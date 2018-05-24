using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace landscape_creator
{
	class Plant: LandscapeObject
	{
		public PlantVariety plant;
		public List<LandscapeObject> radiusConflict;
		public bool sunlightConflict;
		public bool otherObjectConflict;
		public int currentHeight;
		public int currentWidth;
		public double growthSpeed;
		public Plant(PlantVariety _plant, List<object> objects)
		{
			plant = _plant;
			point = SearchPlace(objects);
		}
	}
}
