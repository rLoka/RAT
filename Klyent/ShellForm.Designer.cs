namespace Server
{
    partial class ShellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            this.rbtCmdBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rbtCmdBox
            // 
            this.rbtCmdBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.rbtCmdBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbtCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtCmdBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCmdBox.ForeColor = System.Drawing.SystemColors.Info;
            this.rbtCmdBox.Location = new System.Drawing.Point(0, 0);
            this.rbtCmdBox.Name = "rbtCmdBox";
            this.rbtCmdBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rbtCmdBox.Size = new System.Drawing.Size(641, 332);
            this.rbtCmdBox.TabIndex = 0;
            this.rbtCmdBox.Text = "";
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 332);
            this.Controls.Add(this.rbtCmdBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShellForm";
            this.Text = "ShellForm";
            this.Load += new System.EventHandler(this.ShellForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbtCmdBox;
    }
}