using GestContact.Models;
using ModelLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.Tools
{
    public static class Mappers
    {
        public static Contact ToModel(this ContactForm c)
        {
            return new Contact
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                Telephone = c.Telephone
            };
        }
    }
}