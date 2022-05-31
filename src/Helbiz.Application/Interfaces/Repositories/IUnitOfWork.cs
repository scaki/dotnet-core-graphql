namespace Helbiz.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    public void Save();
    IUserRepository User { get; }
}