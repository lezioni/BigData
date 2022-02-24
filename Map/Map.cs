using System;

namespace Map
{
    class Map
    {
        public const int TEMPERATURA_DI_SOGLIA = 50;
        static void Main(string[] args)
        {
            // CONTEGGIO GIORNI SOPRA SOGLIA PER IMPIANTO E SENSORE

            /*
             * Sample data:
             * 
                Z1, S1, 2021-01-01, 32
                Z1, S2, 2021-01-01, 52
                Z1, S3, 2021-01-01, 12
                Z1, S1, 2021-01-02, 43
                Z1, S2, 2021-01-02, 58
                Z1, S3, 2021-01-02, 33
                Z1, S1, 2021-01-03, 55
                Z1, S1, 2021-01-03, 47
                Z1, S3, 2021-01-03, 39
                Z2, S1, 2021-01-01, 52
                Z2, S2, 2021-01-01, 20
                Z2, S3, 2021-01-01, 32
                Z2, S1, 2021-01-02, 41
                Z2, S2, 2021-01-02, 58
                Z2, S3, 2021-01-02, 53
                Z2, S1, 2021-01-03, 55
                Z2, S1, 2021-01-03, 57
                Z2, S3, 2021-01-03, 32
             */

            string line;
            //Hadoop passes data to the mapper on STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // Split line in fields
                var fields = line.Split(",");

                if (int.Parse(fields[3]) > TEMPERATURA_DI_SOGLIA)
                {
                    var key = fields[0] + fields[1];
                    int value = 1;
                    //Emit tab-delimited key/value pairs.
                    Console.WriteLine(key + "\t" + value);
                }
            }
        }
    }
}