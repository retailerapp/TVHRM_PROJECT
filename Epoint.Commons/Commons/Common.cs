using System.Drawing;
using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Microsoft.Win32;
using Microsoft.Office;
//using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using System.Net.Mail;
using System.ComponentModel;
using Aspose.Cells;

namespace Epoint.Systems.Commons
{
	public class Common
	{
		/// <summary>
		/// Tra ve stt moi nhat tu SYSPARA
		/// </summary>
		/// <param name="strModule"></param> Ma so cua Module hien hanh
		/// <param name="bSaveNew"></param> Luu vao CSDL stt hien hanh
		/// <returns></returns>
		public static string GetNewStt(string strModule, bool bSaveNew)
		{
			string strMa_Dvcs = Element.sysMa_DvCs.Trim().PadLeft(3, '0');

			strModule = strModule.Trim().PadLeft(2, '0');

			long iStt = Convert.ToInt64(Epoint.Systems.Librarys.Parameters.GetParaValue("Stt")) + 1;

			if (bSaveNew)
			{
				Epoint.Systems.Librarys.Parameters.SetParaValue("Stt", iStt);
			}

			string strStt = iStt.ToString().Trim().PadLeft(10, '0');

			return strMa_Dvcs + strModule + strStt;
		}

		public static void CopyDataColumn(DataTable dtSource, DataTable dtDest, string strColumnlist)
		{
			strColumnlist = strColumnlist.Replace(" ", "");
			string[] arrColumn = strColumnlist.Split(',');
			DataColumn dcCopy;

			foreach (string strColumnName in arrColumn)
			{
				if (!dtSource.Columns.Contains(strColumnName) || dtDest.Columns.Contains(strColumnName))
					continue;

				dcCopy = new DataColumn(strColumnName, dtSource.Columns[strColumnName].DataType);
				dtDest.Columns.Add(dcCopy);
			}
		}

		/// <summary>
		/// Copy nguyên cấu trúc và giá trị có DataRowVersion.Original;
		/// </summary>
		/// <param name="drSource"></param>
		/// <param name="drDest"></param>
		public static void CopyDataRow(DataRow drSource, ref DataRow drDest)
		{
			DataTable dtTemp = drSource.Table.Clone();
			dtTemp.ImportRow(drSource);
			drDest = dtTemp.Rows[0];

		}

		/// <summary>
		/// Copy giá trị, không có DataRowVersion.Original
		/// </summary>
		/// <param name="drSource"></param>
		/// <param name="drDest"></param>
		public static void CopyDataRow(DataRow drSource, DataRow drDest)
		{
			string strColumn = String.Empty;

			for (int i = 0; i <= drSource.Table.Columns.Count - 1; i++)
			{
				strColumn = drSource.Table.Columns[i].ColumnName;

				if (drDest.Table.Columns.Contains(strColumn))
				{
					if (!drDest.Table.Columns[strColumn].ReadOnly)
						drDest[strColumn] = drSource[strColumn];
				}
			}

			SetDefaultDataRow(ref drDest);
		}

		/// <summary>
		/// Copy giá trị, không có DataRowVersion.Original
		/// </summary>
		/// <param name="drSource"></param>
		/// <param name="drDest"></param>
		/// <param name="strColumnList">danh sach column</param>
		public static void CopyDataRow(DataRow drSource, DataRow drDest, string strColumnList)
		{
			strColumnList = strColumnList.Replace(" ", "");
			string[] strArrColumnName = strColumnList.Split(',');

			foreach (string strColumnName in strArrColumnName)
			{
				if (!drSource.Table.Columns.Contains(strColumnName) || !drDest.Table.Columns.Contains(strColumnName))
					continue;

				drDest[strColumnName] = drSource[strColumnName];
			}

			SetDefaultDataRow(ref drDest);
		}

		/// <summary>
		/// gán giá trị mặc định cho những cột null
		/// </summary>
		/// <param name="dr"></param>
		public static void SetDefaultDataRow(ref DataRow dr)
		{
			if (dr.Table.Columns.Contains("Ma_Data") && dr["Ma_Data"] == DBNull.Value)
				dr["Ma_Data"] = Element.sysMa_Data;

			if (dr.Table.Columns.Contains("Ma_DvCs") && (dr["Ma_DvCs"] == DBNull.Value || ((string)dr["Ma_DvCs"]).ToString().Trim() == string.Empty))
				dr["Ma_DvCs"] = Element.sysMa_DvCs;

			if (dr.Table.Columns.Contains("User_Crtd") && (dr["User_Crtd"] == DBNull.Value || ((string)dr["User_Crtd"]).ToString().Trim() == string.Empty))
				dr["User_Crtd"] = Element.sysUser_Id;

			if (dr.Table.Columns.Contains("User_Edit"))
				dr["User_Edit"] = Element.sysUser_Id;

			if (dr.Table.Columns.Contains("Ngay_Crtd") && (dr["Ngay_Crtd"] == DBNull.Value || ((DateTime)dr["Ngay_Crtd"]) == Element.sysNgay_Min))
				dr["Ngay_Crtd"] = DateTime.Now;

			if (dr.Table.Columns.Contains("Ngay_Edit"))
				dr["Ngay_Edit"] = DateTime.Now;

			for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
			{
				//Nếu là có giá trị rồi thi không gán nữa
				if (dr[i] != DBNull.Value)
					continue;
				switch (dr.Table.Columns[i].DataType.ToString())
				{
					case "System.Boolean":
					case "System.Byte":
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Decimal":
					case "System.Double":
						dr[i] = 0;
						break;
					case "System.String":
						dr[i] = "";
						break;
					case "System.DateTime":
						dr[i] = Element.sysNgay_Min;
						break;
				}
			}
		}

		/// <summary>
		/// Trả về tổng các cột
		/// </summary>
		/// <param name="dtSum"></param>
		/// <param name="strColumnName"></param>
		/// <returns></returns>
		public static double SumDCValue(DataTable dtSum, string strColumnName, string strFilter)
		{
			double dbSum = 0;
			DataRow[] drArr;

			if (strFilter == string.Empty || strFilter == null)
				drArr = dtSum.Select();
			else
				drArr = dtSum.Select(strFilter);

			foreach (DataRow drSum in drArr)
			{
				if (drSum[strColumnName] == null || drSum[strColumnName] == DBNull.Value)
					continue;

				dbSum += Convert.ToDouble(drSum[strColumnName]);
			}
			return dbSum;
		}
		public static double SumDCValue(DataRow[] drArr, string strColumnName)
		{
			double num = 0.0;
			foreach (DataRow row in drArr)
			{
				if ((row[strColumnName] != null) && (row[strColumnName] != DBNull.Value))
				{
					num += Convert.ToDouble(row[strColumnName]);
				}
			}
			return num;
		}

		public static DataTable FilterDatatable(DataTable dt, string strFilter)
		{
			DataRow[] drArr;
			DataTable dtResult = dt.Clone();
			if (strFilter == string.Empty || strFilter == null)
				drArr = dt.Select();
			else
				drArr = dt.Select(strFilter);

			foreach (DataRow drSum in drArr)
			{
				dtResult.ImportRow(drSum);
			}
			return dtResult;
		}



		/// <summary>
		/// Trả về giá trị lớn nhất trong cột
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="strColumnName"></param>
		/// <returns></returns>
		public static double MaxDCValue(DataTable dt, string strColumnName)
		{

			double dbMax = 0;
			foreach (DataRow drMax in dt.Rows)
			{
				if (drMax[strColumnName] == null || drMax[strColumnName] == DBNull.Value)
					continue;

				dbMax = Math.Max(dbMax, Convert.ToDouble(drMax[strColumnName]));
			}
			return dbMax;
		}

		public static double MaxDCValue(DataRow[] drArr, string strColumnName)
		{
			int iPosition = MaxDCPosition(drArr, strColumnName);
			if (iPosition < 0)
				return 0;

			return Convert.ToDouble(drArr[iPosition][strColumnName]);
		}

		public static int MaxDCPosition(DataTable dt, string strColumnName)
		{
			double dbMax = Double.MinValue;
			int iRow = -1;
			for (int i = 0; i <= dt.Rows.Count - 1; i++)
			{
				DataRow dr = dt.Rows[i];

				if (dr[strColumnName] == null || dr[strColumnName] == DBNull.Value)
					continue;

				if (dbMax < Convert.ToDouble(dr[strColumnName]))
				{
					dbMax = Convert.ToDouble(dr[strColumnName]);
					iRow = i;
				}
			}
			return iRow;
		}

		public static int MaxDCPosition(DataTable dt, string strColumnName, string strFilter)
		{
			double dbMax = Double.MinValue;
			int iRow = 0;

			DataRow[] drArr;

			if (strFilter == string.Empty || strFilter == null)
				drArr = dt.Select();
			else
				drArr = dt.Select(strFilter);

			for (int i = 0; i <= drArr.Length - 1; i++)
			{
				DataRow dr = drArr[i];

				if (dr[strColumnName] == null || dr[strColumnName] == DBNull.Value)
					continue;

				if (dbMax < Convert.ToDouble(dr[strColumnName]))
				{
					dbMax = Convert.ToDouble(dr[strColumnName]);
					iRow = i;
				}
			}
			return iRow;
		}

		public static int MaxDCPosition(DataRow[] drArr, string strColumnName)
		{
			double dbMax = Double.MinValue;
			int iRow = -1;

			for (int i = 0; i <= drArr.Length - 1; i++)
			{
				DataRow dr = drArr[i];

				if (dr[strColumnName] == null || dr[strColumnName] == DBNull.Value)
					continue;

				if (dbMax < Convert.ToDouble(dr[strColumnName]))
				{
					dbMax = Convert.ToDouble(dr[strColumnName]);
					iRow = i;
				}
			}
			return iRow;
		}

