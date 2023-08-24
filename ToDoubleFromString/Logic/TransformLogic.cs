using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoubleFromString.Interfaces;

namespace ToDoubleFromString.Logic
{

    public class TransformLogic : ITransformLogic
    {
        int[] numbers = new int[2];
        double finalDouble;

        /// <summary>
        /// Алгоритм преобразования строки в число
        /// </summary>
        /// <param name="str"></param>
        public void transformString(string str)
        {
            string tmp = null;
            int count = 0;
            bool writeBool = false;
            string ZeroAfterDote = null;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.' || str[i] == ',')
                {
                    if (count > 1)
                    {
                        errorNumber();
                        break;
                    }
                    else
                    {
                        if (checkNumber(tmp, count) == false) break;
                        tmp = null;
                        ZeroAfterDote = "1";
                        count++;
                        continue;
                    }
                }

                tmp += str[i];
                ZeroAfterDote += "0";

                if (i == str.Length - 1)
                {
                    if (checkNumber(tmp, count) == false) break;
                    else writeBool = true;
                }
            }
            if (writeBool)
            {
                int mlp = int.Parse(ZeroAfterDote);

                double x = numbers[0];
                double y = numbers[1];
                y = y / mlp;

                Console.WriteLine($"Певая часть числа: {x}" +
                                  $"\n Число после запятой: {y}" +
                                  $"\n Получившееся число: {x + y}");
            }
        }

        /// <summary>
        /// Преобразование строки в int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool checkNumber(string str, int index)
        {
            bool isInNumber;
            int outNumber = 0;
            isInNumber = int.TryParse(str, out outNumber);
            if (isInNumber)
            {
                numbers[index] = outNumber;
                return true;
            }
            else
            {
                errorNumber();
                return false;
            }
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public void errorNumber()
        {
            Console.WriteLine("Введенная строка не является числом!");
        }

        /// <summary>
        /// Проверка строки на коррктность ввода, для конвертации в Double
        /// </summary>
        /// <param name="input">Введенная строка</param>
        /// <returns></returns>
        public void checkInput(string input)
        {
            bool isInNumber;
            bool isInteger = true;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                isInNumber = char.IsNumber(input, i);
                if (isInNumber == false)
                {
                    if (input[i] == ',' || input[i] == '.')
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Введено некоректное число!");
                            break;
                        }
                        count++;
                        if (count > 1)
                        {
                            Console.WriteLine("Введено некоректное число!");
                            break;
                        }
                        else 
                        {
                            isInteger = false;
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введено некоректное число!");
                        break;
                    }
                }
            }
            Console.WriteLine(">>>>> Введенное число корректно! <<<<<");

            if (isInteger)
            {
                finalDouble = int.Parse(input);
                Console.WriteLine($"Получившееся число: {finalDouble}");
            }
            else transformString(input);
        }

    }
}
