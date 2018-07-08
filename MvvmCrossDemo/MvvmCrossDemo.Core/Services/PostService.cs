using System;
using MvvmCrossDemo.Core.Infrastructure.Extensions;
using MvvmCrossDemo.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace MvvmCrossDemo.Core.Services
{
    public class PostService : IPostService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private string apiUrl = "http://jsonplaceholder.typicode.com/";



        public async Task<ResponseMessage<List<Post>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}posts", cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.ReadAsJsonAsync<List<Post>>();
                    return new ResponseMessage<List<Post>>
                    {
                        IsSuccess = true,
                        Result = result
                    };
                }
                else
                {
                    return new ResponseMessage<List<Post>>
                    {
                        IsSuccess = false,
                        // Show the detailed error message here according to the response.
                        Message = "Errors"
                    };
                }
            }
            catch (Exception e)
            {
                // TODO: Log the exception here.
                return new ResponseMessage<List<Post>>
                {
                    IsSuccess = false,
                    // Show the detailed error message here.
                    Message = "Errors"
                };
            }
            
        }
        public async Task<ResponseMessage<Post>> GetPost(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}posts/{id}", cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.ReadAsJsonAsync<Post>();
                    return new ResponseMessage<Post>
                    {
                        IsSuccess = true,
                        Result = result
                    };
                }
                else
                {
                    return new ResponseMessage<Post>
                    {
                        IsSuccess = false,
                        // Show the detailed error message here according to the response.
                        Message = "Errors"
                    };
                }
            }
            catch (Exception e)
            {
                // TODO: Log the exception here.
                return new ResponseMessage<Post>
                {
                    IsSuccess = false,
                    // Show the detailed error message here.
                    Message = "Errors"
                };
            }
        }

        public async Task<ResponseMessage<List<Comment>>> GetComments(int postId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}posts/{postId}/comments", cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.ReadAsJsonAsync<List<Comment>>();
                    return new ResponseMessage<List<Comment>>
                    {
                        IsSuccess = true,
                        Result = result
                    };
                }
                else
                {
                    return new ResponseMessage<List<Comment>>
                    {
                        IsSuccess = false,
                        // Show the detailed error message here according to the response.
                        Message = "Errors"
                    };
                }
            }
            catch (Exception e)
            {
                // TODO: Log the exception here.
                return new ResponseMessage<List<Comment>>
                {
                    IsSuccess = false,
                    // Show the detailed error message here.
                    Message = "Errors"
                };
            }
        }

        public async Task<ResponseMessage<Post>> UpdatePost(int id, Post post, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                HttpContent content = post.ToStringContent();
                var response = await _httpClient.PutAsync($"{apiUrl}posts/{id}", content, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.ReadAsJsonAsync<Post>();
                    return new ResponseMessage<Post>
                    {
                        IsSuccess = true,
                        Result = result
                    };
                }
                else
                {
                    return new ResponseMessage<Post>
                    {
                        IsSuccess = false,
                        // Show the detailed error message here according to the response.
                        Message = "Errors"
                    };
                }
            }
            catch (Exception e)
            {
                // TODO: Log the exception here.
                return new ResponseMessage<Post>
                {
                    IsSuccess = false,
                    // Show the detailed error message here.
                    Message = "Errors"
                };
            }
        }
    }
}
