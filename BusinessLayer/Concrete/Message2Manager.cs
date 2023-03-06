using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        private readonly IMessage2Repository _message2Repository;

        public Message2Manager(IMessage2Repository message2Repository)
        {
            _message2Repository = message2Repository;
        }

        public void TAdd(Message2 t)
        {
            _message2Repository.Insert(t);
        }

        public void TUpdate(Message2 t)
        {
            _message2Repository.Update(t);
        }

        public void TDelete(Message2 t)
        {
            _message2Repository.Delete(t);
        }

        public List<Message2> GetList()
        {
            return _message2Repository.GetListAll();
        }

        public Message2 TGetByID(int id)
        {
            return _message2Repository.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2Repository.GetListWithMessageByWriter(id);
        }
    }
}
