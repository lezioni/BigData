using System;

namespace Map
{
    class Map
    {
        public const int TEMPERATURA_DI_SOGLIA = 50;
        static void Main(string[] args)
        {
            // CONTEGGIO GIORNI SOPRA SOGLIA

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

                // ADD NECESSARY CHECKS FOR CSV FIELDS

                if (int.Parse(fields[2]) > TEMPERATURA_DI_SOGLIA)
                {
                    var key = fields[0];
                    int value = 1;
                    //Emit tab-delimited key/value pairs.
                    Console.WriteLine(key + "\t" + value);
                }
            }
        }
    }
}