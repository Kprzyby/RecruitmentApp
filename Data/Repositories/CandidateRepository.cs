using Common.ServiceRegistrationAttributes;
using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    [ScopedRegistrationWithInterface]
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        private DataContext _dataContext;

        public CandidateRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}