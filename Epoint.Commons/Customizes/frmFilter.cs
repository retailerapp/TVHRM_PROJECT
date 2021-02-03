using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Controls;
using Epoint.Systems.Resources;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
	public partial class frmFilter : frmEdit
	{
		BindingSource bdsFilter;
		DataTable dtDataSource = new DataTable();
		DataTable dtColumnList = new DataTable();
		string strDefaultColumn = string.Empty;

		public frmFilter()
		{
			InitializeComponent();

			cboColumnList.DropDownClosed += new EventHandler(cbo_DropDownClosed);
			cboCompare.DropDownClosed += new EventHandler(cbo_DropDownClosed);
			cboValue.DropDownClosed += new EventHandler(cbo_DropDownClosed);
			cboLogical.DropDownClosed += new EventHandler(cbo_DropDownClosed);
			cboOperator.DropDownClosed += new EventHandler(cbo_DropDownClosed);
			cboFuntion.DropDownClosed += new EventHandler(cbo_DropDownClosed);

			btRun.Click += new EventHandler(btRun_Click);
			btExit.Click += new EventHandler(btExit_Click);
			btCancel.Click += new EventHandler(btCancel_Click);

			this.KeyDown += new KeyEventHandler(frmFilter_KeyDown);
		}

		new public void Load(object ExportControl)
		{
			//if (ExportControl == null)
			//{
			//    EpointMessage.MsgCancel("Chưa gán ExportControl");
			//    return;
			//}

			this.ExportControl = ExportControl;

			SetBindingSource();
			SetComboColumn();
			
			txtExpr.bSelectOnFocus = false;
			if (bdsFilter.Filter == null || bdsFilter.Filter == string.Empty)
			{
				txtExpr.Text = strDefaultColumn + " ";
				cboColumnList.SelectedValue = strDefaultColumn;
				SetComboValue(strDefaultColumn);
			}
			else
				txtExpr.Text = bdsFilter.Filter;

			this.ShowDialog();

		}

		protected override void OnShown(EventArgs e)
		{
			txtExpr.Focus();
			txtExpr.SelectionStart = txtExpr.Text.Length;

			base.OnShown(e);
		}

		void SetBindingSource()
		{		
			//dgvControl
			if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
			{
				dgvControl dgv = (dgvControl)ExportControl;

				if (dgv.DataSource == null)
					return;

				if (dgv.DataSource.GetType().Name != "BindingSource")
					return;

				BindingSource bds = (BindingSource)dgv.DataSource;
				if (bds == null)
					return;

				this.bdsFilter = bds;
				this.dtDataSource = (DataTable)bds.DataSource;

				dtColumnList = new DataTable();
				dtColumnList.Columns.Add("ColumnID", typeof(string));
				dtColumnList.Columns.Add("ColumnName", typeof(string));
				dtColumnList.Columns.Add("DataType", typeof(string));

				foreach (DataGridViewColumn dgvc in dgv.Columns)
				{
					if (!dtDataSource.Columns.Contains(dgvc.Name))
						continue;

					DataRow dr = dtColumnList.NewRow();
					dr["ColumnID"] = dgvc.DataPropertyName;
					dr["ColumnName"] = dgvc.HeaderText;
					dr["DataType"] = dgvc.ValueType.Name;

					dtColumnList.Rows.Add(dr);
				}

				if (dgv.CurrentCell != null)
					strDefaultColumn = dgv.Columns[dgv.CurrentCell.ColumnIndex].DataPropertyName;
			}
			//tlControl
			if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
			{
				tlControl tl = (tlControl)ExportControl;

				if (tl.DataSource == null)
					return;

				if (tl.DataSource.GetType().Name != "BindingSource")
					return;

				BindingSource bds = (BindingSource)tl.DataSource;
				if (bds == null)
					return;

				this.bdsFilter = bds;
				this.dtDataSource = (DataTable)bds.DataSource;

				dtColumnList = new DataTable();
				dtColumnList.Columns.Add("ColumnID", typeof(string));
				dtColumnList.Columns.Add("ColumnName", typeof(string));
				dtColumnList.Columns.Add("DataType", typeof(string));

				foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tlc in tl.Columns)
				{
					DataRow dr = dtColumnList.NewRow();
					dr["ColumnID"] = tlc.FieldName;
					dr["ColumnName"] = tlc.Caption;
					dr["DataType"] = tlc.ColumnType.Name;

					dtColumnList.Rows.Add(dr);
				}

				if (tl.FocusedColumn != null)
					strDefaultColumn = tl.FocusedColumn.FieldName;
			}
		}

		void SetComboColumn()
		{
			cboColumnList.DisplayMember = "ColumnName";
			cboColumnList.ValueMember = "ColumnID";
			cboColumnList.DataSource = dtColumnList;
			cboColumnList.Text = string.Empty;
		}

		void SetComboValue(string strColumnID)
		{
			cboValue.Items.Clear();

			foreach (DataRow dr in dtDataSource.Rows)
			{
				if (dr[strColumnID].ToString() != string.Empty && !cboValue.Items.Contains(dr[strColumnID].ToString()))
					cboValue.Items.Add(dr[strColumnID].ToString());
			}
		}

		bool ExpressionValid()
		{
			if (bdsFilter == null)
				return false;

			try
			{
				bdsFilter.Filter = txtExpr.Text;
			}
			catch (Exception ex)
			{
				EpointMessage.MsgCancel("Lỗi biểu thức: " + ex.Message);
				bdsFilter.Filter = string.Empty;

				return false;
			}

			return true;
		}

		void frmFilter_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt)
			{
				switch (e.KeyCode)
				{
					case Keys.T:
						cboColumnList.DroppedDown = true;
						break;

					case Keys.S:
						cboCompare.DroppedDown = true;
						cboCompare.Select();
						break;

					case Keys.G:
						cboValue.DroppedDown = true;
						break;

					case Keys.L:
						cboLogical.DroppedDown = true;
						break;

					case Keys.O:
						cboOperator.DroppedDown = true;
						break;

					case Keys.H:
						cboFuntion.DroppedDown = true;
						break;
				}
			}
		}

		void btRun_Click(object sender, EventArgs e)
		{
			if (ExpressionValid())
			{
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.txtExpr.Text = string.Empty;
			this.ExpressionValid();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void cbo_DropDownClosed(object sender, EventArgs e)
		{
			cboControl cbo = ((cboControl)sender);

			if (cbo.SelectedItem == null)
				return;

			int iSelecttion = txtExpr.SelectionStart;
			string strExpr = cbo.SelectedItem.ToString().Trim();

			string strName = cbo.Name;

			switch (strName)
			{
				case "cboColumnList":
					string strColumnID = (string)cbo.SelectedValue;
					SetComboValue(strColumnID);

					strExpr = strColumnID + " ";

					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr);
					this.ActiveControl = txtExpr;
					txtExpr.SelectionStart = iSelecttion + strExpr.Length;

					break;

				case "cboCompare": //> < =					
					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr + " ");
					this.ActiveControl = txtExpr;
					txtExpr.SelectionStart = iSelecttion + strExpr.Length + 1;

					break;

				case "cboValue":

					//Định dạng các kiểu dữ liệu
					if (cboColumnList.SelectedValue != null && cboColumnList.SelectedValue.ToString() != string.Empty)
					{
						if (Common.Inlist(dtDataSource.Columns[(string)cboColumnList.SelectedValue].DataType.Name, "String"))
							strExpr = "'" + strExpr + "'";
						else if (Common.Inlist(dtDataSource.Columns[(string)cboColumnList.SelectedValue].DataType.Name, "DateTime"))
							strExpr = "'" + strExpr + "'";
					}

					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr + " ");
					this.ActiveControl = txtExpr;

					txtExpr.SelectionStart = iSelecttion + strExpr.Length + 1;

					break;

				case "cboLogical": //AND, OR, NOT					
					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr + " ");
					this.ActiveControl = txtExpr;

					if (cboLogical.Text == "()")// Nhảy con trỏ vào giữa dấu ()
						txtExpr.SelectionStart = iSelecttion + 1;
					else
						txtExpr.SelectionStart = iSelecttion + strExpr.Length + 1;

					break;

				case "cboOperator": //+, -, *, /					
					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr + " ");
					this.ActiveControl = txtExpr;
					txtExpr.SelectionStart = iSelecttion + strExpr.Length + 1;

					break;

				case "cboFuntion": //TRIM(), ABS()

					txtExpr.Text = txtExpr.Text.Insert(iSelecttion, strExpr);
					this.ActiveControl = txtExpr;
					txtExpr.SelectionStart = iSelecttion + strExpr.Length - 1;

					break;

				default:
					break;
			}
		}
	}
}

