namespace Epoint.Systems.Customizes
{
	/// <summary>
	/// Summary description for rptFileReport.
	/// </summary>
	partial class rptChart
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptChart));
			DataDynamics.ActiveReports.Chart.ChartArea chartArea1 = new DataDynamics.ActiveReports.Chart.ChartArea();
			DataDynamics.ActiveReports.Chart.Axis axis1 = new DataDynamics.ActiveReports.Chart.Axis();
			DataDynamics.ActiveReports.Chart.Axis axis2 = new DataDynamics.ActiveReports.Chart.Axis();
			DataDynamics.ActiveReports.Chart.Axis axis3 = new DataDynamics.ActiveReports.Chart.Axis();
			DataDynamics.ActiveReports.Chart.Axis axis4 = new DataDynamics.ActiveReports.Chart.Axis();
			DataDynamics.ActiveReports.Chart.Axis axis5 = new DataDynamics.ActiveReports.Chart.Axis();
			DataDynamics.ActiveReports.Chart.Legend legend1 = new DataDynamics.ActiveReports.Chart.Legend();
			DataDynamics.ActiveReports.Chart.Title title1 = new DataDynamics.ActiveReports.Chart.Title();
			DataDynamics.ActiveReports.Chart.Title title2 = new DataDynamics.ActiveReports.Chart.Title();
			DataDynamics.ActiveReports.Chart.Series series1 = new DataDynamics.ActiveReports.Chart.Series();
			DataDynamics.ActiveReports.Chart.Title title3 = new DataDynamics.ActiveReports.Chart.Title();
			DataDynamics.ActiveReports.Chart.Title title4 = new DataDynamics.ActiveReports.Chart.Title();
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.chartControl1 = new DataDynamics.ActiveReports.ChartControl();
			this.lblSubTitle1 = new DataDynamics.ActiveReports.Label();
			this.lblTitle = new DataDynamics.ActiveReports.Label();
			this.lblSubTitle2 = new DataDynamics.ActiveReports.Label();
			this.lblTen_Dv_Cq = new DataDynamics.ActiveReports.Label();
			this.lblDia_Chi_Dv = new DataDynamics.ActiveReports.Label();
			this.lblTen_Dv = new DataDynamics.ActiveReports.Label();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSubTitle1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSubTitle2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTen_Dv_Cq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDia_Chi_Dv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTen_Dv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.chartControl1,
            this.lblSubTitle1,
            this.lblTitle,
            this.lblSubTitle2,
            this.lblTen_Dv_Cq,
            this.lblDia_Chi_Dv,
            this.lblTen_Dv});
			this.pageHeader.Height = 6.052083F;
			this.pageHeader.Name = "pageHeader";
			// 
			// chartControl1
			// 
			this.chartControl1.AutoRefresh = true;
			this.chartControl1.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Color.White, System.Drawing.Color.SteelBlue);
			this.chartControl1.Border.BottomColor = System.Drawing.Color.Black;
			this.chartControl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.chartControl1.Border.LeftColor = System.Drawing.Color.Black;
			this.chartControl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.chartControl1.Border.RightColor = System.Drawing.Color.Black;
			this.chartControl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.chartControl1.Border.TopColor = System.Drawing.Color.Black;
			this.chartControl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			chartArea1.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.None;
			axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical;
			axis1.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis1.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1, 0F, false);
			axis1.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis1.StaggerLabels = true;
			axis1.Title = "Axis X (Trục hoành)";
			axis1.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis2.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis2.LabelsGap = 0;
			axis2.LabelsVisible = false;
			axis2.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
			axis2.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis2.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis2.Position = 0;
			axis2.TickOffset = 0;
			axis2.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis2.Visible = false;
			axis3.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis3.LabelsVisible = false;
			axis3.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis3.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis3.Position = 0;
			axis3.Title = "Axis Y (Trục tung)";
			axis3.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), -90F);
			axis4.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis4.LabelsVisible = false;
			axis4.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
			axis4.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis4.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis4.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis4.Visible = false;
			axis5.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis5.LabelsGap = 0;
			axis5.LabelsVisible = false;
			axis5.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
			axis5.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis5.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
			axis5.Position = 0;
			axis5.TickOffset = 0;
			axis5.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			axis5.Visible = false;
			chartArea1.Axes.AddRange(new DataDynamics.ActiveReports.Chart.AxisBase[] {
            axis1,
            axis2,
            axis3,
            axis4,
            axis5});
			chartArea1.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
			chartArea1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
			chartArea1.Light = new DataDynamics.ActiveReports.Chart.Light(new DataDynamics.ActiveReports.Chart.Graphics.Point3d(10F, 40F, 20F), DataDynamics.ActiveReports.Chart.LightType.InfiniteDirectional, 0.3F);
			chartArea1.Name = "defaultArea";
			chartArea1.Projection = new DataDynamics.ActiveReports.Chart.Projection(DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal, 0.1F, 0.1F);
			this.chartControl1.ChartAreas.AddRange(new DataDynamics.ActiveReports.Chart.ChartArea[] {
            chartArea1});
			this.chartControl1.ChartBorder = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
			this.chartControl1.Height = 4.35F;
			this.chartControl1.Left = 0.775F;
			legend1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
			legend1.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(System.Drawing.Color.White, ((byte)(128)));
			legend1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(), 0, System.Drawing.Color.Black);
			legend1.DockArea = null;
			title1.Backdrop = new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
			title1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
			title1.DockArea = null;
			title1.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			title1.Name = "";
			title1.Text = "";
			legend1.Footer = title1;
			title2.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 2), 0, System.Drawing.Color.Black);
			title2.DockArea = null;
			title2.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			title2.Name = "";
			title2.Text = "Legend";
			legend1.Header = title2;
			legend1.LabelsFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			legend1.Name = "defaultLegend";
			this.chartControl1.Legends.AddRange(new DataDynamics.ActiveReports.Chart.Legend[] {
            legend1});
			this.chartControl1.Name = "chartControl1";
			series1.AxisX = axis1;
			series1.AxisY = axis3;
			series1.ChartArea = chartArea1;
			series1.Legend = legend1;
			series1.LegendText = "";
			series1.Name = "Series1";
			series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
			series1.ValueMembersY = null;
			series1.ValueMemberX = null;
			this.chartControl1.Series.AddRange(new DataDynamics.ActiveReports.Chart.Series[] {
            series1});
			title3.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center;
			title3.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
			title3.DockArea = null;
			title3.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold));
			title3.Name = "header";
			title3.Text = "Chart title";
			title3.Visible = false;
			title4.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
			title4.DockArea = null;
			title4.Docking = DataDynamics.ActiveReports.Chart.DockType.Bottom;
			title4.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
			title4.Name = "footer";
			title4.Text = "Chart Footer";
			title4.Visible = false;
			this.chartControl1.Titles.AddRange(new DataDynamics.ActiveReports.Chart.Title[] {
            title3,
            title4});
			this.chartControl1.Top = 1.5F;
			this.chartControl1.Width = 6.4F;
			// 
			// lblSubTitle1
			// 
			this.lblSubTitle1.Border.BottomColor = System.Drawing.Color.Black;
			this.lblSubTitle1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle1.Border.LeftColor = System.Drawing.Color.Black;
			this.lblSubTitle1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle1.Border.RightColor = System.Drawing.Color.Black;
			this.lblSubTitle1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle1.Border.TopColor = System.Drawing.Color.Black;
			this.lblSubTitle1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle1.Height = 0.2F;
			this.lblSubTitle1.HyperLink = "";
			this.lblSubTitle1.Left = 0.7250001F;
			this.lblSubTitle1.Name = "lblSubTitle1";
			this.lblSubTitle1.Style = "ddo-char-set: 1; text-align: center; font-style: italic; font-size: 10pt; font-fa" +
				"mily: Arial; ";
			this.lblSubTitle1.Tag = "SubTitle1";
			this.lblSubTitle1.Text = "SubTitle1";
			this.lblSubTitle1.Top = 1F;
			this.lblSubTitle1.Width = 6.375F;
			// 
			// lblTitle
			// 
			this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
			this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
			this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
			this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
			this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTitle.Height = 0.3F;
			this.lblTitle.HyperLink = "";
			this.lblTitle.Left = 0.7250001F;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 18pt; font-fam" +
				"ily: Arial; ";
			this.lblTitle.Tag = "Title";
			this.lblTitle.Text = "Title";
			this.lblTitle.Top = 0.675F;
			this.lblTitle.Width = 6.375F;
			// 
			// lblSubTitle2
			// 
			this.lblSubTitle2.Border.BottomColor = System.Drawing.Color.Black;
			this.lblSubTitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle2.Border.LeftColor = System.Drawing.Color.Black;
			this.lblSubTitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle2.Border.RightColor = System.Drawing.Color.Black;
			this.lblSubTitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle2.Border.TopColor = System.Drawing.Color.Black;
			this.lblSubTitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblSubTitle2.Height = 0.2F;
			this.lblSubTitle2.HyperLink = "";
			this.lblSubTitle2.Left = 0.7250001F;
			this.lblSubTitle2.Name = "lblSubTitle2";
			this.lblSubTitle2.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-style: normal; font-" +
				"size: 10pt; font-family: Arial; ";
			this.lblSubTitle2.Tag = "SubTitle2";
			this.lblSubTitle2.Text = "SubTitle2";
			this.lblSubTitle2.Top = 1.2F;
			this.lblSubTitle2.Width = 6.375F;
			// 
			// lblTen_Dv_Cq
			// 
			this.lblTen_Dv_Cq.Border.BottomColor = System.Drawing.Color.Black;
			this.lblTen_Dv_Cq.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv_Cq.Border.LeftColor = System.Drawing.Color.Black;
			this.lblTen_Dv_Cq.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv_Cq.Border.RightColor = System.Drawing.Color.Black;
			this.lblTen_Dv_Cq.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv_Cq.Border.TopColor = System.Drawing.Color.Black;
			this.lblTen_Dv_Cq.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv_Cq.Height = 0.1875F;
			this.lblTen_Dv_Cq.HyperLink = "";
			this.lblTen_Dv_Cq.Left = 0.3F;
			this.lblTen_Dv_Cq.Name = "lblTen_Dv_Cq";
			this.lblTen_Dv_Cq.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; font-family: Arial; ";
			this.lblTen_Dv_Cq.Tag = "";
			this.lblTen_Dv_Cq.Text = "Ten_Dv_Cq";
			this.lblTen_Dv_Cq.Top = 0.05F;
			this.lblTen_Dv_Cq.Width = 4.125F;
			// 
			// lblDia_Chi_Dv
			// 
			this.lblDia_Chi_Dv.Border.BottomColor = System.Drawing.Color.Black;
			this.lblDia_Chi_Dv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblDia_Chi_Dv.Border.LeftColor = System.Drawing.Color.Black;
			this.lblDia_Chi_Dv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblDia_Chi_Dv.Border.RightColor = System.Drawing.Color.Black;
			this.lblDia_Chi_Dv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblDia_Chi_Dv.Border.TopColor = System.Drawing.Color.Black;
			this.lblDia_Chi_Dv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblDia_Chi_Dv.Height = 0.1875F;
			this.lblDia_Chi_Dv.HyperLink = "";
			this.lblDia_Chi_Dv.Left = 0.3F;
			this.lblDia_Chi_Dv.Name = "lblDia_Chi_Dv";
			this.lblDia_Chi_Dv.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; font-family: Arial; ";
			this.lblDia_Chi_Dv.Tag = "";
			this.lblDia_Chi_Dv.Text = "Dia_Chi_Dv";
			this.lblDia_Chi_Dv.Top = 0.45F;
			this.lblDia_Chi_Dv.Width = 4.125F;
			// 
			// lblTen_Dv
			// 
			this.lblTen_Dv.Border.BottomColor = System.Drawing.Color.Black;
			this.lblTen_Dv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv.Border.LeftColor = System.Drawing.Color.Black;
			this.lblTen_Dv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv.Border.RightColor = System.Drawing.Color.Black;
			this.lblTen_Dv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv.Border.TopColor = System.Drawing.Color.Black;
			this.lblTen_Dv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.lblTen_Dv.Height = 0.1875F;
			this.lblTen_Dv.HyperLink = "";
			this.lblTen_Dv.Left = 0.3F;
			this.lblTen_Dv.Name = "lblTen_Dv";
			this.lblTen_Dv.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; font-family: Arial; ";
			this.lblTen_Dv.Tag = "";
			this.lblTen_Dv.Text = "Ten_Dv";
			this.lblTen_Dv.Top = 0.25F;
			this.lblTen_Dv.Width = 4.125F;
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Height = 0F;
			this.detail.Name = "detail";
			// 
			// pageFooter
			// 
			this.pageFooter.Height = 0F;
			this.pageFooter.Name = "pageFooter";
			// 
			// rptChart
			// 
			this.MasterReport = false;
			this.PageSettings.Margins.Bottom = 0F;
			this.PageSettings.Margins.Left = 0F;
			this.PageSettings.Margins.Right = 0F;
			this.PageSettings.Margins.Top = 0F;
			this.PageSettings.PaperHeight = 11F;
			this.PageSettings.PaperWidth = 8.5F;
			this.PrintWidth = 8.125F;
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
						"l; font-size: 10pt; color: Black; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSubTitle1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSubTitle2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTen_Dv_Cq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDia_Chi_Dv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTen_Dv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		public DataDynamics.ActiveReports.PageHeader pageHeader;
		
		public DataDynamics.ActiveReports.Detail detail;
		public DataDynamics.ActiveReports.PageFooter pageFooter;
		public DataDynamics.ActiveReports.ChartControl chartControl1;		
		public DataDynamics.ActiveReports.Label lblTitle;
		public DataDynamics.ActiveReports.Label lblSubTitle1;
		public DataDynamics.ActiveReports.Label lblSubTitle2;
		public DataDynamics.ActiveReports.Label lblTen_Dv_Cq;
		public DataDynamics.ActiveReports.Label lblDia_Chi_Dv;
		public DataDynamics.ActiveReports.Label lblTen_Dv;
	}
}
