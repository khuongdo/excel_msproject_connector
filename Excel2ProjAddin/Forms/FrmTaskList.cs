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
    public partial class frmTaskList : Form
    {
        public frmTaskList(List<MSPTask> ListTask)
        {
            Properties.Settings.Default.CombinedTaskList = string.Empty;
            Properties.Settings.Default.TaskList = string.Empty;
            InitializeComponent();
            PopulateTaskList(ListTask);
            SaveTasks(ListTask);
            Generator.GenerateColumns(olvCombinedTasks, typeof(MSPTask), false);
        }
        private void PopulateTaskList(List<MSPTask> ListTask)
        {
            Generator.GenerateColumns(olvTasks, typeof(MSPTask), false);
            olvTasks.SetObjects(ListTask);
            olvTasks.AutoResizeColumns();

            //Add checkbox to Column "ID"
            OLVColumn colID = olvTasks.GetColumn(0);
            colID.HeaderCheckBox = true;
            //
            OLVColumn colName = olvTasks.GetColumn(3);
            colName.AspectName = "Name";
            OLVColumn colCode = olvTasks.GetColumn(2);
            colCode.AspectName = "Code";

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
            List<MSPTask> CurrTasksList = LoadTasks();
            string NewName = CurrTasksList[Convert.ToInt32(olvTasks.SelectedItems[0].Text)].Name;
            if (InputBox.Show("Kết hợp công tác", "Nhập tên công tác mới", ref NewName)
                == System.Windows.Forms.DialogResult.OK)
            {
                List<MSPTask> TasksToCombine = new List<MSPTask>();
                foreach (OLVListItem item in olvTasks.CheckedItems)
                {
                    //Delete Task in List Task
                    olvTasks.Items.Remove(item);
                    TasksToCombine.Add(CurrTasksList[Convert.ToInt32(item.Text)]);
                }
                MSPTask CombinedTask = MSP_Methods.CombineTasks(NewName, TasksToCombine);// Tasks to be combined
                //Save Combined Task to Disk
                List<MSPTask> tempTasks = LoadCombinedTasks();
                if (tempTasks == null)
                    tempTasks = new List<MSPTask>();
                CombinedTask.ID = tempTasks.Count;
                CombinedTask.TaskNo = tempTasks.Count + 1;
                tempTasks.Add(CombinedTask);
                SaveCombined(tempTasks);

                //Add to Combinedtasks view
                olvCombinedTasks.AddObject(CombinedTask);
                olvCombinedTasks.AutoResizeColumns();
                olvCombinedTasks.Refresh();
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
            List<MSPTask> CombinedTasks = LoadCombinedTasks();
            if (olvCombinedTasks.SelectedIndex >= -1)
            {
                Forms.frmResources f = new frmResources(CombinedTasks[Convert.ToInt32(olvCombinedTasks.SelectedItem.Text)].Resources);
                f.Show();
            }
        }

        private void olvTasks_CellEditFinishing(object sender, CellEditEventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<MSPTask> EdittedTasks = new List<MSPTask>();
            //olvTasks.SelectAll();
            foreach (object item in olvTasks.Objects)
            {
                MSPTask temptask = item as MSPTask;
                EdittedTasks.Add(temptask);
            }
            SaveTasks(EdittedTasks);
            //olvTasks.CancelCellEdit();

        }
        

       

       
        
    }
   
}
 