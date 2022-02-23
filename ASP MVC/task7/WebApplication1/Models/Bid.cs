using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Bid
    {
        // ID заявки
        public virtual int BidId { get; set; }
        // Имя заявителя
        [DisplayName("Имя заявителя")]
        [Required]
        public virtual string Name { get; set; }
        // Название кредита
        [DisplayName("Название кредита")]
        public virtual string CreditHead { get; set; }
        // Дата подачи заявки
        [DisplayName("Дата подачи заявки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime BidDate { get; set; }
    }
}