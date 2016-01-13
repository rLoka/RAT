namespace Server
{
    partial class FileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileForm));
            this.fileDirView1 = new System.Windows.Forms.TreeView();
            this.fileDirImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // fileDirView1
            // 
            this.fileDirView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileDirView1.Location = new System.Drawing.Point(0, 0);
            this.fileDirView1.Name = "fileDirView1";
            this.fileDirView1.Size = new System.Drawing.Size(284, 261);
            this.fileDirView1.TabIndex = 0;
            // 
            // fileDirImgList
            // 
            this.fileDirImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileDirImgList.ImageStream")));
            this.fileDirImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileDirImgList.Images.SetKeyName(0, "document-medium.png");
            this.fileDirImgList.Images.SetKeyName(1, "folder-horizontal-open.png");
            this.fileDirImgList.Images.SetKeyName(2, "ui-check-box.png");
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fileDirView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileForm";
            this.Text = "FileForm";
            this.Load += new System.EventHandler(this.FileForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView fileDirView1;
        public System.Windows.Forms.ImageList fileDirImgList;
    }
}