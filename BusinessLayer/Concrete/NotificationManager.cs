using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public List<Notification> GetList()
        {
            return _notificationRepository.GetListAll();
        }

        public void TAdd(Notification t)
        {
            _notificationRepository.Insert(t);
        }

        public void TDelete(Notification t)
        {
            _notificationRepository.Delete(t);
        }

        public Notification TGetByID(int id)
        {
            return _notificationRepository.GetById(id);
        }

        public void TUpdate(Notification t)
        {
            _notificationRepository.Update(t);
        }
    }
}
