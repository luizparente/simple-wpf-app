using Application.Interfaces;
using Domain.Models.Domain;
using Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class LoginMethodService : ILoginMethodService {
		protected readonly ILoginMethodRepository _loginMethodRepository;

		public LoginMethodService(ILoginMethodRepository loginMethodRepository) {
			this._loginMethodRepository = loginMethodRepository;
		}

		public async Task CreateAsync(LoginMethod obj) {
			// Validate.
			await this._loginMethodRepository.CreateAsync(obj);
		}

		public async Task DeleteAsync(LoginMethod obj) {
			await this._loginMethodRepository.DeleteAsync(obj);
		}

		public async Task<LoginMethod> GetAsync(string ID) {
			return await this._loginMethodRepository.GetAsync(ID);
		}

		public async Task<IEnumerable<LoginMethod>> GetAsync() {
			return await this._loginMethodRepository.GetAsync();
		}

		public async Task UpdateAsync(LoginMethod obj) {
			await this._loginMethodRepository.UpdateAsync(obj);
		}
	}
}
