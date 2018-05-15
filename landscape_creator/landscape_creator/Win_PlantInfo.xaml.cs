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
	/// Логика взаимодействия для Win_PlantInfo.xaml
	/// </summary>
	public partial class Win_PlantInfo : Window
	{
		public Win_PlantInfo(string imagePath, string name, string i1, string i2, string i3, string i4, string i5, string i6, string i7)
		{
			InitializeComponent();
			//if (imagePath != "")
			plantName.Text = "Название: " + name;
			inf1.Text = i1;
			inf2.Text = i2;
			inf3.Text = i3;
			inf4.Text = i4;
			inf5.Text = i5;
			inf6.Text = i6;
			inf7.Text = i7;
		}
	}
}
