using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vocabulary.Models
{
    public class Word
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите EnglWord")]
        public string EnglWord { get; set; }
        [Required(ErrorMessage = "Укажите RussWord")]
        public string RussWord { get; set; }
        public string AddRuss { get; set; }
    }
}
