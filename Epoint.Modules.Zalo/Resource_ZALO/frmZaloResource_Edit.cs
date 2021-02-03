using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using System.Collections;

namespace Epoint.Modules.Zalo
{
    public partial class frmZaloResource_Edit : Epoint.Systems.Customizes.frmEdit
    {

        object objFileContent;
        int Ident00;

        #region Phuong thuc
        public frmZaloResource_Edit()
        {
            InitializeComponent();

            this.btUpLoad.Click += new EventHandler(btUpLoad_Click);
            this.btDownLoad.Click += new EventHandler(btDownLoad_Click);
            this.btRemove.Click += new EventHandler(btRemove_Click);


            this.btMa_Kv_Tag.Click += new EventHandler(btMa_Kv_Tag_Click);
            this.btMa_Bp_Tag.Click += new EventHandler(btMa_Bp_Tag_Click);
            this.btTag_List.Click += new EventHandler(btTag_List_Click);
            btView.Click += new EventHandler(btView_Click);


            txtZaloLink.Validated += new EventHandler(txtZaloLink_Validated);           

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        void btView_Click(object sender, EventArgs e)
        {
            try
            {
                picImage.Image = GenerateScreenshot(txtZaloLink.Text);
            }
            catch
            {
                MessageBox.Show("Khong xem duoc");
            }
        }

        void txtZaloLink_Validated(object sender, EventArgs e)
        {
           
        }

       

        new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            //this.drEdit = drEdit;
            //this.enuNew_Edit = enuNew_Edit;
            //this.Tag = (char)enuNew_Edit + ", " + this.Tag;
            this.cboFile_Type.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT 'DOC' AS File_Type UNION ALL SELECT DISTINCT 'IMG' AS File_Type UNION ALL SELECT DISTINCT 'XLS' AS File_Type UNION ALL SELECT DISTINCT 'EXE' AS File_Type ");
            this.cboFile_Type.DisplayMember = "File_Type";
            this.cboFile_Type.ValueMember = "File_Type";
            //Common.ScaterMemvar(this, ref drEdit);

            //this.ShowDialog();
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = ((char)((ushort)enuNew_Edit)) + ", " + this.Tag;


            if (enuNew_Edit == enuEdit.New)
            {
                Ident00 = 0;
                drEdit["Ident00"] = 0;
                drEdit["Duyet"] = 0;
                drEdit["IsZaloSend"] = 0;
                drEdit["Nguoi_Ky"] = "";
                this.objFileContent = ImageToByte(picImage.Image);
            }
            Common.ScaterMemvar(this, ref drEdit);
            Ident00 = (int)drEdit["Ident00"];
            
            if (enuNew_Edit == enuEdit.Edit)
            {
                //Edit: Disable Ma_Vt                
                txtFile_Id.Enabled = false;

                this.cboFile_Type.Enabled = false;
                this.objFileContent = SaveZaloResource.LoadResource(Ident00);
                if (this.objFileContent != null)
                {
                    using (Stream stream = new MemoryStream())
                    {
                        new BinaryFormatter().Serialize(stream, this.objFileContent);
                        this.lblSize.Text = "(" + stream.Length.ToString() + ")";
                    }
                }


                if ((bool)(drEdit["IsZaloSend"]))
                {
                    btgAccept.btAccept.Enabled = false;
                    btUpLoad.Enabled = false;
                }
                
            }
            this.ShowImage();
            this.LoadDicName();
            this.ShowDialog();
        }
        private void LoadDicName()
        {
            this.lbtFile_Tag.Text = this.drEdit["File_Tag"].ToString();
           
        }
        private bool FormCheckValid()
        {
            //if (txtFile_Name.Text.Trim() == string.Empty)
            //{
            //    EpointMessage.MsgCancel("Tên file không được rỗng");
            //    return false;
            //}

            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref this.drEdit);
            this.drEdit["File_Tag"] = this.lbtFile_Tag.Text;

           
            if (!this.FormCheckValid())
            {
                return false;
            }
            //int Ident00 =  Convert.ToInt32(this.drEdit["Ident00"]);
            DataTable dtupdate =  SaveZaloResource.SaveZaloResoure(Ident00, this.drEdit["File_Id"].ToString(), this.drEdit["File_Name"].ToString(), this.drEdit["Ma_Nhom"].ToString(), this.drEdit["Catalog"].ToString(),
                                                this.drEdit["File_Type"].ToString(), this.drEdit["File_Tag"].ToString(), this.objFileContent, (DateTime)this.drEdit["Ngay_Ky"], this.drEdit["Nguoi_Ky"].ToString(), (bool)this.drEdit["Duyet"]
                                               , this.drEdit["Description"].ToString(), this.drEdit["ZALOLINK"].ToString(), this.drEdit["MA_KV_LIST"].ToString(), this.drEdit["MA_BP_LIST"].ToString(), this.drEdit["Tag_List"].ToString());
            if (dtupdate.Rows.Count > 0)
            {
                Ident00 = Convert.ToInt32(this.drEdit["Ident00"]);
                this.drEdit["Ident00"] = dtupdate.Rows[0]["Ident00"];
                this.drEdit["File_Id"] = dtupdate.Rows[0]["File_Id"];
                this.drEdit["File_Id_Parent"] = dtupdate.Rows[0]["File_Id_Parent"];
            }
            else
                return false;
            //if (Ident00 != 0)
            //{
                
            //}
            //if (DataTool.SQLCheckExist("SYSRESOURCES", "File_Id", this.drEdit["File_Id"].ToString()) && enuNew_Edit == enuEdit.New)
            //{
            //    EpointMessage.MsgOk("Mã tập tin đã tồn tại !");
            //    return false;
            //}

