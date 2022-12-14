namespace Example01_DataBinding.Models.Presentation {
	public class LoginMethod {
		public int ID { get; set; }
		public string Option { get; set; }

		public override string ToString() {
			return this.Option;
		}
	}
}
