using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class ReportIssueFormDto
    {
        [Required]
        public int Project { get; set; }
        [Required]
        public int AssignTo { get; set; }
        [Required]
        public int Severity { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Summary { get; set; }
        [Required]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
