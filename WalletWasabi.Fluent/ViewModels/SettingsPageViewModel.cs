using ReactiveUI;
using System.Windows.Input;

namespace WalletWasabi.Fluent.ViewModels
{
	public class SettingsPageViewModel : NavBarItemViewModel
	{
		public SettingsPageViewModel(IScreen screen) : base(screen)
		{
			Title = "Settings";

			NextCommand = ReactiveCommand.Create(() => screen.Router.Navigate.Execute(new HomePageViewModel(screen)));

			OpenDialogCommand = ReactiveCommand.Create(async () =>
			{
				var x = new TestDialogViewModel();
				var result = await x.ShowDialogAsync(MainViewModel.Instance);
			});
		}

		public ICommand NextCommand { get; }
		public ICommand OpenDialogCommand { get; }

		public override string IconName => "settings_regular";
	}
}
