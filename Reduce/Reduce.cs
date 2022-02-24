using System;
using System.Collections.Generic;

namespace Reduce
{
    class Reduce
    {
        static void Main(string[] args)
        {
            // CONTEGGIO GIORNI SOPRA SOGLIA PER IMPIANTO E SENSORE

            /*
             * Expected output
             * 
                Z1 S2   2
                Z1 S1   1
                Z2 S1   3
                Z2 S2   1
                Z2 S3   1
             */

            // Dictionary for holding days over thresold for every sensor
            Dictionary<string, int> reduceOutput = new Dictionary<string, int>();

            string line;
            //Read from STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // Data from Hadoop is tab-delimited key/value pairs
                var sArr = line.Split('\t');
                // Get the sensor id
                string sensorId = sArr[0];
                // Get the count
                int count = Convert.ToInt32(sArr[1]);

                //Do we already have a count for the sensor?
                if (reduceOutput.ContainsKey(sensorId))
                {
                    reduceOutput[sensorId] += count;
                }
                else
                {
                    reduceOutput.Add(sensorId, count);
                }
            }
            //Finally, emit each sensorId and count
            foreach ((var key, var value) in reduceOutput)
            {
                //Emit tab-delimited key/value pairs.
                Console.WriteLine("{0}\t{1}", key, value);
            }
        }
    }
}