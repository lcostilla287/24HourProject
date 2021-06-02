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

        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Post))]
        public int CommentId { get; set; }
        public virtual Reply Reply { get; set; }

    }
}