		/// <summary>
		/// Ham kiem tra chuoi strExpr co nam trong danh sach chuoi strExprList
		/// </summary>
		/// <param name="strExpr"></param>
		/// <param name="strExprList"></param>
		/// <returns></returns>
		public static bool Inlist(string strExpr, string strExprList)
		{
			string[] arrStr = strExprList.Split(',');
			for (int i = 0; i <= arrStr.Length - 1; i++)
			{
				if (strExpr == arrStr[i].Trim())
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Ham kiem tra chuoi strExpr co nam trong danh sach chuoi strExprList, so sanh bang tuong doi
		/// </summary>
		/// <param name="strExpr"></param>
		/// <param name="strExprList"></param>
		/// <returns></returns>
		public static bool InlistLike(string strExpr, string strExprList)
		{
			string[] arrStr = strExprList.Split(',');
			for (int i = 0; i <= arrStr.Length - 1; i++)
			{
				if (strExpr.StartsWith(arrStr[i].Trim()))
				{
					return true;
				}
			}
			return false;
		}

		public static void ResetTextChange(Control ctr)
		{

			if (ctr.GetType() == typeof(txtTextBox))
			{

				//ctrl.Location.
				txtTextBox t = (txtTextBox)ctr;
				t.bTextChange = false;
			}
			//if (ctr.GetType() == typeof(txtTextLookup))
			//{

			//    //ctrl.Location.
			//    txtTextLookup t = (txtTextLookup)ctr;
			//    t.bTextChange = false;
			//}

			foreach (Control ctrl in ctr.Controls)
			{
				ResetTextChange(ctrl);
			}
		}
		/// <summary>
		/// Hàm copy dtRow sang cac bien( cac Control tren Form frm)
		/// </summary>
		/// <param name="frm"></param>
		/// <param name="dtRow"></param>
		public static void ScaterMemvar(Control ctrls, ref DataRow dtRow)
		{
			foreach (Control ctrl in ctrls.Controls)
			{
				//numUpDown HasChildren
				if (ctrl.GetType().Name == "NumericUpDown" || ctrl.GetType().Name == "numUpDown" || ctrl.GetType().Name == "dteDateTime")
				{
					Scatter(ctrl, ref dtRow);
					continue;
				}

				if (!ctrl.HasChildren)
					Scatter(ctrl, ref dtRow);
				else
					ScaterMemvar(ctrl, ref dtRow);
			}
		}

		public static void Scatter(Control ctrl, ref DataRow dtRow)
		{
			if (ctrl == null)
				return;

			string strCtrlName = ctrl.Name.ToLower();
			if (strCtrlName.Length < 3)// co nhung Control ma tu dong sinh ra trong Form, thi ten la rong
				return;

			string strColumnName = strCtrlName.Substring(3).ToUpper();

			if (!Inlist(strCtrlName.Substring(0, 3), "txt,chk,dte,num,cbo,cbx,enu,rdb"))
				return;

			if (!dtRow.Table.Columns.Contains(strColumnName))
				return;

			string strColumnType = dtRow[strColumnName].GetType().Name.ToString().ToLower();

			//Convert du lieu thanh textbox
			if (strCtrlName.StartsWith("txt"))
			{
				if (Inlist(strColumnType, "string"))
					ctrl.Text = ((string)dtRow[strColumnName]).Trim();
				else if (Inlist(strColumnType, "bit,byte,short,int,long,float,double,decimal"))
					ctrl.Text = dtRow[strColumnName].ToString();
				else if (Inlist(strColumnType, "datetime"))
					ctrl.Text = Library.DateToStr((DateTime)dtRow[strColumnName]);


			}
			//Convert du lieu thanh enum
			else if (strCtrlName.StartsWith("enu"))
			{
				if (Inlist(strColumnType, "string"))
					ctrl.Text = ((string)dtRow[strColumnName]).Trim();
				else if (Inlist(strColumnType, "bit,byte,short,int,long,float,double,decimal"))
					ctrl.Text = dtRow[strColumnName].ToString();
				else if (Inlist(strColumnType, "bool,boolean"))
					ctrl.Text = (bool)dtRow[strColumnName] == true ? "1" : "0";
			}

			//Convert du lieu thanh checkbox
			else if (strCtrlName.StartsWith("chk"))
			{
				if (Inlist(strColumnType, "bool,boolean"))
					((CheckBox)ctrl).Checked = (bool)dtRow[strColumnName];
			}

			//Convert du lieu thanh RadioButton
			else if (strCtrlName.StartsWith("rdb"))
			{
				if (Inlist(strColumnType, "bool,boolean"))
					((RadioButton)ctrl).Checked = (bool)dtRow[strColumnName];
			}

			//Convert du lieu thanh datetime
			else if (strCtrlName.StartsWith("dte"))
			{
				if (Inlist(strColumnType, "datetime"))
					ctrl.Text = Library.DateToStr((DateTime)dtRow[strColumnName]);
			}
			//Convert du lieu thanh numeric
			else if (strCtrlName.StartsWith("num"))
			{
				if (Inlist(strColumnType, "bit,byte,short,int,long,float,double,decimal,int16,int32,int64"))
				{
					if (ctrl.GetType().Name == "numControl")
						((numControl)ctrl).Value = dtRow[strColumnName] == DBNull.Value ? 0 : Convert.ToDouble(dtRow[strColumnName]);

					else if (ctrl.GetType().Name == "NumericUpDown" || ctrl.GetType().Name == "numUpDown")
						((NumericUpDown)ctrl).Value = dtRow[strColumnName] == DBNull.Value ? 0 : Convert.ToDecimal(dtRow[strColumnName]);
				}
			}
			//Convert du lieu ComboBox
			else if (strCtrlName.StartsWith("cbo") && dtRow[strColumnName] != DBNull.Value)
			{
				((ComboBox)ctrl).CreateControl();
				//((ComboBox)ctrl).SelectedValue = ((string)dtRow[strColumnName]).Trim();
				((ComboBox)ctrl).Text = ((string)dtRow[strColumnName]).Trim();
			}
			else if (strCtrlName.StartsWith("cbx") && dtRow[strColumnName] != DBNull.Value)
			{
				((ComboBox)ctrl).CreateControl();
				//((ComboBox)ctrl).SelectedValue = ((string)dtRow[strColumnName]).Trim();
				((ComboBox)ctrl).SelectedValue = ((string)dtRow[strColumnName]).Trim();
			}
		}

		/// <summary>
		/// Copy từ biến vào dtRow
		/// </summary>
		/// <param name="frm"></param>
		/// <param name="dtRow"></param>
		/// 
		public static void GatherMemvar(Control ctrls, ref DataRow dtRow)
		{
			foreach (Control ctrl in ctrls.Controls)
			{
				//numUpDown HasChildren
				if (ctrl.GetType().Name == "NumericUpDown" || ctrl.GetType().Name == "numUpDown" || ctrl.GetType().Name == "dteDateTime")
				{
					Gather(ctrl, ref dtRow);
					continue;
				}

				if (!ctrl.HasChildren)
					Gather(ctrl, ref dtRow);
				else
					GatherMemvar(ctrl, ref dtRow);
			}
		}

		public static void Gather(Control ctrl, ref DataRow dtRow)
		{
			if (ctrl == null)
				return;

			string strCtrlName = ctrl.Name.ToLower();
			if (strCtrlName.Length < 3)// co nhung Control ma tu dong sinh ra trong Form, thi ten la rong
				return;

			string strColumnName = strCtrlName.Substring(3).ToLower();

			if (!Inlist(strCtrlName.Substring(0, 3), "txt,chk,dte,num,cbo,cbx,enu,rdb"))
				return;

			if (!dtRow.Table.Columns.Contains(strColumnName))
				return;

			string strColumnType = dtRow.Table.Columns[strColumnName].DataType.Name.ToString().ToLower();

			//Convert du lieu tu form xuong datarow
			if (Inlist(strColumnType, "string"))
				if (strCtrlName.StartsWith("cbo"))//ComboBox
					dtRow[strColumnName] = ((ComboBox)ctrl).Text;
				else if (strCtrlName.StartsWith("cbx"))//ComboBox
					dtRow[strColumnName] = ((ComboBox)ctrl).SelectedValue;
				else
					dtRow[strColumnName] = ctrl.Text.Trim();

			else if (Inlist(strColumnType, "bit,byte,short,int,long,float,double,decimal,int16,int32,int64"))
			{
				if (ctrl.Text == "")
					dtRow[strColumnName] = 0;
				else
				{
					if (ctrl.GetType().Name == "numControl")
						dtRow[strColumnName] = ((numControl)ctrl).Value;
					else if (ctrl.GetType().Name == "NumericUpDown" || ctrl.GetType().Name == "numUpDown")
						dtRow[strColumnName] = ((NumericUpDown)ctrl).Value;
					else
						dtRow[strColumnName] = Convert.ToDouble(ctrl.Text);
				}
			}

			else if (Inlist(strColumnType, "datetime"))
				dtRow[ctrl.Name.Substring(3)] = Library.StrToDate(ctrl.Text);

			else if (Inlist(strColumnType, "bool,boolean"))
			{
				if (strCtrlName.StartsWith("chk"))
					dtRow[strColumnName] = ((CheckBox)ctrl).Checked;
				else if (strCtrlName.StartsWith("rdb"))
					dtRow[strColumnName] = ((RadioButton)ctrl).Checked;
				else if (strCtrlName.StartsWith("txt"))
					dtRow[strColumnName] = ctrl.Text == "1" ? true : false;
				else if (strCtrlName.StartsWith("enu"))
					dtRow[strColumnName] = ctrl.Text == "1" ? true : false;
			}
		}

		/// <summary>
		/// Tra ve chuoi Log(34) hien hanh : DDMMYY:HHMNSS:USER_ID(20)
		/// </summary>
		/// <returns></returns>
		public static string GetCurrent_Log()
		{
			string strCurrent_Log = string.Empty;
			DateTime dte = DateTime.Now;

			strCurrent_Log += dte.Day.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Month.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Year.ToString().Substring(2, 2);
			strCurrent_Log += ":";
			strCurrent_Log += dte.Hour.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Minute.ToString().PadLeft(2, '0');
			strCurrent_Log += dte.Second.ToString().PadLeft(2, '0');
			strCurrent_Log += ":";
			strCurrent_Log += Element.sysUser_Id;

			return strCurrent_Log;
		}

		public static string Show_Log(string strLog)
		{
			if (strLog.Length > 14)
			{
				return strLog.Substring(14) + ":" + strLog.Substring(0, 2) + "/" + strLog.Substring(2, 2) + "/" + strLog.Substring(4, 2) + ":" + strLog.Substring(7, 2) + "h" + strLog.Substring(9, 2) + "m" + strLog.Substring(11, 2) + "s";
			}
			else
				return strLog;
		}

		public static DateTime GetDate(int iYear, int iMonth, int iDay)
		{
			return DateTime.Parse(iDay + "/" + iMonth + "/" + iYear);
		}
		#region  Queue
		//Queue
		public static bool UpdateQueue(SqlCommand sqlCom, enuEdit enuNew_Edit, DataTable dtEditCt)
		{
			string strMa_Ct = ((string)dtEditCt.Rows[0]["Ma_Ct"]).Trim();
			string strStt = ((string)dtEditCt.Rows[0]["Stt"]).Trim();

			return UpdateQueue(sqlCom, strStt, strMa_Ct);
		}

		public static bool UpdateQueue(SqlCommand sqlCom, string strStt, string strMa_Ct)
		{
			if (strStt == string.Empty || strMa_Ct == string.Empty)
				return false;

			string strSQLExec = "SP_CT_UPDATE80 '" + strStt + "', '" + strMa_Ct + "'";

			if (Element.sysRun_Service)
				return SQLPushQueue(sqlCom, strSQLExec, strStt);
			else
			{
				sqlCom.Parameters.Clear();
				sqlCom.CommandText = "EXEC " + strSQLExec;
				sqlCom.CommandType = CommandType.Text;

				try
				{
					sqlCom.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					EpointMessage.MsgCancel("Error: " + e.Message);
					return false;
				}
				return true;
			}
		}

		public static bool DeleteQueue(SqlCommand sqlCom, string strStt, string strMa_Ct)
		{
			string strSQLExec = "SP_CT_DELETE80 '" + strStt + "', '" + strMa_Ct + "'";

			if (Element.sysRun_Service)
			{
				//Xóa dữ liệu trên bảng Queue: khi xóa thì loại trừ tất cả những dữ liệu cũ trên Queue
				sqlCom.CommandText = "DELETE FROM SYSQUEUE WHERE Stt = @strStt";
				sqlCom.CommandType = CommandType.Text;

				sqlCom.Parameters.Clear();
				sqlCom.Parameters.AddWithValue("@strStt", @strStt);

				sqlCom.ExecuteNonQuery();
				//Xóa xong

				return SQLPushQueue(sqlCom, strSQLExec, strStt);
			}
			else
			{
				sqlCom.Parameters.Clear();
				sqlCom.CommandText = "EXEC " + strSQLExec;
				sqlCom.CommandType = CommandType.Text;

				try
				{
					sqlCom.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					EpointMessage.MsgCancel("Error: " + e.Message);
					return false;
				}
				return true;
			}
		}

		public static bool SQLPushQueue(SqlCommand sqlCom, string strSp_Exec, string strStt)
		{
			//Cập nhật vào bảng hàng đợi, loại trừ dữ liệu trùng
			string strSQLExec =
				" DELETE FROM SYSQUEUE WHERE Sp_Exec = @strSp_Exec AND Stt = @strStt " +
				" INSERT INTO SYSQUEUE(Sp_Exec, Stt) VALUES (@strSp_Exec, @strStt) ";

			sqlCom.CommandType = CommandType.Text;
			sqlCom.CommandText = strSQLExec;

			sqlCom.Parameters.Clear();
			sqlCom.Parameters.AddWithValue("@strSp_Exec", @strSp_Exec);
			sqlCom.Parameters.AddWithValue("@strStt", @strStt);

			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
				return false;
			}
			return true;
		}

		#endregion

		/// <summary>
		/// Phuong thuc kiem tra quyen
		/// </summary>
		/// <param name="strObject_ID">Doi tuong can kiem tra quyen (phu thuoc vao Object_Type)</param>
		/// <param name="strObject_Type">Loai doi tuong kiem tra 'MODULE,MENU,LIST,VOUCHER,REPORT'</param>
		/// <param name="strCheck_Type">Quyen kiem tra: DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE,DENY_VIEW</param>
		/// <returns></returns>
		public static bool CheckPermission(string strObject_ID, enuPermission_Type enuPermission)
		{
			if (!Element.Is_Running)
				return true;

			string strUser_ID = Element.sysUser_Id;
			string strPermission_Type = enuPermission.ToString();

			string[] strArrParameter_Name = new string[] { "@Member_ID", "@Object_ID" };
			object[] objArrParameter_Value = new object[] { strUser_ID, strObject_ID };

			DataTable dtPermission = SQLExec.ExecuteReturnDt("Sp_CheckPermission", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

			if (dtPermission.Rows.Count > 0)
			{
				if (dtPermission.Columns.Contains(strPermission_Type))

					return Convert.ToBoolean(dtPermission.Rows[0][strPermission_Type]);

				else
				{//Khong ton tai truong

					EpointMessage.MsgCancel(Languages.GetLanguage("Not_Exist") + strPermission_Type);
					return false;
				}
			}
			else
				return false;

		}

		public static bool CheckDataLocked(DateTime dteNgay_Ct)
		{
			Hashtable htCheckDataLocked = new Hashtable();
			htCheckDataLocked.Add("NGAY_CT", dteNgay_Ct);
			htCheckDataLocked.Add("MA_DVCS", Element.sysMa_DvCs);

			bool bCheckDataLocked = (bool)SQLExec.ExecuteReturnValue("sp_CheckDataLocked", htCheckDataLocked, CommandType.StoredProcedure);

			return bCheckDataLocked;
		}

		public static void SetEnvironment()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//CultureInfo cti = new CultureInfo("en-GB");

			//cti.NumberFormat.NumberGroupSeparator = " ";
			//cti.NumberFormat.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3 };
			//cti.NumberFormat.NumberDecimalSeparator = ".";

			//cti.NumberFormat.CurrencyGroupSeparator = " ";
			//cti.NumberFormat.CurrencyGroupSizes = new int[] { 3, 3, 3, 3, 3 };
			//cti.NumberFormat.CurrencyDecimalSeparator = ".";

			//Application.CurrentCulture = cti;
			//System.Threading.Thread.CurrentThread.CurrentCulture = cti;


			//string strEpointFile = Application.StartupPath + @"\Epoint.txt";


			DataElement.sysAppConfigFile = Application.StartupPath + Collection.AppConfigFile;
			string ApplicationPATH = Utils.ReadConfigXML(DataElement.sysAppConfigFile, "ApplicationPATH");
			string ConnectionString = Utils.ReadConfigXML(DataElement.sysAppConfigFile, "ConnectionString");
			Element.sysConfigFile = Utils.ReadConfigXML(DataElement.sysAppConfigFile, "ConfigFile").ToLower();
			Element.sysConfigFileUpdate = Utils.ReadConfigXML(DataElement.sysAppConfigFile, "ConfigFileUpdate").ToLower();
			Element.Is_Server = 0 == string.Compare("1", Utils.ReadConfigXML(DataElement.sysAppConfigFile, "ISSERVER").ToLower(), true);

			if (Element.Is_Server)
				Element.sysREPORTPATH = Application.StartupPath + @"\Reports\";
			else
				Element.sysREPORTPATH = ApplicationPATH + @"\Reports\";

			if (ConnectionString == null || ConnectionString == String.Empty)
			{
				DataElement.sysConnection.ConnectionString = Elements.Core.ConnectionString();
			}
			else
				DataElement.sysConnection.ConnectionString = Elements.Core.ConnectionString(ConnectionString);
			Element.Is_Running = true;
			Element.Is_CheckRunLics = true;
			Element.sysConnection.ConnectionString = DataElement.sysConnection.ConnectionString;
		}

		public static void InitSystem()
		{
			Parameters.FillParameters();
			Columns.FillColumns();
			Languages.FillLanguages();
			Zones.FillZones();

			Aspose.Cells.License licenseKey = new Aspose.Cells.License();
			licenseKey.SetLicense(Epoint.Systems.Commons.Commons.LicenseKeyAsposeCells.LStream);
			
			// đặt Culture: phải đặt Culture theo từng User
			/*
                CultureInfo cti = new CultureInfo("fr-FR");
                //CultureInfo cti = new CultureInfo("en-US");

                string strCultureName = Parameters.GetParaValue("CULTUREFORMAT").ToString().Trim();
                if (strCultureName == "vi-VN")
                {
                    cti.NumberFormat = new CultureInfo("vi-VN").NumberFormat;
                    cti.DateTimeFormat = new CultureInfo("vi-VN").DateTimeFormat;
                }

                Application.CurrentCulture = cti;
                System.Threading.Thread.CurrentThread.CurrentCulture = cti;

                */
			string strNumber_currency = (string)Parameters.GetParaValue("NUMBER_CURRENCY");
			strNumber_currency = strNumber_currency.Trim().Replace("{", "").Replace("}", "");
			switch (strNumber_currency)
			{
				case "":
					strNumber_currency = " ";
					break;
					//case string.Empty :
					//    paraValue = " ";
					//    break;
			}
			string strNumber_Decimal = (string)Parameters.GetParaValue("NUMBER_DECIMAL");
			strNumber_Decimal = strNumber_Decimal.Replace("{", "").Replace("}", "");
			if ((strNumber_Decimal == "") || (strNumber_Decimal == string.Empty))
			{
				strNumber_Decimal = ".";
			}
			//CultureInfo info = new CultureInfo("en-GB")
			CultureInfo info = new CultureInfo("fr-FR")
			{
				NumberFormat = { NumberGroupSeparator = strNumber_currency, NumberGroupSizes = new int[] { 3, 3, 3, 3, 3 }, NumberDecimalSeparator = strNumber_Decimal, CurrencyGroupSeparator = strNumber_currency, CurrencyGroupSizes = new int[] { 3, 3, 3, 3, 3 }, CurrencyDecimalSeparator = strNumber_Decimal },
				DateTimeFormat = new CultureInfo("vi-VN").DateTimeFormat
			};
			Application.CurrentCulture = info;

			//////////////////////////////
			Element.sysDateTime_Log = DateTime.Now;

			//Common.SetSysLanguage((string)Parameters.GetParaValue("DEFAULT_LANGUAGE") == "E" ? 'E' : (string)Parameters.GetParaValue("DEFAULT_LANGUAGE") == "V"? 'V' : 'O');

			Element.sysDia_Chi_Dv = (string)Parameters.GetParaValue("DIA_CHI_DV");

			//Gán Dvcs
			string strMa_DvCs = (string)Parameters.GetParaValue("Ma_DvCs");
			char strLanguagueID = (string)Parameters.GetParaValue("DEFAULT_LANGUAGE") == "E" ? 'E' : (string)Parameters.GetParaValue("DEFAULT_LANGUAGE") == "V" ? 'V' : 'O';

			DataRow drMember = DataTool.SQLGetDataRowByID("SYSMEMBER", "Member_ID", Element.sysUser_Id);

			if (drMember.Table.Columns.Contains("Ma_DvCs_Default") && drMember["Ma_DvCs_Default"].ToString() != string.Empty)
				strMa_DvCs = drMember["Ma_DvCs_Default"].ToString();

			if (drMember.Table.Columns.Contains("Language_Default") && drMember["Language_Default"].ToString() != string.Empty)
				strLanguagueID = drMember["Language_Default"].ToString() == "E" ? 'E' : drMember["Language_Default"].ToString() == "V" ? 'V' : 'O';

			DataTable dtDmDvCs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS (NOLOCK) WHERE Ma_DvCs = '" + strMa_DvCs + "'");

			if (Core.Is_Ma_Dvcs_Valid(strMa_DvCs) && dtDmDvCs.Rows.Count > 0)
			//if (dtDmDvCs.Rows.Count > 0)
			{
				Element.sysMa_DvCs = (string)dtDmDvCs.Rows[0]["Ma_DvCs"];
				Element.sysMa_Data = (string)dtDmDvCs.Rows[0]["Ma_Data"];
				Element.sysTong_Hop = (bool)dtDmDvCs.Rows[0]["Tong_Hop"];

				if (dtDmDvCs.Columns.Contains("Dia_Chi_Dv"))
					Element.sysDia_Chi_Dv = (string)dtDmDvCs.Rows[0]["Dia_Chi_Dv"];
			}
			else
			{
				Element.sysMa_DvCs = "E00";
				Element.sysMa_Data = "E00";
				Element.sysTong_Hop = true;
				EpointMessage.MsgCancel(String.Format(EpointMessage.GetMessage("DVCS_NOTEXIST"), strMa_DvCs));
			}

			Common.SetSysLanguage(strLanguagueID);

			//Gán năm làm việc
			string strSQLExec =
				"SELECT Nam, Ma_DvCs, Th_Bd_Ht FROM SYSNAM (NOLOCK)  " +
					"WHERE Ident00 = " +
						"(SELECT Ident00 FROM SYSNAM (NOLOCK)  " +
							"WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = (SELECT MAX(Nam) FROM SYSNAM (NOLOCK) ))";

			DataTable dtNam = SQLExec.ExecuteReturnDt(strSQLExec);

			if (dtNam.Rows.Count > 0)
			{
				Element.sysWorkingYear = (int)dtNam.Rows[0]["Nam"];
				Element.sysTh_Bd_Ht = (int)dtNam.Rows[0]["Th_Bd_Ht"];
			}
			else
			{
				Element.sysWorkingYear = System.DateTime.Now.Year;
				Element.sysTh_Bd_Ht = 1;
			}
			Common.SetDataForDataTool();
			//Các thông số còn lại
			Element.sysIs_Admin = (bool)DataTool.SQLGetDataRowByID("SYSMember", "Member_ID", Element.sysUser_Id)["Is_Admin"];

			Element.sysNgay_Ct1 = GetDate(Element.sysWorkingYear, Element.sysTh_Bd_Ht, 1);
			Element.sysNgay_Ct2 = DateTime.Now;

			Element.sysTimer.Start();
			Element.frmCalc = new Epoint.Systems.Librarys.frmCalc();

			string strTextToolStrip = Parameters.GetParaValue("TEXTTOOLSTRIP").ToString().Trim();
			if (strTextToolStrip == "1")
				Element.sysTextToolStrip = true;
			else
				Element.sysTextToolStrip = false;

            string AppConfigFile = Application.StartupPath + @"\Epoint.exe.config";
            string ApplicationPATH = Utils.ReadConfigXML(AppConfigFile, "ApplicationPATH");
            Element.Is_Server = 0 == string.Compare("1", Utils.ReadConfigXML(AppConfigFile, "ISSERVER").ToLower(), true);
            Element.sysConfigFile = Utils.ReadConfigXML(AppConfigFile, "ConfigFile").ToLower();
            Element.sysConfigFileUpdate = Utils.ReadConfigXML(AppConfigFile, "ConfigFileUpdate").ToLower();

            DataTable dtZaloInfo = SQLExec.ExecuteReturnDt("EXEC SP_Zalo_GetInfo");
            if (dtZaloInfo.Rows.Count>0)
            {
                ElementHrm.sysZaloCodeID = dtZaloInfo.Rows[0]["Code"].ToString();
				ElementHrm.sysZaloOfficialID = dtZaloInfo.Rows[0]["OfficialID"].ToString();
				ElementHrm.sysZaloSeccretKey = dtZaloInfo.Rows[0]["SeccretKey"].ToString();
				ElementHrm.sysZaloAccessToken = dtZaloInfo.Rows[0]["AccessToken"].ToString();
				ElementHrm.sysLinkInfo = dtZaloInfo.Rows[0]["LinkInfo"].ToString();
            }

			//Kiểm tra xem có hợp lệ không
			if (!EpointMethod.CheckdataLics())
			{
				Element.frmMain.Hide();

				//EpointMethod.UpdateDataLics();
				Application.Exit();
				Element.frmMain.Close();
			}


            if (!Element.Is_CheckRunLiveUpdate && !EpointMethod.CheckVersion())
            {
                if (EpointMessage.MsgYes_No("Đã có cấp nhật mới, bạn có muốn cấp nhật không !"))
                {
                    string strFilePath = Application.StartupPath + @"\\LiveUpdate.exe";
                    if (System.IO.File.Exists(strFilePath))
                        System.Diagnostics.Process.Start(strFilePath);

                    //Exit
                    try
                    {
                        Element.Is_Running = false;
                        Element.Is_CheckRunLiveUpdate = false;
                        Application.Exit();
                        //Element.frmMain.Hide();
                        //Common.CloseCurrentForm();
                        //Element.frmMain.Close();
                       
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
            }

		}
		public static void InitSystemCulture()
		{
			try
			{
				//Parameters.FillParameters();
				//Columns.FillColumns();
				//Languages.FillLanguages();
				//Zones.FillZones();
				//// đặt Culture: phải đặt Culture theo từng User

				//CultureInfo cti = new CultureInfo("fr-FR");
				//CultureInfo cti = new CultureInfo("en-US");
				CultureInfo cti = System.Threading.Thread.CurrentThread.CurrentCulture;

				string strCultureName = Parameters.GetParaValue("CULTUREFORMAT").ToString().Trim();
				if (strCultureName == "vi-VN")
				{
					//cti.NumberFormat = new CultureInfo("vi-VN").NumberFormat;
					cti.DateTimeFormat = new CultureInfo("vi-VN").DateTimeFormat;
				}

				Application.CurrentCulture = cti;
				System.Threading.Thread.CurrentThread.CurrentCulture = cti;

			}
			catch { }
		}
		private static void SetDataForDataTool()
		{
			DataTool.sysMa_DvCs = Element.sysMa_DvCs;
			DataTool.sysMa_Data = Element.sysMa_Data;
			DataTool.sysIs_Admin = Element.sysIs_Admin;
			DataTool.sysTong_Hop = Element.sysTong_Hop;
			DataTool.sysWorkingYear = Element.sysWorkingYear;
			DataTool.sysUser_Id = Element.sysUser_Id;

			DataElement.sysMa_DvCs = Element.sysMa_DvCs;
			DataElement.sysMa_Data = Element.sysMa_Data;
			DataElement.sysIs_Admin = Element.sysIs_Admin;
			DataElement.sysTong_Hop = Element.sysTong_Hop;
			DataElement.sysWorkingYear = Element.sysWorkingYear;
			DataElement.sysUser_Id = Element.sysUser_Id;
		}
		public static void SetSysMa_DvCs(string strMa_DvCs)
		{
			DataTable dtDmDvCs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDmDvCs (NOLOCK)  WHERE Ma_DvCs = '" + strMa_DvCs + "'");

			if (!Elements.Core.Is_Ma_Dvcs_Valid(strMa_DvCs))
			{
				MsgCancel("Đơn vị cơ sở không hợp lệ!");
				return;
			}

			if (dtDmDvCs.Rows.Count > 0)
			{
				Element.sysMa_Data = ((string)dtDmDvCs.Rows[0]["Ma_Data"]).Trim();
				Element.sysMa_DvCs = ((string)dtDmDvCs.Rows[0]["Ma_DvCs"]).Trim();
				//Element.sysTen_DvCs = ((string)dtDmDvCs.Rows[0]["Ten_DvCs"]).Trim();
				Element.sysTong_Hop = (bool)dtDmDvCs.Rows[0]["Tong_Hop"];

				if (dtDmDvCs.Columns.Contains("Dia_Chi_Dv"))
					Element.sysDia_Chi_Dv = (string)dtDmDvCs.Rows[0]["Dia_Chi_Dv"];

				//Kiểm tra năm làm việc hiện hành có tồn tai kô
				int iNam = Element.sysWorkingYear;
				DataTable dtNam = SQLExec.ExecuteReturnDt("SELECT * FROM SYSNam  (NOLOCK) WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = " + iNam.ToString());

				if (dtNam.Rows.Count == 1) //Set lại tháng bắt đầu hạch toán
				{
					SetSysWorkingYear(iNam);
				}

				((frmMain)Element.frmMain).Text = Element.sysTen_Dvi.ToUpper() + "_" + Element.sysMa_DvCs;
				Common.CloseAllWorkingModule();
				Common.CloseAllForm((frmMain)Element.frmMain);
			}
			else
				((frmMain)Element.frmMain).ssMain.tsbtYear.Text = DateTime.Now.Year.ToString().Trim();

			Common.SetDataForDataTool();

		}

		public static void SetSysWorkingYear(int iNam)
		{
			string strSQLExec =
				"SELECT * FROM SYSNAM WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = " + iNam.ToString().Trim();
			int iYearOld = Element.sysWorkingYear;
			DataTable dtNam = SQLExec.ExecuteReturnDt(strSQLExec);

			if (dtNam.Rows.Count > 0)
			{
				Element.sysWorkingYear = iNam;
				Element.sysTh_Bd_Ht = (int)dtNam.Rows[0]["Th_Bd_Ht"];
			}
			else
			{
				Element.sysWorkingYear = DateTime.Now.Year;
				Element.sysTh_Bd_Ht = 1;
			}

			//((frmMain)Element.frmMain).tsSystem.tscbYear.Text = Element.sysWorkingYear.ToString().Trim();
			((frmMain)Element.frmMain).ssMain.tsbtYear.Text = Element.sysWorkingYear.ToString().Trim();

			if (iYearOld == Element.sysWorkingYear)
				return;
			Common.CloseAllForm((frmMain)Element.frmMain);
			//
			Common.CloseAllWorkingModule();
		}



		public static void SetSysLanguageToolStrip(Form frm)
		{

			if (frm.Name == "frmMain")
			{    // Tool system
				((frmMain)frm).tsSystem.tsbCalc.ToolTipText = Languages.GetLanguage("Calculator");
				((frmMain)frm).ssMain.tsiLanguage.ToolTipText = Languages.GetLanguage("Language");
				((frmMain)frm).tsSystem.tsbDvCs.ToolTipText = Languages.GetLanguage("Business_Cell");
				((frmMain)frm).ssMain.tsbtYear.ToolTipText = Languages.GetLanguage("Working_Year");
				((frmMain)frm).tsSystem.tsbRestart.ToolTipText = Languages.GetLanguage("Restart");
				((frmMain)frm).tsSystem.tsbExit.ToolTipText = Languages.GetLanguage("ExitProgram");
				//((frmMain)frm).tsSystem.tsbClose.ToolTipText = Languages.GetLanguage("Close");



				// toolstrip view
				((frmMain)frm).tsView.tsbFilter.ToolTipText = Languages.GetLanguage("Filter");
				((frmMain)frm).tsView.tsbQuickReport.ToolTipText = Languages.GetLanguage("Quick_Report");
				((frmMain)frm).tsView.tsbSearch.ToolTipText = Languages.GetLanguage("Search");
				((frmMain)frm).tsView.tsbTotal.ToolTipText = Languages.GetLanguage("Total");
				//((frmMain)frm).tsView.tsbExport.ToolTipText = Languages.GetLanguage("Export");

				((frmMain)frm).tsView.tsbFilter.Text = Languages.GetLanguage("Filter");
				((frmMain)frm).tsView.tsbQuickReport.Text = Languages.GetLanguage("Quick_Report");
				((frmMain)frm).tsView.tsbSearch.Text = Languages.GetLanguage("Search");
				((frmMain)frm).tsView.tsbTotal.Text = Languages.GetLanguage("Total");
				//((frmMain)frm).tsView.tsbExport.Text = Languages.GetLanguage("Export");

				// toolstrip Edit
				((frmMain)frm).tsEdit.tsbNew.ToolTipText = Languages.GetLanguage("Add_New");
				((frmMain)frm).tsEdit.tsbEdit.ToolTipText = Languages.GetLanguage("Edit");
				((frmMain)frm).tsEdit.tsbDelete.ToolTipText = Languages.GetLanguage("Delete");

				((frmMain)frm).tsEdit.tsbNew.Text = Languages.GetLanguage("Add_New");
				((frmMain)frm).tsEdit.tsbEdit.Text = Languages.GetLanguage("Edit");
				((frmMain)frm).tsEdit.tsbDelete.Text = Languages.GetLanguage("Delete");


				// toolstrip Report
				((frmMain)frm).tsReport.tsbChart.ToolTipText = Languages.GetLanguage("Chart");
				((frmMain)frm).tsReport.tsbDesign.ToolTipText = Languages.GetLanguage("Design");
				((frmMain)frm).tsReport.tsbEditVoucher.ToolTipText = Languages.GetLanguage("EditVoucher");
				((frmMain)frm).tsReport.tsbPreview.ToolTipText = Languages.GetLanguage("Preview");
				((frmMain)frm).tsReport.tsbPrint.ToolTipText = Languages.GetLanguage("Print");
				((frmMain)frm).tsReport.tsbRefeshReport.ToolTipText = Languages.GetLanguage("Refesh");

				((frmMain)frm).tsReport.tsbChart.Text = Languages.GetLanguage("Chart");
				((frmMain)frm).tsReport.tsbDesign.Text = Languages.GetLanguage("Design");
				((frmMain)frm).tsReport.tsbEditVoucher.Text = Languages.GetLanguage("EditVoucher");
				((frmMain)frm).tsReport.tsbPreview.Text = Languages.GetLanguage("Preview");
				((frmMain)frm).tsReport.tsbPrint.Text = Languages.GetLanguage("Print");
				((frmMain)frm).tsReport.tsbRefeshReport.Text = Languages.GetLanguage("Refesh");


				((frmMain)frm).ssMain.tsilReminder.Text = Languages.GetLanguage("Reminder");

			}
		}
		public static void SetSysLanguage(char cLanguage)
		{
			Element.sysLanguage = (enuLanguageType)cLanguage;

			//Apply Culter Devexpress for Application
			switch ((enuLanguageType)cLanguage)
			{
				case enuLanguageType.Vietnamese:
					//Đặt culture vi-VN cho control Devexpress
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
					break;

				case enuLanguageType.English:
					//Đặt culture en-EN cho control Devexpress
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
					break;

				case enuLanguageType.Other:
					//Đặt culture zh-CN cho control Devexpress
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
					break;

				default:
					//Đặt culture vi-VN cho control Devexpress
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
					break;
			}

			//Doi ngon ngu
			foreach (Form frm in Application.OpenForms)
			{
				Languages.BindingLanguageForm(frm, Element.sysLanguage);

				//Form Main
				if (frm.Name == "frmMain")
				{
					switch ((enuLanguageType)cLanguage)
					{
						case enuLanguageType.Vietnamese:
							((frmMain)frm).ssMain.tsiLanguage.Text = ((char)enuLanguageType.Vietnamese).ToString();
							((frmMain)frm).ssMain.tsiLanguage.ForeColor = Elements.ColorTable.TextLanguageV;
							break;

						case enuLanguageType.English:
							((frmMain)frm).ssMain.tsiLanguage.Text = ((char)enuLanguageType.English).ToString();
							((frmMain)frm).ssMain.tsiLanguage.ForeColor = Elements.ColorTable.TextLanguageE;	
							break;

						case enuLanguageType.Other:
							((frmMain)frm).ssMain.tsiLanguage.Text = ((char)enuLanguageType.Other).ToString();
							((frmMain)frm).ssMain.tsiLanguage.ForeColor = Elements.ColorTable.TextLanguageO;
							break;

						default:
							((frmMain)frm).ssMain.tsiLanguage.Text = ((char)enuLanguageType.Vietnamese).ToString();
							((frmMain)frm).ssMain.tsiLanguage.ForeColor = Elements.ColorTable.TextLanguageV;
							break;
					}

					SetSysLanguageToolStrip(frm);
				}
			}
		}
		#region Tab controls
		public static void CloseAllWorkingModule()
		{
			foreach (ListViewItem lvi in ((frmMain)Element.frmMain).ucModuleManagement.lvOpeningModule.Items)
			{
				if (lvi.Index != 0) //Không đóng màn hình chính
				{
					if (lvi.GetType().Name == "lviOpeningModule")
					{
						((lviOpeningModule)lvi).tsmi.frmInstance.Close();
					}
				}
			}
		}
		public static void CloseCurrentForm()
		{

			try
			{
				if (Element.frmMain == null)
					return;
				frmMain frmM = (frmMain)Elements.Element.frmMain;
				tbTabControl tbTabMain = frmM.tbTabMain;
				string strNameParent = string.Empty;
				if (frmM.tbTabMain.TabPages.Count > 0)
				{
					if (tbTabMain.SelectedTabPage.Text != "MAIN")
					{
						tbTabPageControl tbTabCurrent = (tbTabPageControl)tbTabMain.SelectedTabPage;
						strNameParent = tbTabCurrent.strNameParent;
						frmM.tbTabMain.TabPages.Remove(tbTabCurrent);
						if (frmM.tbTabMain.TabPages.Count == 0)
						{
							frmM.tbTabMain.Visible = false;
							((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = false;
							frmM.tsReport.Visible = false;
							//tsView.Visible = false;
							frmM.tsEdit.Visible = false;
						}

					}
					if (strNameParent != string.Empty)
						for (int i = 0; i < tbTabMain.TabPages.Count; i++)
						{
							if (strNameParent == tbTabMain.TabPages[i].Name)
							{
								tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
								return;
							}
						}
				}
				else
				{
					frmM.tbTabMain.Visible = false;
					((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = false;
				}
			}
			catch (Exception ex)
			{
				EpointMessage.MsgOk(ex.ToString());
			}
		}
		public static void CloseCurrentFormOnMain()
		{

			try
			{
				if (Element.frmMain == null)
					return;

				//if (Elements.Element.Is_FrmEditRunning)
				//    return;
				frmMain frmM = (frmMain)Elements.Element.frmMain;
				tbTabControl tbTabMain = frmM.tbTabMain;
				tbTabPageControl tbTabPageCurent;
				tbTabPageCurent = (tbTabPageControl)tbTabMain.SelectedTabPage;
				string strNameParent = string.Empty;
				if (tbTabPageCurent.Controls.Count == 0) //Neu tabpage ko chua form nao
				{
					tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
					if (tbTabMain.TabPages.Count == 0)
						tbTabMain.Visible = false;
					return;
				}
				else if (tbTabMain.TabPages.Count > 0)
				{

					strNameParent = tbTabPageCurent.strNameParent;
					if (tbTabPageCurent.Controls.Count > 1)
					{
						//Neu tabpag chứa nhiều form 
						if (Common.InlistLike(tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1].GetType().Name, "frm"))
						{
							Form fr = (Form)tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1];
							if (Common.InlistLike(tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 2].GetType().Name, "frm"))
							{
								//Hiên thị form trước đó
								tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 2].Show();
								tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 2].Focus();
							}
							fr.Close(); // Đóng form mở gầ nhất 
							return;
							//continue;
						}
						//}
					}
					else
					{
						tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
						if (tbTabMain.TabPages.Count == 0)
						{
							tbTabMain.Visible = false;
							ShowStatusReminder();
							frmM.tsReport.Visible = false;
							frmM.tsView.Visible = false;
							frmM.tsEdit.Visible = false;
						}
						if (strNameParent != string.Empty)
							for (int i = 0; i < tbTabMain.TabPages.Count; i++)
							{
								if (strNameParent == tbTabMain.TabPages[i].Name)
								{
									tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
									return;
								}
							}
					}

				}
				else // tat het tabpage thi an luon tab
				{
					tbTabMain.Visible = false;
					ShowStatusReminder();
				}
			}
			catch (Exception ex)
			{
				EpointMessage.MsgOk(ex.ToString());
			}
		}
		public static void ActiveFormOnTab()
		{

			try
			{
				if (Element.frmMain == null)
					return;

				//if (Elements.Element.Is_FrmEditRunning)
				//    return;
				frmMain frmM = (frmMain)Elements.Element.frmMain;
				tbTabControl tbTabMain = frmM.tbTabMain;
				tbTabPageControl tbTabPageCurent;
				tbTabPageCurent = (tbTabPageControl)tbTabMain.SelectedTabPage;
				string strNameParent = string.Empty;
				if (tbTabMain.TabPages.Count > 0)
				{

					strNameParent = tbTabPageCurent.strNameParent;
					if (tbTabPageCurent.Controls.Count > 0)
					{
						//Neu tabpag chứa nhiều form 
						if (Common.InlistLike(tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1].GetType().Name, "frm"))
						{
							Form fr = (Form)tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1];

							fr.Activate(); // Đóng form mở gầ nhất 
							fr.Focus();
							return;
							//continue;
						}
						//}
					}


				}
				else // tat het tabpage thi an luon tab
				{
					tbTabMain.Visible = false;
					ShowStatusReminder();
				}
			}
			catch (Exception ex)
			{
				EpointMessage.MsgOk(ex.ToString());
			}
		}
		/// <summary>
		/// Close tabpage neu Tabpage ko chua form nào
		/// </summary>
		public static void CloseCurrentFormNull()
		{
			try
			{
				if (Element.frmMain == null)
					return;
				frmMain frmM = (frmMain)Elements.Element.frmMain;
				tbTabControl tbTabMain = frmM.tbTabMain;
				if (tbTabMain == null)
					return;
				if (!tbTabMain.Visible)
					return;
				tbTabPageControl tbTabPageCurent;
				string strNameParent = string.Empty;

				if (tbTabMain.TabPages.Count > 0)
				{
					tbTabPageCurent = (tbTabPageControl)tbTabMain.SelectedTabPage;

					if (!tbTabPageCurent.HasChildren)
					{
						tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
					}
					strNameParent = tbTabPageCurent.strNameParent;
					if (tbTabPageCurent.Controls.Count == 0)
					{
						tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
						//return;
					}
					if (tbTabMain.TabPages.Count == 0)
						tbTabMain.Visible = false;
				}
				else
					tbTabMain.Visible = false;
			}
			catch (Exception ex)
			{
				//EpointMessage.MsgOk(ex.ToString());
			}
		}
		//public static void CloseCurrentFormOnChild()
		//{
		//    try
		//    {
		//        frmMain frmM = (frmMain)Elements.Element.frmMain;
		//        tbTabControl tbTabMain = frmM.tbTabMain;
		//        tbTabPageControl tbTabPage = (tbTabPageControl) tbTabMain.SelectedTabPage;
		//        if (tbTabMain.TabPages.Count > 0)
		//        {
		//            if (tbTabPage.Controls.Count > 1)
		//            {
		//                //for (int i = tbTabPage.Controls.Count - 1; i >= 0; i--)
		//                //{
		//                if (Common.InlistLike(tbTabPage.Controls[tbTabPage.Controls.Count - 1].GetType().Name, "frm"))
		//                {
		//                    tbTabPage.Controls[tbTabPage.Controls.Count - 2].Show();
		//                    return;
		//                    //continue;
		//                }
		//                //}
		//            }
		//            else
		//            {
		//                tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
		//                if (tbTabMain.TabPages.Count == 0)
		//                    tbTabMain.Visible = false;
		//            }

		//        }
		//        else
		//            tbTabMain.Visible = false;
		//    }
		//    catch (Exception ex)
		//    {
		//        EpointMessage.MsgOk(ex.ToString());
		//    }
		//}
		/// <summary>
		/// Add tab xác định tab cha cần focus
		/// </summary>
		/// <returns></returns>
        //obj.Visible = true;
        
