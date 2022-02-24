using System;
using System.Collections.Generic;

namespace Reduce
{
    class Reduce
    {
        static void Main(string[] args)
        {
            // CALCOLO TEMPERATURA MEDIA PER SENSORE

            /*
             * Expected output
             * 
                S2   55
                S1   44,25
             */

            Dictionary<string, (int, int)> reduceOutput = new();

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
                    reduceOutput[sensorId] = (reduceOutput[sensorId].Item1 + Convert.ToInt32(sArr[1]), reduceOutput[sensorId].Item2 + 1);
                }
                else
                {
                    reduceOutput.Add(sensorId, (Convert.ToInt32(sArr[1]), 1));
                }
            }

            //Finally, emit each sensorId and average temperature
            foreach ((var key, var value) in reduceOutput)
            {
                //Emit tab-delimited key/value pairs.
                Console.WriteLine("{0}\t{1}", key, value.Item1 / (float)value.Item2);
            }
        }
    }
}