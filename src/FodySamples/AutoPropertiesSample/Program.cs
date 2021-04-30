using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoProperties;

namespace AutoPropertiesSample
{
    public class Program
    {
        public static readonly ConcurrentDictionary<string, object> Settings = new()
        {
            ["Value1"] = "abc",
            ["Value2"] = "123",
        };

        static void Main(string[] args)
        {
            var test1 = new MyTest1();
            Console.WriteLine($"test1: {test1.Value1} {test1.Value2}");
            test1.Value1 = "xyz";
            test1.Value2 = "999";
            Console.WriteLine($"test1: {test1.Value1} {test1.Value2}");


            var test2 = new MyTest2();
            Console.WriteLine($"test2: {test2.Value1} {test2.Value2}");
            test2.Value1 = "def";
            test2.Value2 = "233";
            Console.WriteLine($"test2: {test2.Value1} {test2.Value2}");
        }
    }

    public class MyTest1
    {
        public string Value1
        {
            get => Program.Settings.TryGetValue(nameof(Value1), out var value) ? (string) value : default;
            set => Program.Settings.AddOrUpdate(nameof(Value1), _ => value, (_, _) => value);
        }

        public string Value2
        {
            get => Program.Settings.TryGetValue(nameof(Value2), out var value) ? (string) value : default;
            set => Program.Settings.AddOrUpdate(nameof(Value2), _ => value, (_, _) => value);
        }
    }

    public class MyTest2
    {
        [GetInterceptor]
        private object GetValue(string name) => Program.Settings.TryGetValue(name, out var value) ? value : null;

        [SetInterceptor]
        private void SetValue(string name, object value) =>
            Program.Settings.AddOrUpdate(name, _ => value, (_, _) => value);

        public string Value1 { get; set; }

        public string Value2 { get; set; }
    }

    #region 访问自动属性的备用字段
    
    [BypassAutoPropertySettersInConstructors(true)]
    public class MyTest3
    {
        public MyTest3(string property1, string property2)
        {
            // Property1 = property1;
            // Property2 = property2;

            Property1 = property1;
            Property2.SetBackingField(property2);
        }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }

    #endregion
}