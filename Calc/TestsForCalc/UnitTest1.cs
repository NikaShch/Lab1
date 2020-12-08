using NUnit.Framework;
using Program = Calc.Calc;

namespace TestsForCalc
{
    public class Tests
    {
        [Test, TestCaseSource("DivideCases")]
        public void Test1(int x, int y, int z)
        {
            int temp = Program.Plus(x, y);
            Assert.AreEqual(z, temp);
        }
        static object[] DivideCases =
        {
            new object[] {1,1,2},
            new object[] {2,2,4},
            new object[] {4,2,2},
            new object[] {5,2,10},
            new object[] {1,1,1},
            new object[] {10,2,5}
        };

        [Test, TestCaseSource("DivideCases")]
        public void Test2(int x, int y, int z)
        {
            int temp = Program.Minus(x, y);
            Assert.AreEqual(z,temp);
        }
        [Test, TestCaseSource("DivideCases")]
        public void Test3(int x,int y,int z)
        {
            int temp = Program.Multiplication(x, y);
            Assert.AreEqual(z,temp);
        }
        [Test, TestCaseSource("DivideCases")]
        public void Test4(int x,int y, int z)
        {
            int temp = Program.Division(x, y);
            Assert.AreEqual(z,temp);
        }
    }
}