using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
    public partial class frmMessage : Epoint.Systems.Customizes.frmView
    {
        #region Khai bao bien

        private DataTable dtMesage;
        private DataRow drCurrent;
        private BindingSource bdsMesage = new BindingSource();
        private lvControl lvMesage = new lvControl();        

        #endregion

        #region Contructor

        public frmMessage()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);

            this.lvMesage.Resize += new EventHandler(lvDmDvCs_Resize);
            this.lvMesage.MouseDoubleClick += new MouseEventHandler(lvDmDvCs_MouseDoubleClick);
        }

        void lvDmDvCs_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public override void Load()
        {
            Build();
            FillData();
            BindingLanguage();

            this.Show();
        }

        #endregion

        #region Build, FillData

        private void Build()
        {
            //lvMesage.Location = new Point(3, 3);
            //lvMesage.Size = new Size(this.Size.Width - 12, this.Size.Height - 12);
            //lvMesage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvMesage.FullRowSelect = true;
            lvMesage.GridLines = true;
            lvMesage.HideSelection = false;

            lvMesage.strZone = "Message";
            lvMesage.BuildListView(this.isLookup);
            lvMesage.Dock = DockStyle.Fill;
            this.Controls.Add(lvMesage);
        }

        private void FillData()
        {
            dtMesage = DataTool.SQLGetDataTable("SYSMessage", "*", "", "");// SQLExec.ExecuteReturnDt("SELECT * FROM SYSMessage ORDER BY MessageID");
            //dtMesage = DataTool.SQLGetDataTable("SYSParameter", "*", "", "");
            bdsMesage.DataSource = dtMesage;

            lvMesage.DataSource = bdsMesage;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsMesage;
        }

        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (!lvMesage.MoveDataSourceToCurrentRow())
                return;

            if (bdsMesage.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsMesage.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsMesage.Current).Row, ref drCurrent);
            else
                drCurrent = dtMesage.NewRow();

            frmMessage_Edit frmEdit = new frmMessage_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New && bdsMesage.Position < 0)
                {
                    if (bdsMesage.Position >= 0)
                        dtMesage.ImportRow(drCurrent);
                    else
                        dtMesage.Rows.Add(drCurrent);

                    bdsMesage.Position = bdsMesage.Find("MessageID", drCurrent["MessageID"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsMesage.Current).Row);

                dtMesage.AcceptChanges();

                //Cap nhat vao ListView
                lvMesage.UpdateRowToListViewItem(enuNew_Edit, drCurrent);
            }
            else
                dtMesage.RejectChanges();
        }

        public override void Delete()
        {
            if (!lvMesage.MoveDataSourceToCurrentRow())
                return;

            if (bdsMesage.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsMesage.Current).Row;

            if (!EpointMessage.MsgYes_No("Bạn có muốn xóa không"))
                return;

            if (DataTool.SQLDelete("SYSMessage", drCurrent))
            {
                bdsMesage.RemoveAt(bdsMesage.Position);
                dtMesage.AcceptChanges();

                lvMesage.RemoveCurrentListViewItem();
            }
        }


        #endregion

        #region EnterProcess

        public override void EnterProcess()
        {

        }

        #endregion

        #region Su kien

        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    Delete();
                    break;
            }
        }

        void lvDmDvCs_Resize(object sender, EventArgs e)
        {
            this.lvMesage.ResizeListView();
        }

        #endregion
    }
}
