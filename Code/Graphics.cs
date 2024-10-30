using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceInvaders_WPF.Code
{
	internal class Graphics
	{

		public ImageBrush backgroundImage = new ImageBrush();
		public ImageBrush playerImage = new ImageBrush();
		public ImageBrush playerShotImage = new ImageBrush();
		public ImageBrush defenceBlockBrush = new ImageBrush();

		//RotateTransform Rotation = new RotateTransform();

		public Graphics() 
		{ 
		 backgroundImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\background.png"));
		}

		private void UpdatePlayerImage()
		{
			//if (playerMomentum > -2 && playerMomentum < 2)
			//{
			//	playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo1.png"));
			//}
			//else if (playerMomentum > 3 && playerMomentum < 8 || playerMomentum < 3 && playerMomentum > -8)
			//{
			//	playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo2.png"));
			//}
			//else if (playerMomentum > 8 || playerMomentum < -8)
			//{
			//	playerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\Player\\playerMo3.png"));
			//}
		}

		private void GetRandomPlayerShotImage()
		{

			Random rand = new Random();

			switch (rand.Next(1, 4))
			{
				case 1: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot01.png")); break;
				case 2: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot02.png")); break;
				case 3: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot03.png")); break;
				case 4: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot04.png")); break;

				default: playerShotImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\Projects\\SpaceInvaders_WPF\\res\\PlayerShot\\PlayerShot01.png")); break;
			}

		}

		private void UpdatePlayerShotImage()
		{
			//playerShotImageDelay++;

			//if (playerShotImageDelay > 2)
			//{
			//	playerShotImageDelay = 0;

			//	List<Rectangle> reliventRectangels = display.Children.OfType<Rectangle>().ToList();
			//	for (int i = 0; i < reliventRectangels.Count; i++)
			//	{
			//		if (reliventRectangels[i].Tag == "playerShot")
			//		{
			//			GetRandomPlayerShotImage();
			//			reliventRectangels[i].Fill = playerShotImage;
			//		}

			//	}

			//}

		}


	}




}
