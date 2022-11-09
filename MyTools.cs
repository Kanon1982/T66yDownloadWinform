using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using T66yDownloadWinform.Properties;

namespace T66yDownloadWinform
{
    public class MyTools
    {
        /// <summary>
        /// 读取xml文件，返回SettingsModel对象
        /// </summary>
        /// <returns>根据xml文件生成的SettingsModel对象</returns>
        public static void get_xml_info() 
        {
            /* 注意修改以下路径 */
            /* 1.Debug 时候xml文件的配置路径 */
            /*
            DirectoryInfo rootDir = Directory.GetParent(Environment.CurrentDirectory);      // 项目路径\bin
            string root = rootDir.Parent.FullName;      // 项目根路径
            string xmlDir = root + @"\T66ySettings.xml";   // xml文件路径
            */

            /* 2.release 时候xml文件的配置路径 */
            string xmlDir = @".\T66ySettings.xml";   // xml文件路径
            Console.WriteLine(xmlDir);

            XmlDocument doc = new XmlDocument();    // 创建 xml 文档对象
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;       // 读取xml时，忽略注释内容
            //xmlFilePath:xml文件路径
            XmlReader reader = XmlReader.Create(xmlDir, readerSettings);
            doc.Load(reader);       // 加载 xml 文件


            XmlNode single_node = doc.DocumentElement.SelectSingleNode("/settings");

            XmlNodeList childs = single_node.ChildNodes;

            foreach (XmlNode child in childs)
            {
                string label_name = child.Name;         // 获取标签名称
                string label_value = child.InnerText;   // 获取值的内容
                Console.WriteLine(child.Name);
                Console.WriteLine(child.InnerText);

                switch (label_name)
                {
                    case "download_min":
                        SettingsModel.download_min = Convert.ToInt32(label_value);
                        break;
                    case "download_max":
                        SettingsModel.download_max = Convert.ToInt32(label_value);
                        break;
                    case "page_min":
                        SettingsModel.page_min = Convert.ToInt32(label_value);
                        break;
                    case "page_max":
                        SettingsModel.page_max = Convert.ToInt32(label_value);
                        break;
                    case "day_min":
                        SettingsModel.day_min = Convert.ToInt32(label_value);
                        break;
                    case "day_max":
                        SettingsModel.day_max = Convert.ToInt32(label_value);
                        break;
                    case "implicitly_time":
                        SettingsModel.implicitly_time = Convert.ToInt32(label_value);
                        break;
                    case "sleep_time":
                        SettingsModel.sleep_time = Convert.ToInt32(label_value);
                        break;
                }

            }
            // 关闭 xml 读取流
            reader.Close();
        }

    }
}
