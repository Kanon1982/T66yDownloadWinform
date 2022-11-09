using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T66yDownloadWinform
{
    public partial class Form1 : Form
    {
        // 声明一个 Download 引用
        Download down = null;

        /// <summary>
        /// 主窗体 构造方法
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 给 down 引用创建 对象
            down = new Download();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_break_down_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下载量textbox 文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textbox_download_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tmp_num = int.Parse(textbox_download.Text);     // 将文本框中内容转换成int类型
                                                                  // 如果数值 过大 或者 过小，将值修改为 默认最小值
                if (tmp_num > SettingsModel.download_max || tmp_num < SettingsModel.download_min)
                {
                    lb_download_error.Visible = true;
                }
                else
                {
                    lb_download_error.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Form1窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 给区域combobox添加item
            combo_area.Items.Add("亚洲无码");
            combo_area.Items.Add("亚洲有码");
            combo_area.Items.Add("欧美原创");
            combo_area.Items.Add("动漫原创");
            combo_area.Items.Add("国产原创");
            combo_area.Items.Add("中字原创(中文字幕)");
            // 给区域combobox默认值修改为第一个
            combo_area.SelectedIndex = 0;

            // 将下载量的提示label修改
            lb_down_count.Text = $"超过多少才下载?(取值为{SettingsModel.download_min}-{SettingsModel.download_max}之间)";
            // 将下载量的textbox修改默认值为 最小默认值
            textbox_download.Text = SettingsModel.download_min.ToString();

            // 将根据 页数 下载的 radio 激活
            rd_by_page.Checked = true;
        }

        /// <summary>
        /// 下载量输入框，按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_download_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 下载量textbox 离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_download_Leave(object sender, EventArgs e)
        {
            try
            {
                int tmp_num = int.Parse(textbox_download.Text);     // 将文本框中内容转换成int类型
                // 如果数值 过大 或者 过小，将值修改为 默认最小值
                if (tmp_num > SettingsModel.download_max || tmp_num < SettingsModel.download_min)
                {
                    textbox_download.Text = SettingsModel.download_min.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // 如果输入内容无法转换成int类型，则修改为 默认最小值
                textbox_download.Text = SettingsModel.download_min.ToString();
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 每当 根据页数下载按钮 改变 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rd_by_page_CheckedChanged(object sender, EventArgs e)
        {
            // 如果 根据页数下载 radio 被激活，右侧label改成 下载前多少页
            if (rd_by_page.Checked)
            {
                lb_by_page_or_day.Text = "下载前多少页？(" + SettingsModel.page_min + "-" + SettingsModel.page_max + ")之间";
                tb_page_or_day.Text = SettingsModel.page_min.ToString();
            }
        }

        /// <summary>
        /// 每当 根据页数下载按钮 改变 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rd_by_day_CheckedChanged(object sender, EventArgs e)
        {
            // 如果 根据天数下载 radio 被激活，右侧label改成 下载前多少天
            if (rd_by_day.Checked)
            {
                lb_by_page_or_day.Text = "下载前多少天？(" + SettingsModel.day_min + "-" + SettingsModel.day_max + ")之间";
                tb_page_or_day.Text = SettingsModel.day_min.ToString();
            }
        }

        /// <summary>
        /// 输入 页数 or 天数 输入框的 内容修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_page_or_day_TextChanged(object sender, EventArgs e)
        {
            // 如果 根据页数下载radio 激活
            if (rd_by_page.Checked)     
            {
                try
                {
                    int tmp_num = int.Parse(tb_page_or_day.Text);     // 将文本框中内容转换成int类型
                                                                        // 如果数值 过大 或者 过小，将值修改为 默认最小值
                    if (tmp_num > SettingsModel.page_max || tmp_num < SettingsModel.page_min)
                    {
                        lb_page_or_day_error.Visible = true;
                    }
                    else
                    {
                        lb_page_or_day_error.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // 如果 根据天数下载radio 激活
            if (rd_by_day.Checked)
            {
                try
                {
                    int tmp_num = int.Parse(tb_page_or_day.Text);     // 将文本框中内容转换成int类型
                                                                      // 如果数值 过大 或者 过小，将值修改为 默认最小值
                    if (tmp_num > SettingsModel.day_max || tmp_num < SettingsModel.day_min)
                    {
                        lb_page_or_day_error.Visible = true;
                    }
                    else
                    {
                        lb_page_or_day_error.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 每当根据 页数or天数下载的 textbox输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_page_or_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void tb_page_or_day_Leave(object sender, EventArgs e)
        {
            // 如果 根据页数radio 激活
            if (rd_by_page.Checked)
            {
                try
                {
                    int tmp_num = int.Parse(tb_page_or_day.Text);     // 将文本框中内容转换成int类型
                                                                        // 如果数值 过大 或者 过小，将值修改为 默认最小值
                    if (tmp_num > SettingsModel.page_max || tmp_num < SettingsModel.page_min)
                    {
                        tb_page_or_day.Text = SettingsModel.page_min.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // 如果输入内容无法转换成int类型，则修改为 默认最小值
                    tb_page_or_day.Text = SettingsModel.page_min.ToString();
                }
            }

            // 如果 根据天数radio 激活
            if (rd_by_day.Checked)
            {
                try
                {
                    int tmp_num = int.Parse(tb_page_or_day.Text);     // 将文本框中内容转换成int类型
                                                                      // 如果数值 过大 或者 过小，将值修改为 默认最小值
                    if (tmp_num > SettingsModel.day_max || tmp_num < SettingsModel.day_min)
                    {
                        tb_page_or_day.Text = SettingsModel.day_min.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // 如果输入内容无法转换成int类型，则修改为 默认最小值
                    tb_page_or_day.Text = SettingsModel.day_min.ToString();
                }
            }

        }

        /// <summary>
        /// 配置按钮 点击 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settings_menu_Click(object sender, EventArgs e)
        {
            // 打开xml配置文件
            DirectoryInfo rootDir = Directory.GetParent(Environment.CurrentDirectory);      // 项目路径\bin
            string root = rootDir.Parent.FullName;      // 项目根路径
            string xmlDir = root + @"\T66ySettings.xml";   // xml文件路径
            System.Diagnostics.Process.Start("explorer", "/n, " + xmlDir);

            // 提示 修改完配置文件，应重启软件
            MessageBox.Show("修改并保存xml配置文件后，必须重启软件，修改才会应用到软件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 重置 按钮 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            // 给区域combobox默认值修改为第一个
            combo_area.SelectedIndex = 0;

            // 将下载量的textbox修改默认值为 最小默认值
            textbox_download.Text = SettingsModel.download_min.ToString();

            // 将根据 页数 下载的 radio 激活
            rd_by_page.Checked = true;

            // 下载文本框设置为 最小值
            textbox_download.Text = SettingsModel.download_min.ToString();

            // 修改右侧 下载页数 和 提示label
            lb_by_page_or_day.Text = "下载前多少页？(" + SettingsModel.page_min + "-" + SettingsModel.page_max + ")之间";
            tb_page_or_day.Text = SettingsModel.page_min.ToString();

            // 是否下载破坏版 checkbox 取消勾选
            cb_break_down.Checked = false;
        }

        /// <summary>
        /// 单击 "开始运行" 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_download_Click(object sender, EventArgs e)
        {
            
            string area_str = combo_area.Text;                          // 获取 区域文本
            bool down_break = cb_break_down.Checked;                    // 获取 是否下载破坏版
            int download_input = int.Parse(textbox_download.Text);      // 获取 下载量

            int download_pages = int.Parse(tb_page_or_day.Text);        // 获取 下载的页数
            int download_days = int.Parse(tb_page_or_day.Text);         // 获取 下载的天数

            IWebDriver drvier = null;   // 声明一个WebDriver引用，用于finally中关闭

            try
            {
                drvier = down.getDriver();          // 给Download对象 创建一个web driver对象

                down.go_to_area_func(area_str);     // 从 主页 进入 具体区域

                // 如果 根据页数radio 激活
                if (rd_by_page.Checked)
                {

                    down.download_by_page_func(download_input, down_break, download_pages);
                }

                // 如果 根据天数radio 激活
                if (rd_by_day.Checked)
                {
                    down.download_by_days_func(download_input, down_break, download_days);
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
            finally
            {
                down.closeDriver();     // 关闭webdriver驱动，防止后台偷偷运行
            }
        }
    }
}
