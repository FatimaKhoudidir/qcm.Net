using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace qcm_app.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Quiz_Id { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Quiz Quiz { get; set; }
    }

}
