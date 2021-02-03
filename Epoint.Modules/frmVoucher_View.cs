using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using System.Data.OleDb;
using System.Data.SqlClient;
using Epoint.Systems.Customizes;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;


namespace Epoint.Modules
{
    public partial class frmVoucher_View : Epoint.Systems.Customizes.frmView
    {
        #region Fields

        public DataSet dsVoucher = new DataSet("dsVoucher");

        public DataTable dtViewPh;
        public DataTable dtViewCt;

        public BindingSource bdsViewPh = new BindingSource();
        public BindingSource bdsViewCt = new BindingSource();

        public dgvVoucherGrid dgvViewPh = new dgvVoucherGrid();
        public dgvVoucherGrid dgvViewCt = new dgvVoucherGrid();

        //public dgvVoucher dgvViewPh = new dgvVoucher();
        //public dgvVoucher dgvViewCt = new dgvVoucher();

        public DataRelation drlView;

        public string strMa_Ct_List = string.Empty;
        public DataRow drCurrent;
        public DataRow drDmCt;

        public string strFilterKey_Old = string.Empty;

        public string Is_Key_Filter = string.Empty;

        #endregion

        #region Contructor

        public frmVoucher_View()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            this.Resize += new EventHandler(frmViewPh_Resize);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);

            bdsViewPh.PositionChanged += new EventHandler(bdsViewPh_PositionChanged);

            btPreview.Click += new EventHandler(btPreview_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btFilter.Click += new EventHandler(btFilter_Click);
            //btExit.Click += new EventHandler(btExit_Click);
            btBack.Click += new EventHandler(btBack_Click);
            btImport.Click += new EventHandler(btImport_Click);

  
            dgvViewPh.dgvGridView.Click += new EventHandler(dgvViewPh_CellMouseClick);
            dgvViewPh.dgvGridView.CustomDrawCell += new RowCellCustomDrawEventHandler(dgvViewPh_CellFormatting);
            dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
            dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);

