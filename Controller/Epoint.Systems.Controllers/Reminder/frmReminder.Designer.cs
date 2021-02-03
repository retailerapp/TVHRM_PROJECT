namespace Epoint.Controllers
{
	partial class frmReminder
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReminder));
            this.tabReminder = new Epoint.Systems.Controls.tabControl();
            this.tabBirthDay = new System.Windows.Forms.TabPage();
            this.dgvBirthDay = new Epoint.Systems.Controls.dgvControl();
            this.tabReminder_HanThu = new System.Windows.Forms.TabPage();
            this.dgvReminder_HanThu = new Epoint.Systems.Controls.dgvControl();
            this.tabReminder_HanTra = new System.Windows.Forms.TabPage();
            this.dgvReminder_HanTra = new Epoint.Systems.Controls.dgvControl();
            this.tabReminder_TrangThaiCt = new System.Windows.Forms.TabPage();
            this.dgvReminder_TrangThaiCt = new Epoint.Systems.Controls.dgvControl();
            this.btRefresh = new Epoint.Systems.Controls.btControl();
            this.lvReminder = new System.Windows.Forms.ListView();
            this.btnSendMail = new Epoint.Systems.Controls.btControl();
            this.tabReminder.SuspendLayout();
            this.tabBirthDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthDay)).BeginInit();
            this.tabReminder_HanThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_HanThu)).BeginInit();
            this.tabReminder_HanTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_HanTra)).BeginInit();
            this.tabReminder_TrangThaiCt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_TrangThaiCt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReminder
            // 
            this.tabReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReminder.Controls.Add(this.tabBirthDay);
            this.tabReminder.Controls.Add(this.tabReminder_HanThu);
            this.tabReminder.Controls.Add(this.tabReminder_HanTra);
            this.tabReminder.Controls.Add(this.tabReminder_TrangThaiCt);
            this.tabReminder.Location = new System.Drawing.Point(1, 3);
            this.tabReminder.Name = "tabReminder";
            this.tabReminder.SelectedIndex = 0;
            this.tabReminder.Size = new System.Drawing.Size(786, 517);
            this.tabReminder.TabIndex = 0;
            // 
            // tabBirthDay
            // 
            this.tabBirthDay.Controls.Add(this.dgvBirthDay);
            this.tabBirthDay.Location = new System.Drawing.Point(4, 22);
            this.tabBirthDay.Name = "tabBirthDay";
            this.tabBirthDay.Size = new System.Drawing.Size(778, 491);
            this.tabBirthDay.TabIndex = 3;
            this.tabBirthDay.Text = "Danh sách nhân viên sinh nhật";
            this.tabBirthDay.UseVisualStyleBackColor = true;
            // 
            // dgvBirthDay
            // 
            this.dgvBirthDay.AllowUserToAddRows = false;
            this.dgvBirthDay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBirthDay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBirthDay.BackgroundColor = System.Drawing.Color.White;
            this.dgvBirthDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBirthDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBirthDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBirthDay.EnableHeadersVisualStyles = false;
            this.dgvBirthDay.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBirthDay.Location = new System.Drawing.Point(0, 0);
            this.dgvBirthDay.MultiSelect = false;
            this.dgvBirthDay.Name = "dgvBirthDay";
            this.dgvBirthDay.ReadOnly = true;
            this.dgvBirthDay.Size = new System.Drawing.Size(778, 491);
            this.dgvBirthDay.strZone = "";
            this.dgvBirthDay.TabIndex = 1;
            // 
            // tabReminder_HanThu
            // 
            this.tabReminder_HanThu.Controls.Add(this.dgvReminder_HanThu);
            this.tabReminder_HanThu.Location = new System.Drawing.Point(4, 22);
            this.tabReminder_HanThu.Name = "tabReminder_HanThu";
            this.tabReminder_HanThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabReminder_HanThu.Size = new System.Drawing.Size(778, 491);
            this.tabReminder_HanThu.TabIndex = 0;
            this.tabReminder_HanThu.Tag = "Reminder_HanThu";
            this.tabReminder_HanThu.Text = "Chứng từ đến hạn thu";
            this.tabReminder_HanThu.UseVisualStyleBackColor = true;
            // 
            // dgvReminder_HanThu
            // 
            this.dgvReminder_HanThu.AllowUserToAddRows = false;
            this.dgvReminder_HanThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReminder_HanThu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReminder_HanThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvReminder_HanThu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReminder_HanThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReminder_HanThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReminder_HanThu.EnableHeadersVisualStyles = false;
            this.dgvReminder_HanThu.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReminder_HanThu.Location = new System.Drawing.Point(3, 3);
            this.dgvReminder_HanThu.MultiSelect = false;
            this.dgvReminder_HanThu.Name = "dgvReminder_HanThu";
            this.dgvReminder_HanThu.ReadOnly = true;
            this.dgvReminder_HanThu.Size = new System.Drawing.Size(772, 485);
            this.dgvReminder_HanThu.strZone = "";
            this.dgvReminder_HanThu.TabIndex = 0;
            // 
            // tabReminder_HanTra
            // 
            this.tabReminder_HanTra.Controls.Add(this.dgvReminder_HanTra);
            this.tabReminder_HanTra.Location = new System.Drawing.Point(4, 22);
            this.tabReminder_HanTra.Name = "tabReminder_HanTra";
            this.tabReminder_HanTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabReminder_HanTra.Size = new System.Drawing.Size(778, 491);
            this.tabReminder_HanTra.TabIndex = 2;
            this.tabReminder_HanTra.Tag = "Reminder_HanTra";
            this.tabReminder_HanTra.Text = "Chứng từ đến hạn trả";
            this.tabReminder_HanTra.UseVisualStyleBackColor = true;
            // 
            // dgvReminder_HanTra
            // 
            this.dgvReminder_HanTra.AllowUserToAddRows = false;
            this.dgvReminder_HanTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReminder_HanTra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReminder_HanTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvReminder_HanTra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReminder_HanTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReminder_HanTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReminder_HanTra.EnableHeadersVisualStyles = false;
            this.dgvReminder_HanTra.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReminder_HanTra.Location = new System.Drawing.Point(3, 3);
            this.dgvReminder_HanTra.MultiSelect = false;
            this.dgvReminder_HanTra.Name = "dgvReminder_HanTra";
            this.dgvReminder_HanTra.ReadOnly = true;
            this.dgvReminder_HanTra.Size = new System.Drawing.Size(772, 485);
            this.dgvReminder_HanTra.strZone = "";
            this.dgvReminder_HanTra.TabIndex = 1;
            // 
            // tabReminder_TrangThaiCt
            // 
            this.tabReminder_TrangThaiCt.Controls.Add(this.dgvReminder_TrangThaiCt);
            this.tabReminder_TrangThaiCt.Location = new System.Drawing.Point(4, 22);
            this.tabReminder_TrangThaiCt.Name = "tabReminder_TrangThaiCt";
            this.tabReminder_TrangThaiCt.Padding = new System.Windows.Forms.Padding(3);
            this.tabReminder_TrangThaiCt.Size = new System.Drawing.Size(778, 491);
            this.tabReminder_TrangThaiCt.TabIndex = 1;
            this.tabReminder_TrangThaiCt.Tag = "Reminder_TrangThaiCt";
            this.tabReminder_TrangThaiCt.Text = "Trạng thái chứng từ";
            this.tabReminder_TrangThaiCt.UseVisualStyleBackColor = true;
            // 
            // dgvReminder_TrangThaiCt
            // 
            this.dgvReminder_TrangThaiCt.AllowUserToAddRows = false;
            this.dgvReminder_TrangThaiCt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReminder_TrangThaiCt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReminder_TrangThaiCt.BackgroundColor = System.Drawing.Color.White;
            this.dgvReminder_TrangThaiCt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReminder_TrangThaiCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReminder_TrangThaiCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReminder_TrangThaiCt.EnableHeadersVisualStyles = false;
            this.dgvReminder_TrangThaiCt.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReminder_TrangThaiCt.Location = new System.Drawing.Point(3, 3);
            this.dgvReminder_TrangThaiCt.MultiSelect = false;
            this.dgvReminder_TrangThaiCt.Name = "dgvReminder_TrangThaiCt";
            this.dgvReminder_TrangThaiCt.ReadOnly = true;
            this.dgvReminder_TrangThaiCt.Size = new System.Drawing.Size(772, 485);
            this.dgvReminder_TrangThaiCt.strZone = "";
            this.dgvReminder_TrangThaiCt.TabIndex = 1;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.Location = new System.Drawing.Point(18, 521);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(72, 43);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "&Refresh";
            this.btRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // lvReminder
            // 
            this.lvReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvReminder.Location = new System.Drawing.Point(483, 535);
            this.lvReminder.Name = "lvReminder";
            this.lvReminder.Size = new System.Drawing.Size(303, 22);
            this.lvReminder.TabIndex = 1;
            this.lvReminder.UseCompatibleStateImageBehavior = false;
            this.lvReminder.View = System.Windows.Forms.View.List;
            this.lvReminder.Visible = false;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.Blue;
            this.btnSendMail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMail.Image")));
            this.btnSendMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMail.Location = new System.Drawing.Point(332, 522);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(128, 42);
            this.btnSendMail.TabIndex = 7;
            this.btnSendMail.Tag = "Send_Mail";
            this.btnSendMail.Text = "Gửi Email";
            this.btnSendMail.UseVisualStyleBackColor = true;
            // 
            // frmReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.lvReminder);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.tabReminder);
            this.Name = "frmReminder";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmReminder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabReminder.ResumeLayout(false);
            this.tabBirthDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthDay)).EndInit();
            this.tabReminder_HanThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_HanThu)).EndInit();
            this.tabReminder_HanTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_HanTra)).EndInit();
            this.tabReminder_TrangThaiCt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminder_TrangThaiCt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.tabControl tabReminder;
		private System.Windows.Forms.TabPage tabReminder_HanThu;
		private System.Windows.Forms.TabPage tabReminder_HanTra;
        private System.Windows.Forms.TabPage tabReminder_TrangThaiCt;
        private Epoint.Systems.Controls.btControl btRefresh;
		private Epoint.Systems.Controls.dgvControl dgvReminder_HanThu;
		private Epoint.Systems.Controls.dgvControl dgvReminder_HanTra;
        private Epoint.Systems.Controls.dgvControl dgvReminder_TrangThaiCt;
        private System.Windows.Forms.ListView lvReminder;
        private System.Windows.Forms.TabPage tabBirthDay;
        private Systems.Controls.dgvControl dgvBirthDay;
        private Systems.Controls.btControl btnSendMail;
	}
}