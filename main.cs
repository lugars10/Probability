using System;

namespace MetoProbability
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double[,] timeTable = inputData();
            double[,] frequencyTable = inputData();
            double probability = 0;

            //Assuming both tables have the same length in both of the dimensions
            int rowsLength = timeTable.GetLength(0);
            int columnsLength = timeTable.GetLength(1);

            for(int m = 0; m!=rowsLength; m++)
            {
                for(int n = 0; n!= columnsLength; n++)
                {
                    probability += (timeTable[m, 0] * frequencyTable[n, 0]) * timeTable[m, 1] * frequencyTable[n, 1];
                }
            }

            Console.WriteLine(probability);

        }

        public static double[,] inputData()
        {
            Console.WriteLine("Number of rows: ");
            int rows = Convert.ToInt16(Console.ReadLine());     //Gets the number of rows for table

            Console.WriteLine("Number of columns: ");
            int columns = Convert.ToInt16(Console.ReadLine());  //Gets the number of columns for table

            double[,] table = new double[rows, columns];

            for (int i = rows; i != 0; i--) 
            {
                Console.WriteLine("===== Row {0} =====", rows - i);
                Console.WriteLine();
                for (int j = columns; j != 0; j--)
                {
                    Console.WriteLine("Value {0}: ", columns-j);
                    table[rows - i, columns - j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            return table;
        }
    }
}
