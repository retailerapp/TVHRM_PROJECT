using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
    public partial class btgAccept : UserControl
    {
        public btgAccept()
        {
            InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Down:
					return this.ProcessDialogKey(Keys.Tab);

				case Keys.Up:
					return this.ProcessDialogKey(Keys.Shift | Keys.Tab);
					//this.FindForm().SelectNextControl(this, false, true, true, true);
					//break;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
    }
}
