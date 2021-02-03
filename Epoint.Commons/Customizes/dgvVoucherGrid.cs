using System;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Librarys;

using Epoint.Systems.Data;

namespace Epoint.Systems.Customizes
{
	public class dgvVoucherGrid: Epoint.Systems.Controls.dgvGridControl
	{
		public Keys kLastKey = Keys.None;

        public dgvVoucherGrid()
		{
			this.ReadOnly = false;
		}
		
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
            //if (((baseCurrentCell != null) && (base.Columns[base.CurrentCell.ColumnIndex] != null)) && (base.Columns[base.CurrentCell.ColumnIndex].GetType().Name == "dgvTextBoxColumn"))
            //{
            //    Epoint.Systems.Controls.dgvTextBoxColumn column = (Epoint.Systems.Controls.dgvTextBoxColumn)base.Columns[base.CurrentCell.ColumnIndex];
            //    if ((column.AutoFilter != null) && column.AutoFilter.Visible)
            //    {
            //        return base.ProcessCmdKey(ref msg, keyData);
            //    }
            //}

		
			this.kLastKey = keyData;		

			if (keyData == Keys.Enter)
			{			
			    return base.ProcessDialogKey(Keys.Tab);				
			}
			else
				return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData == Keys.Tab)
				return true;
			else
				return base.IsInputKey(keyData);
		}		
		
	}
}
