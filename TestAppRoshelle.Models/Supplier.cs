using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestAppRoshelle.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Supplier Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Fax { get; set; }
        [Required]
        public int TelephoneNumber { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
  
        public string ForwarderName { get; set; }
   
        public string PortOfDischarge { get; set; }
     
        public int ImportId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [MaxLength(1)]
        public string IsActive { get; set; }

    }
}
