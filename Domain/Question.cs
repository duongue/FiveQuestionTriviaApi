using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Question
    {
        [DisplayName("Question Id")]
        [Key]
        public int QuestionId { get; set; }
        [DisplayName("Question Level")]
        [ForeignKey("Level")]
        public int LevelId { get; set; }
        [DisplayName("Question Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Question Text")]
        public string Text { get; set; }
        [DisplayName("Correct Answer")]
        public string Answer { get; set; }
        [DisplayName("Additional Info")]
        public string AdditionalInfo { get; set; }
        [DisplayName("Choices")]
        public string Choices { get; set; }
        
        public virtual Level Level { get; set; }
        public virtual Category Category { get; set; }
    }
}
