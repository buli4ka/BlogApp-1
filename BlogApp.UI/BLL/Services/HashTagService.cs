using AutoMapper;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class HashTagService
    {
        IRepository<DAL.Context.HashTag> repository;
        IMapper mapper;
        public HashTagService(IRepository<DAL.Context.HashTag> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();
            });
            mapper = new Mapper(configuration);
        }
        public Task<IEnumerable<DTO.HashTagDTO>> GetAll()
        {
            Task<IEnumerable<DTO.HashTagDTO>> task = new Task<IEnumerable<DTO.HashTagDTO>>(() =>
            {
              return mapper.Map<IEnumerable<DAL.Context.HashTag>, IEnumerable<DTO.HashTagDTO>>(repository.GetAll());
            });
            task.Start();
            return task;
        }

        public Task<DTO.HashTagDTO> Get(int id)
        {
            Task<DTO.HashTagDTO> task = new Task<DTO.HashTagDTO>(() =>
            {
                DAL.Context.HashTag entity = repository.Get(id);
                return mapper.Map<DAL.Context.HashTag, DTO.HashTagDTO>(entity);
            });
            task.Start();
            return task;
        }

        public DTO.HashTagDTO Delete(DTO.HashTagDTO item)
        {
            DAL.Context.HashTag entity = repository.Get(item.HashTagId);
            repository.Delete(entity);
            repository.SaveChanges();
            return item;
        }
        public void CreateOrUpdate(DTO.HashTagDTO item)
        {
            DAL.Context.HashTag entity = mapper.Map<DTO.HashTagDTO, DAL.Context.HashTag>(item);
            repository.CreateOrUpdate(entity);
            repository.SaveChanges();
        }
    }
}
