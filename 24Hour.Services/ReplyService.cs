using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        //POST

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    CommentId = model.CommentId,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        //GET replies by comment ID
        public IEnumerable<ReplyDetail> GetRepliesByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reply
                        .Where(e => e.CommentId == id)
                        .Select(
                            e =>
                                new ReplyDetail
                                {
                                    CommentId = e.CommentId,
                                    ReplyId = e.ReplyId,
                                    Text = e.Text
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
