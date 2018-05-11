using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace landscape_creator
{
	/// <summary>
	/// Логика взаимодействия для TimeSlider.xaml
	/// </summary>
	public partial class TimeSlider : UserControl, INotifyPropertyChanged
	{
		private int currentTime;
		private int backTime;
		private int nextTime;
		private int step;
		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public int CurrentTime
		{
			get { return currentTime; }
			set
			{
				if (value < 0)
					currentTime = 0;
				else
					currentTime = value;
				RaisePropertyChanged("CurrentTime");
			}
		}
		public int BackTime
		{
			get { return backTime; }
			set
			{
				if (value < 0)
					backTime = 0;
				else
					backTime = value;
				RaisePropertyChanged("BackTime");
			}
		}
		public int NextTime
		{
			get { return nextTime; }
			set
			{
				if (value < 0)
					nextTime = 0;
				else
					nextTime = value;
				RaisePropertyChanged("NextTime");
			}
		}
		public TimeSlider()
		{
			InitializeComponent();
			DataContext = this;
			CurrentTime = 0;
			stepTextBox.Text = "1";
			//stepComboBox.SelectedIndex = 0;
			//startTimeComboBox.SelectedIndex = 0;     //???????????????????????? 
		}

		private void timeNext_Click(object sender, RoutedEventArgs e)
		{
			timeChanged(1);
		}
		private void timeBack_Click(object sender, RoutedEventArgs e)
		{
			timeChanged(-1);
		}
		private void timeChanged(int mode)
		{
			if(mode == -1)
			{
				CurrentTime -= step;
				NextTime = CurrentTime + step;
				BackTime = CurrentTime - step;
			}
			else
			{
				CurrentTime += step;
				NextTime = CurrentTime + step;
				BackTime = CurrentTime - step;
			}
		}
		private void stepTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (stepTextBox.Text.IndexOf(" ") != -1)
			{
				stepTextBox.Text = stepTextBox.Text.Remove(stepTextBox.Text.IndexOf(" "));
				stepTextBox.SelectionStart = stepTextBox.Text.Length;
			}
			if (stepTextBox.Text != "")
			{
				stepChanged();
			}
		}
		private void stepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			stepChanged();
		}
		private void stepChanged()
		{
			int tmp = 1;
			if (stepComboBox.SelectedIndex == 1)
				tmp = 30;
			else if (stepComboBox.SelectedIndex == 2)
				tmp = 365;
			step = int.Parse(stepTextBox.Text) * tmp;
			BackTime = CurrentTime - step;
			NextTime = CurrentTime + step;
		}
		private void stepTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
				e.Handled = true;
		}
		
		private void startTimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (stepTextBox.Text.IndexOf(" ") != -1)
			{
				stepTextBox.Text = stepTextBox.Text.Remove(stepTextBox.Text.IndexOf(" "));
				stepTextBox.SelectionStart = stepTextBox.Text.Length;
			}
			if (startTimeTextBox.Text == "")
				startTimeTextBox.Text = CurrentTime.ToString();
			else
			{
				startTimeChanged();
			}
		}

		private void startTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			startTimeChanged();
		}
		private void startTimeChanged()
		{
			int tmp = 1;
			if (startTimeComboBox.SelectedIndex == 1)
				tmp = 30;
			else if (startTimeComboBox.SelectedIndex == 2)
				tmp = 365;
			CurrentTime = int.Parse(startTimeTextBox.Text) * tmp;
			BackTime = CurrentTime - step;
			NextTime = CurrentTime + step;
		}
	}
}
