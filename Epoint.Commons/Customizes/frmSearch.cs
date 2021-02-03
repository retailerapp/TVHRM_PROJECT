using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
	public partial class frmSearch : frmBase
	{
		public BindingSource bdsSearch;
        public string strZoneSearch;

		private List<int> lstSearch = new List<int>();
		public int iCurrentPotition = -1;
		public string strTextSearch = string.Empty;

		public frmSearch()
		{
			InitializeComponent();

			this.FormLayout();

			this.btSearch.Click += new EventHandler(btSearch_Click);
			this.btOption.Click += new EventHandler(btOption_Click);
			this.btClose.Click += new EventHandler(btClose_Click);
		}

		void FormLayout()
		{
			if (this.gbOption.Visible)
			{
				this.Height = this.Height + this.gbOption.Height;
				this.btOption.Text += " >>";
			}
			else
			{
				this.Height = this.Height - this.gbOption.Height;
				this.btOption.Text += " <<";
			}
		}

		public void StartSearch()
		{
			strTextSearch = cboSearch.Text.Trim();

			//không tìm kiếm với chuỗi rỗng
			if (strTextSearch == string.Empty)
				return;

			if (bdsSearch == null || bdsSearch.DataSource == null)
			{
				EpointMessage.MsgOk(Librarys.Languages.GetLanguage("Not_Assign_Search"));
				return;
			}

			lstSearch.Clear();

			DataRow[] drArr = new DataRow[bdsSearch.Count];
           
            
            //dgvControl dgvSearch = (dgvControl)this.ExportControl;


			switch (bdsSearch.DataSource.GetType().Name)
			{
				case "DataSet":
					if (((DataSet)bdsSearch.DataSource).Tables.Contains(bdsSearch.DataMember))
						drArr = ((DataSet)bdsSearch.DataSource).Tables[bdsSearch.DataMember].Select(bdsSearch.Filter);

					break;

				case "DataTable":
					drArr = ((DataTable)bdsSearch.DataSource).Select(bdsSearch.Filter);

					break;
			}

			for (int i = 0; i <= drArr.Length - 1; i++)
			{//Chạy hàng

				bool bFound = false;

				DataRow dr = drArr[i];

				for (int j = 0; j <= dr.Table.Columns.Count - 1; j++)
				{//Chạy cột

                    string strColumnName = dr.Table.Columns[j].ColumnName;

                    if(this.strZoneSearch!= null && this.strZoneSearch!=string.Empty)
                    {
                        //lblZone.Text = this.strZoneSearch;
                        DataTable dtColumn = Data.DataTool.SQLGetDataTable("SYSColumn", "", "Zone  = '" + this.strZoneSearch + "' AND Column_ID = '" + strColumnName + "' AND Visible = 1 ", "");
                        if (dtColumn.Rows.Count == 0)
                        {
                            //DataRow drC = dtColumn.Rows[0]; 
                            continue;
                        }
                    }

					if (rdbStartwith.Checked)
					{
						if (chkMatch_Case.Checked)
						{
							if (dr[j].ToString().Trim().StartsWith(strTextSearch))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
						else
						{
							if (dr[j].ToString().Trim().ToLower().StartsWith(strTextSearch.ToLower()))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
					}
					else if (rdbEndwith.Checked)
					{
						if (chkMatch_Case.Checked)
						{
							if (dr[j].ToString().Trim().EndsWith(strTextSearch))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
						else
						{
							if (dr[j].ToString().Trim().ToLower().EndsWith(strTextSearch.ToLower()))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
					}
					else if (rdbConstains.Checked)
					{
						if (chkMatch_Case.Checked)
						{
							if (dr[j].ToString().Trim().Contains(strTextSearch))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
						else
						{
							if (dr[j].ToString().Trim().ToLower().Contains(strTextSearch.ToLower()))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
					}
					else if (rdbEquals.Checked)
					{
						if (chkMatch_Case.Checked)
						{
							if (dr[j].ToString().Trim().Equals(strTextSearch))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
						else
						{
							if (dr[j].ToString().Trim().ToLower().Equals(strTextSearch.ToLower()))
							{
								lstSearch.Add(i);
								bFound = true;
							}
						}
					}

					if (bFound)// tìm thấy trên cột
						break;// thoat khoi vong lặp j
				}
			}

			GoNext();
		}

		public void GoNext()
		{
			if (cboSearch.Text.Trim() == string.Empty)
			{
				lstSearch.Clear();
				return;
			}

			if (strTextSearch != cboSearch.Text.Trim())
			{
				StartSearch();
				return;
			}

			int iPositionFirstFound = -1;
			int iPositionLastFound = -1;

			for (int i = 0; i <= lstSearch.Count - 1; i++)
			{
				//Vi tri dau tien
				if (i == 0)
					iPositionFirstFound = lstSearch[i];

				//Vi tri cuoi cung
				if (i == lstSearch.Count - 1)
					iPositionLastFound = lstSearch[i];

				if (lstSearch[i] >= iCurrentPotition)
				{
					iCurrentPotition = lstSearch[i];
					break;
				}
			}

			if (lstSearch.Count == 0)
			{
				EpointMessage.MsgOk(Librarys.Languages.GetLanguage("Not_Found") + "'" + strTextSearch + "'");
				return;
			}

			bdsSearch.Position = iCurrentPotition;

			if (iPositionLastFound >= 0)
				iCurrentPotition = iPositionFirstFound;
			else
				iCurrentPotition++;
		}

		void btOption_Click(object sender, EventArgs e)
		{
			this.gbOption.Visible = !this.gbOption.Visible;
			this.FormLayout();
		}

		void btSearch_Click(object sender, EventArgs e)
		{
			this.StartSearch();
		}

		void btClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			cboSearch.Focus();
		}
		protected override void OnClosed(EventArgs e)
		{
			this.Hide();

			//base.OnClosed(e);
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			base.OnClosing(e);
		}
	}
}