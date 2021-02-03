using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Lists;
using BarcodeLib;

namespace Epoint.Controllers
{
    public partial class frmBarcode_Edit : Epoint.Systems.Customizes.frmEdit
    {
        #region Methods
        private string strBarcode;
        private PrintDialog _Print1;
        private PrintDialog _Print2;
        private PrintDialog _Print3;
        private PrintDialog _Print128;
        private PrintDocument _PrintDocument1;
        private PrintDocument _PrintDocument2;
        private PrintDocument _PrintDocument3;
        private PrintDocument _PrintDocument128;
        private PrintPreviewDialog printPreviewDialog1;
        private Color color = Color.Black;
        BarcodeLib.Barcode barcodeLib = new BarcodeLib.Barcode();


        public frmBarcode_Edit()
        {
            InitializeComponent();

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            btnViewBarcode.Click += new EventHandler(btnViewBarcode_Click);

            btnViewBarcode128.Click += new EventHandler(btnPrintBarcodeView128_Click);
            btnPreviewBarcode128.Click += new EventHandler(btnPreview_Click);
            btnViewBarcode128.Click += new EventHandler(btnPrintBarcodeView128_Click);
            btnPrintBarcode128.Click += new EventHandler(btnPrintBarcode128_Click);
            btClose.Click += new EventHandler(btClose_Click);

            btSave.Click += new EventHandler(btSave_Click);

            //Khởi tạo đối tương printer
            this.Print1 = new PrintDialog();
            this.Print2 = new PrintDialog();
            this.Print3 = new PrintDialog();
            this.PrintDocument1 = new PrintDocument();
            this.PrintDocument2 = new PrintDocument();
            this.PrintDocument3 = new PrintDocument();



            this.Print1.AllowCurrentPage = true;
            this.Print1.AllowPrintToFile = false;
            this.Print1.AllowSelection = true;
            this.Print1.AllowSomePages = true;
            this.Print1.Document = this.PrintDocument1;
            this.Print1.UseEXDialog = true;

            this.Print2.AllowCurrentPage = true;
            this.Print2.AllowPrintToFile = false;
            this.Print2.AllowSelection = true;
            this.Print2.AllowSomePages = true;
            this.Print2.Document = this.PrintDocument2;
            this.Print2.UseEXDialog = true;

            this.Print3.AllowCurrentPage = true;
            this.Print3.AllowPrintToFile = false;
            this.Print3.AllowSelection = true;
            this.Print3.AllowSomePages = true;
            this.Print3.Document = this.PrintDocument3;
            this.Print3.UseEXDialog = true;



            this.Print128 = new PrintDialog();
            this.PrintDocument128 = new PrintDocument();

            this.Print128.AllowCurrentPage = true;
            this.Print128.AllowPrintToFile = false;
            this.Print128.AllowSelection = true;
            this.Print128.AllowSomePages = true;
            this.Print128.Document = this.PrintDocument128;
            this.Print128.UseEXDialog = true;

            this.printPreviewDialog1 = new PrintPreviewDialog();
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(600, 800);
            this.printPreviewDialog1.Document = this.PrintDocument128;

        }





        new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

        private void LoadDicName()
        {

        }

        private bool CheckFormValid()
        {
            return true;
        }

        private bool Save()
        {

            return true;
        }

