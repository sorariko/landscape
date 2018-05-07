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
		PlantVariety plant;
		List<object> radiusConflict;
		bool sunlightConflict;
		public Plant(PlantVariety _plant, List<object> objects)
		{
			plant = _plant;
			point = SearchPlace(objects);
		}
	}
}
