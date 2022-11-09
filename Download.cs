using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Firefox;
using System.Collections;
using System.Security.Principal;
using System.Collections.ObjectModel;

namespace T66yDownloadWinform
{
    class Download
    {
        IWebDriver driver = null;   // 声明一个浏览器webdriver引用

        public Download()
        {
            // 打开主窗体后，立即 读取xml文件
            MyTools.get_xml_info();
        }

        /// <summary>
        /// 创建驱动对象方法
        /// </summary>
        /// <returns>返回驱动对象</returns>
        public IWebDriver getDriver()
        {
            if (driver != null)         // 如果驱动不为null，关闭驱动
            {
                this.closeDriver();
            }
            driver = new ChromeDriver();    // 新建驱动
            return driver;
        }

        /// <summary>
        /// 关闭驱动
        /// </summary>
        /// <returns>-1:退出异常; 0:正常退出</returns>
        public int closeDriver()
        {
            try
            {
                this.driver.Quit();     // 关闭浏览器所有窗口
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;      // 正常退出失败，返回-1
            }
            return 0;   // 正常退出，返回0

        }

        /// <summary>
        /// 进入 具体区域 的方法
        /// </summary>
        /// <param name="area_str">区域名称(字符串)</param>
        public void go_to_area_func(string area_str) 
        {
            driver.Navigate().GoToUrl("https://t66y.com/index.php");    // 进入 草榴首页

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待

            //Thread.Sleep(3000);     // 等待3秒，等待主页打开

            int choice = 1;     // 声明默认区域为1

            switch (area_str)
            {
                case "亚洲无码":
                    choice = 1;
                    break;
                case "亚洲有码":
                    choice = 2;
                    break;
                case "欧美原创":
                    choice = 3;
                    break;
                case "动漫原创":
                    choice = 4;
                    break;
                case "国产原创":
                    choice = 5;
                    break;
                case "中字原创(中文字幕)":
                    choice = 6;
                    break;
            }

            // 进入 具体的某一区域
            driver.FindElement(By.CssSelector("#cate_1 tr:nth-child(" + choice + ") th h2 a")).Click();
        }


        /// <summary>
        /// 根据页数下载bt种子方法
        /// </summary>
        /// <param name="download_input">下载量超过多少才下载</param>
        /// <param name="down_break">是否下载破坏版</param>
        /// <param name="download_pages">下载前多少页</param>
        public void download_by_page_func(int download_input, bool down_break, int download_pages) 
        {
            int page_now = 1;       // 当前页数

            while (page_now <= download_pages) 
            {
                download_1_page_func(download_input, down_break);       // 执行下载当前一整页函数

                // 获取当前页码，并下一页
                page_now++;
                IWebElement page_input = driver.FindElement(By.CssSelector("a[class=\"w70\"] input"));
                page_input.Click();
                page_input.Clear();
                page_input.SendKeys(page_now.ToString());
                page_input.SendKeys(Keys.Enter);
                Thread.Sleep(SettingsModel.sleep_time);
            }
        }

