using System.Threading.Tasks;

namespace Application.Interfaces {
	public interface IAuthenticationService {
		public Task<bool> AuthenticateAsync(string username, string password, string method);
	}
}
