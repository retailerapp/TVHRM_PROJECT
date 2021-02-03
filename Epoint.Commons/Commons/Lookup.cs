using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Text;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Customizes;

namespace Epoint.Systems.Commons
{
	public class Lookup
	{
		/// <summary>
		/// Hiện thị Form Lookup, trả về DataRow
		/// </summary>
		/// <param name="frm">Form danh muc</param>
		/// <param name="strTableName">Tên bảng danh mục</param>
		/// <param name="strLookupColumn">Tên cột Lookup</param>
		/// <param name="strLookupValue">Giá trị nhập trên ô nhập</param>
		/// <param name="bLookupRequire">true: bắt buộc nhập DLiệu, fase: không bắt buộc </param>
		/// <param name="strLookupKeyFilter">Điều kiện lọc tu CSDL</param>
		/// <returns></returns>
		public static DataRow ShowLookup(frmView frm, string strTableName, string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter)
		{
			return ShowLookup(frm, strTableName, strLookupColumn, strLookupValue, bLookupRequire, strLookupKeyFilter, null);
		}

		/// <summary>
		/// Hiện thị Form Lookup, trả về DataRow
		/// </summary>
		/// <param name="frm">Form danh muc</param>
		/// <param name="strTableName">Tên bảng danh mục</param>
		/// <param name="strLookupColumn">Tên cột Lookup</param>
		/// <param name="strLookupValue">Giá trị nhập trên ô nhập</param>
		/// <param name="bLookupRequire">true: bắt buộc nhập DLiệu, fase: không bắt buộc </param>
		/// <param name="strLookupKeyFilter">Điều kiện lọc tu CSDL</param>
		/// /// <param name="strLookupKeyFilter">Kiểm tra Valid khi nhấn Enter</param>
		/// <returns></returns>
		public static DataRow ShowLookup(frmView frm, string strTableName, string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
		{
			strLookupValue = (strLookupValue == null? string.Empty: strLookupValue);
			strLookupValue = strLookupValue.ToUpper();

			//Nếu không cần bắt buộc nhập thì thoát
			if (!bLookupRequire && strLookupValue == string.Empty)
				return null;

			//Kiem tra co trong CSDL hay không
			string strWhere = "( " + strLookupColumn + " = N'" + strLookupValue + "' )";

			if (!(strLookupKeyFilter == null || strLookupKeyFilter == string.Empty))
				strWhere += " AND (" + strLookupKeyFilter + ")";

			if (!(strLookupKeyValid == null || strLookupKeyValid == string.Empty))
				strWhere += " AND (" + strLookupKeyValid + ")";

			//Kiem tra co trong CSDL hay không
			DataTable dtFind = DataTool.SQLGetDataTable(strTableName, null, strWhere, null);

			if (dtFind.Rows.Count == 1)
				return dtFind.Rows[0];

			else
			{//Hien Form Lookup

				frm.isLookup = true;
				frm.strLookupColumn = strLookupColumn;
				frm.strLookupValue = strLookupValue;
				frm.strLookupKeyFilter = strLookupKeyFilter;
				frm.strLookupKeyValid = strLookupKeyValid;

				frm.LoadToolStrip();
				frm.LoadLookup();

				return frm.drLookup;
			}

		}
        public static DataRow ShowLookup(frmView frm, string strTableName, string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid,string strOrder)
        {
            strLookupValue = (strLookupValue == null ? string.Empty : strLookupValue);
            strLookupValue = strLookupValue.ToUpper();

            //Nếu không cần bắt buộc nhập thì thoát
            if (!bLookupRequire && strLookupValue == string.Empty)
                return null;

            //Kiem tra co trong CSDL hay không
            string strWhere = "( " + strLookupColumn + " = N'" + strLookupValue + "' )";

            if (!(strLookupKeyFilter == null || strLookupKeyFilter == string.Empty))
                strWhere += " AND (" + strLookupKeyFilter + ")";

            if (!(strLookupKeyValid == null || strLookupKeyValid == string.Empty))
                strWhere += " AND (" + strLookupKeyValid + ")";

            //Kiem tra co trong CSDL hay không
            DataTable dtFind = DataTool.SQLGetDataTable(strTableName, null, strWhere, null);

            if (dtFind.Rows.Count == 1)
                return dtFind.Rows[0];

            else
            {//Hien Form Lookup

                frm.isLookup = true;
                frm.strLookupColumn = strLookupColumn;
                frm.strLookupValue = strLookupValue;
                frm.strLookupKeyFilter = strLookupKeyFilter;
                frm.strLookupKeyValid = strLookupKeyValid;
                frm.strLookupOrder = strOrder;

                frm.LoadToolStrip();
                frm.LoadLookup();

                return frm.drLookup;
            }

        }


        public static DataRow ShowLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter)
        {
            return ShowLookup(strLookupColumn, strLookupValue, bLookupRequire, strLookupKeyFilter, null);
        }
        public static DataRow ShowLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
        {
            return ShowLookup(strLookupColumn, strLookupValue, bLookupRequire, strLookupKeyFilter, strLookupKeyValid, null);
        }
        

