using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		/// 

		public static int ConvertRoman(string roman)
        {
            int i;
            string symbol;
            int dec = 0;
            int new_value = 0;
            int old_value = 0;

            for (i = 1; (i <= roman.Length); i++)
            {
                symbol = roman.Substring((i - 1), 1);

                switch (symbol.ToUpper())
                {
                    case "I":
                        new_value = 1;
                        break;
                    case "V":
                        new_value = 5;
                        break;
                    case "X":
                        new_value = 10;
                        break;
                    case "L":
                        new_value = 50;
                        break;
                    case "C":
                        new_value = 100;
                        break;
                    case "D":
                        new_value = 500;
                        break;
                    case "M":
                        new_value = 1000;
                        break;
                }

                if (new_value > old_value)
                {
                    dec = dec + new_value - 2 * old_value;
                }
                else
                {
                    dec = dec + new_value;
                }

                old_value = new_value;
            }
            return dec;

        }

		public static int Evaluate(string expression)
		{
			expression = expression.ToUpper().Replace(" ", "");

			string permission = "MDCLXVI+-*";
			string letters = "MDCLXVI";

			int result = 0;

			if(expression != null)
            {
				foreach(char element in expression)
                {
                    int error = 1;
                    foreach (char perm in permission)
                    {
                        if(perm == element)
                        {
                            error = 0;
                            break;
                        }
                    }
                    if (error == 1)
                    {
						Console.WriteLine($"{element} not found");
						return 0;
					}
                }

				string roman = null;
                char operation = '+';
                int first = 1;

				foreach (char element in expression)
				{
					if (letters.Contains(element))
					{
						roman += element;
					}
                    else
                    {
                        if(first == 1)
                        {
                            result += ConvertRoman(roman);
                            roman = null;
                            first = 0;
                        } else
                        {
                            if (operation == '+')
                            {
                                result += ConvertRoman(roman);
                                roman = null;
                            }
                            else if (operation == '-')
                            {
                                result -= ConvertRoman(roman);
                                roman = null;
                            }
                            else if (operation == '*')
                            {
                                result *= ConvertRoman(roman);
                                roman = null; 
                            }
                        }
                        

                        if(element == '+')
                        {
                            operation = '+';
                        } else if (element == '-')
                        {
                            operation = '-';
                        } else if(element == '*')
                        {
                            operation = '*';
                        }
                    }
				}

                if (operation == '+')
                {
                    result += ConvertRoman(roman);
                }
                else if (operation == '-')
                {
                    result -= ConvertRoman(roman);
                }
                else if (operation == '*')
                {
                    result *= ConvertRoman(roman);
                }
            }


			return result;
		}
	}
}
