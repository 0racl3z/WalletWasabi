using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using WalletWasabi.Gui.ViewModels.Validation;
using WalletWasabi.Models;

namespace WalletWasabi.Gui.ViewModels
{
	public class ViewModelBase : ReactiveObject, INotifyDataErrorInfo
	{
		public ViewModelBase()
		{
			var vmc = Validator.PropertiesWithValidation(this).ToList();
			if (vmc.Count == 0)
			{
				return;
			}

			ValidationMethodCache = vmc;
		}

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		private List<(string propertyName, MethodInfo mInfo)> ValidationMethodCache { get; }

		public bool HasErrors => Validator.ValidateAllProperties(this, ValidationMethodCache).HasErrors;

		public IEnumerable GetErrors(string propertyName)
		{
			var error = Validator.ValidateProperty(this, propertyName, ValidationMethodCache);

			if (error.HasErrors)
			{
				return error;
			}

			return ErrorDescriptors.Empty;
		}

		protected void NotifyErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}
	}
}
