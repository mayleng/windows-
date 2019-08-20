using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsServiceTest.AppData;


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
            string start = "程序启动了";
            LogHelper.WriteLog(start);
            Log(start);    //将字符串 string 写入文件  
            RedisTest();
        }

    


        //服务停止
        protected override void OnStop()
        {
            string stop = "程序停止了";
            string ss = "程序停止2.";
            LogHelper.WriteLog(stop);
            Log(stop);
            Log(ss);
           
        }



        //自定义方法 写入字符串到文件
        protected void Log(string str)    // 记录服务启动
        {
            string path = "c://log//log.txt";
            str = DateTime.Now + str;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
        }

        //调用 ServiceStackRedis
        public void RedisTest()
        {
            string ss = "访问RedisTest";
            Log(ss);
            Thread.Sleep(5);
            ServiceStackRedisTest redistest = new ServiceStackRedisTest();
            redistest.AddTest();
            redistest.SerachTest();
            redistest.AppendTest();
            redistest.AddOne();
            redistest.SubOne();
            redistest.DelTest();
        }


    }
}
