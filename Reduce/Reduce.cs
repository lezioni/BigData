using System;
using System.Collections.Generic;

namespace Reduce
{
    class Reduce
    {
        static void Main(string[] args)
        {
            // ELENCO GIORNATE SOPRA SOGLIA PER SENSORE

            /*
             * Expected output
             * 
                S2   2021-01-01, 2021-01-02
                S1   2021-01-03
             */

            // Dictionary for holding days over thresold for every sensor
            Dictionary<string, string> reduceOutput = new Dictionary<string, string>();

            string line;
            //Read from STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // Data from Hadoop is tab-delimited key/value pairs
                var sArr = line.Split('\t');
                // Get the sensor id
                string sensorId = sArr[0];
                if (reduceOutput.ContainsKey(sensorId))
                {
                    //Do we already have a count for the sensor?
                    if (reduceOutput[sensorId].Contains(sArr[1]))
                        continue;

                    reduceOutput[sensorId] += ", " + sArr[1];
                }
                else
                {
                    reduceOutput.Add(sensorId, sArr[1]);
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