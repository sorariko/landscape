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
		public Polygon obj;
		public int height;
		public int length;
		public int width;
		public string description;
		public OtherObject(Point _p, Polygon _obj, int _height, int _length, int _width, string _desc)
		{
			point = _p;
			obj = _obj;
			height = _height;
			length = _length;
			width = _width;
			description = _desc;
		}
	}
}
