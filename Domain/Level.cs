using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain
{
    public class Level
    {
        [DisplayName("Level Id")]
        public int LevelId { get; set; }
        [DisplayName("Level Description")]
        public string Description { get; set; }
    }
}
