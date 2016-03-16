using System.Collections.Generic;
using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;
using System.Threading.Tasks;

namespace QASystem.Service.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private IUnitOfWork _uow;
        private IRepository<Subject> _subjectRepository;


        public SubjectService(IUnitOfWork uow, IRepository<Subject> subjectRepository)
        {
            _uow = uow;
            _subjectRepository = subjectRepository;
        }

        public bool Add(Subject subject)
        {
            _subjectRepository.Insert(subject);
            return _uow.SaveChanges() > 0;
        }

        public bool Delete(Subject subject)
        {
            _subjectRepository.Delete(subject);
            return _uow.SaveChanges() > 0;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _subjectRepository.Table.ToList();
        }

        public bool Update(Subject cate)
        {
            _subjectRepository.Update(cate);
            return _uow.SaveChanges() > 0;
        }

        public async Task<bool> Add(ICollection<Subject> cates)
        {
            foreach (var item in cates)
            {
                _subjectRepository.Insert(item);
            }
            return await _uow.SaveChangesAsync() > 0;
        }

    }
}
