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

		public int shotReloadValue = 4;

		public int shotReloadCount = 0;

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
				case ShotType.SingleShot: shotReloadValue = 4; shotReloadCount = 0; break;
				case ShotType.BurstShot:  shotReloadValue = 2; shotReloadCount = 0; break;

				default: shotReloadValue = 4; shotReloadCount = 0; break;
			}
		}

	}

	enum ShotType
		{
			SingleShot,
			BurstShot
		}


}
