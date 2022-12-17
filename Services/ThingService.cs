using Application.Interfaces;
using Domain.Models.Domain;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services {
	public class ThingService : IThingService {
		protected readonly IThingRepository _thingRepository;

		public ThingService(IThingRepository thingRepository) {
			this._thingRepository = thingRepository;
		}

		public async Task CreateAsync(Thing obj) {
			// Validate.
			await this._thingRepository.CreateAsync(obj);
		}

		public async Task DeleteAsync(Thing obj) {
			await this._thingRepository.DeleteAsync(obj);
		}

		public async Task<IEnumerable<Thing>> GetAsync() {
			return await this._thingRepository.GetAsync();
		}

		public async Task<Thing> GetAsync(string ID) {
			return await this._thingRepository.GetAsync(ID);
		}

		public async Task UpdateAsync(Thing obj) {
			await this._thingRepository.UpdateAsync(obj);
		}
	}
}
