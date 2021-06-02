using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentCreate
    {
        [MaxLength(8000)]
        public string Text { get; set; }

        public int PostId { get; set; }
    }
}
