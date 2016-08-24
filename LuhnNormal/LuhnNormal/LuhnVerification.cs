using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnNormal
{
    public static class LuhnVerification
    {
        /// <summary>
        /// Generic implmentation of the Luhn Algorithm.
        /// Works with any length number.
        /// </summary>
        /// <param name="idNumber">The tested number</param>
        /// <returns>True if the number is valid according to the algorithm.</returns>
        public static bool VerifyUsingLuhn(string idNumber)
        {
            int CHECKSUMSIZE = (idNumber.Length / 2) + 1;

            // Generate repeating squence of alternating ones and twos (1 2 1 2 ...)
            IEnumerable<string> sequence = Enumerable.Repeat("21", CHECKSUMSIZE);

            // Join the sqence to a string of values.
            string mergedSequence = string.Join("", sequence);

            // Construct a sequence from both sequences to enable digit by digit comparison.
            char[] idValues = idNumber.ToArray<char>();
            char[] checksumValues = mergedSequence.ToArray<char>();

            double accumulatedChecksum = 0;
            for (int i = 0; i < idValues.Length; i++)
            {
                // Multiply each digit and convert to integer to prepare for modulo math
                double inputDigit = Char.GetNumericValue(idValues[i]);
                double validationDigit = Char.GetNumericValue(checksumValues[i]);
                int multiplicationResult = (int)(inputDigit * validationDigit);

                // Split number by using standard MOD 10 operation and add to accumulator
                accumulatedChecksum += multiplicationResult % 10;
                accumulatedChecksum += multiplicationResult / 10;
            }

            // Calculate Luhn control digit specified as the MOD 10 value.
            double controlNumber = accumulatedChecksum % 10;

            // Luhn algorith specifies that a zero control digit is a valid number.
            if (controlNumber == 0)
            {
                return true;
            }
            return false;
        }
    }
}
