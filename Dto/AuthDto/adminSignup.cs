using System.ComponentModel.DataAnnotations;

namespace blissBackend.Dto.AuthDto{
    public class adminSignup{
        [Required]
        public string firstname { get; set; } = null!;
        [Required]
        public string lastname { get; set; } = null!;
        [Required]
        public string email { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!;
    }
}