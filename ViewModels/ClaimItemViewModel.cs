using System;
using System.ComponentModel.DataAnnotations;

namespace LostnFound.ViewModels
{
    public class ClaimItemViewModel
    {
        [Required(ErrorMessage = "Date found is required")]
        [DataType(DataType.Date)]
        public DateTime DateFound { get; set; }

        [Required(ErrorMessage = "Location found is required")]
        public string LocationFound { get; set; }

        [Required(ErrorMessage = "Finder's contact is required")]
        public string FindersContact { get; set; }
    }
}
