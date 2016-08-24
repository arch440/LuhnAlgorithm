using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnNormal
{
    public class IdentityNumber
    {

        private bool isValidIdNumber = false;
        private string personalNumber;

        /// <summary>
        /// Class that represent a personal identity number.
        /// </summary>
        /// <param name="personalNumber">Identity number. Must be 10 characters.</param>
        public IdentityNumber(string personalNumber)
        {
            if (IsPersonalNumberCorrrect(personalNumber))
            {
                this.PersonalNumber = personalNumber;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public string PersonalNumber
        {
            get { return personalNumber; }
            set { personalNumber = value; }
        }

        public bool ValidNumber
        {
            get { return isValidIdNumber; }
            private set { isValidIdNumber = value; }
        }

        /// <summary>
        /// Method that verify that a PIN is valid.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True is the number is correctly formatted, false otherwise.</returns>
        private bool IsPersonalNumberCorrrect(string number)
        {
            // Check that number is not NULL or empty to avoid exceptions later.
            if (string.IsNullOrEmpty(number))
                return false;

            // Expression check each array element 'digit' is a number for all elements.
            bool isDigits = number.All(digit => Char.IsNumber(digit) == true);
            if (!isDigits)
            {
                return false;
            }
            // Technically a personal number can be 12 digits but we disallow that currently.
            if (number.Length != 10)
            {
                return false;
            }

            return true;
        }

        public bool ValidateUsingLuhn()
        {
            // Validate using the Luhn algorith class.
            return LuhnVerification.VerifyUsingLuhn(this.PersonalNumber);
        }

    }
}
