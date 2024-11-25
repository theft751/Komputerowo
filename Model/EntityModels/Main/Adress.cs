using Domain.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        public Voivodeship Voivodeship { get; set; }
        public string PostCode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string NumberOfBuilding { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
