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
        
        int bw = 1500;
        int bh = 900;
        PointF[] points = { PointF.Empty };
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

            // 점
            foreach (var point in this.points) {
                FillSquare(g, Brushes.Red, this.pbxDraw.RealToDraw(point), 4);
            }

            bool showLine = this.chkShowLine.Checked;
            bool showNumber = this.chkShowNumber.Checked;
            using (var font = SystemFonts.DefaultFont) {
                for (int i = 0; i < this.visitOrder.Length; i++) {
                    var ptIdx = this.visitOrder[i];
                    var pt = this.points[ptIdx];
                    if (showLine) {
                        var ptIdxNext = this.visitOrder[(i+1) % this.visitOrder.Length];
                        var ptNext = this.points[ptIdxNext];
                        g.DrawLine(Pens.Blue, this.pbxDraw.RealToDraw(pt), this.pbxDraw.RealToDraw(ptNext));
                    }
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

            this.SortUpdate();
        }

        private void rdoNoSort_Click(object sender, EventArgs e) {
            this.SortUpdate();
        }

        private void SortUpdate() {
            bool eucDist = this.chkEucDist.Checked;
            var t0 = Stopwatch.GetTimestamp();
            if (this.rdoNoSort.Checked) {
                this.NoSort(eucDist);
            } else if (this.rdoNearestNeighbor.Checked) {
                this.SortNearestNeighbor(eucDist);
            }
            var ms = (Stopwatch.GetTimestamp() - t0) / (double)Stopwatch.Frequency * 1000;
            this.Log(string.Format("sort time {0}ms", ms));
            this.pbxDraw.Invalidate();
        }

        private float Dist(PointF pt1, PointF pt2, bool eucDist) {
            float dx = (pt2.X-pt1.X);
            float dy = (pt2.Y-pt1.Y);
            if (eucDist)
                return (float)Math.Sqrt(dx * dx + dy * dy);
            else
                return Math.Max(Math.Abs(dx), Math.Abs(dy));    // dx, dy중 큰 값
        }

        private float CalcFullDist(bool eucDist) {
            float fullDist = 0;
            for (int i = 0; i < this.visitOrder.Length; i++) {
                var ptIdx = this.visitOrder[i];
                var pt = this.points[ptIdx];
                var ptIdxNext = this.visitOrder[(i+1) % this.visitOrder.Length];
                var ptNext = this.points[ptIdxNext];
                fullDist += Dist(pt, ptNext, eucDist);
            }
            return fullDist;
        }

        private void NoSort(bool eucDist) {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();

            float calcDist = CalcFullDist(eucDist);
            this.Log(string.Format("No Sort Dist          : {0}", calcDist));
        }

        private void SortNearestNeighbor(bool eucDist) {
            this.visitOrder = Enumerable.Range(0, this.points.Length).ToArray();

            for (int i = 0; i < visitOrder.Length - 2; i++) {
                var currPtIdx = visitOrder[i];
                var currPt = this.points[currPtIdx];
                var minDist = float.MaxValue;
                var minIdx = -1;
                for (int j = i + 1; j < visitOrder.Length; j++) {
                    var otherPtIdx = visitOrder[j];
                    var otherPt = this.points[otherPtIdx];
                    var dist = Dist(currPt, otherPt, eucDist);
                    if (dist < minDist) {
                        minDist = dist;
                        minIdx = j;
                    }
                }
                int temp = visitOrder[i + 1];
                visitOrder[i + 1] = visitOrder[minIdx];
                visitOrder[minIdx] = temp;
            }

            float calcDist = CalcFullDist(eucDist);
            this.Log(string.Format("Nearest Neighbor Dist : {0}", calcDist));
        }
    }
}
