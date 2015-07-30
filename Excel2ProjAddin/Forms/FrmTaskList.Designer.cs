using ObjectsLibrary;
using System.Collections.Generic;
using BrightIdeasSoftware;
namespace Excel2ProjAddin.Forms
{
    partial class FrmTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskList));
            this.btnOK = new System.Windows.Forms.Button();
            this.olvTasks = new BrightIdeasSoftware.ObjectListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCombine = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.olvResources = new BrightIdeasSoftware.ObjectListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.olv_CombineList = new BrightIdeasSoftware.ObjectListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colChildTasks = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv_CombineList)).BeginInit();
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
            // olvTasks
            // 
            this.olvTasks.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.olvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.olvTasks.CheckBoxes = true;
            this.olvTasks.ContextMenuStrip = this.contextMenu;
            this.olvTasks.FullRowSelect = true;
            this.olvTasks.GridLines = true;
            this.olvTasks.HeaderUsesThemes = true;
            this.olvTasks.HeaderWordWrap = true;
            this.olvTasks.HighlightBackgroundColor = System.Drawing.Color.Yellow;
            this.olvTasks.HighlightForegroundColor = System.Drawing.Color.Yellow;
            this.olvTasks.Location = new System.Drawing.Point(0, 38);
            this.olvTasks.MultiSelect = false;
            this.olvTasks.Name = "olvTasks";
            this.olvTasks.OwnerDraw = true;
            this.olvTasks.ShowGroups = false;
            this.olvTasks.Size = new System.Drawing.Size(449, 443);
            this.olvTasks.TabIndex = 6;
            this.olvTasks.UseCompatibleStateImageBehavior = false;
            this.olvTasks.UseFiltering = true;
            this.olvTasks.View = System.Windows.Forms.View.Details;
            this.olvTasks.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCombine,
            this.uncheckTấtCảToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // btnCombine
            // 
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(152, 22);
            this.btnCombine.Text = "Kết hợp";
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // uncheckTấtCảToolStripMenuItem
            // 
            this.uncheckTấtCảToolStripMenuItem.Name = "uncheckTấtCảToolStripMenuItem";
            this.uncheckTấtCảToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uncheckTấtCảToolStripMenuItem.Text = "Uncheck tất cả";
            // 
            // olvResources
            // 
            this.olvResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvResources.FullRowSelect = true;
            this.olvResources.GridLines = true;
            this.olvResources.HeaderWordWrap = true;
            this.olvResources.Location = new System.Drawing.Point(3, 38);
            this.olvResources.Name = "olvResources";
            this.olvResources.ShowGroups = false;
            this.olvResources.Size = new System.Drawing.Size(353, 213);
            this.olvResources.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvResources.TabIndex = 7;
            this.olvResources.UseCompatibleStateImageBehavior = false;
            this.olvResources.UseFiltering = true;
            this.olvResources.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(2, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.olvTasks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(819, 483);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Location = new System.Drawing.Point(136, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 31);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(35, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(275, 20);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Danh sách công tác:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.olvResources);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.olv_CombineList);
            this.splitContainer2.Size = new System.Drawing.Size(359, 481);
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách tài nguyên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kết hợp tài nguyên:";
            // 
            // olv_CombineList
            // 
            this.olv_CombineList.AllColumns.Add(this.colName);
            this.olv_CombineList.AllColumns.Add(this.colChildTasks);
            this.olv_CombineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv_CombineList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colChildTasks});
            this.olv_CombineList.FullRowSelect = true;
            this.olv_CombineList.GridLines = true;
            this.olv_CombineList.Location = new System.Drawing.Point(3, 28);
            this.olv_CombineList.Name = "olv_CombineList";
            this.olv_CombineList.ShowGroups = false;
            this.olv_CombineList.Size = new System.Drawing.Size(353, 194);
            this.olv_CombineList.TabIndex = 0;
            this.olv_CombineList.UseCompatibleStateImageBehavior = false;
            this.olv_CombineList.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Tên công tác gộp";
            this.colName.Width = 200;
            // 
            // colChildTasks
            // 
            this.colChildTasks.Text = "Công tác con";
            this.colChildTasks.Width = 100;
            // 
            // FrmTaskList
            // 
            this.ClientSize = new System.Drawing.Size(823, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmTaskList";
            this.Text = "E2P Add-in - Danh sách công tác";
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvResources)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olv_CombineList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private ObjectListView olvTasks;
        private ObjectListView olvResources;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private ObjectListView olv_CombineList;
        private OLVColumn colName;
        private OLVColumn colChildTasks;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnCombine;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem uncheckTấtCảToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;




    }
}