using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Commons
{
    public class Public
    {
        #region DocTien
        public static string ReadMoneyC(Double SoTien)
        {
            string[] strSo = { " 零 ", " 壹 ", " 貳 ", " 叁 ", " 肆 ", " 伍 ", " 陆 ", " 柒 ", 
                                    " 捌 ", " 玖 " };

            string strKq = string.Empty;

            if (SoTien == 0)
                return " 零 ";

            if (SoTien == 10)
                return " 拾 ";

            long SoTien0 = Convert.ToInt64(Math.Truncate(SoTien));
            long SoTien00 = SoTien0;

            for (int i = 3; i >= 0; i--)
            {
                long ivalue = Convert.ToInt64(Math.Truncate(SoTien0 / Math.Pow(10, 3 * i)));
                SoTien0 = SoTien0 - Convert.ToInt64(ivalue * Math.Pow(10, 3 * i));

                if (ivalue > 0)
                {
                    int iDonvi = Convert.ToInt32(ivalue % 10);
                    int iChuc = Convert.ToInt32(ivalue % 100 - iDonvi);
                    int iTram = Convert.ToInt32(ivalue % 1000 - iChuc);

                    iChuc = iChuc / 10;
                    iTram = iTram / 100;

                    for (int j = 2; j >= 0; j--)
                    {
                        if (j == 2) //Hang tram
                        {
                            if (iTram == 0 && strKq == string.Empty)
                                continue;

                            if (i == 3) // ty
                                strKq += strSo[iTram] + " 佰 ";
                            else
                                if (i == 2) // tram trieu
                                    strKq += strSo[iTram] + " 億 ";
                                else
                                    if (i == 1) // tram ngan
                                        strKq += strSo[iTram] + " 拾 萬 ";
                                    else
                                        strKq += strSo[iTram] + " 佰 ";
                        }
                        else if (j == 1) //Hang chuc
                        {
                            if (iChuc == 0)
                                continue;

                            if (i == 3) // ty
                                strKq += strSo[iChuc] + " 拾 ";
                            else
                                if (i == 2) // chuc trieu
                                    strKq += strSo[iChuc] + " 仟 萬 ";
                                else
                                    if (i == 1) // chuc ngan
                                        strKq += strSo[iChuc] + " 萬 ";
                                    else
                                        if (SoTien00 < 20)
                                            strKq += " 拾 ";
                                        else
                                            strKq += strSo[iChuc] + " 拾 ";
                        }
                        else if (j == 0) //Hang dv
                        {
                            if (iDonvi == 0)
                                continue;

                            if (iChuc == 0)
                            {
                                if (strKq != string.Empty)
                                    strKq += " 零 ";
                            }

                            if (i == 3) // ty
                                strKq += strSo[iDonvi] + " 拾 億 ";
                            else
                                if (i == 2) // trieu
                                    strKq += strSo[iDonvi] + " 佰 萬 ";
                                else
                                    if (i == 1) // ngan
                                        strKq += strSo[iDonvi] + " 仟 ";
                                    else
                                        strKq += strSo[iDonvi];
                        }
                    }
                }
            }
            strKq = strKq.Replace("  ", " ").Trim();
            strKq = strKq.Substring(0, 1) + strKq.Substring(1);

            string str0 = string.Empty;
            string str1 = string.Empty;

            // rut gon nhieu chu 萬 thanh 1 chu
            for (int j = strKq.Length - 1; j >= 0; j--)
            {
                if (strKq[j].ToString() == "萬")
                {
                    str0 = strKq.Substring(j, strKq.Length - j);
                    str1 = strKq.Substring(0, j);

                    break;
                }
            }
            str1 = str1.Replace("萬 ", "");
            strKq = str1 + str0;

            // rut gon nhieu chu 億 thanh 1 chu
            for (int j = strKq.Length - 1; j >= 0; j--)
            {
                if (strKq[j].ToString() == "億")
                {
                    str0 = strKq.Substring(j, strKq.Length - j);
                    str1 = strKq.Substring(0, j);

                    break;
                }
            }
            str1 = str1.Replace("億 ", "");
            strKq = str1 + str0;

            return strKq + " 元 整 ";

        }
        #endregion
    }
}
