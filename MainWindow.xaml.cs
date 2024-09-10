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
		bool readyToShoot;
		int shotReloadValue = 4;
		int shotReloadCount = 0;
		
		RotateTransform playerRotation = new RotateTransform();


		public MainWindow()
		{
			InitializeComponent();

			diplay.Focus();

			playerRotation.CenterX = player.Width / 2;
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

			readyToShoot = true;

			gameTimer.Start();
		}

		private void GameLoop(object sender, EventArgs e)
		{
			HandelInputs();

			HandelPlayer();

			HandelPlayerShots();

			testLabel.Content = "player Momentum: " + playerMomentum + ".";
		}

		private void HandelInputs()
		{

			if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum--; } else if (playerMomentum < 0) { playerMomentum++; } }
			else if (leftDown) { if (playerMomentum > -playerMaxMomentum) { playerMomentum--; } }
			else if (rightDown) { if (playerMomentum < playerMaxMomentum) { playerMomentum++; } }

			if (spaceDown) { if (spaceDown && readyToShoot ){ AddPlayerShot(); } }

		}

		private void HandelPlayer()
		{
			MovePlayer();
			RotatePlayer();
		}

		private void HandelPlayerShots()
		{

			MovePlayerShots();
			RemoveRedundentPlayerShots();
			UpdateReload();


		}

		private void MovePlayerShots()
		{
			foreach (var shot in diplay.Children.OfType<Rectangle>())
			{
				if (shot.Tag == "playerShot") { Canvas.SetTop(shot, Canvas.GetTop(shot) - (shot.Height / 2)); }

			}
		}
		private void RemoveRedundentPlayerShots()
		{

			for (int childIndex = diplay.Children.Count - 1; childIndex >= 0; childIndex--)
			{

				if (diplay.Children[childIndex].GetType() == typeof(Rectangle) &&
					Canvas.GetTop(diplay.Children[childIndex] ) < - 50 )
				{ diplay.Children.Remove(diplay.Children[childIndex]); }
				
			}

		
		}
		private void UpdateReload()
		{
			if (shotReloadCount == 0) { readyToShoot = true; }
			else if (shotReloadCount > 0) { shotReloadCount--; }
			else {  Console.WriteLine("Reaload Error"); }

		}
		


		private void AddPlayerShot()
		{
			Rectangle spawnShot = new Rectangle
			{

				Width = 10,
				Height = 30,
				Fill = Brushes.Red,
				StrokeThickness = 3,
				Stroke = Brushes.Black,
				Tag = "playerShot"

			};

			Canvas.SetLeft(spawnShot,Canvas.GetLeft(player) + (spawnShot.Width/2) );
			Canvas.SetTop(spawnShot, Canvas.GetTop(player) - spawnShot.Height);

			diplay.Children.Add(spawnShot);
			shotReloadCount = shotReloadValue;
			readyToShoot = false;

		}



		private void MovePlayer()
		{

			if (playerMomentum != 0)
			{
				double nextPlayerLeft = Canvas.GetLeft(player) + (playerSpeed * playerMomentum);

				if (nextPlayerLeft < 25) { Canvas.SetLeft(player, 25); }
				else if (nextPlayerLeft > 710) { Canvas.SetLeft(player, 710); }
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