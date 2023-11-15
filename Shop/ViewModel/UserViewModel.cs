using System.ComponentModel.DataAnnotations;

namespace Shop;

public class UserViewModel
{
    public int Id { get; set; }
    [Display(Name ="نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string FirstName { get; set; }
    [Display(Name ="نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string LastName { get; set; }
    [Display(Name ="آدرس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Address { get; set; }
    [Display(Name ="موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Mobile { get; set; } 
}