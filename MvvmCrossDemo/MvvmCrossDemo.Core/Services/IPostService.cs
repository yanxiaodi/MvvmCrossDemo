using MvvmCrossDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Services
{
    public interface IPostService
    {
        Task<ResponseMessage<List<Post>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken));
        Task<ResponseMessage<Post>> GetPost(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task<ResponseMessage<List<Comment>>> GetComments(int postId, CancellationToken cancellationToken = default(CancellationToken));
        Task<ResponseMessage<Post>> UpdatePost(int id, Post post, CancellationToken cancellationToken = default(CancellationToken));

    }
}
