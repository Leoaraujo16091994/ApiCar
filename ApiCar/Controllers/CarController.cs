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
    public class CarController : Controller
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;
        }


        // GET: Car
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carro.ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            return View();
        }
        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Carro.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult AbastecerCarro()
        {
          return View();
          
        }

        public async Task<IActionResult> AutonomiaAllCarro()
        {
            return View(await _context.Carro.ToListAsync());
        }


        public async Task<IActionResult> AutonomiaMaxCarro()
        {
            var maiorAutonomia =_context.Carro.Max(x => x.Autonomia);
            var carro = await _context.Carro.Where(x => x.Autonomia == maiorAutonomia).ToListAsync();
            return View(carro);
        }

       
        public async Task<IActionResult> ConsultaMaisRapidoPorDistancia()
        {
            return View();
        }

        public async Task<IActionResult> ResultadoModeloMaisRapidoPorDistancia(int? distancia)
        {

            var carroComAutonomia = await _context.Carro.Where(x => x.Autonomia >= distancia ).ToListAsync();
            var maiorVelocidadesDosCarroComAutonomia = carroComAutonomia.Max(x => x.VelocidadeMedia);
            var carrosMaisRapidos = carroComAutonomia.Where(x => x.VelocidadeMedia == maiorVelocidadesDosCarroComAutonomia);
          
            return View(carrosMaisRapidos);
        }

    








        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Km,CapacidadeTanque,QtsLitrosNoTanque,VelocidadeMedia,Modelo,Autonomia,Preco,Ativo,CriadoPor,DataCriacao,ModificacaoPor,DataModificacao")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }



        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Km,CapacidadeTanque,QtsLitrosNoTanque,VelocidadeMedia,Modelo,Autonomia,Preco,Ativo,CriadoPor,DataCriacao,ModificacaoPor,DataModificacao")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }







        [HttpGet, ActionName("GetAll")]
        public IList<Car> GetAll()
        {
            return _context.Carro.ToList();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbastecerCarro(int? litrosGasolinaAbastecido, [Bind("Modelo")] Car car)
        {

            if (Enum.IsDefined(typeof(EnumModelCar), car.Modelo))
            {
               var carro = await _context.Carro.Where(x => x.Modelo == car.Modelo).FirstAsync();

                if (carro.CapacidadeTanque >= carro.QtsLitrosNoTanque + litrosGasolinaAbastecido)
                {
                    carro.QtsLitrosNoTanque = carro.QtsLitrosNoTanque + litrosGasolinaAbastecido;
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                else {
                   throw new AbastecerMaisQueTanqueSuportaException("O tanque  não suporta a quantidade de litros gasolina abastecida");
                }
            }
            else {
                throw new ModeloInexistente("Não existe o modelo informado");
            }
        return View(car);
        }







        [HttpPost, ActionName("AtivarModoEconomico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtivarModoEconomico(int? id)
        {
            var carroSelecionado = await _context.Carro.Where(x => x.Id == id).FirstAsync();
            if (carroSelecionado.Modelo.ToString() == EnumModelCarModoEconomico.CHEVROLET_ONIX.ToString() ||
                carroSelecionado.Modelo.ToString() == EnumModelCarModoEconomico.VOLKSWAGEN_GOL.ToString())
            {

                ICar carro = new CarEconomicoDecorator(carroSelecionado);
                carro = carro.ativarModoEconomico(carroSelecionado);
                _context.Update(carro);
                await _context.SaveChangesAsync();
                return View("index", await _context.Carro.ToListAsync());
            }
            else {
                throw new CarroNaoPossuiModoEconomicoException("O carro não possui modo economico");
            }            
        }

      
        [HttpPost, ActionName("AtivarModoTurbo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtivarModoTurbo(int? id)
        {
            var carroSelecionado = await _context.Carro.Where(x => x.Id == id).FirstAsync();
            if (carroSelecionado.Modelo.ToString() == EnumModelCarModoTurbo.CHEVROLET_CELTA.ToString() ||
                carroSelecionado.Modelo.ToString() == EnumModelCarModoTurbo.FIAT_UNO.ToString())
            {

                ICar carro = new CarTurboDecorator(carroSelecionado);
                carro = carro.ativarModoTurbo(carroSelecionado);
                _context.Update(carro);
                await _context.SaveChangesAsync();
                return View("index", await _context.Carro.ToListAsync());
            }
            else
            {
                throw new CarroNaoPossuiModoEconomicoException("O carro não possui modo turbo");
            }
        }



        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var car = await _context.Carro.FindAsync(id);
            _context.Carro.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CarExists(int? id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }

        
    }
}
