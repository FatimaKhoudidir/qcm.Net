using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace qcm_app.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
