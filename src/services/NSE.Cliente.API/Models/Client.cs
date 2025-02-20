using NSE.Core.DomainObjects;

namespace NSE.Cliente.API.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluded { get; private set; }
        public Address Address { get; private set; }

        // EF Relation
        protected Client() { }

        public Client(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Excluded = false;
            
        }
    }
}