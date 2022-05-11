

//namespace API_MySIRH.Services
//{


//    using API_MySIRH.DTOs;
//    using API_MySIRH.Entities.Evaluation;
//    using API_MySIRH.Interfaces;
//    using AutoMapper;
//    using Microsoft.AspNetCore.Mvc;

//    public class EvaluationService:IEvaluationService
//    {
//        private readonly IEvaluationRepository _EvaluationRepository;
//        private readonly ICandidatRepository _candidatRepository;
//       // private readonly ICommenterRepository _commenterRepository;
//        private readonly ITemplateRepository _templateRepository;
//        private readonly IMapper _mapper;

//        public EvaluationService(IEvaluationRepository EvaluationRepository, ITemplateRepository templateRepository, IMapper mapper, ICandidatRepository candidatRepository)
//        {
//            this._EvaluationRepository = EvaluationRepository;
//            this._mapper = mapper;
//            _candidatRepository = candidatRepository;
//           //_commenterRepository = commenterRepository;
//            _templateRepository = templateRepository;
//        }

//        public async Task<EvaluationDTO> AddEvaluation(EvaluationDTO Evaluation)
//        {
//            var Ev = this._mapper.Map<Evaluation>(Evaluation);
//            var returnedEvaluation = await this._EvaluationRepository.AddEvaluation(Ev);
//            return this._mapper.Map<EvaluationDTO>(returnedEvaluation);
//        }



//        public async Task DeleteEvaluation(int id)
//        {
//            await this._EvaluationRepository.DeleteEvaluation(id);
//        }

//        public async Task<EvaluationDTO> GetEvaluation(int id)
//        {
//            return this._mapper.Map<EvaluationDTO>(await this._EvaluationRepository.GetEvaluation(id));
//        }

//        public async Task<IEnumerable<EvaluationDTO>> GetEvaluations()
//        {
//            //var query = this._EvaluationRepository.GetEvaluations().ProjectTo<EvaluationDTO>(_mapper.ConfigurationProvider).AsNoTracking();
//            ////var mapping = this._mapper.Map<PagedList<Evaluation>, PagedList<EvaluationDTO>>(collabs);
//            //return await PagedList<EvaluationDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

//            var result = await _EvaluationRepository.GetEvaluations();
//            return _mapper.Map<IEnumerable<Evaluation>, IEnumerable<EvaluationDTO>>(result);
//        }

//        public async Task UpdateEvaluation(int id, EvaluationDTO Evaluation)
//        {
//            await this._EvaluationRepository.UpdateEvaluation(id, this._mapper.Map<Evaluation>(Evaluation));
//        }

//        public async Task<dynamic> GetEvaluationByCandidat(int id)
//        {
//            return await _EvaluationRepository.GetEvaluationByCandidat(id) ??null;
//        }

//    }
//}
