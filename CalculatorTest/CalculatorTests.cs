using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator.Simple _simple;
        public CalculatorTests()
        {
         _simple=new Calculator.Simple();   
        }

        [TestMethod]
        public void simple_multiplication()
        {
            var calcValue = _simple.Solve("5*5");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(25));
        }

        [TestMethod]
        public void less_simple_multiplication()
        {
            var calcValue = _simple.Solve("5 * 5 * 2");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(50));
        }

        [TestMethod]
        public void less_simple_multiplication_with_negative()
        {
            var calcValue = _simple.Solve("5 * 5 * -2");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(-50));
        }

        [TestMethod]
        public void less_simple_multiplication_with_double_negative()
        {
            var calcValue = _simple.Solve("5 * -5 * -2");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(50));
        }

        [TestMethod]
        public void simple_division()
        {
            var calcValue = _simple.Solve("10 / 5");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue .Equals(2));
        }

        [TestMethod]
        public void less_simple_dvision()
        {
            var calcValue = _simple.Solve("25 / 5 / 2");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(2.5));
        }

        [TestMethod]
        public void less_simple_dvision_with_negative()
        {
            var calcValue = _simple.Solve("25 / 5 / -2");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(-2.5));
        }

        [TestMethod]
        public void mixed_high_operations()
        {
            var calcValue = _simple.Solve("5 * 5 * 2 / 5");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(10));
        }

        [TestMethod]
        public void simple_addition()
        {
            var calcValue = _simple.Solve("5 + 5");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(10));
        }

        [TestMethod]
        public void less_simple_addition()
        {
            var calcValue = _simple.Solve("5 + 5 + 10");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(20));
        }

        [TestMethod]
        public void less_simple_addition_with_negative()
        {
            var calcValue = _simple.Solve("5 + 5 + -10");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(0));
        }

        [TestMethod]
        public void complete_mixed_operations()
        {
            var calcValue = _simple.Solve("5 + 5 * 10 / 50 - 1");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(5));
        }

        [TestMethod]
        public void complete_mixed_operations_differnt_orders()
        {
            var calcValue = _simple.Solve("5 * 5 + 50 / 10 * 3 + 2 * 5");
            Console.WriteLine(calcValue);
            Assert.IsTrue(calcValue.Equals(50));
        }


        [TestMethod]
        public void parans_calculate()
        {
            var tempCalc = _simple.Solve("( 5 + 5 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(10));
        }
        [TestMethod]
        public void parans_calculate_dual()
        {
            var tempCalc = _simple.Solve("( 5 + 5 ) + ( 1 + 1 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(12));
        }

        [TestMethod]
        public void parans_calculate_nested()
        {
            var tempCalc = _simple.Solve("( 5 + ( 1 + 1 ) + 5 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(12));
        }

        [TestMethod]
        public void parans_calculate_mixed_operations()
        {
            var tempCalc = _simple.Solve("( 5 * 5 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(25));
        }
        [TestMethod]
        public void parans_calculate_dual_multiply()
        {
            var tempCalc = _simple.Solve("( 5 + 5 ) * ( 1 + 1 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(20));
        }

        [TestMethod]
        public void parans_calculate_nested_multiply()
        {
            var tempCalc = _simple.Solve("( 5 * ( 1 + 1 ) + 5 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(15));
        }

        [TestMethod]
        public void parans_calculate_front_nested_multiply()
        {
            var tempCalc = _simple.Solve("( ( 5 + 2 ) * ( 1 + 1 ) + 5 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(19));
        }

        [TestMethod]
        public void parans_calculate_front_nested_multiply_extenal()
        {
            var tempCalc = _simple.Solve("( ( 5 + 2 ) * ( 1 + 1 ) + 5 ) - 1");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(18));
        }

        [TestMethod]
        public void parans_calculate_front_nested_multiply_extenal_nested()
        {
            var tempCalc = _simple.Solve("( ( ( 5 + 2 ) * ( 1 + 1 ) + 5 ) - 1 ) / 9");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(2));
        }

        [TestMethod]
        public void parans_calculate_front_nested_multiply_extenal_nested_extended_double()
        {
            var tempCalc = _simple.Solve("( ( ( 5 + 2 ) * ( 1 + 1 ) + 5 ) - 1 ) / 2 / 5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(1.8));
        }

        [TestMethod]
        public void provided_problem()
        {
            var tempCalc = _simple.Solve("4 * 8 + -5.3 / ( 9 + 7 )");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(31.66875));
        }

        [TestMethod]
        public void parse_simple_addition()
        {
            var spacedString = _simple.EnsureProperlySpacedProblem("5+5");
            Console.WriteLine(spacedString);
            Assert.IsTrue(spacedString.Equals("5 + 5"));
        }

        [TestMethod]
        public void parse_parans_calculate_front_nested_multiply_extenal_nested_extended_double()
        {
            var tempCalc = _simple.EnsureProperlySpacedProblem("(((5+2)*(1+1)+5)-1)/2/5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals("( ( ( 5 + 2 ) * ( 1 + 1 ) + 5 ) - 1 ) / 2 / 5"));
        }

        [TestMethod]
        public void parse_power()
        {
            var tempCalc = _simple.EnsureProperlySpacedProblem("2^2");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals("2^2"));
        }

        [TestMethod]
        public void simple_power()
        {
            var tempCalc = _simple.Solve("2^2");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(4));
        }

        [TestMethod]
        public void simple_power_addition()
        {
            var tempCalc = _simple.Solve("2^2+2");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(6));
        }

        [TestMethod]
        public void simple_power_addition_with_parans()
        {
            var tempCalc = _simple.Solve("2^(2+2)");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(16));
        }

        [TestMethod]
        public void simple_power_addition_with_negative()
        {
            var tempCalc = _simple.Solve("2^-3");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(.125));
        }

        [TestMethod]
        public void simple_power_addition_with_negative_add()
        {
            var tempCalc = _simple.Solve("2^-3+5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(5.125));
        }

        [TestMethod]
        public void simple_power_addition_with_negative_add_parans()
        {
            var tempCalc = _simple.Solve("(2^-3)+5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(5.125));
        }

        [TestMethod]
        public void simple_power_addition_with_negative_multiply()
        {
            var tempCalc = _simple.Solve("2^-3*5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(.625));
        }

        [TestMethod]
        public void parse_parans_calculate_front_nested_multiply_extenal_nested_extended_double_power()
        {
            var tempCalc = _simple.Solve("(((5+2)*(1+1)+2^2)-1)/2/5");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(1.7));
        }

        [TestMethod]
        public void double_negative()
        {
            var tempCalc = _simple.Solve("2--2");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(4));
        }

        [TestMethod]
        public void double_negative_in_parans()
        {
            var tempCalc = _simple.Solve("2-(-2)");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(4));
        }
        [TestMethod]
        public void double_minus()
        {
            var tempCalc = _simple.Solve("-2-2");
            Console.WriteLine(tempCalc);
            Assert.IsTrue(tempCalc.Equals(-4));
        }
    }
}
