namespace TestAutomationCourse.Demos.d01.Nunit
{
    public class Factorial
    {
        public int Calculate(int number)
        {
            if (number <= 1)
                return number;
            else
                return Calculate(number - 1) * number;
        }
    }
}
