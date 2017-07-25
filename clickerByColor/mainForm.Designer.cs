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
            this.components = new System.ComponentModel.Container();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fromCamGroupBox = new System.Windows.Forms.GroupBox();
            this.fromCamPictureBox = new System.Windows.Forms.PictureBox();
            this.colorBlobAdjustmentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.interestedColorgroupBox = new System.Windows.Forms.GroupBox();
            this.detectionColorListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addInterestedColorBtn = new System.Windows.Forms.Button();
            this.removeInterestedColorBtn = new System.Windows.Forms.Button();
            this.interestedColorList = new System.Windows.Forms.ListView();
            this.colorSample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openImageBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blobCountUpdater = new System.Windows.Forms.Timer(this.components);
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.numPersonTextBox = new System.Windows.Forms.TextBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.fromCamGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromCamPictureBox)).BeginInit();
            this.colorBlobAdjustmentTableLayoutPanel.SuspendLayout();
            this.interestedColorgroupBox.SuspendLayout();
            this.detectionColorListTableLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.Controls.Add(this.fromCamGroupBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.colorBlobAdjustmentTableLayoutPanel, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.menuStrip1, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1006, 603);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // fromCamGroupBox
            // 
            this.fromCamGroupBox.Controls.Add(this.fromCamPictureBox);
            this.fromCamGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromCamGroupBox.Location = new System.Drawing.Point(3, 33);
            this.fromCamGroupBox.Name = "fromCamGroupBox";
            this.fromCamGroupBox.Size = new System.Drawing.Size(798, 567);
            this.fromCamGroupBox.TabIndex = 1;
            this.fromCamGroupBox.TabStop = false;
            this.fromCamGroupBox.Text = "Result";
            // 
            // fromCamPictureBox
            // 
            this.fromCamPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromCamPictureBox.Location = new System.Drawing.Point(3, 18);
            this.fromCamPictureBox.Name = "fromCamPictureBox";
            this.fromCamPictureBox.Size = new System.Drawing.Size(792, 546);
            this.fromCamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fromCamPictureBox.TabIndex = 0;
            this.fromCamPictureBox.TabStop = false;
            // 
            // colorBlobAdjustmentTableLayoutPanel
            // 
            this.colorBlobAdjustmentTableLayoutPanel.ColumnCount = 1;
            this.colorBlobAdjustmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.colorBlobAdjustmentTableLayoutPanel.Controls.Add(this.interestedColorgroupBox, 0, 0);
            this.colorBlobAdjustmentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorBlobAdjustmentTableLayoutPanel.Location = new System.Drawing.Point(807, 33);
            this.colorBlobAdjustmentTableLayoutPanel.Name = "colorBlobAdjustmentTableLayoutPanel";
            this.colorBlobAdjustmentTableLayoutPanel.RowCount = 1;
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.colorBlobAdjustmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.colorBlobAdjustmentTableLayoutPanel.Size = new System.Drawing.Size(196, 567);
            this.colorBlobAdjustmentTableLayoutPanel.TabIndex = 3;
            // 
            // interestedColorgroupBox
            // 
            this.interestedColorgroupBox.Controls.Add(this.detectionColorListTableLayoutPanel);
            this.interestedColorgroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interestedColorgroupBox.Location = new System.Drawing.Point(3, 3);
            this.interestedColorgroupBox.Name = "interestedColorgroupBox";
            this.interestedColorgroupBox.Size = new System.Drawing.Size(190, 561);
            this.interestedColorgroupBox.TabIndex = 2;
            this.interestedColorgroupBox.TabStop = false;
            this.interestedColorgroupBox.Text = "Interested Colors";
            // 
            // detectionColorListTableLayoutPanel
            // 
            this.detectionColorListTableLayoutPanel.ColumnCount = 1;
            this.detectionColorListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detectionColorListTableLayoutPanel.Controls.Add(this.addInterestedColorBtn, 0, 1);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.removeInterestedColorBtn, 0, 2);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.interestedColorList, 0, 0);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.openImageBtn, 0, 3);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.label1, 0, 4);
            this.detectionColorListTableLayoutPanel.Controls.Add(this.numPersonTextBox, 0, 5);
            this.detectionColorListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectionColorListTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this.detectionColorListTableLayoutPanel.Name = "detectionColorListTableLayoutPanel";
            this.detectionColorListTableLayoutPanel.RowCount = 6;
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.detectionColorListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.detectionColorListTableLayoutPanel.Size = new System.Drawing.Size(184, 540);
            this.detectionColorListTableLayoutPanel.TabIndex = 0;
            // 
            // addInterestedColorBtn
            // 
            this.addInterestedColorBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addInterestedColorBtn.Location = new System.Drawing.Point(3, 393);
            this.addInterestedColorBtn.Name = "addInterestedColorBtn";
            this.addInterestedColorBtn.Size = new System.Drawing.Size(178, 24);
            this.addInterestedColorBtn.TabIndex = 0;
            this.addInterestedColorBtn.Text = "Add Color";
            this.addInterestedColorBtn.UseVisualStyleBackColor = true;
            this.addInterestedColorBtn.Click += new System.EventHandler(this.addInterestedColorBtn_Click);
            // 
            // removeInterestedColorBtn
            // 
            this.removeInterestedColorBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeInterestedColorBtn.Location = new System.Drawing.Point(3, 423);
            this.removeInterestedColorBtn.Name = "removeInterestedColorBtn";
            this.removeInterestedColorBtn.Size = new System.Drawing.Size(178, 24);
            this.removeInterestedColorBtn.TabIndex = 1;
            this.removeInterestedColorBtn.Text = "Remove Color";
            this.removeInterestedColorBtn.UseVisualStyleBackColor = true;
            this.removeInterestedColorBtn.Click += new System.EventHandler(this.removeInterestedColorBtn_Click);
            // 
            // interestedColorList
            // 
            this.interestedColorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colorSample,
            this.colorCount,
            this.columnHeader1});
            this.interestedColorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interestedColorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.interestedColorList.FullRowSelect = true;
            this.interestedColorList.GridLines = true;
            this.interestedColorList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.interestedColorList.Location = new System.Drawing.Point(3, 3);
            this.interestedColorList.MultiSelect = false;
            this.interestedColorList.Name = "interestedColorList";
            this.interestedColorList.ShowGroups = false;
            this.interestedColorList.Size = new System.Drawing.Size(178, 384);
            this.interestedColorList.TabIndex = 2;
            this.interestedColorList.UseCompatibleStateImageBehavior = false;
            this.interestedColorList.View = System.Windows.Forms.View.Details;
            // 
            // colorSample
            // 
            this.colorSample.Text = "      ";
            this.colorSample.Width = 50;
            // 
            // colorCount
            // 
            this.colorCount.Text = "Area(%)";
            this.colorCount.Width = 70;
            // 
            // openImageBtn
            // 
            this.openImageBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openImageBtn.Location = new System.Drawing.Point(3, 453);
            this.openImageBtn.Name = "openImageBtn";
            this.openImageBtn.Size = new System.Drawing.Size(178, 24);
            this.openImageBtn.TabIndex = 3;
            this.openImageBtn.Text = "Open Image";
            this.openImageBtn.UseVisualStyleBackColor = true;
            this.openImageBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchCameraToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // switchCameraToolStripMenuItem
            // 
            this.switchCameraToolStripMenuItem.Enabled = false;
            this.switchCameraToolStripMenuItem.Name = "switchCameraToolStripMenuItem";
            this.switchCameraToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.switchCameraToolStripMenuItem.Text = "Switch Camera";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // blobCountUpdater
            // 
            this.blobCountUpdater.Enabled = true;
            this.blobCountUpdater.Interval = 300;
            this.blobCountUpdater.Tick += new System.EventHandler(this.blobCountUpdater_Tick);
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.FileName = "openFileDialog1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Count (Person)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Person";
            // 
            // numPersonTextBox
            // 
            this.numPersonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPersonTextBox.Location = new System.Drawing.Point(3, 513);
            this.numPersonTextBox.Name = "numPersonTextBox";
            this.numPersonTextBox.Size = new System.Drawing.Size(178, 22);
            this.numPersonTextBox.TabIndex = 5;
            this.numPersonTextBox.Text = "1800";
            this.numPersonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPersonTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numPersonTextBox_KeyPress);
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
            this.mainTableLayoutPanel.PerformLayout();
            this.fromCamGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fromCamPictureBox)).EndInit();
            this.colorBlobAdjustmentTableLayoutPanel.ResumeLayout(false);
            this.interestedColorgroupBox.ResumeLayout(false);
            this.detectionColorListTableLayoutPanel.ResumeLayout(false);
            this.detectionColorListTableLayoutPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.PictureBox fromCamPictureBox;
        private System.Windows.Forms.GroupBox fromCamGroupBox;
        private System.Windows.Forms.TableLayoutPanel colorBlobAdjustmentTableLayoutPanel;
        private System.Windows.Forms.GroupBox interestedColorgroupBox;
        private System.Windows.Forms.TableLayoutPanel detectionColorListTableLayoutPanel;
        private System.Windows.Forms.Button addInterestedColorBtn;
        private System.Windows.Forms.Button removeInterestedColorBtn;
        private System.Windows.Forms.ListView interestedColorList;
        private System.Windows.Forms.ColumnHeader colorSample;
        private System.Windows.Forms.ColumnHeader colorCount;
        private System.Windows.Forms.Timer blobCountUpdater;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button openImageBtn;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numPersonTextBox;
    }
}

