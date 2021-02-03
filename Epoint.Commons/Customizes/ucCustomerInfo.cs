using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	public partial class ucCustomerInfo : UserControl
	{
		public ucCustomerInfo()
		{
			InitializeComponent();
			

			this.lblTen_Dvi.Text = Elements.Element.sysTen_Dvi.ToUpper();
            this.lblDia_Chi.Text = Epoint.Systems.Elements.Element.sysDia_Chi_Dv;

			string strFileLogo = Application.StartupPath + @"\Images\Logo.bin";

			if (File.Exists(strFileLogo))
			{			
				FileStream fileStream = File.OpenRead(strFileLogo);
				BinaryFormatter binaryFormatter = new BinaryFormatter();

				Image img = (Image)binaryFormatter.Deserialize(fileStream);

                //picLogo_Customer.Width = img.Width;
                //picLogo_Customer.Height = img.Height;

				picLogo_Customer.Image = img;

				lblTen_Dvi.Location = new Point(lblTen_Dvi.Left, picLogo_Customer.Bottom + 10);
				lblDia_Chi.Location = new Point(lblDia_Chi.Left, lblTen_Dvi.Bottom + 10);
				
				this.Width = Math.Max( picLogo_Customer.Right, Math.Max(lblTen_Dvi.Width, lblDia_Chi.Width)) + 20;
				
			}
			else
			{
				picLogo_Customer.Visible = false;
				lblTen_Dvi.Location = new Point(lblTen_Dvi.Location.X, lblDv_SuDung.Bottom + 10);
				lblDia_Chi.Location = new Point(lblDia_Chi.Location.X, lblTen_Dvi.Bottom + 10);

				this.Width = lblTen_Dvi.Left + Math.Max(lblTen_Dvi.Width, lblDia_Chi.Width) + 10;				
			}

			this.Height = lblDia_Chi.Location.Y + 20;
		}
        public void Load()
        {
            InitializeComponent();


            this.lblTen_Dvi.Text = Elements.Element.sysTen_Dvi.ToUpper();
            this.lblDia_Chi.Text = Epoint.Systems.Elements.Element.sysDia_Chi_Dv;

            string strFileLogo = Application.StartupPath + @"\Images\Logo.bin";

            if (File.Exists(strFileLogo))
            {
                FileStream fileStream = File.OpenRead(strFileLogo);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                Image img = (Image)binaryFormatter.Deserialize(fileStream);

                //picLogo_Customer.Width = img.Width;
                //picLogo_Customer.Height = img.Height;

                picLogo_Customer.Image = img;

                lblTen_Dvi.Location = new Point(lblTen_Dvi.Left, picLogo_Customer.Bottom + 10);
                lblDia_Chi.Location = new Point(lblDia_Chi.Left, lblTen_Dvi.Bottom + 10);

                //this.Width = Math.Max(picLogo_Customer.Right, Math.Max(lblTen_Dvi.Width, lblDia_Chi.Width)) + 20;

            }
            else
            {
                picLogo_Customer.Visible = false;
                lblTen_Dvi.Location = new Point(lblTen_Dvi.Location.X, lblDv_SuDung.Bottom + 10);
                lblDia_Chi.Location = new Point(lblDia_Chi.Location.X, lblTen_Dvi.Bottom + 10);

                this.Width = lblTen_Dvi.Left + Math.Max(lblTen_Dvi.Width, lblDia_Chi.Width) + 10;
            }

            this.Height = lblDia_Chi.Location.Y + 20;
        }
	}
}
