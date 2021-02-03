namespace Epoint.Systems.Customizes
{
	/// <summary>
	/// Summary description for rptFileReport.
	/// </summary>
	partial class rptFileReport
	{	

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			base.Dispose(disposing);
		}

		#region ActiveReport Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptFileReport));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
			this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
			this.reportHeader = new DataDynamics.ActiveReports.ReportHeader();
			this.reportFooter = new DataDynamics.ActiveReports.ReportFooter();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Height = 0F;
			this.pageHeader.Name = "pageHeader";
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Height = 0.28125F;
			this.detail.Name = "detail";
			// 
			// pageFooter
			// 
			this.pageFooter.Height = 0F;
			this.pageFooter.Name = "pageFooter";
			// 
			// groupHeader1
			// 
			this.groupHeader1.Height = 0F;
			this.groupHeader1.Name = "groupHeader1";
			// 
			// groupFooter1
			// 
			this.groupFooter1.Height = 0F;
			this.groupFooter1.Name = "groupFooter1";
			// 
			// reportHeader
			// 
			this.reportHeader.Height = 0.25F;
			this.reportHeader.Name = "reportHeader";
			// 
			// reportFooter
			// 
			this.reportFooter.Height = 0.25F;
			this.reportFooter.Name = "reportFooter";
			// 
			// rptFileReport
			// 
			this.MasterReport = false;
			this.PageSettings.Margins.Bottom = 0F;
			this.PageSettings.Margins.Left = 0F;
			this.PageSettings.Margins.Right = 0F;
			this.PageSettings.Margins.Top = 0F;
			this.PageSettings.PaperHeight = 11F;
			this.PageSettings.PaperWidth = 8.5F;
			this.Sections.Add(this.reportHeader);
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.groupHeader1);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.groupFooter1);
			this.Sections.Add(this.pageFooter);
			this.Sections.Add(this.reportFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
						"l; font-size: 10pt; color: Black; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		public DataDynamics.ActiveReports.PageHeader pageHeader;
		
		public DataDynamics.ActiveReports.Detail detail;
		public DataDynamics.ActiveReports.PageFooter pageFooter;

		public DataDynamics.ActiveReports.GroupHeader groupHeader1;
		public DataDynamics.ActiveReports.GroupFooter groupFooter1;
		
		public DataDynamics.ActiveReports.ReportHeader reportHeader;
		public DataDynamics.ActiveReports.ReportFooter reportFooter;
	}
}
