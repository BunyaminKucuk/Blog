using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetList()
        {
            return _contactRepository.GetListAll();
        }

        public void TAdd(Contact t)
        {
            _contactRepository.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactRepository.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void TUpdate(Contact t)
        {
            _contactRepository.Update(t);
        }
    }
}
