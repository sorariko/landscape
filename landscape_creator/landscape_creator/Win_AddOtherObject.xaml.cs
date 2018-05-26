using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace landscape_creator
{
	/// <summary>
	/// Логика взаимодействия для Win_AddOtherObject.xaml
	/// </summary>
	public partial class Win_AddOtherObject : Window
	{
		Area area;
		public Win_AddOtherObject(Area _area)
		{
			InitializeComponent();
			area = _area;
		}
		private void Redrawing()
		{
			////
		}
		private void rb1_1_Checked(object sender, RoutedEventArgs e)
		{
			Redrawing();
		}
		private void buttonAddOtherObject_Click(object sender, RoutedEventArgs e)
		{
			if(textBoxLength.Text == "" || textBoxLength.Text == "0" ||
				textBoxWidth.Text == "" || textBoxWidth.Text == "0" ||
				textBoxHeight.Text == "" || textBoxHeight.Text == "0" || (textBoxAngle.Text == "" && rb2.IsChecked == true))
			{
				MessageBox.Show("Неверно введены данные!");
				return;
			}

			int length = int.Parse(textBoxLength.Text);
			if(rb1_1.IsChecked != true)
			{
				length *= 100;
			}
			int height = int.Parse(textBoxHeight.Text);
			if (rb3_1.IsChecked != true)
			{
				height *= 100;
			}
			int width = int.Parse(textBoxWidth.Text);
			if (rb2_1.IsChecked != true)
			{
				width *= 100;
			}
			string desc = textBoxDesc.Text;
			Polygon polygon;
			polygon.vertices = CreateNewPolygon(length, width);
			List<Point> points = area.SearchPlaceOtherObject(polygon);
			Point point = points[0];
			points.RemoveAt(0);
			polygon.vertices = points;
			OtherObject obj = new OtherObject(point, polygon, height,length,width,desc);
			area.AddObject(obj);
		}
		private List<Point> CreateNewPolygon(int length, int width)
		{
			List<Point> points = new List<Point>();
			Point p1 = new Point(0, 0);
			Point p2 = new Point(0, width);
			Point p3 = new Point(length, width);
			Point p4 = new Point(length, 0);
			if(rb2.IsChecked == true)
			{
				int angle = int.Parse(textBoxAngle.Text);

				p2.X = p2.X * Math.Cos(angle) + p2.Y * Math.Sin(angle);
				p2.Y = -p2.X * Math.Sin(angle) + p2.Y * Math.Cos(angle);

				p3.X = p3.X * Math.Cos(angle) + p3.Y * Math.Sin(angle);
				p3.Y = -p3.X * Math.Sin(angle) + p3.Y * Math.Cos(angle);

				p4.X = p4.X * Math.Cos(angle) + p4.Y * Math.Sin(angle);
				p4.Y = -p4.X * Math.Sin(angle) + p4.Y * Math.Cos(angle);
			}
			points.Add(p1); points.Add(p2); points.Add(p3); points.Add(p4);
			return points;
		}
		private void textBoxAngle_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
				e.Handled = true;
		}
		private void textBoxAngle_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (((TextBox)sender).Text.IndexOf(" ") != -1)
			{
				((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).Text.IndexOf(" "));
				((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
			}

			Redrawing();
		}
	}
}
