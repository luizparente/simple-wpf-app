namespace Application.Interfaces {
	public interface IService<T> : ICRUDable<T> where T: class { }
}
