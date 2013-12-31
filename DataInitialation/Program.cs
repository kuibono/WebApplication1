using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace DataInitialation
{
    class Program
    {
        static void Main(string[] args)
        {
            using(Model2Container c=new Model2Container())
            {
                Console.WriteLine("正在验证数据版本");
                bool dontUpdate = c.DataVersion.Any(p => p.Version > 1);
                if (dontUpdate == false)
                {
                    Console.WriteLine("正在更新数据...");
                    V1.InstallAll();
                    Console.WriteLine("数据更新完成.");
                }
                else
                {
                    Console.WriteLine("数据不需要更新...");
                }
            }
        }

    }
}
