using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class Shot
	{

		public int playerShotImageDelay = 0;

		public int leftMomentum;
		
		public int topMomentum;

		RotateTransform Rotation = new RotateTransform();

		public Shot()
		{

		}

		//change to move shot. add x and y volocatys.
		private void MovePlayerShots()
		{
			//foreach (var shot in display.Children.OfType<Rectangle>())
			//{
			//	if (shot.Tag == "playerShot") { Canvas.SetTop(shot, Canvas.GetTop(shot) - (shot.Height / 2)); }

			//}
		}

		private void UpdateReload()
		{
			if (shotReloadCount == 0) { readyToShoot = true; }
			else if (shotReloadCount > 0) { shotReloadCount--; }
			else { Console.WriteLine("Reaload Error"); }

		}

		private void AddPlayerShot()
		{
			//GetRandomPlayerShotImage();

			//Rectangle spawnShot = new Rectangle
			//{

			//	Width = 10,
			//	Height = 30,
			//	Fill = playerShotImage,

			//	Tag = "playerShot"

			//};

			//Canvas.SetLeft(spawnShot, Canvas.GetLeft(display.Children.OfType<Rectangle>().First(x => x.Tag == "player")) + (display.Children.OfType<Rectangle>().First(x => x.Tag == "player").Width / 2) - (spawnShot.Width / 2));
			//Canvas.SetTop(spawnShot, Canvas.GetTop(display.Children.OfType<Rectangle>().First(x => x.Tag == "player")) - spawnShot.Height + 20);

			//display.Children.Add(spawnShot);
			//shotReloadCount = shotReloadValue;
			//readyToShoot = false;

		}


	}
}
