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
	/// Логика взаимодействия для Win_CreateArea.xaml
	/// </summary>
	public partial class Win_CreateArea : Window
	{
		MainWindow main;
		public Win_CreateArea(MainWindow _main)
		{
			InitializeComponent();
			main = _main;
		}
		public SunPosition sunPositionFromList;
		private void buttonListSun_Click(object sender, RoutedEventArgs e)
		{
			var sunPositionList = new Win_SunPositionList(this);
			sunPositionList.Show();
		}
		private bool Check1()
		{
			if(rb2_1.IsChecked == true)
			{
				string[] a1 = new string[] { textBoxLB_X.Text, textBoxLB_Y.Text, textBoxLT_X.Text, textBoxLT_Y.Text, textBoxRT_X.Text, textBoxRT_Y.Text, textBoxRB_X.Text, textBoxRB_X.Text};
				if (a1.Where(x => x == "" || x == "-").Count() != 0)
				{
					MessageBox.Show("Некорректные данные! Заполните координаты правильно.");
					return false;
				}
				int[] a2 = new int[8];
				for (int i = 0; i < 8; i++)
				{
					a2[i] = int.Parse(a1[i]);
				}
				int[] a2_1 = new int[] { a2[0], a2[2], a2[4], a2[6] };
				int[] a2_2 = new int[] { a2[1], a2[3], a2[5], a2[7]};
				if(a2_1.Where(x => x < -180 || x > 180).Count() != 0)
				{
					MessageBox.Show("Некорректные данные! Широта координат должна принадлежать интервалу от -180 до 180 градусов.");
					return false;
				}
				if (a2_2.Where(x => x < -90 || x > 90).Count() != 0)
				{
					MessageBox.Show("Некорректные данные! Долгота координат должна принадлежать интервалу от -180 до 180 градусов.");
					return false;
				}
				if (a2.Where(x => x < -180 || x > 180).Count() != 0)
				{
					MessageBox.Show("Некорректные данные! Координаты должны принадлежать интервалу от -90 до 90 градусов.");
					return false;
				}
				if (a2[3] < a2[1] || a2[4] < a2[2] || a2[5] < a2[7] || a2[6] < a2[0])
				{
					MessageBox.Show("Некорректные данные! Введите верные координаты поля.");
					return false;
				}
			}
			return true;
		}
		private bool Check2()
		{
			if (rb2_2.IsChecked == true)
			{
				if(textBoxLength.Text == "" || textBoxWidth.Text == "" || textBoxAngle.Text == "")
				{
					MessageBox.Show("Некорректные данные! Стороны и угол поворота не должны быть пустыми.");
					return false;
				}
				if(textBoxLength.Text == "0" || textBoxWidth.Text == "0")
				{
					MessageBox.Show("Некорректные данные! Стороны не должны быть равными 0.");
					return false;
				}
				if(int.Parse(textBoxAngle.Text) > 180 || int.Parse(textBoxAngle.Text) < -180)
				{
					MessageBox.Show("Некорректные данные! Угол поворота должен принадлежать интервалу от -180 до 180 градусов.");
					return false;
				}
			}
			return true;
		}
		private bool Check3()
		{
			if(rb1_1.IsChecked == true)
			{
				if(sunPositionFromList == null)
				{
					MessageBox.Show("Некорректные данные! Задайте из списка азимут и высоту солнца над горизонтом.");
					return false;
				}
			}
			return true;
		}
		private bool Check4()
		{
			if(rb1_2.IsChecked == true)
			{
				if(textBoxAzimuth.Text == "" || textBoxHeigthHorizon.Text == "")
				{
					MessageBox.Show("Некорректные данные! Задайте азимут и высоту солнца над горизонтом.");
					return false;
				}
				if(int.Parse(textBoxAzimuth.Text) < 0 || int.Parse(textBoxAzimuth.Text) > 360)
				{
					MessageBox.Show("Некорректные данные! Азимут должен принадлежать интервалу от 0 до 360 градусов.");
					return false;
				}
				if(int.Parse(textBoxHeigthHorizon.Text) < -90 || int.Parse(textBoxHeigthHorizon.Text) > 90)
				{
					MessageBox.Show("Некорректные данные! Высота над горизонтом должна принадлежать интервалу от -90 до 90 градусов.");
					return false;
				}
			}
			return true;
		}
		private void buttonCreateArea_Click(object sender, RoutedEventArgs e)
		{
			bool c1 = Check1(), c2 = Check2(), c3 = Check3(), c4 = Check4();
			if(c1 && c2 && c3 && c4)
			{
				Point p1 = new Point(int.Parse(textBoxLB_X.Text), int.Parse(textBoxLB_Y.Text)),
					p2 = new Point(int.Parse(textBoxLT_X.Text), int.Parse(textBoxLT_Y.Text)),
					p3 = new Point(int.Parse(textBoxRT_X.Text), int.Parse(textBoxRT_Y.Text)),
					p4 = new Point(int.Parse(textBoxRB_X.Text), int.Parse(textBoxRB_Y.Text));
				int length = int.Parse(textBoxLength.Text), width = int.Parse(textBoxWidth.Text), angle = int.Parse(textBoxAngle.Text);
				if (rb3_2.IsChecked == true)
					length *= 100;
				if (rb4_2.IsChecked == true)
					width *= 100;
				int azimuth = int.Parse(textBoxAzimuth.Text), heightHorizon = int.Parse(textBoxHeigthHorizon.Text);

				if(rb2_1.IsChecked == true && rb1_1.IsChecked == true)
				{
					main.area = new Area(p1, p2, p3, p4, sunPositionFromList.Azimuth, sunPositionFromList.HeightAboveHorizon);
				}
				if(rb2_1.IsChecked == true && rb1_2.IsChecked == true)
				{
					main.area = new Area(p1, p2, p3, p4, azimuth, heightHorizon);
				}
				if (rb2_2.IsChecked == true && rb1_1.IsChecked == true)
				{
					main.area = new Area(length, width, angle,sunPositionFromList.Azimuth,sunPositionFromList.HeightAboveHorizon);
				}
				if (rb2_1.IsChecked == true && rb1_2.IsChecked == true)
				{
					main.area = new Area(length, width, angle, azimuth, heightHorizon);
				}
			}
		}

		private void textBoxLT_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0) && (e.Text[0] != '-' || ((TextBox)sender).SelectionStart != 0))
				e.Handled = true;
		}

		private void textBoxLT_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (((TextBox)sender).Text.IndexOf(" ") != -1)
			{
				((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).Text.IndexOf(" "));
				((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
			}
		}

		private void textBoxLength_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
				e.Handled = true;
		}
	}
}
