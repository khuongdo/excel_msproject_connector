using ObjectsLibrary;
using System.Collections.Generic;
using BrightIdeasSoftware;
namespace Excel2ProjAddin.Forms
{
    partial class frmTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskList));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCombine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.olvTasks = new BrightIdeasSoftware.ObjectListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.olvCombinedTasks = new BrightIdeasSoftware.ObjectListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCombineTasks = new System.Windows.Forms.Panel();
            this.btnGroup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvCombinedTasks)).BeginInit();
            this.panelCombineTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCombine,
            this.cmUncheckAll});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(151, 48);
            // 
            // cmCombine
            // 
            this.cmCombine.Name = "cmCombine";
            this.cmCombine.Size = new System.Drawing.Size(150, 22);
            this.cmCombine.Text = "Kết hợp";
            this.cmCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // cmUncheckAll
            // 
            this.cmUncheckAll.Name = "cmUncheckAll";
            this.cmUncheckAll.Size = new System.Drawing.Size(150, 22);
            this.cmUncheckAll.Text = "Bỏ chọn tất cả";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.olvTasks);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.olvCombinedTasks);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(823, 422);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Excel2ProjAddin.Properties.Resources.Refresh_icon;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Location = new System.Drawing.Point(127, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(33, 30);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // olvTasks
            // 
            this.olvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvTasks.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.olvTasks.CheckBoxes = true;
            this.olvTasks.ContextMenuStrip = this.contextMenu;
            this.olvTasks.FullRowSelect = true;
            this.olvTasks.GridLines = true;
            this.olvTasks.HeaderWordWrap = true;
            this.olvTasks.Location = new System.Drawing.Point(2, 38);
            this.olvTasks.Name = "olvTasks";
            this.olvTasks.OwnerDraw = true;
            this.olvTasks.ShowGroups = false;
            this.olvTasks.Size = new System.Drawing.Size(419, 382);
            this.olvTasks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvTasks.TabIndex = 11;
            this.olvTasks.UseCompatibleStateImageBehavior = false;
            this.olvTasks.UseFiltering = true;
            this.olvTasks.View = System.Windows.Forms.View.Details;
            this.olvTasks.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTasks_CellEditFinishing);
            this.olvTasks.DoubleClick += new System.EventHandler(this.olvTasks_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Location = new System.Drawing.Point(226, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 31);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(31, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(155, 20);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Danh sách công tác:";
            // 
            // olvCombinedTasks
            // 
            this.olvCombinedTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvCombinedTasks.FullRowSelect = true;
            this.olvCombinedTasks.GridLines = true;
            this.olvCombinedTasks.Location = new System.Drawing.Point(2, 37);
            this.olvCombinedTasks.Name = "olvCombinedTasks";
            this.olvCombinedTasks.ShowGroups = false;
            this.olvCombinedTasks.Size = new System.Drawing.Size(392, 383);
            this.olvCombinedTasks.TabIndex = 0;
            this.olvCombinedTasks.UseCompatibleStateImageBehavior = false;
            this.olvCombinedTasks.View = System.Windows.Forms.View.Details;
            this.olvCombinedTasks.DoubleClick += new System.EventHandler(this.olv_CombineList_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách công tác sau khi kết hợp:";
            // 
            // panelCombineTasks
            // 
            this.panelCombineTasks.Controls.Add(this.splitContainer1);
            this.panelCombineTasks.Controls.Add(this.btnGroup);
            this.panelCombineTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCombineTasks.Location = new System.Drawing.Point(0, 0);
            this.panelCombineTasks.Name = "panelCombineTasks";
            this.panelCombineTasks.Size = new System.Drawing.Size(823, 466);
            this.panelCombineTasks.TabIndex = 9;
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(736, 503);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 9;
            this.btnGroup.Text = "Nhóm>>";
            this.btnGroup.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmTaskList
            // 
            this.ClientSize = new System.Drawing.Size(823, 466);
            this.Controls.Add(this.panelCombineTasks);
            this.Name = "frmTaskList";
            this.Text = "E2P Add-in - Kết hợp công tác";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvCombinedTasks)).EndInit();
            this.panelCombineTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private ObjectListView olvCombinedTasks;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmCombine;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem cmUncheckAll;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private ObjectListView olvTasks;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelCombineTasks;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button button1;




    }
}