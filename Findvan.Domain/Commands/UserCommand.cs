using Flunt.Validations;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindVan.Domain.Commands.Contracts;

namespace FindVan.Domain.Commands
{
    public class UserCommand : Notifiable, ICommand
    {
        public UserCommand()
        {
        }

        public UserCommand(string name, string idFirebase)
        {
            Name = name;
            IdFirebase = idFirebase;
        }

        public string Name { get; set; }
        public string IdFirebase { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 2, "Name", "Name deve ter mais caracteres")
                    .HasMinLen(IdFirebase, 6, "User", "Usuario Invalido")
            );
        }
    }
}
