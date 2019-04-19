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

namespace TravellingSalesmanProblem {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
            this.pbxDraw.ZoomToRect(0, 0, bw, bh);
        }
        
        int bw = 1000;
        int bh = 1000;
        PointF[] points = { PointF.Empty };
        long[,] dists = new long[,]{ { 0 } };
        int[] visitOrder = { 0 };

        private void btnResetZoom_Click(object sender, EventArgs e) {
            this.pbxDraw.ZoomReset();
        }
        
        private void btnFitZoom_Click(object sender, EventArgs e) {
            this.pbxDraw.ZoomToRect(0, 0, bw, bh);
        }

        private void Log(string text) {
            this.tbxLog.AppendText(text + Environment.NewLine);
        }

        private void btnClearLog_Click(object sender, EventArgs e) {
            this.tbxLog.Clear();
        }

        private void FillSquare(Graphics g, Brush br, PointF pt, float size) {
            g.FillRectangle(br, pt.X-size/2, pt.Y-size/2, size, size);
        }

        private void pbxDraw_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            // 영역
            var rect = new Rectangle(0, 0, bw, bh);
            g.FillRectangle(Brushes.White, this.pbxDraw.RealToDrawRect(rect));

            bool showLine = this.chkShowLine.Checked;
            bool showNumber = this.chkShowNumber.Checked;
            using (var font = SystemFonts.DefaultFont) {
                for (int i = 0; i < this.visitOrder.Length; i++) {
                    var ptIdx = this.visitOrder[i];
                    var pt = this.points[ptIdx];
                    
                    // 선 표시
                    if (showLine) {
                        var ptIdxNext = this.visitOrder[(i+1) % this.visitOrder.Length];
                        var ptNext = this.points[ptIdxNext];
                        g.DrawLine(Pens.Blue, this.pbxDraw.RealToDraw(pt), this.pbxDraw.RealToDraw(ptNext));
                    }

                    // 점 표시
                    FillSquare(g, Brushes.Red, this.pbxDraw.RealToDraw(pt), 4);

                    // 번호 표시
                    if (showNumber)
                        g.DrawString(i.ToString(), font, Brushes.Black, this.pbxDraw.RealToDraw(pt));
                }
            }
        }

        private void chkShowNumber_CheckedChanged(object sender, EventArgs e) {
            this.pbxDraw.Invalidate();
        }

        private void btnGenerateRandomPoints_Click(object sender, EventArgs e) {
            bool fixedSeed = this.chkFixedSeed.Checked;
            int num = (int)this.numPoints.Value;
            Random rnd = fixedSeed ? new Random(0) : new Random();
            
            this.points = new PointF[num];
            this.points[0] = PointF.Empty;
            for (int i = 1; i < this.points.Length; i++) {
                this.points[i] = new PointF((float)(rnd.NextDouble() * (bw-1)), (float)(rnd.NextDouble() * (bh-1)));
            }

            this.CalcDistTable();
            this.SortUpdate();
        }

        private void rdoNoSort_Click(object sender, EventArgs e) {
            this.SortUpdate();
        }

        private void CalcDistTable() {
            double Dist(PointF pt1, PointF pt2) {
                float dx = (pt2.X-pt1.X);
                float dy = (pt2.Y-pt1.Y);
                return Math.Sqrt(dx * dx + dy * dy);
            }

            int num = this.points.Length;
            this.dists = new long[num, num];
            for (int i=0; i<num; i++) {
                var ptI = this.points[i];
                for (int j=0; j<num; j++) {
                    var ptJ = this.points[j];
                    this.dists[i,j] = (long)(Dist(ptI, ptJ) * 1000);
                    this.dists[j,i] = (long)(Dist(ptJ, ptI) * 1000);
                }
            }
        }

        private void SortUpdate() {
            var t0 = Stopwatch.GetTimestamp();
            if (this.rdoNoSort.Checked) {
                this.Log("==== No Sort ====");
                this.NoSort();
            } else if (this.rdoNearestNeighbor.Checked) {
                this.Log("==== Nearest Neighbor ====");
                this.SortNearestNeighbor();
            } else if (this.rdoGoogleRoute.Checked) {
                this.Log("==== Google Route ====");
                this.SortGoogleRoute();
            }
            var ms = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;
            this.Log(string.Format("Calc Time  : {0}ms", ms));
            
            float calcDist = CalcRouteDist();
            this.Log(string.Format("Route Dist : {0}", calcDist));

            this.pbxDraw.Invalidate();
        }

        private float CalcRouteDist() {
            long fullDist = 0;
            for (int i = 0; i < this.visitOrder.Length; i++) {
                var ptIdx = this.visitOrder[i];
                var ptIdxNext = this.visitOrder[(i+1) % this.visitOrder.Length];
                fullDist += this.dists[ptIdx, ptIdxNext];
            }
            return fullDist * 0.001f ;
        }

        private void NoSort() {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();
        }

        private void SortNearestNeighbor() {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();

            for (int i = 0; i < visitOrder.Length - 2; i++) {
                var currPtIdx = visitOrder[i];
                var minDist = float.MaxValue;
                var minIdx = -1;
                for (int j = i + 1; j < visitOrder.Length; j++) {
                    var otherPtIdx = visitOrder[j];
                    var dist = this.dists[currPtIdx, otherPtIdx];
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

        private void SortGoogleRoute() {
            this.visitOrder = TspCities.Run(this.dists, 1, 0);
        }
    }
}
