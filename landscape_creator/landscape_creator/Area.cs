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
		public Point P_lb;
		public Point P_lt;
		public Point P_rt;
		public Point P_rb;
	}
	public struct Polygon
	{
		public List<Point> vertices;
		////type: true - растение, false - другой объект
		//bool type;
	}
	public class Area
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
		public Area()
		{

		}
		public Area(Point p1, Point p2, Point p3, Point p4, int azimuth, int height)
		{
			CreateAreaPosition(p1, p2, p3, p4);
			CreateSunPosition(azimuth, height);
			main = _main;
		}
		public Area(double length, double width, double angle, int azimuth, int height)
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
		private void CreateAreaPosition(Point p1, Point p2, Point p3, Point p4)
		{

		}
		private void CreateAreaPosition(double length, double width, double angle)
		{

		}
		#endregion
		#region Добавление нового объекта
		public void AddObject(LandscapeObject obj)
		{
			//ИД задать
			//obj.point = SearchPlace(obj);
			objects.Add(obj);
			//доб. тень
			//пересчет теней
			//отрисовка
		}
		public List<Point> SearchPlaceOtherObject(Polygon polygon)
		{
			List<Point> points = new List<Point>();
			////
			return points;
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
			//int lf = _plant.plant.LifeFormID;
			int n = objects.Count;
			List<int> index = new List<int>();
			for(int i = 0; i < n; i++)
			{
				if (objects[i] is Plant && objects[i] != _plant)
				{
					Plant _item = (Plant)objects[i];
					double x1 = _plant.point.X, y1 = _plant.point.Y, x2 = _item.point.X, y2 = _item.point.Y;
					int R1 = _plant.plant.LandingRadius.Where(x => x.IDForm == _item.plant.LifeFormID).Select(y => y.Radius).First();
					int R2 = _item.plant.LandingRadius.Where(x => x.IDForm == _plant.plant.LifeFormID).Select(y => y.Radius).First();
					double L1 = R1 + R2;
					double L2 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
					if (L2 < L1)
					{
						((Plant)objects[i]).radiusConflict.Add(_plant);
						_plant.radiusConflict.Add(objects[i]);
					}
				}
				else
				{
					////поиск пересечений с объектами???? смотрим не принадлежит ли центр растения многоугольнику
					//double x1 = ((OtherObject)objects[i]).obj.vertices[0].X, x2 = ((OtherObject)objects[i]).obj.vertices[1].X,
					//	y1 = ((OtherObject)objects[i]).obj.vertices[0].Y, y2 = ((OtherObject)objects[i]).obj.vertices[1].Y,
					//	x3 = ((OtherObject)objects[i]).obj.vertices[2].X, x4 = ((OtherObject)objects[i]).obj.vertices[3].X,
					//	y3 = ((OtherObject)objects[i]).obj.vertices[2].Y, y4 = ((OtherObject)objects[i]).obj.vertices[3].Y;
					//if (x1 == x2 || y1 == y2)
					//{
					//	if(_plant.point.X >= x1 && _plant.point.X <= x4 && _plant.point.Y >= y1)
					//}
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
