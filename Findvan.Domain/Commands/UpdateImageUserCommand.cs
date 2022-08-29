using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateImageUserCommand : Notifiable, ICommand
    {
        public UpdateImageUserCommand(string idFirebase, string img)
        {
            Img = img;
            IdFirebase = idFirebase;
        }
        public UpdateImageUserCommand()
        {
        }
        public string Img { get; set; }
        public string IdFirebase { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Img, 3, "Img", "Deve inserir uma URL valida!")
                    .HasMinLen(IdFirebase, 6, "IdFirebase", "Usuario Invalido")
            );
        }
    }
}
