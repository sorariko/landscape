using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace landscape_creator
{
	class OtherObject: LandscapeObject
	{
		Polygon obj;
		int height;
		string description;
		public OtherObject(Polygon _obj, int _height, string _desc, List<object> objects)
		{
			obj = _obj;
			height = _height;
			description = _desc;
			point = SearchPlace(objects);
		}
	}
}
