using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectsLibrary;
using BrightIdeasSoftware;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MSproject = Microsoft.Office.Interop.MSProject;
using Microsoft.VisualBasic;

namespace Excel2ProjAddin.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            Properties.Settings.Default.CombinedTaskList = string.Empty;
            Properties.Settings.Default.TaskList = string.Empty;
            InitializeComponent();

            //Panel
            panelStep1.Visible = true;
            //panelStep2.Visible = false;

            
            //
            PopulateTaskList();
            PopulateCombinedTasks();

            //Worker collect task
            BackgroundWorker worker_collectTask = new BackgroundWorker();
            worker_collectTask.WorkerReportsProgress = true;
            worker_collectTask.DoWork += worker_collectTask_DoWork;
            worker_collectTask.RunWorkerCompleted += worker_collectTask_RunWorkerCompleted;
            worker_collectTask.ProgressChanged += worker_collectTask_ProgressChanged;
            worker_collectTask.RunWorkerAsync();
        }

        void worker_collectTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLabel.Text = (string)e.UserState;
        }

        void worker_collectTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<MSPTask> Tasks = (List<MSPTask>)e.Result;
            olvTasks.Enabled = true;
            olvTasks.SetObjects(Tasks);
            SaveTasks(olvTasks.Objects.Cast<MSPTask>().ToList());
        }

        void worker_collectTask_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            worker.ReportProgress(1, "Đang tạo danh sách công tác....");
            e.Result = ExcelModule.CollectTasks();
            worker.ReportProgress(1, "Tải danh sách công tác hoàn tất");
        }
        private void PopulateTaskList()
        {
            Generator.GenerateColumns(olvTasks, typeof(MSPTask), false);
            olvTasks.Columns.RemoveAt(6);
            olvTasks.AllColumns[0].HeaderCheckBox = true;
            olvTasks.Enabled = false;
        }
        private void PopulateCombinedTasks()
        {
            Generator.GenerateColumns(olvCombinedTasks, typeof(MSPTask), false);
            
            
        }
        private void SaveTasks(List<MSPTask> Tasks)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, Tasks);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.TaskList = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }
        private void SaveCombined(List<MSPTask> Tasks)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, Tasks);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.CombinedTaskList = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }

        private List<MSPTask> LoadTasks()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String
                (Properties.Settings.Default.TaskList)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<MSPTask>)bf.Deserialize(ms);
            }
        }
        private List<MSPTask> LoadCombinedTasks()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String
                (Properties.Settings.Default.CombinedTaskList)))
            {
                if (ms.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<MSPTask>)bf.Deserialize(ms);
                }
                else
                    return null;
            }
            
        }

        //private void tbSearch_TextChanged(object sender, EventArgs e)
        //{
        //    if (tbSearch.Text != string.Empty)
        //    {
        //        olvTasks.OwnerDraw = true;
        //        TextMatchFilter filter = TextMatchFilter.Contains(olvTasks, tbSearch.Text);
        //        olvTasks.ModelFilter = filter;
        //        HighlightTextRenderer hl = new HighlightTextRenderer(filter);
        //        hl.FillBrush = new SolidBrush(Color.Yellow);
        //        hl.CornerRoundness = 1.5f;
        //        hl.FramePen = new Pen(Color.Red);
        //        olvTasks.DefaultRenderer = hl;
        //    }
        //    //else
        //    //{
        //    //    //olvTasks.Refresh();
        //    //    olvTasks.OwnerDraw = false;
        //    //}
        //}
        // Context Menu
        private void btnCombine_Click(object sender, EventArgs e)
        {
            //Check if no task is selected
            if (olvTasks.CheckedObjects.Count == 0)
                return;

            //Check if tasks can not be combined
            List<string> Unit = new List<string>();
            foreach (MSPTask item in olvTasks.CheckedObjects)
            {
                Unit.Add(item.unit.Name);
            }
            if (Unit.Distinct().Count() > 1)
            {
                MessageBox.Show("Không thể kết hợp công tác khác đơn vị");
                return;
            }
            string NewName = Interaction.InputBox("Nhập tên công tác mới", "Kết hợp công tác", 
                ((MSPTask)olvTasks.CheckedObjects[0]).Name);
            if (NewName == string.Empty)
                return;
            List<MSPTask> TasksToCombine = new List<MSPTask>();
            foreach (MSPTask item in olvTasks.CheckedObjects)
            {
                //Delete Task in List Task
                olvTasks.RemoveObject(item);
                TasksToCombine.Add(item);
            }
            MSPTask NewTask = MSPMethods.CombineTasks(NewName,TasksToCombine);
            NewTask.ID = olvCombinedTasks.Items.Count;
            NewTask.TaskNo = olvCombinedTasks.Items.Count + 1;
            olvCombinedTasks.AddObject(NewTask);
            //olvCombinedTasks.UpdateObject(NewTask);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn tải lại danh sách công tác?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                olvCombinedTasks.Items.Clear();
                olvTasks.Items.Clear();
                olvTasks.SetObjects(LoadTasks());
            }
        }

       

        
       

        private void cmAdd_Click(object sender, EventArgs e)
        {
            if (olvTasks.CheckedObjects.Count == 0)
                return;
            
            foreach (MSPTask item in olvTasks.CheckedObjects)
            {
                //Delete Task in List Task
                olvTasks.RemoveObject(item);
                MSPTask newTask = (MSPTask)item;
                newTask.ID = olvCombinedTasks.Items.Count;
                newTask.TaskNo = newTask.ID + 1;
                olvCombinedTasks.AddObject(newTask);
            }
            
         
        }

        private void cmChoosePredecessor_Click(object sender, EventArgs e)
        {
            //Subtract selected object
            if (olvCombinedTasks.SelectedIndex == -1)
            {
                return;
            }
            MSPTask TaskObjToRemove = olvCombinedTasks.SelectedObject as MSPTask;
            List<MSPTask> TasksToPopulate = olvCombinedTasks.Objects.Cast<MSPTask>().ToList(); 
            TasksToPopulate.Remove(TaskObjToRemove);
            Forms.frmChoosePredecessor frmChoosePre = new frmChoosePredecessor(TasksToPopulate,TaskObjToRemove.Predecessors);
            
            frmChoosePre.FormClosed += frmChoosePre_FormClosed;
            frmChoosePre.ShowDialog();
            
        }

        void frmChoosePre_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmChoosePre = (Form)sender;
            ObjectListView olvChoosePre = frmChoosePre.Controls.OfType<ObjectListView>().ToList()[0];
            List<MSPTask> PreTasks = olvChoosePre.CheckedObjects.Cast<MSPTask>().ToList();
            if (PreTasks == null || PreTasks.Count == 0)
            {
                return;
            }
            this.Focus();
            ((MSPTask)olvCombinedTasks.SelectedObject).Predecessors = PreTasks;
            olvCombinedTasks.RefreshObject(olvCombinedTasks.SelectedObject);
        }

      

       

        private void olvCombinedTasks_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            ObjectListView olv = (ObjectListView)sender;
            MSPTask CurrTask = (MSPTask)e.RowObject;
            if (e.Column == olv.GetColumn("Nhân công"))
            {
                CurrTask.Worker = (int)e.NewValue;
                CurrTask.Resources.Single(x => x.Type == ResourceType.Work).Value = CurrTask.Worker;
                CalculateDuration(ref CurrTask);
            }
            
            olv.UpdateObject(CurrTask);
        }
        private void CalculateDuration(ref MSPTask Task)
        {
         
            if (Task.Worker == 0)
                return;
            double WorkerQuota = Task.Resources.Single(x => x.Type == ResourceType.Work).Assess;
            Task.DurationInDay = Math.Ceiling(2 * Task.Value * WorkerQuota / Task.Worker) / 2;

        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            olvCombinedTasks.ShowGroups = olvCombinedTasks.ShowGroups == true ? false : true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Navigator buttons
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (olvCombinedTasks.SelectedIndex <= 0)
                return;
            var selected_obj = olvCombinedTasks.SelectedObject;
            var prev_obj = olvCombinedTasks.GetModelObject(olvCombinedTasks.SelectedIndex - 1);
            
            int temp_TaskNo = ((MSPTask)selected_obj).TaskNo;
            ((MSPTask)selected_obj).TaskNo = ((MSPTask)prev_obj).TaskNo;
            ((MSPTask)prev_obj).TaskNo = temp_TaskNo;

            olvCombinedTasks.MoveObjects(olvCombinedTasks.SelectedIndex - 1, new object[]{selected_obj});
            olvCombinedTasks.Focus();
            olvCombinedTasks.EnsureModelVisible(selected_obj);
            olvCombinedTasks.Refresh();
            olvCombinedTasks.SelectObject(selected_obj);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (olvCombinedTasks.SelectedIndex == -1 || olvCombinedTasks.SelectedIndex == olvCombinedTasks.Items.Count - 1)
                return;
            var selected_obj = olvCombinedTasks.SelectedObject;
            var next_obj = olvCombinedTasks.GetModelObject(olvCombinedTasks.SelectedIndex + 1);

            int temp_TaskNo = ((MSPTask)selected_obj).TaskNo;
            ((MSPTask)selected_obj).TaskNo = ((MSPTask)next_obj).TaskNo;
            ((MSPTask)next_obj).TaskNo = temp_TaskNo;

            olvCombinedTasks.MoveObjects(olvCombinedTasks.SelectedIndex, new object[] { next_obj });
            olvCombinedTasks.Focus();
            olvCombinedTasks.EnsureModelVisible(next_obj);
            olvCombinedTasks.RefreshObjects(new object[] {next_obj,selected_obj});
            olvCombinedTasks.SelectObject(selected_obj);
        }
        #endregion

        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (olvCombinedTasks.SelectedIndex == -1)
                return;
            MSPTask selectedtask = (MSPTask)olvCombinedTasks.SelectedObject;
            Forms.frmResources f = new frmResources(selectedtask);
            f.Show();
        }

        private void resourcesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (olvTasks.SelectedIndex == -1)
                return;
            MSPTask task = (MSPTask)olvTasks.SelectedObject;
            Forms.frmResources f = new frmResources(task);
            f.Show();
        }

        

        #region
        private void btnExportPj_Click(object sender, EventArgs e)
        {
            btnExportPj.Enabled = false;
            List<MSPTask> Tasks = olvCombinedTasks.Objects.Cast<MSPTask>().ToList();
            backgroundWorker_ExportPj.RunWorkerAsync(Tasks);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker_ExportPj.CancelAsync();
        }
        private void backgroundWorker_ExportPj_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MSPTask> Tasks = (List<MSPTask>)e.Argument;
            Tasks.Sort();
            BackgroundWorker bgwsender = (BackgroundWorker)sender;

            // Add resource to project
            bgwsender.ReportProgress(0, "Xử lý resources....Đang chạy");
            List<MSPResource> ResourceList = MSPMethods.CollectResources(Tasks);
            bgwsender.ReportProgress(0, "Xử lý resources....Hoàn tất");
            MSproject.Application PjApp = new MSproject.Application();
            MSproject.Project PjProject = PjApp.Projects.Add();
            bgwsender.ReportProgress(0, "Đang nạp resource....");
            foreach (var r in ResourceList)
            {
               MSproject.Resource CurrRes = PjProject.Resources.Add(r.Name);
               CurrRes.Type = r.Type == ResourceType.Material ? 
                   MSproject.PjResourceTypes.pjResourceTypeMaterial : MSproject.PjResourceTypes.pjResourceTypeWork;
               CurrRes.Initials = r.Code;
            }
            bgwsender.ReportProgress(0, "Đang nạp resource....Hoàn tất");

            // Add task
            foreach (MSPTask task in Tasks)
            {
                if (!bgwsender.CancellationPending)
                {
                    bgwsender.ReportProgress(1, string.Format("Đang xuất công tác: {0}/{1}",task.TaskNo, Tasks.Count));
                    ExportToMSP.ExportByTask(PjProject, task);
                }
                else
                {
                    bgwsender.ReportProgress(1, "Dừng bởi người dùng");
                    PjApp.Quit(MSproject.PjSaveType.pjDoNotSave);
                    e.Cancel = true;
                    return;
                }
            }
            bgwsender.ReportProgress(1, "Hoàn tất");
            PjApp.Visible = true;
        }
        private void backgroundWorker_ExportPj_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLabel.Text = (string)e.UserState;
        }

        private void backgroundWorker_ExportPj_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExportPj.Enabled = true;
        }
        #endregion

       

        










    }
   
}
 