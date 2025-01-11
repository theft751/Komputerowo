using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class BankAcountNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Number { get; set; }
    }
}
