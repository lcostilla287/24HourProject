using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _userId,
                    PostId = model.PostId,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Comment
                    .Where(e => e.PostId == id)
                    .Select(
                        e =>
                            new CommentListItem
                            {
                                CommentId = e.CommentId,
                                Text = e.Text,
                            }
                                );
                return query.ToArray();
            }
        }
    }
}