		public static void AddFormOnTab(Form obj, string strName, string strDesc, string strDescE, string strDescO, string strImage,string strObject_ID)
		{
			if (obj == null)
				return;
			frmMain frmM = (frmMain)Element.frmMain;

			tbTabControl tbTabMain = frmM.tbTabMain;

			tbTabPageControl tbTabPage = new tbTabPageControl();

			//for (int i = 0; i < tbTabMain.TabPages.Count; i++)
			// {
			//     if (strName == tbTabMain.TabPages[i].Name)
			//     {
			//         tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
			//         return;
			//     }
			// }

			tbTabPage.Name = strName;
			tbTabPage.strEnglish = strDescE;
			tbTabPage.strVietNamese = strDesc;
			tbTabPage.strOtherLanguage = strDescO;
			tbTabPage.ImageFileName = strImage;
			tbTabPage.Tooltip = obj.Text;
			if (strImage != string.Empty)
			{
				string strFileName = Application.StartupPath + @"\Images\" + strImage;

				if (System.IO.File.Exists(strFileName))
				{
					Image img = Image.FromFile(strFileName);
					Element.sysImageList.Images.Add(img);
					tbTabPage.Image = Element.sysImageList.Images[Element.sysImageList.Images.Count - 1];
				}
			}
			else if (InlistLike(obj.Name, "frmReport"))
				tbTabPage.Image = Properties.Resources.Report;

			if (frmM.tbTabMain.Visible && tbTabMain.TabPages.Count > 0)
				tbTabPage.strNameParent = tbTabMain.SelectedTabPage.Name;


			if (Element.sysLanguage == enuLanguageType.Vietnamese)
				tbTabPage.Text = strDesc;
			else if (Element.sysLanguage == enuLanguageType.English)
				tbTabPage.Text = strDescE;
			else
				tbTabPage.Text = strDescO;



			frmM.tbTabMain.Visible = true;
			tbTabMain.TabPages.Add(tbTabPage);
			tbTabMain.SelectedTabPage = tbTabPage;
			obj.TopLevel = false;
			obj.FormBorderStyle = FormBorderStyle.None;
			obj.Dock = DockStyle.Fill;
			//obj.
			if (obj == null)
				return;
			tbTabPage.Controls.Add(obj);
			//obj.Visible = true;
			SetToolStrip();
			((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
			obj.Activate();
			obj.Focus();

		}
		public static void AddFormOnTab(Form obj, string strName, string strDesc, string strDescE, string strDescO)
		{
			AddFormOnTab(obj, strName, strDesc, strDescE, strDescO, "");
		}

		public static void AddFormOnTab(Form obj, string strName, string strLanguageID)
		{


			string strEnglish = Languages.GetLanguage(strLanguageID, enuLanguageType.English);
			string strVietNamese = Languages.GetLanguage(strLanguageID, enuLanguageType.Vietnamese);
			string strOtherLanguage = Languages.GetLanguage(strLanguageID, enuLanguageType.Other);

			AddFormOnTab(obj, strName, strEnglish, strVietNamese, strOtherLanguage, "");
		}


		public static void AddFormOnTab(object obj, string strName, string strLanguageID)
		{
			string strEnglish = Languages.GetLanguage(strLanguageID, enuLanguageType.English);
			string strVietNamese = Languages.GetLanguage(strLanguageID, enuLanguageType.Vietnamese);
			string strOtherLanguage = Languages.GetLanguage(strLanguageID, enuLanguageType.Other);

			AddFormOnTab(obj, strName, strEnglish, strVietNamese, strOtherLanguage, "");
		}

		public static void AddFormOnTab(object obj, string strName, string strDesc, string strDescE, string strDescO)
		{
			AddFormOnTab(obj, strName, strDesc, strDescE, strDescO, "");
		}

		public static void AddFormOnTab(object obj, string strName, string strDesc, string strDescE, string strDescO, string strImage)
		{
			if (obj == null)
				return;
			frmMain frmM = (frmMain)Element.frmMain;

			tbTabControl tbTabMain = frmM.tbTabMain;

			tbTabPageControl tbTabPage = new tbTabPageControl();

			Form frm = (Form)obj;
			tbTabPage.Name = strName;
			tbTabPage.strEnglish = strDescE;
			tbTabPage.strVietNamese = strDesc;
			tbTabPage.strOtherLanguage = strDescO;
			tbTabPage.ImageFileName = strImage;
			if (strImage != string.Empty)
			{
				string strFileName = Application.StartupPath + @"\Images\" + strImage;

				if (System.IO.File.Exists(strFileName))
				{
					Image img = Image.FromFile(strFileName);
					Element.sysImageList.Images.Add(img);
					tbTabPage.Image = Element.sysImageList.Images[Element.sysImageList.Images.Count - 1];
				}
			}
			else if (InlistLike(frm.Name, "frmReport"))
				tbTabPage.Image = Properties.Resources.ViewReport;

			if (frmM.tbTabMain.Visible && tbTabMain.TabPages.Count > 0)
				tbTabPage.strNameParent = tbTabMain.SelectedTabPage.Name;



			if (Element.sysLanguage == enuLanguageType.Vietnamese)
				tbTabPage.Text = strDesc;
			else if (Element.sysLanguage == enuLanguageType.English)
				tbTabPage.Text = strDescE;
			else
				tbTabPage.Text = strDescO;


			frmM.tbTabMain.Visible = true;
			tbTabMain.TabPages.Add(tbTabPage);
			tbTabMain.SelectedTabPage = tbTabPage;
			frm.TopLevel = false;
			frm.FormBorderStyle = FormBorderStyle.None;
			frm.Dock = DockStyle.Fill;

			tbTabPage.Controls.Add(frm);
			SetToolStrip();
			((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
			frm.Activate();
			frm.Focus();
		}

		public static void AddObjectOnCurentTab(object obj)
		{
			if (obj == null)
				return;
			frmMain frmM = (frmMain)Element.frmMain;

			tbTabControl tbTabMain = frmM.tbTabMain;
			if (tbTabMain.TabPages.Count == 0)
				return;
			tbTabPageControl tbTabPage = (tbTabPageControl)tbTabMain.SelectedTabPage;
			foreach (Control ctrl in tbTabPage.Controls)
			{
				if (Common.InlistLike(ctrl.GetType().Name, "frm"))
				{
					ctrl.Hide();
					//continue;
				}
			}
			tbTabPage.Controls.Add((Control)obj);
		}
		public static void AddFormOnCurentTab(Form obj)
		{
			if (obj == null)
				return;
			frmMain frmM = (frmMain)Element.frmMain;

			tbTabControl tbTabMain = frmM.tbTabMain;
			if (tbTabMain.TabPages.Count == 0)
				return;
			tbTabPageControl tbTabPage = (tbTabPageControl)tbTabMain.SelectedTabPage;
			foreach (Control ctrl in tbTabPage.Controls)
			{
				if (Common.InlistLike(ctrl.GetType().Name, "frm"))
				{
					ctrl.Hide();
					//continue;
				}
			}
			obj.TopLevel = false;
			obj.FormBorderStyle = FormBorderStyle.None;
			obj.Dock = DockStyle.Fill;
			//obj.
			if (obj != null)
				tbTabPage.Controls.Add(obj);
			((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
			obj.Activate();
			obj.Focus();

		}
		public static bool tabExistsOnMain()
		{
			frmMain frmMain = (frmMain)Element.frmMain;
			if (frmMain.tbTabMain.TabPages.Count == 0)
				return false;
			return true;
		}
		public static bool tabPageExistsOnMain(string strNameTabPage)
		{
			frmMain frmMain = (frmMain)Element.frmMain;
			tbTabControl tbTabMain = frmMain.tbTabMain;

			tbTabPageControl tbTabPage = new tbTabPageControl();

			for (int i = 0; i < tbTabMain.TabPages.Count; i++)
			{
				if (strNameTabPage == tbTabMain.TabPages[i].Name)
				{
					tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
					return false;
				}
			}
			return true;
		}
		public static void CloseAllForm(frmMain frm)
		{
			try
			{
				//frmMain frmMain = (frmMain)Elements.Element.frmMain;

				if (frm == null)
					return;
				tbTabControl tbMain = frm.tbTabMain;
				for (int i = tbMain.TabPages.Count - 1; i >= 0; i--)
				{
					//if (tbMain.TabPages[i].Tag.ToString() != "MAIN")
					//{
					tbMain.TabPages.RemoveAt(i);
					//}
				}
				tbMain.Visible = false;
				ShowStatusReminder();
			}
			catch (Exception ex)
			{
				EpointMessage.MsgOk(ex.ToString());
			}
		}
		// find tren tab control
		public static Form FindFormChildInTab()
		{
			Form frm = null;

			frmMain frmMain = (frmMain)Elements.Element.frmMain;

			if (frmMain.tbTabMain.TabPages.Count == 0)
				return null;
			tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;
			if (tb.Tag == "MAIN")
				return null;

			foreach (Control ctrl in tb.Controls)
			{
				if (Common.InlistLike(ctrl.GetType().Name, "frm") && ctrl.GetType().Name != "frmReportResult" && ctrl.GetType().Name != "frmReport")
				{
					frm = (Form)ctrl;
					continue;
				}
			}

			return frm;
		}
		//Find from frmReportResult tren Tabcontrol

		public static Form FindFormReportResultInTab()
		{
			Form frm = null;

			frmMain frmMain = (frmMain)Elements.Element.frmMain; if (frmMain.tbTabMain.TabPages.Count == 0)
				return null;
			tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;
			if (tb.Tag == "MAIN")
				return null;

			foreach (Control ctrl in tb.Controls)
			{
				if (Common.InlistLike(ctrl.GetType().Name, "frmReportResult"))
				{
					frm = (Form)ctrl;
					continue;
				}
			}

			return frm;
		}
		public static Form FindFormReportInTab()
		{
			Form frm = null;

			frmMain frmMain = (frmMain)Elements.Element.frmMain; if (frmMain.tbTabMain.TabPages.Count == 0)
				return null;
			tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;

			if (tb.Tag == "MAIN")
				return null;

			foreach (Control ctrl in tb.Controls)
			{
				if (Common.InlistLike(ctrl.GetType().Name, "frmReport"))
				{
					frm = (Form)ctrl;
					continue;
				}
			}

			return frm;
		}

		#endregion
		#region Readmoney And Number
		public static string ReadMoney(Double dbAmount, string strCurrency)
		{
			string strDvt = string.Empty;
			string strDvt0 = string.Empty;
			string strRead = string.Empty;
			string strDau = dbAmount < 0 ? "Âm " : "";
			dbAmount = Math.Abs(dbAmount);

			switch (strCurrency)
			{
				case "VND":
					strDvt = " đồng";
					strDvt0 = " xu";
					break;
				case "USD":
					strDvt = " đô la Mỹ";
					strDvt0 = " cent";
					break;
				case "SGD":
					strDvt = " đô la Singapore";
					strDvt0 = " cent";
					break;
				case "CHF":
					strDvt = " franc Thụy Sỹ";
					strDvt0 = " cent";
					break;
				default:
					strDvt = strCurrency;
					strDvt0 = " cent";
					break;
			}

			double dbNumber = Math.Truncate(dbAmount);
			double dbDecimal = Math.Round(dbAmount - dbNumber, 5, MidpointRounding.AwayFromZero); //Lỗi 500.01 - 500 = 0.0099999999999999051
			if (dbDecimal > 0)
				dbDecimal = Math.Round(dbDecimal * 100, 0, MidpointRounding.AwayFromZero); //Convert.ToInt16(dbDecimal.ToString().Substring(2));

			if (dbNumber > 0)
			{
				strRead = ReadNumber(dbNumber) + strDvt;
				strRead = strRead.Substring(0, 1).ToUpper() + strRead.Substring(1, strRead.Length - 1);
			}
			if (dbDecimal > 0)
				if (dbNumber > 0)
					strRead = strRead + " và " + ReadNumber(dbDecimal) + strDvt0;
				else
					strRead = ReadNumber(dbDecimal) + strDvt0;
			else
			{
				if (dbNumber > 0 && (Math.Round(dbNumber / 100, 2, MidpointRounding.AwayFromZero) - Math.Round(dbNumber / 100, 0, MidpointRounding.AwayFromZero)) == 0)
					strRead = strRead + " chẵn.";
			}

			return strDau + strRead;
		}

		public static string ReadMoneyE(Double dbAmount, string strCurrency)
		{
			string strDvt = string.Empty;
			string strDvt0 = string.Empty;
			string strRead = string.Empty;
			string strDau = dbAmount < 0 ? "Minus " : "";
			dbAmount = Math.Abs(dbAmount);

			switch (strCurrency)
			{
				case "VND":
					strDvt = " dong";
					strDvt0 = " penny";
					break;
				case "USD":
					strDvt = " US dollar";
					strDvt0 = " cents";
					break;
				case "SGD":
					strDvt = " Singapore dollar";
					strDvt0 = " cents";
					break;
				case "CHF":
					strDvt = " Swiss franc";
					strDvt0 = " cents";
					break;
				default:
					strDvt = strCurrency.ToString();
					strDvt0 = " cents";
					break;
			}

			double dbNumber = Math.Truncate(dbAmount);
			double dbDecimal = Math.Round(dbAmount - dbNumber, 5, MidpointRounding.AwayFromZero); //Lỗi 500.01 - 500 = 0.0099999999999999051
			if (dbDecimal > 0)
				dbDecimal = Convert.ToInt16(dbDecimal.ToString().Substring(2));

			if (dbNumber > 0)
			{
				strRead = ReadNumberE(dbNumber) + strDvt;
				strRead = strRead.Substring(0, 1).ToUpper() + strRead.Substring(1, strRead.Length - 1);
			}

			if (dbDecimal > 0)
				if (dbNumber > 0)
					strRead = strRead + " and " + ReadNumberE(dbDecimal) + strDvt0;
				else
					strRead = ReadNumberE(dbDecimal) + strDvt0;
			else
			{
				if (dbNumber > 0)
					strRead = strRead + " only.";
			}

			return strDau + strRead;
		}

		public static string ReadNumber(Double dbNumber)
		{
			string[] strArrSo = { " không ", " một ", " hai ", " ba ", " bốn ", " năm ", " sáu ", " bảy ", " tám ", " chín " };
			string[] strArrPhanCach = { "", " ngàn ", " triệu ", " tỷ " };
			string strRead = string.Empty;

			if (dbNumber == 0)
				return "Không ";

			long dbNumber0 = Convert.ToInt64(Math.Truncate(dbNumber));

			for (int i = 3; i >= 0; i--)
			{
				long iRead = Convert.ToInt64(Math.Truncate(dbNumber0 / Math.Pow(10, 3 * i)));
				dbNumber0 = dbNumber0 - Convert.ToInt64(iRead * Math.Pow(10, 3 * i));

				if (iRead > 0)
				{
					int iDonvi = Convert.ToInt32(iRead % 10);
					int iChuc = Convert.ToInt32(iRead % 100 - iDonvi);
					int iTram = Convert.ToInt32(iRead % 1000 - iChuc);

					iChuc = iChuc / 10;
					iTram = iTram / 100;

					for (int j = 2; j >= 0; j--)
					{
						if (j == 2) //Hang tram
						{
							if (iTram == 0 && strRead == string.Empty)
								continue;

							strRead += strArrSo[iTram] + " trăm ";
						}
						else if (j == 1) //Hang chuc
						{
							if (iChuc == 0)
								continue;

							if (iChuc == 1) //mười, mươi
								strRead += " mười ";
							else
								strRead += strArrSo[iChuc] + " mươi ";

						}
						else if (j == 0) //Hang dv
						{
							if (iDonvi == 0)
								continue;

							if (iChuc == 0)
							{
								if (strRead != string.Empty)
									strRead += " lẻ ";

							}
							else
							{
								if (iDonvi == 1)
								{
									if (iChuc == 1)
										strRead += " một ";
									else
										strRead += " mốt ";

									continue;
								}
								else if (iDonvi == 5)
								{
									strRead += " lăm ";
									continue;
								}
							}
							strRead += strArrSo[iDonvi];
						}
					}

					strRead += strArrPhanCach[i];
				}
			}

			strRead = strRead.Replace("  ", " ");
			strRead = strRead.Replace("  ", " ").Trim();

			strRead = strRead.Substring(0, 1) + strRead.Substring(1);

			return strRead;
		}

		public static string ReadNumberE(Double dbNumber)
		{

			string[] strArrSo = { " zero ", " one ", " two ", " three ", " four ", " five ", " six ", " seven ", " eight ", " nine " };
			string[] strArrPhanCach = { "", " thousand ", " million ", " billion " };
			string strRead = string.Empty;

			string[] strArrChuc = { "", "", " twenty ", " thirty ", " fourty ", " fifty ", " sixty ", " seventy ", " eighty ", " ninety " };
			string[] strArrMuoi = { " ten ", " eleven ", " twelve ", " thirteen ", " fourteen ", " fifteen ", " sixteen ", " seventeen ", " eighteen ", " nineteen " };

			long dbNumber0 = Convert.ToInt64(Math.Truncate(dbNumber));

			if (dbNumber == 0)
				return "zero " + strArrPhanCach[0];

			for (int i = 3; i >= 0; i--)
			{
				long iRead = Convert.ToInt64(Math.Truncate(dbNumber0 / Math.Pow(10, 3 * i)));
				dbNumber0 = dbNumber0 - Convert.ToInt64(iRead * Math.Pow(10, 3 * i));

				if (iRead > 0)
				{
					int iDonvi = Convert.ToInt32(iRead % 10);
					int iChuc = Convert.ToInt32(iRead % 100 - iDonvi);
					int iTram = Convert.ToInt32(iRead % 1000 - iChuc);

					iChuc = iChuc / 10;
					iTram = iTram / 100;

					for (int j = 2; j >= 0; j--)
					{
						if (j == 2) //Hang tram
						{
							if (iTram == 0 && strRead == string.Empty)
								continue;

							strRead += strArrSo[iTram] + " hundred and ";
						}
						else if (j == 1) //Hang chuc
						{
							if (iChuc == 0 || iChuc == 1)
								continue;

							strRead += strArrChuc[iChuc];
						}
						else if (j == 0) //Hang dv
						{
							if (iDonvi == 0 && iChuc != 1)
								continue;

							if (iChuc == 1) //mười, mươi
								strRead += strArrMuoi[iDonvi];
							else
								strRead += strArrSo[iDonvi];
						}
					}

					strRead += strArrPhanCach[i];
				}
			}

			strRead = strRead.Replace("  ", " ");
			strRead = strRead.Replace("  ", " ").Trim();

			strRead = strRead.Substring(0, 1) + strRead.Substring(1);

			return strRead.Trim();
		}

		public static string ReadNumberC(Double dbNumber)
		{
			string[] strSo = { " 零 ", " 壹 ", " 貳 ", " 叁 ", " 肆 ", " 伍 ", " 陆 ", " 柒 ",
									" 捌 ", " 玖 " };

			string strKq = string.Empty;

			if (dbNumber == 0)
				return " 零 ";

			if (dbNumber == 10)
				return " 拾 ";

			long SoTien0 = Convert.ToInt64(Math.Truncate(dbNumber));
			long SoTien00 = SoTien0;

			for (int i = 3; i >= 0; i--)
			{
				long ivalue = Convert.ToInt64(Math.Truncate(SoTien0 / Math.Pow(10, 3 * i)));
				SoTien0 = SoTien0 - Convert.ToInt64(ivalue * Math.Pow(10, 3 * i));

				if (ivalue > 0)
				{
					int iDonvi = Convert.ToInt32(ivalue % 10);
					int iChuc = Convert.ToInt32(ivalue % 100 - iDonvi);
					int iTram = Convert.ToInt32(ivalue % 1000 - iChuc);

					iChuc = iChuc / 10;
					iTram = iTram / 100;

					for (int j = 2; j >= 0; j--)
					{
						if (j == 2) //Hang tram
						{
							if (iTram == 0 && strKq == string.Empty)
								continue;

							if (i == 3) // ty
								strKq += strSo[iTram] + " 佰 ";
							else
								if (i == 2) // tram trieu
								strKq += strSo[iTram] + " 億 ";
							else
									if (i == 1) // tram ngan
								strKq += strSo[iTram] + " 拾 萬 ";
							else
								strKq += strSo[iTram] + " 佰 ";
						}
						else if (j == 1) //Hang chuc
						{
							if (iChuc == 0)
								continue;

							if (i == 3) // ty
								strKq += strSo[iChuc] + " 拾 ";
							else
								if (i == 2) // chuc trieu
								strKq += strSo[iChuc] + " 仟 萬 ";
							else
									if (i == 1) // chuc ngan
								strKq += strSo[iChuc] + " 萬 ";
							else
										if (SoTien00 < 20)
								strKq += " 拾 ";
							else
								strKq += strSo[iChuc] + " 拾 ";
						}
						else if (j == 0) //Hang dv
						{
							if (iDonvi == 0)
								continue;

							if (iChuc == 0)
							{
								if (strKq != string.Empty)
									strKq += " 零 ";
							}

							if (i == 3) // ty
								strKq += strSo[iDonvi] + " 拾 億 ";
							else
								if (i == 2) // trieu
								strKq += strSo[iDonvi] + " 佰 萬 ";
							else
									if (i == 1) // ngan
								strKq += strSo[iDonvi] + " 仟 ";
							else
								strKq += strSo[iDonvi];
						}
					}
				}
			}
			strKq = strKq.Replace("  ", " ").Trim();
			strKq = strKq.Substring(0, 1) + strKq.Substring(1);

			string str0 = string.Empty;
			string str1 = string.Empty;

			// rut gon nhieu chu 萬 thanh 1 chu
			for (int j = strKq.Length - 1; j >= 0; j--)
			{
				if (strKq[j].ToString() == "萬")
				{
					str0 = strKq.Substring(j, strKq.Length - j);
					str1 = strKq.Substring(0, j);

					break;
				}
			}
			str1 = str1.Replace("萬 ", "");
			strKq = str1 + str0;

			// rut gon nhieu chu 億 thanh 1 chu
			for (int j = strKq.Length - 1; j >= 0; j--)
			{
				if (strKq[j].ToString() == "億")
				{
					str0 = strKq.Substring(j, strKq.Length - j);
					str1 = strKq.Substring(0, j);

					break;
				}
			}
			str1 = str1.Replace("億 ", "");
			strKq = str1 + str0;

			return strKq + " 元 整 ";
		}
        public static int CountSheetExcel(string strFilePath)
        {
            int i = 0;
            if (File.Exists(strFilePath))
            {
                DataTable dtImport = null;
                if (System.IO.File.Exists(strFilePath))
                {
                    Workbook wb = new Workbook(strFilePath);
                    i = wb.Worksheets.Count;
                }
            }
            return i;
        }
		public static DataTable ReadExcel(string strFilePath, int iSheetIndex, int iRowHeader, int iRowEnd, int iColEnd)
		{
			if (File.Exists(strFilePath))
			{
				DataTable dtImport = null;
				if (System.IO.File.Exists(strFilePath))
				{
					Workbook wb = new Workbook(strFilePath);
					Worksheet worksheet = wb.Worksheets[0];
					DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader - 1, 0, iRowEnd, iColEnd);

					dtImport = new DataTable();

					//Tao cau truc bang
					for (int i = 0; i <= iColEnd; i++)
					{
						string strColName = "Column" + i.ToString();

						if (worksheet.Cells[iRowHeader, i].Value != null)
						{
							strColName = worksheet.Cells[iRowHeader, i].Value.ToString();
						}

						if (strColName.StartsWith("Ngay") || strColName.EndsWith("Ngay"))
							dtImport.Columns.Add(strColName, typeof(DateTime));
						else if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
							dtImport.Columns.Add(strColName, typeof(double));
						else
							dtImport.Columns.Add(strColName, typeof(string));
					}

					//Dua du lieu vao: Duyet dong
					for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
					{
						bool bRowNull = true;
						DataRow drNew = dtImport.NewRow();

						//Duyet Cot
						for (int j = 0; j <= iColEnd; j++)
						{
							if (worksheet.Cells[i, j].Value != null)
							{
								string strColName = drNew.Table.Columns[j].ColumnName;

								try
								{
									if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
									{
										if (worksheet.Cells[i, j].Type == CellValueType.IsString)
											drNew[j] = worksheet.Cells[i, j].Value;
										else
											drNew[j] = worksheet.Cells[i, j].DateTimeValue;
									}
									else if (strColName.StartsWith("TIEN") || strColName.StartsWith("PS_NO") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
										drNew[j] = worksheet.Cells[i, j].DoubleValue;
									else
										drNew[j] = worksheet.Cells[i, j].StringValue;

									bRowNull = false;
								}
								catch (Exception ex)
								{
									Common.MsgCancel("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
									continue;
								}
							}
						}

						if (!bRowNull)
						{
							dtImport.Rows.Add(drNew);
						}
					}
				}

				return dtImport;
			}

			return null;
		}
		public static DataTable ReadExcel(string strFilePath, int iSheetIndex)
		{
			if (File.Exists(strFilePath))
			{
				DataTable dtImport = null;
				if (System.IO.File.Exists(strFilePath))
				{
					Workbook wb = new Workbook(strFilePath);
                    Worksheet worksheet = wb.Worksheets[iSheetIndex];

					int iRowEnd = worksheet.Cells.MaxDataRow < 0 ? 1 : worksheet.Cells.MaxDataRow;
					int iColEnd = worksheet.Cells.MaxDataColumn < 0 ? 1 : worksheet.Cells.MaxDataColumn;
					int iRowHeader = worksheet.Cells.MinDataRow < 0 ? 1 : worksheet.Cells.MinDataRow;
					int iColStart = worksheet.Cells.MinColumn;

					DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader, iColStart, iRowEnd, iColEnd);

					dtImport = new DataTable();

					//Tao cau truc bang
					for (int i = 0; i <= iColEnd; i++)
					{
						string strColName = "Column" + i.ToString();

						if (worksheet.Cells[iRowHeader, i].Value != null)
						{
							strColName = worksheet.Cells[iRowHeader, i].Value.ToString();
						}

						if (strColName.StartsWith("Ngay") || strColName.EndsWith("Ngay"))
							dtImport.Columns.Add(strColName, typeof(DateTime));
						else if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
							dtImport.Columns.Add(strColName, typeof(double));
						else
							dtImport.Columns.Add(strColName, typeof(string));
					}

					//Dua du lieu vao: Duyet dong
					for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
					{
						bool bRowNull = true;
						DataRow drNew = dtImport.NewRow();

						//Duyet Cot
						for (int j = 0; j <= iColEnd; j++)
						{
							if (worksheet.Cells[i, j].Value != null)
							{
								string strColName = drNew.Table.Columns[j].ColumnName;

								try
								{
									if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
									{
										if (worksheet.Cells[i, j].Type == CellValueType.IsString)
											drNew[j] = worksheet.Cells[i, j].Value;
										else
											drNew[j] = worksheet.Cells[i, j].DateTimeValue;
									}
									else if (strColName.StartsWith("TIEN") || strColName.StartsWith("PS_NO") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
										drNew[j] = worksheet.Cells[i, j].DoubleValue;
									else
										drNew[j] = worksheet.Cells[i, j].StringValue;

									bRowNull = false;
								}
								catch (Exception ex)
								{
									Common.MsgCancel("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
									continue;
								}
							}
						}

						if (!bRowNull)
						{
							dtImport.Rows.Add(drNew);
						}
					}
				}

				return dtImport;
			}

			return null;
		}
        public static DataTable ReadExcel(string strFilePath)
        {
            if (File.Exists(strFilePath))
            {
                DataTable dtImport = null;
                if (System.IO.File.Exists(strFilePath))
                {
                    Workbook wb = new Workbook(strFilePath);
                    Worksheet worksheet = wb.Worksheets[0];

                    int iRowEnd = worksheet.Cells.MaxDataRow < 0 ? 1 : worksheet.Cells.MaxDataRow;
                    int iColEnd = worksheet.Cells.MaxDataColumn < 0 ? 1 : worksheet.Cells.MaxDataColumn;
                    int iRowHeader = worksheet.Cells.MinDataRow < 0 ? 1 : worksheet.Cells.MinDataRow;
                    int iColStart = worksheet.Cells.MinColumn;

                    DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader, iColStart, iRowEnd, iColEnd);

                    dtImport = new DataTable();

                    //Tao cau truc bang
                    for (int i = 0; i <= iColEnd; i++)
                    {
                        string strColName = "Column" + i.ToString();

                        if (worksheet.Cells[iRowHeader, i].Value != null)
                        {
                            strColName = worksheet.Cells[iRowHeader, i].Value.ToString();
                        }

                        if (strColName.StartsWith("Ngay") || strColName.EndsWith("Ngay"))
                            dtImport.Columns.Add(strColName, typeof(DateTime));
                        else if (strColName.StartsWith("Tien") || strColName.StartsWith("Ps_No") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
                            dtImport.Columns.Add(strColName, typeof(double));
                        else
                            dtImport.Columns.Add(strColName, typeof(string));
                    }

                    //Dua du lieu vao: Duyet dong
                    for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
                    {
                        bool bRowNull = true;
                        DataRow drNew = dtImport.NewRow();

                        //Duyet Cot
                        for (int j = 0; j <= iColEnd; j++)
                        {
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                string strColName = drNew.Table.Columns[j].ColumnName;

                                try
                                {
                                    if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
                                    {
                                        if (worksheet.Cells[i, j].Type == CellValueType.IsString)
                                            drNew[j] = worksheet.Cells[i, j].Value;
                                        else
                                            drNew[j] = worksheet.Cells[i, j].DateTimeValue;
                                    }
                                    else if (strColName.StartsWith("TIEN") || strColName.StartsWith("PS_NO") || strColName.StartsWith("Ps_Co") || strColName.StartsWith("Du_Dau") || strColName.StartsWith("Du_Cuoi") || strColName.StartsWith("Du_No") || strColName.StartsWith("Du_Co") || strColName.StartsWith("SO_LUONG") || strColName.StartsWith("GIA"))
                                        drNew[j] = worksheet.Cells[i, j].DoubleValue;
                                    else
                                        drNew[j] = worksheet.Cells[i, j].StringValue;

                                    bRowNull = false;
                                }
                                catch (Exception ex)
                                {
                                    Common.MsgCancel("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
                                    continue;
                                }
                            }
                        }

                        if (!bRowNull)
                        {
                            dtImport.Rows.Add(drNew);
                        }
                    }
                }

                return dtImport;
            }

            return null;
        }
		public static DataTable ReadExcelMSOffice(string strFilePath, int iSheetIndex, int iRowHeader, int iRowEnd, int iColEnd)
		{
			if (File.Exists(strFilePath))
			{
				Microsoft.Office.Interop.Excel.Application o = null;
				Microsoft.Office.Interop.Excel.Workbook workbook = null;
				Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
				Microsoft.Office.Interop.Excel.Range range = null;
				object obj2 = Missing.Value;
				try
				{
					int num;
					string columnName;
					o = new Microsoft.Office.Interop.Excel.Application();
					object updateLinks = 2;
					object readOnly = true;
					object format = obj2;
					object password = obj2;
					object writeResPassword = obj2;
					object ignoreReadOnlyRecommended = true;
					object origin = obj2;
					object delimiter = obj2;
					object editable = false;
					object notify = false;
					object converter = obj2;
					object addToMru = false;
					object local = obj2;
					object corruptLoad = obj2;



					workbook = o.Workbooks.Open(strFilePath, updateLinks, readOnly, format, password, writeResPassword, ignoreReadOnlyRecommended, origin, delimiter, editable, notify, converter, addToMru, local, corruptLoad);
					worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[iSheetIndex];
					range = worksheet.get_Range(o.Cells[iRowHeader, 1], o.Cells[iRowEnd, iColEnd]);
					DataTable table = new DataTable();
					for (num = 1; num <= iColEnd; num++)
					{
						columnName = "Column" + num.ToString();
						if (((Microsoft.Office.Interop.Excel.Range)range[iRowHeader, num]).Value2 != null)
						{
							columnName = ((Microsoft.Office.Interop.Excel.Range)range[iRowHeader, num]).Value2.ToString();
						}
						if (columnName.StartsWith("Ngay"))
						{
							table.Columns.Add(columnName, typeof(DateTime));
						}
						else if ((((columnName.StartsWith("Tien") || columnName.StartsWith("Ps_No")) || (columnName.StartsWith("Ps_Co") || columnName.StartsWith("Du_Dau"))) || ((columnName.StartsWith("Du_Cuoi") || columnName.StartsWith("Du_No")) || (columnName.StartsWith("Du_Co") || columnName.StartsWith("So_Luong")))) || columnName.StartsWith("Gia"))
						{
							table.Columns.Add(columnName, typeof(double));
						}
						else
						{
							table.Columns.Add(columnName, typeof(string));
						}
					}
					for (num = Convert.ToInt32((int)(iRowHeader + 1)); num <= iRowEnd; num++)
					{
						bool flag = true;
                        double dbValue = 0;
						DataRow dr = table.NewRow();
						for (int i = 1; i <= iColEnd; i++)
						{
							if (((Microsoft.Office.Interop.Excel.Range)range[num, i]).Value2 != null)
							{
								columnName = dr.Table.Columns[i - 1].ColumnName;
								try
								{
									if (columnName.StartsWith("Ngay"))
									{
										dr[i - 1] = Convert.ToDateTime(((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing));
									}
									else if ((((columnName.StartsWith("Tien") || columnName.StartsWith("Ps_No")) || (columnName.StartsWith("Ps_Co") || columnName.StartsWith("Du_Dau"))) || ((columnName.StartsWith("Du_Cuoi") || columnName.StartsWith("Du_No")) || (columnName.StartsWith("Du_Co") || columnName.StartsWith("So_Luong")))) || columnName.StartsWith("Gia"))
									{
                                        dbValue = double.TryParse(((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing), out dbValue);
                                        dr[i - 1] = dbValue;// Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing));
									}
									else
									{
										dr[i - 1] = ((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing);
									}
									flag = false;
								}
								catch (Exception)
								{
									MsgCancel("Kh\x00f4ng nhận được dữ liệu [" + columnName + "] = " + ((Microsoft.Office.Interop.Excel.Range)range[num, i]).Value2.ToString());
								}
							}
						}
						if (!flag)
						{
							SetDefaultDataRow(ref dr);
							table.Rows.Add(dr);
						}
					}
					GC.Collect();
					GC.WaitForPendingFinalizers();
					Marshal.FinalReleaseComObject(range);
					Marshal.FinalReleaseComObject(worksheet);
					workbook.Close(Type.Missing, Type.Missing, Type.Missing);
					Marshal.FinalReleaseComObject(workbook);
					o.Quit();
					Marshal.FinalReleaseComObject(o);
					return table;
				}
				catch (Exception)
				{
					return null;
				}
			}
			return null;
		}
		
		public static Microsoft.Office.Interop.Excel.Range ReadExcelRange(string strFilePath)
		{
			if (File.Exists(strFilePath))
			{
				Microsoft.Office.Interop.Excel.Application o = null;
				Microsoft.Office.Interop.Excel.Workbook workbook = null;
				Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
				Microsoft.Office.Interop.Excel.Worksheet worksheetPv = null;
				Microsoft.Office.Interop.Excel.Range Userange = null;
				Microsoft.Office.Interop.Excel.Range range = null;
				object obj2 = Missing.Value;
				try
				{
					int num;
					string columnName;
					o = new Microsoft.Office.Interop.Excel.Application();
					object updateLinks = 2;
					object readOnly = true;
					object format = obj2;
					object password = obj2;
					object writeResPassword = obj2;
					object ignoreReadOnlyRecommended = true;
					object origin = obj2;
					object delimiter = obj2;
					object editable = false;
					object notify = false;
					object converter = obj2;
					object addToMru = false;
					object local = obj2;
					object corruptLoad = obj2;
					int iRowHeader, iRowEnd, iColEnd;


					workbook = o.Workbooks.Open(strFilePath, updateLinks, readOnly, format, password, writeResPassword, ignoreReadOnlyRecommended, origin, delimiter, editable, notify, converter, addToMru, local, corruptLoad);
					worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
					worksheetPv = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[2];
					Userange = worksheet.UsedRange;
					iRowEnd = Userange.Rows.Count;
					iColEnd = Userange.Columns.Count;
					iRowHeader = 1;

					range = Userange;// worksheet.get_Range(o.Cells[iRowHeader, 1], o.Cells[iRowEnd, iColEnd]);
									 //Microsoft.Office.Interop.Excel.PivotCache cache = workbook.PivotTables.Add(range);
									 //Microsoft.Office.Interop.Excel.PivotTable pt = workbook.PivotTables.Add("report", worksheet.Range["A1"], cache);
									 ////Microsoft.Office.Interop.Excel.PivotTable pt = sheet2.PivotTables.Add("Pivot Table", sheet.Range["A1"], cache);

					////Set Row Labels
					//var r1 = pt.PivotFields("VendorNo");
					////r1.Axis = AxisTypes.Row;
					//pt.RowHeaderCaption = "VendorNo";

					return range;
				}
				catch (Exception e)
				{
					return null;
				}
			}
			return null;
		}
		public static DataSet ReadExcelToDataSet(string strFilePath)
		{
			DataSet dsOutPut = new DataSet();

			if (File.Exists(strFilePath))
			{
				DataTable dtImport = null;
				if (System.IO.File.Exists(strFilePath))
				{

					Workbook wb = new Workbook(strFilePath);

					for (int iSheet = 0; iSheet < wb.Worksheets.Count; iSheet++)
					{
						Worksheet worksheet = wb.Worksheets[iSheet];
						string tbName = wb.Worksheets[iSheet].Name;
						dtImport = ReadExcel(strFilePath, iSheet);						
						dtImport.Namespace = tbName;
                        dsOutPut.Tables.Add(dtImport);
                    }


				}

				return dsOutPut;
			}

			return null;
		}

		public static DataTable ReadExcelMSOffice(string strFilePath)
		{
			if (File.Exists(strFilePath))
			{
				Microsoft.Office.Interop.Excel.Application o = null;
				Microsoft.Office.Interop.Excel.Workbook workbook = null;
				Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
				Microsoft.Office.Interop.Excel.Range Userange = null;
				Microsoft.Office.Interop.Excel.Range range = null;
				object obj2 = Missing.Value;
				try
				{
					int num;
					string columnName;
					o = new Microsoft.Office.Interop.Excel.Application();
					object updateLinks = 2;
					object readOnly = true;
					object format = obj2;
					object password = obj2;
					object writeResPassword = obj2;
					object ignoreReadOnlyRecommended = true;
					object origin = obj2;
					object delimiter = obj2;
					object editable = false;
					object notify = false;
					object converter = obj2;
					object addToMru = false;
					object local = obj2;
					object corruptLoad = obj2;
					int iRowHeader, iRowEnd, iColEnd;


					workbook = o.Workbooks.Open(strFilePath, updateLinks, readOnly, format, password, writeResPassword, ignoreReadOnlyRecommended, origin, delimiter, editable, notify, converter, addToMru, local, corruptLoad);
					worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
					Userange = worksheet.UsedRange;
					iRowEnd = Userange.Rows.Count;
					iColEnd = Userange.Columns.Count;
					iRowHeader = 1;

					range = Userange;// worksheet.get_Range(o.Cells[iRowHeader, 1], o.Cells[iRowEnd, iColEnd]);
					DataTable table = new DataTable();
					for (num = 1; num <= iColEnd; num++)
					{
						columnName = "Column" + num.ToString();
						if (((Microsoft.Office.Interop.Excel.Range)range[iRowHeader, num]).Value2 != null)
						{
							columnName = ((Microsoft.Office.Interop.Excel.Range)range[iRowHeader, num]).Value2.ToString();
						}
						if (columnName.StartsWith("Ngay"))
						{
							table.Columns.Add(columnName, typeof(DateTime));
						}
						else if ((((columnName.StartsWith("Tien") || columnName.StartsWith("Ps_No")) || (columnName.StartsWith("Ps_Co") || columnName.StartsWith("Du_Dau"))) || ((columnName.StartsWith("Du_Cuoi") || columnName.StartsWith("Du_No")) || (columnName.StartsWith("Du_Co") || columnName.StartsWith("So_Luong")))) || columnName.StartsWith("Gia"))
						{
							table.Columns.Add(columnName, typeof(double));
						}
						else
						{
							table.Columns.Add(columnName, typeof(string));
						}
					}
					for (num = Convert.ToInt32((int)(iRowHeader + 1)); num <= iRowEnd; num++)
					{
						bool flag = true;
						DataRow dr = table.NewRow();
						for (int i = 1; i <= iColEnd; i++)
						{
							if (((Microsoft.Office.Interop.Excel.Range)range[num, i]).Value2 != null)
							{
								columnName = dr.Table.Columns[i - 1].ColumnName;
								try
								{
									if (columnName.StartsWith("Ngay"))
									{
										dr[i - 1] = Convert.ToDateTime(((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing));
									}
									else if ((((columnName.StartsWith("Tien") || columnName.StartsWith("Ps_No")) || (columnName.StartsWith("Ps_Co") || columnName.StartsWith("Du_Dau"))) || ((columnName.StartsWith("Du_Cuoi") || columnName.StartsWith("Du_No")) || (columnName.StartsWith("Du_Co") || columnName.StartsWith("So_Luong")))) || columnName.StartsWith("Gia"))
									{
										dr[i - 1] = Convert.ToDouble(((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing));
									}
									else
									{
										dr[i - 1] = ((Microsoft.Office.Interop.Excel.Range)range[num, i]).Cells.get_Value(Type.Missing);
									}
									flag = false;
								}
								catch (Exception)
								{
									MsgCancel("Kh\x00f4ng nhận được dữ liệu [" + columnName + "] = " + ((Microsoft.Office.Interop.Excel.Range)range[num, i]).Value2.ToString());
								}
							}
						}
						if (!flag)
						{
							SetDefaultDataRow(ref dr);
							table.Rows.Add(dr);
						}
					}
					GC.Collect();
					GC.WaitForPendingFinalizers();
					Marshal.FinalReleaseComObject(range);
					Marshal.FinalReleaseComObject(worksheet);
					workbook.Close(Type.Missing, Type.Missing, Type.Missing);
					Marshal.FinalReleaseComObject(workbook);
					o.Quit();
					Marshal.FinalReleaseComObject(o);
					return table;
				}
				catch (Exception e)
				{
					return null;
				}
			}
			return null;
		}
		public static string ReadDate(DateTime Ngay_Ct1, DateTime Ngay_Ct2, enuLanguageType LanguageType)
		{
			string strDateV = string.Empty;
			string strDateE = string.Empty;
			string strDateO = string.Empty;
			int iMonth1 = 0;
			int iMonth2 = 0;
			char cTimeType = 'D';//Loại ngày
			int iYear1 = 0, iYear2 = 0;
			CultureInfo CultureE = new CultureInfo("en-US");

			iYear1 = Ngay_Ct1.Year;
			iYear2 = Ngay_Ct2.Year;

			if (Ngay_Ct1.Day == 1 && Ngay_Ct2.AddDays(1).Day == 1 && iYear1 == iYear2)
			{
				iMonth1 = Ngay_Ct1.Month;
				iMonth2 = Ngay_Ct2.Month;
				cTimeType = 'M'; // tạm thời bỏ
			}

			if (cTimeType == 'D')
			{//Theo ngày
				if (Ngay_Ct1 == Ngay_Ct2)
				{
					strDateV = "Ngày " + Ngay_Ct1.ToString("dd/MM/yyyy");
					strDateE = Ngay_Ct1.ToString("MMMM dd yyyy", CultureE);
					strDateO = Ngay_Ct1.ToString("MMMM dd yyyy", CultureE);
				}
				else
				{
					strDateV = "Từ ngày " + Ngay_Ct1.ToString("dd/MM/yyyy") + " đến ngày " + Ngay_Ct2.ToString("dd/MM/yyyy");
					strDateE = "From " + Ngay_Ct1.ToString("MMMM dd yyyy", CultureE) + " to " + Ngay_Ct2.ToString("MMMM dd yyyy", CultureE);
					strDateO = "" + Ngay_Ct1.ToString("dd/MM/yyyy") + " -> " + Ngay_Ct2.ToString("dd/MM/yyyy");
				}
			}
			else
			{//Theo tháng				
				if (iYear1 != iYear2)
				{
					strDateV = "Từ tháng " + Ngay_Ct1.Month + " năm " + Ngay_Ct1.Year + " đến tháng " + Ngay_Ct2.Month + " năm " + Ngay_Ct2.Year;
					strDateE = "From " + Ngay_Ct1.ToString("MMMM", CultureE) + " " + Ngay_Ct1.Year + " to " + Ngay_Ct2.ToString("MMMM", CultureE) + " " + Ngay_Ct2.Year;
					strDateO = "" + Ngay_Ct1.Month + " / " + Ngay_Ct1.Year + " --> " + Ngay_Ct2.Month + " / " + Ngay_Ct2.Year;
				}
				else if (iMonth2 + 1 - iMonth1 == 12)//Cả năm
				{
					strDateV = "Năm " + Ngay_Ct1.Year;
					strDateE = "Year " + Ngay_Ct1.Year;
					strDateO = "" + Ngay_Ct1.Year;
				}
				else if (iMonth1 == iMonth2)
				{
					strDateV = "Tháng " + Ngay_Ct1.Month + " năm " + Ngay_Ct1.Year;
					strDateE = Ngay_Ct1.ToString("MMMM", CultureE) + " " + Ngay_Ct1.Year;
					strDateO = " " + Ngay_Ct1.Month + " / " + Ngay_Ct1.Year;
				}
				else if (iMonth2 + 1 - iMonth1 == 6 && iMonth1 == 1)
				{
					strDateV = "6 tháng đầu năm " + iYear1;
					strDateE = "1 -- > 6 /" + iYear1;
					strDateO = "1 -- > 6 /" + iYear1;
				}
				else if (iMonth2 + 1 - iMonth1 == 6 && iMonth1 == 7)
				{
					strDateV = "6 tháng cuối năm " + iYear1;
					strDateE = "6 -- > 12 /" + iYear1;
					strDateO = "6 -- > 12 /" + iYear1;
				}
				else if (iMonth2 + 1 - iMonth1 == 9 && iMonth1 == 1)
				{
					strDateV = "9 tháng đầu năm " + iYear1;
					strDateE = "1 -- > 9/" + iYear1;
					strDateO = "1 -- > 9/" + iYear1;
				}
				else if (iMonth1 == 1 && iMonth1 == 3)
				{
					strDateV = "Quý I năm " + Ngay_Ct1.Year;
					strDateE = "First Quarter " + Ngay_Ct1.Year;
					strDateO = "I - " + Ngay_Ct1.Year;
				}
				else if (iMonth1 == 4 && iMonth1 == 6)
				{
					strDateV = "Quý II năm " + Ngay_Ct1.Year;
					strDateE = "Second Quarter " + Ngay_Ct1.Year;
					strDateO = "II - " + Ngay_Ct1.Year;
				}
				else if (iMonth1 == 7 && iMonth1 == 9)
				{
					strDateV = "Quý III năm " + Ngay_Ct1.Year;
					strDateE = "Third Quarter " + Ngay_Ct1.Year;
					strDateO = "III - " + Ngay_Ct1.Year;
				}
				else if (iMonth1 == 10 && iMonth1 == 12)
				{
					strDateV = "Quý IV năm " + Ngay_Ct1.Year;
					strDateE = "Fourth Quarter " + Ngay_Ct1.Year;
					strDateO = "IV - " + Ngay_Ct1.Year;
				}
				else
				{
					strDateV = "Từ tháng " + iMonth1 + " đến tháng " + iMonth2 + " năm " + Ngay_Ct2.Year;
					strDateE = "From " + Ngay_Ct1.ToString("MMMM", CultureE) + " " + Ngay_Ct1.Year + " to " + Ngay_Ct2.ToString("MMMM", CultureE) + " " + Ngay_Ct2.Year;
					strDateO = Languages.GetLanguage("FROM") + iMonth1 + " --> " + iMonth2 + Languages.GetLanguage("YEAR") + Ngay_Ct2.Year;
				}
			}

			return LanguageType == enuLanguageType.Vietnamese ? strDateV : LanguageType == enuLanguageType.English ? strDateE : strDateO;
		}
		public static string ReadDate(DateTime Ngay_Ct, enuLanguageType LanguageType)
		{
			string strDateV = string.Empty;
			string strDateE = string.Empty;
			string strDateO = string.Empty;

			//strDateV = "Ngày " + Ngay_Ct.Day + " Tháng " + Ngay_Ct.Month + " Năm " + Ngay_Ct.Year;
			//strDateE = "Ngày " + Ngay_Ct.Day + " Tháng " + Ngay_Ct.Month + " Năm " + Ngay_Ct.Year;

			string strNgay = string.Empty;
			string strThang = string.Empty;

			if (Ngay_Ct.Day <= 9)
				strNgay = "0" + Ngay_Ct.Day;
			else
				strNgay = Ngay_Ct.Day.ToString();

			if (Ngay_Ct.Month <= 9)
				strThang = "0" + Ngay_Ct.Month;
			else
				strThang = Ngay_Ct.Month.ToString();

			strDateV = "Ngày  " + strNgay + "  tháng  " + strThang + "  năm  " + Ngay_Ct.Year;
			strDateE = "Date:  " + strNgay + "/" + strThang + "/" + Ngay_Ct.Year;
			strDateO = "天  " + strNgay + "  月  " + strThang + "  年  " + Ngay_Ct.Year;

			return LanguageType == enuLanguageType.Vietnamese ? strDateV : LanguageType == enuLanguageType.English ? strDateE : strDateO;
		}


		#endregion
		public static void ShowStatus(string strStatusText)
		{
			if (Element.frmMain != null)
			{

				((frmMain)Element.frmActiveMain).ssMain.ShowStatus(strStatusText);
				//lock (Element.frmMain) ;
			}
		}

		public static void EndShowStatus()
		{
			if (Element.frmMain != null)
				((frmMain)Element.frmActiveMain).ssMain.EndShowStatus();
		}
		public static void ShowStatusReminder()
		{

			try
			{
				if (Element.frmMain == null)
					return;
				frmMain frmM = (frmMain)Elements.Element.frmMain;
				tbTabControl tbTabMain = frmM.tbTabMain;
				string strNameParent = string.Empty;
				if (frmM.tbTabMain.TabPages.Count > 0)
				{
					((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
				}
				else
					((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = false;
			}
			catch
			{

			}
		}


		#region MessageBox

		/// <summary>
		/// Thông báo lựa chọn Yes_No, Yes: return true, No: return false
		/// </summary>
		/// <param name="strMsg">Chuỗi thông báo</param>
		/// <returns></returns>
		public static bool MsgYes_No(string strMsg)
		{
			if (MessageBox.Show(strMsg, "Message",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)

				return true;
			else
				return false;

		}

		/// <summary>
		/// Thông báo lựa chọn Yes_No, Yes: return true, No: return false
		/// </summary>
		/// <param name="strMsg">Chuỗi thông báo</param>
		/// <param name="strDefaultY_N">"Y" mặc định là chọn Yes, "N" mặc định là chọn No</param>
		/// <returns></returns>
		public static bool MsgYes_No(string strMsg, string strDefaultY_N)
		{
			if (MessageBox.Show(strMsg, "Message",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						strDefaultY_N == "Y" ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes)

				return true;
			else
				return false;

		}
		public static bool MsgYes_No_Cancel(string strMsg, string strDefaultY_N)
		{
			if (MessageBox.Show(strMsg, "Message",
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Question,
						strDefaultY_N == "Y" ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes)

				return true;
			else
				return false;

		}
		public static bool MsgOk(string strMsg)
		{
			MessageBox.Show(strMsg, "Message",
						MessageBoxButtons.OK,
						MessageBoxIcon.None);

			return true;
		}

		public static bool MsgCancel(string strMsg)
		{
			MessageBox.Show(strMsg, "Message",
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop);

			return true;
		}

		#endregion

		public static void Export(object ExportControl)
		{
			string strTitle = ((Control)ExportControl).FindForm().Text;
			if (strTitle.Contains(","))
				strTitle = strTitle.Split(',')[0];

			Export(ExportControl, strTitle, string.Empty);
		}

		public static void Export(object ExportControl, string strTitle, string strSubTitle)
		{
			Dictionary<string, string> dicHeader = new Dictionary<string, string>();

			dicHeader["TEN_DV"] = Epoint.Systems.Elements.Element.sysTen_Dvi.ToUpper();
			dicHeader["DIA_CHI_DV"] = Element.sysDia_Chi_Dv;
			dicHeader["TITLE"] = strTitle.ToUpper();

			frmExport frm = new frmExport();
			frm.Load(strTitle);

			if (!frm.isAccept)
				return;

			string strPath = frm.strPath;
			string strExportType = frm.cboExportType.Text;

			if (strExportType.StartsWith("1"))
			{
				ExportExcel(ExportControl, strTitle, strSubTitle, strPath, frm.enuFormatFont.Text.Trim());

				if (File.Exists(strPath) && frm.chkOpenFile.Checked)
					Process.Start(strPath);
			}
			else if (strExportType.StartsWith("5")) //Export to Foxpro
			{
				ExportFoxpro(ExportControl, strTitle, strPath, frm.enuFormatFont.Text.Trim());

				if (File.Exists(strPath))
					EpointMessage.MsgOk(EpointMessage.GetMessage("DATA_EXPORT") + strPath);
			}
			//else
			//{
			//    rptQuickReport repFile = BuildReport(ExportControl, dicHeader, true);
			//    if (repFile == null)
			//        return;

			//    switch (strExportType.Substring(0, 1))
			//    {
			//        case "1": //enuExportType.Excel:
			//            DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
			//            xlsExport.UseCellMerging = true;
			//            xlsExport.Export(repFile.Document, strPath);
			//            break;
			//        case "2": //enuExportType.Word:
			//            DataDynamics.ActiveReports.Export.Rtf.RtfExport rftExport = new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
			//            rftExport.Export(repFile.Document, strPath);
			//            break;
			//        case "3": //enuExportType.PDF:
			//            DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			//            pdfExport.Export(repFile.Document, strPath);
			//            break;
			//        case "4": //enuExportType.Html:
			//            DataDynamics.ActiveReports.Export.Html.HtmlExport htmlExport = new DataDynamics.ActiveReports.Export.Html.HtmlExport();
			//            htmlExport.Export(repFile.Document, strPath);
			//            break;
			//    }

			//    if (File.Exists(strPath) && frm.chkOpenFile.Checked)
			//        Process.Start(strPath);
			//}

		}

		public static void RunQuickReport(object ExportControl)
		{
			Dictionary<string, string> dicHeader = new Dictionary<string, string>();

			dicHeader["TEN_DV"] = Epoint.Systems.Elements.Element.sysTen_Dvi.ToUpper();
			dicHeader["DIA_CHI_DV"] = Element.sysDia_Chi_Dv;

			string strTieu_De = ((Control)ExportControl).FindForm().Text;
			if (strTieu_De.Contains(","))
				strTieu_De = strTieu_De.Split(',')[0];

			dicHeader["TITLE"] = strTieu_De.ToUpper();

			rptQuickReport repFile = BuildReport(ExportControl, dicHeader, false);
			if (repFile == null)
				return;

			frmQuickReport frm = new frmQuickReport();
			frm.Load(repFile);
		}

		public static rptQuickReport BuildReport(object ExportControl, Dictionary<string, string> dicHeader, bool bExport)
		{
			DataTable dtReport;
			Dictionary<string, ColumnInfo> ColumnInfos = new Dictionary<string, ColumnInfo>();
			int iSumColumnWidth = 0;

			#region dgvExport, tlExport
			if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
			{
				dgvControl dgvExport = (dgvControl)ExportControl;

				if (dgvExport.DataSource == null)
					return null;

				if (dgvExport.DataSource.GetType().Name != "BindingSource")
					return null;

				BindingSource bdsExport = (BindingSource)dgvExport.DataSource;
				if (bdsExport == null)
					return null;

				dtReport = (DataTable)bdsExport.DataSource;
				if (dtReport == null)
					return null;


				string strZone = dgvExport.strZone;
				foreach (DataGridViewColumn dgvc in dgvExport.Columns)
				{
					if (dgvc.Visible && dgvc.Name.Trim() != string.Empty && dgvc.Width > 5)
						if (dtReport.Columns.Contains(dgvc.Name.Trim()))
						{
							string strColumnName = dgvc.Name;

							ColumnInfos[strColumnName] = new ColumnInfo(strColumnName, dgvc.HeaderText, dgvc.Width, dgvExport.ColumnInfos[strZone + "." + strColumnName].Type, dgvExport.ColumnInfos[strZone + "." + strColumnName].Scale, false, "3");
							iSumColumnWidth += dgvc.Width;
						}
				}

			}
			else if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
			{
				tlControl tlExport = (tlControl)ExportControl;

				if (tlExport.DataSource == null)
					return null;

				if (tlExport.DataSource.GetType().Name != "BindingSource")
					return null;

				BindingSource bdsExport = (BindingSource)tlExport.DataSource;
				if (bdsExport == null)
					return null;

				dtReport = (DataTable)bdsExport.DataSource;
				if (dtReport == null)
					return null;

				string strZone = tlExport.strZone;
				foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tlc in tlExport.Columns)
				{
					if (tlc.Visible && tlc.FieldName.Trim() != string.Empty && tlc.Width > 20)
						if (dtReport.Columns.Contains(tlc.FieldName.Trim()))
						{
							string strColumnName = tlc.FieldName;

							ColumnInfos[strColumnName] = new ColumnInfo(strColumnName, tlc.Caption, tlc.Width, tlExport.ColumnInfos[strZone + "." + strColumnName].Type, tlExport.ColumnInfos[strZone + "." + strColumnName].Scale, false, "3");
							iSumColumnWidth += tlc.Width;
						}
				}
			}
			else
				return null;

			#endregion

			#region  repFile
			rptQuickReport repFile = new rptQuickReport();
			repFile.PageSettings.DefaultPaperSize = false;

			repFile.PageSettings.Margins.Top = 0F;
			repFile.PageSettings.Margins.Bottom = 0F;
			repFile.PageSettings.Margins.Left = 0F;
			repFile.PageSettings.Margins.Right = 0F;

			repFile.pageHeader.Height = 1F;
			repFile.pageFooter.Height = 1F;

			float DetailHeight = 0.25F;
			repFile.detail.Height = DetailHeight;

			if (bExport)
			{
				repFile.reportHeader.Height = repFile.reportHeader.Height + 0.5F;
				repFile.pageHeader.Height = 0;
				repFile.pageFooter.Height = 0;
				repFile.reportFooter.Height = 0;
			}

			if (iSumColumnWidth <= 827)
			{
				repFile.PrintWidth = 8.27F;
				repFile.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
				repFile.Document.Printer.PaperKind = System.Drawing.Printing.PaperKind.A4;
				repFile.Document.Printer.Landscape = false;
			}
			else if (iSumColumnWidth > 827 && iSumColumnWidth <= 1169)
			{
				repFile.PrintWidth = 11.69F;
				repFile.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
				repFile.Document.Printer.PaperKind = System.Drawing.Printing.PaperKind.A4;
				repFile.Document.Printer.Landscape = true;
			}
			else
			{
				repFile.PrintWidth = 16.54F;
				repFile.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A3;
				repFile.Document.Printer.PaperKind = System.Drawing.Printing.PaperKind.A3;
				repFile.Document.Printer.Landscape = true;
			}

			#endregion

			#region TextBox, Label, Line
			repFile.lblTieu_De.Left = (float)repFile.PrintWidth / 2 - (float)repFile.lblTieu_De.Width / 2;

			float fLeftMargin = 30F;
			float x = fLeftMargin;
			float fX = 0F;
			foreach (string strColumnName in ColumnInfos.Keys)
			{
				int iColumnWidth = ColumnInfos[strColumnName].Width;
				string strText = ColumnInfos[strColumnName].Description;

				DataDynamics.ActiveReports.TextBox txt = new DataDynamics.ActiveReports.TextBox();
				DataDynamics.ActiveReports.Label lbl = new DataDynamics.ActiveReports.Label();
				DataDynamics.ActiveReports.Line lineHeader = new DataDynamics.ActiveReports.Line();
				DataDynamics.ActiveReports.Line lineDetail = new DataDynamics.ActiveReports.Line();

				fX = x / 100F;

				//Label 
				lbl.Location = new System.Drawing.PointF(fX, bExport ? repFile.reportHeader.Height : repFile.pageHeader.Height - 0.2F);
				lbl.Width = (float)iColumnWidth / 100;
				lbl.Text = strText;
				lbl.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
				lbl.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
				lbl.Name = "lbl" + strColumnName;

				//TextBox				
				txt.Location = new System.Drawing.PointF(fX + 0.02F, 0.02F);
				txt.Width = (float)iColumnWidth / 100 - 0.04F;
				txt.DataField = strColumnName;
				txt.Name = "txt" + strColumnName;
				txt.Font = new System.Drawing.Font("Arial", 8);

				//lineHeader
				lineHeader.X1 = lineHeader.X2 = fX;
				lineHeader.Y1 = repFile.pageHeader.Height - DetailHeight + 0.01F;
				lineHeader.Y2 = repFile.pageHeader.Height;
				lineHeader.Name = "lineHeader" + strColumnName;

				//lineDetail
				lineDetail.X1 = lineDetail.X2 = fX;
				lineDetail.Y1 = 0;
				lineDetail.Y2 = DetailHeight - 0.01F;
				lineDetail.Name = "lineDetail" + strColumnName;

				if (ColumnInfos[strColumnName].Type == enuColumnType.Numeric)
				{
					txt.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;

					switch (ColumnInfos[strColumnName].Scale)
					{
						case 0:
							txt.OutputFormat = "#,##0";
							break;
						case 1:
							txt.OutputFormat = "#,##0.0";
							break;
						case 2:
							txt.OutputFormat = "#,##0.00";
							break;
						case 3:
							txt.OutputFormat = "#,##0.000";
							break;
						case 4:
							txt.OutputFormat = "#,##0.0000";
							break;
					}


				}
				else
				{
					if (ColumnInfos[strColumnName].Type == enuColumnType.DateTime)
						txt.OutputFormat = "dd/MM/yyyy";

					txt.Alignment = DataDynamics.ActiveReports.TextAlignment.Left;
				}
				x += iColumnWidth;

				repFile.detail.Controls.Add(txt);
				repFile.detail.Controls.Add(lineDetail);

				if (bExport)
				{
					repFile.reportHeader.Controls.Add(lbl);
					repFile.reportHeader.Controls.Add(lineHeader);
				}
				else
				{
					repFile.pageHeader.Controls.Add(lbl);
					repFile.pageHeader.Controls.Add(lineHeader);
				}
			}

			fX = (float)fLeftMargin / 100F;
			//lineHeaderEnd
			DataDynamics.ActiveReports.Line lineHeaderEnd = new DataDynamics.ActiveReports.Line();
			lineHeaderEnd.X1 = lineHeaderEnd.X2 = fX + (float)iSumColumnWidth / 100;
			lineHeaderEnd.Y1 = repFile.pageHeader.Height - DetailHeight + 0.01F;
			lineHeaderEnd.Y2 = repFile.pageHeader.Height;
			lineHeaderEnd.Name = "lineHeaderEnd";

			//lineDetailEnd
			DataDynamics.ActiveReports.Line lineDetailEnd = new DataDynamics.ActiveReports.Line();
			lineDetailEnd.X1 = lineDetailEnd.X2 = fX + (float)iSumColumnWidth / 100;
			lineDetailEnd.Y1 = 0;
			lineDetailEnd.Y2 = DetailHeight;
			lineDetailEnd.Name = "lineDetailEnd";

			//lineBarHeader1
			DataDynamics.ActiveReports.Line lineBarHeader1 = new DataDynamics.ActiveReports.Line();
			lineBarHeader1.X1 = fX;
			lineBarHeader1.X2 = fX + (float)iSumColumnWidth / 100;
			lineBarHeader1.Y1 = lineBarHeader1.Y2 = repFile.pageHeader.Height - DetailHeight;
			lineBarHeader1.Name = "lineBarHeader1";

			//lineBarHeader2
			DataDynamics.ActiveReports.Line lineBarHeader2 = new DataDynamics.ActiveReports.Line();
			lineBarHeader2.X1 = fX;
			lineBarHeader2.X2 = fX + (float)iSumColumnWidth / 100;
			lineBarHeader2.Y1 = lineBarHeader2.Y2 = repFile.pageHeader.Height - 0.01F;
			lineBarHeader2.Name = "lineBarHeader2";

			//lineBarDetail
			DataDynamics.ActiveReports.Line lineBarDetail = new DataDynamics.ActiveReports.Line();
			lineBarDetail.Tag = "LINEBAR";
			lineBarDetail.X1 = fX;
			lineBarDetail.X2 = fX + (float)iSumColumnWidth / 100;
			lineBarDetail.Y1 = lineBarDetail.Y2 = DetailHeight - 0.01F;
			lineBarDetail.Name = "lineBarDetail";

			repFile.pageHeader.Controls.Add(lineHeaderEnd);
			repFile.pageHeader.Controls.Add(lineBarHeader1);
			repFile.pageHeader.Controls.Add(lineBarHeader2);

			repFile.detail.Controls.Add(lineDetailEnd);
			repFile.detail.Controls.Add(lineBarDetail);
			#endregion

			#region reportHeader
			foreach (DataDynamics.ActiveReports.ARControl arCtrl in repFile.reportHeader.Controls)
			{
				if (arCtrl.GetType().Name == "Label")
				{
					if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
						continue;

					string strDataField = ((string)arCtrl.Tag).ToUpper();
					if (dicHeader.ContainsKey(strDataField))
						((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
					else
						((DataDynamics.ActiveReports.Label)arCtrl).Text = "";
				}
			}
			#endregion

			repFile.DataSource = dtReport;

			repFile.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
			repFile.Run();

			return repFile;
		}

		public static void ExportExcel(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont)
		{
			Workbook workbook = new Workbook();
			Worksheet wSheet = workbook.Worksheets[0];
			ImportTableOptions importOptions = new ImportTableOptions();
			importOptions.IsFieldNameShown = false;

			Range range = null;
			Style style = null;
			StyleFlag styleFlag = null;

			bool bOverwrite = true;
			if (System.IO.File.Exists(strFileName))
			{
				try
				{
					if (Common.MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
					{
						System.IO.File.Delete(strFileName);
					}
					else
						bOverwrite = false;
				}
				catch (Exception ex)
				{
					Common.MsgCancel(ex.Message);
					return;
				}
			}

			DataTable dtExport;
			BindingSource bdsExport;

			string[] lstColumnsID = null;
			string[] lstColumnsName = null;

			int iColLength, iRowLength, iNextRow = 0;
			int iBold = -1;
			int iCongThuc = -1;
			int iFore_Color = -1;
			int iBack_Color = -1;
			int iColor = -1;

			string strAddr1, strAddr2;

			tlControl tlExport = new tlControl();
			dgvGridControl dgvExportDX = new dgvGridControl();
			dgvControl dgvExport = new dgvControl();

			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
				tlExport = (tlControl)ExportControl;
			else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
				dgvExportDX = (dgvGridControl)ExportControl;
			else
				dgvExport = (dgvControl)ExportControl;

			#region Parametter
			if (Common.Inlist(ExportControl.GetType().Name, "tlReport,tlControl"))
			{
				bdsExport = (BindingSource)tlExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = tlExport.VisibleColumns.Count;
				iRowLength = tlExport.VisibleNodesCount;
				
				lstColumnsID = new string[iColLength];
				lstColumnsName = new string[iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{
					if (!dtExport.Columns.Contains(tlExport.Columns[i].FieldName))
					{
						DataColumn dcNewCol;
						if (tlExport.Columns[i].ColumnType.Name == "Boolean")
						{
							dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(bool));
							dcNewCol.DefaultValue = false;
						}
						else if (tlExport.Columns[i].ColumnType.Name == "DateTime")
						{
							dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(DateTime));
							dcNewCol.DefaultValue = Element.sysNgay_Min;
						}
						else if (Common.Inlist(tlExport.Columns[i].ColumnType.Name, "Int16,Int32,Int64,Decimal,Double"))
						{
							dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(double));
							dcNewCol.DefaultValue = 0;
						}
						else
						{
							dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(string));
							dcNewCol.DefaultValue = string.Empty;
						}
						dtExport.Columns.Add(dcNewCol);
					}

					lstColumnsID[i] = tlExport.Columns[i].FieldName;
					lstColumnsName[i] = tlExport.Columns[i].Caption;

					if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}
            else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
			{
				bdsExport = (BindingSource)dgvExportDX.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = dgvExportDX.dgvGridView.VisibleColumns.Count;
				iRowLength = dgvExportDX.dgvGridView.DataRowCount;
				
				lstColumnsID = new string[iColLength];
				lstColumnsName = new string[iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{
					if (!dtExport.Columns.Contains(dgvExportDX.dgvGridView.Columns[i].FieldName))
					{
						DataColumn dcNewCol;
						if (dgvExportDX.dgvGridView.Columns[i].ColumnType.Name == "Boolean")
						{
							dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(bool));
							dcNewCol.DefaultValue = false;
						}
						else if (dgvExportDX.dgvGridView.Columns[i].ColumnType.Name == "DateTime")
						{
							dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(DateTime));
							dcNewCol.DefaultValue = Element.sysNgay_Min;
						}
						else if (Common.Inlist(dgvExportDX.dgvGridView.Columns[i].ColumnType.Name, "Int16,Int32,Int64,Decimal,Double"))
						{
							dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(double));
							dcNewCol.DefaultValue = 0;
						}
						else
						{
							dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(string));
							dcNewCol.DefaultValue = string.Empty;
						}
						dtExport.Columns.Add(dcNewCol);
					}

					lstColumnsID[i] = dgvExportDX.dgvGridView.Columns[i].FieldName;
					lstColumnsName[i] = dgvExportDX.dgvGridView.Columns[i].Caption;

					if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}
			else
			{
				bdsExport = (BindingSource)dgvExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = dgvExport.Columns.Count;
				iRowLength = dgvExport.Rows.Count;

				if (dgvExport.Columns.Contains("BOLD"))
					iColLength = --iColLength;

				if (dgvExport.Columns.Contains("COLOR"))
					iColLength = --iColLength;

				if (dgvExport.Columns.Contains("FORE_COLOR"))
					iColLength = --iColLength;

				if (dgvExport.Columns.Contains("BACK_COLOR"))
					iColLength = --iColLength;

				lstColumnsID = new string[iColLength];
				lstColumnsName = new string[iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{
					if (!dtExport.Columns.Contains(dgvExport.Columns[i].DataPropertyName))
					{
						DataColumn dcNewCol;
						if (Common.Inlist(dgvExport.Columns[i].GetType().Name, "dgvCheckBoxColumn,DataGridViewCheckBoxColumn"))
						{
							dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(bool));
							dcNewCol.DefaultValue = false;
						}
						else if (dgvExport.Columns[i].GetType().Name == "dgvDateTimeColumn")
						{
							dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(DateTime));
							dcNewCol.DefaultValue = Element.sysNgay_Min;
						}
						else
						{
							dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(string));
							dcNewCol.DefaultValue = string.Empty;
						}

						dtExport.Columns.Add(dcNewCol);
					}

					lstColumnsID[i] = dgvExport.Columns[i].DataPropertyName;
					lstColumnsName[i] = dgvExport.Columns[i].HeaderText;

					if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}
			//End Parametter\\
			#endregion

			#region Create column header
			wSheet.Cells.ImportArray(lstColumnsName, iNextRow, 0, false);

			strAddr1 = wSheet.Cells[iNextRow, 0].Name;
			strAddr2 = wSheet.Cells[iNextRow, iColLength - 1].Name;

			range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
			style = workbook.Styles[workbook.Styles.Add()];
			styleFlag = new StyleFlag();
			styleFlag.All = true;

			style.VerticalAlignment = TextAlignmentType.Center;
			style.HorizontalAlignment = TextAlignmentType.Center;
			style.Font.IsBold = true;

			style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.TopBorder].Color = Color.Black;
			style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.LeftBorder].Color = Color.Black;
			style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.BottomBorder].Color = Color.Black;
			style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			style.Borders[BorderType.RightBorder].Color = Color.Black;

			range.ApplyStyle(style, styleFlag);
			//End column header

			#endregion

			#region Formating the columns before polulating the data

			style = workbook.Styles[workbook.Styles.Add()];
			styleFlag = new StyleFlag();
			styleFlag.All = true;
			iNextRow += 1;
			for (int i = 0; i < iColLength; i++)
			{
				if (lstColumnsID[i] == null)
					continue;

				string strColName = lstColumnsID[i].ToString();

				if (!dtExport.Columns.Contains(strColName))
					continue;

				try
				{
					strAddr1 = wSheet.Cells[iNextRow, i].Name;
					strAddr2 = wSheet.Cells[iNextRow + iRowLength, i].Name;

					range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);

					if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
						style.Custom = "@";
					else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
						style.Custom = "dd/MM/yyyy";
					else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
					{
						if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvVoucher"))
						{
							if (dgvExport.Columns[strColName].GetType().Name == "dgvNumericColumn")
							{
								string strTag = "".PadRight(((dgvNumericColumn)dgvExport.Columns[strColName]).Scale, '0');
								style.Custom = "#,##0" + (strTag != "" ? "." : "") + strTag;
							}
						}
						else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
						{
							if (dgvExportDX.dgvGridView.Columns[strColName].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
							{
								string strTag = "".PadRight(Convert.ToInt32(dgvExportDX.dgvGridView.Columns[strColName].DisplayFormat.FormatString.Replace("N", "")), '0');
								style.Custom = "#,##0" + (strTag != "" ? "." : "") + strTag;
							}
						}
						else
							style.Custom = "#,##0.00";
					}

					range.ApplyStyle(style, styleFlag);
				}
				catch (Exception ex)
				{
					Common.MsgCancel(ex.Message);
				}
			}
			//End Format
			#endregion
			//workbook.Save(strFileName);
			//return;
			#region Polulating the data
			try
			{
				DataView dvExport = dtExport.DefaultView;
				DataTable dtTemp = dvExport.ToTable(false, lstColumnsID);
				wSheet.Cells.ImportData(dtTemp, iNextRow, 0, importOptions);

				strAddr1 = wSheet.Cells[iNextRow, 0].Name;
				strAddr2 = wSheet.Cells[iNextRow + iRowLength - 1, iColLength - 1].Name;

				//Creating a range of cells starting from "A1" cell to 3rd column in a row

				range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
				style = workbook.Styles[workbook.Styles.Add()];
				styleFlag = new StyleFlag();
				styleFlag.Borders = true;

				style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.TopBorder].Color = Color.Black;
				style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.LeftBorder].Color = Color.Black;
				style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.BottomBorder].Color = Color.Black;
				style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.RightBorder].Color = Color.Black;

				range.ApplyStyle(style, styleFlag);

				//Format Bold
				if (dtExport.Columns.Contains("BOLD"))
				{
					DataRow[] arrFotmat = dtExport.Select("BOLD=TRUE");
					if (arrFotmat.Length != 0)
					{
						style = workbook.Styles[workbook.Styles.Add()];
						style.Font.IsBold = true;
						styleFlag = new StyleFlag();
						styleFlag.FontBold = true;

						foreach (DataRow dr in arrFotmat)
						{
							strAddr1 = wSheet.Cells[iNextRow + dtExport.Rows.IndexOf(dr), 0].Name;
							strAddr2 = wSheet.Cells[iNextRow + dtExport.Rows.IndexOf(dr), iColLength].Name;
							range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
							range.ApplyStyle(style, styleFlag);
						}
					}
				}
			}

			catch (Exception ex)
			{
				Common.MsgCancel("Có lỗi xảy ra: " + ex.Message);
			}

			#endregion

			wSheet.AutoFitRows();
			wSheet.AutoFitColumns();

			#region Header

			//Dòng Ten_Dvi
			iNextRow = 0;
			wSheet.Cells.InsertRow(iNextRow);
			wSheet.Cells[iNextRow, 0].PutValue(Element.sysTen_Dvi.ToUpper());
			wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

			Cell cellFormat = wSheet.Cells[0, 0];
			Style styleFormat = cellFormat.GetStyle();
			styleFormat.HorizontalAlignment = TextAlignmentType.Left;
			styleFormat.Font.IsBold = true;
			styleFormat.Font.Size = 10;
			styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
			cellFormat.SetStyle(styleFormat);

			//Dòng địa chỉ
			iNextRow += 1;
			wSheet.Cells.InsertRow(iNextRow);
			wSheet.Cells[iNextRow, 0].PutValue(Element.sysDia_Chi_Dv);
			wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

			cellFormat = wSheet.Cells[iNextRow, 0];
			styleFormat = cellFormat.GetStyle();
			styleFormat.HorizontalAlignment = TextAlignmentType.Left;
			styleFormat.Font.IsBold = true;
			styleFormat.Font.Size = 10;
			styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
			cellFormat.SetStyle(styleFormat);

			//Title và SubTitle
			iNextRow += 1;
			wSheet.Cells.InsertRow(iNextRow);
			wSheet.Cells[iNextRow, 0].PutValue(strTitle);
			wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

			cellFormat = wSheet.Cells[iNextRow, 0];
			styleFormat = cellFormat.GetStyle();
			styleFormat.HorizontalAlignment = TextAlignmentType.Center;
			styleFormat.Font.IsBold = true;
			styleFormat.Font.Size = 18;
			styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
			cellFormat.SetStyle(styleFormat);

			string[] strArrSubTitle = strSubTitle.Split('|');
			int iSubTitleLen = strArrSubTitle.Length;
			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
			{
				iNextRow = 3 + j;
				wSheet.Cells.InsertRow(iNextRow);
				wSheet.Cells[iNextRow, 0].PutValue(strArrSubTitle[j]);
				wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

				cellFormat = wSheet.Cells[iNextRow, 0];
				styleFormat = cellFormat.GetStyle();
				styleFormat.HorizontalAlignment = TextAlignmentType.Center;
				styleFormat.Font.IsBold = true;
				styleFormat.Font.IsItalic = true;
				styleFormat.Font.Size = 10;
				styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
				cellFormat.SetStyle(styleFormat);
			}

			#endregion

			//Ghi file lên đĩa
			if (bOverwrite)
			{
				try
				{
					if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName)))
					{
						workbook.Save(strFileName);
					}
				}
				catch (Exception ex)
				{
					Common.MsgCancel("Không thể kết xuất được dữ liệu!");
				}
			}

			Common.EndShowStatus();
		}

		public static void ExportExcelMSOffice(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont)
		{
			// Chạy thử hàng của Thuận
			ExportExcelMSOffice(ExportControl, strTitle, strSubTitle, strFileName, strDestFont, "");
			return;


			//Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
			//Microsoft.Office.Interop.Excel.Workbook wBook = default(Microsoft.Office.Interop.Excel.Workbook);
			//Microsoft.Office.Interop.Excel.Worksheet wSheet = default(Microsoft.Office.Interop.Excel.Worksheet);

			//wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
			//wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;

			Microsoft.Office.Interop.Excel.Application excel = null;
			Microsoft.Office.Interop.Excel.Workbook wBook = null;
			Microsoft.Office.Interop.Excel.Worksheet wSheet = null;
			//Microsoft.Office.Interop.Excel._Worksheet wSheet = null;

			try
			{
				excel = new Microsoft.Office.Interop.Excel.Application();
				wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
				wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
				//Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);
				//wSheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);

			}
			catch (Exception ex)
			{
				Common.MsgCancel("Không thể kết xuất được dữ liệu! Error " + ex.Message);
				return;
			}

			bool bOverwrite = true;
			if (System.IO.File.Exists(strFileName))
			{
				try
				{
					if (Common.MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
					{
						System.IO.File.Delete(strFileName);
					}
					else
						bOverwrite = false;
				}
				catch (Exception ex)
				{
					Common.MsgCancel(ex.Message);
					return;
				}
			}

			//excel.Visible = true;

			DataTable dtExport;
			BindingSource bdsExport;

			object[,] objColNames, objFieldNames, objRowValues;
			int iColLength, iRowLength, iNextRow = 0;
			int iBold = -1;
			int iCongThuc = -1;
			int iFore_Color = -1;
			int iBack_Color = -1;
			int iColor = -1;

			string strAddr1, strAddr2;

			tlControl tlExport = new tlControl();
			dgvControl dgvExport = new dgvControl();
			dgvGridControl dgvExportGrid = new dgvGridControl();

			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
			{
				tlExport = (tlControl)ExportControl;
				bdsExport = (BindingSource)tlExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;
			}
			else if (Common.Inlist(ExportControl.GetType().Name, "dgvReportGrid"))
			{
				dgvExportGrid = (dgvGridControl)ExportControl;
				bdsExport = (BindingSource)dgvExportGrid.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				dgvReport dgvrpt = new dgvReport();
				dgvrpt.strZone = dgvExportGrid.strZone;
				//dgvExport.drReport = dgvExportGrid.drReport;                
				dgvrpt.BuildGridViewReport();

				dgvExport = (dgvControl)dgvrpt;

				dgvExport.DataSource = bdsExport;


				//dgvExportGrid.ExportToXls(strFileName);
				//return;
			}
            else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvVoucherGrid"))
			{
				dgvExportGrid = (dgvGridControl)ExportControl;
				bdsExport = (BindingSource)dgvExportGrid.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;


				dgvExport.strZone = dgvExportGrid.strZone;
				dgvExport.DataSource = bdsExport;
				dgvExport.BuildGridView();
			}
			else
			{
				dgvExport = (dgvControl)ExportControl;
				bdsExport = (BindingSource)dgvExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;
			}

			//dtExport = (DataTable)bdsExport.DataSource;

			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
			{

				iColLength = tlExport.Columns.Count;
				iRowLength = tlExport.VisibleNodesCount;
				//iRowLength = tlExport.Nodes.Count;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < objColNames.Length; i++)
				{
					objColNames[0, i] = tlExport.Columns[i].Caption;
					objFieldNames[0, i] = tlExport.Columns[i].FieldName;

					if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
						iBold = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "COLOR")
						iColor = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}

				////Điền dữ liệu vào objRowValues
				//for (int j = 0; j < tlExport.Nodes.Count; j++)
				//{
				//    for (int k = 0; k < iColLength; k++)
				//    {
				//        objRowValues[j, k] = tlExport.Nodes[j].GetValue(tlExport.Columns[k].FieldName);
				//    }
				//}
			}
			else
			{


				iColLength = dgvExport.Columns.Count;
				iRowLength = dtExport.Rows.Count;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{
					objColNames[0, i] = dgvExport.Columns[i].HeaderText;
					objFieldNames[0, i] = dgvExport.Columns[i].DataPropertyName;

					if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}

				////Điền dữ liệu vào objRowValues
				//foreach (DataGridViewRow dgvr in dgvExport.Rows)
				//{
				//    for (int k = 0; k < iColLength; k++)
				//    {
				//        objRowValues[dgvr.Index, k] = dgvr.Cells[k].Value;
				//    }
				//}
			}

			#region //Điền dữ liệu Header
			strAddr1 = wSheet.Cells[1, 1].Address;
			strAddr2 = wSheet.Cells[1, iColLength].Address;

			Microsoft.Office.Interop.Excel.Range columnsNamesRange = excel.get_Range(strAddr1, strAddr2);
			columnsNamesRange.Value2 = objColNames;
			columnsNamesRange.EntireRow.Font.Bold = true;
			columnsNamesRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(columnsNamesRange);
			columnsNamesRange = null;
			#endregion

			#region //Điền dữ liệu Detail
			iNextRow = 2;

			if (1 == 1)
			{
				strAddr1 = wSheet.Cells[iNextRow, 1].Address;
				strAddr2 = wSheet.Cells[iNextRow + iRowLength - 1, iColLength].Address;

				Microsoft.Office.Interop.Excel.Range dataCells = excel.get_Range(strAddr1, strAddr2);
				dataCells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

				//formating the columns before polulating the data
				for (int i = 0; i < iColLength; i++)
				{
					string strColName = objFieldNames[0, i].ToString();

					if (!dtExport.Columns.Contains(strColName))
						continue;

					try
					{
						if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "@";
						else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy";
						else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
						{
							if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
							{
								if (dgvExport.Columns[strColName].GetType().Name == "dgvNumericColumn")
								{
									string strTag = "".PadRight(((dgvNumericColumn)dgvExport.Columns[strColName]).Scale, '0');
									((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0" + (strTag != "" ? "." : "") + strTag;
								}
							}
							else
								((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0.00";
						}
						//else if ((dtExport.Columns[strColName].DataType.Equals(typeof(int))))
						//    ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0";

						//Chưa áp dụng gán độ rộng cột trên excel
						//rsDataGridView dgvExport1 = (rsDataGridView)ExportControl;
						//if (dgvExport1.Columns[strColName].Width > 255)
						//{
						//    //((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).AutoFit();
						//    ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.ColumnWidth = 255;// dgvExport1.Columns[strColName].Width;
						//}
					}
					catch (Exception ex)
					{
						Common.MsgCancel(ex.Message);
						throw;
					}
				}

				//release range
				System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
				dataCells = null;

				//polulating the data
				try
				{
					int iFetch1 = 0, iFetch2 = 0, iFetchLen = 10000; //Mỗi lần Fetch 10.000 dòng
					while (iFetch1 < iRowLength)
					{
						Common.ShowStatus("Exporting row at " + iFetch1.ToString());
						iFetch2 = Math.Min(iFetch1 + iFetchLen, iRowLength);

						strAddr1 = wSheet.Cells[iNextRow + iFetch1, 1].Address;
						strAddr2 = wSheet.Cells[iNextRow + iFetch2 - 1, iColLength].Address;

						Microsoft.Office.Interop.Excel.Range dataCellsFetch = excel.get_Range(strAddr1, strAddr2);
						objRowValues = new object[Math.Min(iFetch2 - iFetch1, iFetchLen), iColLength]; //Tạo mảng với số dòng tối đa bằng iFetchLen

						//Quyét dòng j từ iFetch1 -> 10.000
						for (int j = iFetch1; j < iFetch1 + iFetchLen; j++)
						{
							if (j < iRowLength) //Chỉ lấy dữ liệu khi j < Số dòng
							{
								//Quét cột k từ 0 -> iColLength
								for (int k = 0; k < iColLength; k++) //Điền dữ liệu vào objRowValues
								{
									if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
									{
										objRowValues[j - iFetch1, k] = tlExport.GetNodeByVisibleIndex(j).GetValue(tlExport.Columns[k].FieldName);
										//objRowValues[j - iFetch1, k] = tlExport.Nodes[j].GetValue(tlExport.Columns[k].FieldName);
									}
									else if (Common.Inlist(ExportControl.GetType().Name, "dgvControl"))
									{
										objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;

										#region Color cho từng Cell giống CellGrid => làm chương trình chạy chậm
										if (iRowLength < 10000) //==> Chỉ bôi màu chữ cho dữ liệu < 10.000 record
										{
											DataGridViewCell dgvc = dgvExport.Rows[j].Cells[k];

											if (dgvc.Style.ForeColor.Name.ToString() != "0") //Chỉ bôi màu cho Cell được Format màu
											{
												strAddr1 = wSheet.Cells[iNextRow + j, k + 1].Address;
												strAddr2 = wSheet.Cells[iNextRow + j, k + 1].Address;

												Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddr1, strAddr2);

												dataCellsFetchColor.Font.Color = System.Drawing.ColorTranslator.ToOle(dgvc.Style.ForeColor);
												////dataCellsFetchColor.Interior.Color = System.Drawing.ColorTranslator.ToOle(dgvc.OwningRow.DefaultCellStyle.BackColor);
											}
										}
										#endregion
									}
									else
									{
										if (dtExport.Columns.Contains(dgvExport.Columns[k].Name))
										{
											string valuecell;//= dgvExportGrid.dgvGridView.GetRowCellValue(j, dgvExport.Columns[k].Name).ToString();
											valuecell = dtExport.Rows[j][dgvExport.Columns[k].Name].ToString();
											objRowValues[j - iFetch1, k] = valuecell;
										}
									}
								}

								if (iBold >= 0 && objRowValues[j - iFetch1, iBold] != null && objRowValues[j - iFetch1, iBold].GetType().Equals(typeof(bool)) && (bool)objRowValues[j - iFetch1, iBold])
								{
									((Microsoft.Office.Interop.Excel.Range)dataCellsFetch.Cells[j - iFetch1 + 1, 1]).EntireRow.Font.Bold = true;
								}

								//Export có ForeColor, BackColor theo màu khai báo trên dữ liệu
								if (iFore_Color >= 0 && objRowValues[j - iFetch1, iFore_Color] != null && objRowValues[j - iFetch1, iFore_Color].GetType().Equals(typeof(string)))
								{
									if (objRowValues[j - iFetch1, iFore_Color].ToString() != "")
									{
										string strAddrC1 = wSheet.Cells[iNextRow + j, 1].Address;
										string strAddrC2 = wSheet.Cells[iNextRow + j, iColLength].Address;

										Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddrC1, strAddrC2);
										dataCellsFetchColor.Font.Color = Color.FromName(objRowValues[j - iFetch1, iFore_Color].ToString());
									}
								}
								//Export có ForeColor, BackColor theo màu khai báo trên dữ liệu
								if (iBack_Color >= 0 && objRowValues[j - iFetch1, iBack_Color] != null && objRowValues[j - iFetch1, iBack_Color].GetType().Equals(typeof(string)))
								{
									if (objRowValues[j - iFetch1, iBack_Color].ToString() != "")
									{
										string strAddrC1 = wSheet.Cells[iNextRow + j, 1].Address;
										string strAddrC2 = wSheet.Cells[iNextRow + j, iColLength].Address;

										Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddrC1, strAddrC2);
										dataCellsFetchColor.Interior.Color = Color.FromName(objRowValues[j - iFetch1, iBack_Color].ToString());
									}
								}
							}
						}

						dataCellsFetch.Value2 = objRowValues;

						//Xóa đi 3 cột cuối: Bold | Color | Fore_Color | Back_Color
						//if (iBold > 0)
						//    ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iBold + 1]).EntireColumn.Delete(); //iColLength
						if (iCongThuc > 0)
							((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iCongThuc + 1]).EntireColumn.Delete();
						if (iColor > 0)
							((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iColor + 1]).EntireColumn.Delete();
						if (iFore_Color > 0)
							((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iFore_Color + 1]).EntireColumn.Delete(); //iColLength - 1
						if (iBack_Color > 0)
							((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iBack_Color + 1]).EntireColumn.Delete(); //iColLength - 2

						//release range
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						GC.SuppressFinalize(objRowValues);
						GC.SuppressFinalize(dataCellsFetch);

						System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCellsFetch);
						dataCellsFetch = null;

						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						iFetch1 += iFetchLen;
					}

					////release range
					//System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
					//dataCells = null;

				}
				catch (Exception ex)
				{
					Common.MsgCancel("Có lỗi xảy ra: " + ex.Message);
				}
			}
			#endregion

			excel.Visible = true;
			//wSheet.Columns.AutoFit();

			#region Header
			/*
            //Dòng Ten_Dvi
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).EntireRow.Insert();
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Value = Epoint.Systems.Elements.Element.sysTen_Dvi.ToUpper();
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Size = 10;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Dòng địa chỉ
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).EntireRow.Insert();
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Value = Element.sysDia_Chi_Dv;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Size = 10;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Title và SubTitle
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).EntireRow.Insert();
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Value = strTitle;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Size = 18;
            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            string[] strArrSubTitle = strSubTitle.Split('|');
            int iSubTitleLen = strArrSubTitle.Length;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).EntireRow.Insert();
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Value = strArrSubTitle[j];
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Bold = true;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Italic = true;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Size = 10;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).WrapText = false;
            }
            */
			/*
            //11/11/2012:  bỏ vì báo lỗi đối với framework 4.0
            excel.get_Range(excel.Cells[1, 1], excel.Cells[1, objColNames.Length]).MergeCells = true;
            excel.get_Range(excel.Cells[2, 1], excel.Cells[2, objColNames.Length]).MergeCells = true;
            excel.get_Range(excel.Cells[3, 1], excel.Cells[3, objColNames.Length]).MergeCells = true;

            strAddr1 = excel.Cells[1, 1].Address; strAddr2 = excel.Cells[1, objColNames.Length].Address;
            //excel.get_Range(strAddr1, strAddr2).MergeCells = true;
            excel.get_Range(strAddr1, strAddr2).WrapText = false;

            strAddr1 = excel.Cells[2, 1].Address; strAddr2 = excel.Cells[2, objColNames.Length].Address;
            //excel.get_Range(strAddr1, strAddr2).MergeCells = true;
            excel.get_Range(strAddr1, strAddr2).WrapText = false;

            strAddr1 = excel.Cells[3, 1].Address; strAddr2 = excel.Cells[3, objColNames.Length].Address;
            //excel.get_Range(strAddr1, strAddr2).MergeCells = true;
            excel.get_Range(strAddr1, strAddr2).WrapText = false;

            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                strAddr1 = excel.Cells[4 + j, 1].Address;
                strAddr2 = excel.Cells[4 + j, objColNames.Length].Address;

                //excel.get_Range(strAddr1, strAddr2).MergeCells = true;
            }

            ((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                ((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            }
            */
			#endregion

			//Ghi file lên đĩa
			if (bOverwrite)
			{
				try
				{
					Object emptyItem = System.Reflection.Missing.Value;
					excel.DisplayAlerts = false;
					excel.AlertBeforeOverwriting = true;

					if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName))) //.GetFullPath(strFileName)))
					{
						//wBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
						//wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
						wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
					}
				}
				catch (Exception ex)
				{
					//Common.MsgCancel("Không thể kết xuất được dữ liệu!");
					//MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					throw;
				}
			}

			Common.EndShowStatus();

			System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
			wSheet = null;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
			wBook = null;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
			excel = null;
		}
		public static void ExportExcelMSOffice(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont, bool a)
		{
			//Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
			//Microsoft.Office.Interop.Excel.Workbook wBook = default(Microsoft.Office.Interop.Excel.Workbook);
			//Microsoft.Office.Interop.Excel.Worksheet wSheet = default(Microsoft.Office.Interop.Excel.Worksheet);

			//wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
			//wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;

			CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;

			Microsoft.Office.Interop.Excel.Application excel = null;
			Microsoft.Office.Interop.Excel.Workbook wBook = null;
			Microsoft.Office.Interop.Excel.Worksheet wSheet = null;
			//Microsoft.Office.Interop.Excel._Worksheet wSheet = null;

			try
			{
				excel = new Microsoft.Office.Interop.Excel.Application();
				wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
				wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
				//Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);
				//wSheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.Worksheets.get_Item(1);

			}
			catch (Exception ex)
			{
				try //Cố gắng kết xuất lần thứ 2 (do lỗi office cũ không nhận ra Culture mới)
				{
					System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

					excel = new Microsoft.Office.Interop.Excel.Application();
					wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
					wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
				}
				catch (Exception ex2)
				{
					System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
					EpointMessage.MsgCancel("Cannot export data! Error " + ex.Message);
					return;
				}
			}

			//excel.Visible = true;

			DataTable dtExport;
			BindingSource bdsExport;

			object[,] objColNames, objFieldNames;
			object[,] objRowValues;
			int iColLength, iRowLength, iNextRow;

			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
			{
				tlControl tlExport = (tlControl)ExportControl;
				bdsExport = (BindingSource)tlExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = tlExport.Columns.Count;
				iRowLength = tlExport.Nodes.Count;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < objColNames.Length; i++)
				{
					objColNames[0, i] = tlExport.Columns[i].Caption;
					objFieldNames[0, i] = tlExport.Columns[i].FieldName;
				}

				//Điền dữ liệu vào objRowValues
				for (int j = 0; j < tlExport.Nodes.Count; j++)
				{
					for (int k = 0; k < iColLength; k++)
					{
						objRowValues[j, k] = tlExport.Nodes[j].GetValue(tlExport.Columns[k].FieldName);
					}
				}
			}
			else
			{
				dgvControl dgvExport = (dgvControl)ExportControl;
				bdsExport = (BindingSource)dgvExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = dgvExport.Columns.Count;
				iRowLength = dgvExport.Rows.Count;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{
					objColNames[0, i] = dgvExport.Columns[i].HeaderText;
					objFieldNames[0, i] = dgvExport.Columns[i].DataPropertyName;
				}

				//Điền dữ liệu vào objRowValues
				foreach (DataGridViewRow dgvr in dgvExport.Rows)
				{
					for (int k = 0; k < iColLength; k++)
					{
						objRowValues[dgvr.Index, k] = dgvr.Cells[k].Value;
					}
				}
			}

			#region Header

			//Dòng Ten_Dvi
			excel.Cells[1, 1] = Epoint.Systems.Elements.Element.sysTen_Dvi.ToUpper();
			excel.Cells[2, 1] = Element.sysDia_Chi_Dv;

			//Title và SubTitle
			excel.Cells[3, 1] = strTitle;

			string[] strArrSubTitle = strSubTitle.Split('|');
			int iSubTitleLen = strArrSubTitle.Length;
			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
			{
				excel.Cells[4 + j, 1] = strArrSubTitle[j];
			}

			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Size = 10;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Size = 10;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Size = 18;

			for (int i = 0; i < iSubTitleLen; i++)//SubTitle
			{
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Bold = true;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Italic = true;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + i, 1]).Font.Size = 10;
			}

			excel.get_Range(excel.Cells[1, 1], excel.Cells[1, objColNames.Length]).MergeCells = true;
			excel.get_Range(excel.Cells[2, 1], excel.Cells[2, objColNames.Length]).MergeCells = true;
			excel.get_Range(excel.Cells[3, 1], excel.Cells[3, objColNames.Length]).MergeCells = true;

			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
				excel.get_Range(excel.Cells[4 + j, 1], excel.Cells[4 + j, objColNames.Length]).MergeCells = true;

			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
			{
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
			}
			#endregion

			//Điền dữ liệu Header
			iNextRow = 4 + iSubTitleLen;
			Microsoft.Office.Interop.Excel.Range columnsNamesRange = wSheet.get_Range(wSheet.Cells[iNextRow, 1], wSheet.Cells[iNextRow, iColLength]);
			columnsNamesRange.Value2 = objColNames;
			columnsNamesRange.EntireRow.Font.Bold = true;
			columnsNamesRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(columnsNamesRange);
			columnsNamesRange = null;

			//Điền dữ liệu Detail
			iNextRow = iNextRow + 1;

			if (1 == 1)
			{
				Microsoft.Office.Interop.Excel.Range dataCells = wSheet.get_Range(wSheet.Cells[iNextRow, 1], wSheet.Cells[iNextRow + iRowLength - 1, iColLength]);
				dataCells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

				//formating the columns before polulating the data
				for (int i = 0; i < iColLength; i++)
				{
					string strColName = objFieldNames[0, i].ToString();

					if (!dtExport.Columns.Contains(strColName))
						continue;

					try
					{
						if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "@";
						else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy";
						else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
						{
							if (strColName.Contains("_NT") || strColName == "SO_LUONG" || strColName == "TY_GIA" || strColName == "HE_SO" || strColName == "TY_LE")
							{
								((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0.00";
							}
							else
							{
								((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0";
							}
						}
						//else if ((dtExport.Columns[strColName].DataType.Equals(typeof(int))))
						//    ((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0";
					}
					catch (Exception)
					{
						throw;
					}

				}

				//polulating the data
				try
				{
					//Gán dữ liệu từng Cell
					for (int iRow = 0; iRow < objRowValues.GetLength(0); iRow++)
					{
						for (int iCol = 0; iCol < objRowValues.GetLength(1); iCol++)
						{
							//excel.Cells[iNextRow + iRow + 1, iCol + 1] = objRowValues[iRow, iCol];
							dataCells[iRow + 1, iCol + 1] = objRowValues[iRow, iCol];
						}
					}
				}
				catch (Exception)
				{
					throw;
				}

				//Bold các dòng
				for (int iCol = 0; iCol < iColLength; iCol++)
				{
					if ((string)objFieldNames[0, iCol] == "BOLD")
					{
						for (int iRow = 0; iRow < iRowLength; iRow++)
						{
							if (objRowValues[iRow, iCol] != null && objRowValues[iRow, iCol].GetType().Equals(typeof(bool)) && (bool)objRowValues[iRow, iCol] == true)
								((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iRow + 1, iCol]).EntireRow.Font.Bold = true;
						}

						break;
					}
				}

				//release range
				System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
				dataCells = null;
			}

			//int iStep = 1;
			//while (iStep * 1000 <= iRowLength)
			//{
			//    object[,] objRowValues1 = new object[1000, iColLength];
			//    Array.Copy(objRowValues, (iStep - 1) * iColLength, objRowValues1, 0, objRowValues1.GetLength(0) * iColLength);

			//    //Microsoft.Office.Interop.Excel.Range dataCells = wSheet.get_Range(wSheet.Cells[iNextRow, 1], wSheet.Cells[iNextRow + iRowLength - 1, iColLength]);
			//    Microsoft.Office.Interop.Excel.Range dataCells = wSheet.get_Range(wSheet.Cells[iNextRow, 1], wSheet.Cells[iNextRow + iStep * objRowValues1.GetLength(0), iColLength]);
			//    //dataCells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

			//    dataCells.Value2 = objRowValues1;

			//    //release range
			//    System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
			//    dataCells = null;

			//    iStep++;
			//}

			wSheet.Columns.AutoFit();

			//Ghi file lên đĩa
			try
			{
				if (System.IO.File.Exists(strFileName))
				{
					if (EpointMessage.MsgYes_No(EpointMessage.GetMessage("FILE_EXIST"), "Y"))
					{
						System.IO.File.Delete(strFileName);
					}
				}

				Object emptyItem = System.Reflection.Missing.Value;
				excel.DisplayAlerts = false;
				excel.AlertBeforeOverwriting = true;

				if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName))) //.GetFullPath(strFileName)))
				{
					//wBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
					//wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
					wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
				}

				excel.Visible = true;
			}
			catch (Exception ex)
			{
				//EpointMessage.MsgCancel("Không thể kết xuất được dữ liệu!");
				//MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

				excel.Visible = true;
				return;
			}

			System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
		}
		public static void ExportExcelMSOffice(object ExportControl, string strTitle, string strSubTitle, string strFileName, string strDestFont, string a) // Hàng của thuận
		{
			Microsoft.Office.Interop.Excel.Application excel = null;
			Microsoft.Office.Interop.Excel.Workbook wBook = null;
			Microsoft.Office.Interop.Excel.Worksheet wSheet = null;

			try
			{
				excel = new Microsoft.Office.Interop.Excel.Application();
				wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
				wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.Worksheets[1];
			}
			catch (Exception ex)
			{
				Common.MsgCancel("Không thể kết xuất được dữ liệu! Error " + ex.Message);
				return;
			}

			bool bOverwrite = true;
			if (System.IO.File.Exists(strFileName))
			{
				try
				{
					if (Common.MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
					{
						System.IO.File.Delete(strFileName);
					}
					else
						bOverwrite = false;
				}
				catch (Exception ex)
				{
					Common.MsgCancel(ex.Message);
					return;
				}
			}

			DataTable dtExport;
			BindingSource bdsExport;

			object[,] objColNames, objFieldNames, objRowValues;
			int iColLength, iRowLength, iNextRow = 0;
			int iBold = -1;
			int iCongThuc = -1;
			int iFore_Color = -1;
			int iBack_Color = -1;
			int iColor = -1;

			string strAddr1, strAddr2;


			//tlControl tlExport = new tlControl();
			//dgvControl dgvExport = new dgvControl();
			//dgvGridControl dgvExportGrid = new dgvGridControl();

			tlControl tlExport = new tlControl();
			dgvGridControl dgvExportDevE = new dgvGridControl();
			dgvControl dgvExport = new dgvControl();

			if (Common.Inlist(ExportControl.GetType().Name, "tlReport,TreeList"))
				tlExport = (tlControl)ExportControl;
			else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvVoucherGrid,dgvReportGrid"))
				dgvExportDevE = (dgvGridControl)ExportControl;
			else
				dgvExport = (dgvControl)ExportControl;

			if (Common.Inlist(ExportControl.GetType().Name, "tlReport,TreeList"))
			{
				bdsExport = (BindingSource)tlExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = tlExport.Columns.Count;
				iRowLength = tlExport.VisibleNodesCount;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i < objColNames.Length; i++)
				{
					objColNames[0, i] = tlExport.Columns[i].Caption;
					objFieldNames[0, i] = tlExport.Columns[i].FieldName;

					if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
						iBold = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "COLOR")
						iColor = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					else if (objFieldNames[0, i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}
			else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvVoucherGrid,dgvReportGrid"))
			{
				bdsExport = (BindingSource)dgvExportDevE.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = dgvExportDevE.dgvGridView.Columns.Count;//Tru 4 col: duoi
				iRowLength = dgvExportDevE.dgvGridView.DataRowCount;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i <= iColLength; i++)
				{
					if (!dgvExportDevE.dgvGridView.Columns[i].Visible)
						continue;

					objColNames[0, i] = dgvExportDevE.dgvGridView.Columns[i].Caption != string.Empty ? dgvExportDevE.dgvGridView.Columns[i].Caption : dgvExportDevE.dgvGridView.Columns[i].FieldName;
					objFieldNames[0, i] = dgvExportDevE.dgvGridView.Columns[i].FieldName;

					if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}
			else
			{
				bdsExport = (BindingSource)dgvExport.DataSource;
				dtExport = (DataTable)bdsExport.DataSource;

				iColLength = dgvExport.Columns.Count;
				iRowLength = dgvExport.Rows.Count;

				objColNames = new object[1, iColLength];
				objFieldNames = new object[1, iColLength];
				objRowValues = new object[iRowLength, iColLength];

				//Điền dữ liệu vào objColNames
				for (int i = 0; i <= iColLength; i++)
				{
					objColNames[0, i] = dgvExport.Columns[i].HeaderText;
					objFieldNames[0, i] = dgvExport.Columns[i].DataPropertyName;

					if (objFieldNames[0, i].ToString().ToUpper() == "BOLD")
						iBold = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "CONG_THUC")
						iCongThuc = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "COLOR")
						iColor = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "FORE_COLOR")
						iFore_Color = i;

					if (objFieldNames[0, i].ToString().ToUpper() == "BACK_COLOR")
						iBack_Color = i;
				}
			}

			#region //Điền dữ liệu Header
			strAddr1 = wSheet.Cells[1, 1].Address;
			strAddr2 = wSheet.Cells[1, iColLength].Address;

			Microsoft.Office.Interop.Excel.Range columnsNamesRange = excel.get_Range(strAddr1, strAddr2);
			columnsNamesRange.Value2 = objColNames;
			columnsNamesRange.EntireRow.Font.Bold = true;
			columnsNamesRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(columnsNamesRange);
			columnsNamesRange = null;
			#endregion

			#region //Điền dữ liệu Detail
			iNextRow = 2;

			if (1 == 1)
			{
				strAddr1 = wSheet.Cells[iNextRow, 1].Address;
				strAddr2 = wSheet.Cells[iNextRow + iRowLength - 1, iColLength].Address;

				Microsoft.Office.Interop.Excel.Range dataCells = excel.get_Range(strAddr1, strAddr2);
				dataCells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

				//formating the columns before polulating the data
				for (int i = 0; i < iColLength; i++)
				{
					if (objFieldNames[0, i] == null)
						continue;

					string strColName = objFieldNames[0, i].ToString();

					if (!dtExport.Columns.Contains(strColName))
						continue;

					try
					{
						if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "@";
						else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
							((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy";
						else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
						{
							if (Common.Inlist(ExportControl.GetType().Name, "dgvControl"))
							{
								if (dgvExport.Columns[strColName].GetType().Name == "dgvNumericColumn")
								{
									string strTag = "".PadRight(((dgvNumericColumn)dgvExport.Columns[strColName]).Scale, '0');
									((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0" + (strTag != "" ? "." : "") + strTag;
								}
							}
							else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvVoucherGrid,dgvReportGrid"))
							{
								if (dgvExportDevE.dgvGridView.Columns[strColName].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
								{
									string strTag = dgvExportDevE.dgvGridView.Columns[strColName].DisplayFormat.FormatString.Replace("N", "");
									((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0" + (strTag != "" ? "." : "") + strTag;
								}
							}
							else
								((Microsoft.Office.Interop.Excel.Range)dataCells.Cells[iNextRow, i + 1]).EntireColumn.NumberFormat = "#,##0.00";
						}
					}
					catch (Exception ex)
					{
						Common.MsgCancel(ex.Message);
						throw;
					}
				}

				//release range
				System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCells);
				dataCells = null;

				//polulating the data
				try
				{
					int iFetch1 = 0, iFetch2 = 0, iFetchLen = 10000; //Mỗi lần Fetch 10.000 dòng
					while (iFetch1 < iRowLength)
					{
						Common.ShowStatus("Exporting row at " + iFetch1.ToString());
						iFetch2 = Math.Min(iFetch1 + iFetchLen, iRowLength);

						strAddr1 = wSheet.Cells[iNextRow + iFetch1, 1].Address;
						strAddr2 = wSheet.Cells[iNextRow + iFetch2 - 1, iColLength].Address;

						Microsoft.Office.Interop.Excel.Range dataCellsFetch = excel.get_Range(strAddr1, strAddr2);
						objRowValues = new object[Math.Min(iFetch2 - iFetch1, iFetchLen), iColLength]; //Tạo mảng với số dòng tối đa bằng iFetchLen

						//Quyét dòng j từ iFetch1 -> 10.000
						for (int j = iFetch1; j < iFetch1 + iFetchLen; j++)
						{
							if (j < iRowLength) //Chỉ lấy dữ liệu khi j < Số dòng
							{
								//Quét cột k từ 0 -> iColLength
								for (int k = 0; k < iColLength; k++) //Điền dữ liệu vào objRowValues
								{
									if (Common.Inlist(ExportControl.GetType().Name, "tlReport,tlTreeList"))
									{
										objRowValues[j - iFetch1, k] = tlExport.GetNodeByVisibleIndex(j).GetValue(tlExport.Columns[k].FieldName);
									}
									else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvVoucherGrid,dgvReportGrid"))
									{
										objRowValues[j - iFetch1, k] = dgvExportDevE.dgvGridView.GetRowCellValue(j, dgvExportDevE.dgvGridView.Columns[k].FieldName);

										#region Color cho từng Cell giống CellGrid => làm chương trình chạy chậm
										if (iRowLength < 10000) //==> Chỉ bôi màu chữ cho dữ liệu < 10.000 record
										{
											var objFormat = dgvExportDevE.dgvGridView.GetRowCellValue(j, dgvExportDevE.dgvGridView.Columns[k].FieldName);
											//if (objFormat.ToString() != "0") //Chỉ bôi màu cho Cell được Format màu
											//{
											//	strAddr1 = wSheet.Cells[iNextRow + j, k + 1].Address;
											//	strAddr2 = wSheet.Cells[iNextRow + j, k + 1].Address;

											//	Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddr1, strAddr2);
											//	dataCellsFetchColor.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.FromName(objFormat.ToString()));
											//}
										}
										#endregion
									}
									else
									{
										objRowValues[j - iFetch1, k] = dgvExport.Rows[j].Cells[k].Value;

										#region Color cho từng Cell giống CellGrid => làm chương trình chạy chậm
										if (iRowLength < 10000) //==> Chỉ bôi màu chữ cho dữ liệu < 10.000 record
										{
											DataGridViewCell dgvc = dgvExport.Rows[j].Cells[k];

											if (dgvc.Style.ForeColor.Name.ToString() != "0") //Chỉ bôi màu cho Cell được Format màu
											{
												strAddr1 = wSheet.Cells[iNextRow + j, k + 1].Address;
												strAddr2 = wSheet.Cells[iNextRow + j, k + 1].Address;

												Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddr1, strAddr2);
												dataCellsFetchColor.Font.Color = System.Drawing.ColorTranslator.ToOle(dgvc.Style.ForeColor);
											}
										}
										#endregion
									}
								}

								if (iBold >= 0 && objRowValues[j - iFetch1, iBold] != null && objRowValues[j - iFetch1, iBold].GetType().Equals(typeof(bool)) && (bool)objRowValues[j - iFetch1, iBold])
								{
									((Microsoft.Office.Interop.Excel.Range)dataCellsFetch.Cells[j - iFetch1 + 1, 1]).EntireRow.Font.Bold = true;
								}

								//ThuanNB bỏ tô màu làm chậm thêm.
								//Export có ForeColor, BackColor theo màu khai báo trên dữ liệu
								if (iFore_Color >= 0 && objRowValues[j - iFetch1, iFore_Color] != null && objRowValues[j - iFetch1, iFore_Color].GetType().Equals(typeof(string)))
								{
									if (objRowValues[j - iFetch1, iFore_Color].ToString() != "")
									{
										string strAddrC1 = wSheet.Cells[iNextRow + j, 1].Address;
										string strAddrC2 = wSheet.Cells[iNextRow + j, iColLength].Address;

										Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddrC1, strAddrC2);
										dataCellsFetchColor.Font.Color = Color.FromName(objRowValues[j - iFetch1, iFore_Color].ToString());
									}
								}
								//Export có ForeColor, BackColor theo màu khai báo trên dữ liệu
								if (iBack_Color >= 0 && objRowValues[j - iFetch1, iBack_Color] != null && objRowValues[j - iFetch1, iBack_Color].GetType().Equals(typeof(string)))
								{
									if (objRowValues[j - iFetch1, iBack_Color].ToString() != "")
									{
										string strAddrC1 = wSheet.Cells[iNextRow + j, 1].Address;
										string strAddrC2 = wSheet.Cells[iNextRow + j, iColLength].Address;

										Microsoft.Office.Interop.Excel.Range dataCellsFetchColor = excel.get_Range(strAddrC1, strAddrC2);
										dataCellsFetchColor.Interior.Color = Color.FromName(objRowValues[j - iFetch1, iBack_Color].ToString());
									}
								}
							}
						}

						dataCellsFetch.Value2 = objRowValues;

						//Xóa đi 3 cột cuối: Bold | Color | Fore_Color | Back_Color
						//if (iBold > 0)
						//	((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iBold + 1]).EntireColumn.Delete(); //iColLength
						//if (iCongThuc > 0)
						//	((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iCongThuc + 1]).EntireColumn.Delete();
						//if (iColor > 0)
						//	((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iColor + 1]).EntireColumn.Delete();
						//if (iFore_Color > 0)
						//	((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iFore_Color + 1]).EntireColumn.Delete(); //iColLength - 1
						//if (iBack_Color > 0)
						//	((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, iBack_Color + 1]).EntireColumn.Delete(); //iColLength - 2

						//release range
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						GC.SuppressFinalize(objRowValues);
						GC.SuppressFinalize(dataCellsFetch);

						System.Runtime.InteropServices.Marshal.ReleaseComObject(dataCellsFetch);
						dataCellsFetch = null;

						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						iFetch1 += iFetchLen;
					}
				}
				catch (Exception ex)
				{
					Common.MsgCancel("Có lỗi xảy ra: " + ex.Message);
				}
			}
			#endregion

			excel.Visible = true;
			wSheet.Columns.AutoFit();

			#region Header

			//Dòng Ten_Dvi
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).EntireRow.Insert();
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Value = Element.sysTen_Dvi.ToUpper();
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).Font.Size = 10;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

			//Dòng địa chỉ
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).EntireRow.Insert();
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Value = Element.sysDia_Chi_Dv;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).Font.Size = 10;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

			//Title và SubTitle
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).EntireRow.Insert();
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Value = strTitle;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Bold = true;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).Font.Size = 18;
			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

