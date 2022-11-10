using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CategoryAdd(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetListAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
