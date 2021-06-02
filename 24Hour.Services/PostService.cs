using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        //post

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get
        public IEnumerable<PostDetail> GetAllPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Post
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new PostDetail
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                    Text = e.Text,
                                    CommentId = e.CommentId
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
