using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.NetCore5.Web.Data.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Author Full Name")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }
    }

    public class CreateBookViewModel
    {
        [Display(Name = "Book Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Author Full Name")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }
    }

    public class UpdateBookViewModel
    {
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Author Full Name")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }
    }

    public class BookListViewModel
    {
        public List<BookViewModel> books { get; set; }

        public int Count { get; set; }
    }
}
