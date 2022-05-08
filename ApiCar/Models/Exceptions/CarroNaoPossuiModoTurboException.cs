using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Exceptions
{
        public class CarroNaoPossuiModoTurboException : Exception
        {
            public CarroNaoPossuiModoTurboException(string message) : base(message)
            {
            }
        }
    }