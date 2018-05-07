using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace landscape_creator
{
	public struct CornerPoints
	{
		// l - left, r - right
		// b - bottom, t - top
		public double P_lb;
		public double P_lt;
		public double P_rt;
		public double P_rb;
	}
	public struct Polygon
	{
		List<Point> vertices;
	}
	class Area
	{
		//координаты площадки
		CornerPoints coordinates;
		//список объектов с координатами
		List<object> objects;
		//список теней
		List<Polygon> shadows;
		//координата солнца
		Point3D sun;

		#region Создание площадки
		public Area(double p1, double p2, double p3, double p4, int azimuth, int height)
		{
			CreateAreaPosition(p1, p2, p3, p4);
			CreateSunPosition(azimuth, height);
		}
		public Area(double length, double width, double angle, int azimuth, int height)
		{
			CreateAreaPosition(length, width, angle);
			CreateSunPosition(azimuth, height);
		}
		//метод, определяющий координаты солнца по азимуту и высоте над горизонтом
		private void CreateSunPosition(int azimuth, int height)
		{

		}
		//методы, определяюшие положенние площадки по заданным параметрам
		private void CreateAreaPosition(double p1, double p2, double p3, double p4)
		{

		}
		private void CreateAreaPosition(double length, double width, double angle)
		{

		}
		#endregion
	}
}
