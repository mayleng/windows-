using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

//系统服务的程序编译完成后，不能点击运行，直接点击生成就行。
namespace WindowsServiceTest
{
    public partial class Service1 : ServiceBase
    {
        //该服务只是向一个TXT文件写入字符串
        public Service1()
        {
            InitializeComponent();
        }
        //服务启动
        protected override void OnStart(string[] args)
        {
            string start = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "程序启动了。");
            start = "service1" + start;
          //  LogHelper.WriteLog(start);
            Log(start);    //将字符串 string 写入文件
           
        }

        //服务停止
        protected override void OnStop()
        {
            string stop = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "程序停止了。");
            stop = "service1" + stop;
            //LogHelper.WriteLog(stop);
            Log(stop);
        }
    
        //自定义方法
       protected  void Log(string str)    // 记录服务启动
        {
            string path = "c://log.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }

    }
}
