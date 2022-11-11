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
    public class WriterManager : IWriterService
    {
        readonly IWriterRepository _writerRepository;

        public WriterManager(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        public void WriteAdd(Writer writer)
        {
            _writerRepository.Insert(writer );
        }
    }
}