			string[] strArrSubTitle = strSubTitle.Split('|');
			int iSubTitleLen = strArrSubTitle.Length;
			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
			{
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).EntireRow.Insert();
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Value = strArrSubTitle[j];
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Bold = true;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Italic = true;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).Font.Size = 10;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).WrapText = false;
			}
			//Merge cell
			wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, objColNames.Length]].Merge();
			wSheet.Range[wSheet.Cells[2, 1], wSheet.Cells[2, objColNames.Length]].Merge();
			wSheet.Range[wSheet.Cells[3, 1], wSheet.Cells[3, objColNames.Length]].Merge();

			for (int j = 0; j < iSubTitleLen; j++)
			{
				wSheet.Range[wSheet.Cells[4 + j, 1], wSheet.Cells[4 + j, objColNames.Length]].Merge();
			}

			((Microsoft.Office.Interop.Excel.Range)excel.Cells[3, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

			for (int j = 0; j < iSubTitleLen; j++) //SubTitle
			{
				((Microsoft.Office.Interop.Excel.Range)excel.Cells[4 + j, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
			}
			#endregion

			//Ghi file lên đĩa
			if (bOverwrite)
			{
				try
				{
					Object emptyItem = System.Reflection.Missing.Value;
					excel.DisplayAlerts = false;
					excel.AlertBeforeOverwriting = true;

					if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName)))
					{
						wBook.SaveAs(strFileName, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, emptyItem, emptyItem, emptyItem, emptyItem, emptyItem);
					}
				}
				catch (Exception ex)
				{
					Common.MsgCancel("Không thể kết xuất được dữ liệu!");
				}
			}

			Common.EndShowStatus();

			System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
			wSheet = null;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
			wBook = null;

			System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
			excel = null;
		}
		public static bool ExportFoxpro(object ExportControl, string strTitle, string strPathFile, string strDestFont)
		{
			string strPath = string.Empty;
			string strFileName = string.Empty;

			if (strPathFile.Split('\\').Length > 0)
			{
				strFileName = strPathFile.Split('\\')[strPathFile.Split('\\').Length - 1];
				strPath = strPathFile.Substring(0, strPathFile.Length - strFileName.Length);
			}

			if (!System.IO.Directory.Exists(strPath))
				return false;

			//Ghi file lên đĩa
			try
			{
				if (System.IO.File.Exists(strPathFile))
				{
					if (EpointMessage.MsgYes_No(EpointMessage.GetMessage("FILE_EXIST"), "Y"))
					{
						System.IO.File.Delete(strPathFile);
					}
				}
			}
			catch (Exception ex)
			{
				EpointMessage.MsgCancel(EpointMessage.GetMessage("CANOT_OVERWRITE"));
				return false;
			}

			DataTable dtExport;

			DataTable dtColumnInfo = new DataTable();
			dtColumnInfo.Columns.Add(new DataColumn("ColumnName", typeof(string)));
			dtColumnInfo.Columns.Add(new DataColumn("Len", typeof(int)));
			dtColumnInfo.Columns.Add(new DataColumn("ColumnAlias", typeof(string)));

			string strColumnList = string.Empty;

			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
			{
				tlControl tl = (tlControl)ExportControl;
				BindingSource bds = (BindingSource)tl.DataSource;

				if (bds.Filter != null && bds.Filter != string.Empty)
				{
					dtExport = ((DataTable)bds.DataSource).Clone();
					DataRow[] arrRow = ((DataTable)bds.DataSource).Select(bds.Filter);
					foreach (DataRow dr in arrRow)
						dtExport.ImportRow(dr);
				}
				else
					dtExport = (DataTable)bds.DataSource;

				//Tạo chuổi các cột
				for (int iCol = 1; iCol <= tl.Columns.Count - 1; iCol++)
				{
					string strColumnName = tl.Columns[iCol].FieldName;
					string strColumnAlias = strColumnName.Length < 10 ? strColumnName : "Col_" + (iCol + 1).ToString();

					strColumnList += (strColumnList == string.Empty ? "" : ",") + "'" + strColumnName + "'";

					dtColumnInfo.Rows.Add(new object[] { strColumnName, 100, strColumnAlias });
				}
			}
			else
			{
				dgvControl dgv = (dgvControl)ExportControl;
				BindingSource bds = (BindingSource)dgv.DataSource;

				if (bds.Filter != null && bds.Filter != string.Empty)
				{
					dtExport = ((DataTable)bds.DataSource).Clone();
					DataRow[] arrRow = ((DataTable)bds.DataSource).Select(bds.Filter);
					foreach (DataRow dr in arrRow)
						dtExport.ImportRow(dr);
				}
				else
					dtExport = (DataTable)bds.DataSource;

				for (int iCol = 0; iCol <= dgv.Columns.Count - 1; iCol++)
				{
					string strColumnName = dgv.Columns[iCol].DataPropertyName;
					string strColumnAlias = strColumnName.Length < 10 ? strColumnName : "Col_" + (iCol + 1).ToString();

					strColumnList += (strColumnList == string.Empty ? "" : ",") + "'" + strColumnName + "'";

					dtColumnInfo.Rows.Add(new object[] { strColumnName, 100, strColumnAlias });
				}
			}

			if (dtExport.Columns.Count <= 0)
			{
				throw new Exception();
			}

			//Xử lý tên cột, độ dài cột
			//for (int iCol = 0; iCol < dtExport.Columns.Count; iCol++)
			//{
			//    string strColumnName = dtExport.Columns[iCol].ColumnName;
			//    string strColumnAlias = strColumnName.Length < 10 ? strColumnName : "Col_" + (iCol + 1).ToString();

			//    strColumnList += (strColumnList == string.Empty ? "" : ",") + "'" + strColumnName + "'";

			//    dtColumnInfo.Rows.Add(new object[] { strColumnName, 100, strColumnAlias });
			//}

			//Lấy Max_Len từ sys.Columns
			string strSQLExec =
				"SELECT Name AS Name, AVG(Max_Length) AS Max_Length " +
					" FROM sys.columns " +
					" WHERE User_Type_ID = 167 AND Name IN (" + strColumnList + ") " +
					" GROUP BY Name";

			DataTable dtColumns = SQLExec.ExecuteReturnDt(strSQLExec);

			foreach (DataRow dr in dtColumnInfo.Rows)
			{
				if (dtColumns.Select("Name = '" + dr["ColumnName"] + "'").Length == 1)
					dr["Len"] = dtColumns.Select("Name = '" + dr["ColumnName"] + "'")[0]["Max_Length"];
			}
			//Xử lý xong

			string tableName = string.Empty;
			string folderPath = string.Empty;

			if (strPathFile.Split('\\').Length > 0)
			{
				tableName = strPathFile.Split('\\')[strPathFile.Split('\\').Length - 1];
				folderPath = strPathFile.Substring(0, strPathFile.Length - tableName.Length);

				if (tableName.Length > 4 && tableName.Substring(tableName.Length - 4, 1) == ".")
					tableName = tableName.Substring(0, tableName.Length - 4);
			}

			// here you can use DBASE IV also
			string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + folderPath + "; Extended Properties=DBASE III;";
			string createStatement = "CREATE TABLE " + tableName + " ( ";
			string insertStatement = "INSERT INTO " + tableName + " VALUES ( ";
			string insertTemp = string.Empty;
			OleDbCommand cmd = new OleDbCommand();
			OleDbConnection conn = new OleDbConnection(connString);


			for (int iCol = 0; iCol < dtColumnInfo.Rows.Count; iCol++)
			{
				string strColumnName = dtColumnInfo.Rows[iCol]["ColumnName"].ToString();
				string strColumnAlias = dtColumnInfo.Rows[iCol]["ColumnAlias"].ToString();
				int iLen = Convert.ToInt32(dtColumnInfo.Rows[iCol]["Len"]);

				if (dtExport.Columns.Contains(strColumnName))
				{
					if (dtExport.Columns[strColumnName].DataType == typeof(string))
						createStatement += "[" + strColumnAlias + "] char(" + iLen.ToString() + "),";
					else if (dtExport.Columns[strColumnName].DataType == typeof(DateTime))
						createStatement += "[" + strColumnAlias + "] char(10),";
					else if (dtExport.Columns[strColumnName].DataType == typeof(double) || dtExport.Columns[strColumnName].DataType == typeof(decimal))
						createStatement += "[" + strColumnAlias + "] numeric(18, 6),";
					else
						createStatement += "[" + strColumnAlias + "] char(100),";
				}
			}
			createStatement = createStatement.Substring(0, createStatement.Length - 1) + ")";

			DataTable dtDbf = new DataTable();

			conn.Open();
			OleDbDataAdapter daInsertTable = new OleDbDataAdapter(createStatement, conn);
			daInsertTable.Fill(dtDbf);

			DataTable dtTemp = new DataTable();

			for (int row = 0; row < dtExport.Rows.Count; row++)
			{
				insertTemp = insertStatement;
				DataRow dr = dtTemp.NewRow();
				dtTemp.Rows.Add(dr);

				for (int col = 0; col < dtColumnInfo.Rows.Count; col++)
				{
					string strColumnName = dtColumnInfo.Rows[col]["ColumnName"].ToString();

					if (!dtExport.Columns.Contains(strColumnName))
						continue;

					if (row == 0)
					{
						DataColumn dc = new DataColumn(strColumnName);
						dtTemp.Columns.Add(dc);
					}

					// Remove Special character if any like dot,semicolon,colon,comma // etc
					dtExport.Rows[row][strColumnName].ToString().Replace("LF", "");
					// do the formating if you want like modify the Date symbol , //thousand saperator etc.
					dtTemp.Rows[row][strColumnName] = dtExport.Rows[row][strColumnName].ToString().Trim();

					//Convert font chữ
					if (dtExport.Columns[strColumnName].DataType == typeof(string))
					{
						if (strDestFont == "T")
							dtTemp.Rows[row][strColumnName] = ConvertFont.UnicodeToTCVN3(dtTemp.Rows[row][strColumnName].ToString().ToString());
						else if ((strDestFont == "V"))
							dtTemp.Rows[row][strColumnName] = ConvertFont.UNICODEToVNI(dtTemp.Rows[row][strColumnName].ToString().ToString());
					}

					if (dtExport.Columns[strColumnName].DataType == typeof(DateTime) && dtTemp.Rows[row][strColumnName].ToString().Length >= 10)
						insertTemp += "'" + dtTemp.Rows[row][strColumnName].ToString().Substring(0, 10) + "',";
					else if (dtExport.Columns[strColumnName].DataType == typeof(double) || dtExport.Columns[strColumnName].DataType == typeof(decimal))
						insertTemp += dtTemp.Rows[row][strColumnName].ToString() + ",";
					else
					{
						insertTemp += "'" + dtTemp.Rows[row][strColumnName].ToString().Replace("'", "") + "',";
					}
				}
				insertTemp = insertTemp.Substring(0, insertTemp.Length - 1) + ");";

				daInsertTable = new OleDbDataAdapter(insertTemp, conn);
				daInsertTable.Fill(dtDbf);
			}

			return true;
		}

        #region Pivot Excel
        public static void ExportExcelPivot(object ExportControl, string strFileName, string[] arrRowData, string[] arrColumnData, string[] arrFielData)
        {
            Workbook workbook = new Workbook();
            Worksheet wSheet = workbook.Worksheets[0];
            wSheet.Name = "Data";
            ImportTableOptions importOptions = new ImportTableOptions();
            importOptions.IsFieldNameShown = false;

            Range range = null;
            Style style = null;
            StyleFlag styleFlag = null;

            bool bOverwrite = true;
            if (System.IO.File.Exists(strFileName))
            {
                try
                {
                    if (Common.MsgYes_No("File [" + strFileName + "] đã tồn tại, có chắc chắn ghi đè file?", "Y"))
                    {
                        System.IO.File.Delete(strFileName);
                    }
                    else
                        bOverwrite = false;
                }
                catch (Exception ex)
                {
                    Common.MsgCancel(ex.Message);
                    return;
                }
            }

            DataTable dtExport;
            BindingSource bdsExport;

            string[] lstColumnsID = null;
            string[] lstColumnsName = null;

            int iColLength, iRowLength, iNextRow = 0;
            int iBold = -1;
            int iCongThuc = -1;
            int iFore_Color = -1;
            int iBack_Color = -1;
            int iColor = -1;

            string strAddr1, strAddr2;

            tlControl tlExport = new tlControl();
            dgvGridControl dgvExportDX = new dgvGridControl();
            dgvControl dgvExport = new dgvControl();

            if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport,rsTreeList"))
                tlExport = (tlControl)ExportControl;
            else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
                dgvExportDX = (dgvGridControl)ExportControl;
            else
                dgvExport = (dgvControl)ExportControl;

            #region Parametter
            if (Common.Inlist(ExportControl.GetType().Name, "tlReport,tlControl"))
            {
                bdsExport = (BindingSource)tlExport.DataSource;
                dtExport = (DataTable)bdsExport.DataSource;

                iColLength = tlExport.VisibleColumns.Count;
                iRowLength = tlExport.VisibleNodesCount;

                lstColumnsID = new string[iColLength];
                lstColumnsName = new string[iColLength];

                //Điền dữ liệu vào objColNames
                for (int i = 0; i < iColLength; i++)
                {
                    if (!dtExport.Columns.Contains(tlExport.Columns[i].FieldName))
                    {
                        DataColumn dcNewCol;
                        if (tlExport.Columns[i].ColumnType.Name == "Boolean")
                        {
                            dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(bool));
                            dcNewCol.DefaultValue = false;
                        }
                        else if (tlExport.Columns[i].ColumnType.Name == "DateTime")
                        {
                            dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(DateTime));
                            dcNewCol.DefaultValue = Element.sysNgay_Min;
                        }
                        else if (Common.Inlist(tlExport.Columns[i].ColumnType.Name, "Int16,Int32,Int64,Decimal,Double"))
                        {
                            dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(double));
                            dcNewCol.DefaultValue = 0;
                        }
                        else
                        {
                            dcNewCol = new DataColumn(tlExport.Columns[i].FieldName, typeof(string));
                            dcNewCol.DefaultValue = string.Empty;
                        }
                        dtExport.Columns.Add(dcNewCol);
                    }

                    lstColumnsID[i] = tlExport.Columns[i].FieldName;
                    lstColumnsName[i] = tlExport.Columns[i].Caption;

                    if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
                        iBold = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
                        iCongThuc = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
                        iColor = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
                        iFore_Color = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
                        iBack_Color = i;
                }
            }
            else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
            {
                bdsExport = (BindingSource)dgvExportDX.DataSource;
                dtExport = (DataTable)bdsExport.DataSource;

                iColLength = dgvExportDX.dgvGridView.VisibleColumns.Count;
                iRowLength = dgvExportDX.dgvGridView.DataRowCount;

                lstColumnsID = new string[iColLength];
                lstColumnsName = new string[iColLength];

                //Điền dữ liệu vào objColNames
                for (int i = 0; i < iColLength; i++)
                {
                    if (!dtExport.Columns.Contains(dgvExportDX.dgvGridView.Columns[i].FieldName))
                    {
                        DataColumn dcNewCol;
                        if (dgvExportDX.dgvGridView.Columns[i].ColumnType.Name == "Boolean")
                        {
                            dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(bool));
                            dcNewCol.DefaultValue = false;
                        }
                        else if (dgvExportDX.dgvGridView.Columns[i].ColumnType.Name == "DateTime")
                        {
                            dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(DateTime));
                            dcNewCol.DefaultValue = Element.sysNgay_Min;
                        }
                        else if (Common.Inlist(dgvExportDX.dgvGridView.Columns[i].ColumnType.Name, "Int16,Int32,Int64,Decimal,Double"))
                        {
                            dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(double));
                            dcNewCol.DefaultValue = 0;
                        }
                        else
                        {
                            dcNewCol = new DataColumn(dgvExportDX.dgvGridView.Columns[i].FieldName, typeof(string));
                            dcNewCol.DefaultValue = string.Empty;
                        }
                        dtExport.Columns.Add(dcNewCol);
                    }

                    lstColumnsID[i] = dgvExportDX.dgvGridView.Columns[i].FieldName;
                    lstColumnsName[i] = dgvExportDX.dgvGridView.Columns[i].Caption == string.Empty ? dgvExportDX.dgvGridView.Columns[i].FieldName : dgvExportDX.dgvGridView.Columns[i].Caption;

                    if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
                        iBold = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
                        iCongThuc = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
                        iColor = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
                        iFore_Color = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
                        iBack_Color = i;
                }
            }
            else
            {
                bdsExport = (BindingSource)dgvExport.DataSource;
                dtExport = (DataTable)bdsExport.DataSource;

                iColLength = dgvExport.Columns.Count;
                iRowLength = dgvExport.Rows.Count;

                if (dgvExport.Columns.Contains("BOLD"))
                    iColLength = --iColLength;

                if (dgvExport.Columns.Contains("COLOR"))
                    iColLength = --iColLength;

                if (dgvExport.Columns.Contains("FORE_COLOR"))
                    iColLength = --iColLength;

                if (dgvExport.Columns.Contains("BACK_COLOR"))
                    iColLength = --iColLength;

                lstColumnsID = new string[iColLength];
                lstColumnsName = new string[iColLength];

                //Điền dữ liệu vào objColNames
                for (int i = 0; i < iColLength; i++)
                {
                    if (!dtExport.Columns.Contains(dgvExport.Columns[i].DataPropertyName))
                    {
                        DataColumn dcNewCol;
                        if (Common.Inlist(dgvExport.Columns[i].GetType().Name, "dgvCheckBoxColumn,DataGridViewCheckBoxColumn"))
                        {
                            dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(bool));
                            dcNewCol.DefaultValue = false;
                        }
                        else if (dgvExport.Columns[i].GetType().Name == "dgvDateTimeColumn")
                        {
                            dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(DateTime));
                            dcNewCol.DefaultValue = Element.sysNgay_Min;
                        }
                        else
                        {
                            dcNewCol = new DataColumn(dgvExport.Columns[i].DataPropertyName, typeof(string));
                            dcNewCol.DefaultValue = string.Empty;
                        }

                        dtExport.Columns.Add(dcNewCol);
                    }

                    lstColumnsID[i] = dgvExport.Columns[i].DataPropertyName;
                    lstColumnsName[i] = dgvExport.Columns[i].HeaderText;

                    if (lstColumnsID[i].ToString().ToUpper() == "BOLD")
                        iBold = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "CONG_THUC")
                        iCongThuc = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "COLOR")
                        iColor = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "FORE_COLOR")
                        iFore_Color = i;

                    if (lstColumnsID[i].ToString().ToUpper() == "BACK_COLOR")
                        iBack_Color = i;
                }
            }
            //End Parametter\\
            #endregion

            #region Create column header
            wSheet.Cells.ImportArray(lstColumnsName, iNextRow, 0, false);

            strAddr1 = wSheet.Cells[iNextRow, 0].Name;
            strAddr2 = wSheet.Cells[iNextRow, iColLength - 1].Name;

            range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
            style = workbook.Styles[workbook.Styles.Add()];
            styleFlag = new StyleFlag();
            styleFlag.All = true;

            style.VerticalAlignment = TextAlignmentType.Center;
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.Font.IsBold = true;

            style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.TopBorder].Color = Color.Black;
            style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.LeftBorder].Color = Color.Black;
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.BottomBorder].Color = Color.Black;
            style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.RightBorder].Color = Color.Black;

            range.ApplyStyle(style, styleFlag);
            //End column header

            #endregion

            #region Formating the columns before polulating the data

            style = workbook.Styles[workbook.Styles.Add()];
            styleFlag = new StyleFlag();
            styleFlag.All = true;
            iNextRow += 1;
            for (int i = 0; i < iColLength; i++)
            {
                if (lstColumnsID[i] == null)
                    continue;

                string strColName = lstColumnsID[i].ToString();

                if (!dtExport.Columns.Contains(strColName))
                    continue;

                try
                {
                    strAddr1 = wSheet.Cells[iNextRow, i].Name;
                    strAddr2 = wSheet.Cells[iNextRow + iRowLength, i].Name;

                    range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);

                    if (dtExport.Columns[strColName].DataType.Equals(typeof(string)))
                        style.Custom = "@";
                    else if (dtExport.Columns[strColName].DataType.Equals(typeof(DateTime)))
                        style.Custom = "dd/MM/yyyy";
                    else if ((dtExport.Columns[strColName].DataType.Equals(typeof(double))) || (dtExport.Columns[strColName].DataType.Equals(typeof(decimal))))
                    {
                        if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvVoucher"))
                        {
                            if (dgvExport.Columns[strColName].GetType().Name == "dgvNumericColumn")
                            {
                                string strTag = "".PadRight(((dgvNumericColumn)dgvExport.Columns[strColName]).Scale, '0');
                                style.Custom = "#,##0" + (strTag != "" ? "." : "") + strTag;
                            }
                        }
                        else if (Common.Inlist(ExportControl.GetType().Name, "dgvGridControl,dgvReportGrid,dgvVoucherGrid"))
                        {
                            if (dgvExportDX.dgvGridView.Columns[strColName].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                            {
                                string strTag = "".PadRight(Convert.ToInt32(dgvExportDX.dgvGridView.Columns[strColName].DisplayFormat.FormatString.Replace("N", "")), '0');
                                style.Custom = "#,##0" + (strTag != "" ? "." : "") + strTag;
                            }
                        }
                        else
                            style.Custom = "#,##0.00";
                    }

                    range.ApplyStyle(style, styleFlag);
                }
                catch (Exception ex)
                {
                    Common.MsgCancel(ex.Message);
                }
            }
            //End Format
            #endregion
            //workbook.Save(strFileName);
            //return;
            #region Polulating the data
            try
            {
                DataView dvExport = dtExport.DefaultView;
                DataTable dtTemp = dvExport.ToTable(false, lstColumnsID);
                wSheet.Cells.ImportData(dtTemp, iNextRow, 0, importOptions);

                strAddr1 = wSheet.Cells[iNextRow, 0].Name;
                strAddr2 = wSheet.Cells[iNextRow + iRowLength - 1, iColLength - 1].Name;

                //Creating a range of cells starting from "A1" cell to 3rd column in a row

                range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
                style = workbook.Styles[workbook.Styles.Add()];
                styleFlag = new StyleFlag();
                styleFlag.Borders = true;

                style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style.Borders[BorderType.TopBorder].Color = Color.Black;
                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                style.Borders[BorderType.BottomBorder].Color = Color.Black;
                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style.Borders[BorderType.RightBorder].Color = Color.Black;

                range.ApplyStyle(style, styleFlag);

                //Format Bold
                if (dtExport.Columns.Contains("BOLD"))
                {
                    DataRow[] arrFotmat = dtExport.Select("BOLD=TRUE");
                    if (arrFotmat.Length != 0)
                    {
                        style = workbook.Styles[workbook.Styles.Add()];
                        style.Font.IsBold = true;
                        styleFlag = new StyleFlag();
                        styleFlag.FontBold = true;

                        foreach (DataRow dr in arrFotmat)
                        {
                            strAddr1 = wSheet.Cells[iNextRow + dtExport.Rows.IndexOf(dr), 0].Name;
                            strAddr2 = wSheet.Cells[iNextRow + dtExport.Rows.IndexOf(dr), iColLength].Name;
                            range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
                            range.ApplyStyle(style, styleFlag);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Common.MsgCancel("Có lỗi xảy ra: " + ex.Message);
            }

            #endregion

            wSheet.AutoFitRows();
            wSheet.AutoFitColumns();

            #region Header
            /*
            //Dòng Ten_Dvi
            iNextRow = 0;
            wSheet.Cells.InsertRow(iNextRow);
            wSheet.Cells[iNextRow, 0].PutValue(Element.sysTen_Dvi.ToUpper());
            wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

            Cell cellFormat = wSheet.Cells[0, 0];
            Style styleFormat = cellFormat.GetStyle();
            styleFormat.HorizontalAlignment = TextAlignmentType.Left;
            styleFormat.Font.IsBold = true;
            styleFormat.Font.Size = 10;
            styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
            cellFormat.SetStyle(styleFormat);

            //Dòng địa chỉ
            iNextRow += 1;
            wSheet.Cells.InsertRow(iNextRow);
            wSheet.Cells[iNextRow, 0].PutValue(Element.sysDia_Chi_Dv);
            wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

            cellFormat = wSheet.Cells[iNextRow, 0];
            styleFormat = cellFormat.GetStyle();
            styleFormat.HorizontalAlignment = TextAlignmentType.Left;
            styleFormat.Font.IsBold = true;
            styleFormat.Font.Size = 10;
            styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
            cellFormat.SetStyle(styleFormat);

            //Title và SubTitle
            iNextRow += 1;
            wSheet.Cells.InsertRow(iNextRow);
            wSheet.Cells[iNextRow, 0].PutValue(strTitle);
            wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

            cellFormat = wSheet.Cells[iNextRow, 0];
            styleFormat = cellFormat.GetStyle();
            styleFormat.HorizontalAlignment = TextAlignmentType.Center;
            styleFormat.Font.IsBold = true;
            styleFormat.Font.Size = 18;
            styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
            cellFormat.SetStyle(styleFormat);

            string[] strArrSubTitle = strSubTitle.Split('|');
            int iSubTitleLen = strArrSubTitle.Length;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                iNextRow = 3 + j;
                wSheet.Cells.InsertRow(iNextRow);
                wSheet.Cells[iNextRow, 0].PutValue(strArrSubTitle[j]);
                wSheet.Cells.Merge(iNextRow, 0, 1, iColLength);

                cellFormat = wSheet.Cells[iNextRow, 0];
                styleFormat = cellFormat.GetStyle();
                styleFormat.HorizontalAlignment = TextAlignmentType.Center;
                styleFormat.Font.IsBold = true;
                styleFormat.Font.IsItalic = true;
                styleFormat.Font.Size = 10;
                styleFormat.SetBorder(BorderType.BottomBorder, CellBorderType.None, Color.Transparent);
                cellFormat.SetStyle(styleFormat);
            }
           */
            #endregion

            #region Add Pivot
            //var workB = new Aspose.Cells.Workbook(strFileName);
            //workbook.Worksheets[0].VisibilityType = VisibilityType.VeryHidden;
            Worksheet wSheetpivot = workbook.Worksheets[workbook.Worksheets.Add()];
            wSheetpivot.Name = "PivotData";
            var PivotTableCollection = wSheetpivot.PivotTables;
            string strRange = "Data!A1:" + strAddr2;
            int index = PivotTableCollection.Add(strRange, "A1", "PivotTables");
            var pivotTable = PivotTableCollection[index];
            //pivotTable.RowGrand = true;
            pivotTable.ColumnGrand = true;
            pivotTable.IsAutoFormat = true;
            pivotTable.EnableDataValueEditing = true;
            pivotTable.ShowValuesRow = true;
            pivotTable.ShowPivotStyleColumnHeader = true;
            pivotTable.CalculateData();
            if (arrRowData != null)
            {
                foreach (string sRowdata in arrRowData)
                {
                    pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Row, sRowdata);
                }
            }
            if (arrColumnData != null)
            {
                foreach (string sColdata in arrColumnData)
                {


                    pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Column, sColdata);

                    //Aspose.Cells.Pivot.PivotFieldCollection pivotFields = pivotTable.RowFields;
                    // // Accessing the first row field in the row fields.
                    //Aspose.Cells.Pivot.PivotField pivotField = pivotFields[sColdata]; 
                    // // Setting Subtotals.
                    // pivotField.SetSubtotals(Aspose.Cells.Pivot.PivotFieldSubtotalType.Sum, true);
                }

            }
            if (arrFielData != null)
            {
                foreach (string sFielddata in arrFielData)
                {
                    pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Data, sFielddata);
                    pivotTable.DataFields[sFielddata].NumberFormat = "#,##0";
                }
            }

            pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Column, pivotTable.DataField);

            workbook.Worksheets[0].VisibilityType = VisibilityType.Hidden;
            #endregion

            //Ghi file lên đĩa
            if (bOverwrite)
            {
                try
                {
                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName)))
                    {
                        workbook.Save(strFileName);
                    }

                }
                catch (Exception ex)
                {
                    Common.MsgCancel("Không thể kết xuất được dữ liệu!");
                }
            }

            Common.EndShowStatus();
        }

        #endregion


		#region RunMethod

		public static object RunMethod(string strMethodName)
		{
			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
				return null;
			}

			string strAssembly = string.Empty;
			string strType = string.Empty;

			strAssembly = arrStr[0];
			strType = "Epoint." + arrStr[1];

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);

			type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);

			return frm;
		}
		public static object RunMethod(string strMethodName, object[] objPara)
		{
			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
				return null;
			}

			string strAssembly = string.Empty;
			string strType = string.Empty;

			strAssembly = arrStr[0];
			strType = "Epoint." + arrStr[1];

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);

			type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);

			return frm;
		}
		public static void SetToolStrip()
		{
			frmMain frmM = (frmMain)Element.frmMain;
			Form frm = Common.FindFormReportResultInTab();
			if (frm != null)
			{
				if (frm.GetType().Name == "frmReportResult")
				{
					frmM.tsEdit.Visible = false;
					frmM.tsView.Visible = true;
					frmM.tsReport.Visible = true;

					return;
				}

			}
			frm = Common.FindFormReportInTab();
			if (frm != null)
			{
				if (frm.GetType().Name == "frmReport")
				{
					//frmM.tsEdit.Visible = false;
					//frmM.tsReport.Visible = false;

					return;
				}

			}
			frm = Common.FindFormChildInTab();
			if (frm != null)
			{
				frmM.tsEdit.Visible = true;
				frmM.tsView.Visible = true;
				frmM.tsReport.Visible = false;

				return;
			}


		}

		public static object RunMethod(tsmiControl tsmi)
		{
			if (tsmi == null)
				return null;

			string strMethodName = tsmi.MethodName;
			string strParaName = tsmi.ParaName;
			int iID = tsmi.ID;

			Form frmParent = tsmi.OwnerItem.Owner.Parent.FindForm();
			frmMain frmMain = (frmMain)frmParent;
			TsmiWindowManagement tsmiWindowManagement = frmMain.tsmiWindowManagement;

			if (strMethodName == string.Empty)
				return null;

			//      1           2       3
			//E01Main:E01Main.frmE01Main:Show
			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
				return null;
			}

			Assembly asl = Assembly.Load(arrStr[0]);

			Type type = asl.GetType("Epoint." + arrStr[1]);

			#region Kiem tra form da mo hay chua

			if (frmMain != null)
			{
				string strItemKey = type.Name + "." + iID.ToString().Trim();

				if (tsmiWindowManagement.DropDownItems.ContainsKey(strItemKey))
				{
					if (tsmi.frmInstance != null)
					{
						if (tsmi.frmInstance.GetType().Name == "frmMain")
						{
							Element.frmActiveMain = tsmi.frmInstance;
						}
						else
						{
							tsmi.frmInstance.Activate();
						}

						return tsmi.frmInstance;
					}
				}
			}

			#endregion

			#region Phan tich chuoi Parameter
			List<object> lstPara = new List<object>();
			if (strParaName.Trim() != string.Empty && strParaName.Trim() != null)
			{
				string[] strParaList = strParaName.Split('~');
				for (int i = 0; i <= strParaList.Length - 1; i++)
				{
					string strParaValue = strParaList[i].Substring(1).Trim();

					if (strParaValue.StartsWith("["))
						strParaValue = strParaValue.Remove(0, 1);

					if (strParaValue.EndsWith("]"))
						strParaValue = strParaValue.Remove(strParaValue.Length - 1, 1);

					switch (strParaList[i].Substring(0, 1))
					{
						//string
						case "S":
							string strPara = strParaValue;
							lstPara.Add(strPara);
							break;
						//int
						case "I":
							int iPara = int.Parse(strParaValue);
							lstPara.Add(iPara);
							break;
						//float
						case "F":
							float fPara = float.Parse(strParaValue);
							lstPara.Add(fPara);
							break;
						//DateTime
						case "D":
							DateTime dtePara = Library.StrToDate(strParaValue);
							lstPara.Add(dtePara);
							break;
					}
				}
			}

			#endregion

			string[] arrStrCon = arrStr[1].Split('.');
			bool bIsContructor = (arrStrCon[arrStrCon.Length - 1].Trim() == arrStr[2].Trim()) ? true : false;

			Form frm;

			if (bIsContructor)
			{
				if (lstPara.Count > 0)
					frm = (Form)Activator.CreateInstance(type, lstPara.ToArray());
				else
					frm = (Form)Activator.CreateInstance(type);

				if (frmParent != null && frmParent.IsMdiContainer && !frm.IsMdiContainer && !frm.Modal)
					frm.MdiParent = frmParent;

				if (frm.GetType().Name == "frmMain")
					Element.frmActiveMain = frm;

			}
			else //Khong phai la contructor
			{
				frm = (Form)Activator.CreateInstance(type);

				if (frmParent != null && frmParent.IsMdiContainer && !frm.IsMdiContainer && !frm.Modal)
					frm.MdiParent = frmParent;

				if (frm.GetType().Name == "frmMain")
					Element.frmActiveMain = frm;

				if (lstPara.Count > 0)
					type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, lstPara.ToArray());
				else
					type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);
			}

			if (!frm.IsDisposed)//Khong dua vao nhung Form da Close
			{
				tsmi.frmInstance = frm;

				frmMain.tsmiWindowManagement.AddMenuItemToWindowManagement(tsmi);

				if (frm.MdiParent != null)
					return frm;
				else
					return null;
			}
			else
				return null;
		}
		public static object RunMethodTab(tsmiControl tsmi)
		{

			if (tsmi == null)
				return null;

			string strMethodName = tsmi.MethodName;
			string strParaName = tsmi.ParaName;
			//string strImageFileName = tsmi.im
			int iID = tsmi.ID;

			//Form frmParent = tsmi.OwnerItem.Owner.Parent.FindForm();
			//frmMain frmMain = (frmMain)frmParent;
			//TsmiWindowManagement tsmiWindowManagement = frmMain.tsmiWindowManagement;

			if (strMethodName == string.Empty)
				return null;

			//      1           2       3
			//E01Main:E01Main.frmE01Main:Show
			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
				return null;
			}

			Assembly asl = Assembly.Load(arrStr[0]);

			Type type = asl.GetType("Epoint." + arrStr[1]);
			if (type == null)
			{
				EpointMessage.MsgOk("Assembly invalid !!");
				return null;
			}
			#region Phan tich chuoi Parameter
			List<object> lstPara = new List<object>();
			if (strParaName.Trim() != string.Empty && strParaName.Trim() != null)
			{
				string[] strParaList = strParaName.Split('~');
				for (int i = 0; i <= strParaList.Length - 1; i++)
				{
					string strParaValue = strParaList[i].Substring(1).Trim();

					if (strParaValue.StartsWith("["))
						strParaValue = strParaValue.Remove(0, 1);

					if (strParaValue.EndsWith("]"))
						strParaValue = strParaValue.Remove(strParaValue.Length - 1, 1);

					switch (strParaList[i].Substring(0, 1))
					{
						//string
						case "S":
							string strPara = strParaValue;
							lstPara.Add(strPara);
							break;
						//int
						case "I":
							int iPara = int.Parse(strParaValue);
							lstPara.Add(iPara);
							break;
						//float
						case "F":
							float fPara = float.Parse(strParaValue);
							lstPara.Add(fPara);
							break;
							//DateTime
							//case "D":
							//    DateTime dtePara = Library.StrToDate(strParaValue);
							//    lstPara.Add(dtePara);
							//    break;
					}
				}
			}

			#endregion

			string[] arrStrCon = arrStr[1].Split('.');
			bool bIsContructor = (arrStrCon[arrStrCon.Length - 1].Trim() == arrStr[2].Trim()) ? true : false;

			Form frm;

			if (bIsContructor)
			{
				if (lstPara.Count > 0)
					frm = (Form)Activator.CreateInstance(type, lstPara.ToArray());
				else
					frm = (Form)Activator.CreateInstance(type);


			}
			else //Khong phai la contructor
			{
				frm = (Form)Activator.CreateInstance(type);
				//frm.Visible = false;

				if (lstPara.Count > 0)
					type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, lstPara.ToArray());
				else
					type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);
			}
			return frm;


			//
		}
        public static object RunMethodTabFormBase(tsmiControl tsmi)
        {

            if (tsmi == null)
                return null;

            string strMethodName = tsmi.MethodName;
            string strParaName = tsmi.ParaName;
            //string strImageFileName = tsmi.im
            int iID = tsmi.ID;

            //Form frmParent = tsmi.OwnerItem.Owner.Parent.FindForm();
            //frmMain frmMain = (frmMain)frmParent;
            //TsmiWindowManagement tsmiWindowManagement = frmMain.tsmiWindowManagement;

            if (strMethodName == string.Empty)
                return null;

            //      1           2       3
            //E01Main:E01Main.frmE01Main:Show
            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
                return null;
            }

            Assembly asl = Assembly.Load(arrStr[0]);

            Type type = asl.GetType("Epoint." + arrStr[1]);
            if (type == null)
            {
                EpointMessage.MsgOk("Assembly invalid !!");
                return null;
            }
            #region Phan tich chuoi Parameter
            List<object> lstPara = new List<object>();
            if (strParaName.Trim() != string.Empty && strParaName.Trim() != null)
            {
                string[] strParaList = strParaName.Split('~');
                for (int i = 0; i <= strParaList.Length - 1; i++)
                {
                    string strParaValue = strParaList[i].Substring(1).Trim();

                    if (strParaValue.StartsWith("["))
                        strParaValue = strParaValue.Remove(0, 1);

                    if (strParaValue.EndsWith("]"))
                        strParaValue = strParaValue.Remove(strParaValue.Length - 1, 1);

                    switch (strParaList[i].Substring(0, 1))
                    {
                        //string
                        case "S":
                            string strPara = strParaValue;
                            lstPara.Add(strPara);
                            break;
                        //int
                        case "I":
                            int iPara = int.Parse(strParaValue);
                            lstPara.Add(iPara);
                            break;
                        //float
                        case "F":
                            float fPara = float.Parse(strParaValue);
                            lstPara.Add(fPara);
                            break;
                        //DateTime
                        //case "D":
                        //    DateTime dtePara = Library.StrToDate(strParaValue);
                        //    lstPara.Add(dtePara);
                        //    break;
                    }
                }
            }

            #endregion

            string[] arrStrCon = arrStr[1].Split('.');
            bool bIsContructor = (arrStrCon[arrStrCon.Length - 1].Trim() == arrStr[2].Trim()) ? true : false;

            frmBase frm;

            if (bIsContructor)
            {
                if (lstPara.Count > 0)
                    frm = (frmBase)Activator.CreateInstance(type, lstPara.ToArray());
                else
                    frm = (frmBase)Activator.CreateInstance(type);


            }
            else //Khong phai la contructor
            {
                frm = (frmBase)Activator.CreateInstance(type);
                frm.Object_ID = tsmi.Object_Id;
                //frm.Visible = false;

                if (lstPara.Count > 0)
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, lstPara.ToArray());
                else
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);
            }
            return frm;


            //
        }
		public static tsmiControl FindTsmi(MenuStrip ms, int iID)
		{
			for (int i = 0; i <= ms.Items.Count - 1; i++)
			{
				ToolStripMenuItem tsi = (ToolStripMenuItem)ms.Items[i];

				for (int j = 0; j <= tsi.DropDownItems.Count - 1; j++)
				{
					if (tsi.DropDownItems[j].GetType().ToString() == "Epoint.Systems.Controls.tsmiControl")
					{
						tsmiControl tsmi = (tsmiControl)tsi.DropDownItems[j];

						if (tsmi.ID == iID)
						{
							return tsmi;
						}
					}
				}
			}

			return null;
		}

		#endregion
		#region Working with zip
		public static void ZipFile(string strSourcePath, string strDestPath)
		{
			if (!System.IO.Directory.Exists(strSourcePath))
			{
				EpointMessage.MsgCancel(EpointMessage.GetMessage("PATH_NOTEXIST"));
				return;
			}

			if (Directory.GetFiles(strSourcePath).Length < 1)
			{
				EpointMessage.MsgCancel(EpointMessage.GetMessage("FILE_NOTEXIST"));
				return;
			}

			string[] sTemp = strSourcePath.Split('\\');
			string sZipFileName = sTemp[sTemp.Length - 1].ToString();

			if (!System.IO.Directory.Exists(strDestPath))
			{
				System.IO.Directory.CreateDirectory(strDestPath);
			}

			// zip up the files
			try
			{
				string[] filenames = Directory.GetFiles(strSourcePath);

				// Zip up the files - From SharpZipLib Demo Code
				using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(strDestPath + "\\" + sZipFileName + ".ept")))
				{
					zipStream.SetLevel(9); // 0-9, 9 being the highest level of compression

					byte[] buffer = new byte[4096];

					foreach (string file in filenames)
					{
						ZipEntry entry = new ZipEntry(Path.GetFileName(file));

						entry.DateTime = DateTime.Now;
						zipStream.PutNextEntry(entry);
						//zipStream.Password = 

						using (FileStream fs = File.OpenRead(file))
						{
							int sourceBytes;
							do
							{
								sourceBytes = fs.Read(buffer, 0, buffer.Length);
								zipStream.Write(buffer, 0, sourceBytes);

							} while (sourceBytes > 0);
						}
					}
					zipStream.Finish();
					zipStream.Close();
				}

				//MessageBox.Show("Epoint file " + strDestPath + " created.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Zip Operation Error");
			}
		}
		public static void ZipOneFile(string strFileName, string strDestPath, string strPwd)
		{
			if (!System.IO.File.Exists(strFileName))
			{
				EpointMessage.MsgCancel(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strFileName));
				return;
			}


			string[] sTemp = strFileName.Split('\\');
			string sZipFileName = sTemp[sTemp.Length - 1].ToString();

			if (!System.IO.Directory.Exists(strDestPath))
			{
				System.IO.Directory.CreateDirectory(strDestPath);
			}

			// zip up the files
			try
			{

				// Zip up the files - From SharpZipLib Demo Code
				using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(strDestPath + "\\" + sZipFileName + ".Epoint")))
				{
					zipStream.SetLevel(9); // 0-9, 9 being the highest level of compression

					byte[] buffer = new byte[4096];


					ZipEntry entry = new ZipEntry(Path.GetFileName(strFileName));

					entry.DateTime = DateTime.Now;
					zipStream.PutNextEntry(entry);


					using (FileStream fs = File.OpenRead(strFileName))
					{
						int sourceBytes;
						do
						{
							sourceBytes = fs.Read(buffer, 0, buffer.Length);
							zipStream.Write(buffer, 0, sourceBytes);

						} while (sourceBytes > 0);
					}
					zipStream.Password = strPwd;
					zipStream.Finish();
					zipStream.Close();
				}

				//MessageBox.Show("Epoint file " + strDestPath + " created.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Zip Operation Error");
			}
		}
		public static void UnZipFile(string strSourceFile, string strDestPath)
		{
			if (!File.Exists(strSourceFile))
				return;

			if (!Directory.Exists(strDestPath))
				Directory.CreateDirectory(strDestPath);

			ZipInputStream zipStream = new ZipInputStream(File.OpenRead(strSourceFile));
			ZipEntry entry;

			while ((entry = zipStream.GetNextEntry()) != null)
			{
				string fileName = Path.GetFileName(entry.Name);

				if (fileName != String.Empty)
				{
					if (entry.Name.IndexOf(".ini") < 0)
					{
						string fullPath = strDestPath + "\\" + entry.Name;
						fullPath = fullPath.Replace("\\ ", "\\");
						string fullDirPath = Path.GetDirectoryName(fullPath);

						FileStream streamWriter = File.Create(fullPath);
						int size = 2048;
						byte[] data = new byte[2048];
						while (true)
						{
							size = zipStream.Read(data, 0, data.Length);
							if (size > 0)
							{
								streamWriter.Write(data, 0, size);
							}
							else
							{
								break;
							}
						}
						streamWriter.Close();
					}
				}
			}
			zipStream.Close();
			//if (deleteZipFile)
			//    File.Delete(zipPathAndFile);
		}
		public static void UnZipFile(string strSourceFile, string strDestPath, string strPass)
		{
			if (!File.Exists(strSourceFile))
				return;

			if (!Directory.Exists(strDestPath))
				Directory.CreateDirectory(strDestPath);

			ZipInputStream zipStream = new ZipInputStream(File.OpenRead(strSourceFile));
			ZipEntry entry;
			zipStream.Password = strPass;
			while ((entry = zipStream.GetNextEntry()) != null)
			{
				string fileName = Path.GetFileName(entry.Name);

				if (fileName != String.Empty)
				{
					if (entry.Name.IndexOf(".ini") < 0)
					{
						string fullPath = strDestPath + "\\" + entry.Name;
						fullPath = fullPath.Replace("\\ ", "\\");
						string fullDirPath = Path.GetDirectoryName(fullPath);

						FileStream streamWriter = File.Create(fullPath);
						int size = 2048;
						byte[] data = new byte[2048];
						while (true)
						{
							size = zipStream.Read(data, 0, data.Length);
							if (size > 0)
							{
								streamWriter.Write(data, 0, size);
							}
							else
							{
								break;
							}
						}
						streamWriter.Close();
					}
				}
			}
			zipStream.Close();
			//if (deleteZipFile)
			//    File.Delete(zipPathAndFile);
		}
		public static String[] GetExcelSheetNames(string excelFile)
		{
			OleDbConnection objConn = null;
			DataTable dt = null;

			try
			{
				// Connection String. Change the excel file to the file you
				// will search.
				String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
				  "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
				// Create connection object by using the preceding connection string.
				objConn = new OleDbConnection(connString);
				// Open connection with the database.
				objConn.Open();
				// Get the data table containg the schema guid.
				dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				if (dt == null)
				{
					return null;
				}

				String[] excelSheets = new String[dt.Rows.Count];
				int i = 0;

				// Add the sheet name to the string array.
				foreach (DataRow row in dt.Rows)
				{
					excelSheets[i] = row["TABLE_NAME"].ToString();
					i++;
				}

				// Loop through all of the sheets if you want too...
				for (int j = 0; j < excelSheets.Length; j++)
				{
					// Query each excel sheet.
				}

				return excelSheets;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				// Clean up.
				if (objConn != null)
				{
					objConn.Close();
					objConn.Dispose();
				}
				if (dt != null)
				{
					dt.Dispose();
				}
			}
		}
		public static DataTable GetExcelToTable(string excelFile, string strSheetName)
		{
			OleDbConnection objConn = null;
			DataTable dt = null;

			try
			{
				// Connection String. Change the excel file to the file you
				// will search.
				String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
				  "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
				// Create connection object by using the preceding connection string.
				objConn = new OleDbConnection(connString);
				// Open connection with the database.
				objConn.Open();
				// Get the data table containg the schema guid.
				dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				if (dt == null)
				{
					return null;
				}
				OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + strSheetName + "]", objConn);
				DataSet ds = new DataSet();
				OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
				da.Fill(ds, strSheetName);
				objConn.Close();
				return ds.Tables[0];


			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				// Clean up.
				if (objConn != null)
				{
					objConn.Close();
					objConn.Dispose();
				}
				if (dt != null)
				{
					dt.Dispose();
				}
			}
		}
		public static DataTable GetExcelToTableByCmd(string excelFile, string strSelectCmd)
		{
			OleDbConnection objConn = null;
			DataTable dt = null;
			DataSet ds = new DataSet();
			try
			{
				// Connection String. Change the excel file to the file you
				// will search.
				String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
				  "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
				// Create connection object by using the preceding connection string.
				objConn = new OleDbConnection(connString);
				// Open connection with the database.
				objConn.Open();
				// Get the data table containg the schema guid.
				dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				if (dt == null)
				{
					return null;
				}

				OleDbCommand objCmdSelect = new OleDbCommand(strSelectCmd, objConn);
				OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
				da.Fill(ds);
				objConn.Close();
				return ds.Tables[0];


			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				// Clean up.
				if (objConn != null)
				{
					objConn.Close();
					objConn.Dispose();
				}

			}
		}
		public static MemoryStream UnZipOneFile(string strSourceFile, string strFileName)
		{
			if (!File.Exists(strSourceFile))
				return null;

			ZipInputStream zipStream = new ZipInputStream(File.OpenRead(strSourceFile));
			ZipEntry entry;

			MemoryStream memoryWriter = null;

			while ((entry = zipStream.GetNextEntry()) != null)
			{
				string fileName = Path.GetFileName(entry.Name);

				if (fileName.ToUpper() == strFileName.ToUpper())
				{
					memoryWriter = new MemoryStream();

					int size = 2048;
					byte[] data = new byte[2048];
					while (true)
					{
						size = zipStream.Read(data, 0, data.Length);
						if (size > 0)
						{
							memoryWriter.Write(data, 0, size);
						}
						else
						{
							break;
						}
					}
				}
			}
			zipStream.Close();

			memoryWriter.Position = 0;

			return memoryWriter;
		}
		public static MemoryStream UnZipOneFile(string strSourceFile, string strFileName, string strPassword)
		{
			if (!File.Exists(strSourceFile))
				return null;

			ZipInputStream zipStream = new ZipInputStream(File.OpenRead(strSourceFile));
			zipStream.Password = strPassword;
			ZipEntry entry;

			MemoryStream memoryWriter = null;

			while ((entry = zipStream.GetNextEntry()) != null)
			{
				string fileName = Path.GetFileName(entry.Name);

				//if (fileName.ToUpper() == strFileName.ToUpper())
				//{
				memoryWriter = new MemoryStream();

				int size = 2048;
				byte[] data = new byte[2048];
				while (true)
				{
					size = zipStream.Read(data, 0, data.Length);
					if (size > 0)
					{
						memoryWriter.Write(data, 0, size);
					}
					else
					{
						break;
					}
				}
				//}
			}
			zipStream.Close();

			memoryWriter.Position = 0;

			return memoryWriter;
		}
		#endregion
		public static bool SetBufferValueNotCheck(string strBufferName, object objBufferValue)
		{
			try
			{
				RegistryKey rk = Registry.CurrentUser;
				RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\Bluepoint\\EpointERP2018\\BufferValue\\");
				sk1.SetValue(strBufferName, objBufferValue);

				return true;
			}
			catch (Exception e)
			{
				return false;
			}

			return true;
		}
		public static bool SetBufferValue(string strBufferName, object objBufferValue)
		{
			try
			{
				RegistryKey rk = Registry.CurrentUser;
				RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\Bluepoint\\EpointERP2018\\BufferValue\\");
				sk1.SetValue(strBufferName, objBufferValue);

				return true;
			}
			catch (Exception e)
			{
				EpointMessage.MsgCancel("Writing registry " + strBufferName);
				return false;
			}

			return true;
		}

		public static string GetBufferValue(string strBufferName)
		{
			RegistryKey rk = Registry.CurrentUser;
			RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\Bluepoint\\EpointERP2018\\BufferValue\\");

			if (sk1 == null)
			{
				return string.Empty;
			}
			else
			{
				try
				{
					return (string)sk1.GetValue(strBufferName);
				}
				catch (Exception e)
				{
					return string.Empty;
				}
			}
		}

		public static void ShowPartition()
		{
			//Hiển thị Partition
			((frmMain)Element.frmMain).ssMain.tsilPartition.Text = Common.GetPartitionCurrent().ToString();
		}

		public static int GetPartitionCurrent()
		{
			if (!DataTool.SQLCheckExist("sys.Objects", "Name", "fn_PartitionCurrentGet"))
			{
				string strSQLExec = @"
					CREATE FUNCTION [dbo].[fn_PartitionCurrentGet]()
					RETURNS INT
					AS
					BEGIN

						DECLARE @_PartitionCurrent INT,
								@_Definition NVARCHAR(MAX)

						SELECT @_Definition = MAX(Definition) FROM sys.check_constraints WHERE Name LIKE '%PartitionData'

						IF (@_Definition IS NOT NULL AND LEN(@_Definition) > 20)
							SELECT @_PartitionCurrent = SUBSTRING(@_Definition, 14, 4)
						ELSE
							SELECT @_PartitionCurrent = 0

						RETURN @_PartitionCurrent
					END";

				SQLExec.Execute(strSQLExec);
			}

			return (int)(SQLExec.ExecuteReturnValue("SELECT dbo.fn_PartitionCurrentGet()"));
		}

		public static bool SelectPartition(int iYearNew)
		{
			return SQLExec.Execute("EXEC sp_PartitionChange " + iYearNew.ToString().Trim());

			#region
			//            int iYearCurrent;
			//            int iPartitionCurrent, iPartitionNew;

			//            string strSQLDefinition = SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Definition), '') FROM sys.check_constraints WHERE Name = 'CK_R80SoCai_PartitionData'").ToString().Trim();

			//            if (strSQLDefinition != string.Empty)
			//            {
			//                iYearCurrent = Convert.ToInt32(strSQLDefinition.Substring(13, 4));

			//                if (iYearNew != iYearCurrent)
			//                {
			//                    //Current
			//                    string strSQLExec = @"
			//						SELECT ISNULL(MAX(T2.Boundary_ID), 0) + 1
			//							FROM sys.Partition_Functions T1 JOIN sys.Partition_Range_Values T2 ON T1.Function_ID = T2.Function_ID
			//							WHERE T1.Name = 'PF_Epoint_DATA' AND T2.Value = CONVERT(DateTime, '" + iYearCurrent.ToString().Trim() + "0101')";

			//                    iPartitionCurrent = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec));

			//                    //New
			//                    strSQLExec = @"
			//						SELECT ISNULL(MAX(T2.Boundary_ID), 0) + 1
			//							FROM sys.Partition_Functions T1 JOIN sys.Partition_Range_Values T2 ON T1.Function_ID = T2.Function_ID
			//							WHERE T1.Name = 'PF_Epoint_DATA' AND T2.Value = CONVERT(DateTime, '" + iYearNew.ToString().Trim() + "0101')";

			//                    iPartitionNew = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec));

			//                    strSQLExec = @"
			//						SET XACT_ABORT ON
			//
			//						DECLARE @_Table_Name0 VARCHAR(100),
			//								@_TablePartition VARCHAR(100),
			//								@_strSQLExec NVARCHAR(MAX)
			//
			//						BEGIN TRANSACTION
			//
			//						DECLARE C_Partition CURSOR FOR SELECT Table_Name0 FROM SYSDMTABLE WHERE Is_Partition = 1
			//
			//						OPEN C_Partition
			//						FETCH NEXT FROM C_Partition INTO @_Table_Name0
			//						WHILE @@FETCH_STATUS = 0
			//						BEGIN
			//							SET @_TablePartition = SUBSTRING(@_Table_Name0, 1, 3) + 'P' + SUBSTRING(@_Table_Name0, 4, LEN(@_Table_Name0)-3) 
			//
			//							SET @_strSQLExec = '
			//								IF NOT EXISTS(SELECT * FROM sys.check_constraints WHERE Name = ''CK_' + @_Table_Name0 + '_PartitionData'')
			//									ALTER TABLE ' + @_Table_Name0 + ' ADD CONSTRAINT CK_' + @_Table_Name0 + '_PartitionData 
			//										CHECK (Ngay_Ct >= ''" + (iYearCurrent).ToString().Trim() + @"0101'' AND Ngay_Ct < ''" + (iYearCurrent + 1).ToString().Trim() + @"0101'')
			//
			//								ALTER TABLE ' + @_Table_Name0 + ' SWITCH TO ' + @_TablePartition + ' PARTITION " + iPartitionCurrent.ToString().Trim() + @"
			//							
			//								ALTER TABLE ' + @_Table_Name0 + ' DROP CK_' + @_Table_Name0 + '_PartitionData
			//
			//								ALTER TABLE ' + @_Table_Name0 + ' ADD CONSTRAINT CK_' + @_Table_Name0 + '_PartitionData 
			//									CHECK (Ngay_Ct >= ''" + (iYearNew).ToString().Trim() + @"0101'' AND Ngay_Ct < ''" + (iYearNew + 1).ToString().Trim() + @"0101'')
			//
			//								ALTER TABLE ' + @_TablePartition + ' SWITCH PARTITION " + iPartitionNew + @" TO ' + @_Table_Name0
			//
			//							EXEC(@_strSQLExec)
			//
			//							FETCH NEXT FROM C_Partition INTO @_Table_Name0
			//						END
			//						CLOSE C_Partition
			//						DEALLOCATE C_Partition
			//
			//						COMMIT TRANSACTION";

			//                    return SQLExec.Execute(strSQLExec);
			//                }
			//            }

			//            return true;
			#endregion
		}
		public static Color GetColorBoder()
		{
			string strColor = Parameters.GetParaValue("BORDERCOLOR").ToString();
			if (strColor == "")
				return Color.Transparent;
			else
				return Color.FromName(strColor);
		}
		public static void SetBorderControl(Control C, Color cl)
		{

			//foreach (Control ctrl in C.Controls)
			//{
			//    Graphics g = C.CreateGraphics();
			//    Rectangle newRect = new Rectangle(ctrl.Location.X - 1, ctrl.Location.Y - 1,
			//         ctrl.Width + 1, ctrl.Height + 1);
			//    g.DrawRectangle(new Pen(cl, 1), newRect);

			//}
		}
		public static string FormatNumToString(string num, string Scale, string Separate)
		{
			return SQLExec.ExecuteReturnValue("SELECT  dbo.fn_FormatNumber(" + num + "," + Scale + ",'" + Separate + "')").ToString();
		}

		#region email
		public static string SendMail(string strClientHost, string strClientCredentials, string strPassClient, string strFrom, string strFromDescr, string strTo, string strSubject, string strBody)
		{
			string strMeg = string.Empty;
			//Builed The MSG
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			//msg.To.Add("reciver@gmail.com");
			msg.To.Add(strTo);
			//msg.From = new MailAddress("dummy@gmail.com", "One Ghost", System.Text.Encoding.UTF8);
			msg.From = new MailAddress(strFrom, strFromDescr, System.Text.Encoding.UTF8);
			msg.Subject = strSubject;
			msg.SubjectEncoding = System.Text.Encoding.UTF8;
			msg.Body = strBody;
			msg.BodyEncoding = System.Text.Encoding.UTF8;
			msg.IsBodyHtml = true;
			msg.Priority = MailPriority.High;

			//Add the Creddentials
			SmtpClient client = new SmtpClient();
			client.Credentials = new System.Net.NetworkCredential(strClientCredentials, strPassClient);
			client.Port = 587;//or use 587            
							  //client.Host = "smtp.gmail.com";
			client.Host = strClientHost;
			client.EnableSsl = true;
			client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
			object userState = msg;
			try
			{
				//you can also call client.Send(msg)
				client.SendAsync(msg, userState);
				return "\nMessage sent " + strTo;

			}
			catch (System.Net.Mail.SmtpException ex)
			{
				return ex.Message + " \nSend Mail Error : " + strTo;
			}
		}
		private static void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
		{
			MailMessage mail = (MailMessage)e.UserState;
			string subject = mail.Subject;

			if (e.Cancelled)
			{
				//string cancelled = string.Format("[{0}] Send canceled.", subject);
				//MessageBox.Show(cancelled);
			}
			if (e.Error != null)
			{
				//string error = String.Format("[{0}] {1}", subject, e.Error.ToString());
				//MessageBox.Show(error);
			}
			else
			{
				//MessageBox.Show("Message sent.");
			}
			//mailSent = true;
		}
		public static void SaveFileText(string strFileName, string strText)
		{
			try
			{
				FileStream stream = new FileStream(strFileName, FileMode.Create);
				StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
				writer.WriteLine(strText);
				writer.Flush();
				writer.Close();
				stream.Close();

			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString(), "");
			}
		}
		#endregion







	}
}
