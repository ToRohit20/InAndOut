using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category is a required field !")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
