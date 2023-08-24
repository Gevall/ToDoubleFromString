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
            

            while (true)
            {
                Console.Write("Введите число которое необходимо преобразовать: ");
                str = Console.ReadLine();

                transform.checkInput(str);
            }

        }

    }

}