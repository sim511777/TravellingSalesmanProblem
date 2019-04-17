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
         this.panel1 = new System.Windows.Forms.Panel();
         this.tbxLog = new System.Windows.Forms.TextBox();
         this.panel2 = new System.Windows.Forms.Panel();
         this.btnFitZoom = new System.Windows.Forms.Button();
         this.btnResetZoom = new System.Windows.Forms.Button();
         this.grpSorting = new System.Windows.Forms.GroupBox();
         this.rdoNearestNeighbor = new System.Windows.Forms.RadioButton();
         this.rdoNoSort = new System.Windows.Forms.RadioButton();
         this.btnClearLog = new System.Windows.Forms.Button();
         this.btnGetPoints = new System.Windows.Forms.Button();
         this.numPoints = new System.Windows.Forms.NumericUpDown();
         this.chkShowLine = new System.Windows.Forms.CheckBox();
         this.chkShowNumber = new System.Windows.Forms.CheckBox();
         this.chkFixedSeed = new System.Windows.Forms.CheckBox();
         this.splitter1 = new System.Windows.Forms.Splitter();
         this.pbxDraw = new ShimLib.ZoomPictureBox();
         this.panel3 = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.grpSorting.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
         this.panel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.tbxLog);
         this.panel1.Controls.Add(this.panel2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
         this.panel1.Location = new System.Drawing.Point(603, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(267, 600);
         this.panel1.TabIndex = 0;
         // 
         // tbxLog
         // 
         this.tbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbxLog.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbxLog.Location = new System.Drawing.Point(0, 383);
         this.tbxLog.Multiline = true;
         this.tbxLog.Name = "tbxLog";
         this.tbxLog.Size = new System.Drawing.Size(265, 215);
         this.tbxLog.TabIndex = 5;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.btnFitZoom);
         this.panel2.Controls.Add(this.btnResetZoom);
         this.panel2.Controls.Add(this.grpSorting);
         this.panel2.Controls.Add(this.btnClearLog);
         this.panel2.Controls.Add(this.btnGetPoints);
         this.panel2.Controls.Add(this.numPoints);
         this.panel2.Controls.Add(this.chkShowLine);
         this.panel2.Controls.Add(this.chkShowNumber);
         this.panel2.Controls.Add(this.chkFixedSeed);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(265, 383);
         this.panel2.TabIndex = 6;
         // 
         // btnFitZoom
         // 
         this.btnFitZoom.Location = new System.Drawing.Point(93, 354);
         this.btnFitZoom.Name = "btnFitZoom";
         this.btnFitZoom.Size = new System.Drawing.Size(82, 23);
         this.btnFitZoom.TabIndex = 6;
         this.btnFitZoom.Text = "Fit Zoom";
         this.btnFitZoom.UseVisualStyleBackColor = true;
         this.btnFitZoom.Click += new System.EventHandler(this.btnFitZoom_Click);
         // 
         // btnResetZoom
         // 
         this.btnResetZoom.Location = new System.Drawing.Point(5, 354);
         this.btnResetZoom.Name = "btnResetZoom";
         this.btnResetZoom.Size = new System.Drawing.Size(82, 23);
         this.btnResetZoom.TabIndex = 6;
         this.btnResetZoom.Text = "Reset Zoom";
         this.btnResetZoom.UseVisualStyleBackColor = true;
         this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
         // 
         // grpSorting
         // 
         this.grpSorting.Controls.Add(this.rdoNearestNeighbor);
         this.grpSorting.Controls.Add(this.rdoNoSort);
         this.grpSorting.Location = new System.Drawing.Point(5, 76);
         this.grpSorting.Name = "grpSorting";
         this.grpSorting.Size = new System.Drawing.Size(249, 255);
         this.grpSorting.TabIndex = 5;
         this.grpSorting.TabStop = false;
         this.grpSorting.Text = "Sorting";
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
         this.btnClearLog.Location = new System.Drawing.Point(181, 354);
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
         // chkShowLine
         // 
         this.chkShowLine.AutoSize = true;
         this.chkShowLine.Checked = true;
         this.chkShowLine.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkShowLine.Location = new System.Drawing.Point(3, 54);
         this.chkShowLine.Name = "chkShowLine";
         this.chkShowLine.Size = new System.Drawing.Size(84, 16);
         this.chkShowLine.TabIndex = 4;
         this.chkShowLine.Text = "Show Line";
         this.chkShowLine.UseVisualStyleBackColor = true;
         this.chkShowLine.CheckedChanged += new System.EventHandler(this.chkShowNumber_CheckedChanged);
         // 
         // chkShowNumber
         // 
         this.chkShowNumber.AutoSize = true;
         this.chkShowNumber.Checked = true;
         this.chkShowNumber.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkShowNumber.Location = new System.Drawing.Point(3, 32);
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
         // splitter1
         // 
         this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
         this.splitter1.Location = new System.Drawing.Point(600, 0);
         this.splitter1.Name = "splitter1";
         this.splitter1.Size = new System.Drawing.Size(3, 600);
         this.splitter1.TabIndex = 1;
         this.splitter1.TabStop = false;
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
         this.pbxDraw.Size = new System.Drawing.Size(598, 598);
         this.pbxDraw.TabIndex = 2;
         this.pbxDraw.Text = "zoomPictureBox1";
         this.pbxDraw.UseDrawPixelValue = true;
         this.pbxDraw.Zoom = 1F;
         this.pbxDraw.ZoomMax = 100F;
         this.pbxDraw.ZoomMin = 0.1F;
         this.pbxDraw.ZoomStep = 1.2F;
         this.pbxDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxDraw_Paint);
         // 
         // panel3
         // 
         this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel3.Controls.Add(this.pbxDraw);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(600, 600);
         this.panel3.TabIndex = 3;
         // 
         // FormMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(870, 600);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.splitter1);
         this.Controls.Add(this.panel1);
         this.Name = "FormMain";
         this.Text = "Form1";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.grpSorting.ResumeLayout(false);
         this.grpSorting.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
         this.panel3.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Button btnGetPoints;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox chkFixedSeed;
        private System.Windows.Forms.CheckBox chkShowLine;
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
   }
}

