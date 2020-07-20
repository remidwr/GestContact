using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dal = DAL.Entities;
using local = ModelLocal.Models;

namespace ModelLocal.Tools
{
    public static class Mappers
    {
        public static local.Contact ToLocal(this dal.Contact c)
        {
            return new local.Contact
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                Telephone = c.Telephone
            };
        }

        public static dal.Contact ToDal(this local.Contact c)
        {
            return new dal.Contact
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                Telephone = c.Telephone
            };
        }
    }
}