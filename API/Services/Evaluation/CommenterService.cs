

namespace API_MySIRH.Services
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class CommenterService : ICommenterService
    {
        private readonly ICommenterRepository _CommenterRepository;
        private readonly IMapper _mapper;

        public CommenterService(ICommenterRepository CommenterRepository, IMapper mapper)
        {
            this._CommenterRepository = CommenterRepository;
            this._mapper = mapper;
        }

        public async Task<CommenterDTO> AddCommenter(CommenterDTO Commenter)
        {
            var returnedCommenter = await this._CommenterRepository.AddCommenter(this._mapper.Map<Notes>(Commenter));
            return this._mapper.Map<CommenterDTO>(returnedCommenter);
        }

        public async Task DeleteCommenter(int id)
        {
            await this._CommenterRepository.DeleteCommenter(id);
        }

        public async Task<CommenterDTO> GetCommenter(int id)
        {
            return this._mapper.Map<CommenterDTO>(await this._CommenterRepository.GetCommenter(id));
        }

        public async Task<IEnumerable<CommenterDTO>> GetCommenters()
        {
            //var query = this._CommenterRepository.GetCommenters().ProjectTo<CommenterDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Commenter>, PagedList<CommenterDTO>>(collabs);
            //return await PagedList<CommenterDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _CommenterRepository.GetCommenters();
            return _mapper.Map<IEnumerable<Notes>, IEnumerable<CommenterDTO>>(result);
        }

        public async Task UpdateCommenter(int id, CommenterDTO Commenter)
        {
            await this._CommenterRepository.UpdateCommenter(id, this._mapper.Map<Notes>(Commenter));
        }

    }
}
