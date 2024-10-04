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
		public double Left;
		public double Top;

		public double Width;
		public double Height;

		public RotateTransform Rotation; 

		public WeaponType Weapon;

		public int Speed;
		public int Momentum;
		public int MaxMomentum;

		public double score;

		public List<Shot> shotList;

		public Player()
		{

			Left = 380;
			Top = 300;

			Width = 50;
			Height = 50;

			Rotation = new RotateTransform();
			Rotation.CenterX = Width/2;
			Rotation.CenterY = Height;

			Speed = 2;
			Momentum = 0;
			MaxMomentum = 10;

			score = 0;

			Weapon = new WeaponType();

			shotList = new List<Shot>();

		}

		public void Loop(Inputs input)
		{
			HandelInput(input);
			MovePlayer();
			RotatePlayer();
			//HandelColitions?

		}

		private void HandelInput(Inputs input)
		{
			if (input.leftDown && input.rightDown || !input.leftDown && !input.rightDown) 
			{
			   	  if (Momentum > 0) { Momentum--; } 
			 else if (Momentum < 0) { Momentum++; } 
			}
			else if (input.leftDown && Momentum > -MaxMomentum) { Momentum--; } 
			else if (input.rightDown && Momentum < MaxMomentum) { Momentum++; }

			if (input.spaceDown && Weapon.readyToShoot) { shotList.Add(new Shot) }

		}

		private void MovePlayer()
		{

			if (Momentum != 0)
			{
				double nextLeft = Left + (Speed * Momentum);

				if (nextLeft < 25) { Left = 25; }
				else if (nextLeft > 710) { Left = 710; }
				else { Left = nextLeft; }
				
			}

		}

		private void RotatePlayer()
		{
			Rotation.Angle = Momentum * 3;
			//display.Children.OfType<Rectangle>().First(x => x.Tag == "player").RenderTransform = playerRotation;

		}

	}
}
