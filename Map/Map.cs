using System;

namespace Map
{
    class Map
    {
        static void Main(string[] args)
        {
            // CALCOLO TEMPERATURA MEDIA PER SENSORE

            /*
             * Sample data:
             * 
                S1, 2021-01-01, 32
                S2, 2021-01-01, 52
                S1, 2021-01-02, 43
                S2, 2021-01-02, 58
                S1, 2021-01-03, 55
                S1, 2021-01-03, 47
             */

            string line;
            //Hadoop passes data to the mapper on STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // Split line in fields
                var fields = line.Split(",");

                var key = fields[0];    // Id sensore
                var value = fields[2];  // Temperatura
                //Emit tab-delimited key/value pairs.
                Console.WriteLine(key + "\t" + value);
            }
        }
    }
}