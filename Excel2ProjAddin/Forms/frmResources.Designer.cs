namespace Excel2ProjAddin.Forms
{
    partial class frmResources
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
            this.olvResources = new BrightIdeasSoftware.ObjectListView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olvResources)).BeginInit();
            this.SuspendLayout();
            // 
            // olvResources
            // 
            this.olvResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvResources.FullRowSelect = true;
            this.olvResources.GridLines = true;
            this.olvResources.HeaderWordWrap = true;
            this.olvResources.Location = new System.Drawing.Point(0, 25);
            this.olvResources.Name = "olvResources";
            this.olvResources.ShowGroups = false;
            this.olvResources.Size = new System.Drawing.Size(718, 380);
            this.olvResources.TabIndex = 0;
            this.olvResources.UseCompatibleStateImageBehavior = false;
            this.olvResources.UseFiltering = true;
            this.olvResources.View = System.Windows.Forms.View.Details;
            this.olvResources.DoubleClick += new System.EventHandler(this.olvResources_DoubleClick);
            this.olvResources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.olvResources_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bấm \"ESC\" để thoát";
            // 
            // frmResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.olvResources);
            this.KeyPreview = true;
            this.Name = "frmResources";
            this.Text = "frmResources";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmResources_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmResources_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.olvResources)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvResources;
        private System.Windows.Forms.Label label1;
    }
}