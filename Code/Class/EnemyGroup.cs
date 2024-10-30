using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class EnemyGroup
	{
		public List<Enemy> UnitList;

		//public bool moveTheRight;

		//public double moveDelay;

		//public double moveDelayCount;

		public EnemyGroup()
		{
			UnitList = new List<Enemy>();
			InializEmemyList();

			//moveTheRight = true;

			//moveDelay = 20;
			//moveDelayCount = 0;

		}

		private void InializEmemyList()
		{
			//UnitList.Add(new Enemy(100, 100));
			//UnitList.Add(new Enemy(200, 100));
			UnitList.Add(new Enemy(300, 100));
			UnitList.Add(new Enemy(420, 80));
			UnitList.Add(new Enemy(600, 100));
			
		}
		public void UpdatePositions() { foreach (Enemy enemy in UnitList) { enemy.UpdateData(UnitList); } }

	}
}
