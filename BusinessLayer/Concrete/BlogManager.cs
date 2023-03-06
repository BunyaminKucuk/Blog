using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        #region Method

        public void TAdd(Blog t)
        {
            _blogRepository.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            _blogRepository.Update(t);
        }

        public void TDelete(Blog t)
        {
            _blogRepository.Delete(t);
        }

        public List<Blog> GetList()
        {
            return _blogRepository.GetListAll();
        }

        public Blog TGetByID(int id)
        {
            return _blogRepository.GetById(id);
        }

        public List<Blog> GetLastTreeBlog()
        {
            return _blogRepository.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogRepository.GetListAllByFilter(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogRepository.GetListWithCategory();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogRepository.GetListAllByFilter(x => x.WriterId == id);
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogRepository.GetListWithCategoryByWriter(id);
        }


        #endregion

    }
}
