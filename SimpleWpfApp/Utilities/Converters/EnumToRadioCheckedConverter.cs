using Domain.Models.Domain;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleWpfApp.Utilities.Converters {
	public class EnumToRadioCheckedConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			ThingType type = (ThingType)value;
			int option = int.Parse(parameter?.ToString());

			return (int)type == option;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return (ThingType)int.Parse(parameter?.ToString());
		}
	}
}
