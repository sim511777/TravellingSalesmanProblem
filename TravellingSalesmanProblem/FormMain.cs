using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Google.OrTools.ConstraintSolver;

namespace TravellingSalesmanProblem {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
            RoutingSearchParameters srcPrms = operations_research_constraint_solver.DefaultRoutingSearchParameters();
            this.grdPrm.SelectedObject = srcPrms;
            this.pbxDraw.ZoomToRect(0, 0, bw, bh);
        }
        
        int bw = 1000;
        int bh = 1000;
        PointF[] points = { PointF.Empty };
        long[] distTable = { 0 };
        int[] visitOrder = { 0 };

        private void Log(string text) {
            Action action = () => this.tbxLog.AppendText(text + Environment.NewLine);
            if (this.tbxLog.InvokeRequired)
                this.tbxLog.BeginInvoke(action);
            else
                action();
        }

        private void FillSquare(Graphics g, Brush br, PointF pt, float size) {
            g.FillRectangle(br, pt.X-size/2, pt.Y-size/2, size, size);
        }

        private void GeneratePoints(int num, Random rnd) {
           
            this.points = new PointF[num];
            this.points[0] = PointF.Empty;
            for (int i = 1; i < this.points.Length; i++) {
                this.points[i] = new PointF((float)(rnd.NextDouble() * (bw-1)), (float)(rnd.NextDouble() * (bh-1)));
            }
        }

        private void CalcDistTable() {
            double PointDistance(PointF pt1, PointF pt2) {
                float dx = (pt2.X-pt1.X);
                float dy = (pt2.Y-pt1.Y);
                return Math.Sqrt(dx * dx + dy * dy);
            }

            int num = this.points.Length;
            this.distTable = new long[num * num];
            for (int i=0; i<num; i++) {
                var ptI = this.points[i];
                for (int j=0; j<num; j++) {
                    var ptJ = this.points[j];
                    this.distTable[i * num + j] = (long)(PointDistance(ptI, ptJ) * 1000);
                    this.distTable[j * num + i] = (long)(PointDistance(ptJ, ptI) * 1000);
                }
            }
        }

        private void SortUpdate() {
            var t0 = Stopwatch.GetTimestamp();
            
            try {
                if (this.rdoNoSort.Checked) {
                    this.Log("==== No Sort ====");
                    this.NoSort();
                }
                else if (this.rdoNearestNeighbor.Checked) {
                    this.Log("==== Nearest Neighbor ====");
                    this.SortNearestNeighbor();
                }
                else if (this.rdo2Opt.Checked) {
                    this.Log("==== 2-OPT ====");
                    this.NoSort();
                    this.Improve2Opt();
                }
                else if (this.rdo2OptNative.Checked) {
                    this.Log("==== 2-OPT ====");
                    this.NoSort();
                    AlgDll.Improve2Opt(this.visitOrder, this.visitOrder.Length, this.distTable);
                }
                else if (this.rdoNearestNeighbor2Opt.Checked) {
                    this.Log("==== Nearest Neighbor + 2-OPT====");
                    this.SortNearestNeighbor();
                    this.Improve2Opt();
                }
                else if (this.rdoNearestNeighbor2OptNative.Checked) {
                    this.Log("==== Nearest Neighbor + 2-OPT====");
                    this.SortNearestNeighbor();
                    AlgDll.Improve2Opt(this.visitOrder, this.visitOrder.Length, this.distTable);
                }
                else if (this.rdoGoogleRoute.Checked) {
                    string msg = string.Format("==== Google Route ====");
                    this.Log(msg);
                    RoutingSearchParameters srcPrms = (RoutingSearchParameters)this.grdPrm.SelectedObject;
                    this.SortGoogleRoute(srcPrms);
                }
            } catch (Exception ex) {
                this.visitOrder = new int[0];
                this.Log(ex.ToString());
            }
            
            var ms = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;

            float calcDist = CalcRouteDist(this.visitOrder);

            this.Log(string.Format("Route Dist : {0}", calcDist));
            this.Log(string.Format("Calc Time  : {0}ms", ms));

            this.pbxDraw.Invalidate();
        }

        private float CalcRouteDist(int[] order) {
            return CalcRouteDistLong(order) * 0.001f;
        }

        private long CalcRouteDistLong(int[] order) {
            int num = order.Length;
            long fullDist = 0;
            for (int i = 0; i < order.Length; i++) {
                var ptIdx = order[i];
                var ptIdxNext = order[(i+1) % order.Length];
                fullDist += this.distTable[ptIdx * num + ptIdxNext];
            }
            return fullDist;
        }

        private void NoSort() {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();
        }

        private void SortNearestNeighbor() {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();

            int num = this.visitOrder.Length;

            for (int i = 0; i < visitOrder.Length - 2; i++) {
                var currPtIdx = visitOrder[i];
                var minDist = float.MaxValue;
                var minIdx = -1;
                for (int j = i + 1; j < visitOrder.Length; j++) {
                    var otherPtIdx = visitOrder[j];
                    var dist = this.distTable[currPtIdx * num + otherPtIdx];
                    if (dist < minDist) {
                        minDist = dist;
                        minIdx = j;
                    }
                }
                int temp = visitOrder[i + 1];
                visitOrder[i + 1] = visitOrder[minIdx];
                visitOrder[minIdx] = temp;
            }
        }

        private void Improve2Opt() {
            void Swap2Opt(int[] route, int start, int end) {
                for (int i=start, j=end; i<j; i++, j--) {
                    int temp = route[i];
                    route[i] = route[j];
                    route[j] = temp;
                }
            }

            int num = this.visitOrder.Length;
            int[] bestRoute = (int[])this.visitOrder.Clone();
            long bestDistance = CalcRouteDistLong(bestRoute);

            bool improved;
            do {
                improved = false;
                for (int i = 1; i < num - 1; i++) {
                    for (int j = i + 1; j < num; j++) {
                        long newDistance = bestDistance
                            - this.distTable[bestRoute[i] * num + bestRoute[i-1]]
                            - this.distTable[bestRoute[j] * num + bestRoute[(j+1) % num]]
                            + this.distTable[bestRoute[j] * num + bestRoute[i-1]]
                            + this.distTable[bestRoute[i] * num + bestRoute[(j+1) % num]];
                        if (newDistance < bestDistance) {
                            bestDistance = newDistance;
                            Swap2Opt(bestRoute, i, j);
                            improved = true;
                            break;
                        }
                    }
                    if (improved)
                        break;
                }
            } while (improved);

            Array.Copy(bestRoute, this.visitOrder, num);
        }

        private void SortGoogleRoute(RoutingSearchParameters srcPrms) {
            this.visitOrder = TspCities.Run(this.distTable, this.points.Length, 1, 0, srcPrms);
        }

        private void DoBenchmark() {
            Log("==== Benchmark Started ====");
            Random rnd = new Random();
            int[] pointNums = {100, 200, 500};
            int benchNum = (int)numBenchMark.Value;
            foreach (var pointNum in pointNums) {
                this.Log(string.Format("== PointNum : {0}", pointNum));
                for (int benchIndex = 0; benchIndex < benchNum; benchIndex++) {
                    GeneratePoints(pointNum, rnd);
                    CalcDistTable();

                    long t0 = Stopwatch.GetTimestamp();
                    SortNearestNeighbor();
                    double ms0 = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;
                    float calcDist0 = CalcRouteDist(this.visitOrder);

                    t0 = Stopwatch.GetTimestamp();
                    SortNearestNeighbor();
                    AlgDll.Improve2Opt(this.visitOrder, this.visitOrder.Length, this.distTable);
                    double ms1 = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;
                    float calcDist1 = CalcRouteDist(this.visitOrder);

                    t0 = Stopwatch.GetTimestamp();
                    this.visitOrder = TspCities.Run(this.distTable, this.points.Length, 1, 0, (RoutingSearchParameters)this.grdPrm.SelectedObject);
                    double ms2 = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;
                    float calcDist2 = CalcRouteDist(this.visitOrder);

                    this.Log(string.Format("Greedy : {0}, Time : {1}ms / Greedy+2OPT : {2}, Time : {3}ms / GoogleRoute : {4}, Time : {5}ms", calcDist0, ms0, calcDist1, ms1, calcDist2, ms2));
                } 
            }
            Log("==== Benchmark Finished ====");
        }

        // ==== event handler ====
        private void btnClearLog_Click(object sender, EventArgs e) {
            this.tbxLog.Clear();
        }
        
        private void chkShowNumber_CheckedChanged(object sender, EventArgs e) {
            this.pbxDraw.Invalidate();
        }

        private void btnResetZoom_Click(object sender, EventArgs e) {
            this.pbxDraw.ZoomReset();
        }
        
        private void btnFitZoom_Click(object sender, EventArgs e) {
            this.pbxDraw.ZoomToRect(0, 0, bw, bh);
        }

        private void pbxDraw_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            // 영역
            var rect = new Rectangle(0, 0, bw, bh);
            g.FillRectangle(Brushes.White, this.pbxDraw.RealToDrawRect(rect));

            bool showNumber = this.chkShowNumber.Checked;
            using (var font = SystemFonts.DefaultFont) {
                for (int i = 0; i < this.visitOrder.Length; i++) {
                    var ptIdx = this.visitOrder[i];
                    var pt = this.points[ptIdx];

                    // 선 표시
                    var ptIdxNext = this.visitOrder[(i+1) % this.visitOrder.Length];
                    var ptNext = this.points[ptIdxNext];
                    g.DrawLine(Pens.Blue, this.pbxDraw.RealToDraw(pt), this.pbxDraw.RealToDraw(ptNext));

                    // 점 표시
                    FillSquare(g, Brushes.Red, this.pbxDraw.RealToDraw(pt), 4);

                    // 번호 표시
                    if (showNumber)
                        g.DrawString(i.ToString(), font, Brushes.Black, this.pbxDraw.RealToDraw(pt));
                }
            }
        }

        private void btnGenerateRandomPoints_Click(object sender, EventArgs e) {
            int num = (int)this.numPoints.Value;
            Random rnd = this.chkFixedSeed.Checked ? new Random(0) : new Random();
            GeneratePoints(num, rnd);

            this.CalcDistTable();
            this.SortUpdate();
        }

        private void rdoNoSort_Click(object sender, EventArgs e) {
            this.SortUpdate();
        }

        private void grdPrm_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            this.SortUpdate();
        }

        private async void btnBenchmark_Click(object sender, EventArgs e) {
            await Task.Run(() => DoBenchmark());
        }
    }
}
