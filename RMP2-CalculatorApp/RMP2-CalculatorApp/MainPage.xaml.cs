using System;
using Xamarin.Forms;

namespace RMP2_CalculatorApp;

public partial class MainPage : ContentPage
{
    private double _firstOperand;
    private double _secondOperand;
    private CurrentState _currentState = CurrentState.InputFirstOperand;

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

        if (ResultText.Text != "0" && _currentState != CurrentState.None) return;
        ResultText.Text = "";
        _currentState = CurrentState.InputFirstOperand;

        ResultText.Text += pressed;

        double result;
        if (double.TryParse(ResultText.Text, out result))
        {
        }
    }

    private void OnSelectOperator(object sender, EventArgs e)
    {
        // throw new NotImplementedException();
    }

    private void OnClear(object sender, EventArgs e)
    {
        _currentState = CurrentState.None;
        _firstOperand = 0;
        _secondOperand = 0;
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        // throw new NotImplementedException();
    }
}