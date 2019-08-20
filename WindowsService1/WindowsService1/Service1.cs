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

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "service.log";
            var context = "MyWindowsService: Service Starting " + DateTime.Now + "\r\n";
            WriteLogs(path, context);
            int threadNums = 10;
            Thread.Sleep(10000);
            Thread[] threads = new Thread[threadNums];
            for(var i = 0; i < threadNums; i++)
            {
                threads[i] = new Thread(workWaper);
                
                threads[i].Start(i);
            }
        }

        protected void workWaper(object data)
        {
            while (true)
            {
                work((int)data);
            }
        }

        public void work(int index)
        {
            Thread.Sleep(30000);
            var path = AppDomain.CurrentDomain.BaseDirectory + "service.log";
            var context = "MyWindowsService: Service running " + index+ " "  + DateTime.Now + "\r\n";
            WriteLogs(path, context);
        }

        public void WriteLogs(string path, string context)
        {
            try
            {           
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            var sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(context);

            sw.Flush();
            sw.Close();
            fs.Close();
            } catch(Exception ex)
            {

            }
        }
        protected override void OnStop()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "service.log";
            var context = "MyWindowsService: Service Stoped " + DateTime.Now + "\r\n";
            WriteLogs(path, context);
        }
    }
}
