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

namespace Excel2ProjAddin.Forms
{
    public partial class frmChoosePredecessor : Form
    {
        public frmChoosePredecessor(List<MSPTask> Tasks)
        {
            InitializeComponent();
            PopulateOLV(Tasks);
            
        }
        private void PopulateOLV(List<MSPTask> Tasks)
        {
            OLVColumn colNo = new OLVColumn("STT", "No");
            OLVColumn colID = new OLVColumn("ID", "ID");
            OLVColumn colName = new OLVColumn("Tên công tác", "Name");
            OLVColumn colLinkType = new OLVColumn();
            colLinkType.Text = "Link Type";
            colLinkType.DataType = typeof(string);
            colLinkType.IsEditable = true;
            OLVColumn colTag = new OLVColumn("Tag", "Tag");
            
            olvChoosePredecessor.AllColumns.AddRange(new OLVColumn[] { colNo, colID, colName, colLinkType, colTag });
            olvChoosePredecessor.RebuildColumns();
            olvChoosePredecessor.SetObjects(Tasks);
            olvChoosePredecessor.AutoResizeColumns();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void olvChoosePredecessor_CellEditStarting(object sender, CellEditEventArgs e)
        {
            //Ignore edit event for other columns
            if (e.Column != olvChoosePredecessor.AllColumns[3])
                return;

            ComboBox cb = new ComboBox();
            cb.Bounds = e.CellBounds;
            cb.Font = ((ObjectListView)sender).Font;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.AddRange(new string[] { "FS", "SS", "FF", "SF" });
            cb.SelectedIndex = 0;
            //cb.Tag = e.RowObject;
            e.Control = cb;
        }

        private void olvChoosePredecessor_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text != "Link Type")
                return;
            ObjectListView olv = (ObjectListView)sender;
            ComboBox cb = (ComboBox)e.Control;
            
           
            // Here we simply make the list redraw the involved ListViewItem 

            

            e.Cancel = true;
        }

    }
}
