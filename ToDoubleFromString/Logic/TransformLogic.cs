using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public double transformString(string str)
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

                if (i == str.Length - 1 && count < 2)
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

                return x + y;
            }
            else 
            {
                return 0;
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
                return false;
            }
        }

        /// <summary>
        /// Проверка строки на коррктность ввода, для конвертации в Double
        /// </summary>
        /// <param name="input">Введенная строка</param>
        /// <returns></returns>
        public double checkInput(string input)
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
                            isInteger = false;
                            break;
                        }
                        count++;
                        if (count > 1)
                        {
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
                        isInteger = false;
                        break;
                    }
                }
            }
            if (isInteger)
            {
                return int.Parse(input); ;
            }
            else 
            {
                return transformString(input);
            }
        }

    }
}
