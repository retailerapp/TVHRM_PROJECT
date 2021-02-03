using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
    partial class btgAccept
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btCancel = new Epoint.Systems.Customizes.btCancel();
            this.btAccept = new Epoint.Systems.Customizes.btAccept();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Image = global::Epoint.Systems.Commons.Properties.Resources.close3;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(89, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 29);
            this.btCancel.TabIndex = 1;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btAccept
            // 
            this.btAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAccept.ForeColor = System.Drawing.Color.Blue;
            this.btAccept.Image = global::Epoint.Systems.Commons.Properties.Resources.accepted1;
            this.btAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccept.Location = new System.Drawing.Point(0, 0);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(80, 29);
            this.btAccept.TabIndex = 0;
            this.btAccept.Tag = "Accept";
            this.btAccept.Text = "Đồ&ng ý";
            this.btAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAccept);
            this.Name = "btgAccept";
            this.Size = new System.Drawing.Size(171, 29);
            this.ResumeLayout(false);

        }

        #endregion

		public Epoint.Systems.Customizes.btAccept btAccept;
		public Epoint.Systems.Customizes.btCancel btCancel;
    }
}
