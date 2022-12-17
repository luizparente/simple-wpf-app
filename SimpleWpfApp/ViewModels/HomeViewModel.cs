using Application.Interfaces;
using Domain.Models.Domain;
using SimpleWpfApp.Commands;
using SimpleWpfApp.ViewModels.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels {
	public class HomeViewModel : BaseViewModel {
		#region FIELDS
		private IEnumerable<Thing> _things;
		private readonly IThingService _thingService;

		#endregion

		#region PROPERTIES
		public IEnumerable<Thing> Things {
			get {
				return this._things;
			}
			set {
				this._things = value;

				this.Notify("Things");
			}
		}

		#endregion

		#region COMMANDS
		public ICommand InitDataCommand { get; set; }

		#endregion

		public HomeViewModel(IThingService thingService) {
			this.InitDataCommand = new RelayedCommand(async (object obj) => await InitDataAsync(), (object obj) => true);
			this._thingService = thingService;
		}

		public async Task InitDataAsync() {
			this.Things = await this._thingService.GetAsync();
		}
	}
}
