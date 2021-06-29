using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestAppRoshelle.Models.ViewModels
{
    public class ItemProductVM
    {
        public ItemProduct ItemProduct { get; set; }
        public IEnumerable<SelectListItem> SupplierList { get; set; }
    }
   
}
