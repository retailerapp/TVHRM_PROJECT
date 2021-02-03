using System.Windows.Forms;
using System.Drawing;
using DataDynamics.ActiveReports.Viewer;
using Epoint.Systems.Controls;
using System.ComponentModel;
namespace Epoint.Systems.Customizes
{
    partial class ucWTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucModuleLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "ucModuleLabel";
            this.Size = new System.Drawing.Size(345, 72);
            this.ResumeLayout(false);


            ComponentResourceManager manager = new ComponentResourceManager(typeof(ucWTable));
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            this.splitContainerMain = new SplitContainer();
            this.splitContainer1 = new SplitContainer();
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.panel5 = new Panel();
            this.label5 = new Label();
            this.splitContainer2 = new SplitContainer();
            this.panel2 = new Panel();
            this.label2 = new Label();
            this.dgvCongNo = new dgvControl();
            this.panel3 = new Panel();
            this.label3 = new Label();
            this.dgvTaiKhoan = new dgvControl();
            this.viewDoanhThuChiPhi = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.viewDoanhThu = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize)this.dgvCongNo).BeginInit();
            this.panel3.SuspendLayout();
            ((ISupportInitialize)this.dgvTaiKhoan).BeginInit();
            base.SuspendLayout();
            this.splitContainerMain.Dock = DockStyle.Fill;
            this.splitContainerMain.Location = new Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = Orientation.Horizontal;
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainerMain.Size = new Size(800, 0x235);
            this.splitContainerMain.SplitterDistance = 300;
            this.splitContainerMain.TabIndex = 0;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.viewDoanhThuChiPhi);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.viewDoanhThu);
            this.splitContainer1.Size = new Size(800, 300);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.TabIndex = 2;
            this.panel1.BackColor = SystemColors.GradientActiveCaption;
            this.panel1.BackgroundImage = (Image)manager.GetObject("panel1.BackgroundImage");
            this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(450, 20);
            this.panel1.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "DOANH_THU_CHI_PHI";
            this.label1.Text = "Doanh thu - Chi ph\x00ed";
            //this.viewDoanhThuChiPhi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.viewDoanhThuChiPhi.BackColor = SystemColors.GradientActiveCaption;
            this.viewDoanhThuChiPhi.BackgroundImageLayout = ImageLayout.Center;
            this.viewDoanhThuChiPhi.Dock = DockStyle.Fill;
            this.viewDoanhThuChiPhi.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.viewDoanhThuChiPhi.Location = new Point(0, 0);
            this.viewDoanhThuChiPhi.Name = "viewDoanhThuChiPhi";
            this.viewDoanhThuChiPhi.ReportViewer.BackColor = SystemColors.GradientActiveCaption;
            this.viewDoanhThuChiPhi.ReportViewer.CurrentPage = 0;
            this.viewDoanhThuChiPhi.ReportViewer.DisplayUnits = DisplayUnits.Metric;
            this.viewDoanhThuChiPhi.ReportViewer.MultiplePageCols = 3;
            this.viewDoanhThuChiPhi.ReportViewer.MultiplePageRows = 2;
            this.viewDoanhThuChiPhi.ReportViewer.RulerVisible = false;
            this.viewDoanhThuChiPhi.ReportViewer.ViewType = ViewType.Normal;
            this.viewDoanhThuChiPhi.ReportViewer.Zoom = 0.99f;
            this.viewDoanhThuChiPhi.Size = new Size(450, 300);
            this.viewDoanhThuChiPhi.TabIndex = 3;
            this.viewDoanhThuChiPhi.TableOfContents.Text = "Table Of Contents";
            this.viewDoanhThuChiPhi.TableOfContents.Width = 200;
            this.viewDoanhThuChiPhi.TabTitleLength = 0x23;
            this.viewDoanhThuChiPhi.Toolbar.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.viewDoanhThuChiPhi.Toolbar.Visible = false;
            this.panel5.BackColor = SystemColors.GradientActiveCaption;
            this.panel5.BackgroundImage = (Image)manager.GetObject("panel5.BackgroundImage");
            this.panel5.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x15a, 20);
            this.panel5.TabIndex = 2;
            this.label5.AutoSize = true;
            this.label5.BackColor = Color.Transparent;
            this.label5.Location = new Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 13);
            this.label5.TabIndex = 0;
            this.label5.Tag = "DOANH_SO_MAT_HANG";
            this.label5.Text = "Doanh số mặt h\x00e0ng";
            //this.viewDoanhThu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.viewDoanhThu.BackColor = SystemColors.Control;
            this.viewDoanhThu.BackgroundImageLayout = ImageLayout.Center;
            this.viewDoanhThu.Dock = DockStyle.Fill;
            this.viewDoanhThu.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.viewDoanhThu.Location = new Point(0, 0);
            this.viewDoanhThu.Name = "viewDoanhThu";
            this.viewDoanhThu.ReportViewer.BackColor = SystemColors.GradientActiveCaption;
            this.viewDoanhThu.ReportViewer.CurrentPage = 0;
            this.viewDoanhThu.ReportViewer.DisplayUnits = DisplayUnits.Metric;
            this.viewDoanhThu.ReportViewer.MultiplePageCols = 3;
            this.viewDoanhThu.ReportViewer.MultiplePageRows = 2;
            this.viewDoanhThu.ReportViewer.RulerVisible = false;
            this.viewDoanhThu.ReportViewer.ViewType = ViewType.Normal;
            this.viewDoanhThu.ReportViewer.Zoom = 0.99f;
            this.viewDoanhThu.Size = new Size(0x15a, 300);
            this.viewDoanhThu.TabIndex = 4;
            this.viewDoanhThu.TableOfContents.Text = "Table Of Contents";
            this.viewDoanhThu.TableOfContents.Width = 200;
            this.viewDoanhThu.TabTitleLength = 0x23;
            this.viewDoanhThu.Toolbar.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.viewDoanhThu.Toolbar.Visible = false;
            this.splitContainer2.Dock = DockStyle.Fill;
            this.splitContainer2.Location = new Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.dgvCongNo);
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Panel2.Controls.Add(this.dgvTaiKhoan);
            this.splitContainer2.Size = new Size(800, 0x105);
            this.splitContainer2.SplitterDistance = 450;
            this.splitContainer2.TabIndex = 0;
            this.panel2.BackColor = SystemColors.GradientActiveCaption;
            this.panel2.BackgroundImage = (Image)manager.GetObject("panel2.BackgroundImage");
            this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(450, 20);
            this.panel2.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "Cong_No_Den_Han";
            this.label2.Text = "C\x00f4ng nợ đến hạn";
            this.dgvCongNo.AllowUserToAddRows = false;
            this.dgvCongNo.AllowUserToDeleteRows = false;
            style.BackColor = Color.FromArgb(0xf5, 0xf9, 0xff);
            this.dgvCongNo.AlternatingRowsDefaultCellStyle = style;
            this.dgvCongNo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            //this.dgvCongNo.AutoFixsize = false;
            this.dgvCongNo.BackgroundColor = Color.White;
            //this.dgvCongNo.BorderStyle = BorderStyle.Fixed3D;
            this.dgvCongNo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //style2.BackColor = Color.FromArgb(220, 0xeb, 0xff);
            //style2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            //style2.ForeColor = SystemColors.WindowText;
            //style2.SelectionBackColor = SystemColors.Highlight;
            //style2.SelectionForeColor = SystemColors.HighlightText;
            //style2.WrapMode = DataGridViewTriState.True;
            //this.dgvCongNo.ColumnHeadersDefaultCellStyle = style2;
            this.dgvCongNo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongNo.EnableHeadersVisualStyles = false;
            this.dgvCongNo.GridColor = Color.FromArgb(0xa5, 0xbf, 0xe1);
            this.dgvCongNo.Location = new Point(0, 0x15);
            this.dgvCongNo.MultiSelect = false;
            this.dgvCongNo.Name = "dgvCongNo";
            this.dgvCongNo.ReadOnly = true;
            this.dgvCongNo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //style3.BackColor = Color.FromArgb(220, 0xeb, 0xff);
            //style3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            //style3.ForeColor = SystemColors.WindowText;
            //style3.SelectionBackColor = SystemColors.Highlight;
            //style3.SelectionForeColor = SystemColors.HighlightText;
            //style3.WrapMode = DataGridViewTriState.True;
            //this.dgvCongNo.RowHeadersDefaultCellStyle = style3;
            this.dgvCongNo.RowTemplate.Height = 20;
            this.dgvCongNo.Size = new Size(450, 240);
            this.dgvCongNo.strZone = "";
            this.dgvCongNo.TabIndex = 3;
            this.panel3.BackColor = SystemColors.GradientActiveCaption;
            this.panel3.BackgroundImage = (Image)manager.GetObject("panel3.BackgroundImage");
            this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x15a, 20);
            this.panel3.TabIndex = 4;
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "Bao_Cao_Nhanh";
            this.label3.Text = "B\x00e1o c\x00e1o nhanh";
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            style4.BackColor = Color.FromArgb(0xf5, 0xf9, 0xff);
            this.dgvTaiKhoan.AlternatingRowsDefaultCellStyle = style4;
            this.dgvTaiKhoan.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            //this.dgvTaiKhoan.AutoFixsize = false;
            this.dgvTaiKhoan.BackgroundColor = Color.White;
            //this.dgvTaiKhoan.BorderStyle = BorderStyle.Fixed3D;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //style5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //style5.BackColor = Color.FromArgb(220, 0xeb, 0xff);
            //style5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            //style5.ForeColor = SystemColors.WindowText;
            //style5.SelectionBackColor = SystemColors.Highlight;
            //style5.SelectionForeColor = SystemColors.HighlightText;
            //style5.WrapMode = DataGridViewTriState.True;
            //this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = style5;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.GridColor = Color.FromArgb(0xa5, 0xbf, 0xe1);
            this.dgvTaiKhoan.Location = new Point(4, 0x15);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //style6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //style6.BackColor = Color.FromArgb(220, 0xeb, 0xff);
            //style6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            //style6.ForeColor = SystemColors.WindowText;
            //style6.SelectionBackColor = SystemColors.Highlight;
            //style6.SelectionForeColor = SystemColors.HighlightText;
            //style6.WrapMode = DataGridViewTriState.True;
            //this.dgvTaiKhoan.RowHeadersDefaultCellStyle = style6;
            this.dgvTaiKhoan.RowTemplate.Height = 20;
            this.dgvTaiKhoan.Size = new Size(0x153, 0xed);
            this.dgvTaiKhoan.strZone = "";
            this.dgvTaiKhoan.TabIndex = 5;
            //this.dgvTaiKhoan.UseFilter = false;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            //this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "ucDesktop";
            this.Size = new Size(800, 0x235);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize)this.dgvCongNo).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((ISupportInitialize)this.dgvTaiKhoan).EndInit();
            base.ResumeLayout(false);
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainerMain;

        #endregion

    }
}
