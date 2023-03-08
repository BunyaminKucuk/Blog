using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public void TAdd(Admin t)
        {
            _adminRepository.Insert(t);
        }

        public void TUpdate(Admin t)
        {
            _adminRepository.Update(t);
        }

        public void TDelete(Admin t)
        {
            _adminRepository.Delete(t);
        }

        public List<Admin> GetList()
        {
            return _adminRepository.GetListAll();
        }

        public Admin TGetByID(int id)
        {
            return _adminRepository.GetById(id);
        }
    }
}
