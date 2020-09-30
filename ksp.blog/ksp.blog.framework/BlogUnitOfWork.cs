using ksp.blog.data;

namespace ksp.blog.framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public BlogUnitOfWork(
            FrameworkContext dbContext,
            ICategoryRepository categoryRepository,
            IBlogRepository blogRepository)
                : base(dbContext)
        {
            CategoryRepository = categoryRepository;
            BlogRepository = blogRepository;
        }

      

        public ICategoryRepository CategoryRepository { get ; set; }
        public IBlogRepository BlogRepository { get; set; }
    }
}
