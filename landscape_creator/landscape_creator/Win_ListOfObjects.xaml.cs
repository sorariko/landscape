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
	/// Логика взаимодействия для Win_ListOfObjects.xaml
	/// </summary>
	public struct PlantVarietyInfo
	{
		public string fullName { get; set; }
		public int count { get; set; }
		public int height { get; set; }
		public int width { get; set; }
	}
	public partial class Win_ListOfObjects : Window
	{
		public List<PlantVarietyInfo> PlantsList
		{
			get; set;
		}
		public List<OtherObject> OtherObjectsList
		{
			get; set;
		}
		public Win_ListOfObjects(List<LandscapeObject> objects)
		{
			InitializeComponent();
			OtherObjectsList = objects.Where(x => x is OtherObject).Select(x => (OtherObject)x).ToList();
			PlantsList = CreateListOfPlants(objects.Where(x => x is Plant).Select(x => (Plant)x).ToList());
			this.DataContext = this;
		}
		private List<PlantVarietyInfo> CreateListOfPlants(List<Plant> plants)
		{
			List<PlantVarietyInfo> list = new List<PlantVarietyInfo>();
			foreach (var item in plants.GroupBy(x => x.plant.FullName))
			{
				PlantVarietyInfo pv = new PlantVarietyInfo();
				pv.fullName = item.Key;
				pv.height = item.First().currentHeight;
				pv.width = item.First().currentWidth;
				pv.count = item.Count();
				list.Add(pv);
			}
			return list;
		}
	}
}
