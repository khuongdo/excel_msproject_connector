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
            
            InitializeComponent();
            PopulateTaskList(ListTask);
            SaveTasks(ListTask);
            Generator.GenerateColumns(olv_CombineList, typeof(MSPTask), false);
            
            
        }
        private void PopulateTaskList(List<MSPTask> ListTask)
        {
            Generator.GenerateColumns(olvTasks, typeof(MSPTask), false);
            olvTasks.SetObjects(ListTask);
            olvTasks.AutoResizeColumns();
            OLVColumn col = olvTasks.GetColumn(0);
            col.HeaderCheckBox = true;
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
        private List<MSPTask> LoadTasks()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String
                (Properties.Settings.Default.TaskList)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<MSPTask>)bf.Deserialize(ms);
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
            else
            {
                olvTasks.Refresh();
                olvTasks.OwnerDraw = false;
            }
        }
        // Context Menu
        private void btnCombine_Click(object sender, EventArgs e)
        {
            
            if (olvTasks.CheckedIndices.Count >= 2)
            {
                List<MSPTask> CurrTasksList = LoadTasks();
                string NewName = CurrTasksList[Convert.ToInt32(olvTasks.SelectedItem.Text)].Name;
                if (InputBox.Show("Kết hợp công tác", "Nhập tên công tác mới", ref NewName)
                    == System.Windows.Forms.DialogResult.OK)
                {
                    
                    List<MSPTask> combined_list = new List<MSPTask>();
                    foreach (OLVListItem item in olvTasks.CheckedItems)
                    {
                        //Delete Task in List Task
                        olvTasks.Items.Remove(item);
                        combined_list.Add(CurrTasksList[Convert.ToInt32(item.Text)]);
                    }
                    olv_CombineList.AddObject(MSP_Methods.CombineTasks(NewName,combined_list));
                    olv_CombineList.AutoResizeColumns();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn từ 2 công tác trở lên");
                return;
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
        

       

       
        
    }
   
}
