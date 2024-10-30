using SpaceInvaders_WPF.Code.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace SpaceInvaders_WPF.Code
{
    class Game
    {
      
		//public Canvas display;

        public bool isRunning;

        public Player player;

		public Inputs input;

		public EnemyGroup enemys;

        public List<DefenceBlock> defenceBlockList;


        
        public Game( Inputs input)
        { 
            isRunning = false;

			this.input = input;

            player = new Player();

            enemys = new EnemyGroup();

            defenceBlockList = new List<DefenceBlock>();



        }

		


		

		private void UpdateGameState()
		{

			//HandelPlayer()
			player.UpdateData(input);
			
			//HandelPlayerShots();
			player.UpdateShotData();

			//HandelEnemys();
			enemys.UpdatePositions();
			

			//HandelCollistions();

			
		}

		public Canvas RunGameLoopReturnNextCanvas(Canvas display)
		{
			
			display.Children.Clear();

			UpdateGameState();

			display = RenderCanvas(display);

			return display;
		}
		private Canvas RenderCanvas(Canvas display) 
		{

			RenderPlayer(display);
			RenderPlayerShots(display);
			RenderEnemys(display);

			return display;
		
		}
		
		private void RenderPlayer(Canvas display)
		{
			Rectangle ship = new Rectangle
			{ 
				Height = player.Height,
				Width = player.Width,
				Fill = Brushes.Aqua
			};
			
			display.Children.Add(ship);
			
			Canvas.SetLeft(ship,player.Left);
			Canvas.SetTop(ship, player.Top);

		
			//Rotation.CenterX = ship.Width / 2;
			//Rotation.CenterY = ship.Height;
			ship.RenderTransform = player.Rotation;
		
		}
		private void RenderEnemys(Canvas display)
		{
			foreach (Enemy enemy in enemys.UnitList)
			{ 
				Rectangle ship = new Rectangle
				{
					Height = enemy.Height,
					Width = enemy.Width,
					Fill = Brushes.Red
				};

				display.Children.Add(ship);

				Canvas.SetLeft(ship, enemy.Left);
				Canvas.SetTop(ship, enemy.Top);


				////Rotation.CenterX = ship.Width / 2;
				////Rotation.CenterY = ship.Height;
				ship.RenderTransform = enemy.Rotation;
			
			}
		

		}
		private void RenderPlayerShots(Canvas display)
		{
			foreach(Shot shot in player.shotList)
			{
				Rectangle shotBox = new Rectangle
				{
					Height = shot.Height,
					Width = shot.Width,
					Fill = Brushes.Aqua
				};

				display.Children.Add(shotBox);

				shotBox.RenderTransform = shot.Rotation;
				
				Canvas.SetLeft(shotBox, shot.Left);
				Canvas.SetTop(shotBox, shot.Top);
			}

			////Rotation.CenterX = ship.Width / 2;
			////Rotation.CenterY = ship.Height;
			//ship.RenderTransform = player.Rotation;

		}

		private void HandelInputs()
		{

			//if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum--; } else if (playerMomentum < 0) { playerMomentum++; } }
			//else if (leftDown) { if (playerMomentum > -playerMaxMomentum) { playerMomentum--; } }
			//else if (rightDown) { if (playerMomentum < playerMaxMomentum) { playerMomentum++; } }

		//	//if (spaceDown)
		//	//{ if (spaceDown && readyToShoot) { AddPlayerShot(); } }

		}

		private void HandelPlayer()
		{
			//MovePlayer();
			//RotatePlayer();
			//UpdatePlayerImage();
		}

		private void HandelEnemys()
		{
			//List<Rectangle> enemyShips = display.Children.OfType<Rectangle>().Where(x => x.Tag == "enemy").ToList();

			//foreach (Rectangle rectangle in enemyShips)
			//{
			//	double left = Canvas.GetLeft(rectangle);

			//	if (left < 50) { enemyMove = 10; }
			//	else if (left > 700) { enemyMove = -10; }


			//	Canvas.SetLeft(rectangle, left + enemyMove);
			}

		private void HandelPlayerShots()
		{

			//MovePlayerShots();

			//RemoveRedundentPlayerShots();
			//UpdatePlayerShotImage();
			//UpdateReload();


		}

		private void HandelCollistions()
		{
			//List<Rectangle> reliventRectangels = display.Children.OfType<Rectangle>().ToList();

			//for (int rectangleIndex = reliventRectangels.Count - 1; rectangleIndex >= 0; rectangleIndex--)
			//{


			//	if (reliventRectangels[rectangleIndex].Tag == "playerShot")
			//	{
			//		Rect shotHitbox = new Rect(Canvas.GetLeft(reliventRectangels[rectangleIndex]), Canvas.GetTop(reliventRectangels[rectangleIndex]),
			//			reliventRectangels[rectangleIndex].Width, reliventRectangels[rectangleIndex].Height);

			//		for (int checkRectangleIndex = reliventRectangels.Count - 1; checkRectangleIndex >= 0; checkRectangleIndex--)
			//		{
			//			if ((string)reliventRectangels[checkRectangleIndex].Tag == "defenceBlock" ||
			//				(string)reliventRectangels[checkRectangleIndex].Tag == "enemy")
			//			{
			//				Rect targetHitbox = new Rect(Canvas.GetLeft(reliventRectangels[checkRectangleIndex]), Canvas.GetTop(reliventRectangels[checkRectangleIndex]),
			//				reliventRectangels[checkRectangleIndex].Width, reliventRectangels[checkRectangleIndex].Height);


			//				if (shotHitbox.IntersectsWith(targetHitbox))
			//				{
			//					display.Children.Remove(reliventRectangels[rectangleIndex]);
			//					display.Children.Remove(reliventRectangels[checkRectangleIndex]);
			//				}
			//			}
			//		}


			//	}

			//}


		}

		private void RemoveRedundentPlayerShots()
		{

			//for (int childIndex = display.Children.Count - 1; childIndex >= 0; childIndex--)
			//{

			//	if (display.Children[childIndex].GetType() == typeof(Rectangle) &&
			//		Canvas.GetTop(display.Children[childIndex]) < -50)
			//	{ display.Children.Remove(display.Children[childIndex]); }

			//}

		}



	}


	
}
