using System;

namespace MultiFilesAndDelegates1
{
    class Class
    {
        static public string addition(string num1, string num2)
        {
            int n1 = Convert.ToInt32(num1);
            int n2 = Convert.ToInt32(num2);
            int res = n1 + n2;
            string result = Convert.ToString(res);
            return result;
        }
        static public string subtraction(string num1, string num2)
        {
            int n1 = Convert.ToInt32(num1);
            int n2 = Convert.ToInt32(num2);
            int res = n1 - n2;
            string result = Convert.ToString(res);
            return result;
        }
        static public string multiplication(string num1, string num2)
        {
            int n1 = Convert.ToInt32(num1);
            int n2 = Convert.ToInt32(num2);
            int res = n1 * n2;
            string result = Convert.ToString(res);
            return result;
        }
        static public string division(string num1, string num2)
        {
            string result = "";
            double n1 = Convert.ToDouble(num1);
            double n2 = Convert.ToDouble(num2);
            double res = 0;
            if (n2 == 0)
            {
                result = "На ноль не делится!";
            }
            else
            {
                res = n1 / n2;
                result = Convert.ToString(res);
            }
            return result;
        }
    }
}