using System;
using System.Text.RegularExpressions;
using System.IO;

namespace MultiFilesAndDelegates1
{
    delegate string myDelegate(string myStr, string tmp);
    class myClass
    {
        static private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static private Regex reg1 = new Regex(@"(\d+)", RegexOptions.IgnoreCase);
        static private Regex reg2 = new Regex(@"[+/*-]", RegexOptions.IgnoreCase);
        static private string ReadText = myClass.ReadTaskFile("Task.txt");// Документ должен лежать в папке
        static private string integer1 = "", result = "", integer2 = "";
        static private string[] arrReadText;
        static private string[] Searching()
        {
            arrReadText = ReadText.Split('=');
            myDelegate calculator;
            int count = 0;
            do
            {
                for (int i = count; i < arrReadText.Length - 1; i++)
                {
                    MatchCollection match1 = reg1.Matches(arrReadText[i]);

                    integer1 = Convert.ToString(match1[0]);
                    integer2 = Convert.ToString(match1[1]);
                    MatchCollection match2 = reg2.Matches(arrReadText[i]);
                    if (Convert.ToString(match2[0]) == "*")
                    {
                        calculator = Class.multiplication;
                        result = calculator(integer1, integer2);
                    }
                    else if (Convert.ToString(match2[0]) == "/")
                    {
                        calculator = Class.division;
                        result = calculator(integer1, integer2);
                    }
                    else if (Convert.ToString(match2[0]) == "+")
                    {
                        calculator = Class.addition;
                        result = calculator(integer1, integer2);
                    }
                    else if (Convert.ToString(match2[0]) == "-")
                    {
                        calculator = Class.subtraction;
                        result = calculator(integer1, integer2);
                    }
                    break;
                }
                arrReadText[count] += "= " + result;
                count++;
            } while (count < arrReadText.Length - 1);
            return arrReadText;
        }
        static public string ResultToString()
        {
            string[] arrReadText = Searching();
            string result = "";
            for (int i = 0; i < arrReadText.Length; i++)
            {
                result += arrReadText[i];
            }
            return result;
        }
        static public void Print()
        {
            Console.WriteLine(ResultToString());
        }

        static private string ReadTaskFile(string fileName)
        {
            fileName = path + "\\" + fileName;
            string readText = File.ReadAllText(fileName);
            return readText;
        }
        static public void WriteTaskFile(string fileName, string text)
        {
            fileName = path + "\\" + fileName;
            File.WriteAllText(fileName, text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string newFile = "Log.txt";
            myClass.Print();
            var answer = myClass.ResultToString();
            myClass.WriteTaskFile(newFile, answer);
        }
    }
}

