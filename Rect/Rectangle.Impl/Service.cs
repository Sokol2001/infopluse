using System;
using System.Collections.Generic;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Rectangle FindRectangle(List<Point> points)
		{
			//The rectangle coordinates may or may not match with provided points.

			//If may not match with provided points
			//Use D > 0 or D < 0

			//If may match with provided points
			//Use D >= 0 or D <= 0

			int error = 0;
			Rectangle rect = new Rectangle();

			
			int minLeft = 0;
			int minRight = 0;
			int minTop = 0;
			int minDown = 0;

			foreach (Point point in points)
            {
				if(point.X < minLeft)
					minLeft = point.X;
                
				if(point.Y < minDown)
                	minDown = point.Y;
                
				if(point.X > minRight)
                	minRight = point.X;
               
				if(point.Y > minTop)
					minTop = point.Y;
            }

			rect.X1 = minLeft; 
			rect.X2 = minLeft; 
			rect.X3 = minRight; 
			rect.X4 = minRight; 

			rect.Y1 = minDown; 
			rect.Y2 = minTop; 
			rect.Y3 = minTop; 
			rect.Y4 = minDown;

            //one point is on the left

            rect.X1++;
            rect.X2++;

            int A = -(rect.Y2 - rect.Y1);
			int B = rect.X2 - rect.X1;
			int C = -(A * rect.X1 + B * rect.Y1);

			error = 0;


			foreach (Point point in points)
			{
				int D = A * point.X + B * point.Y + C; //If D > 0, the point is on the left-hand side.
													   //If D < 0, the point is on the right-hand side.
													   //If D = 0, the point is on the line.
				if (D > 0)
                {
					error++;
                }
			}

			//one point is on the right
			if (error > 1)
			{	
				rect.X1--;
				rect.X2--; 
				rect.X3--;
				rect.X4--;

				A = -(rect.Y4 - rect.Y3);
				B = rect.X4 - rect.X3;
				C = -(A * rect.X3 + B * rect.Y3);
				
				error = 0;

				foreach (Point point in points)
				{
					int D = A * point.X + B * point.Y + C; //If D > 0, the point is on the left-hand side.
														   //If D < 0, the point is on the right-hand side.
														   //If D = 0, the point is on the line.
					if (D < 0)
					{
						error++;
					}
				}
				if (error > 1)
				{
					//point is on the down

					rect.X3++;
					rect.X4++;

					rect.Y1++;
					rect.Y4++;

					B = -(rect.Y4 - rect.Y1);
					A = rect.X4 - rect.X1;
					C = -(B * rect.X1 + A * rect.Y1);

					error = 0;

					foreach (Point point in points)
					{
						int D = B * point.X + A * point.Y + C; //If D > 0, the point is on the down side.
															   //If D < 0, the point is on the top side.
															   //If D = 0, the point is on the line.
						if (D > 0)
						{
							error++;
						}
					}

                    if (error > 1)
					{
						//point is on the top

						rect.Y1--;
						rect.Y4--;

						rect.Y2--;
						rect.Y3--;

						B = -(rect.Y3 - rect.Y2);
						A = rect.X3 - rect.X2;
						C = -(B * rect.X2 + A * rect.Y2);

						error = 0;

						foreach (Point point in points)
						{
							int D = B * point.X + A * point.Y + C; //If D > 0, the point is on the down side.
																   //If D < 0, the point is on the top side.
																   //If D = 0, the point is on the line.
							if (D < 0)
							{
								error++;
							}

						}
						
						if(error > 1)
                        {
							Console.WriteLine("the input list is invalid");
                        }
						else
							return rect;
					}
					else
						return rect;
				}
                else
					return rect;
			} else
				return rect;

			return rect;
		}
	}
}
