using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class WeaponType
	{
		public ShotType Type;

		public bool readyToShoot;

		public int ReloadValue;

		public int ReloadCounter;

		public WeaponType()
		{
			Type = ShotType.SingleShot;

			readyToShoot = true;

			SetWeaponValues();
		}


		public void SetWeaponValues()
		{
			switch(Type)
			{
				case ShotType.SingleShot: ReloadValue = 10; ReloadCounter = 0; break;
				case ShotType.BurstShot:  ReloadValue = 6; ReloadCounter = 0; break;

				default: ReloadValue = 40; ReloadCounter = 0; break;
			}
		}

		private void UpdateReload()
		{
			if (ReloadCounter == 0) { readyToShoot = true; }
			else if (ReloadCounter > 0) { ReloadCounter--; }
			else { Console.WriteLine("Reaload Error"); }

		}

	}

	enum ShotType
		{
			SingleShot,
			BurstShot
		}


}
