using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class txtMa_Tte : Epoint.Systems.Controls.txtEnum
	{
		public txtMa_Tte()
		{ 
		}

        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs levent)
        {
            if (Elements.Element.Is_Running)
            {
                base.OnLayout(levent);

                this.InputMask = (string)Librarys.Parameters.GetParaValue("MA_TTE_LIST");

                if (this.Text == string.Empty)
                {
                    this.Text = Elements.Element.sysMa_Tte;
                }
            }
        }
	}
}
