using System;
using System.Globalization;
using Xamarin.Forms;

namespace RMP2_CalculatorApp;

public partial class MainPage : ContentPage
{
    private double _firstOperand;
    private double _secondOperand;
    private string _mathOperation;
    private CurrentState _currentState = CurrentState.None;

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);
    }

    private void OnSelectNumber(object sender, EventArgs e)
    {
        if (typeof(Button) != sender.GetType()) return;
        var button = (Button)sender;
        var pressed = button.Text;

        if (ResultText.Text == "0" || _currentState == CurrentState.None)
        {
            ResultText.Text = "";
            _currentState = CurrentState.InputFirstOperand;
        }

        if (_currentState == CurrentState.InputOperation)
        {
            ResultText.Text = "";
            _currentState = CurrentState.InputSecondOperand;
        }

        ResultText.Text += pressed;

        if (!double.TryParse(ResultText.Text, out var result)) return;
        ResultText.Text = result.ToString("N0");
        switch (_currentState)
        {
            case CurrentState.InputFirstOperand:
                _firstOperand = result;
                _currentState = CurrentState.InputOperation;
                break;
            case CurrentState.InputSecondOperand:
                _secondOperand = result;
                break;
            case CurrentState.None:
                break;
            case CurrentState.InputOperation:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnSelectOperator(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var pressed = button.Text;
        _mathOperation = pressed;
    }

    private void OnClear(object sender, EventArgs e)
    {
        _currentState = CurrentState.InputFirstOperand;
        ResultText.Text = "0";
        _firstOperand = 0;
        _secondOperand = 0;
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        if (_currentState != CurrentState.InputSecondOperand) return;
        var result = SimpleCalculator.Calculate(_mathOperation, _firstOperand, _secondOperand);
        ResultText.Text = result.ToString(CultureInfo.CurrentCulture);
        _firstOperand = result;
        _currentState = CurrentState.InputOperation;
    }
}