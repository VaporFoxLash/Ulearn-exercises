namespace Recognizer
{
	public static class GrayscaleTask
	{
		/* 
		 * Переведите изображение в серую гамму.
		 * 
		 * original[x, y] - массив пикселей с координатами x, y. 
		 * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
		 * 
		 * Получившийся массив должен иметь те же размеры, 
		 * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
		 *
		 * Используйте формулу:
		 * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
		 * 
		 * Почему формула именно такая — читайте в википедии 
		 * http://ru.wikipedia.org/wiki/Оттенки_серого
		 */
		
		public static double[,] ToGrayscale(Pixel[,] original)
		{
			var Red = 0.299;
			var Green = 0.587;
			var Blue = 0.114;

			var row = original.GetLength(0);
			var col = original.GetLength(0);
			var grayScale = new double[row, col];
			for (int i = 0; i < row; i++)
			{
                for (int j = 0; j < col; j++)
                {
                    grayscale[i, j] = (original[i, j].R*Red + original[i, j].G*
									   Green + original[i, j].B*Blue) / 255;
				}
			}
			return grayScale;;
		}
	}
}
