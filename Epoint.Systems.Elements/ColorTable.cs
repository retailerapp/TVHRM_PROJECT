using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Epoint.Systems.Elements
{
    public class ColorTable
    {
        public static Color ColumnHeaderStartColor = Color.FromArgb(245, 249, 251);
        public static Color ColumnHeaderMidColor1 = Color.FromArgb(234, 239, 245);
        public static Color ColumnHeaderMidColor2 = Color.FromArgb(224, 231, 240);
        public static Color ColumnHeaderEndColor = Color.FromArgb(212, 220, 233);
        public static Color ColumnHeaderActiveStartColor = Color.FromArgb(248, 214, 152);
        public static Color ColumnHeaderActiveMidColor1 = Color.FromArgb(246, 207, 131);
        public static Color ColumnHeaderActiveMidColor2 = Color.FromArgb(244, 201, 117);
        public static Color ColumnHeaderActiveEndColor = Color.FromArgb(242, 195, 99);
        public static Color GridColor = Color.FromArgb(208, 215, 229);
        public static Color GridColumnHeadersDefaultCellStyle = Color.FromArgb(0xff, 0xf5, 0xf9, 0xff);

        public static Color DefaultCellColor = Color.FromArgb(255, 255, 255);
        public static Color ActiveCellColor = Color.FromArgb(135, 169, 213);
        public static Color ReadonlyCellColor = Color.FromArgb(138, 138, 138);
        //text button Toolstrip
        public static Color TextLanguageV = Color.Red;
        public static Color TextLanguageE = Color.Blue;
        public static Color TextLanguageO = Color.Green;
        public static Color TextDateTime = Color.Blue;

        //text Narbar
        public static Color TextModuleColor = Color.Navy;
        public static Color TextItemColor = Color.Black;
        public static Color TextItemGroupColor = Color.DarkBlue;
        
        //text Status
        public static Color TextStatus = Color.Black;
        public static Color TextStatusProcess = Color.Black;
        public static Color TextStatusDatetime = Color.Black;
        public static Color TextStatusServer = Color.Black;
        public static Color TextStatusDatabase = Color.Black;

        public static Color TextStatusReminder = Color.Black;
        public static Color TextStatusReminder_Acctive = Color.Red;

    }
}
