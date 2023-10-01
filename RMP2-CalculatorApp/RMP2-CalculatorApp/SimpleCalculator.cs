using System;

namespace RMP2_CalculatorApp;

public static class SimpleCalculator
{
    public static double Calculate(string mathOperation, double firstOperand, double secondOperand)
    {
        var result = mathOperation switch
        {
            "+" => firstOperand + secondOperand,
            "-" => firstOperand - secondOperand,
            @"÷" => firstOperand / secondOperand,
            @"×" => firstOperand * secondOperand,
            _ => 0d
        };

        return result;
    }
}