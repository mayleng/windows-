using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
          //nlog
          LogHelper.WriteLog("程序启动main");
           ServiceBase[] ServicesToRun;
            //在这里可以指定多个服务
            ServicesToRun = new ServiceBase[]
            {
                new Service1(),
             
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
