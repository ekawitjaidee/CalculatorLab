﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
     public class TheCalculatorEngine
    {

        /// <summary>
        /// this boolean check str is number
        /// </summary>
        /// <param name="str"></param>
        /// <returns>return numbers</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">this is boolean check str is operator</param>
        /// <returns></returns>
        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "1/x":
                case "√":
                case "%":
                    return true;
            }
            return false;
        }

       

        /// <summary>
        /// this is function to calculate 1/x and loot
        /// </summary>
        /// <param name="operate">is string to save a operator</param>
        /// <param name="operand">is string of number to calaulate</param>
        /// <param name="maxOutputSize">max number of return string</param>
        /// <returns>result result</returns>
        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        try
                        {
                            result = Math.Sqrt(Convert.ToDouble(operand));
                        }
                        catch (Exception ex)
                        {
                            return "E";
                        }
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =

                        return result.ToString("G" + remainLength);


                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return Convert.ToDecimal(result.ToString("N" + remainLength)).ToString("G29");
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// this is function to calaulate +,-,*,/,%
        /// </summary>
        /// <param name="operate">is string to save a operater</param>
        /// <param name="firstOperand">is first number </param>
        /// <param name="secondOperand">is second number</param>
        /// <param name="maxOutputSize">max number of return string</param>
        /// <returns>return result</returns>
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return Convert.ToDecimal(result.ToString("N" + remainLength)).ToString("G29");
                    }
                    break;
                case "%":
                    //your code here
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) / 100));

                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDecimal(result.ToString("N" + remainLength)).ToString("G29");

                    }
                    break;
                case "1/x":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = 1 / (Convert.ToDouble(secondOperand));

                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDecimal(result.ToString("N" + remainLength)).ToString("G29");

                    }
                    break;
                case "√":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(firstOperand));

                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return Convert.ToDecimal(result.ToString("N" + remainLength)).ToString("G29");

                    }
                    break;
            }
            return "E";
        }
    }
}

