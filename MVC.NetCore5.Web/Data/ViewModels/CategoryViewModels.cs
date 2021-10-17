using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class CategoryViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Category Name")]
    public string Name { get; set; }

    [Display(Name = "Display Order")]
    public int DisplayOrder { get; set; }
}

public class CreateCategoryViewModel
{
    [Required]
    [Display(Name = "Category Name")]
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

public class UpdateCategoryViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Category Name")]
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

public class CategoryListViewModel
{
    public List<CategoryViewModel> categories { get; set; }

    public int Count { get; set; }
}
