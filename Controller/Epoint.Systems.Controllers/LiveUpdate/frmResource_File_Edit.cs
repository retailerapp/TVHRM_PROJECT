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

namespace Epoint.Controllers
{
    public partial class frmResource_File_Edit : Epoint.Systems.Customizes.frmEdit
    {

        object objFileContent;

        #region Phuong thuc
        public frmResource_File_Edit()
        {
            InitializeComponent();

            this.btUpLoad.Click += new EventHandler(btUpLoad_Click);
            this.btDownLoad.Click += new EventHandler(btDownLoad_Click);
            this.btRemove.Click += new EventHandler(btRemove_Click);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }


        new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            //this.drEdit = drEdit;
            //this.enuNew_Edit = enuNew_Edit;
            //this.Tag = (char)enuNew_Edit + ", " + this.Tag;

            this.cboFile_Type.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT 'DLL' AS File_Type UNION ALL SELECT DISTINCT 'RPX' AS File_Type UNION ALL SELECT DISTINCT 'DOC' AS File_Type UNION ALL SELECT DISTINCT 'PDF' AS File_Type UNION ALL SELECT DISTINCT 'IMG' AS File_Type UNION ALL SELECT DISTINCT 'XLS' AS File_Type UNION ALL SELECT DISTINCT 'EXE' AS File_Type ");
            this.cboFile_Type.DisplayMember = "File_Type";
            this.cboFile_Type.ValueMember = "File_Type";
            //Common.ScaterMemvar(this, ref drEdit);

            //this.ShowDialog();
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = ((char)((ushort)enuNew_Edit)) + ", " + this.Tag;
            Common.ScaterMemvar(this, ref drEdit);
            if (enuNew_Edit == enuEdit.Edit)
            {
                //Không cho phép sửa File_ID khi nhấn nút Sửa
                txtFile_Id.Enabled = false;

                this.cboFile_Type.Enabled = false;
                this.objFileContent = SaveResource_UpdateFile.LoadResource(this.drEdit["File_Id"].ToString());
                if (this.objFileContent != null)
                {
                    using (Stream stream = new MemoryStream())
                    {
                        new BinaryFormatter().Serialize(stream, this.objFileContent);
                        this.lblSize.Text = "(" + stream.Length.ToString() + ")";
                    }
                }
            }

            this.ShowImage();
            this.BindingLanguage();
            this.LoadDicName();
            this.ShowDialog();
        }
        private void LoadDicName()
        {
            this.lbtFile_Tag.Text = this.drEdit["File_Tag"].ToString();
        }
        private bool FormCheckValid()
        {
            if (txtFile_Name.Text.Trim() == string.Empty)
            {
                EpointMessage.MsgCancel("Tên file không được rỗng");
                return false;
            }

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
            //if (DataTool.SQLCheckExist("SYSRESOURCES", "File_Id", this.drEdit["File_Id"].ToString()))
            //{
            //    EpointMessage.MsgOk("Mã tập tin bị trùng !");
            //    return false;
            //}
            if (!SQLExec.Execute("Sp_UpdateResource_Ver", drEdit, CommandType.StoredProcedure))
            {
                return false;
            }
            
            //Upload file
            SaveResource_UpdateFile.SaveFile(this.drEdit["File_Id"].ToString(), this.drEdit["File_Name"].ToString(), this.drEdit["Ma_Nhom"].ToString(), this.drEdit["Catalog"].ToString(), this.drEdit["File_Type"].ToString(), this.drEdit["File_Tag"].ToString(), this.objFileContent, (DateTime)this.drEdit["Ngay_Ky"], this.drEdit["Description"].ToString(), (bool)this.drEdit["Duyet"]);            

            return true;
        }
        private void ShowImage()
        {
            if (this.objFileContent != null)
            {
                //if (this.cboFile_Type.Text == "IMG")
                //{
                //    this.picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((byte[])this.objFileContent)), this.picImage.Size);
                //}
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            if (this.cboFile_Type.Text == "IMG")
            {
                dialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "XLS")
            {
                dialog.Filter = "(*.XLS;*.XLSX)|*.XLS;*.XLSX|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "DOC")
            {
                dialog.Filter = "(*.DOC;*.DOCX)|*.DOC;*.DOCX|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "EXE")
            {
                dialog.Filter = "(*.EXE)|*.EXE|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "PDF")
            {
                dialog.Filter = "(*.PDF)|*.PDF|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "DLL")
            {
                dialog.Filter = "(*.DLL)|*.DLL|All files (*.*)|*.*";
            }
            else if (this.cboFile_Type.Text == "RPX")
            {
                dialog.Filter = "(*.RPX)|*.RPX|All files (*.*)|*.*";
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.objFileContent = File.ReadAllBytes(dialog.FileName);
                this.ShowImage();
                this.cboFile_Type.Enabled = false;
                this.lbtFile_Tag.Text = Path.GetExtension(dialog.FileName).Substring(1).ToUpper();
                this.txtFile_Id.Text = System.IO.Path.GetFileName(dialog.FileName);
                this.txtFile_Name.Text = System.IO.Path.GetFileName(dialog.FileName);
            }
        }

        private void RemoveFile()
        {
            this.objFileContent = null;
            //this.picImage.Image = null;
            this.cboFile_Type.Enabled = true;
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
                    EpointMessage.MsgOk("File not found !");
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
        #endregion
    }
}