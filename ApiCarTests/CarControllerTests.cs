

using ApiCar.Controllers;
using ApiCar.Models;
using ApiCar.Models.Enum;
using ApiCar.Models.Exceptions;
using ApiCar.Models.Interface;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiCarTests
{
    public class CarControllerTests
    {
        [Fact]
        public void AbastecerCarroMaisQueTanqueSuporta()
        {
            var carController = new CarController(new CarContext());

            var car = new Car
            {
                Modelo = (EnumModelCar)3,
            };
            var qtdLitrosGasolinasAbastecer = 1000;
            Assert.Throws<AbastecerMaisQueTanqueSuportaException>(() => carController.AbastecerCarro(qtdLitrosGasolinasAbastecer,car.Modelo));
        }

        [Fact]
        public void AbastecerCarroModeloInexistente()
        {
            var carController = new CarController(new CarContext());

            var car = new Car
            {
                Modelo = (EnumModelCar)99,
            };
            var qtdLitrosGasolinasAbastecer = 1000;
            Assert.Throws<ModeloInexistente>(() => carController.AbastecerCarro(qtdLitrosGasolinasAbastecer, car.Modelo));
        }


        [Fact]
        public void AtivarModoTurboCarroModeloNaoPossuiModoTurbo()
        {
            var carController = new CarController(new CarContext());
            IList<Car> listaCarros = carController.GetAll();
            var carroBasicoOuEconimico = new Car();
            foreach(var carro in listaCarros)
            {
                if (!(Enum.IsDefined(typeof(EnumModelCarModoTurbo), (int)carro.Modelo))){
                    carroBasicoOuEconimico = carro;
                    return;
                }
         
            };
            Assert.Throws<CarroNaoPossuiModoEconomicoException>(() => carController.AtivarModoTurbo(carroBasicoOuEconimico.Id));
        }


        [Fact]
        public void AtivarModoEconomicoCarroModeloNaoPossuiModoEconomico()
        {
            var carController = new CarController(new CarContext());
            IList<Car> listaCarros = carController.GetAll();
            var carroBasicoOuTurbo = new Car();
            foreach (var carro in listaCarros)
            {
                if (!(Enum.IsDefined(typeof(EnumModelCarModoEconomico), (int)carro.Modelo)))
                {
                    carroBasicoOuTurbo = carro;
                    return;
                }

            };
            Assert.Throws<CarroNaoPossuiModoEconomicoException>(() => carController.AtivarModoTurbo(carroBasicoOuTurbo.Id));
        }
    }
}
