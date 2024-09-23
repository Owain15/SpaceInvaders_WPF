using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class Player
	{
		public double left;
		public double top;

		//RotateTransform Rotation = new RotateTransform();

		//public enum weponType;

		public int Speed;
		public int Momentum;
		public int MaxMomentum;

		public double score;

		public List<Shot> shotList;

		public Player()
		{

			left = 300;
			top = 380;

			Speed = 2;
			Momentum = 0;
			MaxMomentum = 10;

			score = 0;

			shotList = new List<Shot>();

		}

		private void MovePlayer()
		{

		//	if (playerMomentum != 0)
		//	{
		//		double nextPlayerLeft = Canvas.GetLeft(display.Children.OfType<Rectangle>().First(x => x.Tag == "player")) + (playerSpeed * playerMomentum);

		//		if (nextPlayerLeft < 25) { Canvas.SetLeft(display.Children.OfType<Rectangle>().First(x => x.Tag == "player"), 25); }
		//		else if (nextPlayerLeft > 710) { Canvas.SetLeft(display.Children.OfType<Rectangle>().First(x => x.Tag == "player"), 710); }
		//		else { Canvas.SetLeft(display.Children.OfType<Rectangle>().First(x => x.Tag == "player"), nextPlayerLeft); }

		//	}
		}

		private void RotatePlayer()
		{
			//playerRotation.Angle = playerMomentum * 3;
			//display.Children.OfType<Rectangle>().First(x => x.Tag == "player").RenderTransform = playerRotation;

		}

	}
}
