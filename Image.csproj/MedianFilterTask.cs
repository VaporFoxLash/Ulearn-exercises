using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		/*
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя,
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 *
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
		public static double[,] MedianFilter(double[,] original)
		{
				var width = original.GetLength(0);
				var height = original.GetLength(1);
				double[,] array = new double[width, height];
				var list = new List<double>();
				for (int i = 0; i < width; i++)
				{
				    for (int j = 0; j < height; j++)
				    {
				        if ((i == 0 || i == width - 1) && (j == 0 || j == height - 1))
				        {
				            for (int k = 0; k < 2; k++)
				            {
				                for (int l = 0; l < 2; l++)
				                {
				                    list.Add(original[i + k, j + l]);
				                    list.Sort();
				                    array[i, j] = (list[1]+list[2])/2;
				                    list.RemoveRange(0, 3);
				                }
				            }
				        }
				        if (i == 0 || i == width - 1)
				        {
				            for (int k = 0; k < 2; k++)
				            {
				                for (int l = 0; l < 3; l++)
				                {
				                    list.Add(original[i + k, j + l - 1]);
				                    list.Sort();
				                    array[i, j] = (list[3] + list[2]) / 2;
				                    list.RemoveRange(0, 5);
				                }
				            }
				        }
				        if (j == 0 || j == height - 1)
				        {
				            for (int k = 0; k < 3; k++)
				            {
				                for (int l = 0; l < 2; l++)
				                {
				                    list.Add(original[i + k - 1, j + l]);
				                    list.Sort();
				                    array[i, j] = (list[3] + list[2]) / 2;
				                    list.RemoveRange(0, 5);
				                }
				            }
				        }
				       for (int k = 0; k < 3; k++)
				        {
				            for (int l = 0; l < 3; l++)
				            {
				                list.Add(original[i+k-1, j+l-1]);
				                list.Sort();
				                array[i,j] = list[4];
				                list.RemoveRange(0, 8);
				            }
				        }
				    }
				}
				return array;
		}
	}
}
