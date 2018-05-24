using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
	/// Логика взаимодействия для Win_SunPositionList.xaml
	/// </summary>
	public partial class Win_SunPositionList : Window, INotifyPropertyChanged
	{
		Win_CreateArea createArea;
		LandscapeCreatorDBModel context = new LandscapeCreatorDBModel();
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		private ObservableCollection<SunPosition> sunPositions;
		public ObservableCollection<SunPosition> SunPositions
		{
			get
			{
				return sunPositions;
			}
			set
			{
				sunPositions = value;
				NotifyPropertyChanged();
			}
		}
		private SunPosition selectedSunPosition;
		public SunPosition SelectedSunPosition
		{
			get
			{
				return selectedSunPosition;
			}
			set
			{
				selectedSunPosition = value;
				NotifyPropertyChanged();
			}
		}
		public Win_SunPositionList(Win_CreateArea _createArea)
		{
			InitializeComponent();
			createArea = _createArea;
			this.DataContext = this;
			context.SunPosition.Load();
			SunPositions = context.SunPosition.Local;
			SelectedSunPosition = SunPositions.First();
		}

		private void buttonSelectSunPosition_Click(object sender, RoutedEventArgs e)
		{
			if(SelectedSunPosition != null)
			{
				createArea.textBlockSunPositionName.Text = SelectedSunPosition.Name;
				createArea.sunPositionFromList = SelectedSunPosition;
			}
			this.Close();
		}
		
	}
}
