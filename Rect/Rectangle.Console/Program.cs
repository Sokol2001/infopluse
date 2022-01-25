using System;
using System.Collections.Generic;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			int error = 0;
			Random rnd = new Random();
			List<Point> points = new List<Point>();

			for (int i = 0; i < 100; i++)
			{
				Point point = new Point();
				point.X = rnd.Next(-100, 100);
				point.Y = rnd.Next(-100, 100);

				error = 0;

				foreach (Point p in points)
				{
					if (p.X == point.X && p.Y == point.Y)
					{
						error++;
					}
				}
				if (error == 0)
				{
					points.Add(point);
				}
			}

			var rectangle = Service.FindRectangle(points);
			System.Console.ReadKey();
		}
	}
}
