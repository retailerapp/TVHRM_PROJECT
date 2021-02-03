using System.Windows.Forms;
using System.Drawing;

namespace Epoint.Modules.HRM
{
    partial class frmResourceAnalysis
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResourceAnalysis));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dteTodate = new Epoint.Systems.Controls.dteDateTime();
            this.dteFromDate = new Epoint.Systems.Controls.dteDateTime();
            this.lblSize = new Epoint.Systems.Controls.lbtControl();
            this.btTag_List = new Epoint.Systems.Controls.btControl();
            this.btMa_Bp_Tag = new Epoint.Systems.Controls.btControl();
            this.btLoadData = new Epoint.Systems.Controls.btControl();
            this.btMa_Kv_Tag = new Epoint.Systems.Controls.btControl();
            this.lblControl8 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.txtTag_List = new Epoint.Systems.Controls.txtTextBox();
            this.txtMa_Bp_List = new Epoint.Systems.Controls.txtTextBox();
            this.txtMa_Kv_List = new Epoint.Systems.Controls.txtTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spCMain = new System.Windows.Forms.SplitContainer();
            this.rptChartResoure = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.chartHd = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMa_KV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.ChartNVNew_Break = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCMain)).BeginInit();
            this.spCMain.Panel1.SuspendLayout();
            this.spCMain.Panel2.SuspendLayout();
            this.spCMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMa_KV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartNVNew_Break)).BeginInit();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(446, 389);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(76, 29);
            this.btOk.TabIndex = 4;
            this.btOk.Tag = "ACCEPT";
            this.btOk.Text = "&Đồng ý";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(528, 389);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 29);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dteTodate);
            this.panel1.Controls.Add(this.dteFromDate);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.btTag_List);
            this.panel1.Controls.Add(this.btMa_Bp_Tag);
            this.panel1.Controls.Add(this.btLoadData);
            this.panel1.Controls.Add(this.btMa_Kv_Tag);
            this.panel1.Controls.Add(this.lblControl8);
            this.panel1.Controls.Add(this.lblControl7);
            this.panel1.Controls.Add(this.lblControl2);
            this.panel1.Controls.Add(this.lblControl1);
            this.panel1.Controls.Add(this.lblControl6);
            this.panel1.Controls.Add(this.txtTag_List);
            this.panel1.Controls.Add(this.txtMa_Bp_List);
            this.panel1.Controls.Add(this.txtMa_Kv_List);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1214, 78);
            this.panel1.TabIndex = 8;
            // 
            // dteTodate
            // 
            this.dteTodate.bAllowEmpty = true;
            this.dteTodate.bRequire = false;
            this.dteTodate.bSelectOnFocus = false;
            this.dteTodate.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteTodate.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteTodate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteTodate.Location = new System.Drawing.Point(773, 12);
            this.dteTodate.Mask = "00/00/0000";
            this.dteTodate.Name = "dteTodate";
            this.dteTodate.SelectedText = "";
            this.dteTodate.Size = new System.Drawing.Size(104, 19);
            this.dteTodate.TabIndex = 27;
            // 
            // dteFromDate
            // 
            this.dteFromDate.bAllowEmpty = true;
            this.dteFromDate.bRequire = false;
            this.dteFromDate.bSelectOnFocus = false;
            this.dteFromDate.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteFromDate.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteFromDate.Location = new System.Drawing.Point(574, 12);
            this.dteFromDate.Mask = "00/00/0000";
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.SelectedText = "";
            this.dteFromDate.Size = new System.Drawing.Size(104, 19);
            this.dteFromDate.TabIndex = 27;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.Blue;
            this.lblSize.Location = new System.Drawing.Point(99, 9);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 13);
            this.lblSize.TabIndex = 17;
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btTag_List
            // 
            this.btTag_List.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTag_List.Location = new System.Drawing.Point(449, 52);
            this.btTag_List.Name = "btTag_List";
            this.btTag_List.Size = new System.Drawing.Size(33, 20);
            this.btTag_List.TabIndex = 21;
            this.btTag_List.Tag = "";
            this.btTag_List.Text = "...";
            this.btTag_List.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTag_List.UseVisualStyleBackColor = true;
            // 
            // btMa_Bp_Tag
            // 
            this.btMa_Bp_Tag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMa_Bp_Tag.Location = new System.Drawing.Point(449, 29);
            this.btMa_Bp_Tag.Name = "btMa_Bp_Tag";
            this.btMa_Bp_Tag.Size = new System.Drawing.Size(33, 20);
            this.btMa_Bp_Tag.TabIndex = 22;
            this.btMa_Bp_Tag.Tag = "";
            this.btMa_Bp_Tag.Text = "...";
            this.btMa_Bp_Tag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMa_Bp_Tag.UseVisualStyleBackColor = true;
            // 
            // btLoadData
            // 
            this.btLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadData.Image = global::Epoint.Modules.HRM.Properties.Resources.tick;
            this.btLoadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLoadData.Location = new System.Drawing.Point(1068, 7);
            this.btLoadData.Name = "btLoadData";
            this.btLoadData.Size = new System.Drawing.Size(134, 62);
            this.btLoadData.TabIndex = 23;
            this.btLoadData.Tag = "";
            this.btLoadData.Text = "Xem báo cáo ";
            this.btLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLoadData.UseVisualStyleBackColor = true;
            // 
            // btMa_Kv_Tag
            // 
            this.btMa_Kv_Tag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMa_Kv_Tag.Location = new System.Drawing.Point(449, 6);
            this.btMa_Kv_Tag.Name = "btMa_Kv_Tag";
            this.btMa_Kv_Tag.Size = new System.Drawing.Size(33, 20);
            this.btMa_Kv_Tag.TabIndex = 23;
            this.btMa_Kv_Tag.Tag = "";
            this.btMa_Kv_Tag.Text = "...";
            this.btMa_Kv_Tag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMa_Kv_Tag.UseVisualStyleBackColor = true;
            // 
            // lblControl8
            // 
            this.lblControl8.AutoEllipsis = true;
            this.lblControl8.AutoSize = true;
            this.lblControl8.BackColor = System.Drawing.Color.Transparent;
            this.lblControl8.Location = new System.Drawing.Point(12, 56);
            this.lblControl8.Name = "lblControl8";
            this.lblControl8.Size = new System.Drawing.Size(29, 13);
            this.lblControl8.TabIndex = 24;
            this.lblControl8.Tag = "";
            this.lblControl8.Text = "Vị trí";
            this.lblControl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Location = new System.Drawing.Point(12, 32);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(59, 13);
            this.lblControl7.TabIndex = 25;
            this.lblControl7.Tag = "";
            this.lblControl7.Text = "Phòng ban";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(12, 9);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(47, 13);
            this.lblControl6.TabIndex = 26;
            this.lblControl6.Tag = "";
            this.lblControl6.Text = "Khu vực";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTag_List
            // 
            this.txtTag_List.bEnabled = true;
            this.txtTag_List.bIsLookup = false;
            this.txtTag_List.bReadOnly = false;
            this.txtTag_List.bRequire = false;
            this.txtTag_List.KeyFilter = "";
            this.txtTag_List.Location = new System.Drawing.Point(99, 51);
            this.txtTag_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTag_List.Name = "txtTag_List";
            this.txtTag_List.Size = new System.Drawing.Size(345, 20);
            this.txtTag_List.TabIndex = 20;
            this.txtTag_List.Text = "*";
            this.txtTag_List.UseAutoFilter = false;
            // 
            // txtMa_Bp_List
            // 
            this.txtMa_Bp_List.bEnabled = true;
            this.txtMa_Bp_List.bIsLookup = false;
            this.txtMa_Bp_List.bReadOnly = false;
            this.txtMa_Bp_List.bRequire = false;
            this.txtMa_Bp_List.KeyFilter = "";
            this.txtMa_Bp_List.Location = new System.Drawing.Point(99, 29);
            this.txtMa_Bp_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp_List.Name = "txtMa_Bp_List";
            this.txtMa_Bp_List.Size = new System.Drawing.Size(345, 20);
            this.txtMa_Bp_List.TabIndex = 19;
            this.txtMa_Bp_List.Text = "*";
            this.txtMa_Bp_List.UseAutoFilter = false;
            // 
            // txtMa_Kv_List
            // 
            this.txtMa_Kv_List.bEnabled = true;
            this.txtMa_Kv_List.bIsLookup = false;
            this.txtMa_Kv_List.bReadOnly = false;
            this.txtMa_Kv_List.bRequire = false;
            this.txtMa_Kv_List.KeyFilter = "";
            this.txtMa_Kv_List.Location = new System.Drawing.Point(99, 6);
            this.txtMa_Kv_List.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kv_List.Name = "txtMa_Kv_List";
            this.txtMa_Kv_List.Size = new System.Drawing.Size(345, 20);
            this.txtMa_Kv_List.TabIndex = 18;
            this.txtMa_Kv_List.Text = "*";
            this.txtMa_Kv_List.UseAutoFilter = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.spCMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1214, 694);
            this.panel2.TabIndex = 27;
            // 
            // spCMain
            // 
            this.spCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spCMain.Location = new System.Drawing.Point(0, 0);
            this.spCMain.Name = "spCMain";
            // 
            // spCMain.Panel1
            // 
            this.spCMain.Panel1.Controls.Add(this.rptChartResoure);
            this.spCMain.Panel1.Controls.Add(this.ChartNVNew_Break);
            // 
            // spCMain.Panel2
            // 
            this.spCMain.Panel2.Controls.Add(this.chartHd);
            this.spCMain.Panel2.Controls.Add(this.chartMa_KV);
            this.spCMain.Size = new System.Drawing.Size(1214, 694);
            this.spCMain.SplitterDistance = 609;
            this.spCMain.TabIndex = 3;
            // 
            // rptChartResoure
            // 
            this.rptChartResoure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rptChartResoure.BackColor = System.Drawing.SystemColors.Control;
            this.rptChartResoure.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.rptChartResoure.Location = new System.Drawing.Point(353, 488);
            this.rptChartResoure.Name = "rptChartResoure";
            this.rptChartResoure.ReportViewer.CurrentPage = 0;
            this.rptChartResoure.ReportViewer.MultiplePageCols = 3;
            this.rptChartResoure.ReportViewer.MultiplePageMode = true;
            this.rptChartResoure.ReportViewer.MultiplePageRows = 2;
            this.rptChartResoure.ReportViewer.RepositionPage = true;
            this.rptChartResoure.ReportViewer.RulerVisible = false;
            this.rptChartResoure.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.ContinuousScroll;
            this.rptChartResoure.Size = new System.Drawing.Size(256, 206);
            this.rptChartResoure.TabIndex = 10;
            this.rptChartResoure.TableOfContents.Text = "Table Of Contents";
            this.rptChartResoure.TableOfContents.Width = 200;
            this.rptChartResoure.TabTitleLength = 35;
            this.rptChartResoure.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rptChartResoure.Toolbar.Visible = false;
            this.rptChartResoure.Visible = false;
            // 
            // chartHd
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHd.ChartAreas.Add(chartArea2);
            this.chartHd.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartHd.Legends.Add(legend2);
            this.chartHd.Location = new System.Drawing.Point(0, 0);
            this.chartHd.Name = "chartHd";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.IsValueShownAsLabel = true;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartHd.Series.Add(series3);
            this.chartHd.Size = new System.Drawing.Size(601, 694);
            this.chartHd.TabIndex = 3;
            this.chartHd.Text = "chart4";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Blue;
            title1.Name = "Title1";
            title1.Text = "Phân loại hợp đồng";
            this.chartHd.Titles.Add(title1);
            // 
            // chartMa_KV
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMa_KV.ChartAreas.Add(chartArea3);
            this.chartMa_KV.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartMa_KV.Legends.Add(legend3);
            this.chartMa_KV.Location = new System.Drawing.Point(0, 0);
            this.chartMa_KV.Name = "chartMa_KV";
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.MarkerSize = 3;
            series4.Name = "Series1";
            series5.BorderWidth = 0;
            series5.ChartArea = "ChartArea1";
            series5.IsValueShownAsLabel = true;
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.MarkerBorderWidth = 0;
            series5.MarkerSize = 3;
            series5.Name = "Series2";
            this.chartMa_KV.Series.Add(series4);
            this.chartMa_KV.Series.Add(series5);
            this.chartMa_KV.Size = new System.Drawing.Size(601, 694);
            this.chartMa_KV.TabIndex = 2;
            this.chartMa_KV.Text = "chart3";
            this.chartMa_KV.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            this.chartMa_KV.Visible = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(502, 18);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(46, 13);
            this.lblControl1.TabIndex = 26;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Từ ngày";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(703, 18);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(53, 13);
            this.lblControl2.TabIndex = 26;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Đến ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChartNVNew_Break
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartNVNew_Break.ChartAreas.Add(chartArea1);
            this.ChartNVNew_Break.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.ChartNVNew_Break.Legends.Add(legend1);
            this.ChartNVNew_Break.Location = new System.Drawing.Point(0, 0);
            this.ChartNVNew_Break.Name = "ChartNVNew_Break";
            this.ChartNVNew_Break.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Color = System.Drawing.Color.Brown;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelAngle = 6;
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Empty;
            series1.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series1.SmartLabelStyle.MovingDirection = System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Color = System.Drawing.Color.LimeGreen;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.ChartNVNew_Break.Series.Add(series1);
            this.ChartNVNew_Break.Series.Add(series2);
            this.ChartNVNew_Break.Size = new System.Drawing.Size(609, 694);
            this.ChartNVNew_Break.TabIndex = 11;
            this.ChartNVNew_Break.Text = "chart3";
            this.ChartNVNew_Break.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // frmResourceAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(1214, 772);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmResourceAnalysis";
            this.Text = "frmHumanChart";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.spCMain.Panel1.ResumeLayout(false);
            this.spCMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spCMain)).EndInit();
            this.spCMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMa_KV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartNVNew_Break)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Panel panel1;
        private Systems.Controls.lbtControl lblSize;
        private Systems.Controls.btControl btTag_List;
        private Systems.Controls.btControl btMa_Bp_Tag;
        private Systems.Controls.btControl btLoadData;
        private Systems.Controls.btControl btMa_Kv_Tag;
        private Systems.Controls.lblControl lblControl8;
        private Systems.Controls.lblControl lblControl7;
        private Systems.Controls.lblControl lblControl6;
        private Systems.Controls.txtTextBox txtTag_List;
        private Systems.Controls.txtTextBox txtMa_Bp_List;
        private Systems.Controls.txtTextBox txtMa_Kv_List;
        private Panel panel2;
        private Systems.Controls.dteDateTime dteTodate;
        private Systems.Controls.dteDateTime dteFromDate;
        private SplitContainer spCMain;
        private DataDynamics.ActiveReports.Viewer.Viewer rptChartResoure;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMa_KV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHd;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lblControl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartNVNew_Break;
    }
}