using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutManager(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public void TAdd(About t)
        {
            _aboutRepository.Insert(t);
        }

        public void TUpdate(About t)
        {
            _aboutRepository.Update(t);
        }

        public void TDelete(About t)
        {
            _aboutRepository.Delete(t);
        }

        public List<About> GetList()
        {
            return _aboutRepository.GetListAll();
        }

        public About TGetByID(int id)
        {
            return _aboutRepository.GetById(id);
        }
    }
}