            SetColor();
        }

        public void Load(string strMa_Ct_List)
        {            
            this.strMa_Ct_List = strMa_Ct_List;
            this.Object_ID = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Object_ID) FROM SYSDMCT WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "'");

            this.Build();

            object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
            int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));
            string sYear = Convert.ToString(Parameters.GetParaValue("YEAR_FILTER"));
            string sMonth = Convert.ToString(Parameters.GetParaValue("MONTH_FILTER"));

            DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

            string strFilterKey = string.Empty;
            strFilterKey += "(Ma_Ct IN ('" + strMa_Ct_List.Replace(",", "','") + "'))";

            //Hiển thị chứng từ theo năm hoặc theo ngày
            if (sYear == "1")
                strFilterKey += " AND (YEAR(Ngay_Ct) =  " + Element.sysWorkingYear + ")";
            else
                strFilterKey += " AND (Ngay_Ct BETWEEN  '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "')";

            if (sMonth == "1")
                strFilterKey += " AND (MONTH(Ngay_Ct) =  " + DateTime.Now.Month + ") ";

            strFilterKey += " AND (Ma_DvCs = '" + Element.sysMa_DvCs + "')";

            //strFilterKey_Old -> btBack
            strFilterKey_Old = strFilterKey;

            if (Common.Inlist(strMa_Ct_List, "BG,BGM,SO"))            
                this.FillDataBG(strFilterKey, strFilterKey);
            else
                this.FillData(strFilterKey, strFilterKey);
            this.BindingLanguage();
            this.BindingTong_Tien();

            ////Phan quyen truy cap gia, tien
            //string strMa_Ct_Access = SQLExec.ExecuteReturnValue("SELECT Ma_Ct_Access FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "' AND MEMBER_TYPE = 'U'").ToString();
            //if (!Element.sysIs_Admin)
            //    if (Common.Inlist(strMa_Ct_List, strMa_Ct_Access))
            //        if (!Common.CheckPermission("ACCESS_PRICE", enuPermission_Type.Allow_Access))
            //        {
            //            dgvViewCt.Columns["GIA_NT9"].Visible = false;
            //            dgvViewCt.Columns["TIEN_NT9"].Visible = false;
            //            dgvViewPh.Columns["TTIEN"].Visible = false;

            //            numTTien0.Visible = false;
            //            numTTien_Nt0.Visible = false;
            //            numTTien3.Visible = false;
            //            numTTien_Nt3.Visible = false;
            //        }

            this.FormLayout();

            this.Show();
        }

        #endregion

        #region Build, FillData

        private void Build()
        {
            string strMa_Ct = strMa_Ct_List.Split(',')[0];

            drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);

            //dgvViewPh             
            dgvViewPh.ReadOnly = true;
            dgvViewPh.strZone = (string)drDmCt["Zone_ViewPh"];

            dgvViewPh.BuildGridView(false);

            /*   Chưa làm được phân biết tiền tệ
            if (!dgvViewPh.Columns.Contains("Ma_Tte"))
            {
                dgvViewPh.Columns.Add("Ma_Tte", "Ma_Tte"); //Thêm cột để phân biệt chứng từ Nte, VND
                dgvViewPh.Columns["Ma_Tte"].DataPropertyName = "MA_TTE";
                dgvViewPh.Columns["Ma_Tte"].ValueType = typeof(string);
                dgvViewPh.Columns["Ma_Tte"].Visible = false;
            }

            dgvViewPh.Columns.Add("Mark", "Mark"); //Đánh dấu dòng
            dgvViewPh.Columns["Mark"].DataPropertyName = "MARK";
            dgvViewPh.Columns["Mark"].ValueType = typeof(string);
            dgvViewPh.Columns["Mark"].Visible = false;
            */
            //dgvViewCt
            dgvViewCt.ReadOnly = true;
            dgvViewCt.strZone = (string)drDmCt["Zone_ViewCt"];

            dgvViewCt.BuildGridView(false);

            //Position
            this.Controls.Add(dgvViewPh);
            this.Controls.Add(dgvViewCt);
            dgvViewPh.TabIndex = 0;
            dgvViewCt.TabIndex = 1;

        }

        private void FillData(string strKey_Ph, string strKey_Ct)
        {
            string strTable_Ph = (string)drDmCt["Table_Ph"];
            string strTable_Ct = (string)drDmCt["Table_Ct"];
            
            if (!Element.sysIs_Admin) //Khong phai user thuoc nhom Admin
            {
                if (!Common.CheckPermission("MEMBER_ID_ALLOW", enuPermission_Type.Allow_Access)) //Khong duoc truy cap chung tu user khac
                {
                    strKey_Ph += "AND SUBSTRING(Create_Log,15,LEN(Create_Log)) = '" + Element.sysUser_Id + "'";
                    strKey_Ct += " AND Stt IN (SELECT Stt FROM " + strTable_Ph + " WHERE SUBSTRING(Create_Log,15,LEN(Create_Log)) = '" + Element.sysUser_Id + "')";
                }

                if (Common.CheckPermission("MEMBER_ID_ALLOW", enuPermission_Type.Allow_Access)) //Duoc phep truy cap chung tu cua user khac
                {
                    string strUser_Access = (string)SQLExec.ExecuteReturnValue("SELECT Member_Access FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Access.Contains("*,"))// *: Xem chứng từ của tất cả user, ngược lại là chỉ xem được các chứng từ của user cho phép
                    {
                        string[] User = strUser_Access.Split(new char[] { ',' });
                        string strUser = string.Empty;
                        foreach (string u in User)
                        {
                            if (u.Trim() != "")
                                strUser += "'" + u + "',";
                        }
                        //Cong them User hien tai dang log vao -> user dang log vao co the thay chung tu cua chinh minh va chung tu cua user khác duoc cho phep truy xuat
                        strUser = strUser + "'" + Element.sysUser_Id + "'";
                        strKey_Ph += " AND SUBSTRING(Create_Log,15,LEN(Create_Log)) IN (" + strUser + ")";
                        strKey_Ct += " AND Stt IN (SELECT Stt FROM " + strTable_Ph + " WHERE SUBSTRING(Create_Log,15,LEN(Create_Log)) IN (" + strUser + "))";
                    }
                }
            }
            
            string strSelectPh = " *, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt, CAST(0 AS BIT) AS Mark ,SUBSTRING(Create_Log,15,LEN(Create_Log)) AS User_Create";
            dtViewPh = DataTool.SQLGetDataTable(strTable_Ph, strSelectPh, strKey_Ph, "Ngay_Ct, So_Ct");
            dtViewPh.TableName = strTable_Ph;

            bdsViewPh.DataSource = dtViewPh;
            dgvViewPh.DataSource = bdsViewPh;

            dtViewCt = DataTool.SQLGetDataTable(strTable_Ct, "*", strKey_Ct, "Ngay_Ct");
            dtViewCt.TableName = strTable_Ct;

            //Thêm tổng tiền ở phía dưới
            if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
            {
                DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
                dcNew.Expression = "Tien + Tien3";
                dtViewCt.Columns.Add(dcNew);

                dcNew = new DataColumn("TTIEN_NT", typeof(double));
                dcNew.Expression = "Tien_Nt + Tien_Nt3";
                dtViewCt.Columns.Add(dcNew);
            }

            bdsViewCt.DataSource = dtViewCt;
            dgvViewCt.DataSource = bdsViewCt;

            dsVoucher.Tables.Clear();
            dsVoucher.Tables.Add(dtViewPh);
            dsVoucher.Tables.Add(dtViewCt);

            //Lay du lieu tu Ct len Ph theo danh sach Carry_Header
            Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);


            DataRow[] arrdrViewCt;
            DataRow drViewCt;
            foreach (DataRow drViewPh in dtViewPh.Rows)
            {
                string strStt = (string)drViewPh["Stt"];
                arrdrViewCt = dtViewCt.Select("Stt = '" + strStt + "'");

                if (arrdrViewCt.Length > 0)
                    drViewCt = arrdrViewCt[0];
                else
                    continue;

                Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
            }

            bdsViewPh.MoveLast();

            this.bdsSearch = bdsViewPh;
            this.ExportControl = dgvViewPh;
        }

        private void FillDataBG(string strKey_Ph, string strKey_Ct)
        {
            string strTable_Ph = (string)drDmCt["Table_Ph"];
            string strTable_Ct = (string)drDmCt["Table_Ct"];


            string strSelectPh = string.Empty;

            if (strMa_Ct_List == "BG" || strMa_Ct_List == "BGM")
                strSelectPh = @"SELECT *, CAST(0 AS BIT) AS Is_Used, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt, CAST(0 AS BIT) AS Mark 
										INTO #T_Ph
									FROM " + strTable_Ph + " WHERE " + strKey_Ph + @"
									UPDATE #T_Ph SET
										Is_Used = 1
										WHERE So_Ct IN (SELECT DISTINCT So_Ct_Bg FROM ARSO)

									SELECT * FROM #T_Ph ORDER BY Ngay_Ct, So_Ct
									DROP TABLE #T_Ph";

            else if (strMa_Ct_List == "SO")
                strSelectPh = @"SELECT *, CAST(0 AS BIT) AS Is_Used, TTien0 + TTien3 AS TTien, TTien_Nt0 + TTien_Nt3 AS TTien_Nt, CAST(0 AS BIT) AS Mark 
										INTO #T_Ph
									FROM " + strTable_Ph + " WHERE " + strKey_Ph + @"
									UPDATE #T_Ph SET
										Is_Used = 1
										WHERE Stt IN (SELECT DISTINCT Stt FROM MACTLSX)

									SELECT * FROM #T_Ph ORDER BY Ngay_Ct, So_Ct
									DROP TABLE #T_Ph";


            dtViewPh = SQLExec.ExecuteReturnDt(strSelectPh);

            dtViewPh.TableName = strTable_Ph;

            bdsViewPh.DataSource = dtViewPh;
            dgvViewPh.DataSource = bdsViewPh;

            bdsViewPh.Filter = "Is_Used = 0";

            dtViewCt = DataTool.SQLGetDataTable(strTable_Ct, "*", strKey_Ct, "Ngay_Ct");
            dtViewCt.TableName = strTable_Ct;

            //Thêm tổng tiền ở phía dưới
            if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
            {
                DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
                dcNew.Expression = "Tien + Tien3";
                dtViewCt.Columns.Add(dcNew);

                dcNew = new DataColumn("TTIEN_NT", typeof(double));
                dcNew.Expression = "Tien_Nt + Tien_Nt3";
                dtViewCt.Columns.Add(dcNew);
            }

            bdsViewCt.DataSource = dtViewCt;
            dgvViewCt.DataSource = bdsViewCt;

            dsVoucher.Tables.Clear();
            dsVoucher.Tables.Add(dtViewPh);
            dsVoucher.Tables.Add(dtViewCt);

            //Lay du lieu tu Ct len Ph theo danh sach Carry_Header
            Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);
            foreach (DataRow drViewPh in dtViewPh.Rows)
            {
                string strStt = (string)drViewPh["Stt"];
                DataRow drViewCt = dtViewCt.Select("Stt = '" + strStt + "'")[0];

                Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
            }

            bdsViewPh.MoveLast();

            this.bdsSearch = bdsViewPh;
            this.ExportControl = dgvViewPh;
        }
        private void Filter()
        {
            DataTable dtFilter = new DataTable();

            dtFilter.Columns.Add(new DataColumn("Ma_Ct", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Quyen", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("So_Ct0_1", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("So_Ct0_2", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
            dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
            dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Sp", typeof(string)));            
            dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_KhoN", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_CbNv", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Tc", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Is_Thue_Vat", typeof(bool)));
            dtFilter.Columns.Add(new DataColumn("Is_Nb", typeof(bool)));
            dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

            DataRow drFilter = dtFilter.NewRow();

            //Set Default 
            drFilter["Ma_Ct"] = strMa_Ct_List;
            drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
            drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;

            string strTable_Ph = (string)drDmCt["Table_Ph"];
            string strTable_Ct = (string)drDmCt["Table_Ct"];

            drFilter["Table"] = strTable_Ct;
            drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

            if (!this.Filter_ShowForm(drFilter))
                return;

            //1: Lọc theo thông tin tổng; 2-Lọc theo chi tiết từng dòng
            if (Is_Key_Filter == "1")
                drFilter["Table"] = strTable_Ph;
            if (Is_Key_Filter == "2")
                drFilter["Table"] = strTable_Ct;

            string strKey = (string)SQLExec.ExecuteReturnValue("sp_GetVoucherFilterKey", drFilter, CommandType.StoredProcedure);

            string strKey_Ph, strKey_Ct;

            if (drFilter["Is_Thue_Vat"].ToString() != string.Empty)
            {
                if ((bool)drFilter["Is_Thue_Vat"])
                    strKey_Ph = "Stt IN (" + strKey + " AND (Is_Thue_Vat = 1))";
                else if ((bool)drFilter["Is_Nb"])
                    strKey_Ph = "Stt IN (" + strKey + " AND (Is_Thue_Vat = 0))";
                else
                    strKey_Ph = "Stt IN (" + strKey + ")";
            }
            else
                strKey_Ph = "Stt IN (" + strKey + ")";

            strKey_Ct = "Stt IN (" + strKey + ")";

            //Filter
            if (!Element.sysIs_Admin)
            {
                if (!Common.CheckPermission("MEMBER_ID_ALLOW", enuPermission_Type.Allow_Access))
                {
                    strKey_Ph += "AND SUBSTRING(Create_Log,15,LEN(Create_Log)) = '" + Element.sysUser_Id + "'";
                    strKey_Ct += " AND Stt IN (SELECT Stt FROM " + strTable_Ph + " WHERE SUBSTRING(Create_Log,15,LEN(Create_Log)) = '" + Element.sysUser_Id + "')";
                }

                if (Common.CheckPermission("MEMBER_ID_ALLOW", enuPermission_Type.Allow_Access))
                {
                    string strUser_Access = (string)SQLExec.ExecuteReturnValue("SELECT Member_Access FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Access.Contains("*,"))// *: Xem chứng từ của tất cả user, ngược lại là chỉ xem được các chứng từ của user cho phép
                    {
                        string[] User = strUser_Access.Split(new char[] { ',' });
                        string strUser = string.Empty;
                        foreach (string u in User)
                        {
                            if (u.Trim() != "")
                                strUser += "'" + u + "',";
                        }
                        //Cong them User hien tai dang log vao -> user dang log vao co the thay chung tu cua chinh minh va chung tu cua user khác duoc cho phep truy xuat
                        strUser = strUser + "'" + Element.sysUser_Id + "'";
                        strKey_Ph += "AND SUBSTRING(Create_Log,15,LEN(Create_Log)) IN (" + strUser + ")";
                        strKey_Ct += " AND Stt IN (SELECT Stt FROM " + strTable_Ph + " WHERE SUBSTRING(Create_Log,15,LEN(Create_Log)) IN (" + strUser + "))";
                    }
                }
            }
            
            if (Common.Inlist(strMa_Ct_List, "BG,BGM,SO"))
                this.FillDataBG(strKey_Ph, strKey_Ct);
            else
                this.FillData(strKey_Ph, strKey_Ct);

            Element.sysNgay_Ct1 = Convert.ToDateTime(drFilter["Ngay_Ct1"]);
            Element.sysNgay_Ct2 = Convert.ToDateTime(drFilter["Ngay_Ct2"]);
        }

        public virtual bool Filter_ShowForm(DataRow drFilter)
        {
            frmFilter frm = new frmFilter();
            frm.Load(drFilter);

            return frm.isAccept;
        }

        private void Print(bool bPreview)
        {
            if (bdsViewPh.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;
            string strReport_File_First = string.Empty;

            if (drArrPrint.Length > 1)
            {
                for (int i = 0; i < drArrPrint.Length; i++)
                {
                    drCurrent = drArrPrint[i];

                    if (i == 0)
                    {
                        bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
                    }
                    else
                    {
                        if (bAcceptShowDialog)
                            bAcceptShowDialog = PrintVoucher.Print(drCurrent, bPreview, false, ref bInVisibleNextPrint, ref strReport_File_First);
                        else
                            break;
                    }

                    if (bAcceptShowDialog)
                    {
                        drCurrent["Mark"] = false;
                    }
                }
            }
            else
                PrintVoucher.Print(drCurrent, bPreview, true, ref bInVisibleNextPrint, ref strReport_File_First);
        }
        private void SetColor()
        {
            this.BackColor = Color.FromArgb(34, 32, 11, 43);
        }
        private void Design()
        {
            string strMa_Ct = strMa_Ct_List.Split(',')[0];

            DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);

            DataTable dtDmMauIn = DataTool.SQLGetDataTable("SYSDMMAUCT", "Ma_Mau, Ten_Mau", "Ma_Ct = '" + strMa_Ct + "'", "Stt, Ten_Mau");            
            string strReport_File = (string)dtDmMauIn.Rows[0]["Ma_Mau"];

            if (dtDmMauIn.Rows.Count > 1)
            {
                frmDesign_Mau_Ct frmDesign = new frmDesign_Mau_Ct();
                frmDesign.strMa_Ct = strMa_Ct;
                frmDesign.Is_Design = false;
                frmDesign.Load();
                strReport_File = frmDesign.strMa_Mau;

                if (frmDesign.Is_Design)
                {
                    Epoint.Reports.frmReportDesign frm = new Epoint.Reports.frmReportDesign();
                    frm.Load(strReport_File);
                }
            }
            else
            {
                Epoint.Reports.frmReportDesign frm = new Epoint.Reports.frmReportDesign();
                frm.Load(strReport_File);
            }
        }

        private void BindingTong_Tien()
        {
            numTTien0.DataBindings.Add("Value", bdsViewPh, "TTien0");
            numTTien_Nt0.DataBindings.Add("Value", bdsViewPh, "TTien_Nt0");

            numTTien3.DataBindings.Add("Value", bdsViewPh, "TTien3");
            numTTien_Nt3.DataBindings.Add("Value", bdsViewPh, "TTien_Nt3");

            numTSo_Luong.DataBindings.Add("Value", bdsViewPh, "TSo_Luong");

        }

        private void FormLayout()
        {
            dgvViewPh.Location = new Point(3, 3);
            dgvViewPh.Width = this.Width - 7;
            dgvViewPh.Height = (int)(0.5 * this.Height);

            dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
            dgvViewCt.Width = this.Width - 7;
            dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 20;

            dgvViewPh.ResizeGridView();
            dgvViewCt.ResizeGridView();
        }

        private void Mark()
        {
            if (bdsViewPh.Position < 0)
                return;

            //if (dgvViewPh.Columns[dgvViewPh.CurrentCell.ColumnIndex].Name != "LOCKED")
            //{
            //    if (dgvViewPh.Columns.Contains("Mark"))
            //    {
            //        drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            //        drCurrent["Mark"] = !(bool)drCurrent["Mark"];
            //        dgvViewPh.Refresh();
            //    }
            //}
        }

        private void DanhSoCt()
        {
            if (bdsViewPh.Count <= 0)
                return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            string strMa_Ct = (string)drCurrent["Ma_Ct"];
            int iThang = ((DateTime)drCurrent["Ngay_Ct"]).Month;
            string strFormat_Text = string.Empty;
            string strFix_Text = string.Empty;
            string strStt = string.Empty;
            string strSo_Ct = string.Empty;

            DataTable dtDmSoCt = DataTool.SQLGetDataTable("SYSDMSOCT", "", "Ma_Ct = '" + strMa_Ct + "' AND Loai_Ma_Ct = " + iThang.ToString().Trim(), "");

            if (dtDmSoCt != null && dtDmSoCt.Rows.Count > 0)
            {
                strFormat_Text = (string)dtDmSoCt.Rows[0]["Format_Text"];
                strFix_Text = (string)dtDmSoCt.Rows[0]["Fix_Text"];
            }

            frmDanhSo_Ct frm = new frmDanhSo_Ct();
            frm.txtFormat_Text.Text = strFormat_Text;
            frm.txtFix_Text.Text = strFix_Text;
            frm.Load();

            if (frm.isAccept)
            {
                int iSo_Ct = Convert.ToInt32(frm.numSo_Ct.Value);
                strFormat_Text = frm.txtFormat_Text.Text;
                strFix_Text = frm.txtFix_Text.Text;

                for (int i = 0; i < bdsViewPh.Count; i++)
                {
                    bdsViewPh.Position = i;

                    string strSo_Ct_New = iSo_Ct.ToString().PadLeft(strFormat_Text.Length, '0');
                    if (strFix_Text.Contains(","))
                        strSo_Ct_New = strFix_Text.Replace(",", strSo_Ct_New);
                    else
                        strSo_Ct_New = strFix_Text + strSo_Ct_New;

                    drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                    strStt = (string)drCurrent["Stt"];
                    strSo_Ct = (string)drCurrent["So_Ct"];

                    string strSQLExec =
                        "UPDATE GLVOUCHER SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE CATIEN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE APMUA SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE ARBAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE INNHAPXUAT SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE GLKETOAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "'" +
                        "UPDATE GLTHANHTOAN SET So_Ct = '" + strSo_Ct_New + "' WHERE Stt = '" + strStt + "' AND So_Ct = '" + strSo_Ct + "'";

                    if (SQLExec.Execute(strSQLExec))
                    {
                        drCurrent["So_Ct"] = strSo_Ct_New;
                    }

                    iSo_Ct++;
                }
            }
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////
        /// </summary>
        
        #region Import Excel chưng từ
        
        private string strKey_Ph, strKey_Ct;

        //Import Excel chưng từ
        /*
          case Keys.F10:
                    switch (e.Modifiers)
                    {
                        case Keys.None:
                            if (((e.KeyCode == Keys.F10) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
                            {
                                this.Cursor = Cursors.WaitCursor;
                                this.Import_Excel();
                                this.Cursor = Cursors.Default;
                            }
                            return;

                        case Keys.Control:
                            //this.Export_Excel();
                            break;
                    }
                    break;
         */

        private void ConvertFontImport(DataRow drConvert, string strColumnName)
        {
            if ((strColumnName != "strNew_Edit") && (drConvert[strColumnName].GetType().ToString() == "System.String"))
            {
                //string str2 = Parameters.GetParaValue("FONT_IMPORT").ToString().Trim();

                string strFontImport = "U";

                if (strFontImport != null)
                {
                    if (!(strFontImport == "T"))
                    {
                        if (strFontImport == "V")
                        {
                        }
                    }
                    else
                    {
                        drConvert[strColumnName] = ConvertFont.TCVN3ToUnicode(drConvert[strColumnName].ToString());
                    }
                }
            }
        }


        private void SetKeyFillter()
        {
            object objNgay_Ct = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + ((string)this.drDmCt["Table_Ph"]) + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(new char[] { ',' })[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");

            //object obj3 = null;
            //if (this.drDmCt.Table.Columns.Contains("Day_Filter"))
            //{
            //    obj3 = SQLExec.ExecuteReturnValue("SELECT Day_Filter FROM L00DMCT WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(new char[] { ',' })[0] + "' ");
            //}
            //string str = (obj3 == null) ? "" : obj3.ToString();

            //int days = (str == "") ? Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER")) : Convert.ToInt32(str);

            int days = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));
            DateTime dteNgay = (objNgay_Ct != DBNull.Value) ? ((DateTime)objNgay_Ct) : DateTime.Now;
            DateTime time2 = dteNgay.Subtract(new TimeSpan(days, 0, 0, 0));
            string str4 = string.Empty + "(Ma_Ct IN ('" + this.strMa_Ct_List.Replace(",", "','") + "'))";
            string str2 = str4 + " AND (Ngay_Ct BETWEEN  '" + Library.DateToStr(time2) + "' AND '" + Library.DateToStr(dteNgay) + "')";
            if ((bool)DataTool.SQLGetDataRowByID("SYSDMDVCS", "Ma_DvCs", Element.sysMa_DvCs)["Tong_Hop"])
            {
                str2 = str2 + " AND (Ma_DvCs IN (SELECT Ma_DvCs FROM SYSDMDVCS WHERE Tong_Hop = 0))";
            }
            else
            {
                str2 = str2 + " AND (Ma_DvCs = '" + Element.sysMa_DvCs + "')";
            }

            //object obj4 = SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID='CT_FILTER'").ToString();
            //string strExprList = (obj4 == null) ? "" : obj4.ToString();
            //if ((strExprList != "") && Common.Inlist(this.strMa_Ct_List, strExprList))
            //{
            //    this.strKey_Ph = Element.sysIs_Admin ? str2 : string.Concat(new object[] { str2, " AND (RIGHT( Create_Log,", Element.sysUser_Id.Length, ") = '", Element.sysUser_Id, "')" });
            //}
            //else
            //{
            //    this.strKey_Ph = str2;
            //}

            this.strKey_Ph = str2;
            this.strKey_Ct = str2;
        }
        
        public void Import_Excel()
        {
            bool bImport = true;

            //Path check window 64 bit
            string strPath_OS = @"C:\Windows\SysWow64";

            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xls",
                Filter = "*.xls|*.xls|*.xlsx|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if(Directory.Exists(strPath_OS)) //Window 64 bit
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;\r\n\t\t\t\t\t\tData Source= " + dialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES\""))
                    {
                        connection.Open();
                        string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Ct IS NOT NULL  AND Ma_Ct = '" + this.strMa_Ct_List + "'";

                        //if (((string)Parameters.GetParaValue("IMPORTVOUCHER_OPTION")) == "1")
                        //{
                        //    selectCommandText = selectCommandText + " AND Ma_Ct = '" + this.strMa_Ct_List + "'";
                        //}
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DataRow row = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct_List);
                            string strTableName = (string)row["Table_Ct"];
                            string strTable_Ph = (string)row["Table_Ph"];
                            string strSp_UpdatePh = (string)row["Sp_UpdatePh"];
                            string strSp_UpdateCt = (string)row["Sp_UpdateCt"];
                            DataTable table2 = DataTool.SQLGetDataTable(strTable_Ph, "TOP 0 * ", " 0 = 1", null);
                            DataTable table3 = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                            DataTable table4 = DataTool.SQLGetDataTable(strTableName, "TOP 0 Ma_Ct, Ngay_Ct, So_Ct ", " 0 = 1", null);
                            DataTable table5 = table3.Clone();
                            table5.Merge(dataTable, true, MissingSchemaAction.Ignore);
                            foreach (DataRow row2 in table5.Rows)
                            {
                                DataRow dr = row2;
                                Common.SetDefaultDataRow(ref dr);
                                if (table5.Columns.Contains("Tien_Nt2"))
                                {
                                    dr["Tien_Nt9"] = dr["Tien_Nt2"];
                                }
                                else if (table5.Columns.Contains("Tien_Nt"))
                                {
                                    dr["Tien_Nt9"] = dr["Tien_Nt"];
                                }
                                if (table5.Columns.Contains("So_Luong") && table5.Columns.Contains("So_Luong9"))
                                {
                                    dr["So_Luong9"] = dr["So_Luong"];
                                }
                                if (table5.Columns.Contains("Gia_Nt") && table5.Columns.Contains("Gia_Nt9"))
                                {
                                    dr["Gia_Nt9"] = dr["Gia_Nt"];
                                }
                                if (table5.Columns.Contains("Gia_Nt2"))//Gia_Nt2 chi co trong ARBAN
                                {
                                    dr["Gia_Nt9"] = dr["Gia_Nt2"];
                                }                                
                                if (table5.Columns.Contains("So_Ct") && (dr["So_Ct"] == DBNull.Value))
                                {
                                    dr["So_Ct"] = string.Empty;
                                }
                                if (dataTable.Columns.Contains("Ma_Quyen"))
                                {
                                    dr["Ma_Quyen"] = dataTable.Rows[0]["Ma_Quyen"].ToString();
                                }

                                //Update Dia_Chi, Ong_Ba, Ten_DtGtGt
                                if (table5.Columns.Contains("Dia_Chi") && (dr["Dia_Chi"] == ""))
                                {
                                    dr["Dia_Chi"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Dia_Chi FROM LIDOITUONG WHERE Ma_Dt = '" + dr["Ma_Dt"] + "'");
                                }
                                if (table5.Columns.Contains("Ong_Ba") && (dr["Ong_Ba"] == ""))
                                {
                                    dr["Ong_Ba"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Ong_Ba FROM LIDOITUONG WHERE Ma_Dt = '" + dr["Ma_Dt"] + "'");
                                }
                                if (table5.Columns.Contains("Ten_DtGtGt") && (dr["Ten_DtGtGt"] == ""))
                                {
                                    dr["Ten_DtGtGt"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Ten_Dt FROM LIDOITUONG WHERE Ma_So_Thue = '" + dr["Ma_So_Thue"] + "'");
                                }
                                if (table5.Columns.Contains("Thue_GtGt"))
                                {
                                    if (dr["Ma_Thue"] != "")
                                        dr["Thue_GtGt"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Thue_Suat,'') FROM LITHUE WHERE Ma_Thue = '" + dr["Ma_Thue"] + "'");
                                    else
                                        dr["Thue_GtGt"] = 0;
                                }
                            }
                            foreach (DataRow row3 in table5.Rows)
                            {
                                if (!Common.CheckDataLocked(Library.StrToDate(row3["Ngay_Ct"].ToString()))) //Dữ liệu bị khóa, không được import
                                {
                                    bImport = false; //Qua trinh import khong duoc tiep tuc
                                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa. Các chứng từ có ngày nằm trong khoảng thời gian bị khóa sẽ không được import !" : "Data have been locked. Vouchers have days in the time locked will not be imported !";
                                    Common.MsgCancel(strMsg);
                                    //break;
                                    continue;
                                }

                                else
                                {
                                    if (table4.Select(string.Concat(new object[] { "Ma_Ct = '", row3["Ma_Ct"], "' AND Ngay_Ct = '", row3["Ngay_Ct"], "' AND So_Ct = '", row3["So_Ct"], "'" })).Length == 0)
                                    {
                                        DataRow row4 = table4.NewRow();
                                        row4["Ma_Ct"] = row3["Ma_Ct"];
                                        row4["Ngay_Ct"] = row3["Ngay_Ct"];
                                        row4["So_Ct"] = row3["So_Ct"];
                                        table4.Rows.Add(row4);
                                    }
                                }
                            }
                            foreach (DataRow row4 in table4.Rows)
                            {
                                string str11;
                                Exception exception;
                                DataRow[] drArr = table5.Select(string.Concat(new object[] { "Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", row4["Ngay_Ct"], "' AND So_Ct = '", row4["So_Ct"], "'" }));
                                DataRow row5 = table2.NewRow();
                                Common.SetDefaultDataRow(ref row5);
                                Common.CopyDataRow(drArr[0], row5);
                                if (row5.Table.Columns.Contains("Duyet"))
                                {
                                    row5["Duyet"] = row["Default_Duyet"];
                                }
                                if (row5.Table.Columns.Contains("Is_Thue_Vat"))
                                {
                                    foreach (DataRow drThue in dataTable.Rows)
                                    {
                                        if (drThue["So_Ct"] == row4["So_Ct"] && drThue.Table.Columns.Contains("Is_Thue_Vat"))
                                            row5["Is_Thue_Vat"] = drThue["Is_Thue_Vat"];
                                    }
                                }
                                if (row5.Table.Columns.Contains("Create_Log"))
                                {
                                    row5["Create_Log"] = (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) +
                                                            (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) +
                                                            DateTime.Now.Year.ToString().Substring(2, 2) + ":" +
                                                            (DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) +
                                                            (DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) +
                                                            "00:" + Element.sysUser_Id;
                                }
                                if (table5.Columns.Contains("So_Luong") && table2.Columns.Contains("TSo_Luong"))
                                {
                                    row5["TSo_Luong"] = Common.SumDCValue(drArr, "So_Luong");
                                }
                                if (table5.Columns.Contains("Tien"))
                                {
                                    row5["TTien0"] = Common.SumDCValue(drArr, "Tien");
                                }
                                if (table5.Columns.Contains("Tien_Nt"))
                                {
                                    row5["TTien_Nt0"] = Common.SumDCValue(drArr, "Tien_Nt");
                                }
                                if (table5.Columns.Contains("Tien2"))
                                {
                                    row5["TTien0"] = Common.SumDCValue(drArr, "Tien2");
                                }
                                if (table5.Columns.Contains("Tien_Nt2"))
                                {
                                    row5["TTien_Nt0"] = Common.SumDCValue(drArr, "Tien_Nt2");
                                }
                                if (table5.Columns.Contains("Tien3"))
                                {
                                    row5["TTien3"] = Common.SumDCValue(drArr, "Tien3");
                                }
                                if (table5.Columns.Contains("Tien_Nt3"))
                                {
                                    row5["TTien_Nt3"] = Common.SumDCValue(drArr, "Tien_Nt3");
                                }
                                if (table5.Columns.Contains("Tien4"))
                                {
                                    row5["TTien4"] = Common.SumDCValue(drArr, "Tien4");
                                }
                                if (table5.Columns.Contains("Tien_Nt4"))
                                {
                                    row5["TTien_Nt4"] = Common.SumDCValue(drArr, "Tien_Nt4");
                                }
                                if (table5.Columns.Contains("Tien5"))
                                {
                                    row5["TTien5"] = Common.SumDCValue(drArr, "Tien5");
                                }
                                if (table5.Columns.Contains("Tien_Nt5"))
                                {
                                    row5["TTien_Nt5"] = Common.SumDCValue(drArr, "Tien_Nt5");
                                }
                                if (table5.Columns.Contains("Tien6"))
                                {
                                    row5["TTien6"] = Common.SumDCValue(drArr, "Tien6");
                                }
                                if (table5.Columns.Contains("Tien_Nt6"))
                                {
                                    row5["TTien_Nt6"] = Common.SumDCValue(drArr, "Tien_Nt6");
                                }                                

                                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                                SqlTransaction transaction = command.Connection.BeginTransaction("Update_Voucher_Tran");
                                command.Transaction = transaction;
                                string strModule = string.Empty;
                                switch (strTableName)
                                {
                                    case "CATIEN":
                                        strModule = "01";
                                        break;

                                    case "APMUA":
                                    case "APPO":
                                        strModule = "02";
                                        break;

                                    case "ARBAN":
                                    case "ARSO":
                                        strModule = "04";
                                        break;

                                    case "INNHAPXUAT":
                                        strModule = "05";
                                        break;

                                    case "GLKETOAN":
                                        strModule = "80";
                                        break;
                                }
                                string newStt = Common.GetNewStt(strModule, true);
                                while (DataTool.SQLCheckExist(strTable_Ph, "Stt", newStt))
                                {
                                    newStt = Common.GetNewStt(strModule, true);
                                }
                                SQLExec.Execute(string.Concat(new object[] { 
                                                                            "DELETE FROM ", strTableName, " WHERE Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", Library.DateToStr((DateTime) row4["Ngay_Ct"]), "' AND So_Ct = '", row4["So_Ct"], "' AND Ma_DvCs = '", Element.sysMa_DvCs, "';\r\n\t\t\t\t\t\t\t\t\t\t\t DELETE FROM ", strTable_Ph, " WHERE Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", Library.DateToStr((DateTime) row4["Ngay_Ct"]), 
                                                                            "' AND So_Ct = '", row4["So_Ct"], "' AND Ma_DvCs = '", Element.sysMa_DvCs, "'"
                                                                         }));
                                if (row5 != null)
                                {
                                    command.CommandText = strSp_UpdatePh;
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    string str10 = "Object_id = Object_id('" + strSp_UpdatePh + "')";
                                    DataTable table6 = DataTool.SQLGetDataTable("Sys.Parameters", "Name", str10, null);
                                    command.Parameters.AddWithValue("@strNew_Edit", 'N');
                                    Common.SetDefaultDataRow(ref row5);
                                    row5["Stt"] = newStt;
                                    foreach (DataRow row6 in table6.Rows)
                                    {
                                        str11 = ((string)row6["Name"]).Replace("@", "");
                                        this.ConvertFontImport(row5, str11);
                                        if (row5.Table.Columns.Contains(str11))
                                        {
                                            command.Parameters.AddWithValue("@" + str11, row5[str11]);
                                        }
                                    }
                                    try
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception exception1)
                                    {
                                        exception = exception1;
                                        MessageBox.Show("Có lỗi xảy ra :" + exception.Message);
                                        transaction.Rollback();
                                    }
                                }
                                command.Parameters.Clear();
                                command.CommandText = strSp_UpdateCt;
                                command.CommandType = CommandType.StoredProcedure;
                                string strKey = "Object_id = Object_id('" + strSp_UpdateCt + "')";
                                DataTable table7 = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);
                                int num = 1;
                                foreach (DataRow row7 in drArr)
                                {
                                    command.Parameters.Clear();
                                    DataRow row8 = row7;
                                    Common.SetDefaultDataRow(ref row8);
                                    row8["Stt"] = newStt;
                                    row8["Stt0"] = ++num;
                                    if (row8.Table.Columns.Contains("Duyet"))
                                    {
                                        row8["Duyet"] = row["Default_Duyet"];
                                    }
                                    foreach (DataRow row6 in table7.Rows)
                                    {
                                        str11 = ((string)row6["Name"]).Replace("@", "");
                                        this.ConvertFontImport(row8, str11);
                                        if (row8.Table.Columns.Contains(str11))
                                        {
                                            command.Parameters.AddWithValue("@" + str11, row8[str11]);
                                        }
                                    }
                                    try
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception exception2)
                                    {
                                        exception = exception2;
                                        MessageBox.Show("Có lỗi xảy ra trong quá trình import  :" + exception.Message);
                                        command.Transaction.Rollback();
                                    }
                                }
                                transaction.Commit();
                            }
                        }                    
                    }
                    this.SetKeyFillter();
                    this.FillData(this.strKey_Ph, this.strKey_Ct);
                    if (bImport)
                        Common.MsgOk(Languages.GetLanguage("End_Process"));
                }
                else //Window 32bit
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;\r\n\t\t\t\t\t\tData Source= " + dialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES\""))
                    {
                        connection.Open();
                        string selectCommandText = "SELECT * FROM [Sheet1$] Where Ma_Ct IS NOT NULL  AND Ma_Ct = '" + this.strMa_Ct_List + "'";

                        //if (((string)Parameters.GetParaValue("IMPORTVOUCHER_OPTION")) == "1")
                        //{
                        //    selectCommandText = selectCommandText + " AND Ma_Ct = '" + this.strMa_Ct_List + "'";
                        //}
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DataRow row = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", this.strMa_Ct_List);
                            string strTableName = (string)row["Table_Ct"];
                            string strTable_Ph = (string)row["Table_Ph"];
                            string strSp_UpdatePh = (string)row["Sp_UpdatePh"];
                            string strSp_UpdateCt = (string)row["Sp_UpdateCt"];
                            DataTable table2 = DataTool.SQLGetDataTable(strTable_Ph, "TOP 0 * ", " 0 = 1", null);
                            DataTable table3 = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                            DataTable table4 = DataTool.SQLGetDataTable(strTableName, "TOP 0 Ma_Ct, Ngay_Ct, So_Ct ", " 0 = 1", null);
                            DataTable table5 = table3.Clone();
                            table5.Merge(dataTable, true, MissingSchemaAction.Ignore);
                            foreach (DataRow row2 in table5.Rows)
                            {
                                DataRow dr = row2;
                                Common.SetDefaultDataRow(ref dr);
                                if (table5.Columns.Contains("Tien_Nt2"))
                                {
                                    dr["Tien_Nt9"] = dr["Tien_Nt2"];
                                }
                                else if (table5.Columns.Contains("Tien_Nt"))
                                {
                                    dr["Tien_Nt9"] = dr["Tien_Nt"];
                                }
                                if (table5.Columns.Contains("So_Luong") && table5.Columns.Contains("So_Luong9"))
                                {
                                    dr["So_Luong9"] = dr["So_Luong"];
                                }
                                if (table5.Columns.Contains("Gia_Nt") && table5.Columns.Contains("Gia_Nt9"))
                                {
                                    dr["Gia_Nt9"] = dr["Gia_Nt"];
                                }
                                if (table5.Columns.Contains("Gia_Nt2"))//Gia_Nt2 chi co trong ARBAN
                                {
                                    dr["Gia_Nt9"] = dr["Gia_Nt2"];
                                }                                
                                if (table5.Columns.Contains("So_Ct") && (dr["So_Ct"] == DBNull.Value))
                                {
                                    dr["So_Ct"] = string.Empty;
                                }
                                if (dataTable.Columns.Contains("Ma_Quyen"))
                                {
                                    dr["Ma_Quyen"] = dataTable.Rows[0]["Ma_Quyen"].ToString();
                                }

                                //Update Dia_Chi, Ong_Ba, Ten_DtGtGt
                                if (table5.Columns.Contains("Dia_Chi") && (dr["Dia_Chi"] == ""))
                                {
                                    dr["Dia_Chi"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Dia_Chi FROM LIDOITUONG WHERE Ma_Dt = '" + dr["Ma_Dt"] + "'");
                                }
                                if (table5.Columns.Contains("Ong_Ba") && (dr["Ong_Ba"] == ""))
                                {
                                    dr["Ong_Ba"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Ong_Ba FROM LIDOITUONG WHERE Ma_Dt = '" + dr["Ma_Dt"] + "'");
                                }
                                if (table5.Columns.Contains("Ten_DtGtGt") && (dr["Ten_DtGtGt"] == ""))
                                {
                                    dr["Ten_DtGtGt"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 Ten_Dt FROM LIDOITUONG WHERE Ma_So_Thue = '" + dr["Ma_So_Thue"] + "'");
                                }
                                if (table5.Columns.Contains("Thue_GtGt"))
                                {
                                    if (dr["Ma_Thue"] != "")
                                        dr["Thue_GtGt"] = SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Thue_Suat,'') FROM LITHUE WHERE Ma_Thue = '" + dr["Ma_Thue"] + "'");
                                    else
                                        dr["Thue_GtGt"] = 0;
                                }
                            }
                            foreach (DataRow row3 in table5.Rows)
                            {
                                if (!Common.CheckDataLocked(Library.StrToDate(row3["Ngay_Ct"].ToString()))) //Dữ liệu bị khóa, không được import
                                {
                                    bImport = false; //Qua trinh import khong duoc tiep tuc
                                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa. Các chứng từ có ngày nằm trong khoảng thời gian bị khóa sẽ không được import !" : "Data have been locked. Vouchers have days in the time locked will not be imported !";
                                    Common.MsgCancel(strMsg);
                                    //break;
                                    continue;
                                }

                                else
                                {
                                    if (table4.Select(string.Concat(new object[] { "Ma_Ct = '", row3["Ma_Ct"], "' AND Ngay_Ct = '", row3["Ngay_Ct"], "' AND So_Ct = '", row3["So_Ct"], "'" })).Length == 0)
                                    {
                                        DataRow row4 = table4.NewRow();
                                        row4["Ma_Ct"] = row3["Ma_Ct"];
                                        row4["Ngay_Ct"] = row3["Ngay_Ct"];
                                        row4["So_Ct"] = row3["So_Ct"];
                                        table4.Rows.Add(row4);
                                    }
                                }
                            }
                            foreach (DataRow row4 in table4.Rows)
                            {
                                string str11;
                                Exception exception;
                                DataRow[] drArr = table5.Select(string.Concat(new object[] { "Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", row4["Ngay_Ct"], "' AND So_Ct = '", row4["So_Ct"], "'" }));
                                DataRow row5 = table2.NewRow();
                                Common.SetDefaultDataRow(ref row5);
                                Common.CopyDataRow(drArr[0], row5);
                                if (row5.Table.Columns.Contains("Duyet"))
                                {
                                    row5["Duyet"] = row["Default_Duyet"];
                                }
                                if (row5.Table.Columns.Contains("Is_Thue_Vat"))
                                {
                                    foreach (DataRow drThue in dataTable.Rows)
                                    {
                                        if (drThue["So_Ct"] == row4["So_Ct"] && drThue.Table.Columns.Contains("Is_Thue_Vat"))
                                            row5["Is_Thue_Vat"] = drThue["Is_Thue_Vat"];
                                    }
                                }
                                if (row5.Table.Columns.Contains("Create_Log"))
                                {
                                    row5["Create_Log"] = (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) +
                                                            (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) +
                                                            DateTime.Now.Year.ToString().Substring(2, 2) + ":" +
                                                            (DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) +
                                                            (DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) +
                                                            "00:" + Element.sysUser_Id;
                                }
                                if (table5.Columns.Contains("So_Luong") && table2.Columns.Contains("TSo_Luong"))
                                {
                                    row5["TSo_Luong"] = Common.SumDCValue(drArr, "So_Luong");
                                }
                                if (table5.Columns.Contains("Tien"))
                                {
                                    row5["TTien0"] = Common.SumDCValue(drArr, "Tien");
                                }
                                if (table5.Columns.Contains("Tien_Nt"))
                                {
                                    row5["TTien_Nt0"] = Common.SumDCValue(drArr, "Tien_Nt");
                                }
                                if (table5.Columns.Contains("Tien2"))
                                {
                                    row5["TTien0"] = Common.SumDCValue(drArr, "Tien2");
                                }
                                if (table5.Columns.Contains("Tien_Nt2"))
                                {
                                    row5["TTien_Nt0"] = Common.SumDCValue(drArr, "Tien_Nt2");
                                }
                                if (table5.Columns.Contains("Tien3"))
                                {
                                    row5["TTien3"] = Common.SumDCValue(drArr, "Tien3");
                                }
                                if (table5.Columns.Contains("Tien_Nt3"))
                                {
                                    row5["TTien_Nt3"] = Common.SumDCValue(drArr, "Tien_Nt3");
                                }
                                if (table5.Columns.Contains("Tien4"))
                                {
                                    row5["TTien4"] = Common.SumDCValue(drArr, "Tien4");
                                }
                                if (table5.Columns.Contains("Tien_Nt4"))
                                {
                                    row5["TTien_Nt4"] = Common.SumDCValue(drArr, "Tien_Nt4");
                                }
                                if (table5.Columns.Contains("Tien5"))
                                {
                                    row5["TTien5"] = Common.SumDCValue(drArr, "Tien5");
                                }
                                if (table5.Columns.Contains("Tien_Nt5"))
                                {
                                    row5["TTien_Nt5"] = Common.SumDCValue(drArr, "Tien_Nt5");
                                }
                                if (table5.Columns.Contains("Tien6"))
                                {
                                    row5["TTien6"] = Common.SumDCValue(drArr, "Tien6");
                                }
                                if (table5.Columns.Contains("Tien_Nt6"))
                                {
                                    row5["TTien_Nt6"] = Common.SumDCValue(drArr, "Tien_Nt6");
                                }

                                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                                SqlTransaction transaction = command.Connection.BeginTransaction("Update_Voucher_Tran");
                                command.Transaction = transaction;
                                string strModule = string.Empty;
                                switch (strTableName)
                                {
                                    case "CATIEN":
                                        strModule = "01";
                                        break;

                                    case "APMUA":
                                    case "APPO":
                                        strModule = "02";
                                        break;

                                    case "ARBAN":
                                    case "ARSO":
                                        strModule = "04";
                                        break;

                                    case "INNHAPXUAT":
                                        strModule = "05";
                                        break;

                                    case "GLKETOAN":
                                        strModule = "80";
                                        break;
                                }
                                string newStt = Common.GetNewStt(strModule, true);
                                while (DataTool.SQLCheckExist(strTable_Ph, "Stt", newStt))
                                {
                                    newStt = Common.GetNewStt(strModule, true);
                                }
                                SQLExec.Execute(string.Concat(new object[] { 
                                                                        "DELETE FROM ", strTableName, " WHERE Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", Library.DateToStr((DateTime) row4["Ngay_Ct"]), "' AND So_Ct = '", row4["So_Ct"], "' AND Ma_DvCs = '", Element.sysMa_DvCs, "';\r\n\t\t\t\t\t\t\t\t\t\t\t DELETE FROM ", strTable_Ph, " WHERE Ma_Ct = '", row4["Ma_Ct"], "' AND Ngay_Ct = '", Library.DateToStr((DateTime) row4["Ngay_Ct"]), 
                                                                        "' AND So_Ct = '", row4["So_Ct"], "' AND Ma_DvCs = '", Element.sysMa_DvCs, "'"
                                                                     }));
                                if (row5 != null)
                                {
                                    command.CommandText = strSp_UpdatePh;
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Clear();
                                    string str10 = "Object_id = Object_id('" + strSp_UpdatePh + "')";
                                    DataTable table6 = DataTool.SQLGetDataTable("Sys.Parameters", "Name", str10, null);
                                    command.Parameters.AddWithValue("@strNew_Edit", 'N');
                                    Common.SetDefaultDataRow(ref row5);
                                    row5["Stt"] = newStt;
                                    foreach (DataRow row6 in table6.Rows)
                                    {
                                        str11 = ((string)row6["Name"]).Replace("@", "");
                                        this.ConvertFontImport(row5, str11);
                                        if (row5.Table.Columns.Contains(str11))
                                        {
                                            command.Parameters.AddWithValue("@" + str11, row5[str11]);
                                        }
                                    }
                                    try
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception exception1)
                                    {
                                        exception = exception1;
                                        MessageBox.Show("Có lỗi xảy ra :" + exception.Message);
                                        transaction.Rollback();
                                    }
                                }
                                command.Parameters.Clear();
                                command.CommandText = strSp_UpdateCt;
                                command.CommandType = CommandType.StoredProcedure;
                                string strKey = "Object_id = Object_id('" + strSp_UpdateCt + "')";
                                DataTable table7 = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);
                                int num = 1;
                                foreach (DataRow row7 in drArr)
                                {
                                    command.Parameters.Clear();
                                    DataRow row8 = row7;
                                    Common.SetDefaultDataRow(ref row8);
                                    row8["Stt"] = newStt;
                                    row8["Stt0"] = ++num;
                                    if (row8.Table.Columns.Contains("Duyet"))
                                    {
                                        row8["Duyet"] = row["Default_Duyet"];
                                    }
                                    foreach (DataRow row6 in table7.Rows)
                                    {
                                        str11 = ((string)row6["Name"]).Replace("@", "");
                                        this.ConvertFontImport(row8, str11);
                                        if (row8.Table.Columns.Contains(str11))
                                        {
                                            command.Parameters.AddWithValue("@" + str11, row8[str11]);
                                        }
                                    }
                                    try
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception exception2)
                                    {
                                        exception = exception2;
                                        MessageBox.Show("Có lỗi xảy ra trong quá trình import  :" + exception.Message);
                                        command.Transaction.Rollback();
                                    }
                                }
                                transaction.Commit();
                            }
                        }
                    }
                    this.SetKeyFillter();
                    this.FillData(this.strKey_Ph, this.strKey_Ct);
                    if (bImport)
                        Common.MsgOk(Languages.GetLanguage("End_Process"));
                }
            }
        }


        #endregion

        /// <summary>
        /// //////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion

        #region Event

        void frmViewPh_Resize(object sender, EventArgs e)
        {
            this.FormLayout();
        }

        void KeyDownEvent(object sender, KeyEventArgs e)
        {

            string strColumnName = dgvViewPh.dgvGridView.FocusedColumn.Name;
            switch (e.KeyCode)
            {
                case Keys.F9:
                    this.Filter();
                    break;

                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            Design();
                            break;

                        case Keys.Control:
                            Print(true);
                            break;

                        case Keys.None:
                            Print(false);
                            break;
                    }
                    break;

                case Keys.Space:
                    Mark();

                    break;

                case Keys.A:
                    if (strColumnName == "MARK")
                        if (e.Modifiers == Keys.Control)
                        {
                            for (int i = 0; i < dgvViewPh.dgvGridView.RowCount; i++)
                            {
                                dgvViewPh.dgvGridView.SetRowCellValue(i, "MARK", true);
                            }

                            dgvViewPh.Refresh();
                        }

                    break;

                case Keys.U:
                    if (strColumnName == "MARK")
                        if (e.Modifiers == Keys.Control)
                        {
                            for (int i = 0; i < dgvViewPh.dgvGridView.RowCount; i++)
                            {
                                dgvViewPh.dgvGridView.SetRowCellValue(i, "MARK", false);
                            }

                            dgvViewPh.Refresh();
                        }

                    break;


                case Keys.F10:
                    switch (e.Modifiers)
                    {
                        case Keys.None:
                            if (((e.KeyCode == Keys.F10) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
                            {
                                this.Cursor = Cursors.WaitCursor;
                                this.Import_Excel();
                                this.Cursor = Cursors.Default;
                            }
                            return;

                        case Keys.Control:
                            //this.Export_Excel();
                            break;
                    }
                    break;

            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Shift)
            {
                this.DanhSoCt();
                return;
            }
            else

                base.OnKeyDown(e);
        }

        void bdsViewPh_PositionChanged(object sender, EventArgs e)
        {
            if (bdsViewPh.Position < 0)
                return;

            //lblRecordNo.Text = (bdsViewPh.Position + 1).ToString() + "/" + bdsViewPh.Count.ToString();

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = (string)drCurrent["Stt"];

            bdsViewCt.Filter = "(Stt = '" + strStt + "')";
        }

        void btBack_Click(object sender, EventArgs e)
        {
            if (Common.Inlist(strMa_Ct_List, "BG,BGM,SO"))
                this.FillDataBG(strFilterKey_Old, strFilterKey_Old);
            else
                this.FillData(strFilterKey_Old, strFilterKey_Old);
        }

        void btImport_Click(object sender, EventArgs e)
        {
            if ((Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_New)) && Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Edit))
            {
                this.Cursor = Cursors.WaitCursor;
                this.Import_Excel();
                this.Cursor = Cursors.Default;
            }
            return;            
        }

        void btFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void btPreview_Click(object sender, EventArgs e)
        {
            this.Print(true);
        }

        void btPrint_Click(object sender, EventArgs e)
        {
            this.Print(false);
        }

        void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void dgvViewCt_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
        }

        void dgvViewPh_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
        }

       
        void dgvViewPh_CellFormatting(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (e.CellValue == null || e.CellValue == DBNull.Value)
                return;

            if (e.RowHandle < 0)
                return;


            //Cho phép format cell hoặc là không            
            if (Convert.ToString(Parameters.GetParaValue("IS_FORMATCELL")) == "1")
            {

                if ((GridColumn)gridView.Columns["MA_TTE"] != null && gridView.GetRowCellValue(e.RowHandle, "MA_TTE") != null)
                {

                    if ((string)gridView.GetRowCellValue(e.RowHandle, "MA_TTE") != string.Empty)
                    {
                        if ((string)gridView.GetRowCellValue(e.RowHandle, "MA_TTE") != Element.sysMa_Tte)
                            e.Appearance.ForeColor = Color.FromArgb(255, 49, 106, 197);

                    }

                }
            }
            if ((GridColumn)gridView.Columns["MARK"] != null && gridView.GetRowCellValue(e.RowHandle, "MARK") != null)
            {

                if ((bool)gridView.GetRowCellValue(e.RowHandle, "MARK") != true)
                    e.Appearance.ForeColor = Color.FromArgb(255, 0, 0, 255);



            }
            if ((GridColumn)gridView.Columns["MA_CT"] != null && gridView.GetRowCellValue(e.RowHandle, "MA_CT") != null)
            {
                if (Common.Inlist((string)gridView.GetRowCellValue(e.RowHandle, "MA_CT"), "BG,PO,SO,LSX"))
                    e.Appearance.ForeColor = Color.Red;

            }

            if ((GridColumn)gridView.Columns["DUYET"] != null)
            {
                if ((bool)gridView.GetRowCellValue(e.RowHandle, "DUYET") == false)
                    e.Appearance.ForeColor = Color.Red;
            }    

        }
        void dgvViewPh_CellMouseClick(object sender, EventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //    return;
            if (bdsViewPh.Position < 0)
                return; 
            string strColumnName = dgvViewPh.dgvGridView.FocusedColumn.Name;
            //string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            if (strColumnName == "DUYET")
            {
                if (Common.CheckPermission(base.Object_ID, enuPermission_Type.Allow_Duyet))
                {
                    frmDuyet frm = new frmDuyet();
                    frm.Load(drCurrent);
                }
                else
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn không được phân quyền duyệt chứng từ !" : "You are not allowed to check documents !";
                    Common.MsgCancel(strMsg);
                    return;
                }
            }
        }

        #endregion
    }
}
