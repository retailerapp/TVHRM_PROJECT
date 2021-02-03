using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Epoint.Systems.Customizes
{
	/// <summary>
	/// Summary description for rptQuickReport.
	/// </summary>
	public partial class rptQuickReport : DataDynamics.ActiveReports.ActiveReport3
	{
        Dictionary<string, Line> dicLineBar = new Dictionary<string, Line>();

		public rptQuickReport()
		{
			InitializeComponent();

			this.FetchData +=new FetchEventHandler(rptQuickReport_FetchData);
            this.ReportStart += new EventHandler(rptFileReport_ReportStart);
            this.detail.BeforePrint += new EventHandler(detail_BeforePrint);	
		}

        void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (Line lineBar in dicLineBar.Values)
            {
                lineBar.Y1 = this.detail.Height - 0.01F;
                lineBar.Y2 = this.detail.Height - 0.01F;
            }
        }

        void rptFileReport_ReportStart(object sender, EventArgs e)
        {
            foreach (ARControl arControl in this.detail.Controls)
            {
                if (arControl.GetType().Name == "Line")
                {
                    if (arControl.GetType().Name == "Line")
                    {
                        Line line = (Line)arControl;
                        line.AnchorBottom = true;
                        if ((line.X1 != line.X2) && (line.Y1 == line.Y2))
                            dicLineBar[arControl.GetType().Name] = (Line)arControl;
                    }
                }
            }
        }

		void rptQuickReport_FetchData(object sender, ActiveReport3.FetchEventArgs eArgs)
		{
			foreach (ARControl arCtrl in this.detail.Controls)
			{
				if (arCtrl.GetType().Name == "TextBox")
				{
					DataDynamics.ActiveReports.TextBox txt = (DataDynamics.ActiveReports.TextBox)arCtrl;
					string strDataField = txt.DataField;

					//Bold
					if (this.Fields.Contains("Bold"))
					{
						if ((bool)this.Fields["Bold"].Value == true)
							txt.Font = new Font(txt.Font.FontFamily, txt.Font.Size, FontStyle.Bold);
						else
							txt.Font = new Font(txt.Font.FontFamily, txt.Font.Size, FontStyle.Regular);
					}

					if (this.Fields.Contains(strDataField) && txt.OutputFormat != null && txt.OutputFormat.Contains("#"))
					{
						if (Convert.ToDouble(this.Fields[strDataField].Value) == 0)
							txt.Visible = false;
						else
							txt.Visible = true;
					}

					//DateMin
					if (this.DataSource.GetType().Name == "DataTable")
					{
						DataTable dt = (DataTable)this.DataSource;

						if (dt.Columns.Contains(strDataField) && dt.Columns[strDataField].DataType.Name == "DateTime")
							if (this.Fields[strDataField].Value.ToString() == string.Empty || ((DateTime)this.Fields[strDataField].Value).ToString("dd/MM/yyyy") == "01/01/1900")
								txt.Visible = false;
							else
								txt.Visible = true;
					}
				}
			}
		}

	}
}
