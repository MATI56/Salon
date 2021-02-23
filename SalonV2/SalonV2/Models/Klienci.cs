using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonV2.Models
{
    public class Klienci
    {
        public int KlienciId { get; set; }
        [Required(ErrorMessage = "Prosze podać Imię")]
        [DisplayName("Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Prosze podać Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Numer telefonu")]
        public string NumerTel { get; set; }

        public ICollection<Uslugi> Uslugis { get; set; }
    }
}
