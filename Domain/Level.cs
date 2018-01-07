using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Level
    {
        [DisplayName("Level Id")]
        [Key]
        public int LevelId { get; set; }
        [DisplayName("Level Description")]
        public string Description { get; set; }
    }
}
