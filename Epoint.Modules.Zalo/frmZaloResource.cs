using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using ZaloDotNetSDK;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Epoint.Modules.Zalo
{
    public partial class frmZaloResource : Epoint.Systems.Customizes.frmView//Epoint.Lists.frmView
    {

        #region Khai bao bien
        DataTable dtResource;
        DataRow drCurrent;
        BindingSource bdsResource = new BindingSource();
        tlControl tlResource = new tlControl();

        public Hashtable htHistory = new Hashtable();
        public string strTableName = string.Empty;
        public string strCode = string.Empty;
        public string strName = string.Empty;

        object objFileContent;


        ZaloClient client;
        int MsgIDCur = 0;
        string ReleaseType = "S";

        //string AppConfigFile = AppDomain.CurrentDomain.BaseDirectory + @"\ZALOOFFICIALL.exe.config";
        string FilePathZalo = AppDomain.CurrentDomain.BaseDirectory + @"\tempzalo\";
        #endregion

        #region Contructor

        public frmZaloResource()
        {
            InitializeComponent();

            tlResource.MouseDoubleClick += new MouseEventHandler(tlResource_MouseDoubleClick);
            tlResource.MouseClick += new MouseEventHandler(tlResource_MouseClick);
            //cboFile_Type.SelectedValueChanged +=new EventHandler(cboFile_Type_SelectedValueChanged);
            //cboFile_Type.SelectedIndexChanged += new EventHandler(cboFile_Type_SelectedIndexChanged);            
            string access_token = ElementHrm.sysZaloAccessToken;
            //ZaloAppInfo info = new ZaloAppInfo(3320005208606942018, "", "http://tuanviet-trading.com/");
            client = new ZaloClient(access_token);
        }



        public override void Load()
        {
            this.cboFile_Type.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT '*' AS File_Type UNION SELECT File_Type FROM ZALORESOURCES ORDER BY 1");
            this.cboFile_Type.DisplayMember = "File_Type";
            this.cboFile_Type.ValueMember = "File_Type";

            Init();
            Build();
            FillData();
            BindingLanguage();

            if (bdsResource != null)
            {
                //this.cboFile_Type.Enabled = false;
                //DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;
                //this.objFileContent = Resource.LoadResource(drCurrent["File_Id"].ToString());
            }

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        public override void LoadLookup()
        {
            this.Load();
        }
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Quản lý tập tin";
            strTableName = "ZALORESOURCES";
            strCode = "FILE_ID";
            strName = "FILE_NAME";
        }

        #endregion

        #region Build, FillData

        private void Build()
        {
            tlResource.KeyFieldName = "FILE_ID";
            tlResource.ParentFieldName = "FILE_ID_PARENT";
            tlResource.Dock = DockStyle.Fill;

            this.splitContainer_Resource.Panel2.Controls.Add(tlResource);
            //this.Controls.Add(tlResource);
            //this.pnlControl2.Controls.Add(tlResource);

            tlResource.strZone = "RESOURCEZALO";
            tlResource.BuildTreeList(this.isLookup);
        }

        public void FillData()
        {
            dtResource = DataTool.SQLGetDataTable("ZALORESOURCES", null, this.strLookupKeyFilter, null);

            bdsResource.DataSource = dtResource;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsResource;
            ExportControl = tlResource;

            tlResource.DataSource = bdsResource;
            bdsResource.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlResource.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlResource.strZone + "'");
        }

        private void MoveToLookupValue()
        {
            if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtResource.Rows.Count - 1; i++)
                if (((string)dtResource.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsResource.Position = i;
                    break;
                }
        }

        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsResource.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsResource.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);
            else
                drCurrent = dtResource.NewRow();

            frmZaloResource_Edit frmEdit = new frmZaloResource_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                //Cập nhật History
                DataRow drHistory = drCurrent;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";

                    Epoint.Lists.frmView frm = new Lists.frmView();
                    frm.UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsResource.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsResource.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsResource.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsResource.Current)[strName];

                    Epoint.Lists.frmView frm = new Lists.frmView();
                    frm.UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsResource.Position >= 0)
                        dtResource.ImportRow(drCurrent);
                    else
                        dtResource.Rows.Add(drCurrent);

                    bdsResource.Position = bdsResource.Find("FILE_ID", drCurrent["FILE_ID"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsResource.Current).Row);

                dtResource.AcceptChanges();
            }
            //else
            //    dtResource.RejectChanges();
        }

        public override void Delete()
        {
            if (bdsResource.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;
            if ((Boolean)drCurrent["IsZaloSend"])
            {
                EpointMessage.MsgOk("Tin đã gửi không thể xóa");
                return;
            }

            if (Convert.ToInt32(SQLExec.ExecuteReturnValue("SP_HRM_CHECKParent '" + drCurrent["File_ID"].ToString() + "'")) > 0)
            {
                EpointMessage.MsgOk("Không thể xóa nhóm cha !");
                return;
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("ZALORESOURCES", drCurrent))
            {
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";

                Epoint.Lists.frmView frm = new Lists.frmView();
                frm.UpdateHistory();

                bdsResource.RemoveAt(bdsResource.Position);
                dtResource.AcceptChanges();
            }
        }

        public override void MergeID()
        {

        }

        #endregion

        #region EnterProcess

        bool EnterValid()
        {
            if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
                return true;

            if (bdsResource == null || bdsResource.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsResource.Current).Row;
            DataTable dtTemp = dtResource.Clone();
            dtTemp.ImportRow(drCurrent);

            if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
                return true;
            else
                return false;
        }

        public override void EnterProcess()
        {
            if (bdsResource.Position < 0)
                return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsResource.Current).Row;
                this.Close();
            }
        }

        #endregion

        #region Su kien

        void tlResource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.isLookup)
            //    this.EnterProcess();
            //else
            //    this.Edit(enuEdit.Edit);

            if (bdsResource.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);

            if ((Boolean)drCurrent["DUYET"] == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "(*." + drCurrent["File_Tag"].ToString() + ")|*." + drCurrent["File_Tag"].ToString() + "|All files (*.*)|*.*";
                dialog.FileName = drCurrent["File_Name"].ToString();
                if (this.objFileContent != null)
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    stream.Write((byte[])this.objFileContent, 0, ((byte[])this.objFileContent).Length);
                    stream.Close();
                    Process.Start(dialog.FileName);
                }
            }

        }
        void tlResource_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (bdsResource.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);
            string strColumnName = tlResource.FocusedColumn.Name;
            if (strColumnName == "DUYET")
            {
                if (drCurrent["ZaloLink"].ToString() != string.Empty)
                {
                    frmDuyet frm = new frmDuyet();
                    frm.Load(drCurrent);
                    if (frm.isAccept)
                    {
                        ReleaseType = "S";
                        MsgIDCur = Convert.ToInt32(drCurrent["Ident00"]);
                        EpointProcessBox.Show(this);
                        Common.CopyDataRow(drCurrent, ((DataRowView)bdsResource.Current).Row);
                        ReleaseType = string.Empty;
                    }
                }
            }

        }
        void cboFile_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFile_Type.Text.Trim() == "*")
                this.FillData();
            else
            {
                bdsResource.Filter = "File_Type = '" + cboFile_Type.Text.Trim() + "'";
                this.FillData();
            }
        }
        #endregion
        public override void EpointRelease()
        {

            if (ReleaseType == "S")
            {
                string strMsgLog = string.Empty;
                try
                {
                    if (!Directory.Exists(FilePathZalo))
                    {
                        Directory.CreateDirectory(FilePathZalo);
                    }
                    object objImage;
                    string strMsg = string.Empty;
                    string AttachmentId = string.Empty;
                    string ZaloLink, File_Name, Description;
                    string FileImg;
                    //string FilePathZalo
                    //string strMa_Cbnv, strTen_Cbnv, strEmail, strMa_Kv, strMa_Loai2, strSubject;
                    EpointProcessBox.AddMessage("Lấy dữ liệu tin nhắn");

                    DataTable dtMsg = SQLExec.ExecuteReturnDt(" EXEC TUANVIET_OFFICIAL.dbo.Z_GetMessage_ToZalo " + MsgIDCur.ToString());

                    if (dtMsg == null || dtMsg.Rows.Count == 0)
                    {
                        EpointProcessBox.AddMessage("không lấy được dữ liệu tin nhắn");
                        return;
                    }
                    EpointProcessBox.AddMessage("Bắt đầu gửi tin nhắn");
                    //foreach (DataRow drmsg in dtMsg.Rows)
                    //{

                    DataRow drmsg = dtMsg.Rows[0];
                    //int MsgID = Convert.ToInt32(drmsg["Ident00"]);
                    ZaloLink = drmsg["ZaloLink"].ToString();
                    objImage = drmsg["File_Content"];
                    File_Name = drmsg["File_Name"].ToString();
                    Description = drmsg["Description"].ToString();

                    FileImg = FilePathZalo + @"\" + (drmsg["File_Tag"].ToString() == string.Empty ? String.Empty : drmsg["File_ID"].ToString() + "." + drmsg["File_Tag"].ToString());

                    //Common.WriteToFileZaloLog("Start Send Message ToZalo : " + FileImg);
                    if (SaveZaloResource.LoadResourceImage(FileImg, objImage))
                    {
                        ZaloFile Zfile = new ZaloFile(FileImg);
                        Zfile.setMediaTypeHeader("Image/PNG");
                        JObject updatefile = client.uploadImageForOfficialAccountAPI(Zfile);
                        dynamic dynObjFile = JsonConvert.DeserializeObject(updatefile.ToString());
                        AttachmentId = dynObjFile.data.attachment_id;
                    }

                    //Get list employee in branch 
                    //string strSQLEm = "Z_GetEmployee_ByTag " + drmsg["Ident00"] + "";

                    strMsg = File_Name + "\n" + Description + "\n" + ZaloLink;
                    if (true)
                    {
                        DataTable dtEmployee_Br = SQLExec.ExecuteReturnDt("EXEC Z_GetEmployee_ByTag " + MsgIDCur.ToString());
                        if (dtEmployee_Br == null || dtEmployee_Br.Rows.Count == 0) return;

                        foreach (DataRow drR in dtEmployee_Br.Rows)
                        {
                            JObject jSendbr = client.sendImageMessageToUserIdByAttachmentId(drR["Zalo_ID"].ToString(), strMsg, AttachmentId);
                        }
                    }
                    else
                    {
                        JObject jSend_hungnv = client.sendImageMessageToUserIdByAttachmentId("5643947530772678208", strMsg, AttachmentId);
                    }
                    SQLExec.Execute("EXEC TUANVIET_OFFICIAL.dbo.Z_UpdateMessageZaloAfterSend " + MsgIDCur.ToString());
                    EpointProcessBox.AddMessage("Kết thúc");

                }
                catch (Exception ex)
                {
                    EpointProcessBox.AddMessage("Fail Send Message to Zalo : " + strMsgLog + "-------------\n" + ex.ToString());
                }
            }
            else if (ReleaseType == "G")
            {
                EpointProcessBox.AddMessage("Đang cập nhật thông tin người theo dõi!...................");
                UpdateFollower();
                ReleaseType = string.Empty;
                EpointProcessBox.AddMessage("....................Kết thúc...................");
            }
        }
        private void UpdateFollower()
        {
            string strMa_Cbnv, strZalo_ID;
            DataTable dtEm = SQLExec.ExecuteReturnDt("TUANVIET_OFFICIAL.dbo.Z_GetAllEmployee");
            foreach (DataRow drP in dtEm.Rows)
            {
                //if ((Boolean)drP["Sent_Mail"])
                //    continue;

                strMa_Cbnv = drP["Ma_Cbnv"].ToString();
                strZalo_ID = drP["Zalo_ID"].ToString();
                JObject jInfo = client.getProfileOfFollower(strZalo_ID);
                dynamic dynjInfo = JsonConvert.DeserializeObject(jInfo.ToString());
                if (dynjInfo.error != "0")
                {
                    continue;
                }

                Follower User = new Follower();
                User.id = dynjInfo.data.user_id;
                User.gender = dynjInfo.data.user_gender;
                User.name = dynjInfo.data.display_name;
                User.shared_info = false;
                User.Addr = dynjInfo.data.user_id_by_app;
                User.Avatar = dynjInfo.data.avatar;
                if (dynjInfo.data.shared_info != null)//User có chia sẻ thông tin
                {
                    User.Addr = dynjInfo.data.shared_info.address + "#" + dynjInfo.data.shared_info.ward + "#" + dynjInfo.data.shared_info.district + "#" + dynjInfo.data.shared_info.city;
                    User.Phone = dynjInfo.data.shared_info.phone;
                    User.name = dynjInfo.data.shared_info.name;
                    User.shared_info = true;
                    if (dynjInfo.data.shared_info.birth_date != "0")// Có ngày sinh nhật
                    {
                        User.birthday = dynjInfo.data.shared_info.birth_date;
                    }
                }
                if (dynjInfo.data.tags_and_notes_info.tag_names != null)//User có chia sẻ thông tin
                {
                    //User.TagName = dynjInfo.data.tags_and_notes_info.tag_names;
                    JArray items = (JArray)dynjInfo.data.tags_and_notes_info["tag_names"];
                    int length = items.Count;
                    for (int i = 0; i < items.Count; i++)
                    {
                        string tag = items[i].ToString();
                        User.TagName += tag + ";";
                        //do something with item
                    }
                }

                SaveZaloResource.SQLUpdateFollowerInfor(User);


            }

            EpointProcessBox.AddMessage("Số lượng người được cập nhật : " + dtEm.Rows.Count.ToString());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                ReleaseType = "G";
                EpointProcessBox.Show(this);
                ReleaseType = string.Empty;
            }

            else
            {
                base.OnKeyDown(e);
            }
        }

    }
}