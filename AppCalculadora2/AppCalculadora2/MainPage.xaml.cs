using System;
using Xamarin.Forms;

namespace AppCalculadora2
{
    public partial class MainPage : ContentPage
    {
        string operador = "";
        double primerNumero, segundoNumero;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (pressed == "C")
            {
                pantalla.Text = "";
            }
            else if (pressed == "CE")
            {
                pantalla.Text = "";
                resultado.Text = "";
                primerNumero = 0;
                segundoNumero = 0;
                operador = "";
            }
            else if (pressed == "+" || pressed == "-" || pressed == "x" || pressed == "/")
            {
                if (!string.IsNullOrEmpty(pantalla.Text))
                {
                    primerNumero = double.Parse(pantalla.Text);
                    operador = pressed;
                    pantalla.Text = "";
                }
            }
            else if (pressed == "=")
            {
                if (!string.IsNullOrEmpty(pantalla.Text))
                {
                    segundoNumero = double.Parse(pantalla.Text);
                    if (operador == "/" && segundoNumero == 0)
                    {
                        resultado.Text = "No se puede dividir entre cero";
                    }
                    else
                    {
                        double total = RealizarOperacion(primerNumero, segundoNumero, operador);
                        resultado.Text = total.ToString();
                    }
                    operador = "";
                }
            }
            else
            {
                pantalla.Text += pressed;
            }
        }

        double RealizarOperacion(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "x":
                    return num1 * num2;
                case "/":
                    if (num2 != 0)
                        return num1 / num2;
                    else
                        return double.NaN; // División por cero
                default:
                    return double.NaN;
            }
        }
    }
}
