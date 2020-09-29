using ksp.blog.data;
using ksp.blog.framework.Domain;

namespace ksp.blog.framework
{
    public class CategoryRepository : Repository<Category, int, FrameworkContext>, ICategoryRepository
    {
        public CategoryRepository(FrameworkContext dbContext)
            :base(dbContext)
        {

        }
    }
}
