using System;

namespace MetoSimulation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Person x = new Person(1, 2);
            int movForShuffle;
            int iters;
            int nResults;
            double average = 0;
            double p = 0;

            Console.WriteLine("Movements for shuffle: ");
            movForShuffle = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("TIME DISTRIBUTION");
            double[] timeArray = inputArray();
            
            Console.WriteLine("FREQUENCY DISTRIBUTION");
            double[] freqArray = inputArray();

            Console.WriteLine("Number of iterations of each system: ");
            iters = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number of results: ");
            nResults = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("====RESULTS====");
            for(int i = 0; i!= nResults; i++)
            {
                p = prob(timeArray, freqArray, iters, movForShuffle);
                average += p;
                Console.WriteLine(p);
            }

            average = average / nResults;
            Console.WriteLine("AVERAGE: {0}", average);


            //Console.WriteLine("===========");
            //Console.WriteLine("Probability: {0}", (double) given / total);
        }

        public static double prob(double[] timeArray, double[] freqArray, int iterations, int shuffleMov)
        {
            double probability;

            timeArray = shuffleArray(timeArray, shuffleMov);
            freqArray = shuffleArray(freqArray, shuffleMov);

            Person[] people = new Person[timeArray.Length];
            Person p;
            for (int i = 0; i != timeArray.Length; i++)
            {
                p = new Person(Convert.ToInt32(timeArray[i]), freqArray[i]);
                people[i] = p;
            }

            int given = 0;
            int current = 0;
            int total;
            Random generator = new Random();
            double rndResult;

            
            total = iterations;

            for (int i = 0; i != people.Length; i++)
            {
                if (people[i].time != 0)
                {
                    rndResult = generator.NextDouble();
                    if (rndResult < people[i].freq)
                    {
                        given++;
                    }

                    current++;
                    people[i].time--;
                }

                if (current != total && (i + 1) == people.Length)  //If loop is ending and requirement is not accomplished
                {
                    for (int j = 0; j != people.Length; j++)
                    {
                        people[j].time = people[j].TIME;    //Restoration of time of each person
                    }
                }
            }

            probability = (double) given / total;

            return probability;
        }

        public static double[] inputArray()
        {
            Console.WriteLine("Enter the number of distinct categories: ");
            int categoriesTypes = Convert.ToInt16(Console.ReadLine());

            double[,] inputTable = new double[categoriesTypes, 2];
            double[] outputTable;
            int sizeOfArray = 0;
            int sizeOfCategory;
            int currentIndex = 0;
          
            for(int i = 0; i!= categoriesTypes; i++)
            {
                Console.WriteLine("======{0}========", i);
                Console.WriteLine("Enter the size of the category: ");
                inputTable[i,0] = Convert.ToDouble(Console.ReadLine());
                sizeOfArray += Convert.ToInt16(inputTable[i, 0]);
                Console.WriteLine("Enter the data of the category: ");
                inputTable[i, 1] = Convert.ToDouble(Console.ReadLine());

            }
            Console.WriteLine("=======FINISHED=======");
            outputTable = new double[sizeOfArray];
            for(int i = 0; i != categoriesTypes; i++)
            {
                sizeOfCategory = Convert.ToInt16(inputTable[i, 0]);
                for(int j = 0; j!= sizeOfCategory; j++)
                {
                    outputTable[currentIndex] = inputTable[i, 1];
                    currentIndex++;
                }
            }

            return outputTable;
        }

        public static double[] shuffleArray(double[] array, int movements)
        {
            double[] newArray = array;
            Random generator = new Random();
            int fromIndex;
            int toIndex;
            double temporalValue;

            for(int i = 0; i != movements; i++)
            {
                fromIndex = generator.Next(0, array.Length);
                toIndex = generator.Next(0, array.Length);

                temporalValue = newArray[toIndex];
                newArray[toIndex] = newArray[fromIndex];
                newArray[fromIndex] = temporalValue;
            }


            return newArray;
        }
    }

    public class Person
    {
        public int TIME;    //original time; does not change
        public double freq;
        public int time;

        public Person(int time, double freq)
        {
            this.time = time;
            this.freq = freq;
            this.TIME = time;
        }
    }
}