        /// <summary>
        /// 下载一整页的bt种子函数
        /// </summary>
        /// <param name="download_input">下载量超过多少才下载</param>
        /// <param name="down_break">是否下载破坏版</param>
        public void download_1_page_func(int download_input, bool down_break) 
        {
            // 注意：这两个等待不可以删除，否则页面有可能加载不出来
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
            Thread.Sleep(SettingsModel.sleep_time);     // 强制等待

            // 返回 下载量 的td元素集合
            IReadOnlyCollection<IWebElement> down_td_s = driver.FindElements(By.CssSelector("#tbody tr td:nth-child(5)"));

            int tr_num = 1;     // 行号
            ArrayList tr_num_list = new ArrayList();        // 创建 行号 的可变数组

            foreach (IWebElement down_td in down_td_s)
            {
                if (down_td.Text.Equals("--"))
                {
                    continue;
                }
                int down_count = int.Parse(down_td.Text);   // 获取当前种子下载量
                if (down_count >= download_input)
                {
                    IWebElement down_tr = down_td.FindElement(By.XPath(".."));      // 获取该行的tr元素
                    IWebElement bt_title_tag = down_tr.FindElement(By.XPath("./td[2]/h3/a"));   // 获取种子title的a标签

                    // 看标题a标签中是否包含"破解"或"破坏"或"破壊" 并且 是否设置过下载破解版，有则跳过该行，无则点击
                    if ((!down_break) && (
                        bt_title_tag.Text.Contains("破解")
                        || bt_title_tag.Text.Contains("破坏")
                        || bt_title_tag.Text.Contains("破壊")
                        ))
                    {
                        continue;
                    }
                    else
                    {
                        bt_title_tag.Click();
                    }

                    // 获取浏览器中所有标签页的句柄
                    System.Collections.ObjectModel.ReadOnlyCollection<string> windows = driver.WindowHandles;
                    Console.WriteLine(windows.Count);
                    driver.SwitchTo().Window(windows[windows.Count - 1]);

                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                        Thread.Sleep(SettingsModel.sleep_time);
                        driver.FindElement(By.CssSelector("a[href*=\"rmdown.com/link.php?hash=\"]")).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                        Thread.Sleep(SettingsModel.sleep_time);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("报错：" + e.Message);
                        windows = driver.WindowHandles;
                        driver.Close();
                        driver.SwitchTo().Window(windows[0]);
                        continue;
                    }
                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[windows.Count - 1]);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                    Thread.Sleep(SettingsModel.sleep_time);
                    driver.FindElement(By.CssSelector("button[title=\"Download file\"]")).Click();
                    driver.Close();

                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[windows.Count - 1]);
                    driver.Close();

                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[0]);

