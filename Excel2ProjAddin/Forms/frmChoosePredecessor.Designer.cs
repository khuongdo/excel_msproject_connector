namespace Excel2ProjAddin.Forms
{
    partial class frmChoosePredecessor
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
            this.olvChoosePredecessor = new BrightIdeasSoftware.ObjectListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olvChoosePredecessor)).BeginInit();
            this.SuspendLayout();
            // 
            // olvChoosePredecessor
            // 
            this.olvChoosePredecessor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvChoosePredecessor.CellEditEnterChangesRows = true;
            this.olvChoosePredecessor.CheckBoxes = true;
            this.olvChoosePredecessor.FullRowSelect = true;
            this.olvChoosePredecessor.GridLines = true;
            this.olvChoosePredecessor.Location = new System.Drawing.Point(2, 1);
            this.olvChoosePredecessor.Name = "olvChoosePredecessor";
            this.olvChoosePredecessor.ShowGroups = false;
            this.olvChoosePredecessor.Size = new System.Drawing.Size(499, 335);
            this.olvChoosePredecessor.TabIndex = 0;
            this.olvChoosePredecessor.UseCompatibleStateImageBehavior = false;
            this.olvChoosePredecessor.View = System.Windows.Forms.View.Details;
            this.olvChoosePredecessor.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvChoosePredecessor_CellEditFinishing);
            this.olvChoosePredecessor.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvChoosePredecessor_CellEditStarting);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(425, 342);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bấm ESC hoặc nút OK để chọn";
            // 
            // frmChoosePredecessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 372);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.olvChoosePredecessor);
            this.KeyPreview = true;
            this.Name = "frmChoosePredecessor";
            this.Text = "Chọn công tác trước";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChoosePredecessor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.olvChoosePredecessor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvChoosePredecessor;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}