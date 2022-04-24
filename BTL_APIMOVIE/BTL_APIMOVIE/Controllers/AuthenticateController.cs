//using BTL_APIMOVIE.Auth;
using BTL_APIMOVIE.Auth;
using BTL_APIMOVIE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BTL_APIMOVIE.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        APIMOVIESContext _context=new APIMOVIESContext();
        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Tim kiem nguoi dung
            TbNguoidung nguoidung = _context.TbNguoidungs.Where(n => n.Tendangnhap == model.Tendangnhap).Where(n => n.Matkhau == model.Matkhau).SingleOrDefault();
            if (nguoidung == null)
            {
                Unauthorized();
            }    
            // TIm kiem tai khoan
            var user = await _userManager.FindByNameAsync(model.Tendangnhap);
            // Kiểm tra mật khẩu
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Matkhau))
            {
                // Lấy quyền người dùng
                var Role = await _userManager.GetRolesAsync(user);
                // lay thong tin để tạo JWT token
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in Role)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                // Ham tạo token
                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    user=nguoidung
                });
            }
            return Unauthorized();
        }
        // Dang ky nguoi dung
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Kiem tra xem nguoi dung ton tai chua
            var userExists = await _userManager.FindByNameAsync(model.Tendangnhap);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            // Tao nguoi dung moi
            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Tendangnhap
            };
            var result = await _userManager.CreateAsync(user, model.Matkhau);
            // That bai
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            // Thanh cong
            TbNguoidung nguoidung = new TbNguoidung(model.Tendangnhap, Role.User, model.Matkhau); // Quyen la User
            _context.TbNguoidungs.Add(nguoidung);
            _context.SaveChanges();
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        // Tao tai khoan admin
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            // Kiem tra xem nguoi dung ton tai chua
            var userExists = await _userManager.FindByNameAsync(model.Tendangnhap);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            // Tao moi
            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Tendangnhap
            };
            var result = await _userManager.CreateAsync(user, model.Matkhau);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            // Set quyen admin
            if (!await _roleManager.RoleExistsAsync(Role.Admin))
                await _roleManager.CreateAsync(new IdentityRole(Role.Admin));
            if (!await _roleManager.RoleExistsAsync(Role.User))
                await _roleManager.CreateAsync(new IdentityRole(Role.User));
            // Them quyen
            if (await _roleManager.RoleExistsAsync(Role.Admin))
            {
                await _userManager.AddToRoleAsync(user, Role.Admin);
            }
            if (await _roleManager.RoleExistsAsync(Role.Admin))
            {
                await _userManager.AddToRoleAsync(user, Role.User);
            }
            TbNguoidung nguoidung = new TbNguoidung(model.Tendangnhap, Role.Admin, model.Matkhau);
            _context.TbNguoidungs.Add(nguoidung);
            _context.SaveChanges();
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            // Tạo khóa
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            // Tạo token
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            return Ok();
        }

    }
}

