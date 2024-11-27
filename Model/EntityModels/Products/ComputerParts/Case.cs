using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
{

    public class Case:Product
    {
        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CaseType CaseType { get; set; }
    }
}
