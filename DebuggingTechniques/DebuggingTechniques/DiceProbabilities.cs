using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingTechniques
{
    class DiceProbabilities
    {
        public static string debug = "";
        public static Dictionary<int, Double> CalculateProbabilitiesForNumberOfDice(int numberOfDice)
        {
            // Track sums' frequency.
            Dictionary<int, int> sumCounts = new Dictionary<int, int>();
            const int NUMBER_OF_SIDES = 6;

            // Determine the range of possible sums from all dice showing 1 to all showing 6.
            int minimumSum = numberOfDice; 
            int maximumSum = numberOfDice * NUMBER_OF_SIDES; 

            // Initialize sums' occurance to zero.
            for (int sum = minimumSum; sum <= maximumSum; sum++)
            {
                sumCounts[sum] = 0;
                debug += sum.ToString() + ":" + sumCounts[sum].ToString() + " ";
            }

            Debug.WriteLine(debug);
            debug = "";

            int[] diceValues = new int[numberOfDice]; // Holds dices' value.

            // Set the initial state of the dice to simulate starting the rolling process.
            for (int diceValue = 0; diceValue < numberOfDice; diceValue++)
            {
                diceValues[diceValue] = 1;
                debug += diceValues[diceValue].ToString() + " ";
            }

            Debug.WriteLine(debug);
            debug = "";

            bool haveAllCombinationsBeenExplored = false;

            // Generate and count all possible outcomes of dice rolls to compute frequencies.
            while (!haveAllCombinationsBeenExplored)
            {
                int sumDiceValues = 0;

                // Sum the dices' value to update frequency counts.
                foreach (int value in diceValues)
                {
                    sumDiceValues += value;
                }

                sumCounts[sumDiceValues] += 1;

                debug += sumDiceValues.ToString() + ":" + sumCounts[sumDiceValues].ToString() + " ";
                Debug.WriteLine(debug);
                debug = "";

                int indexDiceValue = 0;
                bool isWithinSideLimit = false;

                // Iterate through dice values to explore all possible combinations.
                while (!isWithinSideLimit)
                {
                    diceValues[indexDiceValue] += 1;
                    debug += diceValues.ToString() + ":" + diceValues[indexDiceValue].ToString() + " ";

                    // Ensure die value doesn't exceed the  number of sides.
                    if (diceValues[indexDiceValue] <= NUMBER_OF_SIDES)
                    {
                        isWithinSideLimit = true;
                        Debug.WriteLine(debug);
                    }
                    else
                    {
                        // Reset current die and proceed to increment the next if possible.
                        if (indexDiceValue == numberOfDice - 1)
                        {
                            haveAllCombinationsBeenExplored = true; 
                            isWithinSideLimit = true;
                        }
                        else
                        {
                            diceValues[indexDiceValue] = 1; 
                        }
                    }
                    indexDiceValue++; 
                }
            }

            // Store probabilities of each sum occuring from rolling the dice.
            Dictionary<int, Double> rollProbability = new Dictionary<int, double>();

            // Calculate total possible outcomes to use as a denominator in probability calculations.
            Double totalPossibleOutcomes = Math.Pow(6.0, (Double)numberOfDice); 

            
            for (int indexSum = minimumSum; indexSum <= maximumSum; indexSum++)
            {
                rollProbability[indexSum] = (Double)sumCounts[indexSum] / totalPossibleOutcomes;
            }
            return rollProbability;
        }
    }
}
