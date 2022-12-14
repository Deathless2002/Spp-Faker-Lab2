using System.Collections.Generic;

namespace FakerTests
{
    public class SeveralConstructorClass
    {
        private int sum0;
        private int sum1;
        private int sum2;
        private int sum3;
        private int sum4;

        public SeveralConstructorClass()
        {
            sum0 = 0;
        }

        public SeveralConstructorClass(int a)
        {
            sum1 = a;
        }

        public SeveralConstructorClass(int a, int b)
        {
            sum2 = a + b;
        }

        public SeveralConstructorClass(int a, int b, int c)
        {
            sum3 = a + b + c;
        }

        private SeveralConstructorClass(int a, int b, int c, int d)
        {
            sum4 = a + b + c + d;
        }

        public List<int> GetSum()
        {
            return new List<int>
            { sum0, sum1, sum2, sum3, sum4 };
        }
    }
}
