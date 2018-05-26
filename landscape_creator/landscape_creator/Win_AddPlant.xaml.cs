using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
	/// Логика взаимодействия для Win_AddPlant.xaml
	/// </summary>
	public partial class Win_AddPlant : Window, INotifyPropertyChanged
	{
		MainWindow main;
		LandscapeCreatorDBModel context = new LandscapeCreatorDBModel();
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		private ObservableCollection<Genus> genusList;
		public ObservableCollection<Genus> GenusList
		{
			get
			{
				return genusList;
			}
			set
			{
				genusList = value;
				NotifyPropertyChanged();
			}
		}
		private Genus selectedGenus;
		public Genus SelectedGenus
		{
			get
			{
				return selectedGenus;
			}
			set
			{
				selectedGenus = value;
				NotifyPropertyChanged();
			}
		}
		private ObservableCollection<LifeForm> lifeFormList;
		public ObservableCollection<LifeForm> LifeFormList
		{
			get
			{
				return lifeFormList;
			}
			set
			{
				lifeFormList = value;
				NotifyPropertyChanged();
			}
		}
		private LifeForm selectedLifeForm;
		public LifeForm SelectedLifeForm
		{
			get
			{
				return selectedLifeForm;
			}
			set
			{
				selectedLifeForm = value;
				NotifyPropertyChanged();
			}
		}
		private ObservableCollection<PlantVariety> plantList;
		public ObservableCollection<PlantVariety> PlantList
		{
			get
			{
				return plantList;
			}
			set
			{
				plantList = value;
				NotifyPropertyChanged();
			}
		}
		private PlantVariety selectedPlant;
		public PlantVariety SelectedPlant
		{
			get
			{
				return selectedPlant;
			}
			set
			{
				selectedPlant = value;
				NotifyPropertyChanged();
			}
		}
		public Win_AddPlant(MainWindow _main)
		{
			InitializeComponent();
			main = _main;
			this.DataContext = this;
			context.PlantVariety.Load();
			context.Genus.Load();
			context.LifeForm.Load();
			GenusList = context.Genus.Local;
			SelectedGenus = GenusList.First();
			LifeFormList = context.LifeForm.Local;
			selectedLifeForm = LifeFormList.First();
			PlantList = new ObservableCollection<PlantVariety>();
			checkBoxAll.IsChecked = true;
		}

		private void addPlantButton_Click(object sender, RoutedEventArgs e)
		{
			if(SelectedPlant != null)
			{
				var plant = new Plant(SelectedPlant, main.timeSlider.CurrentTime);
				main.area.AddObject(plant);
			}
		}

		private void plantsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if(plantsListBox.SelectedItem != null)
			{
				var plant = (PlantVariety)plantsListBox.SelectedItem;
				var win = new Win_PlantInfo(plant);
				win.Show();
			}
		}

		private void CreatePlantList()
		{
			ObservableCollection<PlantVariety> list = new ObservableCollection<PlantVariety>();
			List<PlantVariety> list1 = new List<PlantVariety>();
			list1 = context.PlantVariety.Local.ToList();
			if(checkBoxAll.IsChecked != true)
			{
				if(checkGenus.IsChecked == true)
				{
					list1 = list1.Where(x => x.Genus == SelectedGenus).Select(x => x).ToList();
				}
				if (checkLifeForm.IsChecked == true)
				{
					list1 = list1.Where(x => x.LifeForm == SelectedLifeForm).Select(x => x).ToList();
				}
			}

			if(textBoxSearch.Text != "")
			{
				list1 = list1.Where(x => x.FullName.ToLower().Contains(textBoxSearch.Text.ToLower()) == true).Select(x => x).ToList();
			}
			PlantList.Clear();
			foreach (var item in list1)
			{
				PlantList.Add(item);
			}
		}
		private void comboBoxLifeForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CreatePlantList();
		}

		private void comboBoxGenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CreatePlantList();
		}

		private void checkGenus_Checked(object sender, RoutedEventArgs e)
		{
			CreatePlantList();
		}

		private void checkLifeForm_Checked(object sender, RoutedEventArgs e)
		{
			CreatePlantList();
		}

		private void checkBoxAll_Checked(object sender, RoutedEventArgs e)
		{
			CreatePlantList();
		}

		private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreatePlantList();
		}
	}
}
