using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Exceptions
{
        public class AbastecerMaisQueTanqueSuportaException : Exception
        {
            public AbastecerMaisQueTanqueSuportaException(string message) : base(message)
            {
            }
        }
    }