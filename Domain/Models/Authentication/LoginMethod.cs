namespace Domain.Models.Authentication {
	public class LoginMethod {
		public string LoginMethodGuid { get; set; }
		public string Option { get; set; }
		public string Description { get; set; }

		public override string ToString() {
			return this.Option;
		}
	}
}
