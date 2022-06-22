using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Entities
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public string TransactionReference { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public virtual Payment Payments { get; set; }
    }
}