                    tr_num_list.Add(tr_num);
                    Console.WriteLine(tr_num + "-----------" + down_count);

                }
                tr_num++;
            }

        }

        /// <summary>
        /// 下载前？天的种子 函数
        /// </summary>
        /// <param name="download_input">下载量高于多少？</param>
        /// <param name="down_break">是否下载破坏版？</param>
        /// <param name="download_days">下载前多少天？</param>
        public void download_by_days_func(int download_input, bool down_break, int download_days) 
        {
            ArrayList days_list = get_days_list(download_days);     // 得到日期的list列表

            int page_num = 1;   // 目前的页数是多少？

            while (true)
            {
                bool keep_next_page = download_by_days_1_page(download_input, down_break, days_list);

                IWebElement page_input = driver.FindElement(By.CssSelector("a[class=\"w70\"] input"));
                page_num++;
                page_input.Click();
                page_input.Clear();
                page_input.SendKeys(page_num.ToString());
                page_input.SendKeys(Keys.Enter);

                Thread.Sleep(SettingsModel.sleep_time);     

                if (!keep_next_page)
                {
                    break;
                }
            }


        }


        /// <summary>
        /// 根据下载前多少天，返回日期str的ArrayList
        /// </summary>
        /// <param name="download_days">下载前多少天？</param>
        /// <returns>日期str的ArrrayList</returns>
        public ArrayList get_days_list(int download_days)
        {
            ArrayList days_list = new ArrayList();  // 声明 日期str的ArrayList

            if (download_days >= 1)
            {
                days_list.Add("今天");
            }
            if (download_days >= 2)
            {
                days_list.Add("昨天");
            }
            if (download_days >= 3)
            {
                int day_flag = -2;
                //string a = DateTime.Now.AddDays(day_flag).ToString("yyyy-MM-dd");
                //Console.WriteLine(a);

                while (-day_flag + 1 <= download_days)
                {
                    // 新建 前天 以及 前天之前 的日期字符串
                    string day_now_temp = DateTime.Now.AddDays(day_flag).ToString("yyyy-MM-dd");
                    // 将 日期字符串 添加到ArrayList中
                    days_list.Add(day_now_temp);
                    day_flag--;
                }

            }

            foreach (string day_str in days_list)
            {
                Console.WriteLine(day_str);
            }

            return days_list;
        }

        /// <summary>
        /// 根据天数下载 本页 中 符合标准的
        /// </summary>
        /// <param name="download_input"></param>
        /// <param name="down_break"></param>
        /// <param name="days_list"></param>
        /// <returns></returns>
        public bool download_by_days_1_page(int download_input, bool down_break, ArrayList days_list) 
        {
            bool keep_next_page = false;    // 是否继续下一页？ 默认为False

            // 获取最后一行的日期span元素
            IWebElement last_tr_span = driver.FindElement(By.CssSelector("#tbody > tr:last-child td:nth-child(3) div span"));
            Console.WriteLine(last_tr_span.Text);       // 打印该页最后一行的发布日期

            // 查看本页最后一行的日期，是否需要翻页
            foreach (string day_str in days_list)
            {
                // 如果最后一行日期是要下载的日期，则在执行完该页下载之后，翻页
                if (last_tr_span.Text.Contains(day_str))
                {
                    keep_next_page = true;  
                }
            }

            // 等待页面加载完成，下面两行等待不可以删除~~
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
            Thread.Sleep(SettingsModel.sleep_time);

            // 获取每一行的tr
            IReadOnlyCollection<IWebElement> down_tr_s = driver.FindElements(By.CssSelector("#tbody tr"));

            bool is_next_tr = true;     // 是否下一行？

            int tr_num = 1;     // 行号计数器，用于下面的for循环

            foreach (IWebElement down_tr in down_tr_s)
            {
                IWebElement down_num_td = down_tr.FindElement(By.XPath("./td[5]"));             // 获取下载量td元素
                IWebElement bt_title_tag = down_tr.FindElement(By.XPath("./td[2]/h3/a"));       // 获取种子title的a标签
                IWebElement bt_day_tag = down_tr.FindElement(By.XPath("./td[3]/div/span"));     // 获取种子日期标签

                if (down_num_td.Text.Equals("--"))      // 如果没有下载量，跳过该次循环
                {
                    tr_num++;
                    continue;
                }

                // 看标题a标签中是否包含"破解"或"破坏"或"破壊" 并且 是否设置过下载破解版，有则跳过该行，无则点击
                if ((!down_break) && (
                    bt_title_tag.Text.Contains("破解")
                    || bt_title_tag.Text.Contains("破坏")
                    || bt_title_tag.Text.Contains("破壊")
                    ))
                {
                    tr_num++;
                    continue;
                }

                int down_num = int.Parse(down_num_td.Text);     // 将str的下载量转换为int类型
                if (down_num < download_input)                  // 如果下载量低于标准，则跳过该次循环
                {
                    tr_num++;
                    continue;
                }

                bool is_include_the_day = false;    // 当前种子的日期是否被包含在日期列表中
                foreach (string day_str in days_list) 
                {
                    if (bt_day_tag.Text.Contains(day_str))  // 如果该行tr符合要查找的日期
                    {
                        is_include_the_day=true;
                        tr_num++;
                        break;
                    }
                }
                
                if (!is_include_the_day)        // 如果改行tr没有在日期列表中
                {
                    tr_num++;
                }
                else
                {
                    // 显示bt种子的详细信息
                    Console.WriteLine("down_num_td" + down_num_td.Text);
                    Console.WriteLine("bt_title_tag" + bt_title_tag.Text);
                    Console.WriteLine("bt_day_tag" + bt_day_tag.Text);

                    bt_title_tag.Click();       // 进入种子介绍详情页

                    // 获取浏览器中所有标签页的句柄
                    System.Collections.ObjectModel.ReadOnlyCollection<string> windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[windows.Count - 1]);

                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                        Thread.Sleep(SettingsModel.sleep_time);     // 强制等待

                        // 点击页面中 第1个 种子的下载链接(如果有多个的话)
                        IReadOnlyCollection<IWebElement> click_ele_s = driver.FindElements(By.CssSelector("a[href*=\"rmdown.com/link.php?hash=\"]"));
                        click_ele_s.First().Click();

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                        Thread.Sleep(SettingsModel.sleep_time);     // 强制等待



                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        windows = driver.WindowHandles;
                        driver.Close();
                        driver.SwitchTo().Window(windows[0]);
                        continue;
                    }
                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[windows.Count - 1]);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsModel.implicitly_time);     // 隐式等待
                    Thread.Sleep(SettingsModel.sleep_time);     // 强制等待
                    driver.FindElement(By.CssSelector("button[title=\"Download file\"]")).Click();
                    driver.Close();

                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[windows.Count - 1]);
                    driver.Close();

                    windows = driver.WindowHandles;
                    driver.SwitchTo().Window(windows[0]);

                    Console.WriteLine(tr_num + "--------" + down_num_td.Text);
                }
            }

            return keep_next_page;
        }



        
    }
}
