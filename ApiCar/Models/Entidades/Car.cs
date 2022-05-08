using ApiCar.Models.Enum;
using ApiCar.Models.Interface;
using System;

namespace ApiCar.Models
{
    public class Car : ICar
    {
        public int? Id { get; set; }
        public int? Km { get; set; }
        public int? CapacidadeTanque { get; set; }
        public int? QtsLitrosNoTanque { get; set; }
        public int? VelocidadeMedia { get; set; }
        public EnumModelCar Modelo { get; set; }
        public int? Autonomia { get; set; }
        public int? Preco { get; set; }
        public bool? Ativo { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? ModificacaoPor { get; set; }
        public DateTime DataModificacao { get; set; }


        public Car ativarModoEconomico(Car carro) {
            return carro;

        }
        public Car ativarModoTurbo(Car carro)
        {
            return carro;
        }
    }
}
