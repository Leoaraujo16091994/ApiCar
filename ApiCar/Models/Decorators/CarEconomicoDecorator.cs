using ApiCar.Models.Interface;

namespace ApiCar.Models.Decorators
{
    public class CarEconomicoDecorator : CarDecorator
    {
        public CarEconomicoDecorator(ICar car) : base (car)
        {                
        }


        public override Car ativarModoEconomico(Car carro)
        {
            var carroModoEconomicoAtivado = carro;
            carroModoEconomicoAtivado.Km = carroModoEconomicoAtivado.Km + (int)(((double)carro.Km / 100) * 10);
            carroModoEconomicoAtivado.Autonomia = carroModoEconomicoAtivado.Autonomia + (int)(((double)carro.Autonomia / 100) * 5);
            carroModoEconomicoAtivado.Preco = carroModoEconomicoAtivado.Preco + (int)(((double)carro.Preco / 100) * 5); 
            return carroModoEconomicoAtivado;
        }
    }
}