            //if (!SQLExec.Execute("Sp_UpdateResource", drEdit, CommandType.StoredProcedure))
            //{
            //    return false;
            //}

            //if (drEdit["File_Type"].ToString() == "IMG")
            //    SaveResource.SaveImage(this.drEdit["File_Id"].ToString(), this.drEdit["File_Name"].ToString(), this.drEdit["Ma_Nhom"].ToString(), this.drEdit["Catalog"].ToString(), this.drEdit["File_Type"].ToString(), this.drEdit["File_Tag"].ToString(), picImage, (DateTime)this.drEdit["Ngay_Ky"], this.drEdit["Nguoi_Ky"].ToString(), (bool)this.drEdit["Duyet"]);
            //else
            //    SaveResource.Save(this.drEdit["File_Id"].ToString(), this.drEdit["File_Name"].ToString(), this.drEdit["Ma_Nhom"].ToString(), this.drEdit["Catalog"].ToString(), this.drEdit["File_Type"].ToString(), this.drEdit["File_Tag"].ToString(), this.objFileContent, (DateTime)this.drEdit["Ngay_Ky"], this.drEdit["Nguoi_Ky"].ToString(), (bool)this.drEdit["Duyet"]);

            return true;

        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void ShowImage()
        {
            if (this.objFileContent != null)
            {
                if (this.cboFile_Type.Text == "IMG")
                {
                    //this.picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((byte[])this.objFileContent)), this.picImage.Size);
                    this.picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((byte[])this.objFileContent)));
                    this.picImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                //else if (this.cboFile_Type.Text == "XLS")
                //{
                //    this.picImage.Image = this.imageList1.Images["EXCEL"];
                //}
                //else if (this.cboFile_Type.Text == "DOC")
                //{
                //    this.picImage.Image = this.imageList1.Images["DOC"];
                //}
                //else if (this.cboFile_Type.Text == "EXE")
                //{
                //    this.picImage.Image = this.imageList1.Images["EXE"];
                //}
            }
        }
        private void UploadFile()
        {
            cboFile_Type.Text = "IMG";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
            if (this.cboFile_Type.Text == "IMG")
            {
                dialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
            }
            //else if (this.cboFile_Type.Text == "XLS")
            //{
            //    dialog.Filter = "(*.XLS;*.XLSX)|*.XLS;*.XLSX|All files (*.*)|*.*";
            //}
            //else if (this.cboFile_Type.Text == "DOC")
            //{
            //    dialog.Filter = "(*.DOC;*.DOCX)|*.DOC;*.DOCX|All files (*.*)|*.*";
            //}
            //else if (this.cboFile_Type.Text == "EXE")
            //{
            //    dialog.Filter = "(*.EXE)|*.EXE|All files (*.*)|*.*";
            //}
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.objFileContent = File.ReadAllBytes(dialog.FileName);
                this.ShowImage();
                this.cboFile_Type.Enabled = false;
                this.lbtFile_Tag.Text = Path.GetExtension(dialog.FileName).Substring(1).ToUpper();
            }
        }
        private void RemoveFile()
        {
            this.objFileContent = null;
            this.picImage.Image = null;
            this.cboFile_Type.Enabled = true;
            this.lbtFile_Tag.Text = "";
        }

        public Bitmap GenerateScreenshot(string url)
        {
            try
            {
                // Load the webpage into a WebBrowser control
                WebBrowser wb = new WebBrowser();
                wb.ScrollBarsEnabled = false;
                wb.ScriptErrorsSuppressed = true;
                wb.Navigate(url);

                // waits for the page to be completely loaded
                while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

                // Take Screenshot of the web pages full width + some padding
                wb.Width = wb.Document.Body.ScrollRectangle.Height;
                // Take Screenshot of the web pages full height
                wb.Height = wb.Document.Body.ScrollRectangle.Height;

                // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
                Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
                wb.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, wb.Width, wb.Height));
                wb.Dispose();

                return bitmap;
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
                return null;
            }
        }
        #endregion

        #region Su kien

        void btRemove_Click(object sender, EventArgs e)
        {
            this.RemoveFile();
        }

        void btDownLoad_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "(*." + this.lbtFile_Tag.Text + ")|*." + this.lbtFile_Tag.Text + "|All files (*.*)|*.*";
            dialog.FileName = this.txtFile_Name.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (this.objFileContent != null)
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    stream.Write((byte[])this.objFileContent, 0, ((byte[])this.objFileContent).Length);
                    stream.Close();
                    if (this.chkOpen.Checked)
                    {
                        Process.Start(dialog.FileName);
                    }
                }
                else
                    EpointMessage.MsgOk("Tập tin rỗng");
            }

        }

        void btUpLoad_Click(object sender, EventArgs e)
        {
            this.UploadFile();

        }
        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                isAccept = true;
                this.Close();
            }
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        void btTag_List_Click(object sender, EventArgs e)
        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtTag_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Dt", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtTag_List.Text = "*";
                return;
            }
            txtTag_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }

        void btMa_Bp_Tag_Click(object sender, EventArgs e)
        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtMa_Bp_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Bp", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtMa_Bp_List.Text = "*";
                return;
            }
            txtMa_Bp_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }

        void btMa_Kv_Tag_Click(object sender, EventArgs e)

        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtMa_Kv_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Kv", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtMa_Kv_List.Text = "*";
                return;
            }
            txtMa_Kv_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }

        #endregion
    }
}