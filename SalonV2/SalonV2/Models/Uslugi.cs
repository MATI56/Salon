using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalonV2.Models
{
    public class Uslugi
    {
        public int UslugiId { get; set; }
        [Required(ErrorMessage = "Prosze podać nazwe uslugi")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Prosze podać Cene")]
        public decimal Cena { get; set; }
        [Required(ErrorMessage = "Prosze podać Data Rozpoczecia")]
        [DisplayName("Data Rozpoczecia")]
        public DateTime DataRozpo { get; set; }
        [Required(ErrorMessage = "Prosze podać Data Zakonczenia")]
        [DisplayName("Data Zakonczenia")]
        public DateTime DataZak { get; set; }
        public string Produkty { get; set; }
        public string Uwagi { get; set; }

        public int KlienciId { get; set; }
        public Klienci Klienci { get; set; }
    }
}
