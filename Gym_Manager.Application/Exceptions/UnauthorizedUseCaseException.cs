using Gym_Manager.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_Management.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            :base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}")
        {

        }
    }
}
