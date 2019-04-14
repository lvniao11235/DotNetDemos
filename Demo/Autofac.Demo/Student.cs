using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Demo
{
    public interface IStudent
    {
        int Add(int a, int b);
    }

    public class Student : IStudent, IDisposable, IStartable
    {
		public static int count = 0;

		public void Dispose()
		{
		}
		public string Name { get; set; }

        public ICalculator Calculator { get; set; }

		public Student()
		{
			count++;
		}

		public Student(ICalculator calculator)
        {
            this.Calculator = calculator;
        }

		public Student(string name)
		{
			this.Name = name;
		}

		public int Add(int a, int b)
        {
            return Calculator.Add(a, b);
        }

		public void Start()
		{
			
		}
	}
}
