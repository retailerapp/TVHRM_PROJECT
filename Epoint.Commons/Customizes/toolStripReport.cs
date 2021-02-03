using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Resources;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
	public class toolStripReport : Epoint.Systems.Controls.tsControl
	{
		public tsbPreview tsbPreview = new tsbPreview();
        public tsbPrint tsbPrint = new tsbPrint();
        public tsbDesign tsbDesign = new tsbDesign();
        public tsbChart tsbChart = new tsbChart();
        public tsbEditVoucher tsbEditVoucher = new tsbEditVoucher();
        public tsbRefesh tsbRefeshReport = new tsbRefesh();

		public toolStripReport()
		{
			this.Items.Add(tsbPreview);
			this.Items.Add(tsbPrint);
            this.Items.Add(tsbDesign);
            this.Items.Add(tsbChart);
			this.Items.Add(tsbEditVoucher);
            this.Items.Add(tsbRefeshReport);
		}	
	}

    public class tsbPreview : tsbControl
	{
		public tsbPreview()
		{
            Bitmap Bmp = new Bitmap(Resources.Resource.Preview, this.Size);

            this.Image = Bmp;
			this.ToolTipText = Languages.GetLanguage("Preview");
            this.Text = Languages.GetLanguage("Preview");
			this.Click += new EventHandler(tsbPreview_Click);
		}

		void tsbPreview_Click(object sender, EventArgs e)
		{
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
             {    //Kết xuất dữ liệu trên báo cáo
                 if (frm.GetType().Name == "frmReportResult")
                 {
                     frm.GetType().InvokeMember("PreviewReport", System.Reflection.BindingFlags.InvokeMethod, null, frm, null);
                 }
             }
		}
	}

    public class tsbPrint : tsbControl
	{
		public tsbPrint()
		{
            Bitmap Bmp = new Bitmap(Resources.Resource.Print48x48, this.Size);

            this.Image = Bmp;
			this.ToolTipText = Languages.GetLanguage("Print");
            this.Text = Languages.GetLanguage("Print");
			this.Click += new EventHandler(tsbPrint_Click);
		}

		void tsbPrint_Click(object sender, EventArgs e)
		{
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
            {    //Kết xuất dữ liệu trên báo cáo
                if (frm.GetType().Name == "frmReportResult")
                {
                    frm.GetType().InvokeMember("PrintReport", System.Reflection.BindingFlags.InvokeMethod, null, frm, null);
                }
            }
            else
            {
                frm = Common.FindFormChildInTab();
                if (frm == null)
                    return;
                try
                {
                    ((frmView)frm).PrintVoucherDoc();
                }
                catch { }
            }
		}
	}

    public class tsbDesign : tsbControl
	{
		public tsbDesign()
		{
            Bitmap Bmp = new Bitmap(Resources.Resource.Design, this.Size);

            this.Image = Bmp;
			this.ToolTipText = Languages.GetLanguage("Design");
            this.Text = Languages.GetLanguage("Design");
			this.Click += new EventHandler(tsbDesign_Click);
		}

		void tsbDesign_Click(object sender, EventArgs e)
		{
            
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
            {    //Kết xuất dữ liệu trên báo cáo
                if (frm.GetType().Name == "frmReportResult")
                {
                    frm.GetType().InvokeMember("DesignReport", System.Reflection.BindingFlags.InvokeMethod, null, frm, null);
                }
            }
            else
            {
                frm = Common.FindFormChildInTab();
                if (frm == null)
                    return;
                try
                {
                    ((frmView)frm).DesignReport();
                }
                catch { }
            }
		}
	}

    public class tsbEditVoucher : tsbControl
	{
		public tsbEditVoucher()
		{
            Bitmap Bmp = new Bitmap(Resources.Resource.Edit_Voucher_Report, this.Size);

            this.Image = Bmp;
			this.ToolTipText = Languages.GetLanguage("EditVoucher");
            this.Text = Languages.GetLanguage("EditVoucher");
			this.Click += new EventHandler(tsbEditVoucher_Click);
		}

		void tsbEditVoucher_Click(object sender, EventArgs e)
		{
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
            {    //Kết xuất dữ liệu trên báo cáo
                if (frm.GetType().Name == "frmReportResult")
                {
                    frm.GetType().InvokeMember("Edit", System.Reflection.BindingFlags.InvokeMethod, null, frm, null);
                }
            }
		}
	}

    public class tsbChart : tsbControl
	{
		public tsbChart()
		{
			this.Image = new Bitmap(Epoint.Systems.Commons.Properties.Resources.Chart, this.Size);
			this.ToolTipText = Languages.GetLanguage("Chart");
            this.Text = Languages.GetLanguage("Chart");
			this.Click += new EventHandler(tsbChart_Click);
		}

		void tsbChart_Click(object sender, EventArgs e)
		{
            
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
            {    //Kết xuất dữ liệu trên báo cáo
                if (frm.GetType().Name == "frmReportResult")
                {
                    frm.GetType().InvokeMember("RunChart", System.Reflection.BindingFlags.InvokeMethod, null, frm, null);
                }
            }
		}
	}

    public class tsbRefesh : tsbControl
    {
        public tsbRefesh()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.refresh, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Refresh");
            this.Text = Languages.GetLanguage("Refresh");
            this.Click += new EventHandler(tsbRefesh_Click);
        }

        void tsbRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Common.FindFormReportResultInTab();
                if (frm == null)
                    return;
                if (frm.GetType().Name == "frmReportResult")
                {
                    ((frmBase)frm).RefeshReportView();
                }
               
            }
            catch { }
        }
    }

}
