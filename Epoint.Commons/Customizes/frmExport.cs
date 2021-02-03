using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using Epoint.Systems;

namespace Epoint.Systems.Customizes
{
	public partial class frmExport : Epoint.Systems.Customizes.frmEdit
	{
		public string strPath = string.Empty;
		string strTen_Bc = string.Empty;

		public frmExport()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			btPath.Click += new EventHandler(btPath_Click);
			cboExportType.Validated += new EventHandler(cboExportType_Validated);
		}

		public void Load(string strTen_Bc)
		{
			this.strTen_Bc = strTen_Bc;

			//strPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Personal", @"C:\");
			//txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".xls";

			if (Commons.Common.GetBufferValue("EXPORT_EXCEL_PATH") == null)
				txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			else
				txtPath.Text = Commons.Common.GetBufferValue("EXPORT_EXCEL_PATH");

			txtPath.Text = txtPath.Text + (txtPath.Text.EndsWith(@"\") ? "" : @"\") + strTen_Bc.Trim() + ".xls";

			cboExportType.Text = cboExportType.Items[0].ToString();

			this.ShowDialog();
		}

		void cboExportType_Validated(object sender, EventArgs e)
		{
			if (Commons.Common.GetBufferValue("EXPORT_EXCEL_PATH") == null)
				strPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			else
				strPath = Commons.Common.GetBufferValue("EXPORT_EXCEL_PATH");

			switch (cboExportType.Text.Substring(0, 1))
			{
				case "1": //Excel
					txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".xls";
					break;
				case "2": //enuExportType.Word:
					txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".doc";
					break;
				case "3": //enuExportType.PDF:
					txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".pdf";
					break;
				case "4": //enuExportType.Html:
					txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".htm";
					break;
				case "5": //enuExportType.Foxpro
					txtPath.Text = strPath + @"\" + strTen_Bc.Trim() + ".dbf";
					break;
			}
		}

		void btPath_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfdlg = new SaveFileDialog();
			sfdlg.OverwritePrompt = true;
			sfdlg.InitialDirectory = Commons.Common.GetBufferValue("EXPORT_EXCEL_PATH");

			switch (cboExportType.Text.Substring(0, 1))
			{
				case "1": //enuExportType.Excel:
					sfdlg.DefaultExt = "xls";
					sfdlg.Filter = "*.xls|*.xls";
					break;
				case "2": //enuExportType.Word:
					sfdlg.DefaultExt = "doc";
					sfdlg.Filter = "*.doc|*.doc";
					break;
				case "3": //enuExportType.PDF:
					sfdlg.DefaultExt = "pdf";
					sfdlg.Filter = "*.pdf|*.pdf";
					break;
				case "4": //enuExportType.Html:
					sfdlg.DefaultExt = "Htm";
					sfdlg.Filter = "*.Htm|*.Htm";
					break;
				case "5": //enuExportType.Foxpro
					sfdlg.DefaultExt = "Dbf";
					sfdlg.Filter = "*.Dbf|*.Dbf";
					break;
			}

			if (sfdlg.ShowDialog() == DialogResult.OK)
			{
				strPath = sfdlg.FileName;
				txtPath.Text = strPath;

				Commons.Common.SetBufferValue("EXPORT_EXCEL_PATH", System.IO.Path.GetDirectoryName(sfdlg.FileName));
			}
		}	

		void btAccept_Click(object sender, EventArgs e)
		{
			strPath = txtPath.Text.Trim();

			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}
