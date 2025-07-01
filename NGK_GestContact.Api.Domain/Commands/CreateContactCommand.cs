using Tools.Cqs.Commands;

namespace NGK_GestContact.Api.Domain.Commands
{
    public class CreateContactCommand : ICommandDefinition
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string? Email { get; }
        public string? Tel { get; }
        public CreateContactCommand(string nom, string prenom, string? email, string? tel)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }
    }
}
