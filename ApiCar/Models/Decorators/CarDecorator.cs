using ApiCar.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Decorators
{
    public class CarDecorator : ICar
    {

        private readonly ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car;
        }

        public virtual Car ativarModoEconomico(Car carro)
        {
            var car = _car.ativarModoEconomico(carro);
            return car;
        }

        public virtual Car ativarModoTurbo(Car carro)
        {
            var car = _car.ativarModoTurbo(carro);
            return car;
        }
    }
}
