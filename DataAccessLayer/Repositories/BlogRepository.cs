﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private Context _context = new Context();

        public List<Blog> ListAllBlogs()
        {
            return _context.Blogs.ToList();
        }

        public void AddBlog(Blog blog)
        {
            _context.Add(blog);
            _context.SaveChanges();
        }

        public void UpdateBlog(Blog blog)
        {
            _context.Update(blog);
            _context.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.Find(id);
        }
    }
}
