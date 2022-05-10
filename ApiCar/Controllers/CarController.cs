using ApiCar.Models;
using ApiCar.Models.Decorators;
using ApiCar.Models.Enum;
using ApiCar.Models.Exceptions;
using ApiCar.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Controllers
{
    [Route("/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IList<Car> GetAll()
        {
            return _context.Carro.ToList();
        }

        [HttpPut("abastecerCarro")]
        public void AbastecerCarro(int? litrosGasolinaAbastecido, EnumModelCar modelo)
        {

            if (Enum.IsDefined(typeof(EnumModelCar), modelo))
            {
                var carro = _context.Carro.Where(x => x.Modelo == modelo).FirstOrDefault();

                if (carro.CapacidadeTanque >= carro.QtsLitrosNoTanque + litrosGasolinaAbastecido)
                {
                    carro.QtsLitrosNoTanque = carro.QtsLitrosNoTanque + litrosGasolinaAbastecido;
                    _context.Update(carro);
                    _context.SaveChanges();
                }
                else
                {
                    throw new AbastecerMaisQueTanqueSuportaException("O tanque  não suporta a quantidade de litros gasolina abastecida");
                }
            }
            else
            {
                throw new ModeloInexistente("Não existe o modelo informado");
            }
        }

        [HttpGet("autonomiaAllCarro")]
        public IList<Car> GetAutonomiaAllCarro() {
            return _context.Carro.Select(news => new Car
            {
                Id = news.Id,
                Autonomia = news.Autonomia
            }).ToList();
        }

        [HttpPut("ativarModoTurbo")]
        public void AtivarModoTurbo(int? id)
        {
            var carroSelecionado =  _context.Carro.Where(x => x.Id == id).First();
            if (carroSelecionado.Modelo.ToString() == EnumModelCarModoTurbo.CHEVROLET_CELTA.ToString() ||
                carroSelecionado.Modelo.ToString() == EnumModelCarModoTurbo.FIAT_UNO.ToString())
            {

                ICar carro = new CarTurboDecorator(carroSelecionado);
                carro = carro.ativarModoTurbo(carroSelecionado);
                _context.Update(carro);
                 _context.SaveChanges();
            }
            else
            {
                throw new CarroNaoPossuiModoEconomicoException("O carro não possui modo turbo");
            }
        }


        [HttpPut("ativarModoEconomico")]
        public void AtivarModoEconomico(int? id)
        {
            var carroSelecionado = _context.Carro.Where(x => x.Id == id).First();
            if (carroSelecionado.Modelo.ToString() == EnumModelCarModoEconomico.CHEVROLET_ONIX.ToString() ||
                carroSelecionado.Modelo.ToString() == EnumModelCarModoEconomico.VOLKSWAGEN_GOL.ToString())
            {

                ICar carro = new CarEconomicoDecorator(carroSelecionado);
                carro = carro.ativarModoEconomico(carroSelecionado);
                _context.Update(carro);
                 _context.SaveChangesAsync();
                }
            else
            {
                throw new CarroNaoPossuiModoEconomicoException("O carro não possui modo economico");
            }
        }

        [HttpGet("carroMaxAutonomia")]
        public IList<Car> AutonomiaMaxCarro()
        {
            var maiorAutonomia = _context.Carro.Max(x => x.Autonomia);
            var carro =  _context.Carro.Where(x => x.Autonomia == maiorAutonomia).ToList();
            return carro;
        }

        [HttpGet("carroMaisRapidoByDistancia")]
        public IList<Car> GetCarroRapidoByDistancia(int? distancia)
        {

            var carroComAutonomia =  _context.Carro.Where(x => x.Autonomia >= distancia).ToList();
            var maiorVelocidadesDosCarroComAutonomia = carroComAutonomia.Max(x => x.VelocidadeMedia);
            var carrosMaisRapidos = carroComAutonomia.Where(x => x.VelocidadeMedia == maiorVelocidadesDosCarroComAutonomia).ToList();

            return carrosMaisRapidos;
        }
    }
}
