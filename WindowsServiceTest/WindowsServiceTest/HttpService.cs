using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    //写一个类跟http页面交互
   public class HttpService
    {

        HttpListener listerner = null;

        public void Start()
        {
            listerner = new HttpListener();
            try
            {
                listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                listerner.Prefixes.Add("http://127.0.0.1:8888/");
                listerner.Start();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("端口监听打开失败：" + ex.Message);
            }
            int min, max, port;
            ThreadPool.GetMinThreads(out min, out port);
            ThreadPool.GetMaxThreads(out max, out port);
            while (true)
            {
                HttpListenerContext ctx = listerner.GetContext();//等待请求
                ThreadPool.QueueUserWorkItem(new WaitCallback(Callback), ctx);
            }
        }

        static void Callback(Object o)
        {
            HttpListenerContext ctx = (HttpListenerContext)o;
            Stream stream = ctx.Request.InputStream;
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String body = reader.ReadToEnd();

            ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");//打开跨域权限
            ctx.Response.AddHeader("Access-Control-Allow-Methods", "POST");//限制请求方式

            LogHelper.WriteLog("request body : " + body);

            ctx.Response.StatusCode = 200;//Http返回状态码
            using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream, Encoding.UTF8))
            {
                writer.Write("hello success web");//简单的输出一个字符串
                writer.Close();
                ctx.Response.Close();
            }
        }
        public void Stop()
        {
            try
            {
                listerner.Close();
                LogHelper.WriteLog("停止监听web服务");
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("停止监听web服务失败" + e.Message);
            }
        }


       


     





    }
}
