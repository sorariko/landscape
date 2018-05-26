using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace landscape_creator
{
	public class OtherObject: LandscapeObject
	{
		public Polygon obj { get; set; }
		public int height { get; set; }
		public int length { get; set; }
		public int width { get; set; }
		public string description { get; set; }
		public OtherObject()
		{

		}
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
