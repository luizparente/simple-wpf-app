using Domain.Models.Domain;
using Repositories.Abstract;
using Repositories.Data;
using Services.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories {
	public class ThingRepository : Repository<Thing>, IThingRepository {
		public ThingRepository(FakeDataContext context) : base(context) { }

		public async override Task<Thing> GetAsync(string ID) {
			return this._context.DbSet<Thing>().Where(t => t.ThingGuid == ID).FirstOrDefault();
		}
	}
}
