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
using System.Windows.Shapes;

namespace landscape_creator
{
	/// <summary>
	/// Логика взаимодействия для Win_AddPlant.xaml
	/// </summary>
	public partial class Win_AddPlant : Window
	{
		public Win_AddPlant()
		{
			InitializeComponent();
		}

		private void addPlantButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void plantsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if(plantsListBox.SelectedItem != null)
			{
				var plant = (PlantVariety)plantsListBox.SelectedItem;
				var win = new Win_PlantInfo(plant.Image, plant.FullName, plant.Genus.Name, plant.LifeForm.Name, plant.Sunlight.ToString(), plant.AverageHeight.ToString(), plant.AverageWidth.ToString(), plant.LifeTime.ToString(), plant.TimeToAdult.ToString());
				win.Show();
			}
		}

		private void comboBoxLifeForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void comboBoxGenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void checkGenus_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void checkLifeForm_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void checkGenus_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void checkLifeForm_Unchecked(object sender, RoutedEventArgs e)
		{

		}
	}
}
