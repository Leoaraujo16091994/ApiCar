

using ApiCar.Controllers;
using ApiCar.Models;
using ApiCar.Models.Enum;
using ApiCar.Models.Exceptions;
using ApiCar.Models.Interface;
using Moq;
using NSubstitute;
using Xunit;

namespace ApiCarTests
{
    public class CarControllerTests
    {
        [Fact]
        public void AbastecerCarroMaisQueTanqueSuporta()
        {
            var carController = new CarController(new CarContext());

            var carContext = new Mock<ICarContext>();
            var car = new Car
            {
                Modelo = (EnumModelCar)3,
            };
            var qtdLitrosGasolinasAbastecer = 1000;
            Assert.Throws<AbastecerMaisQueTanqueSuportaException>(() => carController.AbastecerCarro(qtdLitrosGasolinasAbastecer,car.Modelo));
        }
    }
}
