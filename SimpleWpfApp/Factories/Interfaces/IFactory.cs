namespace SimpleWpfApp.Factories.Interfaces {
	public interface IFactory<T> {
		public abstract T Create();
	}
}