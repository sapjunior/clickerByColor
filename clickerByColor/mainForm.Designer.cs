namespace clickerByColor
{
    partial class mainForm
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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fromCamPictureBox = new System.Windows.Forms.PictureBox();
            this.fromCamGroupBox = new System.Windows.Forms.GroupBox();
            this.colorBlobAdjustmentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.minBlobSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.maxBlobSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.interestedColorgroupBox = new System.Windows.Forms.GroupBox();
            this.minBlobSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.maxBlobSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.detectionColorListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addInterestedColorBtn = new System.Windows.Forms.Button();
            this.removeInterestedColorBtn = new System.Windows.Forms.Button();
            this.interestedColorList = new System.Windows.Forms.ListView();
            this.colorNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorSample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromCamPictureBox)).BeginInit();
            this.fromCamGroupBox.SuspendLayout();
            this.colorBlobAdjustmentTableLayoutPanel.SuspendLayout();
            this.minBlobSizeGroupBox.SuspendLayout();
            this.maxBlobSizeGroupBox.SuspendLayout();
            this.interestedColorgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minBlobSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlobSizeTrackBar)).BeginInit();
            this.detectionColorListTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.Controls.Add(this.fromCamGroupBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.colorBlobAdjustmentTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1006, 603);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // fromCamPictureBox
            // 
            this.fromCamPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromCamPictureBox.Location = new System.Drawing.Point(3, 18);
            this.fromCamPictureBox.Name = "fromCamPictureBox";
            this.fromCamPictureBox.Size = new System.Drawing.Size(792, 576);
            this.fromCamPictureBox.TabIndex = 0;
            this.fromCamPictureBox.TabStop = false;
            // 
            // fromCamGroupBox
            // 
            this.fromCamGroupBox.Controls.Add(this.fromCamPictureBox);
            this.fromCamGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromCamGroupBox.Location = new System.Drawing.Point(3, 3);
            this.fromCamGroupBox.Name = "fromCamGroupBox";
            this.fromCamGroupBox.Size = new System.Drawing.Size(798, 597);
            this.fromCamGroupBox.TabIndex = 1;
            this.fromCamGroupBox.TabStop = false;
            this.fromCamGroupBox.Text = "Live Sream";
            // 
            // colorBlobAdjustmentTableLayoutPanel
            // 
            this.colorBlobAdjustmentTableLayoutPanel.ColumnCount = 1;
            this.colorBlobAdjustmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.colorBlobAdjustmentTableLayoutPanel.Controls.Add(this.minBlobSizeGroupBox, 0, 1);
            this.colorBlobAdjustmentTableLayoutPanel.Controls.Add(this.maxBlobSizeGroupBox, 0, 2);
            this.colorBlobAdjustmentTableLayoutPanel.Controls.Add(this.interestedColorgroupBox, 0, 0);
            this.colorBlobAdjustmentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorBlobAdjustmentTableLayoutPanel.Location = new System.Drawing.Point(807, 3);
            this.colorBlobAdjustmentTableLayoutPanel.Name = "colorBlobAdjustmentTableLayoutPanel";
            this.colorBlobAdjustmentTableLayoutPanel.RowCount = 3;
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.colorBlobAdjustmentTableLayoutPanel.Size = new System.Drawing.Size(196, 597);
            this.colorBlobAdjustmentTableLayoutPanel.TabIndex = 3;
            // 
            // minBlobSizeGroupBox
            // 
            this.minBlobSizeGroupBox.Controls.Add(this.minBlobSizeTrackBar);
            this.minBlobSizeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minBlobSizeGroupBox.Location = new System.Drawing.Point(3, 420);
            this.minBlobSizeGroupBox.Name = "minBlobSizeGroupBox";
            this.minBlobSizeGroupBox.Size = new System.Drawing.Size(190, 83);
            this.minBlobSizeGroupBox.TabIndex = 0;
            this.minBlobSizeGroupBox.TabStop = false;
            this.minBlobSizeGroupBox.Text = "Minimum Blob Size (%)";
            // 
            // maxBlobSizeGroupBox
            // 
            this.maxBlobSizeGroupBox.Controls.Add(this.maxBlobSizeTrackBar);
            this.maxBlobSizeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxBlobSizeGroupBox.Location = new System.Drawing.Point(3, 509);
            this.maxBlobSizeGroupBox.Name = "maxBlobSizeGroupBox";
            this.maxBlobSizeGroupBox.Size = new System.Drawing.Size(190, 85);
            this.maxBlobSizeGroupBox.TabIndex = 1;
            this.maxBlobSizeGroupBox.TabStop = false;
            this.maxBlobSizeGroupBox.Text = "Maximum Blob Size (%)";
            // 
            // interestedColorgroupBox
            // 
            this.interestedColorgroupBox.Controls.Add(this.detectionColorListTableLayoutPanel);
            this.interestedColorgroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interestedColorgroupBox.Location = new System.Drawing.Point(3, 3);
            this.interestedColorgroupBox.Name = "interestedColorgroupBox";
            this.interestedColorgroupBox.Size = new System.Drawing.Size(190, 411);
            this.interestedColorgroupBox.TabIndex = 2;
            this.interestedColorgroupBox.TabStop = false;
            this.interestedColorgroupBox.Text = "Interested Colors";
            // 
            // minBlobSizeTrackBar
            // 
            this.minBlobSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minBlobSizeTrackBar.Location = new System.Drawing.Point(3, 18);
            this.minBlobSizeTrackBar.Minimum = 1;
            this.minBlobSizeTrackBar.Name = "minBlobSizeTrackBar";
            this.minBlobSizeTrackBar.Size = new System.Drawing.Size(184, 62);
            this.minBlobSizeTrackBar.TabIndex = 0;
            this.minBlobSizeTrackBar.Value = 1;
            // 
            // maxBlobSizeTrackBar
            // 
            this.maxBlobSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxBlobSizeTrackBar.Location = new System.Drawing.Point(3, 18);
            this.maxBlobSizeTrackBar.Minimum = 1;
            this.maxBlobSizeTrackBar.Name = "maxBlobSizeTrackBar";
            this.maxBlobSizeTrackBar.Size = new System.Drawing.Size(184, 64);
            this.maxBlobSizeTrackBar.TabIndex = 0;
            this.maxBlobSizeTrackBar.Value = 3;
            // 
            // detectionColorListTableLayoutPanel
            // 
            this.detectionColorListTableLayoutPanel.ColumnCount = 1;
            this.detectionColorListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detectionColorListTableLayoutPanel.Controls.Add(this.addInterestedColorBtn, 0, 1);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.removeInterestedColorBtn, 0, 2);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.interestedColorList, 0, 0);
            this.detectionColorListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectionColorListTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this.detectionColorListTableLayoutPanel.Name = "detectionColorListTableLayoutPanel";
            this.detectionColorListTableLayoutPanel.RowCount = 3;
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.detectionColorListTableLayoutPanel.Size = new System.Drawing.Size(184, 390);
            this.detectionColorListTableLayoutPanel.TabIndex = 0;
            // 
            // addInterestedColorBtn
            // 
            this.addInterestedColorBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addInterestedColorBtn.Location = new System.Drawing.Point(3, 315);
            this.addInterestedColorBtn.Name = "addInterestedColorBtn";
            this.addInterestedColorBtn.Size = new System.Drawing.Size(178, 33);
            this.addInterestedColorBtn.TabIndex = 0;
            this.addInterestedColorBtn.Text = "Add Color";
            this.addInterestedColorBtn.UseVisualStyleBackColor = true;
            this.addInterestedColorBtn.Click += new System.EventHandler(this.addInterestedColorBtn_Click);
            // 
            // removeInterestedColorBtn
            // 
            this.removeInterestedColorBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeInterestedColorBtn.Location = new System.Drawing.Point(3, 354);
            this.removeInterestedColorBtn.Name = "removeInterestedColorBtn";
            this.removeInterestedColorBtn.Size = new System.Drawing.Size(178, 33);
            this.removeInterestedColorBtn.TabIndex = 1;
            this.removeInterestedColorBtn.Text = "Remove Color";
            this.removeInterestedColorBtn.UseVisualStyleBackColor = true;
            this.removeInterestedColorBtn.Click += new System.EventHandler(this.removeInterestedColorBtn_Click);
            // 
            // interestedColorList
            // 
            this.interestedColorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colorNo,
            this.colorSample,
            this.colorCount});
            this.interestedColorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interestedColorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.interestedColorList.FullRowSelect = true;
            this.interestedColorList.GridLines = true;
            this.interestedColorList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.interestedColorList.Location = new System.Drawing.Point(3, 3);
            this.interestedColorList.MultiSelect = false;
            this.interestedColorList.Name = "interestedColorList";
            this.interestedColorList.Scrollable = false;
            this.interestedColorList.ShowGroups = false;
            this.interestedColorList.Size = new System.Drawing.Size(178, 306);
            this.interestedColorList.TabIndex = 2;
            this.interestedColorList.UseCompatibleStateImageBehavior = false;
            this.interestedColorList.View = System.Windows.Forms.View.Details;
            // 
            // colorNo
            // 
            this.colorNo.Text = "No";
            this.colorNo.Width = 35;
            // 
            // colorSample
            // 
            this.colorSample.Text = "      ";
            this.colorSample.Width = 40;
            // 
            // colorCount
            // 
            this.colorCount.Text = "Count";
            this.colorCount.Width = 106;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 603);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "mainForm";
            this.Text = "Clicker By Color";
            this.mainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fromCamPictureBox)).EndInit();
            this.fromCamGroupBox.ResumeLayout(false);
            this.colorBlobAdjustmentTableLayoutPanel.ResumeLayout(false);
            this.minBlobSizeGroupBox.ResumeLayout(false);
            this.minBlobSizeGroupBox.PerformLayout();
            this.maxBlobSizeGroupBox.ResumeLayout(false);
            this.maxBlobSizeGroupBox.PerformLayout();
            this.interestedColorgroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minBlobSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlobSizeTrackBar)).EndInit();
            this.detectionColorListTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.PictureBox fromCamPictureBox;
        private System.Windows.Forms.GroupBox fromCamGroupBox;
        private System.Windows.Forms.TableLayoutPanel colorBlobAdjustmentTableLayoutPanel;
        private System.Windows.Forms.GroupBox minBlobSizeGroupBox;
        private System.Windows.Forms.GroupBox maxBlobSizeGroupBox;
        private System.Windows.Forms.GroupBox interestedColorgroupBox;
        private System.Windows.Forms.TrackBar minBlobSizeTrackBar;
        private System.Windows.Forms.TrackBar maxBlobSizeTrackBar;
        private System.Windows.Forms.TableLayoutPanel detectionColorListTableLayoutPanel;
        private System.Windows.Forms.Button addInterestedColorBtn;
        private System.Windows.Forms.Button removeInterestedColorBtn;
        private System.Windows.Forms.ListView interestedColorList;
        private System.Windows.Forms.ColumnHeader colorNo;
        private System.Windows.Forms.ColumnHeader colorSample;
        private System.Windows.Forms.ColumnHeader colorCount;
    }
}

