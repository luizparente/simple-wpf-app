using System;

namespace Domain.Models.Domain {
	public class Thing {
		public string ThingGuid { get; set; }
		public string SomeProperty { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }

		public Thing() { 
			this.ThingGuid = Guid.NewGuid().ToString();
			this.CreatedOn = DateTime.Now;
		}

		public static bool operator ==(Thing a, Thing b) {
			return a?.ThingGuid == a?.ThingGuid;
		}

		public static bool operator !=(Thing a, Thing b) {
			return a?.ThingGuid == a?.ThingGuid;
		}

		public override bool Equals(object obj) {
			if (obj?.GetType() != this?.GetType())
				return false;

			return this?.ThingGuid == ((Thing)obj)?.ThingGuid;
		}

		public override int GetHashCode() {
			return this?.ThingGuid?.GetHashCode() ?? 0;
		}
	}
}
