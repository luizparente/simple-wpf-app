using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace SimpleWpfApp.Utilities.Converters {
	public class NullToHiddenConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			return value == null ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
