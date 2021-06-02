using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        //[ForeignKey(nameof(CommentId))]
        //[Required]
        //public int CommentId { get; set; }
        public virtual List<Comment> Comment { get; set; } = new List<Comment>();

        [Required]
        public Guid AuthorId { get; set; }

    }
}
