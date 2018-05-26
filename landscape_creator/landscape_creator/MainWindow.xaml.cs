using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		LandscapeCreatorDBModel context = new LandscapeCreatorDBModel();
		public Area area = new Area();
		public MainWindow()
		{
			InitializeComponent();
			LoadDataBase();
		}
		private void LoadDataBase()
		{
			context.PlantVariety.Load();
		}
		private void buttonAddPlant_Click(object sender, RoutedEventArgs e)
		{
			var addPlant = new Win_AddPlant(this);
			addPlant.Show();
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
			//тест-------------------------
			List<LandscapeObject> list = new List<LandscapeObject>();

			int i = 0;
			foreach (var item in context.PlantVariety.Local)
			{
				Plant p = new Plant(item, 0);
				p.id = ++i;
				list.Add(p);
				p = new Plant(item, 0);
				p.id = ++i;
				list.Add(p);
			}

			OtherObject o1 = new OtherObject();
			o1.description = "vbuuvbwv"; o1.height = 10; o1.width = 10; o1.length = 10;
			list.Add(o1);

			//----------------------------------

			var listOfObjects = new Win_ListOfObjects(list);
			listOfObjects.Show();
		}

		private void buttonCurrentPlant_Click(object sender, RoutedEventArgs e)
		{
			//тест----------------------------------
			PlantVariety var = context.PlantVariety.Local.First();
			Plant p = new Plant(var, 0);
			p.id = 1;
			PlantVariety var1 = context.PlantVariety.Local[1];
			Plant p1 = new Plant(var1, 0);
			p1.id = 2;
			//p.otherObjectDescription = "soygeruiur";
			p.sunlightConflict = true;
			p.radiusConflict = new List<LandscapeObject>();
			p.radiusConflict.Add(p1);

			//-------------------------------------------

			var currentPlant = new Win_CurrentPlant(p);
			currentPlant.Show();
		}

		private void buttonNewProject_Click(object sender, RoutedEventArgs e)
		{
			var newProject = new Win_CreateArea(this);
			newProject.Show();
		}
	}
}
