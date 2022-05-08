using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Exceptions
{
        public class ModeloInexistente : Exception
        {
            public ModeloInexistente(string message) : base(message)
            {
            }
        }
    }