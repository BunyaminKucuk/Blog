using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterRepository _writerRepository;

        public WriterManager(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public void TAdd(Writer t)
        {
            _writerRepository.Insert(t);
        }

        public void TUpdate(Writer t)
        {
            _writerRepository.Update(t);
        }

        public void TDelete(Writer t)
        {
            _writerRepository.Delete(t);
        }

        public List<Writer> GetList()
        {
            return _writerRepository.GetListAll();
        }

        public Writer TGetByID(int id)
        {
            return _writerRepository.GetById(id);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerRepository.GetListAllByFilter(x => x.WriterId == id);
        }
    }
}
