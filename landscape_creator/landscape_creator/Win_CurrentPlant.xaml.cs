using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace landscape_creator
{
	/// <summary>
	/// Логика взаимодействия для Win_CurrentPlant.xaml
	/// </summary>
	public partial class Win_CurrentPlant : Window
	{
		public Win_CurrentPlant(Plant _plant)
		{
			InitializeComponent();
			this.DataContext = _plant;
		}
	}
}
