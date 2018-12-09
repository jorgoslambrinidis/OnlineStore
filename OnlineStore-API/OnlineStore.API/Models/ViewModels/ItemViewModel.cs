using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.API.Models.ViewModels
{
    public class ItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Number Of Items")]
        public int NumberOfItems { get; set; }

        [Display(Name = "Is Reserved")]
        public bool IsReserved { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}