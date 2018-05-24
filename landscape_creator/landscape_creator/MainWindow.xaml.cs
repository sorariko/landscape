using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace landscape_creator
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Area area = new Area();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonAddPlant_Click(object sender, RoutedEventArgs e)
		{

		}

		private void buttonAddOtherObject_Click(object sender, RoutedEventArgs e)
		{
			var addOtherObject = new Win_AddOtherObject(area);
			addOtherObject.Show();
		}

		private void buttonDeleteObject_Click(object sender, RoutedEventArgs e)
		{

		}

		private void buttonListOfObjects_Click(object sender, RoutedEventArgs e)
		{

		}

		private void buttonCurrentPlant_Click(object sender, RoutedEventArgs e)
		{

		}

		private void buttonNewProject_Click(object sender, RoutedEventArgs e)
		{
			var newProject = new Win_CreateArea();
			newProject.Show();
		}
	}
}
