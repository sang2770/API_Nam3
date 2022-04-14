using System.ComponentModel.DataAnnotations;

namespace BTL_APIMOVIE.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Tendangnhap { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Matkhau { get; set; }
    }
}
