using System.ComponentModel.DataAnnotations;

namespace Shop;

public class ProductViewModel
{
    public int Id { get; set; }
    [Display(Name ="نام کالا")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; }
    [Display(Name ="توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Description { get; set; }
    [Display(Name ="نام عکس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string ImageUrl { get; set; }
    [Display(Name ="تعداد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Count { get; set; }
    [Display(Name ="قیمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public decimal Price { get; set; }
}