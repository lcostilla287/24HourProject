using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(750)]
        public string Text { get; set; }
        
        public int CommentId { get; set; }
    }
}
