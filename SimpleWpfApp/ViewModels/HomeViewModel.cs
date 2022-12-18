using Application.Interfaces;
using Domain.Models.Domain;
using SimpleWpfApp.Commands;
using SimpleWpfApp.Utilities.Interfaces;
using SimpleWpfApp.ViewModels.Abstract;
using System;
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
		private readonly IDialogService _dialogService;

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

		public HomeViewModel(IThingService thingService, 
							 IDialogService dialogService,
							 SignOutCommand signOutCommand) {
			this._thingService = thingService;
			this._dialogService = dialogService;
			this.SignOutCommand = signOutCommand;
			this.InitDataCommand = new RelayedCommand(async _ => await InitDataAsync(), _ => true);
			this.CreateCommand = new RelayedCommand(Create, _ => true);
			this.UpdateCommand = new RelayedCommand(Update, _ => true);
			this.ResetCommand = new RelayedCommand(Reset, _ => true);
		}

		public async Task InitDataAsync() {
			GetNewThing();
			
			try {
				var things = await this._thingService.GetAsync();
				this.Things = new ObservableCollection<Thing>(things);
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}
		}

		private void GetNewThing() {
			this.NewThing = new Thing();
			this.NewThing.OnUpdate += CheckCanCreate;
		}

		private void Create(object obj) {
			if (this.NewThing == null)
				return;

			try {
				Task.Run(async () => {
					await this._thingService.CreateAsync(this.NewThing);
					var things = await this._thingService.GetAsync();
					this.Things = new ObservableCollection<Thing>(things);
					this.Reset(null);
				});
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}
		}

		private void Update(object obj) {
			if (this.SelectedThing == null)
				return;

			try {
				Task.Run(async () => {
					await this._thingService.UpdateAsync(this.SelectedThing);
					var things = await this._thingService.GetAsync();
					this.Things = new ObservableCollection<Thing>(things);
					string idBuffer = this.SelectedThing.ThingGuid;
					this.SelectedThing = await this._thingService.GetAsync(idBuffer);
				});
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}
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
