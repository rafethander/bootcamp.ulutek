using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public bool  IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
        [Required]
        public string Address { get; set; }
        public bool  IsFree { get; set; }
        public double Price { get; set; }
        public string Subject { get; set; }
        public string Desc { get; set; }
    }
}
