﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
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

		int playerShotImageDelay = 0;

		List<Point> defenceBlockData;

		ImageBrush backgroundImage = new ImageBrush();
		ImageBrush playerImage = new ImageBrush();
		ImageBrush playerShotImage = new ImageBrush();
		//ImageBrush defenceBlockBrush = new ImageBrush();

		
		RotateTransform playerRotation = new RotateTransform();
		public MainWindow()
		{
			InitializeComponent();

			
			backgroundImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\background.png"));
			backgroud.Fill = backgroundImage;

			
			playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo1.png"));
			player.Fill = playerImage;

			defenceBlockData = new List<Point>();
			InitializeDefenceBlocks();
			

			display.Focus();

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

			HandelCollistions();

			testLabel.Content = "player Momentum: " + playerMomentum + ".";
		}

		private void HandelInputs()
		{

			if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum--; } else if (playerMomentum < 0) { playerMomentum++; } }
			else if (leftDown) { if (playerMomentum > -playerMaxMomentum) { playerMomentum--; } }
			else if (rightDown) { if (playerMomentum < playerMaxMomentum) { playerMomentum++; } }

			if (spaceDown) 
			{ if (spaceDown && readyToShoot ){ AddPlayerShot(); } }

		}

		private void HandelPlayer()
		{
			MovePlayer();
			RotatePlayer();
			UpdatePlayerImage();
		}

		private void HandelPlayerShots()
		{

			MovePlayerShots();
			
			RemoveRedundentPlayerShots();
			UpdatePlayerShotImage();
			UpdateReload();


		}

		private void HandelCollistions()
		{
			List<Rectangle> reliventRectangels = display.Children.OfType<Rectangle>().ToList();

			for (int rectangleIndex = reliventRectangels.Count - 1; rectangleIndex >= 0; rectangleIndex--)
			{
				

				if (reliventRectangels[rectangleIndex].Tag == "playerShot")
				{
					Rect shotHitbox = new Rect(Canvas.GetLeft(reliventRectangels[rectangleIndex]), Canvas.GetTop(reliventRectangels[rectangleIndex]),
						reliventRectangels[rectangleIndex].Width, reliventRectangels[rectangleIndex].Height);

					for (int checkRectangleIndex = reliventRectangels.Count - 1; checkRectangleIndex >= 0; checkRectangleIndex--)
					{
						if ((string)reliventRectangels[checkRectangleIndex].Tag == "defenceBlock")
						{
							Rect targetHitbox = new Rect(Canvas.GetLeft(reliventRectangels[checkRectangleIndex]), Canvas.GetTop(reliventRectangels[checkRectangleIndex]),
							reliventRectangels[checkRectangleIndex].Width, reliventRectangels[checkRectangleIndex].Height);


							if (shotHitbox.IntersectsWith(targetHitbox))
							{
								display.Children.Remove(reliventRectangels[rectangleIndex]);
								display.Children.Remove(reliventRectangels[checkRectangleIndex]);
							}
						}
					}

					
				}

			}


		}




		private void MovePlayerShots()
		{
			foreach (var shot in display.Children.OfType<Rectangle>())
			{
				if (shot.Tag == "playerShot") { Canvas.SetTop(shot, Canvas.GetTop(shot) - (shot.Height / 2)); }

			}
		}

		private void UpdatePlayerImage()
		{
			if (playerMomentum > -2 && playerMomentum < 2)
			{
				playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo1.png"));
			}
			else if (playerMomentum > 3 && playerMomentum < 8 || playerMomentum < 3 &&playerMomentum > -8)
			{
				playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo2.png"));
			}
			else if ( playerMomentum > 8 || playerMomentum < -8 )
			{
				playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo3.png"));
			}
		}

		private void RemoveRedundentPlayerShots()
		{

			for (int childIndex = display.Children.Count - 1; childIndex >= 0; childIndex--)
			{

				if (display.Children[childIndex].GetType() == typeof(Rectangle) &&
					Canvas.GetTop(display.Children[childIndex] ) < - 50 )
				{ display.Children.Remove(display.Children[childIndex]); }
				
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
			GetRandomPlayerShotImage();

			Rectangle spawnShot = new Rectangle
			{

				Width = 10,
				Height = 30,
				Fill = playerShotImage,
				
				Tag = "playerShot"

			};

			Canvas.SetLeft(spawnShot,Canvas.GetLeft(player) +(player.Width/2) - (spawnShot.Width/2)  );
			Canvas.SetTop(spawnShot, Canvas.GetTop(player) - spawnShot.Height + 20);

			display.Children.Add(spawnShot);
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





		private void AddDefenceBlock(double positionLeft, double positionTop)
		{

			ImageBrush defenceBlockBrush = new ImageBrush();
			defenceBlockBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\block.png"));

			Rectangle defenceBlock = new Rectangle
			{

				Width = 15,
				Height = 15,
				Fill = defenceBlockBrush,
				Tag = "defenceBlock"

			};

			Canvas.SetLeft(defenceBlock, positionLeft);
			Canvas.SetTop(defenceBlock, positionTop);

			display.Children.Add(defenceBlock);
		}

		private void AddDefenceBlockGroup(double positionLeft, double positionTop)
		{
			
			defenceBlockData.Add(new Point(positionLeft     , positionTop + 20));
			defenceBlockData.Add(new Point(positionLeft + 20, positionTop + 20));

			defenceBlockData.Add(new Point(positionLeft     , positionTop + 40));
			defenceBlockData.Add(new Point(positionLeft + 20, positionTop + 40));

			defenceBlockData.Add(new Point(positionLeft + 20, positionTop));
			defenceBlockData.Add(new Point(positionLeft + 40, positionTop));
			defenceBlockData.Add(new Point(positionLeft + 60, positionTop));

			defenceBlockData.Add(new Point(positionLeft + 40, positionTop + 20));

			defenceBlockData.Add(new Point(positionLeft + 60, positionTop + 20));
			defenceBlockData.Add(new Point(positionLeft + 80, positionTop + 20));

			defenceBlockData.Add(new Point(positionLeft + 60, positionTop + 40));
			defenceBlockData.Add(new Point(positionLeft + 80, positionTop + 40));
		}




		private void InitializeDefenceBlocks() 
		{
			AddDefenceBlockGroup(70, 280);
			AddDefenceBlockGroup(260, 280);
			AddDefenceBlockGroup(440, 280);
			AddDefenceBlockGroup(620, 280);

			foreach (var point in defenceBlockData)
			{
				AddDefenceBlock(point.X,point.Y);
			}
			


			
			


		}

		private void GetRandomPlayerShotImage()
		{

			Random rand = new Random();
		
		    switch (rand.Next(1,4))
			{
				case 1: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot01.png")); break;
				case 2: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot02.png")); break;
				case 3: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot03.png")); break;
				case 4: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot04.png")); break;

				default: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot01.png")); break;
			}

		}

		private void UpdatePlayerShotImage()
		{
			playerShotImageDelay++;

			if(playerShotImageDelay>2)
			{
				playerShotImageDelay = 0;

				List<Rectangle> reliventRectangels = display.Children.OfType<Rectangle>().ToList();
				for (int i = 0; i < reliventRectangels.Count; i++)
				{ 
					if(reliventRectangels[i].Tag == "playerShot")
					{
						GetRandomPlayerShotImage();
						reliventRectangels[i].Fill = playerShotImage;
					}
			
				}

			}
			
		}


	}


}