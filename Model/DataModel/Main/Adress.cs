﻿using Model.DataModel.Enums.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        public Voivodeship Voivodeship { get; set; }
        public string PostCode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string LocalNumber { get; set; }

        //Navigation properties
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
