using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
	public interface ICRUDable<T> where T: class {
		public Task CreateAsync(T obj);
		public Task<T> GetAsync(string ID);
		public Task<IEnumerable<T>> GetAsync();
		public Task UpdateAsync(T obj);
		public Task DeleteAsync(T obj);
	}
}
