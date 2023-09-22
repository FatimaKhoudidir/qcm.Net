using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace qcm_app.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