        public static DataRow ShowLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid, Hashtable htFieldValue)
        {
            frmView view;
            Type type;
            strLookupValue = (strLookupValue == null) ? string.Empty : strLookupValue;
            strLookupValue = strLookupValue.ToUpper();
            DataRow row = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", strLookupColumn);
            if (row == null)
            {
                 EpointMessage.MsgCancel("Chưa khai báo Lookup cho [" + strLookupColumn + "]");
                return null;
            }
            if (!(bLookupRequire || !(strLookupValue == string.Empty)))
            {
                return null;
            }
            string strKey = string.Concat(new object[] { "( ", row["ColumnID_Lookup"], " = N'", strLookupValue, "' )" });
            if ((strLookupKeyFilter != null) && (strLookupKeyFilter != string.Empty))
            {
                strKey = strKey + " AND (" + strLookupKeyFilter + ")";
            }
            if ((strLookupKeyValid != null) && (strLookupKeyValid != string.Empty))
            {
                strKey = strKey + " AND (" + strLookupKeyValid + ")";
            }
            DataTable table = DataTool.SQLGetDataTable(row["Table_Lookup"].ToString(), null, strKey, null);
            if (table.Rows.Count == 1)
            {
                return table.Rows[0];
            }
            if (row == null)
            {
                 EpointMessage.MsgCancel("Bạn chưa khai báo Lookup");
                return null;
            }
            string str2 = row["Assembly"].ToString();
            try
            {
                type = Assembly.Load(str2.Split(new char[] { ':' })[0]).GetType("Epoint."+str2.Split(new char[] { ':' })[1]);
                view = (frmView)Activator.CreateInstance(type);
            }
            catch (Exception exception)
            {
                 EpointMessage.MsgCancel("Có lỗi xảy ra: " + exception.Message + "/nKiểm tra lại khai báo Lookup: " + str2);
                return null;
            }
            if (htFieldValue != null)
            {
                foreach (string str3 in htFieldValue.Keys)
                {
                    if (type.GetField(str3) != null)
                    {
                        type.GetField(str3).SetValue(view, htFieldValue[str3]);
                    }
                    else if (type.GetProperty(str3) != null)
                    {
                        type.GetProperty(str3).SetValue(view, htFieldValue[str3], null);
                    }
                    else
                    {
                         EpointMessage.MsgCancel("Không gán được biến truyền vào [" + str3 + "]");
                    }
                }
            }
                

            view.isLookup = true;
            view.strLookupColumn = row["ColumnID_Lookup"].ToString();
            view.strLookupValue = strLookupValue;
            view.strLookupKeyFilter = strLookupKeyFilter;
            view.strLookupKeyValid = strLookupKeyValid;



            view.LoadToolStrip();
            view.LoadLookup();
            return view.drLookup;
        }
       
