using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    //将nlog封装
   public class LogHelper
    {
       //想使用Nlog需要将Nlog配置文件手动复制到debug的EXE文件目录中

      //实例化Logger对象，默认logger的名称是当前类的名称（包括类所在的命名空间名称）
       public static  Logger logger = LogManager.GetCurrentClassLogger();
        
        public static void WriteLog(string info)
        {
            logger.Info(info);
        }

        public static void WriteLog(string info, Exception se)
        {          
            logger.Error( info+":"+se);
        }

        //该方法跟Nlog无关，用来写其他业务的打印结果
        public static void WriteResult(string path ,string str)
        {
            str = DateTime.Now + str;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }

    }
}
