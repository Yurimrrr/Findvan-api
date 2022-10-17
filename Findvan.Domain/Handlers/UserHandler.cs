using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindVan.Domain.Commands;
using FindVan.Domain.Commands.Contracts;
using FindVan.Domain.Entities;
using FindVan.Domain.Handlers.Contracts;
using FindVan.Domain.Repositores;

namespace FindVan.Domain.Handlers
{
    public class UserHandler : 
        Notifiable,
        IHandler<UserCommand>,
        IHandler<UpdateImageUserCommand>

    {
        private readonly IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(UserCommand command)
        {
            // Criar user -- fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Alguma coisa errada", command.Notifications);
            // Antes de gerar um novo usuario preciso validar se existe um IdFirebase no meu banco.
            // se existe atualiza o usuario se não só persiste.


            var user = _repository.GetById(command.IdFirebase);
            if (user != null)
            {
                user.UpdateName(command.Name);
                _repository.Update(user);

                return new GenericCommandResult(true, "Usuario atualizado", user);
            }
            else
            {
                //Gera
                user = new User(command.Name, command.IdFirebase);

                //Salva
                _repository.Create(user);

                return new GenericCommandResult(true, "Usuario salvo", user);
            }
        }

        public ICommandResult Handle(UpdateImageUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Parece que algo está errado com sua tarefa", command.Notifications);
            }

            var user = _repository.GetById(command.IdFirebase);

            user.UpdateImg(command.Img);

            _repository.Update(user);

            return new GenericCommandResult(true, "Usuario salvo", command.Notifications);
        }
    }
}
