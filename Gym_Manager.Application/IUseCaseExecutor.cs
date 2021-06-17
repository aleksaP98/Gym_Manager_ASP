using Gym_Management.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> querry, TSearch search)
        {
            logger.Log(querry, actor, search);

            if (!actor.AllowedUseCases.Contains(querry.Id))
            {
                throw new UnauthorizedUseCaseException(querry, actor);
            }
            return querry.Execute(search);

        }
        public void ExecuteCommand<TRequet>(ICommand<TRequet> command, TRequet requet)
        {
            logger.Log(command, actor, requet);

            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            command.Execute(requet);
        }
    }
}
