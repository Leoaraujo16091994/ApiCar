using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Exceptions
{
        public class CarroNaoPossuiModoEconomicoException : Exception
        {
            public CarroNaoPossuiModoEconomicoException(string message) : base(message)
            {
            }
        }
    }