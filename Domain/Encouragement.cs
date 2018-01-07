using System.ComponentModel;

namespace Domain
{
    public class Encouragement
    {
        [DisplayName("Encouragement ID")]
        public int Id { get; set; }
        [DisplayName("Encouragement Text")]
        public string Text { get; set; }
        [DisplayName("Say this on Correct Answer")]
        public bool SaysOnCorrectAnswer { get; set; }
    }
}
