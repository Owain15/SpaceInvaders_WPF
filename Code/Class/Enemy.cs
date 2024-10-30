using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class Enemy
	{
		public double Index;

		//public enum enemyType;

		public double Height;

		public double Width;

		public double Left;

		public double Top;

		public WeaponType Weapon;

		public bool isMovingRight;
		public bool isMovingUp;

		public double LeftMomentum;
		private int MaxLeftMomentum;
		private bool MaxLeftMomentumHit;
		
		public double TopMomentum;
		private int MaxTopMomentum;
		private bool MaxTopMomentumHit;
		private double TopMomentumDelay;

		public List<Shot> ShotsList;

		public bool isMoving;

		public int Speed;

		public double moveDelay;

		public double moveDelayCount;



		public RotateTransform Rotation;

		public Enemy(double Index, double Left, double Top) 
		{
			this.Index = Index;
			this.Left = Left;
			this.Top = Top;

			Height = 30;
			Width = 30;

			isMovingRight = true;
			isMovingUp = true;

			LeftMomentum = 0;
			MaxLeftMomentum = 10;
			MaxLeftMomentumHit = false;
			
			TopMomentum = 0;
			MaxTopMomentum = 5;
			MaxTopMomentumHit = false;
			TopMomentumDelay = 0;

			Weapon = new WeaponType();

			ShotsList = new List<Shot>();

			Speed = 1;

			moveDelay = 10;
			moveDelayCount = 0;
			
			Rotation = new RotateTransform();
			Rotation.CenterX = Width / 2;
			//Rotation.CenterY = Height;


		}


		public void UpdateData(List<Enemy> UnitList)
		{
			UpdateIsMovingBool();
			UpdateLeftMomentum();
			UpdateLeftPosition();
			
			//UpdateTopMomentum();
			//UpdateTopPosition();

			CheckForSquadCollitions(UnitList);
			
			CheckBounderies();
			
			UpdateRotation();
		}



		public void UpdateIsMovingBool()
		{
			if (!isMoving) { moveDelayCount++; }
			
			if (moveDelayCount >= moveDelay) 
			{
				moveDelayCount = 0;

				isMoving = true;

			}

			
		}

		public void UpdateLeftMomentum()
		{
			
			
			if ( isMoving &&  isMovingRight && !MaxLeftMomentumHit) { LeftMomentum++; }
			if ( isMoving &&  isMovingRight &&  MaxLeftMomentumHit ) { LeftMomentum--; }
		
			if ( isMoving && !isMovingRight && !MaxLeftMomentumHit) { LeftMomentum--; }
			if ( isMoving && !isMovingRight &&  MaxLeftMomentumHit ) { LeftMomentum++; }
			
			if ( isMoving && LeftMomentum == 0 && MaxLeftMomentumHit) { MaxLeftMomentumHit = false; isMoving = false; }
			
			if ( isMoving && LeftMomentum >=  MaxLeftMomentum) { MaxLeftMomentumHit = true; }
			if ( isMoving && LeftMomentum <= -MaxLeftMomentum) { MaxLeftMomentumHit = true; }
			
			

		}

		private void UpdateLeftPosition() { Left = GetPreposedLeft(); }

	

		private void UpdateTopMomentum()
		{
			if (isMoving && isMovingUp) { TopMomentum--; }
			if (isMoving && !isMovingUp) { TopMomentum++; }
			if (TopMomentum == -MaxTopMomentum){ MaxTopMomentumHit = true; TopMomentum = 0; isMovingUp = false; }
			if (TopMomentum == MaxTopMomentum) { MaxTopMomentumHit = true; TopMomentum = 0; isMovingUp = true; }
			
		}
		private void UpdateTopPosition() 
		{
			if (isMoving) { Top = Top + (Speed * TopMomentum); }
			
		}

		private void CheckForSquadCollitions(List<Enemy> UnitList)
		{
			for( int shipNumber = UnitList.Count - 1; shipNumber >= 0; shipNumber -- )
			{
				//if (Left == UnitList[shipNumber].Left && Top == UnitList[shipNumber].Top){ break; }
				//if (this == UnitList[shipNumber]){ break; }

				if (    
						Index != UnitList[ shipNumber ].Index &&
						isMovingRight &&
						Top > UnitList[shipNumber].Top - UnitList[shipNumber].Height &&
			     		Top < UnitList[shipNumber].Top + UnitList[shipNumber].Height &&
						Left > UnitList[shipNumber].Left - UnitList[shipNumber].Width &&
						Left < UnitList[shipNumber].Left + UnitList[shipNumber].Width 
					)
				{
						isMoving = false;
						LeftMomentum = 0;
						isMovingRight = false;
						moveDelayCount = moveDelay - 2;

						UnitList[shipNumber].isMoving = false;
						UnitList[shipNumber].LeftMomentum = 0;
						UnitList[shipNumber].isMovingRight = true;
						UnitList[shipNumber].moveDelayCount = UnitList[shipNumber].moveDelay - 2;

						
						Left = UnitList[shipNumber].Left - Width - 1;

				}
				else if
					(
						Index != UnitList[shipNumber].Index &&
						!isMovingRight &&
						Top > UnitList[shipNumber].Top - UnitList[shipNumber].Height &&
						Top < UnitList[shipNumber].Top + UnitList[shipNumber].Height &&
						Left > UnitList[shipNumber].Left - UnitList[shipNumber].Width &&
						Left < UnitList[shipNumber].Left + UnitList[shipNumber].Width
					)
				{

					isMoving = false;
					LeftMomentum = 0;
					isMovingRight = true;
					moveDelayCount = moveDelay - 2;

					UnitList[shipNumber].isMoving = false;
					UnitList[shipNumber].LeftMomentum = 0;
					UnitList[shipNumber].isMovingRight = false;
					UnitList[shipNumber].moveDelayCount = UnitList[shipNumber].moveDelay - 2;

					Left = UnitList[shipNumber].Left + Width + 1;
				}

			}
		}
		
		private void CheckBounderies()
		{
			if (Left <= 25  ) { Left = 25;  }
			if (Left >= 710 ) { Left = 710; }

			if ( Left <= 25 && !isMoving ) { isMovingRight = true; }
			if (Left >= 710 && !isMoving) { isMovingRight = false; }

			//if ( Left <= 25) {  isMovingRight = true;  MaxLeftMomentumHit = false; }
			//if ( Left >= 710){  isMovingRight = false; MaxLeftMomentumHit = false; }
		}

		
		
		
		public double GetPreposedLeft()
		{
			double preposedPosition = Left; 

			if (isMoving && LeftMomentum != 0)
			{
				double nextLeft = Left + (Speed * LeftMomentum);

				if (nextLeft < 25)       { preposedPosition = 25;  }
				else if (nextLeft > 710) { preposedPosition = 710;  }
				else { preposedPosition = nextLeft; }

			}

			return preposedPosition;
		}
		
		private void UpdateRotation() { Rotation.Angle = LeftMomentum * 3; }


	}
}
