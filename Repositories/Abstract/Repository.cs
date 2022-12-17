using Repositories.Data;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract {
	public abstract class Repository<T> : IRepository<T> where T: class {
		protected readonly FakeDataContext _context;

		public Repository(FakeDataContext context) {
			this._context = context;
		}

		public async Task CreateAsync(T obj) {
			await Task.Run(() => {
				this._context.DbSet<T>().Add(obj);
			});
		}

		public async Task DeleteAsync(T obj) {
			await Task.Run(() => {
				this._context.DbSet<T>().Remove(obj);
			});
		}

		public async Task<IEnumerable<T>> GetAsync() {
			return this._context.DbSet<T>();
		}

		public abstract Task<T> GetAsync(string ID);

		public async Task UpdateAsync(T obj) {
			await this.DeleteAsync(obj);
			await this.CreateAsync(obj);
		}
	}
}
