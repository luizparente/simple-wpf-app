using Example01_DataBinding.Models.Presentation;

namespace Example01_DataBinding.Models.Authentication {
	public class LoginModel {
		public string Username { get; set; }
		public string Password { get; set; }
		public LoginMethod Method { get; set; }
	}
}
