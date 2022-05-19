using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCourse.Exercises.e03.Refactoring
{
    internal class CalculatorDisplay
    {
        string d = "0";
        public string GetDisplay()
        {
            return d;
        }

        public void Press(string s)
        {
            if (d.Equals("0"))
            {
                d = s;
            }
            else
                if (!s.Equals("+"))
                d += s;
        }
    }
}