        private void CreateAutoBarcode()
        {

            try
            {
                string strNewBarcode = string.Empty;
                long sOMAVACH = Convert.ToInt32(Parameters.GetParaValue("CURRENTBARCODE"));
                string s = Parameters.GetParaValue("CONFIGBARCODE") + Convert.ToString(sOMAVACH);
                string mAVACH = "";
                bool iCheckBarcode = true;
                strBarcode = drEdit["Barcode"].ToString();
                while (iCheckBarcode)
                {
                    if (true)
                    {
                        mAVACH = "";

                        //"8936" 
                        byte num3 = (byte)(12 - s.Length);

                        for (byte i = 1; i <= num3; i = (byte)(i + 1))
                        {
                            s = s.Insert(4, "0");
                        }

                        this.DrawEan13AutoNew(s, ref mAVACH);
                    }

                    if (!DataTool.SQLCheckExist("LIVATTU", "Ma_Vt", mAVACH))
                    {

                        iCheckBarcode = false;
                    }
                    else
                    {
                        sOMAVACH++;
                        iCheckBarcode = true;
                    }
                }

                strNewBarcode = mAVACH;
                if (true) // Nếu cho phép cập nhật
                {
                    //SQLExec.Execute("UPDATE LIVATTU SET Barcode = '" + strBarcode + "' WHERE Ma_Vt = '" + txtMa_Vt + "'");
                    Parameters.SetParaValue("CURRENTBARCODE", sOMAVACH + 1);
                }
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }



        #endregion

        #region Events


        void btnViewBarcode_Click(object sender, EventArgs e)
        {
            CreateBarcode();
        }


        void btnPrint_Click(object sender, EventArgs e)
        {
            switch (this.txtMa_Vt.Text[0])
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':

                    if (this.Print1.ShowDialog() == DialogResult.OK)
                    {
                        this.PrintDocument1.Print();
                    }
                    return;
            }
        }
        
        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Save_FileBarcode()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */  savetype = BarcodeLib.SaveTypes.BMP; break;
                    case 2: /* GIF */  savetype = BarcodeLib.SaveTypes.GIF; break;
                    case 3: /* JPG */  savetype = BarcodeLib.SaveTypes.JPG; break;
                    case 4: /* PNG */  savetype = BarcodeLib.SaveTypes.PNG; break;
                    case 5: /* TIFF */ savetype = BarcodeLib.SaveTypes.TIFF; break;
                    default: break;
                }//switch
                barcodeLib.SaveImage(sfd.FileName, savetype);
            }
        }
        void Auto_Save_FileBarcode()
        {            
            string fileName = string.Empty;
            fileName = Application.StartupPath + @"\Images\Barcode\" + txtMa_Vt.Text.Trim() + ".png";//Path co dinh
            
            barcodeLib.SaveImage(fileName, BarcodeLib.SaveTypes.PNG);            
            
        }        
        #endregion

        #region PrintDocument 128
        private void CreateBarcode128()
        {
            string strBarcode = txtMa_Vt.Text.Trim();
            //string strTen1 = txtTen_Vt2.Text.Trim();
            //string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);

            string strTen1 = "";
            string strTen2 = "";

            int W = picBarCode.Width;//Convert.ToInt32(this.txtWidth.Text.Trim());
            int H = picBarCode.Height;// Convert.ToInt32(this.txtHeight.Text.Trim());
            //Barcode alignment
            barcodeLib.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
            
            //Hien thi so ma vach
            //barcodeLib.IncludeLabel = true;
            barcodeLib.IncludeLabel = false; //--> khong can hien thi label ma code

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {

                    barcodeLib.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);

                    //label alignment and position
                    barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    //switch (this.cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
                    //{
                    //    case "BOTTOMLEFT": barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT; break;
                    //    case "BOTTOMRIGHT": barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT; break;
                    //    case "TOPCENTER": barcodeLib.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER; break;
                    //    case "TOPLEFT": barcodeLib.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT; break;
                    //    case "TOPRIGHT": barcodeLib.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT; break;
                    //    default: barcodeLib.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER; break;
                    //}//switch

                    //===== Encoding performed here =====
                    picBarCode.Image = barcodeLib.Encode(type, strBarcode, strTen1, strTen2, this.color, Color.White, W, H);                    
                    //===================================

                    //txtEncoded.Text = barcodeLib.EncodedValue;

                    //tsslEncodedType.Text = "Encoding Type: " + barcodeLib.EncodedType.ToString();
                }//if

                picBarCode.Width = picBarCode.Image.Width;
                picBarCode.Height = picBarCode.Image.Height;

                //Tu dong luu Barcode
                Auto_Save_FileBarcode();

            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch

        }
        internal virtual PrintDialog Print128
        {
            get
            {
                return this._Print128;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Print128 = value;
            }
        }
        private void PrintDocument128_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {
                Image img = picBarCode.Image;

                using (Graphics g = e.Graphics)
                {
                    int w = picBarCode.Width;
                    int h = picBarCode.Height;
                    int num = 14;
                    int num2 = 20;
                    int numLine = 0;
                    int x = 0, y = 0;
                    //num2 = 20;
                    //num = 15;
                    for (int i = 0; i < 11; i++)
                    {
                        
                        for (int j = 0; j < 6; j++)
                        {
                            //x = j * w;
                            //y = i * h;
                            //g.DrawImage(picBarCode.Image, x + num2 * (j+1) , y + num*(i+1));
                            //numLine = y + (num * i) - num/2;
                            
                            x = j * w + num2 * (j + 1);
                            y = i * h + num * (i + 1);
                            g.DrawImage(picBarCode.Image, x , y );
                            numLine = y  - num / 2;
                            //num2++;
                        }


                        g.DrawLine(Pens.LightGray, (float)0f, (float)(numLine), (float)800f, (float)(numLine));
                        //num++;

                    }
                    g.Dispose();
                }
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
        internal virtual PrintDocument PrintDocument128
        {
            get
            {
                return this._PrintDocument128;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PrintPageEventHandler handler = new PrintPageEventHandler(this.PrintDocument128_PrintPage);
                if (this._PrintDocument128 != null)
                {
                    this._PrintDocument128.PrintPage -= handler;
                }
                this._PrintDocument128 = value;
                if (this._PrintDocument128 != null)
                {
                    this._PrintDocument128.PrintPage += handler;
                }
            }
        }

        void btnPrintBarcodeView128_Click(object sender, EventArgs e)
        {
            CreateBarcode128();
        }
        void btnPreview_Click(object sender, EventArgs e)
        {
            CreateBarcode128();
            this.printPreviewDialog1.ShowDialog();
        }
        void btnPrintBarcode128_Click(object sender, EventArgs e)
        {
            CreateBarcode128();
            if (this.Print128.ShowDialog() == DialogResult.OK)
            {
                this.PrintDocument128.Print();
            }
            return;
        }
        void btSave_Click(object sender, EventArgs e)
        {
            Save_FileBarcode();
        }
        #endregion

        #region PrintDocument EAN13
        public void CreateBarcode()
        {
            try
            {
                if (true)
                {

                    string mAVACH = "";
                    if (true)
                    {
                        mAVACH = "";
                        this.DrawEan13(txtMa_Vt.Text, ref mAVACH);
                    }
                    //txtBARCODE.Text = mAVACH;
                }
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }


        private void DrawEan13(string S, ref string BARCODE)
        {
            //string strTen1 = txtTen_Vt2.Text;
            ////string strTen2 = txtTen_Vt.Text;
            ////string strTen2 = String.Format("{0:0,0 vnđ}", numGia_Ban.Value);    
            //string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            //try
            //{
            //    Graphics g = this.picBarCode.CreateGraphics();
            //    Rectangle rect = new Rectangle(0, 0, this.picBarCode.Width, this.picBarCode.Height);
            //    g.FillRectangle(new SolidBrush(Color.White), rect);
            //    BARCODEClassEAN13 sean = new BARCODEClassEAN13
            //    {
            //        CountryCode = S.Substring(0, 2),
            //        ManufacturerCode = S.Substring(2, 5),
            //        ProductCode = S.Substring(7),
            //        _fScale = 1.5f
            //    };
            //    Point pt = new Point(0, 4);
            //    sean.DrawEan13Barcode(ref g, pt, ref BARCODE, strTen1, strTen2);



            //    g.Dispose();
            //}
            //catch (Exception exception1)
            //{

            //    Exception exception = exception1;
            //}


            string strBarcode = txtMa_Vt.Text;
            string strTen1 = txtTen_Vt2.Text;
            //string strTen2 = txtTen_Vt.Text;
            //string strTen2 = String.Format("{0:0,0 vnđ}", numGia_Ban.Value);    
            string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            try
            {
                Graphics g = this.picBarCode.CreateGraphics();
                Rectangle rect = new Rectangle(0, 0, this.picBarCode.Width, this.picBarCode.Height);
                g.FillRectangle(new SolidBrush(Color.White), rect);

                Ean13 ean = new Ean13
                {
                    CountryCode = strBarcode.Substring(0, 2),
                    ManufacturerCode = strBarcode.Substring(2, 5),
                    ProductCode = strBarcode.Substring(7, 5),
                    strChecksumDigit = strBarcode.Substring(12, 1),
                    _fScale = 1f
                };


                Point pt = new Point(0, 0);
                ean.DrawEan13BarcodeView(g, pt, strTen1, strTen2, 1, 0f);

                g.Dispose();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
        private void DrawEan13AutoNew(string S, ref string BARCODE)
        {
            try
            {
                Graphics g = this.picBarCode.CreateGraphics();
                Rectangle rect = new Rectangle(0, 0, this.picBarCode.Width, this.picBarCode.Height);
                g.FillRectangle(new SolidBrush(Color.White), rect);
                BARCODEClassEAN13 sean = new BARCODEClassEAN13
                {
                    CountryCode = S.Substring(0, 2),
                    ManufacturerCode = S.Substring(2, 5),
                    ProductCode = S.Substring(7),
                    _fScale = 1.5f
                };
                Point pt = new Point(0, 0);
                sean.DrawEan13BarcodeNEW(ref g, pt, ref BARCODE);



                g.Dispose();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        #region Print Code EAN13
        internal virtual PrintDialog Print1
        {
            get
            {
                return this._Print1;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Print1 = value;
            }
        }
        internal virtual PrintDialog Print2
        {
            get
            {
                return this._Print2;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Print2 = value;
            }
        }
        internal virtual PrintDialog Print3
        {
            get
            {
                return this._Print3;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Print3 = value;
            }
        }

        internal virtual PrintDocument PrintDocument1
        {
            get
            {
                return this._PrintDocument1;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PrintPageEventHandler handler = new PrintPageEventHandler(this.PrintDocument1_PrintPage);
                if (this._PrintDocument1 != null)
                {
                    this._PrintDocument1.PrintPage -= handler;
                }
                this._PrintDocument1 = value;
                if (this._PrintDocument1 != null)
                {
                    this._PrintDocument1.PrintPage += handler;
                }
            }
        }
        internal virtual PrintDocument PrintDocument2
        {
            get
            {
                return this._PrintDocument2;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PrintPageEventHandler handler = new PrintPageEventHandler(this.PrintDocument2_PrintPage);
                if (this._PrintDocument2 != null)
                {
                    this._PrintDocument2.PrintPage -= handler;
                }
                this._PrintDocument2 = value;
                if (this._PrintDocument2 != null)
                {
                    this._PrintDocument2.PrintPage += handler;
                }
            }
        }
        internal virtual PrintDocument PrintDocument3
        {
            get
            {
                return this._PrintDocument3;
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PrintPageEventHandler handler = new PrintPageEventHandler(this.PrintDocument3_PrintPage);
                if (this._PrintDocument3 != null)
                {
                    this._PrintDocument3.PrintPage -= handler;
                }
                this._PrintDocument3 = value;
                if (this._PrintDocument3 != null)
                {
                    this._PrintDocument3.PrintPage += handler;
                }
            }
        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string strBarcode = txtMa_Vt.Text;
            string strTen1 = txtTen_Vt2.Text;
            //string strTen2 = txtTen_Vt.Text;
            //string strTen2 = String.Format("{0:0,0 vnđ}", numGia_Ban.Value);    
            string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            try
            {
                Graphics g = e.Graphics;
                float left = e.MarginBounds.Left;
                float num3 = 10f;
                float num5 = 0f;
                Ean13 ean = new Ean13
                {
                    CountryCode = strBarcode.Substring(0, 2),
                    ManufacturerCode = strBarcode.Substring(2, 5),
                    ProductCode = strBarcode.Substring(7, 5),
                    strChecksumDigit = strBarcode.Substring(12, 1),
                    _fScale = 1f
                };
                int num = 0;
                int numH = 0;
                float a = 0.5f;
                do
                {
                    num5 = num3 + (num * 0x16);
                    Point pt = new Point((int)Math.Round((double)(left + 50f)), (int)Math.Round((double)num5));
                    ean.DrawEan13BarcodeView(g, pt, strTen1, strTen2, 7, 0f);
                    //PointF pt = new PointF((int)Math.Round((double)(left + 50f)), (int)Math.Round((double)num5)-a*numH);
                    //ean.DrawEan13BarcodeView(g, pt, strTen1, strTen2, 5, 0f);
                    num++;
                    numH += 2;
                }
                while (num <= 12);
                g.Dispose();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private void PrintDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            string strBarcode = txtMa_Vt.Text;
            string strTen1 = txtTen_Vt2.Text;
            //string strTen2 = txtTen_Vt.Text;
            //string strTen2 = String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            try
            {
                Graphics g = e.Graphics;
                float left = e.MarginBounds.Left;
                float num3 = 0f;
                float num5 = 0f;
                int num = 0;
                ClassEan13FT220 eanft = new ClassEan13FT220
                {
                    CountryCode = strBarcode.Substring(0, 2),
                    ManufacturerCode = strBarcode.Substring(2, 5),
                    ProductCode = strBarcode.Substring(7),
                    _fScale = 1f
                };
                num5 = num3 + (num * 0x16);
                Point pt = new Point((int)Math.Round((double)(left + 50f)), (int)Math.Round((double)num5));
                eanft.DrawEan13Barcode(g, pt, strTen1, strTen2, 2);
                g.Dispose();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private void PrintDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            string strBarcode = txtMa_Vt.Text;
            string strTen1 = txtTen_Vt2.Text;
            //string strTen2 = txtTen_Vt.Text;
            //string strTen2 = String.Format("{0:0,0 vnđ}", numGia_Ban.Value);    
            string strTen2 = txtTen_Vt.Text + "\n" + String.Format("{0:0,0 vnđ}", numGia_Ban.Value);
            try
            {
                if (true)
                {
                    Graphics g = e.Graphics;
                    float left = e.MarginBounds.Left;
                    float num3 = 0f;
                    float num5 = 0f;
                    int num = 0;
                    ClassEan13FT220 eanft = new ClassEan13FT220
                    {
                        CountryCode = strBarcode.Substring(0, 2),
                        ManufacturerCode = strBarcode.Substring(2, 5),
                        ProductCode = strBarcode.Substring(7, 5),
                        _fScale = 1f
                    };
                    num5 = num3 + (num * 0x16);
                    Point pt = new Point((int)Math.Round((double)(left + 50f)), (int)Math.Round((double)num5));
                    eanft.DrawEan13Barcode(g, pt, strTen1, strTen2, 2);
                    g.Dispose();
                }
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
        #endregion

        #endregion
    }
}
