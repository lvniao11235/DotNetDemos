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

    public class Student : IStudent
    {
        public ICalculator Calculator { get; set; }

        public Student(ICalculator calculator)
        {
            this.Calculator = calculator;
        }
        public int Add(int a, int b)
        {
            return Calculator.Add(a, b);
        }
    }
}
