using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T66yDownloadWinform
{
    public class SettingsModel 
    {
        // 最小和最大访问量
        public static int download_min = 200;
        public static int download_max = 10000;

        // 最少和最多下载页数
        public static int page_min = 1;
        public static int page_max = 30;

        // 最少和最多下载天数
        public static int day_min = 1;
        public static int day_max = 15;

        // 注意：等待时长不可以太小，否则会被网站发现是在爬虫，导致报错
            // 隐式等待时长，秒
        public static int implicitly_time = 13;
            // 强制等待时长，毫秒
        public static int sleep_time = 3000;

    }
}
