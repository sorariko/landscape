using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace landscape_creator
{
	abstract public class LandscapeObject
	{
		public int id { get; set; }
		public Point point;
		public Point SearchPlace(List<object> objects)
		{
			Point point = new Point(0, 0);
			return point;
		}
	}
}
