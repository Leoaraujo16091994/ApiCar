using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCar.Models.Enum
{
    public enum EnumModelCar
    {
        [Display(Name = "1 - CHEVROLET_CORSA")]
        CHEVROLET_CORSA = 1,
        [Display(Name = " 2 - CHEVROLET_CELTA")]
        CHEVROLET_CELTA = 2,
        [Display(Name = " 3 - CHEVROLET_ONIX")]
        CHEVROLET_ONIX = 3,
        [Display(Name = "4 - FIAT_PUNTO")]
        FIAT_PUNTO = 4,
        [Display(Name = " 5 - FIAT_SIENA ")]
        FIAT_SIENA = 5,
        [Display(Name = " 6 - FIAT_UNO ")]
        FIAT_UNO = 6,
        [Display(Name = "7 - FIAT_PALIO")]
        FIAT_PALIO = 7,
        [Display(Name = " 8 - VOLKSWAGEN_GOL")]
        VOLKSWAGEN_GOL = 8,
        [Display(Name = "9 -VOLKSWAGEN_FOX ")]
        VOLKSWAGEN_FOX = 9,
        [Display(Name = "10 - VOLKSWAGEN_UP")]
        VOLKSWAGEN_UP = 10
    }
}