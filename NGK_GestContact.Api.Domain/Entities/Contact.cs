using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGK_GestContact.Api.Domain.Entities
{
    public class Contact
    {
        public int Id { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }

        public Contact(int id, string nom, string prenom, string? email, string? tel)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }
    }
}
