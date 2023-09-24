using Interfaces.Repository.Repositories;

namespace Interfaces.Repository.Database
{
	public interface IUnitOfWork
	{
        IIndicatorRepository Indicator { get; }
        IParameterRepository Parameter { get; }
        ISymbolRepository Symbol { get; }
        IUserRepository User { get; }

        void Commit();
    }
}

