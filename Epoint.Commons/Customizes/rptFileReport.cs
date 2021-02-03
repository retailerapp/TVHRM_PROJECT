using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	/// <summary>
	/// Summary description for rptFileReport.
	/// </summary>
	public partial class rptFileReport : DataDynamics.ActiveReports.ActiveReport3
	{
        Dictionary<string, Line> dicLineBar = new Dictionary<string,Line>();
        private int TopPage = 0;
		public rptFileReport()
		{
			InitializeComponent();

			this.FetchData += new FetchEventHandler(rptFileReport_FetchData);
            this.ReportStart += new EventHandler(rptFileReport_ReportStart);
            this.detail.BeforePrint += new EventHandler(detail_BeforePrint);
			this.PageStart += new EventHandler(rptFileReport_PageStart);
			this.PageEnd += new EventHandler(rptFileReport_PageEnd);
			this.ReportEnd += new EventHandler(rptFileReport_ReportEnd);
		}

		void rptFileReport_ReportEnd(object sender, EventArgs e)
		{
			int i = 1;
		}

		void rptFileReport_PageEnd(object sender, EventArgs e)
		{
			int i = 1;
		}

		void rptFileReport_PageStart(object sender, EventArgs e)
		{
			
		}

        void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach(Line lineBar in dicLineBar.Values)
            {
                lineBar.Y1 = this.detail.Height - 0.01F;
                lineBar.Y2 = this.detail.Height - 0.01F;
            }
        }

        void rptFileReport_ReportStart(object sender, EventArgs e)
        {
			//Căn kích thước của ReportHeader
			foreach (ARControl arControl in this.reportHeader.Controls)
			{
				if (arControl.Tag != null && arControl.Tag.ToString().ToUpper() == "SUBTITLE2")
				{
					DataDynamics.ActiveReports.Label lblSubTitle2 = (DataDynamics.ActiveReports.Label)arControl;
					if (lblSubTitle2.Text.Trim() != string.Empty)
					{
						System.Windows.Forms.Label lblMeasure = new System.Windows.Forms.Label();
						lblMeasure.Font = lblSubTitle2.Font;

						float fHeight;
						fHeight = lblMeasure.CreateGraphics().MeasureString(lblSubTitle2.Text, lblMeasure.Font).Height;
						lblSubTitle2.Height = (float)fHeight / 100 + 0.1F;

					}
					//    this.reportHeader.Height = lblSubTitle2.Location.Y + lblSubTitle2.Height;
					//}
					//else
					//    this.reportHeader.Height = lblSubTitle2.Location.Y;

				}
			}

            foreach (ARControl arControl in this.detail.Controls)
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
		
		void rptFileReport_FetchData(object sender, ActiveReport3.FetchEventArgs eArgs)
		{
			foreach (ARControl arCtrl in this.detail.Controls)
			{
				if (arCtrl.GetType().Name == "TextBox")
				{
					DataDynamics.ActiveReports.TextBox txt = (DataDynamics.ActiveReports.TextBox)arCtrl;
                    Font ft = txt.Font;
					string strDataField = txt.DataField;

					//Bold
                    if (this.Fields.Contains("Bold"))
                    {
                        if ((bool)this.Fields["Bold"].Value == true)
                        {
                            txt.Font = new Font(txt.Font.FontFamily, txt.Font.Size, FontStyle.Bold);
                            //this.detail.NewPage = NewPage.After;
                        }
                        else
                        {
                            //txt.Font = ft;
                            txt.Font = new Font(txt.Font.FontFamily, txt.Font.Size, FontStyle.Regular);
                            //this.detail.NewPage = NewPage.None;
                        }
                    }

					if (this.Fields.Contains(strDataField) && txt.OutputFormat != null && txt.OutputFormat.Contains("#"))
					{
						if (Convert.ToDouble(this.Fields[strDataField].Value) == 0)
							txt.Visible = false;
						else
							txt.Visible = true;

						txt.Text = txt.Text.Replace(' ', '.');
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

                    //Bold
                    if (this.Fields.Contains("NewPage"))
                    {
                        if ((bool)this.Fields["NewPage"].Value == true && TopPage > 0)
                        {
                            this.detail.NewPage = NewPage.Before;
                        }
                        else
                        {
                            
                            this.detail.NewPage = NewPage.None;
                        }
                    }
                    //if (this.Fields.Contains("Ma_Vt"))
                    //{
                    //    if (this.Fields["Ma_Vt"].Value.ToString() == string.Empty)
                    //        this.detail.NewPage = NewPage.After;
                    //}
				}				
			}

            TopPage++;
		}
	}
}
