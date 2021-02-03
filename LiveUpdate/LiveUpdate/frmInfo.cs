using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

//using System.Globalization;
//using System.Threading;
//using System.Resources;
//using System.Reflection;


namespace AutoMail
{
    public partial class frmInfo : Epoint.Systems.Customizes.frmView
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        public override void Load()
        {
            lblSERVER_NAME.Text = Element.sysConnection.DataSource;
            lblDATABASE_NAME.Text = Element.sysConnection.Database;
            this.ShowDialog();
        }
    }
}