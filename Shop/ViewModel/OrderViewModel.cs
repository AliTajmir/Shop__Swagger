using System.ComponentModel.DataAnnotations;

namespace Shop;

public class OrderViewModel
{
    public int Id { get; set; }
    [Display(Name ="نام کالا")]
    public string Name_Product { get; set; }
    [Display(Name ="نام کاربر")]
    
    public string FirstName_User { get; set; }
    [Display(Name ="تاریخ ایجاد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public DateTime CreateDate { get; set; } 
    [Display(Name ="آیدی کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int UserId { get; set; }
    [Display(Name ="آیدی کالا")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int ProductId { get; set; }
}