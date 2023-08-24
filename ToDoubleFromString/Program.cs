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

            while (true)
            {
                Console.Write("Введите число которое необходимо преобразовать: ");
                str = Console.ReadLine();

                convert = transform.checkInput(str);

                if (convert == 0)
                {
                    Console.WriteLine("Введенная строка не может быть преобразована в \"double\"");
                }
                else
                {
                    Console.WriteLine($"Сконвертированное число: {convert}");
                }
            }

        }

    }

}