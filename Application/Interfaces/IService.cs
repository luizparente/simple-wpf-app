using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces {
	public interface IService<T> {
		public Task CreateAsync(T obj);
		public Task<T> GetAsync(string ID);
		public Task<IEnumerable<T>> GetAllAsync();
		public Task UpdateAsync(T obj);
		public Task DeleteAsync(T obj);
	}
}
