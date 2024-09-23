using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class Player
	{
		public double left;
		public double top;

		//public enum weponType;

		public int Speed = 2;
		public int Momentum = 0;
		public int MaxMomentum = 10;

		public double score;

		public List<Shot> shotList;

		public Player()
		{

		}

	}
}
