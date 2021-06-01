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
        public int id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

    }
}
