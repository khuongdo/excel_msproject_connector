using ObjectsLibrary;
using System.Collections.Generic;
using BrightIdeasSoftware;
namespace Excel2ProjAddin.Forms
{
    partial class TaskList
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
            this.btnOK = new System.Windows.Forms.Button();
            this.dataListView_Resources = new BrightIdeasSoftware.DataListView();
            this.dataListView_tasks = new BrightIdeasSoftware.DataListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView_Resources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView_tasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(721, 489);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // dataListView_Resources
            // 
            this.dataListView_Resources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataListView_Resources.DataSource = null;
            this.dataListView_Resources.Location = new System.Drawing.Point(552, 5);
            this.dataListView_Resources.Name = "dataListView_Resources";
            this.dataListView_Resources.Size = new System.Drawing.Size(259, 472);
            this.dataListView_Resources.TabIndex = 3;
            this.dataListView_Resources.UseCompatibleStateImageBehavior = false;
            this.dataListView_Resources.View = System.Windows.Forms.View.Details;
            // 
            // dataListView_tasks
            // 
            this.dataListView_tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataListView_tasks.DataSource = null;
            this.dataListView_tasks.FullRowSelect = true;
            this.dataListView_tasks.GridLines = true;
            this.dataListView_tasks.Location = new System.Drawing.Point(24, 5);
            this.dataListView_tasks.Name = "dataListView_tasks";
            this.dataListView_tasks.ShowGroups = false;
            this.dataListView_tasks.Size = new System.Drawing.Size(502, 472);
            this.dataListView_tasks.TabIndex = 4;
            this.dataListView_tasks.UseCompatibleStateImageBehavior = false;
            this.dataListView_tasks.View = System.Windows.Forms.View.Details;
            this.dataListView_tasks.SelectedIndexChanged += new System.EventHandler(this.dataListView_tasks_SelectedIndexChanged);
            // 
            // TaskList
            // 
            this.ClientSize = new System.Drawing.Size(823, 538);
            this.Controls.Add(this.dataListView_tasks);
            this.Controls.Add(this.dataListView_Resources);
            this.Controls.Add(this.btnOK);
            this.Name = "TaskList";
            ((System.ComponentModel.ISupportInitialize)(this.dataListView_Resources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView_tasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private DataListView dataListView_Resources;
        private DataListView dataListView_tasks;




    }
}