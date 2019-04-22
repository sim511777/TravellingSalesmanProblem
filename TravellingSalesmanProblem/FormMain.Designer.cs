namespace TravellingSalesmanProblem {
    partial class FormMain {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFitZoom = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.grpSorting = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFirstSolutionStrategy = new System.Windows.Forms.ComboBox();
            this.rdoGoogleRoute = new System.Windows.Forms.RadioButton();
            this.rdoNearestNeighbor = new System.Windows.Forms.RadioButton();
            this.rdoNoSort = new System.Windows.Forms.RadioButton();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnGetPoints = new System.Windows.Forms.Button();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.chkShowNumber = new System.Windows.Forms.CheckBox();
            this.chkFixedSeed = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pbxDraw = new ShimLib.ZoomPictureBox();
            this.panel2.SuspendLayout();
            this.grpSorting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxLog
            // 
            this.tbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxLog.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLog.Location = new System.Drawing.Point(0, 31);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.Size = new System.Drawing.Size(789, 199);
            this.tbxLog.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.grpSorting);
            this.panel2.Controls.Add(this.btnGetPoints);
            this.panel2.Controls.Add(this.numPoints);
            this.panel2.Controls.Add(this.chkFixedSeed);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(517, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 480);
            this.panel2.TabIndex = 6;
            // 
            // btnFitZoom
            // 
            this.btnFitZoom.Location = new System.Drawing.Point(210, 3);
            this.btnFitZoom.Name = "btnFitZoom";
            this.btnFitZoom.Size = new System.Drawing.Size(82, 23);
            this.btnFitZoom.TabIndex = 6;
            this.btnFitZoom.Text = "Fit Zoom";
            this.btnFitZoom.UseVisualStyleBackColor = true;
            this.btnFitZoom.Click += new System.EventHandler(this.btnFitZoom_Click);
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Location = new System.Drawing.Point(122, 3);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(82, 23);
            this.btnResetZoom.TabIndex = 6;
            this.btnResetZoom.Text = "Reset Zoom";
            this.btnResetZoom.UseVisualStyleBackColor = true;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // grpSorting
            // 
            this.grpSorting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSorting.Controls.Add(this.label1);
            this.grpSorting.Controls.Add(this.cbxFirstSolutionStrategy);
            this.grpSorting.Controls.Add(this.rdoGoogleRoute);
            this.grpSorting.Controls.Add(this.rdoNearestNeighbor);
            this.grpSorting.Controls.Add(this.rdoNoSort);
            this.grpSorting.Location = new System.Drawing.Point(5, 32);
            this.grpSorting.Name = "grpSorting";
            this.grpSorting.Size = new System.Drawing.Size(261, 202);
            this.grpSorting.TabIndex = 5;
            this.grpSorting.TabStop = false;
            this.grpSorting.Text = "Sorting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "FirstSolutionStrategy";
            // 
            // cbxFirstSolutionStrategy
            // 
            this.cbxFirstSolutionStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFirstSolutionStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFirstSolutionStrategy.FormattingEnabled = true;
            this.cbxFirstSolutionStrategy.Location = new System.Drawing.Point(28, 98);
            this.cbxFirstSolutionStrategy.Name = "cbxFirstSolutionStrategy";
            this.cbxFirstSolutionStrategy.Size = new System.Drawing.Size(227, 20);
            this.cbxFirstSolutionStrategy.TabIndex = 1;
            this.cbxFirstSolutionStrategy.SelectedIndexChanged += new System.EventHandler(this.cbxFirstSolutionStrategy_SelectedIndexChanged);
            // 
            // rdoGoogleRoute
            // 
            this.rdoGoogleRoute.AutoSize = true;
            this.rdoGoogleRoute.Location = new System.Drawing.Point(6, 64);
            this.rdoGoogleRoute.Name = "rdoGoogleRoute";
            this.rdoGoogleRoute.Size = new System.Drawing.Size(99, 16);
            this.rdoGoogleRoute.TabIndex = 0;
            this.rdoGoogleRoute.Text = "Google Route";
            this.rdoGoogleRoute.UseVisualStyleBackColor = true;
            this.rdoGoogleRoute.Click += new System.EventHandler(this.rdoNoSort_Click);
            // 
            // rdoNearestNeighbor
            // 
            this.rdoNearestNeighbor.AutoSize = true;
            this.rdoNearestNeighbor.Checked = true;
            this.rdoNearestNeighbor.Location = new System.Drawing.Point(6, 42);
            this.rdoNearestNeighbor.Name = "rdoNearestNeighbor";
            this.rdoNearestNeighbor.Size = new System.Drawing.Size(122, 16);
            this.rdoNearestNeighbor.TabIndex = 0;
            this.rdoNearestNeighbor.TabStop = true;
            this.rdoNearestNeighbor.Text = "Neighbor Nearest";
            this.rdoNearestNeighbor.UseVisualStyleBackColor = true;
            this.rdoNearestNeighbor.Click += new System.EventHandler(this.rdoNoSort_Click);
            // 
            // rdoNoSort
            // 
            this.rdoNoSort.AutoSize = true;
            this.rdoNoSort.Location = new System.Drawing.Point(6, 20);
            this.rdoNoSort.Name = "rdoNoSort";
            this.rdoNoSort.Size = new System.Drawing.Size(65, 16);
            this.rdoNoSort.TabIndex = 0;
            this.rdoNoSort.Text = "No Sort";
            this.rdoNoSort.UseVisualStyleBackColor = true;
            this.rdoNoSort.Click += new System.EventHandler(this.rdoNoSort_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(714, 3);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(72, 23);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnGetPoints
            // 
            this.btnGetPoints.Location = new System.Drawing.Point(3, 3);
            this.btnGetPoints.Name = "btnGetPoints";
            this.btnGetPoints.Size = new System.Drawing.Size(75, 23);
            this.btnGetPoints.TabIndex = 0;
            this.btnGetPoints.Text = "Gen Points";
            this.btnGetPoints.UseVisualStyleBackColor = true;
            this.btnGetPoints.Click += new System.EventHandler(this.btnGenerateRandomPoints_Click);
            // 
            // numPoints
            // 
            this.numPoints.Location = new System.Drawing.Point(84, 3);
            this.numPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(67, 21);
            this.numPoints.TabIndex = 1;
            this.numPoints.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkShowNumber
            // 
            this.chkShowNumber.AutoSize = true;
            this.chkShowNumber.Location = new System.Drawing.Point(11, 7);
            this.chkShowNumber.Name = "chkShowNumber";
            this.chkShowNumber.Size = new System.Drawing.Size(105, 16);
            this.chkShowNumber.TabIndex = 4;
            this.chkShowNumber.Text = "Show Number";
            this.chkShowNumber.UseVisualStyleBackColor = true;
            this.chkShowNumber.CheckedChanged += new System.EventHandler(this.chkShowNumber_CheckedChanged);
            // 
            // chkFixedSeed
            // 
            this.chkFixedSeed.AutoSize = true;
            this.chkFixedSeed.Checked = true;
            this.chkFixedSeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFixedSeed.Location = new System.Drawing.Point(157, 4);
            this.chkFixedSeed.Name = "chkFixedSeed";
            this.chkFixedSeed.Size = new System.Drawing.Size(74, 16);
            this.chkFixedSeed.TabIndex = 3;
            this.chkFixedSeed.Text = "Seed Fix";
            this.chkFixedSeed.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pbxDraw);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 480);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbxLog);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 483);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(791, 232);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnFitZoom);
            this.panel5.Controls.Add(this.btnClearLog);
            this.panel5.Controls.Add(this.btnResetZoom);
            this.panel5.Controls.Add(this.chkShowNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(789, 31);
            this.panel5.TabIndex = 6;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 480);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(791, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(514, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 480);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // pbxDraw
            // 
            this.pbxDraw.AutoDrawCenterLine = true;
            this.pbxDraw.AutoDrawCursorPixelInfo = true;
            this.pbxDraw.AxisXInvert = false;
            this.pbxDraw.AxisXYFlip = false;
            this.pbxDraw.AxisYInvert = false;
            this.pbxDraw.BackColor = System.Drawing.Color.DarkGray;
            this.pbxDraw.CenterLineColor = System.Drawing.Color.Yellow;
            this.pbxDraw.CenterLineDotStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.pbxDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxDraw.DrawingImage = null;
            this.pbxDraw.DrawPixelValueZoom = 20F;
            this.pbxDraw.EnableMousePan = true;
            this.pbxDraw.EnableWheelZoom = true;
            this.pbxDraw.Location = new System.Drawing.Point(0, 0);
            this.pbxDraw.Name = "pbxDraw";
            this.pbxDraw.Pan = new System.Drawing.SizeF(0F, 0F);
            this.pbxDraw.Size = new System.Drawing.Size(512, 478);
            this.pbxDraw.TabIndex = 2;
            this.pbxDraw.Text = "zoomPictureBox1";
            this.pbxDraw.UseDrawPixelValue = true;
            this.pbxDraw.Zoom = 1F;
            this.pbxDraw.ZoomMax = 100F;
            this.pbxDraw.ZoomMin = 0.1F;
            this.pbxDraw.ZoomStep = 1.2F;
            this.pbxDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxDraw_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 715);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpSorting.ResumeLayout(false);
            this.grpSorting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Button btnGetPoints;
        private System.Windows.Forms.CheckBox chkFixedSeed;
        private System.Windows.Forms.CheckBox chkShowNumber;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox grpSorting;
        private System.Windows.Forms.RadioButton rdoNearestNeighbor;
        private System.Windows.Forms.RadioButton rdoNoSort;
        private ShimLib.ZoomPictureBox pbxDraw;
        private System.Windows.Forms.Button btnResetZoom;
        private System.Windows.Forms.Button btnFitZoom;
      private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoGoogleRoute;
        private System.Windows.Forms.ComboBox cbxFirstSolutionStrategy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
    }
}

