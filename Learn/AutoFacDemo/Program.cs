using Autofac;
using System;

namespace AutoFacDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //1.建立ContainerBuilder物件
            ContainerBuilder builder = new ContainerBuilder();
            //2.註冊型別(可限制創建物件生命週期)
            builder.RegisterType<ConsoleService2>().As<IConsoleService>();
            builder.RegisterType<ConsoleService2222>().As<ConsoleService2222>();
            //3.建立IContainer
            IContainer container = builder.Build();
            //4.使用IContainer取得我們需要的物件.
            IConsoleService user = container.Resolve<IConsoleService>();


            user.ShowHello();

            ConsoleService2222 userService = container.Resolve<ConsoleService2222>();
            //ConsoleService2222 userService1 = new ConsoleService2222();
            //userService.Test();
            Console.ReadLine();
        }
    }

    public class ConsoleService2222
    {
        private IConsoleService ITestService;

        public ConsoleService2222(IConsoleService testService)
        {
            ITestService = testService;
        }

        public void Test()
        {
            ITestService.ShowHello();
        }

    }

    public interface IConsoleService
    {
        void ShowHello();
    }

    public class ConsoleService : IConsoleService
    {
        public void ShowHello()
        {
            Console.WriteLine($"Hello，It's {this.GetType().Name}");
        }
    }

    public class ConsoleService2 : IConsoleService
    {
        public void ShowHello()
        {
            Console.WriteLine($"Hello，It's {this.GetType().Name}");
        }
    }

}