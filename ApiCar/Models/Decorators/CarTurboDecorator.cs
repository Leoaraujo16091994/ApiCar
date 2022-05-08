using ApiCar.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Decorators
{
    public class CarTurboDecorator : CarDecorator
    {
        public CarTurboDecorator(ICar car) : base(car)
        {
        }


        public override Car ativarModoTurbo(Car carro)
        {
            var carroModoTurboAtivado = carro;
            carroModoTurboAtivado.Km = carroModoTurboAtivado.Km - (int)(((double)carro.Km / 100) * 30);
            carroModoTurboAtivado.VelocidadeMedia = carroModoTurboAtivado.VelocidadeMedia + (int)(((double)carro.VelocidadeMedia / 100) * 15);
            carroModoTurboAtivado.Preco = carroModoTurboAtivado.Preco + (int)(((double)carro.Preco / 100) * 10);
            return carroModoTurboAtivado;
        }
    }
}