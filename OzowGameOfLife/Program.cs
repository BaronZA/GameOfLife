using System;

namespace OzowGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The game of life");

            Console.Write("Enter the generations: ");
            int generations = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Height: ");
            int height = Convert.ToInt32(Console.ReadLine()); ;

            Console.Write("Enter Width: ");
            int width = Convert.ToInt32(Console.ReadLine()); ;

            Grid testGrid = new Grid(width, height, true);

            for (int x = 0; x < generations; x++)
            {
                Console.WriteLine("Generation: " + (x + 1));
                Console.WriteLine(testGrid.GenerateCurrentGridOutput());

                if (testGrid.LifeExists())
                {
                    testGrid.UpdateGrid();
                }
                else
                {
                    Console.WriteLine("Life has ended");
                    break;
                }
            }
        }
    }
}
