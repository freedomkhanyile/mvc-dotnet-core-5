using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class CreateCategoryViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "Display Order")]
    [Required]
    [
        Range(
            1,
            int.MaxValue,
            ErrorMessage = "Display order must be greater than 0")
    ]
    public int DisplayOrder { get; set; }
}
