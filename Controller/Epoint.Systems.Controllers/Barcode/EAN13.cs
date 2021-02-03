using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace Epoint.Controllers
{
    public static class  POSElement
    {
        internal static char KYTUBARCODE;
    }

    public class BARCODEClassEAN13
    {
        // Fields
        private string[] _aEvenLeft = new string[] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string[] _aOddLeft = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] _aRight = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        internal float _fFontSize = 6f;
        internal float _fHeight = 13f;
        //internal float _fScale = 1f;
        public float _fScale = 1f;
        internal float _fWidth = 28f;
        private string _sLeadTail = "101";
        private string _sQuiteZone = "000000000";
        private string _sSeparator = "01010";
        internal string ChecksumDigit;
        //internal string CountryCode;
        //internal string ManufacturerCode;
        //internal string ProductCode;
        public string CountryCode;
        public string ManufacturerCode;
        public string ProductCode;
        // Methods
        public void CalculateChecksumDigit()
        {
            try
            {
                string str = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int num4 = 0;
                int num3 = 0;
                for (int i = str.Length; i >= 1; i += -1)
                {
                    num3 = Convert.ToInt32(str.Substring(i - 1, 1));
                    if ((i % 2) == 0)
                    {
                        num4 += num3 * 3;
                    }
                    else
                    {
                        num4 += num3 * 1;
                    }
                }
                this.ChecksumDigit = ((10 - (num4 % 10)) % 10).ToString();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "1":
                    return this.CountryCode1(sLeft.Substring(1));

                case "8":
                    return this.CountryCode8(sLeft.Substring(1));
            }
            return "";
        }

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            int num3 = inputNumber.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                index = Convert.ToInt32(inputNumber.Substring(i, 1));
                builder.Append(patterns[index]);
            }
            return builder.ToString();
        }

        private string CountryCode1(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode8(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        public void DrawEan13Barcode(ref Graphics g, Point pt, ref string BARCODE)
        {
            float num6 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num6) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float x = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float num9 = pt.X;
            float y = pt.Y;
            float num7 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            //builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, "" });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num12 = builder2.Length - 1;
            for (int i = 0; i <= num12; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (num9 == pt.X)
                    {
                        num9 = x;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        g.FillRectangle(brush, x, y, width, height - num);
                    }
                    else
                    {
                        g.FillRectangle(brush, x, y, width, height);
                    }
                }
                x += width;
                num7 = x;
            }
            float num5 = 0f;
            x = num9 - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            num5 = x + 8f;
            float num10 = y + (height - num);
            PointF point = new PointF(x, num10);
            g.DrawString(str2.Substring(0, 1), font, brush, point);
            x += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(1, 6), font, brush, point);
            x += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(7), font, brush, point);
            g.Restore(gstate);
            BARCODE = str2.ToString();

        }
        public void DrawEan13Barcode(ref Graphics g, Point pt, ref string BARCODE, string TieuDe1,string TieuDe2)
        {
           
            float num6 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num6) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float x = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float num9 = pt.X;
            float y = pt.Y;
            float num7 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            //builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, "" });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num12 = builder2.Length - 1;
            PointF tf = new PointF(3,0);
            g.DrawString(TieuDe1, font, brush, tf);
            for (int i = 0; i <= num12; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (num9 == pt.X)
                    {
                        num9 = x;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        g.FillRectangle(brush, x, y, width, height - num);
                    }
                    else
                    {
                        g.FillRectangle(brush, x, y, width, height);
                    }
                }
                x += width;
                num7 = x;
            }
            float num5 = 0f;
            x = num9 - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            num5 = x + 8f;
            float num10 = y + (height - num);
            PointF point = new PointF(x, num10);
            g.DrawString(str2.Substring(0, 1), font, brush, point);
            x += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(1, 6), font, brush, point);
            x += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(7), font, brush, point);
            float a =3;
            float b = 22;
            PointF tf2 = new PointF(a, b);
            g.DrawString(TieuDe2, font, brush, tf2);
            g.Restore(gstate);
            BARCODE = str2.ToString();

        }

        public void DrawEan13BarcodeNEW(ref Graphics g, Point pt, ref string BARCODE)
        {
            float num6 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num6) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float x = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float num9 = pt.X;
            float y = pt.Y;
            float num7 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            //builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, "" });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num12 = builder2.Length - 1;
            for (int i = 0; i <= num12; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (num9 == pt.X)
                    {
                        num9 = x;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        g.FillRectangle(brush, x, y, width, height - num);
                    }
                    else
                    {
                        g.FillRectangle(brush, x, y, width, height);
                    }
                }
                x += width;
                num7 = x;
            }
            float num5 = 0f;
            x = num9 - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            num5 = x + 8f;
            float num10 = y + (height - num);
            PointF point = new PointF(x, num10);
            g.DrawString(str2.Substring(0, 1), font, brush, point);
            x += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(1, 6), font, brush, point);
            x += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            point = new PointF(x, num10);
            g.DrawString(str2.Substring(7), font, brush, point);
            g.Restore(gstate);
            BARCODE = str2.ToString();

        }
    }


    public  class ClassEAN13
    {
        // Fields
        private string[] _aEvenLeft = new string[] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string[] _aOddLeft = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] _aRight = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        internal float _fFontSize = 6f;
        internal float _fHeight = 13f;
        internal float _fScale = 1f;
        internal float _fWidth = 28f;
        private string _sLeadTail = "101";
        private string _sQuiteZone = "000000000";
        private string _sSeparator = "01010";
        internal string ChecksumDigit;
        internal string CountryCode;
        internal string ManufacturerCode;
        internal string ProductCode;

        // Methods
        public void CalculateChecksumDigit()
        {
            try
            {
                string str = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int num4 = 0;
                int num3 = 0;
                for (int i = str.Length; i >= 1; i += -1)
                {
                    num3 = Convert.ToInt32(str.Substring(i - 1, 1));
                    if ((i % 2) == 0)
                    {
                        num4 += num3 * 3;
                    }
                    else
                    {
                        num4 += num3 * 1;
                    }
                }
                this.ChecksumDigit = ((10 - (num4 % 10)) % 10).ToString();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
            }
        }

        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "1":
                    return this.CountryCode1(sLeft.Substring(1));

                case "8":
                    return this.CountryCode8(sLeft.Substring(1));
            }
            return "";
        }

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            int num3 = inputNumber.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                index = Convert.ToInt32(inputNumber.Substring(i, 1));
                builder.Append(patterns[index]);
            }
            return builder.ToString();
        }

        private string CountryCode1(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode8(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        public Bitmap CreateBitmap()
        {
            float num2 = (this._fWidth * this._fScale) * 100f;
            float num = (this._fHeight * this._fScale) * 100f;
            Bitmap image = new Bitmap((int)Math.Round((double)num2), (int)Math.Round((double)num));
            Graphics g = Graphics.FromImage(image);
            Point pt = new Point(0, 0);
            this.DrawEan13Barcode(ref g, pt);
            g.Dispose();
            return image;
        }

        public void DrawEan13Barcode(ref Graphics g, Point pt)
        {
            float num5 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num5) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float x = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float num8 = pt.X;
            float y = pt.Y;
            float num6 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num11 = builder2.Length - 1;
            for (int i = 0; i <= num11; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (num8 == pt.X)
                    {
                        num8 = x;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        g.FillRectangle(brush, x, y, width, height - num);
                    }
                    else
                    {
                        g.FillRectangle(brush, x, y, width, height);
                    }
                }
                x += width;
                num6 = x;
            }
            x = num8 - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float num9 = y + (height - num);
            PointF point = new PointF(x, num9);
            g.DrawString(str2.Substring(0, 1), font, brush, point);
            x += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            point = new PointF(x, num9);
            g.DrawString(str2.Substring(1, 6), font, brush, point);
            x += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            point = new PointF(x, num9);
            g.DrawString(str2.Substring(7), font, brush, point);
            g.Restore(gstate);
        }
    }


    public  class ClassEan13FT220
    {
        // Fields
        private string[] _aEvenLeft = new string[] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string[] _aOddLeft = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] _aRight = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        internal float _fFontSize = 6f;//7.6f;
        internal float _fHeight = 10f;
        internal float _fScale = 1f;//2f;
        internal float _fWidth = 34f;
        private string _sLeadTail = "101";
        private string _sQuiteZone = "000000000";
        private string _sSeparator = "01010";
        internal string ChecksumDigit;
        internal string CountryCode;
        internal string ManufacturerCode;
        internal string ProductCode;

        // Methods
        public void CalculateChecksumDigit()
        {
            try
            {
                string str = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int num4 = 0;
                int num3 = 0;
                for (int i = str.Length; i >= 1; i += -1)
                {
                    num3 = Convert.ToInt32(str.Substring(i - 1, 1));
                    if ((i % 2) == 0)
                    {
                        num4 += num3 * 3;
                    }
                    else
                    {
                        num4 += num3 * 1;
                    }
                }
                this.ChecksumDigit = ((10 - (num4 % 10)) % 10).ToString();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "1":
                    return this.CountryCode1(sLeft.Substring(1));

                case "2":
                    return this.CountryCode2(sLeft.Substring(1));

                case "3":
                    return this.CountryCode3(sLeft.Substring(1));

                case "4":
                    return this.CountryCode4(sLeft.Substring(1));

                case "5":
                    return this.CountryCode5(sLeft.Substring(1));

                case "6":
                    return this.CountryCode6(sLeft.Substring(1));

                case "7":
                    return this.CountryCode7(sLeft.Substring(1));

                case "8":
                    return this.CountryCode8(sLeft.Substring(1));
            }
            return "";
        }

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            int num3 = inputNumber.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                index = Convert.ToInt32(inputNumber.Substring(i, 1));
                builder.Append(patterns[index]);
            }
            return builder.ToString();
        }

        private string CountryCode0(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode1(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode2(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode3(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode4(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode5(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode6(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode7(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode8(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        public void DrawEan13Barcode(Graphics g, Point pt, string TieuDe1, string TieuDe2, byte SOTEM)
        {
            PointF tf;
            float num9 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num9) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float num11 = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float x = pt.X;
            float y = pt.Y;
            float num10 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num3 = g.MeasureString(text, font).Height;
            short num = 0x2a;
            short num2 = 7;
            int num15 = SOTEM - 1;
            int num6 = 0;
            while (num6 <= num15)
            {
                tf = new PointF(((num11 + (num * num6)) + num2) + 2f, y + 3f);
                g.DrawString(TieuDe1, font, brush, tf);
                num6++;
            }
            y += 6f;
            int num16 = builder2.Length - 1;
            for (int i = 0; i <= num16; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (x == pt.X)
                    {
                        x = num11;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        int num17 = SOTEM - 1;
                        num6 = 0;
                        while (num6 <= num17)
                        {
                            g.FillRectangle(brush, (num11 + (num * num6)) + num2, y, width, height - num3);
                            num6++;
                        }
                    }
                    else
                    {
                        int num18 = SOTEM - 1;
                        num6 = 0;
                        while (num6 <= num18)
                        {
                            g.FillRectangle(brush, (num11 + (num * num6)) + num2, y, width, height);
                            num6++;
                        }
                    }
                }
                num11 += width;
                num10 = num11;
            }
            num11 = x - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float num8 = num11 + 2f;
            float num13 = y + (height - num3);
            int num19 = SOTEM - 1;
            for (num6 = 0; num6 <= num19; num6++)
            {
                tf = new PointF((num11 + (num * num6)) + num2, num13);
                g.DrawString(str2.Substring(0, 1), font, brush, tf);
            }
            num11 += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            int num20 = SOTEM - 1;
            for (num6 = 0; num6 <= num20; num6++)
            {
                tf = new PointF((num11 + (num * num6)) + num2, num13);
                g.DrawString(str2.Substring(1, 6), font, brush, tf);
            }
            num11 += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            int num21 = SOTEM - 1;
            for (num6 = 0; num6 <= num21; num6++)
            {
                tf = new PointF((num11 + (num * num6)) + num2, num13);
                g.DrawString(str2.Substring(7), font, brush, tf);
                tf = new PointF((num8 + (num * num6)) + num2, num13 + 4f);
                g.DrawString(TieuDe2, font, brush, tf);
            }
            g.DrawLine(Pens.LightGray, (float)0f, (float)(num13 + 8f), (float)500f, (float)(num13 + 8f));
            g.Restore(gstate);
            try
            {
                POSElement.KYTUBARCODE = Convert.ToChar(str2.Substring(str2.Length - 1, 1));
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
    }

    public  class ClassEan13FT220_2
    {
        // Fields
        private string[] _aEvenLeft = new string[] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string[] _aOddLeft = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] _aRight = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        internal float _fFontSize = 7.6f;
        internal float _fHeight = 10f;
        internal float _fScale = 2f;
        internal float _fWidth = 34f;
        private string _sLeadTail = "101";
        private string _sQuiteZone = "000000000";
        private string _sSeparator = "01010";
        internal string ChecksumDigit;
        internal string CountryCode;
        internal string ManufacturerCode;
        internal string ProductCode;

        // Methods
        public void CalculateChecksumDigit()
        {
            try
            {
                string str = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int num4 = 0;
                int num3 = 0;
                for (int i = str.Length; i >= 1; i += -1)
                {
                    num3 = Convert.ToInt32(str.Substring(i - 1, 1));
                    if ((i % 2) == 0)
                    {
                        num4 += num3 * 3;
                    }
                    else
                    {
                        num4 += num3 * 1;
                    }
                }
                this.ChecksumDigit = ((10 - (num4 % 10)) % 10).ToString();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "1":
                    return this.CountryCode1(sLeft.Substring(1));

                case "2":
                    return this.CountryCode2(sLeft.Substring(1));

                case "3":
                    return this.CountryCode3(sLeft.Substring(1));

                case "4":
                    return this.CountryCode4(sLeft.Substring(1));

                case "5":
                    return this.CountryCode5(sLeft.Substring(1));

                case "6":
                    return this.CountryCode6(sLeft.Substring(1));

                case "7":
                    return this.CountryCode7(sLeft.Substring(1));

                case "8":
                    return this.CountryCode8(sLeft.Substring(1));
            }
            return "";
        }

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            int num3 = inputNumber.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                index = Convert.ToInt32(inputNumber.Substring(i, 1));
                builder.Append(patterns[index]);
            }
            return builder.ToString();
        }

        private string CountryCode0(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode1(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode2(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode3(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode4(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode5(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode6(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode7(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode8(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        public Bitmap CreateBitmap(string TieuDe1, string TieuDe2, byte SOTEM)
        {
            float num2 = (float)((this._fWidth * this._fScale) * 3.7);
            float num = (float)((this._fHeight * this._fScale) * 6.6);
            Bitmap image = new Bitmap((int)Math.Round((double)num2), (int)Math.Round((double)num));
            Graphics g = Graphics.FromImage(image);
            Point pt = new Point(0, 0);
            this.DrawEan13Barcode(g, pt, TieuDe1, TieuDe2, SOTEM);
            g.Dispose();
            return image;
        }

        public void DrawEan13Barcode(Graphics g, Point pt, string TieuDe1, string TieuDe2, byte SOTEM)
        {
            PointF tf;
            float num7 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num7) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float x = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float num10 = pt.X;
            float y = pt.Y;
            float num8 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num13 = SOTEM - 1;
            int num4 = 0;
            while (num4 <= num13)
            {
                tf = new PointF(x + 3f, y);
                g.DrawString(TieuDe1, font, brush, tf);
                num4++;
            }
            y += 3f;
            int num14 = builder2.Length - 1;
            for (int i = 0; i <= num14; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (num10 == pt.X)
                    {
                        num10 = x;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        int num15 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num15)
                        {
                            g.FillRectangle(brush, x, y, width, height - num);
                            num4++;
                        }
                    }
                    else
                    {
                        int num16 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num16)
                        {
                            g.FillRectangle(brush, x, y, width, height);
                            num4++;
                        }
                    }
                }
                x += width;
                num8 = x;
            }
            x = num10 - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float num6 = x + 2f;
            float num11 = y + (height - num);
            int num17 = SOTEM - 1;
            for (num4 = 0; num4 <= num17; num4++)
            {
                tf = new PointF(x, num11);
                g.DrawString(str2.Substring(0, 1), font, brush, tf);
            }
            x += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            int num18 = SOTEM - 1;
            for (num4 = 0; num4 <= num18; num4++)
            {
                tf = new PointF(x, num11);
                g.DrawString(str2.Substring(1, 6), font, brush, tf);
            }
            x += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            int num19 = SOTEM - 1;
            for (num4 = 0; num4 <= num19; num4++)
            {
                tf = new PointF(x, num11);
                g.DrawString(str2.Substring(7), font, brush, tf);
                tf = new PointF(num6, num11 + 4f);
                g.DrawString(TieuDe2, font, brush, tf);
            }
            g.Restore(gstate);
            try
            {
                //ThuVien.KYTUBARCODE = Conversions.ToChar(str2.Substring(str2.Length - 1, 1));
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
    }

    public  class Ean13
    {
        // Fields
        private string[] _aEvenLeft = new string[] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private string[] _aOddLeft = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] _aRight = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        internal float _fFontSize = 7.6f;
        internal float _fHeight = 12f;
        internal float _fScale = 2f;
        internal float _fWidth = 26f;
        //internal float _fWidth = 18f;
        private string _sLeadTail = "101";
        private string _sQuiteZone = "000000000";
        private string _sSeparator = "01010";
        internal string ChecksumDigit;
        internal string CountryCode;
        internal string ManufacturerCode;
        internal string ProductCode;
        internal string strChecksumDigit;

        // Methods
        public void CalculateChecksumDigit()
        {
            try
            {
                string str = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int num4 = 0;
                int num3 = 0;
                for (int i = str.Length; i >= 1; i += -1)
                {
                    num3 = Convert.ToInt32(str.Substring(i - 1, 1));
                    if ((i % 2) == 0)
                    {
                        num4 += num3 * 3;
                    }
                    else
                    {
                        num4 += num3 * 1;
                    }
                }
                this.ChecksumDigit = ((10 - (num4 % 10)) % 10).ToString();
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }

        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "1":
                    return this.CountryCode1(sLeft.Substring(1));

                case "2":
                    return this.CountryCode2(sLeft.Substring(1));

                case "3":
                    return this.CountryCode3(sLeft.Substring(1));

                case "4":
                    return this.CountryCode4(sLeft.Substring(1));

                case "5":
                    return this.CountryCode5(sLeft.Substring(1));

                case "6":
                    return this.CountryCode6(sLeft.Substring(1));

                case "7":
                    return this.CountryCode7(sLeft.Substring(1));

                case "8":
                    return this.CountryCode8(sLeft.Substring(1));
            }
            return "";
        }

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            int num3 = inputNumber.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                index = Convert.ToInt32(inputNumber.Substring(i, 1));
                builder.Append(patterns[index]);
            }
            return builder.ToString();
        }

        private string CountryCode0(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode1(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode2(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode3(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode4(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode5(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode6(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        private string CountryCode7(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return builder.ToString();
        }

        private string CountryCode8(string sLeft)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            builder.Append(this.ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return builder.ToString();
        }

        public void DrawEan13Barcode(Graphics g, Point pt, string TieuDe1, string TieuDe2, byte SOTEM)
        {
            PointF tf;
            float num7 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num7) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float num9 = 0f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float x = pt.X;
            float y = pt.Y;
            float num8 = 0f;
            Font font = new Font("Arial", this._fFontSize * this._fScale);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num13 = SOTEM - 1;
            int num4 = 0;
            while (num4 <= num13)
            {
                tf = new PointF((num9 + (0x1c * num4)) + 3f, y);
                g.DrawString(TieuDe1, font, brush, tf);
                num4++;
            }
            y += 3f;
            int num14 = builder2.Length - 1;
            for (int i = 0; i <= num14; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (x == pt.X)
                    {
                        x = num9;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        int num15 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num15)
                        {
                            g.FillRectangle(brush, (num9 + (0x1c * num4)) + 2f, y, width, height - num);
                            num4++;
                        }
                    }
                    else
                    {
                        int num16 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num16)
                        {
                            g.FillRectangle(brush, (num9 + (0x1c * num4)) + 2f, y, width, height);
                            num4++;
                        }
                    }
                }
                num9 += width;
                num8 = num9;
            }
            num9 = x - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float num6 = num9 + 2f;
            float num11 = y + (height - num);
            int num17 = SOTEM - 1;
            for (num4 = 0; num4 <= num17; num4++)
            {
                tf = new PointF((num9 + (0x1c * num4)) + 2f, num11);
                g.DrawString(str2.Substring(0, 1), font, brush, tf);
            }
            num9 += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            int num18 = SOTEM - 1;
            for (num4 = 0; num4 <= num18; num4++)
            {
                tf = new PointF((num9 + (0x1c * num4)) + 2f, num11);
                g.DrawString(str2.Substring(1, 6), font, brush, tf);
            }
            num9 += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            int num19 = SOTEM - 1;
            for (num4 = 0; num4 <= num19; num4++)
            {
                tf = new PointF((num9 + (0x1c * num4)) + 2f, num11);
                g.DrawString(str2.Substring(7), font, brush, tf);
                tf = new PointF((num6 + (0x1c * num4)) + 2f, num11 + 4f);
                g.DrawString(TieuDe2, font, brush, tf);
            }
            g.DrawLine(Pens.LightGray, (float)0f, (float)(num11 + 8f), (float)500f, (float)(num11 + 8f));
            g.Restore(gstate);
            try
            {
                POSElement.KYTUBARCODE = Convert.ToChar(str2.Substring(str2.Length - 1, 1));
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
        public void DrawEan13BarcodeView(Graphics g, PointF pt, string TieuDe1, string TieuDe2, byte SOTEM,float fDv)
        {
            //string strCheckSum = BARCODE.Substring(BARCODE.Length - 1, 1);
            PointF tf;
            float num7 = this._fWidth * this._fScale;
            float height = this._fHeight * this._fScale;
            float width = (float)(((double)num7) / 113.0);
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Millimeter;
            g.PageScale = 1f;
            SolidBrush brush = new SolidBrush(Color.Black);
            float num9 = 10f;
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            float x = pt.X;
            float y = pt.Y;
            //if (y > 10)
            y = y - fDv;
            float num8 = 0f;
            Font font = new Font("Arial", 6f * 1f);
            this.CalculateChecksumDigit();
            builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, this.ChecksumDigit });
            //builder.AppendFormat("{0}{1}{2}{3}", new object[] { this.CountryCode, this.ManufacturerCode, this.ProductCode, strChecksumDigit });
            string str2 = builder.ToString();
            string str = "";
            str = this.ConvertLeftPattern(str2.Substring(0, 7));
            builder2.AppendFormat("{0}{1}{2}{3}{4}{1}{0}", new object[] { this._sQuiteZone, this._sLeadTail, str, this._sSeparator, this.ConvertToDigitPatterns(str2.Substring(7), this._aRight) });
            string text = builder2.ToString();
            float num = g.MeasureString(text, font).Height;
            int num13 = SOTEM - 1;
            int num4 = 0;
            int iWith = 0x1c;
            //int iWith = 40;
            while (num4 <= num13)
            {
                tf = new PointF((num9 + (iWith * num4)) + 3f, y);
                g.DrawString(TieuDe1, font, brush, tf);
                num4++;
            }
            y += 3f;
            int num14 = builder2.Length - 1;
            for (int i = 0; i <= num14; i++)
            {
                if (text.Substring(i, 1) == "1")
                {
                    if (x == pt.X)
                    {
                        x = num9;
                    }
                    if (((i > 12) & (i < 0x37)) | ((i > 0x39) & (i < 0x65)))
                    {
                        int num15 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num15)
                        {
                            g.FillRectangle(brush, (num9 + (iWith * num4)) + 2f, y, width, height - num);
                            num4++;
                        }
                    }
                    else
                    {
                        int num16 = SOTEM - 1;
                        num4 = 0;
                        while (num4 <= num16)
                        {
                            g.FillRectangle(brush, (num9 + (iWith * num4)) + 2f, y, width, height);
                            num4++;
                        }
                    }
                }
                num9 += width;
                num8 = num9;
            }
            num9 = x - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float num6 = num9 + 2f;
            float num11 = y + (height - num);
            int num17 = SOTEM - 1;
            for (num4 = 0; num4 <= num17; num4++)
            {
                tf = new PointF((num9 + (iWith * num4)) + 2f, num11);
                g.DrawString(str2.Substring(0, 1), font, brush, tf);
            }
            num9 += (g.MeasureString(str2.Substring(0, 1), font).Width + (43f * width)) - g.MeasureString(str2.Substring(1, 6), font).Width;
            int num18 = SOTEM - 1;
            for (num4 = 0; num4 <= num18; num4++)
            {
                tf = new PointF((num9 + (iWith * num4)) + 2f, num11);
                g.DrawString(str2.Substring(1, 6), font, brush, tf);
            }
            num9 += g.MeasureString(str2.Substring(1, 6), font).Width + (11f * width);
            int num19 = SOTEM - 1;
            for (num4 = 0; num4 <= num19; num4++)
            {
                tf = new PointF((num9 + (iWith * num4)) + 2f, num11);
                g.DrawString(str2.Substring(7), font, brush, tf);
                tf = new PointF((num6 + (iWith * num4)) + 2f, num11 + 2f);
                g.DrawString(TieuDe2, font, brush, tf);
            }
            g.DrawLine(Pens.LightGray, (float)0f, (float)(num11 + 8f), (float)500f, (float)(num11 + 8f));
            g.Restore(gstate);
            try
            {
                POSElement.KYTUBARCODE = Convert.ToChar(str2.Substring(str2.Length - 1, 1));
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
            }
        }
    
    }


 
}
