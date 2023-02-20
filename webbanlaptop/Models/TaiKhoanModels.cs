using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class TaiKhoanModels
    {
    }

    public class TaiKhoanLogin
    {
        public string? TenTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        internal static Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
