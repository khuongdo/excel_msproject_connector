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

namespace Excel2ProjAddin.Forms
{
    public partial class frmMain : Form
    {
        public frmMain(List<MSPTask> ListTask)
        {
            Properties.Settings.Default.CombinedTaskList = string.Empty;
            Properties.Settings.Default.TaskList = string.Empty;
            InitializeComponent();

            //Panel
            panelStep1.Visible = true;
            //panelStep2.Visible = false;

            //
            PopulateTaskList(ListTask);
            PopulateCombinedTasks();

            
        }
        private void PopulateTaskList(List<MSPTask> ListTask)
        {
            Generator.GenerateColumns(olvTasks, typeof(MSPTask), false);
            olvTasks.SetObjects(ListTask);
            olvTasks.Columns.RemoveAt(5);
            olvTasks.AllColumns[0].HeaderCheckBox = true;

            
            SaveTasks(ListTask);

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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty)
            {
                olvTasks.OwnerDraw = true;
                TextMatchFilter filter = TextMatchFilter.Contains(olvTasks, tbSearch.Text);
                olvTasks.ModelFilter = filter;
                HighlightTextRenderer hl = new HighlightTextRenderer(filter);
                hl.FillBrush = new SolidBrush(Color.Yellow);
                hl.CornerRoundness = 1.5f;
                hl.FramePen = new Pen(Color.Red);
                olvTasks.DefaultRenderer = hl;
            }
            //else
            //{
            //    //olvTasks.Refresh();
            //    olvTasks.OwnerDraw = false;
            //}
        }
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
                
            List<MSPTask> CurrTasksList = LoadTasks();
            string NewName = ((MSPTask)olvTasks.CheckedObjects[0]).Name;
            if (InputBox.Show("Kết hợp công tác", "Nhập tên công tác mới", ref NewName)
                == System.Windows.Forms.DialogResult.OK)
            {
                List<MSPTask> TasksToCombine = new List<MSPTask>();
                foreach (MSPTask item in olvTasks.CheckedObjects)
                {
                    //Delete Task in List Task
                    olvTasks.RemoveObject(item);
                    TasksToCombine.Add(item);
                }
                MSPTask CombinedTask = MSP_Methods.CombineTasks(NewName, TasksToCombine);// Tasks to be combined
                //Save Combined Task to Disk
                List<MSPTask> CombinedTasks = LoadCombinedTasks() ?? new List<MSPTask>();
                CombinedTask.ID = CombinedTasks.Count;
                CombinedTask.TaskNo = CombinedTasks.Count + 1;
                CombinedTasks.Add(CombinedTask);
                SaveCombined(CombinedTasks);

                //Add new Item and Resize olvcombined Columns
                olvCombinedTasks.AddObject(CombinedTask);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn tải lại danh sách công tác?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                List<MSPTask> list = LoadTasks();
                olvTasks.Clear();
                PopulateTaskList(list);
            }
        }

        private void olvTasks_DoubleClick(object sender, EventArgs e)
        {
            List<MSPTask> TasksList = LoadTasks();
            if (olvTasks.SelectedIndex >= -1)
            {
                Forms.frmResources f = new frmResources(TasksList[olvTasks.SelectedIndex].Resources);
                f.Show();
            }
                
        }

        private void olv_CombineList_DoubleClick(object sender, EventArgs e)
        {
            if (olvCombinedTasks.SelectedIndex == -1)
                return;
            List<MSPTask> CombinedTasks = LoadCombinedTasks();
            Forms.frmResources f = new frmResources(CombinedTasks[Convert.ToInt32(olvCombinedTasks.SelectedItem.Text)].Resources);
            f.Show();
        
        }

        private void olvTasks_CellEditFinishing(object sender, CellEditEventArgs e)
        {
          
        }

        private void btnNextStep2_Click(object sender, EventArgs e)
        {
            if (olvCombinedTasks.Objects != null)
            {
                List<MSPTask> CombinedTasks = olvCombinedTasks.Objects as List<MSPTask>;
                SaveCombined(CombinedTasks);
                
            }
            else
            {
                if (MessageBox.Show("Chọn tất cả các công tác cột bên trái?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.CombinedTaskList = Properties.Settings.Default.TaskList;
                    Properties.Settings.Default.Save();
                }
            }
            panelStep1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (olvCombinedTasks.Items.Count == 0)
                return;
            List<MSPTask> CombinedTasks = new List<MSPTask>();
            foreach (object obj in olvCombinedTasks.Objects)
                CombinedTasks.Add(obj as MSPTask);
            
            SaveCombined(CombinedTasks);
        }

        private void cmAdd_Click(object sender, EventArgs e)
        {
            if (olvTasks.CheckedObjects.Count == 0)
                return;
            //Load tasks
            List<MSPTask> CurrTasksList = LoadTasks();
            List<MSPTask> CombinedTasks = LoadCombinedTasks() ?? new List<MSPTask>();
            foreach (MSPTask item in olvTasks.CheckedObjects)
            {
                //Delete Task in List Task
                olvTasks.RemoveObject(item);
                MSPTask TaskToAdd = item;
                //Add selected item to CombinedList
                TaskToAdd.ID = CombinedTasks.Count;
                TaskToAdd.TaskNo = CombinedTasks.Count + 1;
                CombinedTasks.Add(TaskToAdd);

                //Add to olvCombinedTasks
                olvCombinedTasks.AddObject(item);
            }
            
            SaveCombined(CombinedTasks);
        }

        private void cmChoosePredecessor_Click(object sender, EventArgs e)
        {
            //Subtract selected object
            
            if (olvCombinedTasks.SelectedIndex == -1)
            {
                return;
            }
            MSPTask TaskObjToRemove;
            TaskObjToRemove = olvCombinedTasks.SelectedObject as MSPTask;
            List<MSPTask> TasksToPopulate = LoadCombinedTasks();
            TasksToPopulate.Remove(TaskObjToRemove);
            Forms.frmChoosePredecessor f = new frmChoosePredecessor(TasksToPopulate);
            f.Show();
        }

        

       
       
        

       

       
        
    }
   
}
 