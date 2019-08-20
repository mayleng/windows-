using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest.AppData
{
    //该类使用ServiceStack.Redis版本5.6.0
   public  class ServiceStackRedisTest
    {
        public static RedisClient dbclient;
        public static string path = "c://log//ServiceStackRedis.log";

        //将连接数据库封装成一个方法
        protected void GetdbClient(out RedisClient dbclient)
        {
            //连接数据库
            string conn = ConfigurationManager.AppSettings["redis"].ToString();           
            dbclient = new RedisClient(conn);
        }

        //添加数据
        public void AddTest()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
                string a = "redisTest";
                int bnum = 5;
                dbclient.Add<string>("a", a);
                dbclient.Add<int>("b", bnum);
                var exist = dbclient.Exists("a");
                if (exist == 1)
                {
                    LogHelper.WriteResult(path, "添加数据成功。");
                }
                else
                {
                    LogHelper.WriteResult(path, "添加数据失败。");
                }
            }
            catch (Exception ex)
            {
                string ss = "添加数据失败：" + ex.Message;
                LogHelper.WriteResult(path, ss);
            }
        }
        //查询
        public void SerachTest()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
                string a = dbclient.Get<string>("a");
                int b = dbclient.Get<int>("b");
                if (a == "redisTest")
                {
                    LogHelper.WriteResult(path, "查询成功");
                }
                else
                {
                    LogHelper.WriteResult(path, "查询失败");
                }
            }
            catch (Exception ex)
            {
                string ss = "查询数据失败" + ex.Message;
                LogHelper.WriteResult(path, ss);
            }

        }
        //追加
        public void AppendTest()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
                dbclient.AppendToValue("a", "123");
               // byte[] sd = {1,2,3 };
               // dbclient.Append("a",sd);
                string ss = "追加数据成功：" + dbclient.Get<string>("a");
                LogHelper.WriteResult(path, ss);
            }
            catch (Exception ex)
            {
                string ss = "追加失败：" + ex.Message;
                LogHelper.WriteResult(path, ss);
            }
        }

        //加一
        public void AddOne()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
                dbclient.Incr("b");
                string ss = "加一结果：" + dbclient.Get<int>("b").ToString();
                LogHelper.WriteResult(path, ss);
            }
            catch (Exception ex)
            {
                string ss = "加一失败：" + ex.Message;
                LogHelper.WriteResult(path, ss);
            }
        }
        //减一
        public void SubOne()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
                dbclient.Decr("b");
                string ss = "减一结果：" + dbclient.Get<int>("b").ToString();
                LogHelper.WriteResult(path, ss);
            }
            catch (Exception ex)
            {
                string ss ="减一失败："+ ex.Message;
                LogHelper.WriteResult(path, ss);
            }
        }
        //删除
        public void DelTest()
        {
            try
            {
                GetdbClient(out RedisClient dbclient);
               //dbclient.Delete<string>("a");             
               //dbclient.DeleteAll<int>();
                dbclient.Del("a");
                dbclient.Del("b");
                LogHelper.WriteResult(path, "删除成功。");
            }
            catch (Exception ex)
            {
                string ss = "删除失败：" + ex.Message;
                LogHelper.WriteResult(path, ss);
            }
        }

    }


}
