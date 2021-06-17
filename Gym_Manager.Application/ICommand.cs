using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        public void Execute(TRequest request);
    }
    public interface IQuery<TSearch, TResult> : IUseCase
    {
        public TResult Execute(TSearch search);
    }
    public interface IUseCase
    {
        public int Id { get; }
        public string Name { get; }
    }
}
