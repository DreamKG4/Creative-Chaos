using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyMVC.Models
{
    public class ItemDetails
    {
        [Key]
        [Display(Name ="Item ID")]
        public int Item_ID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Item_Name { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public int Item_Price { get; set; }

        [Required]
        [Display(Name = "Image Name")]
        public string Image_Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
   
}

