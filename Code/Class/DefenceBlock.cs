using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders_WPF.Code.Class
{
	internal class DefenceBlock
	{
		public double left;
		
		public double top;


		public DefenceBlock() 
		{
			left = 0;
			top = 0;
		}

		public DefenceBlock(double left, double top)
		{
			this.left = left;
			this.top = top;
		}

		public void Remove()
		{


		}

		private void AddDefenceBlock(double positionLeft, double positionTop)
		{

			////ImageBrush defenceBlockBrush = new ImageBrush();
			//defenceBlockBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\block.png"));

			//Rectangle defenceBlock = new Rectangle
			//{

			//	Width = 15,
			//	Height = 15,
			//	Fill = defenceBlockBrush,
			//	Tag = "defenceBlock"

			//};

			//Canvas.SetLeft(defenceBlock, positionLeft);
			//Canvas.SetTop(defenceBlock, positionTop);

			//display.Children.Add(defenceBlock);
		}

		private void AddDefenceBlockGroup(double positionLeft, double positionTop)
		{

			//defenceBlockData.Add(new Point(positionLeft, positionTop + 20));
			//defenceBlockData.Add(new Point(positionLeft + 20, positionTop + 20));

			//defenceBlockData.Add(new Point(positionLeft, positionTop + 40));
			//defenceBlockData.Add(new Point(positionLeft + 20, positionTop + 40));

			//defenceBlockData.Add(new Point(positionLeft + 20, positionTop));
			//defenceBlockData.Add(new Point(positionLeft + 40, positionTop));
			//defenceBlockData.Add(new Point(positionLeft + 60, positionTop));

			//defenceBlockData.Add(new Point(positionLeft + 40, positionTop + 20));

			//defenceBlockData.Add(new Point(positionLeft + 60, positionTop + 20));
			//defenceBlockData.Add(new Point(positionLeft + 80, positionTop + 20));

			//defenceBlockData.Add(new Point(positionLeft + 60, positionTop + 40));
			//defenceBlockData.Add(new Point(positionLeft + 80, positionTop + 40));
		}


	}
}
