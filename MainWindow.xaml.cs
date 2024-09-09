using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceInvaders_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int refreshRate = 20;
		DispatcherTimer gameTimer = new DispatcherTimer();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{

        }

		private void KeyUpEvent(object sender, KeyEventArgs e)
		{

		}
	}
}