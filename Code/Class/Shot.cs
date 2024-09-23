using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class Shot
	{
		public bool readyToShoot;
		
		public int shotReloadValue = 4;
		
		public int shotReloadCount = 0;

		public int playerShotImageDelay = 0;


		public Shot()
		{

		}

	}
}
