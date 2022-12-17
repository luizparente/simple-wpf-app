using Application.Interfaces;

namespace Services.Repositories.Interfaces
{
    public interface IRepository<T> : ICRUDable<T> where T: class { }
}
