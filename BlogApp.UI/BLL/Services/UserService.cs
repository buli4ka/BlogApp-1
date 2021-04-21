using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;

namespace BLL.Services
{
    class UserService
    {
        IRepository<DAL.Context.User> repository;
        IMapper mapper;
        public UserService(IRepository<DAL.Context.User> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<DAL.Context.User, DTO.UserDTO>();
                x.CreateMap<DTO.UserDTO, DAL.Context.User>();

                x.CreateMap<DAL.Context.Article, DTO.ArticleDTO>()
               .ForMember(y => y.ViewCount, y => y.MapFrom(source => source.ViewedUsers.Count))
               .ForMember(y => y.LikesCount, y => y.MapFrom(source => source.LikedUsers.Count));

                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();

                x.CreateMap<DTO.ArticleDTO, DAL.Context.Article>();
            });
            mapper = new Mapper(configuration);
        }

    }
}
