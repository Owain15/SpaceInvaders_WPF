using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceInvaders_WPF.Code
{
	internal class Inputs
	{
		bool leftDown,
			 rightDown,
			 spaceDown;
			 //ctrDown,        //secodry shot, rockets?
			 //pDown,          //pause game
			 //escDown;        // exit to menu....make a menu.
	
		public Inputs()
		{
			leftDown = false;
			rightDown = false;
			spaceDown = false;
			//ctrDown = false;
			//pDown = false;
			//escDown = false;

		}

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Left) { leftDown = true; }
			if (e.Key == Key.Right) { rightDown = true; }
			if (e.Key == Key.Space) { spaceDown = true; }
		}

		private void KeyUpEvent(object sender, KeyEventArgs e)
		{

			if (e.Key == Key.Left) { leftDown = false; }
			if (e.Key == Key.Right) { rightDown = false; }
			if (e.Key == Key.Space) { spaceDown = false; }

		}

		//private void HandelInputs()
		//{

		//	//if (leftDown && rightDown || !leftDown && !rightDown) { if (playerMomentum > 0) { playerMomentum--; } else if (playerMomentum < 0) { playerMomentum++; } }
		//	//else if (leftDown) { if (playerMomentum > -playerMaxMomentum) { playerMomentum--; } }
		//	//else if (rightDown) { if (playerMomentum < playerMaxMomentum) { playerMomentum++; } }

		//	//if (spaceDown)
		//	//{ if (spaceDown && readyToShoot) { AddPlayerShot(); } }

		//}








	}
}
