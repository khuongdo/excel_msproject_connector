using ObjectsLibrary;
using System.Collections.Generic;
using BrightIdeasSoftware;
namespace Excel2ProjAddin.Forms
{
    partial class frmMain
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
            this.contextMenuLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCombine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.olvTasks = new BrightIdeasSoftware.ObjectListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.olvCombinedTasks = new BrightIdeasSoftware.ObjectListView();
            this.contextMenuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmChoosePredecessor = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExportPj = new System.Windows.Forms.Button();
            this.backgroundWorker_ExportPj = new System.ComponentModel.BackgroundWorker();
            this.contextMenuLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvCombinedTasks)).BeginInit();
            this.contextMenuRight.SuspendLayout();
            this.panelStep1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuLeft
            // 
            this.contextMenuLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCombine,
            this.cmAdd,
            this.resourcesToolStripMenuItem1});
            this.contextMenuLeft.Name = "contextMenu";
            this.contextMenuLeft.Size = new System.Drawing.Size(128, 70);
            // 
            // cmCombine
            // 
            this.cmCombine.Name = "cmCombine";
            this.cmCombine.Size = new System.Drawing.Size(127, 22);
            this.cmCombine.Text = "Kết hợp";
            this.cmCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // cmAdd
            // 
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(127, 22);
            this.cmAdd.Text = "Thêm";
            this.cmAdd.Click += new System.EventHandler(this.cmAdd_Click);
            // 
            // resourcesToolStripMenuItem1
            // 
            this.resourcesToolStripMenuItem1.Name = "resourcesToolStripMenuItem1";
            this.resourcesToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.resourcesToolStripMenuItem1.Text = "Resources";
            this.resourcesToolStripMenuItem1.Click += new System.EventHandler(this.resourcesToolStripMenuItem1_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.olvTasks);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.btnGroup);
            this.splitContainer1.Panel2.Controls.Add(this.olvCombinedTasks);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(822, 362);
            this.splitContainer1.SplitterDistance = 369;
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
            this.olvTasks.CheckBoxes = true;
            this.olvTasks.ContextMenuStrip = this.contextMenuLeft;
            this.olvTasks.FullRowSelect = true;
            this.olvTasks.GridLines = true;
            this.olvTasks.HeaderWordWrap = true;
            this.olvTasks.Location = new System.Drawing.Point(2, 38);
            this.olvTasks.Name = "olvTasks";
            this.olvTasks.OwnerDraw = true;
            this.olvTasks.ShowGroups = false;
            this.olvTasks.Size = new System.Drawing.Size(368, 322);
            this.olvTasks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvTasks.TabIndex = 11;
            this.olvTasks.UseCompatibleStateImageBehavior = false;
            this.olvTasks.UseFiltering = true;
            this.olvTasks.View = System.Windows.Forms.View.Details;
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 360);
            this.panel2.TabIndex = 11;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackgroundImage = global::Excel2ProjAddin.Properties.Resources._1439670537_arrow_full_down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDown.Location = new System.Drawing.Point(3, 175);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 32);
            this.btnDown.TabIndex = 11;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.BackgroundImage = global::Excel2ProjAddin.Properties.Resources._1439670530_arrow_full_up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUp.Location = new System.Drawing.Point(2, 129);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(33, 32);
            this.btnUp.TabIndex = 10;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.BackgroundImage = global::Excel2ProjAddin.Properties.Resources.images;
            this.btnGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGroup.Location = new System.Drawing.Point(270, 6);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(31, 29);
            this.btnGroup.TabIndex = 9;
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // olvCombinedTasks
            // 
            this.olvCombinedTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvCombinedTasks.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvCombinedTasks.CellEditEnterChangesRows = true;
            this.olvCombinedTasks.ContextMenuStrip = this.contextMenuRight;
            this.olvCombinedTasks.FullRowSelect = true;
            this.olvCombinedTasks.GridLines = true;
            this.olvCombinedTasks.HeaderWordWrap = true;
            this.olvCombinedTasks.Location = new System.Drawing.Point(41, 37);
            this.olvCombinedTasks.MultiSelect = false;
            this.olvCombinedTasks.Name = "olvCombinedTasks";
            this.olvCombinedTasks.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.olvCombinedTasks.ShowGroups = false;
            this.olvCombinedTasks.Size = new System.Drawing.Size(403, 323);
            this.olvCombinedTasks.TabIndex = 0;
            this.olvCombinedTasks.UseCompatibleStateImageBehavior = false;
            this.olvCombinedTasks.View = System.Windows.Forms.View.Details;
            this.olvCombinedTasks.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvCombinedTasks_CellEditFinishing);
            // 
            // contextMenuRight
            // 
            this.contextMenuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmChoosePredecessor,
            this.resourcesToolStripMenuItem});
            this.contextMenuRight.Name = "contextMenuRight";
            this.contextMenuRight.Size = new System.Drawing.Size(170, 48);
            this.contextMenuRight.Text = "Chọn";
            // 
            // cmChoosePredecessor
            // 
            this.cmChoosePredecessor.Name = "cmChoosePredecessor";
            this.cmChoosePredecessor.Size = new System.Drawing.Size(169, 22);
            this.cmChoosePredecessor.Text = "Chọn Predecessor";
            this.cmChoosePredecessor.Click += new System.EventHandler(this.cmChoosePredecessor_Click);
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resourcesToolStripMenuItem.Text = "Resources";
            this.resourcesToolStripMenuItem.Click += new System.EventHandler(this.resourcesToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách công tác sau khi kết hợp:";
            // 
            // panelStep1
            // 
            this.panelStep1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStep1.Controls.Add(this.btnStop);
            this.panelStep1.Controls.Add(this.statusStrip1);
            this.panelStep1.Controls.Add(this.btnExit);
            this.panelStep1.Controls.Add(this.btnExportPj);
            this.panelStep1.Controls.Add(this.splitContainer1);
            this.panelStep1.Location = new System.Drawing.Point(0, 2);
            this.panelStep1.Name = "panelStep1";
            this.panelStep1.Size = new System.Drawing.Size(822, 441);
            this.panelStep1.TabIndex = 9;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(655, 368);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Dừng";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(23, 17);
            this.statusLabel.Text = "OK";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(736, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExportPj
            // 
            this.btnExportPj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPj.Location = new System.Drawing.Point(736, 368);
            this.btnExportPj.Name = "btnExportPj";
            this.btnExportPj.Size = new System.Drawing.Size(75, 23);
            this.btnExportPj.TabIndex = 9;
            this.btnExportPj.Text = "Xuất Project";
            this.btnExportPj.UseVisualStyleBackColor = true;
            this.btnExportPj.Click += new System.EventHandler(this.btnExportPj_Click);
            // 
            // backgroundWorker_ExportPj
            // 
            this.backgroundWorker_ExportPj.WorkerReportsProgress = true;
            this.backgroundWorker_ExportPj.WorkerSupportsCancellation = true;
            this.backgroundWorker_ExportPj.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ExportPj_DoWork);
            this.backgroundWorker_ExportPj.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ExportPj_ProgressChanged);
            this.backgroundWorker_ExportPj.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ExportPj_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(823, 443);
            this.Controls.Add(this.panelStep1);
            this.Name = "frmMain";
            this.Text = "E2P Add-in - Kết hợp công tác";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuLeft.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvCombinedTasks)).EndInit();
            this.contextMenuRight.ResumeLayout(false);
            this.panelStep1.ResumeLayout(false);
            this.panelStep1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private ObjectListView olvCombinedTasks;
        private System.Windows.Forms.ContextMenuStrip contextMenuLeft;
        private System.Windows.Forms.ToolStripMenuItem cmCombine;
        private System.Windows.Forms.ToolStripMenuItem cmAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.Button btnExportPj;
        private System.Windows.Forms.ContextMenuStrip contextMenuRight;
        private System.Windows.Forms.ToolStripMenuItem cmChoosePredecessor;
        private ObjectListView olvTasks;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ExportPj;
        private System.Windows.Forms.Button btnStop;




    }
}