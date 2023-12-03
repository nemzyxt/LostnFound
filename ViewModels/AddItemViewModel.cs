using System;
using System.ComponentModel.DataAnnotations;

namespace LostnFound.ViewModels
{
    public class AddItemViewModel
    {
        [Required(ErrorMessage = "Item name is required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Date lost is required")]
        [DataType(DataType.Date)]
        public DateTime DateLost { get; set; }

        [Required(ErrorMessage = "Location lost is required")]
        public string LocationLost { get; set; }
    }
}
