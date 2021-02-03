using System.Resources;
using DataDynamics.ActiveReports.Chart;
using DataDynamics.ActiveReports;
using System.Data;
using System.Drawing;
using DataDynamics.ActiveReports.Chart.Graphics;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using DDCssLib;
namespace Epoint.Systems.Customizes
{
    partial class rptDoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptDoanhThu));
            DataDynamics.ActiveReports.Chart.ChartArea chartArea2 = new DataDynamics.ActiveReports.Chart.ChartArea();
            DataDynamics.ActiveReports.Chart.Axis axis6 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis7 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis8 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis9 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis10 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Legend legend2 = new DataDynamics.ActiveReports.Chart.Legend();
            DataDynamics.ActiveReports.Chart.Title title5 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Title title6 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Series series2 = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Title title7 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Title title8 = new DataDynamics.ActiveReports.Chart.Title();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.chartControl1 = new DataDynamics.ActiveReports.ChartControl();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.chartControl1});
            this.pageHeader.Height = 3.15625F;
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
            chartArea2.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.Graphics;
            axis6.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical;
            axis6.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis6.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1D, 0F, false);
            axis6.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis6.Title = "Axis X";
            axis6.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis7.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis7.LabelsGap = 0;
            axis7.LabelsVisible = false;
            axis7.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis7.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis7.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis7.Position = 0D;
            axis7.TickOffset = 0D;
            axis7.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis7.Visible = false;
            axis8.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis8.LabelsVisible = false;
            axis8.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis8.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis8.Position = 0D;
            axis8.Title = "Axis Y";
            axis8.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), -90F);
            axis9.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis9.LabelsVisible = false;
            axis9.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis9.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis9.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis9.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis9.Visible = false;
            axis10.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis10.LabelsGap = 0;
            axis10.LabelsVisible = false;
            axis10.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis10.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis10.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis10.Position = 0D;
            axis10.TickOffset = 0D;
            axis10.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis10.Visible = false;
            chartArea2.Axes.AddRange(new DataDynamics.ActiveReports.Chart.AxisBase[] {
            axis6,
            axis7,
            axis8,
            axis9,
            axis10});
            chartArea2.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
            chartArea2.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            chartArea2.Light = new DataDynamics.ActiveReports.Chart.Light(new DataDynamics.ActiveReports.Chart.Graphics.Point3d(10F, 40F, 20F), DataDynamics.ActiveReports.Chart.LightType.InfiniteDirectional, 0.3F);
            chartArea2.Name = "defaultArea";
            chartArea2.Projection = new DataDynamics.ActiveReports.Chart.Projection(DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal, 0.1F, 0.1F, 0F, 37F);
            this.chartControl1.ChartAreas.AddRange(new DataDynamics.ActiveReports.Chart.ChartArea[] {
            chartArea2});
            this.chartControl1.ChartBorder = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            this.chartControl1.Height = 3.125F;
            this.chartControl1.Left = 0F;
            legend2.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Bottom;
            legend2.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(System.Drawing.Color.White, ((byte)(128)));
            legend2.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(), 0, System.Drawing.Color.Black);
            legend2.DockArea = chartArea2;
            title5.Backdrop = new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
            title5.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title5.DockArea = null;
            title5.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title5.Name = "";
            title5.Text = "";
            title5.Visible = false;
            legend2.Footer = title5;
            legend2.GridLayout = new DataDynamics.ActiveReports.Chart.GridLayout(2, 4);
            title6.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 2), 0, System.Drawing.Color.Black);
            title6.DockArea = null;
            title6.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title6.Name = "";
            title6.Text = "Legend";
            title6.Visible = false;
            legend2.Header = title6;
            legend2.LabelsFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            legend2.Name = "defaultLegend";
            this.chartControl1.Legends.AddRange(new DataDynamics.ActiveReports.Chart.Legend[] {
            legend2});
            this.chartControl1.Name = "chartControl1";
            series2.AxisX = axis6;
            series2.AxisY = axis8;
            series2.ChartArea = chartArea2;
            series2.ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Default;
            series2.Legend = legend2;
            series2.LegendText = "";
            series2.Name = "Series1";
            series2.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            new DataDynamics.ActiveReports.Chart.KeyValuePair("HoleSize", 0F),
            new DataDynamics.ActiveReports.Chart.KeyValuePair("Marker", new DataDynamics.ActiveReports.Chart.Marker(7, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 8F)), "{Value}", DataDynamics.ActiveReports.Chart.Alignment.Bottom))),
            new DataDynamics.ActiveReports.Chart.KeyValuePair("BarType", DataDynamics.ActiveReports.Chart.BarType.Bar)});
            series2.Type = DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D;
            series2.ValueMembersY = null;
            series2.ValueMemberX = null;
            this.chartControl1.Series.AddRange(new DataDynamics.ActiveReports.Chart.Series[] {
            series2});
            title7.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center;
            title7.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title7.DockArea = null;
            title7.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title7.Name = "header";
            title7.Text = "Chart title";
            title7.Visible = false;
            title8.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title8.DockArea = null;
            title8.Docking = DataDynamics.ActiveReports.Chart.DockType.Bottom;
            title8.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title8.Name = "footer";
            title8.Text = "Chart Footer";
            title8.Visible = false;
            this.chartControl1.Titles.AddRange(new DataDynamics.ActiveReports.Chart.Title[] {
            title7,
            title8});
            this.chartControl1.Top = 0F;
            this.chartControl1.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting;
            this.chartControl1.Width = 5F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0.0625F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // rptDoanhThu
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 4F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 4F;
            this.PrintWidth = 5.020833F;
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private ChartControl chartControl1;
        private Detail detail;
        private DataTable dtDoanhThu;
        public float fHeight = 0f;
        public float fWidth = 0f;
        private PageFooter pageFooter;
        private PageHeader pageHeader;



 


        #endregion
    }
}