        public static DataRow ShowMultiLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
        {
            strLookupValue = (strLookupValue == null) ? string.Empty : strLookupValue;
            strLookupValue = strLookupValue.ToUpper();
            DataRow row = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", strLookupColumn);
            frmQuickLookup lookup = new frmQuickLookup();
            lookup.bMuiltiLookup = true;
            lookup.isLookup = true;
            lookup.strLookupColumn = row["ColumnID_Lookup"].ToString();
            lookup.strLookupValue = strLookupValue;
            lookup.strLookupKeyFilter = strLookupKeyFilter;
            lookup.strLookupKeyValid = strLookupKeyValid;
            lookup.LoadLookup();
            return lookup.drLookup;
        }
        public static DataRow ShowQuickLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid)
        {
            strLookupValue = (strLookupValue == null) ? string.Empty : strLookupValue;
            strLookupValue = strLookupValue.ToUpper();
            DataRow row = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", strLookupColumn);
            if (row == null)
            {
                EpointMessage.MsgCancel("Chưa khai báo Lookup cho [" + strLookupColumn + "]");
                return null;
            }
            if (!(bLookupRequire || !(strLookupValue == string.Empty)))
            {
                return null;
            }
            string strKey = string.Concat(new object[] { "( ", row["ColumnID_Lookup"], " = N'", strLookupValue, "' )" });
            if ((strLookupKeyFilter != null) && (strLookupKeyFilter != string.Empty))
            {
                strKey = strKey + " AND (" + strLookupKeyFilter + ")";
            }
            if ((strLookupKeyValid != null) && (strLookupKeyValid != string.Empty))
            {
                strKey = strKey + " AND (" + strLookupKeyValid + ")";
            }
            DataTable table = DataTool.SQLGetDataTable(row["Table_Lookup"].ToString(), null, strKey, null);
            if (table.Rows.Count == 1)
            {
                return table.Rows[0];
            }
            frmQuickLookup lookup = new frmQuickLookup();
            lookup.bMuiltiLookup = false;
            lookup.isLookup = true;
            lookup.strLookupColumn = row["ColumnID_Lookup"].ToString();
            lookup.strLookupValue = strLookupValue;
            lookup.strLookupKeyFilter = strLookupKeyFilter;
            lookup.strLookupKeyValid = strLookupKeyValid;
            lookup.LoadLookup();
            return lookup.drLookup;
        }
        public static DataRow ShowMultiLookup(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid,string strOrder)
        {
            strLookupValue = (strLookupValue == null) ? string.Empty : strLookupValue;
            strLookupValue = strLookupValue.ToUpper();
            DataRow row = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", strLookupColumn);
            frmQuickLookup lookup = new frmQuickLookup();
            lookup.bMuiltiLookup = true;
            lookup.isLookup = true;
            lookup.strLookupColumn = row["ColumnID_Lookup"].ToString();
            lookup.strLookupValue = strLookupValue;
            lookup.strLookupKeyFilter = strLookupKeyFilter;
            lookup.strLookupKeyValid = strLookupKeyValid;
            lookup.strOrder = strOrder;
            lookup.LoadLookup();
            return lookup.drLookup;
        }

        public static DataRow ShowMultiLookupNew(string strLookupColumn, string strLookupValue, bool bLookupRequire, string strLookupKeyFilter, string strLookupKeyValid, string strOrder)
        {
            strLookupValue = (strLookupValue == null) ? string.Empty : strLookupValue;
            strLookupValue = strLookupValue.ToUpper();
            DataRow row = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", strLookupColumn);
            frmQuickLookupMulti lookup = new frmQuickLookupMulti();
            lookup.bMuiltiLookup = true;
            lookup.isLookup = true;
            lookup.strLookupColumn = row["ColumnID_Lookup"].ToString();
            lookup.strLookupValue = strLookupValue;
            lookup.strLookupKeyFilter = strLookupKeyFilter;
            lookup.strLookupKeyValid = strLookupKeyValid;
            lookup.strOrder = strOrder;
            lookup.LoadLookup();
            return lookup.drLookup;
        }

 

	}
}
