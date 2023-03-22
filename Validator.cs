using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterProject_XuanLu1
{
    /// <summary>
    /// this class provide methods to check the validity of data entry
    /// </summary>
    public static class Validator
    {
        //fields
        private static string lineEnd = "\n";

        //properties
        /// <summary>
        ///  this is the setter and getter for the line end character
        /// </summary>
        public static string LineEnd { get; set; }

        public static frmCustomerInf frmCustomerInf
        {
            get => default;
            set
            {
            }
        }

        //methods
        /// <summary>
        /// check if a value is present
        /// </summary>
        /// <param name="value">This is the value entered in a control </param>
        /// <param name="name">This is the name of the control stored in the tag</param>
        /// <returns>Returns a message string </returns>
        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field. " + lineEnd;
            }
            return msg;
        }
        /// <summary>
        /// Check if a value is decimal
        /// </summary>
        /// <param name="value">This is the value entered in a control</param>
        /// <param name="name">This is the name of the control stored in the tag</param>
        /// <returns>Returns a message string</returns>
        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be valid decimal value. " + lineEnd;
            }
            return msg;
        }
    }
}

