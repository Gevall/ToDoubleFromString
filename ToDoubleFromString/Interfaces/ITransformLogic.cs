using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoubleFromString.Interfaces
{
    interface ITransformLogic
    {

        void transformString(string str);

        bool checkNumber(string str, int index);

        void errorNumber();

        void checkInput(string input);

    }
}
