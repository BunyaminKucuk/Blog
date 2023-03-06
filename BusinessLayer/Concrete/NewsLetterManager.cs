using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterRepository _newsLetterRepository;

        public NewsLetterManager(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }

        public List<NewsLetter> GetList()
        {
            return _newsLetterRepository.GetListAll();
        }

        public void TAdd(NewsLetter t)
        {
            _newsLetterRepository.Insert(t);

        }

        public void TDelete(NewsLetter t)
        {
            _newsLetterRepository.Delete(t);
        }

        public NewsLetter TGetByID(int id)
        {
            return _newsLetterRepository.GetById(id);
        }

        public void TUpdate(NewsLetter t)
        {
            _newsLetterRepository.Update(t);
        }
    }
}
