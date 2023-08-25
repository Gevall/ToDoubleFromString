using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ToDoubleFromString.Interfaces;
using ToDoubleFromString.Logic;

namespace ToDoubleFromString
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ITransformLogic transform = new TransformLogic();
            string str = "";
            double convert;
            double convert2;

            while (true)
            {
                Console.Write("Введите число которое необходимо преобразовать: ");
                str = Console.ReadLine();
                convert2 = getEnumetareDouble(str);
                convert = transform.checkInput(str);

                if (convert == 0)
                {
                    Console.WriteLine("Введенная строка не может быть преобразована в \"double\"");
                }
                else
                {
                    Console.WriteLine($"Сконвертированное число: {convert}");
                }
                if (convert == convert2) Console.WriteLine("Два сконвертирвоанных числа равны!");
            }

        }

        private static double getEnumetareDouble(string str)
        {
            Console.WriteLine(Double.MaxValue.ToString()); 
            char[] chars = str.ToCharArray();
            int count = 0;
            double dbCount = 0.1;
            bool doteChk = false;
            Console.WriteLine($"Length - {chars.Length}");
            foreach (char c in chars)
            {
                //Console.WriteLine($"{count} - {c}");
                if (c == ',' || c == '.') doteChk = true;
                if (doteChk == false) dbCount = dbCount * 10;

                count++;
            }
            double convert = 0;
            int tmp;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '.' || chars[i] == ',') continue;
                else 
                {
                    convert += converToInt(chars[i], dbCount);
                    dbCount = dbCount / 10;
                }
            }
            Console.WriteLine($"New method convert: {convert}");
            return convert;
        }

        private static double converToInt(char ch, double count)
        {
            double e = ch - '0';
            e = e * count;
            return e;
        }

    }

}