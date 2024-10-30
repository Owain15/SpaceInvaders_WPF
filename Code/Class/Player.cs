using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

		public void UpdateData(Inputs input)
		{
			UpdateMomentum(input);
			UpdatePostion();
			UpdateRotation();
			UpdateWeapon(input);
			//HandelColitions?

		}
		public void UpdateShotData() 
		{
			foreach (Shot shot in shotList) 
			{
				shot.UpdatePosition();

			}
			for( int i =shotList.Count-1; i>= 0; i--)
			{
				if(shotList[i].Top < -shotList[i].Height) 
				{ shotList.Remove(shotList[i]); }
			
			}
		}

		private void UpdateWeapon(Inputs input)
		{

			if (input.spaceDown && Weapon.readyToShoot) 
			{ 
				Weapon.readyToShoot = false;
				shotList.Add(new Shot(this)); 
			}
			
			if (!Weapon.readyToShoot)
			{
				Weapon.ReloadCounter++;
			}
			
			if (Weapon.ReloadCounter >= Weapon.ReloadValue)
			{ 
				Weapon.readyToShoot = true;
				Weapon.ReloadCounter = 0;
			}
		
		}


		private void UpdateMomentum(Inputs input)
		{

			if (input.leftDown && input.rightDown || !input.leftDown && !input.rightDown) 
			{
			   	  if (Momentum > 0) { Momentum--; } 
			 else if (Momentum < 0) { Momentum++; } 
			}
			else if (input.leftDown && Momentum > -MaxMomentum) { Momentum--; } 
			else if (input.rightDown && Momentum < MaxMomentum) { Momentum++; }

		}

		private void UpdatePostion()
		{

			if (Momentum != 0)
			{
				double nextLeft = Left + (Speed * Momentum);

				if (nextLeft < 25) { Left = 25; }
				else if (nextLeft > 710) { Left = 710; }
				else { Left = nextLeft; }
				
			}

		}

		private void UpdateRotation()
		{
			Rotation.Angle = Momentum * 3;
			//display.Children.OfType<Rectangle>().First(x => x.Tag == "player").RenderTransform = playerRotation;

		}
		public void ShotCollitions(List<Enemy> enenyShips)
		{
			for (int i = shotList.Count - 1; i >= 0; i--)
			{
				for (int e = enenyShips.Count - 1; e >= 0; e--)
				{
					Rect shot = new Rect(shotList[i].Left, shotList[i].Top, shotList[i].Width, shotList[i].Height);
					Rect target = new Rect(enenyShips[e].Left, enenyShips[e].Top, enenyShips[e].Width, enenyShips[e].Height);

					if (shot.IntersectsWith(target))
					{
						shotList.RemoveAt(i);
						enenyShips.RemoveAt(e);
					}
				}
			}
		}
	}
}
