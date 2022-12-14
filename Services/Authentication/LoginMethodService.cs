using Application.Interfaces;
using Domain.Models.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Authentication {
	public class LoginMethodService : ILoginMethodService {
		public async Task CreateAsync(LoginMethod obj) {
			throw new System.NotImplementedException();
		}

		public async Task DeleteAsync(LoginMethod obj) {
			throw new System.NotImplementedException();
		}

		public async Task<LoginMethod> GetAsync(string ID) {
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<LoginMethod>> GetAllAsync() {
			return new List<LoginMethod>() {
				new LoginMethod() { LoginMethodGuid = "0", Option = "2FA" },
				new LoginMethod() { LoginMethodGuid = "1", Option = "Active Directory" },
				new LoginMethod() { LoginMethodGuid = "2", Option = "Default" },
				new LoginMethod() { LoginMethodGuid = "3", Option = "Token" },
			};
		}

		public async Task UpdateAsync(LoginMethod obj) {
			throw new System.NotImplementedException();
		}
	}
}
