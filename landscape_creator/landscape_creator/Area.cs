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
		public List<Point> vertices;
		////type: true - растение, false - другой объект
		//bool type;
	}
	class Area
	{
		//координаты площадки
		CornerPoints coordinates;
		//список объектов с координатами
		List<LandscapeObject> objects;
		//список теней
		List<Polygon> shadows;
		//координата солнца
		Point3D sun;
		MainWindow main;
		#region Создание площадки
		public Area(double p1, double p2, double p3, double p4, int azimuth, int height, MainWindow _main)
		{
			CreateAreaPosition(p1, p2, p3, p4);
			CreateSunPosition(azimuth, height);
			main = _main;
		}
		public Area(double length, double width, double angle, int azimuth, int height, MainWindow _main)
		{
			CreateAreaPosition(length, width, angle);
			CreateSunPosition(azimuth, height);
			main = _main;
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
		#region Добавление нового объекта
		public void AddObject(LandscapeObject obj)
		{
			obj.point = SearchPlace(obj);
			objects.Add(obj);
			//доб. тень
			//пересчет теней
			//отрисовка
		}
		public Point SearchPlace(LandscapeObject obj)
		{
			Point point = new Point(0,0);
			///////
			return point;
		}
		#endregion
		#region Удаление объекта
		public void DeleteObject(LandscapeObject obj)
		{
			objects.Remove(obj);
			//пересчет теней
			//отрисовка
		}
		#endregion
		#region Изменение времени
		public void TimeChanged()
		{
			int time = main.timeSlider.CurrentTime;
			//поменять все высоты и ширины у растений
			//перестрой теней
			//пересчет теней
			//отрисовка
		}
		#endregion
		public void MoveObject(LandscapeObject obj)
		{
			//проверка радиусов
			//пересчет теней
			//отрисовка
		}
		private void CheckLandingRadius(Plant _plant)
		{
			int lf = _plant.plant.LifeFormID;
			foreach (var item in objects)
			{
				if(item is Plant && item != _plant)
				{
					Plant _item = (Plant)item;
					double x1 = _plant.point.X, y1 = _plant.point.Y, x2 = _item.point.X, y2 = _item.point.Y;
					int R1 = _plant.plant.LandingRadius.Where(x => x.IDForm == _item.plant.LifeFormID).Select(y => y.Radius).First();
					int R2 = _item.plant.LandingRadius.Where(x => x.IDForm == _plant.plant.LifeFormID).Select(y => y.Radius).First();
					double L1 = R1 + R2;
					double L2 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
					if(L2 < L1)
					{
						//добавление в списки
					}
				}
			}
		}
		private void CheckShadows()
		{
			//трудна
		}
		private void CreateShadow(LandscapeObject obj)
		{

		}
		private void SearchIntersection()
		{

		}
		private double PolygonArea(Polygon polygon)
		{
			double s = 0;
			var points = polygon.vertices;
			for (int i = 0; i < points.Count; i++)
			{
				double j;
				if(i != points.Count-1)
					j = (points[i].X + points[i + 1].X) * (points[i].Y - points[i + 1].Y);
				else
					j = (points[i].X + points[0].X) * (points[i].Y - points[0].Y);
				s += j;
			}
			s /= 2;
			return s;
		}
	}
}
