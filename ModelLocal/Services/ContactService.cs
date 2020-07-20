using DAL.Interface;
using DAL.Repositories;
using dal = DAL.Entities;
using local = ModelLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelLocal.Tools;

namespace ModelLocal.Services
{
    public class ContactService : IContactRepository<local.Contact>
    {
        private IContactRepository<dal.Contact> _repo;

        public ContactService()
        {
            _repo = new ContactRepository();
        }

        public int Delete(int id)
        {
           return _repo.Delete(id);
        }

        public IEnumerable<local.Contact> FindByName(string name)
        {
            IEnumerable<local.Contact> c = _repo.FindByName(name).Select(x => x.ToLocal()).ToList();
            return c ;
        }

        public IEnumerable<local.Contact> GetAll()
        {
            return _repo.GetAll().Select(x => x.ToLocal());
        }

        public local.Contact GetById(int id)
        {
            return _repo.GetById(id).ToLocal();
        }

        public int Save(local.Contact entity)
        {
            return _repo.Save(entity.ToDal());
        }

        public int Update(local.Contact entity)
        {
            return _repo.Update(entity.ToDal());
        }
    }
}