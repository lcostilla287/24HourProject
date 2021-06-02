using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Post))]
        [Required]
        public int CommentId { get; set; }
        public virtual Reply Reply { get; set; }

    }
}
