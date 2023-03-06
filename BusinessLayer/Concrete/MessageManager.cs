using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void TAdd(Message t)
        {
            _messageRepository.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _messageRepository.Update(t);
        }

        public void TDelete(Message t)
        {
            _messageRepository.Delete(t);
        }

        public List<Message> GetList()
        {
            return _messageRepository.GetListAll();
        }

        public Message TGetByID(int id)
        {
            return _messageRepository.GetById(id);
        }

        public List<Message> GetInboxListWithByWriter(string mail)
        {
            return _messageRepository.GetListAllByFilter(x => x.Receiver == mail);
        }
    }
}
