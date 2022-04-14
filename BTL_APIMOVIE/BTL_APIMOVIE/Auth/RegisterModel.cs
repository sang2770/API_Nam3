using System.ComponentModel.DataAnnotations;

namespace BTL_APIMOVIE.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Tendangnhap { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Matkhau { get; set; }
    }
}
