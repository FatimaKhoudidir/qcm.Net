namespace qcm_app.Models
{
    public class QuesVM
    {
        public int Question_Id { get; set; }
        public string Question_Text { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
