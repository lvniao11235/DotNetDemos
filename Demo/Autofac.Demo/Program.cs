using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Demo
{
    /*
     *使用Autofac的基本模式如下
     * 1. 使用依赖注入来结构化应用程序
     * 2. 增加Autofac依赖
     * 3. 创建ContainerBuilder对象
     * 4. 将组件注册进ContainerBuilder
     * 5. 创建容器并保存以备后面使用
     * 6. 从容器中创建lifetime scope
     * 7. 使用lifetime scope来解析组件实例
     *
     */
    class Program
    {
        static void Main(string[] args)
        {
            BaseUsage();
        }

        public static void BaseUsage()
        {
            ContainerBuilder builder = new ContainerBuilder();
            /*
             * 这是一种建造者模式的应用，即要通过autofac来注入的类型是不确定的
             * 所以要通过依次将需要注入的类型注册到ContainerBuilder上，
             * 这之后就可直接创建容器来使用。
             */
            builder.RegisterType<Calculator>().As<ICalculator>();
            builder.RegisterType<Student>().As<IStudent>();
            IContainer container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                IStudent calc = scope.Resolve<IStudent>();
                Console.WriteLine(calc.Add(1, 2));
            }
        }
    }
}
