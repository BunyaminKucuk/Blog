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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterRepository _newsLetterRepository;

        public NewsLetterManager(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }
        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterRepository.Insert(newsLetter);
        }
    }
}
