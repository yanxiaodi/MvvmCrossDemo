using System;
using MvvmCrossDemo.Core.Infrastructure.Extensions;
using MvvmCrossDemo.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Services
{
    public class PostService : IPostService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private string apiUrl = "http://jsonplaceholder.typicode.com/";



        public async Task<ResponseMessage<List<Post>>> GetPostList()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}posts");
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
        public async Task<ResponseMessage<Post>> GetPost(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}posts/{id}");
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
