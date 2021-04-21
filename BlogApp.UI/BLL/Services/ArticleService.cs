using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;

namespace BLL.Services
{
    class ArticleService
    {
        IRepository<DAL.Context.Article> repository;
        IMapper mapper;
        public ArticleService(IRepository<DAL.Context.Article> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<DAL.Context.Article, DTO.ArticleDTO>()
                .ForMember(y => y.ViewCount, y => y.MapFrom(source => source.ViewedUsers.Count))
                .ForMember(y => y.LikesCount, y => y.MapFrom(source => source.LikedUsers.Count));

                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();

                x.CreateMap<DTO.ArticleDTO, DAL.Context.Article>();
            });
            mapper = new Mapper(configuration);
        }
        public Task<IEnumerable<DTO.ArticleDTO>> GetAll()
        {
            Task<IEnumerable<DTO.ArticleDTO>> task = new Task<IEnumerable<DTO.ArticleDTO>>(() =>
            {
                return mapper.Map<IEnumerable<DAL.Context.Article>, IEnumerable<DTO.ArticleDTO>>(repository.GetAll());
            });
            task.Start();
            return task;
        }

        public Task<DTO.ArticleDTO> Get(int id)
        {
            Task<DTO.ArticleDTO> task = new Task<DTO.ArticleDTO>(() =>
            {
                DAL.Context.Article entity = repository.Get(id);
                return mapper.Map<DAL.Context.Article, DTO.ArticleDTO>(entity);
            });
            task.Start();
            return task;
        }

        public DTO.ArticleDTO Delete(DTO.ArticleDTO item)
        {
            DAL.Context.Article entity = repository.Get(item.ArticleId);
            repository.Delete(entity);
            repository.SaveChanges();
            return item;
        }
        public void CreateOrUpdate(DTO.ArticleDTO item)
        {
            DAL.Context.Article entity = mapper.Map<DTO.ArticleDTO, DAL.Context.Article>(item);
            repository.CreateOrUpdate(entity);
            repository.SaveChanges();
        }
    }
}
