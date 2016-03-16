using QASystem.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASystem.Service.SubjectService
{
    public interface ISubjectService
    {
        bool Add(Subject subject);
        Task<bool> Add(ICollection<Subject> subjects);
        bool Update(Subject subject);
        bool Delete(Subject subject);
        IEnumerable<Subject> GetAll();
    }
}
