using SpaceInvaders_WPF.Code.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders_WPF.Code
{
    class Game
    {
      
        public bool isRunning;

        public Player player;

		public List<Enemy> enemyList;

        public List<DefenceBlock> defenceBlockList;

		//int refreshRate = 20;
		
        //DispatcherTimer gameTimer = new DispatcherTimer();

		
        
        public Game()
        { 
            isRunning = false;

            player = new Player();

            enemyList = new List<Enemy>();

            defenceBlockList = new List<DefenceBlock>();

        }

        public void Start()
        {
			//leftDown = false;
			//rightDown = false;
			//spaceDown = false;

			//readyToShoot = true;

			//gameTimer.Start();
		}

        public void Pause()
        { 
            //gameTimer += RunPauseEvent;
        }

        public void Stop()
        {

        }

		private void GameLoop(object sender, EventArgs e)
		{
			//HandelInputs();

			//HandelPlayer();

			//HandelEnemys();

			//HandelPlayerShots();

			//HandelCollistions();

			//testLabel.Content = "player Momentum: " + playerMomentum + ".";
		}

		private void HandelInputs()
		{

		//	//if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum--; } else if (playerMomentum < 0) { playerMomentum++; } }
		//	//else if (leftDown) { if (playerMomentum > -playerMaxMomentum) { playerMomentum--; } }
		//	//else if (rightDown) { if (playerMomentum < playerMaxMomentum) { playerMomentum++; } }

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
