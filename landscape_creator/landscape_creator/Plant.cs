using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace landscape_creator
{
	public class Plant: LandscapeObject
	{
		public PlantVariety plant { get; set; }
		public List<LandscapeObject> radiusConflict { get; set; }
		public bool sunlightConflict { get; set; }
		public bool otherObjectConflict { get; set; }
		public string otherObjectDescription { get; set; }
		public int currentHeight { get; set; }
		public int currentWidth { get; set; }
		public double growthSpeed { get; set; }
		public Plant(PlantVariety _plant, int days)
		{
			plant = _plant;
			//вычислить текущие данные и прочее
			//point = SearchPlace(objects);
		}
	}
}
