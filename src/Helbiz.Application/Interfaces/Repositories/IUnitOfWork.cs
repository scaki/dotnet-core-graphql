namespace Helbiz.Application.Interfaces.Repositories;

public interface IUnitOfWork:IDisposable
{
    public void Save();
    IUserRepository User { get; }
}