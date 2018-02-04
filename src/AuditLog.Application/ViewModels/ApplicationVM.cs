using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuditLog.Application.ViewModels
{
    public class ApplicationVM : ViewModel<ApplicationVM>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }

        public IEnumerable<RequestVM> Requests { get; set; }
    }
}
