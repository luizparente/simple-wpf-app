using Domain.Models.Domain;
using Repositories.Abstract;
using Repositories.Data;
using Services.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories {
	public class LoginMethodRepository : Repository<LoginMethod>, ILoginMethodRepository {
		public LoginMethodRepository(FakeDataContext context) : base(context) { }

		public async override Task<LoginMethod> GetAsync(string ID) {
			return this._context.DbSet<LoginMethod>().Where(l => l.LoginMethodGuid == ID).FirstOrDefault();
		}
	}
}
