using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetListAll();
        }

        public Category TGetByID(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void TAdd(Category t)
        {
            _categoryRepository.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryRepository.Update(t);
        }

        public void TDelete(Category t)
        {
            _categoryRepository.Delete(t);
        }
    }
}
