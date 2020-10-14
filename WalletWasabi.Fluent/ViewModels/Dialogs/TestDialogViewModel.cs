using System.Windows.Input;
using ReactiveUI;

namespace WalletWasabi.Fluent.ViewModels.Dialogs
{
	public class TestDialogViewModel : DialogViewModelBase<bool>
	{
		private string _message;

		public TestDialogViewModel(string message)
		{
			_message = message;

			CancelCommand = ReactiveCommand.Create(() => Close(false));
			ConfirmCommand = ReactiveCommand.Create(() => Close(true));
		}

		public string Message
		{
			get => _message;
			set => this.RaiseAndSetIfChanged(ref _message, value);
		}

		public ICommand CancelCommand { get; }
		public ICommand ConfirmCommand { get; }

		protected override void OnDialogClosed()
		{
		}
	}
}