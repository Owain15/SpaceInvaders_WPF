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

		bool leftDown, rightDown, spaceDown;

		int playerSpeed = 10;
		int playerMomentum = 0;
		
		public MainWindow()
		{
			InitializeComponent();

			diplay.Focus();

			gameTimer.Tick += GameLoop;
			gameTimer.Interval = TimeSpan.FromMilliseconds(refreshRate);

			StartGame();
			

		}

		private void StartGame()
		{
			leftDown = false;
			rightDown = false;
			spaceDown = false;

			gameTimer.Start();
		}

		private void GameLoop(object sender, EventArgs e)
		{
			HandelInputs();

		}

		private void HandelInputs()
		{
			if (leftDown ) { HandelLeftInput();  }
			if (rightDown) { HandelRightInput(); }
			if (spaceDown) { HandelSpaceInput(); }
		}

		private void HandelLeftInput() 
		{ 
		 if (!rightDown)
			{
				if (Canvas.GetLeft(player) - playerSpeed < 10) { Canvas.SetLeft(player, 10); }
				else { Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed); }
			}
		
		}

		private void HandelRightInput() 
		{

			if (!leftDown)
			{
				if (Canvas.GetLeft(player) + playerSpeed > 800 - player.Width - 30)
				{ Canvas.SetLeft(player, 800 - player.Width - 30); }
				else { Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed); }
			}
		}

		private void HandelSpaceInput() 
		{
		
		
		}

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Left)  { leftDown  = true; }
			if (e.Key == Key.Right) { rightDown = true; }
			if (e.Key == Key.Space) { spaceDown = true; }
		}

		private void KeyUpEvent(object sender, KeyEventArgs e)
		{

			if (e.Key == Key.Left)  { leftDown  = false; }
			if (e.Key == Key.Right) { rightDown = false; }
			if (e.Key == Key.Space) { spaceDown = false; }

		}
	}
}