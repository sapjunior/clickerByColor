namespace clickerByColor
{
    partial class selectColorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fromWebcamPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.segmentationResultPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancleBtn = new System.Windows.Forms.Button();
            this.displayTableLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromWebcamPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentationResultPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayTableLayoutPanel
            // 
            this.displayTableLayoutPanel.ColumnCount = 2;
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this.displayTableLayoutPanel.Controls.Add(this.groupBox2, 1, 0);
            this.displayTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.displayTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.displayTableLayoutPanel.Name = "displayTableLayoutPanel";
            this.displayTableLayoutPanel.RowCount = 2;
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.displayTableLayoutPanel.Size = new System.Drawing.Size(1342, 721);
            this.displayTableLayoutPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fromWebcamPictureBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 675);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Image";
            // 
            // fromWebcamPictureBox
            // 
            this.fromWebcamPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromWebcamPictureBox.Location = new System.Drawing.Point(3, 18);
            this.fromWebcamPictureBox.Name = "fromWebcamPictureBox";
            this.fromWebcamPictureBox.Size = new System.Drawing.Size(659, 654);
            this.fromWebcamPictureBox.TabIndex = 0;
            this.fromWebcamPictureBox.TabStop = false;
            this.fromWebcamPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fromWebcamPictureBox_MouseDown);
            this.fromWebcamPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fromWebcamPictureBox_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.segmentationResultPictureBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(674, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 675);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Segmentation Result";
            // 
            // segmentationResultPictureBox
            // 
            this.segmentationResultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentationResultPictureBox.Location = new System.Drawing.Point(3, 18);
            this.segmentationResultPictureBox.Name = "segmentationResultPictureBox";
            this.segmentationResultPictureBox.Size = new System.Drawing.Size(659, 654);
            this.segmentationResultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.segmentationResultPictureBox.TabIndex = 0;
            this.segmentationResultPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.okBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancleBtn, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(674, 684);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okBtn.Location = new System.Drawing.Point(3, 3);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(326, 28);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancleBtn
            // 
            this.cancleBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancleBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancleBtn.Location = new System.Drawing.Point(335, 3);
            this.cancleBtn.Name = "cancleBtn";
            this.cancleBtn.Size = new System.Drawing.Size(327, 28);
            this.cancleBtn.TabIndex = 1;
            this.cancleBtn.Text = "Cancle";
            this.cancleBtn.UseVisualStyleBackColor = true;
            // 
            // selectColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 721);
            this.Controls.Add(this.displayTableLayoutPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "selectColorForm";
            this.Text = "Select Color";
            this.Load += new System.EventHandler(this.selectColorForm_Load);
            this.Resize += new System.EventHandler(this.selectColorForm_Resize);
            this.displayTableLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fromWebcamPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.segmentationResultPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayTableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox fromWebcamPictureBox;
        private System.Windows.Forms.PictureBox segmentationResultPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancleBtn;
    }
}