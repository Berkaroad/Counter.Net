using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCounter.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string key1 = "C10010/1";
            string key2 = "C10011/10001";

            var provider = DCounter.DCounterServiceFactory.Create((p)=> {
                // 初始化各个计数器
                for (var i= 1; i <= 10000; i++)
                {
                    p.Set("C10010/" + i.ToString(), i % 100 + 2);
                }
                for (var i = 10001; i <= 20000; i++)
                {
                    p.Set("C10011/" + i.ToString(), i % 100 + 3);
                }
            }).Provider;

            // 打印初始值
            Console.WriteLine(String.Format("{0}'s value is {1}", key1, provider.Get(key1)));
            Console.WriteLine(String.Format("{0}'s value is {1}", key2, provider.Get(key2)));

            // 增加 |-90|
            provider.IncreaseBy(key1, -90);
            Console.WriteLine(String.Format("{0}'s value is {1}", key1, provider.Get(key1)));

            // 减少 |-90|
            provider.DecreaseBy(key2, -90);
            Console.WriteLine(String.Format("{0}'s value is {1}", key2, provider.Get(key2)));
        }
    }
}
