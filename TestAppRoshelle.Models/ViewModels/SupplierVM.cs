using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestAppRoshelle.Models.ViewModels
{
    public class SupplierVM
    {
        public Supplier Supplier { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
   
}
