﻿using System;
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
		public Win_PlantInfo(PlantVariety _plant)
		{
			InitializeComponent();
			this.DataContext = _plant;
		}
	}
}
