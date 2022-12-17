using Application.Interfaces;
using Domain.Models.Domain;
using SimpleWpfApp.Commands;
using SimpleWpfApp.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModels {
	public class HomeViewModel : BaseViewModel {
		#region FIELDS
		private ObservableCollection<Thing> _things;
		private Thing _selectedThing;
		private Thing _newThing;
		private bool _canCreate;
		private bool _canUpdate;

		#endregion

		#region SERVICES
		private readonly IThingService _thingService;

		#endregion

		#region PROPERTIES
		public ObservableCollection<Thing> Things {
			get {
				return this._things;
			}
			set {
				this._things = value;

				this.Notify("Things");
			}
		}

		public Thing SelectedThing {
			get {
				return this._selectedThing;
			}
			set {
				this._selectedThing = value;
				this.CheckCanUpdate();

				this.Notify("SelectedThing");
			}
		}

		public Thing NewThing {
			get {
				return this._newThing;
			}
			set {
				this._newThing = value;

				this.Notify("NewThing");
			}
		}

		public bool CanCreate { 
			get {
				return this._canCreate;
			}
			set {
				this._canCreate = value;

				this.Notify("CanCreate");
			}
		}

		public bool CanUpdate {
			get {
				return this._canUpdate;
			}
			set {
				this._canUpdate = value;

				this.Notify("CanUpdate");
			}
		}

		#endregion

		#region COMMANDS
		public ICommand InitDataCommand { get; set; }
		public ICommand CreateCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand ResetCommand { get; set; }
		public ICommand SignOutCommand { get; set; }

		#endregion

		public HomeViewModel(IThingService thingService, SignOutCommand signOutCommand) {
			this._thingService = thingService;
			this.SignOutCommand = signOutCommand;
			this.InitDataCommand = new RelayedCommand(async _ => await InitDataAsync(), _ => true);
			this.CreateCommand = new RelayedCommand(Create, _ => true);
			this.UpdateCommand = new RelayedCommand(Update, _ => true);
			this.ResetCommand = new RelayedCommand(Reset, _ => true);
		}

		public async Task InitDataAsync() {
			GetNewThing();
			this.Things = new ObservableCollection<Thing>(await this._thingService.GetAsync());
		}

		private void GetNewThing() {
			this.NewThing = new Thing();
			this.NewThing.OnUpdate += CheckCanCreate;
		}

		private void Create(object obj) {
			if (this.NewThing == null)
				return;

			Task.Run(async () => {
				await this._thingService.CreateAsync(this.NewThing);
				this.Things = new ObservableCollection<Thing>(await this._thingService.GetAsync());
				this.Reset(null);
			});
		}

		private void Update(object obj) {
			if (this.SelectedThing == null)
				return;

			Task.Run(async () => {
				await this._thingService.UpdateAsync(this.SelectedThing);
				this.Things = new ObservableCollection<Thing>(await this._thingService.GetAsync());
				string idBuffer = this.SelectedThing.ThingGuid;
				this.SelectedThing = await this._thingService.GetAsync(idBuffer);
			});
		}

		private void CheckCanCreate() {
			this.CanCreate = !string.IsNullOrWhiteSpace(this.NewThing.SomeProperty);
		}

		private void CheckCanUpdate() {
			this.CanUpdate = this.SelectedThing != null;
		}

		private void Reset(object obj) {
			this.GetNewThing();
			this.CheckCanCreate();
		}
	}
}
