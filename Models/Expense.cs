using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense Name")]
        [Required(ErrorMessage = "Expense Name is a required field !")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than Zero(0) !")]
        public int Amount { get; set; }

        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
