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
			UseSingleton();

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

		public static void UseSpecifyConstructor()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<Student>().UsingConstructor(typeof(string));
			IContainer container = builder.Build();
			using (var scope = container.BeginLifetimeScope())
			{
				Student calc = scope.Resolve<Student>(new NamedParameter("name", "aa"));
				Console.WriteLine(calc.Name);
			}
		}

		public static void UseMutiplyImplement()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.Register<CreditCard>((c, p) =>
			{
				var type = p.Named<int>("type");
				if (type == 1)
				{
					return new GoldCard();
				}
				else
				{
					return new StandardCard();
				}
			});
			IContainer container = builder.Build();
			using (var scope = container.BeginLifetimeScope())
			{
				CreditCard CreditCard = scope.Resolve<CreditCard>(new NamedParameter("type", 2));
				if(CreditCard != null)
				{

				}
			}
		}

		public static void UsePropertyInject()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<Student>().SingleInstance().WithProperty("Name", "1235");
			IContainer container = builder.Build();
			using (var scope = container.BeginLifetimeScope())
			{
				for(int i=0; i<10; i++)
				{
					Student stu = scope.Resolve<Student>();
					Student stu1 = scope.Resolve<Student>();
					Console.WriteLine(stu.Name);
				}
				
			}
			Console.WriteLine("end");
		}

		public static void UseSingleton()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<Student>().AsSelf().As<IStartable>().SingleInstance();
			IContainer container = builder.Build();
		}
    }

	public interface CreditCard
	{

	}

	public class GoldCard : CreditCard
	{

	}

	public class StandardCard: CreditCard
	{

	}
}
