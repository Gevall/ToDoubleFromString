using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoubleFromString.Interfaces
{
    interface ITransformLogic
    {

        double transformString(string str);

        bool checkNumber(string str, int index);

        double checkInput(string input);

    }
}
