using System.ComponentModel.DataAnnotations;

namespace NGK_GestContact.Api.Dtos
{
    public class CreateContactDto
    {
        public CreateContactDto(string nom, string prenom, string? email, string? tel)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Ce n'est pas une adresse email valide")]
        [MaxLength(384)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Tel { get; set; }
    }
}
