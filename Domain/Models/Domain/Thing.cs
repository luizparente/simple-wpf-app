using System;

namespace Domain.Models.Domain {
	public class Thing {
		private string _someProperty;

		public event Action OnUpdate;

		public string ThingGuid { get; set; }
		public ThingType Type { get; set; }
		public string SomeProperty { 
			get {
				return this._someProperty;
			}
			set {
				if (value == this._someProperty)
					return;

				this._someProperty = value;

				this.OnUpdate?.Invoke();
			}
		}
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }

		public Thing() {
			this.ThingGuid = Guid.NewGuid().ToString();
			this.CreatedOn = DateTime.Now;
		}

		public static bool operator ==(Thing a, Thing b) {
			return a?.ThingGuid == b?.ThingGuid;
		}

		public static bool operator !=(Thing a, Thing b) {
			return a?.ThingGuid != b?.ThingGuid;
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
