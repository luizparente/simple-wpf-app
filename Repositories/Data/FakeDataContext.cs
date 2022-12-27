using Domain.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Data
{
    public class FakeDataContext {
		public List<Thing> Things { get; set; }
		public List<LoginMethod> LoginMethods { get; set; }

		public FakeDataContext() {
			this.Things = new List<Thing>() { 
				new Thing() { SomeProperty = "Some thing", Type = ThingType.Option2 },
				new Thing() { SomeProperty = "Something else", Type = ThingType.Option1 },
				new Thing() { SomeProperty = "Another thing", Type = ThingType.Option3 },
				new Thing() { SomeProperty = "Yet another thing", Type = ThingType.Option2 },
				new Thing() { SomeProperty = "Last thing", Type = ThingType.Option3 },
			};

			this.LoginMethods = new List<LoginMethod>() {
				new LoginMethod() { LoginMethodGuid = "0", Option = "2FA" },
				new LoginMethod() { LoginMethodGuid = "1", Option = "Active Directory" },
				new LoginMethod() { LoginMethodGuid = "2", Option = "Default" },
				new LoginMethod() { LoginMethodGuid = "3", Option = "Token" },
			};
		}

		public List<T> DbSet<T>() {
			return this.GetType()
					   .GetProperties()
					   .Where(p => p.PropertyType == typeof(List<T>))
					   .FirstOrDefault()
					   .GetValue(this) as List<T>;
		}
	}
}
