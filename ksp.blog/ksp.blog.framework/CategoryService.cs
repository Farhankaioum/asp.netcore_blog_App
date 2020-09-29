using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ksp.blog.framework
{
    public class CategoryService : ICategoryService
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public CategoryService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public CategoryService()
        {

        }

        public IList<Category> GetCategories()
        {
            var category = _blogUnitOfWork.CategoryRepository.GetAll().ToList();

            return category;
        }

        public Category GetCategory(int id)
        {
            return _blogUnitOfWork.CategoryRepository.GetById(id);
        }

        public void CreateCategory(Category category)
        {
            var duplicateCheck = IsCategoryExists(category.Name);

            if (duplicateCheck)
            {
                throw new Exception($"Category name already exists {nameof(category.Name)}");
            }

            _blogUnitOfWork.CategoryRepository.Add(category);
            _blogUnitOfWork.Save();
        }

        public void EditCategory(Category category)
        {
            var duplicateCheckName = IsCategoryExists(category.Name);
            var duplicateCheckById = _blogUnitOfWork.CategoryRepository.GetCount(x => x.Id != category.Id);

            if (duplicateCheckName && duplicateCheckById > 0)
            {
                throw new Exception($"Category name already exists {nameof(category.Name)}");
            }

            var existingCategory = _blogUnitOfWork.CategoryRepository.GetById(category.Id);
            existingCategory.Name = category.Name;

            _blogUnitOfWork.Save();

        }

        public Category DeleteCategory(int id)
        {
            var category = _blogUnitOfWork.CategoryRepository.GetById(id);

            _blogUnitOfWork.CategoryRepository.Remove(id);
            _blogUnitOfWork.Save();

            return category;
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        private bool IsCategoryExists(string name)
        {
            var count = _blogUnitOfWork.CategoryRepository.GetCount(c => c.Name == name);

            return count > 0 ? true : false;
        }

      
    }
}
