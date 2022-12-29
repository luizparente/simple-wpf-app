using Application.Interfaces;
using Domain.Models.Domain;
using SimpleWpfApp.Commands;
using SimpleWpfApp.Commands.Interfaces;
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

		#endregion

		#region SERVICES
		private readonly IThingService _thingService;
		private readonly IDialogService _dialogService;

		#endregion

		#region PROPERTIES
		public ObservableCollection<Thing> Things {
			get => this._things;
			set => this.SetAndNotify(ref this._things, value);
		}

		public Thing SelectedThing {
			get => this._selectedThing;
			set => this.SetAndNotify(ref this._selectedThing, value);
		}

		public Thing NewThing {
			get => this._newThing;
			set => this.SetAndNotify(ref this._newThing, value);
		}

		#endregion

		#region COMMANDS
		public ICommand InitDataCommand { get; set; }
		public IRelayedCommand CreateCommand { get; set; }
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
			this.CreateCommand = new RelayedCommand(async _ => await this.Create(), _ => this.CanCreate());
			this.UpdateCommand = new RelayedCommand(async _ => await this.Update(), _ => true);
			this.ResetCommand = new RelayedCommand(this.Reset, _ => true);
		}

		public async Task InitDataAsync() {
			this.GetNewThing();

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
			this.NewThing.OnUpdate += RefreshCanCreate;
		}

		private async Task Create() {
			if (this.NewThing == null)
				return;

			try {
				await this._thingService.CreateAsync(this.NewThing);
				var things = await this._thingService.GetAsync();
				this.Things = new ObservableCollection<Thing>(things);

				this.Reset(null);
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}
		}

		private async Task Update() {
			if (this.SelectedThing == null)
				return;

			try {
				await this._thingService.UpdateAsync(this.SelectedThing);

				var things = await this._thingService.GetAsync();
				this.Things = new ObservableCollection<Thing>(things);

				string idBuffer = this.SelectedThing.ThingGuid;
				this.SelectedThing = await this._thingService.GetAsync(idBuffer);
			}
			catch (Exception e) {
				this._dialogService.ShowDialog(e);
			}
		}

		private bool CanCreate() {
			return !string.IsNullOrWhiteSpace(this.NewThing?.SomeProperty);
		}

		private void Reset(object obj) {
			this.GetNewThing();
			this.RefreshCanCreate();
		}

		private void RefreshCanCreate() {
			this.CreateCommand.TriggerCanExecuteChanged();
		}
	}
}
