using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void CategoryAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void CategoryUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void CategoryDelete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            return _blogRepository.GetListAll();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogRepository.GetListAll(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogRepository.GetListWithCategory();
        }
		  public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogRepository.GetListAll(x => x.WriterId == id);
		}
    }
}
