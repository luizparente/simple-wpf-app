namespace Domain.Models.Domain
{
    public class LoginMethod
    {
        public string LoginMethodGuid { get; set; }
        public string Option { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Option;
		}

		public static bool operator ==(LoginMethod a, LoginMethod b) {
			return a?.LoginMethodGuid == a?.LoginMethodGuid;
		}

		public static bool operator !=(LoginMethod a, LoginMethod b) {
			return a?.LoginMethodGuid == a?.LoginMethodGuid;
		}

		public override bool Equals(object obj) {
			if (obj?.GetType() != this?.GetType())
				return false;

			return this?.LoginMethodGuid == ((LoginMethod)obj)?.LoginMethodGuid;
		}

		public override int GetHashCode() {
			return this?.LoginMethodGuid?.GetHashCode() ?? 0;
		}
	}
}
