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

		int playerSpeed = 2;
		int playerMomentum = 0;
		int playerMaxMomentum = 10;
		RotateTransform playerRotation = new RotateTransform();
		
		public MainWindow()
		{
			InitializeComponent();

			diplay.Focus();

			playerRotation.CenterX = player.Width/2;
			playerRotation.CenterY = player.Height;

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
			MovePlayer();
			RotatePlayer();

			testLabel.Content = "player Momentum: " + playerMomentum + ".";
		}

		private void HandelInputs()
		{
			
			if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum --; }else if (playerMomentum < 0) { playerMomentum ++; } }
			else if (leftDown ) { if (playerMomentum > -playerMaxMomentum ) { playerMomentum -- ; } }
		    else if (rightDown) { if (playerMomentum < playerMaxMomentum  ) { playerMomentum ++ ; } }
			
			if (spaceDown) { HandelSpaceInput(); }

		}

		private void HandelLeftInput() 
		{ 
		 if (!rightDown)
			{
				
				if ( playerMomentum < playerMaxMomentum ) { playerMomentum++; }


			
				//if (Canvas.GetLeft(player) - playerSpeed < 10) { Canvas.SetLeft(player, 10); }
				//else 
				//{ 
				
				//	//Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
				//	RotateTransform rotateTransform1 = new RotateTransform(-5*playerMomentum);
				//	player.RenderTransform = rotateTransform1;
				//	//player.tr
				
				//}
			}
		
		}

		private void HandelRightInput() 
		{

			if (!leftDown)
			{
				if (Canvas.GetLeft(player) + playerSpeed > 800 - player.Width - 30){ Canvas.SetLeft(player, 800 - player.Width - 30); }
				else { Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed); }
			}
		}

		private void HandelSpaceInput() 
		{
		
		
		}

		private void MovePlayer()
		{

			if (playerMomentum != 0)
			{
				double nextPlayerLeft = Canvas.GetLeft(player) + (playerSpeed * playerMomentum);

				if (nextPlayerLeft < 5) { Canvas.SetLeft(player, 5); }
				else if (nextPlayerLeft > 730) { Canvas.SetLeft(player, 730); }
				else { Canvas.SetLeft(player, nextPlayerLeft); }

			}
		}

		private void RotatePlayer()
		{
			playerRotation.Angle = playerMomentum * 3;
			player.RenderTransform = playerRotation;

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