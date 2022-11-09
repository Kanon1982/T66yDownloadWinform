namespace T66yDownloadWinform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.combo_area = new System.Windows.Forms.ComboBox();
            this.lb_area = new System.Windows.Forms.Label();
            this.cb_break_down = new System.Windows.Forms.CheckBox();
            this.lb_down_count = new System.Windows.Forms.Label();
            this.textbox_download = new System.Windows.Forms.TextBox();
            this.lb_line = new System.Windows.Forms.Label();
            this.sc_1 = new System.Windows.Forms.SplitContainer();
            this.rd_by_day = new System.Windows.Forms.RadioButton();
            this.rd_by_page = new System.Windows.Forms.RadioButton();
            this.lb_page_or_day_error = new System.Windows.Forms.Label();
            this.tb_page_or_day = new System.Windows.Forms.TextBox();
            this.lb_by_page_or_day = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settings_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_line2 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lb_download_error = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).BeginInit();
            this.sc_1.Panel1.SuspendLayout();
            this.sc_1.Panel2.SuspendLayout();
            this.sc_1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_area
            // 
            this.combo_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_area.FormattingEnabled = true;
            this.combo_area.Location = new System.Drawing.Point(143, 58);
            this.combo_area.Name = "combo_area";
            this.combo_area.Size = new System.Drawing.Size(136, 20);
            this.combo_area.TabIndex = 0;
            this.combo_area.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lb_area
            // 
            this.lb_area.AutoSize = true;
            this.lb_area.Location = new System.Drawing.Point(36, 61);
            this.lb_area.Name = "lb_area";
            this.lb_area.Size = new System.Drawing.Size(101, 12);
            this.lb_area.TabIndex = 1;
            this.lb_area.Text = "请选择种子区域：";
            this.lb_area.Click += new System.EventHandler(this.label1_Click);
            // 
            // cb_break_down
            // 
            this.cb_break_down.AutoSize = true;
            this.cb_break_down.Location = new System.Drawing.Point(38, 125);
            this.cb_break_down.Name = "cb_break_down";
            this.cb_break_down.Size = new System.Drawing.Size(120, 16);
            this.cb_break_down.TabIndex = 2;
            this.cb_break_down.Text = "是否下载破坏版？";
            this.cb_break_down.UseVisualStyleBackColor = true;
            this.cb_break_down.CheckedChanged += new System.EventHandler(this.cb_break_down_CheckedChanged);
            // 
            // lb_down_count
            // 
            this.lb_down_count.AutoSize = true;
            this.lb_down_count.Location = new System.Drawing.Point(36, 204);
            this.lb_down_count.Name = "lb_down_count";
            this.lb_down_count.Size = new System.Drawing.Size(95, 12);
            this.lb_down_count.TabIndex = 4;
            this.lb_down_count.Text = "超过多少才下载?";
            // 
            // textbox_download
            // 
            this.textbox_download.Location = new System.Drawing.Point(38, 230);
            this.textbox_download.MaxLength = 6;
            this.textbox_download.Name = "textbox_download";
            this.textbox_download.Size = new System.Drawing.Size(100, 21);
            this.textbox_download.TabIndex = 5;
            this.textbox_download.TextChanged += new System.EventHandler(this.Textbox_download_TextChanged);
            this.textbox_download.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_download_KeyPress);
            this.textbox_download.Leave += new System.EventHandler(this.textbox_download_Leave);
            // 
            // lb_line
            // 
            this.lb_line.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_line.Location = new System.Drawing.Point(300, 25);
            this.lb_line.Name = "lb_line";
            this.lb_line.Size = new System.Drawing.Size(1, 265);
            this.lb_line.TabIndex = 6;
            this.lb_line.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // sc_1
            // 
            this.sc_1.Location = new System.Drawing.Point(339, 40);
            this.sc_1.Name = "sc_1";
            // 
            // sc_1.Panel1
            // 
            this.sc_1.Panel1.Controls.Add(this.rd_by_day);
            this.sc_1.Panel1.Controls.Add(this.rd_by_page);
            // 
            // sc_1.Panel2
            // 
            this.sc_1.Panel2.Controls.Add(this.lb_page_or_day_error);
            this.sc_1.Panel2.Controls.Add(this.tb_page_or_day);
            this.sc_1.Panel2.Controls.Add(this.lb_by_page_or_day);
            this.sc_1.Size = new System.Drawing.Size(330, 233);
            this.sc_1.SplitterDistance = 135;
            this.sc_1.TabIndex = 7;
            // 
            // rd_by_day
            // 
            this.rd_by_day.AutoSize = true;
            this.rd_by_day.Location = new System.Drawing.Point(20, 113);
            this.rd_by_day.Name = "rd_by_day";
            this.rd_by_day.Size = new System.Drawing.Size(95, 16);
            this.rd_by_day.TabIndex = 1;
            this.rd_by_day.Text = "根据天数下载";
            this.rd_by_day.UseVisualStyleBackColor = true;
            this.rd_by_day.CheckedChanged += new System.EventHandler(this.rd_by_day_CheckedChanged);
            // 
            // rd_by_page
            // 
            this.rd_by_page.AutoSize = true;
            this.rd_by_page.Location = new System.Drawing.Point(20, 71);
            this.rd_by_page.Name = "rd_by_page";
            this.rd_by_page.Size = new System.Drawing.Size(95, 16);
            this.rd_by_page.TabIndex = 0;
            this.rd_by_page.Text = "根据页数下载";
            this.rd_by_page.UseVisualStyleBackColor = true;
            this.rd_by_page.CheckedChanged += new System.EventHandler(this.rd_by_page_CheckedChanged);
            // 
            // lb_page_or_day_error
            // 
            this.lb_page_or_day_error.AutoSize = true;
            this.lb_page_or_day_error.ForeColor = System.Drawing.Color.Red;
            this.lb_page_or_day_error.Location = new System.Drawing.Point(46, 141);
            this.lb_page_or_day_error.Name = "lb_page_or_day_error";
            this.lb_page_or_day_error.Size = new System.Drawing.Size(89, 12);
            this.lb_page_or_day_error.TabIndex = 2;
            this.lb_page_or_day_error.Text = "输入内容不合法";
            this.lb_page_or_day_error.Visible = false;
            // 
            // tb_page_or_day
            // 
            this.tb_page_or_day.Location = new System.Drawing.Point(39, 108);
            this.tb_page_or_day.MaxLength = 6;
            this.tb_page_or_day.Name = "tb_page_or_day";
            this.tb_page_or_day.Size = new System.Drawing.Size(100, 21);
            this.tb_page_or_day.TabIndex = 1;
            this.tb_page_or_day.TextChanged += new System.EventHandler(this.tb_page_or_day_TextChanged);
            this.tb_page_or_day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_page_or_day_KeyPress);
            this.tb_page_or_day.Leave += new System.EventHandler(this.tb_page_or_day_Leave);
            // 
            // lb_by_page_or_day
            // 
            this.lb_by_page_or_day.AutoSize = true;
            this.lb_by_page_or_day.Location = new System.Drawing.Point(23, 75);
            this.lb_by_page_or_day.Name = "lb_by_page_or_day";
            this.lb_by_page_or_day.Size = new System.Drawing.Size(89, 12);
            this.lb_by_page_or_day.TabIndex = 0;
            this.lb_by_page_or_day.Text = "下载前多少页？";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settings_menu
            // 
            this.settings_menu.Name = "settings_menu";
            this.settings_menu.Size = new System.Drawing.Size(92, 21);
            this.settings_menu.Text = "打开配置文件";
            this.settings_menu.Click += new System.EventHandler(this.settings_menu_Click);
            // 
            // lb_line2
            // 
            this.lb_line2.BackColor = System.Drawing.Color.Black;
            this.lb_line2.Location = new System.Drawing.Point(-2, 290);
            this.lb_line2.Name = "lb_line2";
            this.lb_line2.Size = new System.Drawing.Size(704, 1);
            this.lb_line2.TabIndex = 14;
            this.lb_line2.Text = "1";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(116, 308);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 15;
            this.btn_reset.Text = "重置";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lb_download_error
            // 
            this.lb_download_error.AutoSize = true;
            this.lb_download_error.ForeColor = System.Drawing.Color.Red;
            this.lb_download_error.Location = new System.Drawing.Point(144, 233);
            this.lb_download_error.Name = "lb_download_error";
            this.lb_download_error.Size = new System.Drawing.Size(89, 12);
            this.lb_download_error.TabIndex = 16;
            this.lb_download_error.Text = "输入内容不合法";
            this.lb_download_error.Visible = false;
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(473, 308);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 17;
            this.btn_download.Text = "开始运行";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 348);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.lb_download_error);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lb_line2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.sc_1);
            this.Controls.Add(this.lb_line);
            this.Controls.Add(this.textbox_download);
            this.Controls.Add(this.lb_down_count);
            this.Controls.Add(this.cb_break_down);
            this.Controls.Add(this.lb_area);
            this.Controls.Add(this.combo_area);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(718, 387);
            this.Name = "Form1";
            this.Text = "T66yDownloadWinform";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sc_1.Panel1.ResumeLayout(false);
            this.sc_1.Panel1.PerformLayout();
            this.sc_1.Panel2.ResumeLayout(false);
            this.sc_1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_1)).EndInit();
            this.sc_1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_area;
        private System.Windows.Forms.Label lb_area;
        private System.Windows.Forms.CheckBox cb_break_down;
        private System.Windows.Forms.Label lb_down_count;
        private System.Windows.Forms.TextBox textbox_download;
        private System.Windows.Forms.Label lb_line;
        private System.Windows.Forms.SplitContainer sc_1;
        private System.Windows.Forms.RadioButton rd_by_day;
        private System.Windows.Forms.RadioButton rd_by_page;
        private System.Windows.Forms.Label lb_by_page_or_day;
        private System.Windows.Forms.TextBox tb_page_or_day;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settings_menu;
        private System.Windows.Forms.Label lb_line2;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lb_download_error;
        private System.Windows.Forms.Label lb_page_or_day_error;
        private System.Windows.Forms.Button btn_download;
    }
}

