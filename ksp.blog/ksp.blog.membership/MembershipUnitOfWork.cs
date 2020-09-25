using ksp.blog.membership.Contexts;

namespace ksp.blog.membership
{
    public class MembershipUnitOfWork : IMembershipUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IMembershipRepository MembershipRepository { get; set; }

        public MembershipUnitOfWork(ApplicationDbContext dbContext, IMembershipRepository membershipRepository)
        {
            _dbContext = dbContext;
            MembershipRepository = membershipRepository;
        }

        

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }
    }
}
