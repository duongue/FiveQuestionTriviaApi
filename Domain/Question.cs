using System.ComponentModel;

namespace Domain
{
    public class Question
    {
        [DisplayName("Question Id")]
        public int QuestionId { get; set; }
        [DisplayName("Question Level")]
        public Level Level { get; set; }
        [DisplayName("Question Category")]
        public Category Category { get; set; }
        [DisplayName("Question Text")]
        public string Text { get; set; }
        [DisplayName("Correct Answer")]
        public string Answer { get; set; }
        [DisplayName("Additional Info")]
        public string AdditionalInfo { get; set; }
        [DisplayName("Choices")]
        public string Choices { get; set; }
    }
}
