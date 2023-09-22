using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace qcm_app.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isAnswer { get; set; }
        public int Question_Id { get; set; }
    }
}
