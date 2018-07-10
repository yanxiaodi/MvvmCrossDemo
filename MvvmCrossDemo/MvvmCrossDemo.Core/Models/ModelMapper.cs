using MvvmCrossDemo.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Models
{
    public static class ModelMapper
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostViewModel, Post>();
                
            });
        }
    }
}
