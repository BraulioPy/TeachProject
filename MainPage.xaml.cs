using TeachProject.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
namespace TeachProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Bvolver.IsVisible = false;
        }

        private async void suma(object sender, EventArgs e)
        {
            Toperacion.Text = "Suma";
            int aciertos = 0;
            ZonaBotones.IsVisible = false;
            ZonaRespuesta.IsVisible = true;
            int i = 0;
            do
            {
                i++;
                Operacion operacion = GenerarOperacion("sum");
                Loperacion.Text = operacion.operacion;
                bool continuar = await EsperarSegundos(operacion.tiempo);
                if (continuar)
                {
                    double escrito = double.TryParse(Lrespuesta.Text ?? "0", out double result) ? result : 0;
                    if (escrito == operacion.resultado)
                    {
                        aciertos += 1;
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                    else
                    {
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                }
                if(aciertos == 5)
                {
                    Laciertos.Text = $"Has terminado | Score: {aciertos}/5";
                    Bvolver.IsVisible = true;
                    break;
                }
            } while (i <= 5);
        }


        private async void resta(object sender, EventArgs e)
        {
            Toperacion.Text = "Resta";
            int aciertos = 0;
            ZonaBotones.IsVisible = false;
            ZonaRespuesta.IsVisible = true;
            int i = 0;
            do
            {
                i++;
                Operacion operacion = GenerarOperacion("res");
                Loperacion.Text = operacion.operacion;
                bool continuar = await EsperarSegundos(operacion.tiempo);
                if (continuar)
                {
                    double escrito = double.TryParse(Lrespuesta.Text ?? "0", out double result) ? result : 0;
                    if (escrito == operacion.resultado)
                    {
                        aciertos += 1;
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                    else
                    {
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                }
                if (aciertos == 5)
                {
                    Laciertos.Text = $"Has terminado | Score: {aciertos}/5";
                    Bvolver.IsVisible = true;
                    break;
                }
            } while (i <= 5);
        }

        private async void multiplicacion(object sender, EventArgs e)
        {
            Toperacion.Text = "Multiplicación";
            int aciertos = 0;
            ZonaBotones.IsVisible = false;
            ZonaRespuesta.IsVisible = true;
            int i = 0;
            do
            {
                i++;
                Operacion operacion = GenerarOperacion("mul");
                Loperacion.Text = operacion.operacion;
                bool continuar = await EsperarSegundos(operacion.tiempo);
                if (continuar)
                {
                    double escrito = double.TryParse(Lrespuesta.Text ?? "0", out double result) ? result : 0;
                    if (escrito == operacion.resultado)
                    {
                        aciertos += 1;
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                    else
                    {
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                }
                if (aciertos == 5)
                {
                    Laciertos.Text = $"Has terminado | Score: {aciertos}/5";
                    Bvolver.IsVisible = true;
                    break;
                }
            } while (i <= 5);
        }

        private async void division(object sender, EventArgs e)
        {
            Toperacion.Text = "División";
            int aciertos = 0;
            ZonaBotones.IsVisible = false;
            ZonaRespuesta.IsVisible = true;
            int i = 0;
            do
            {
                i++;
                Operacion operacion = GenerarOperacion("div");
                Loperacion.Text = operacion.operacion;
                bool continuar = await EsperarSegundos(operacion.tiempo);
                if (continuar)
                {
                    double escrito = double.TryParse(Lrespuesta.Text ?? "0", out double result) ? result : 0;
                    if (escrito == operacion.resultado)
                    {
                        aciertos += 1;
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                    else
                    {
                        Laciertos.Text = $"llevas {aciertos} aciertos de 5";
                        Lrespuesta.Text = "";
                    }
                }
                if (aciertos == 5)
                {
                    Laciertos.Text = $"Has terminado | Score: {aciertos}/5";
                    Bvolver.IsVisible = true;
                    break;
                }
            } while (i <= 5);
        }

        private void volver(object sender, EventArgs e)
        {
            volverALaNormalidad();
            LtiempoRestante.Text = "--";
            Laciertos.Text = "-- Aciertos";
            Toperacion.Text = "--";
        }
        private void volverALaNormalidad()
        {
            ZonaBotones.IsVisible = true;
            ZonaRespuesta.IsVisible = false;
            Bvolver.IsVisible = false;
        }
        public Operacion GenerarOperacion(string tipo)
        {
            List<string> Operacion = GenerarOperacionMatematica(tipo);
            Random rand = new Random();
            int segundos = rand.Next(5, 11);
            Operacion operacionnueva = new Operacion { 
                tiempo = segundos,
                operacion = Operacion[0],
                resultado = Convert.ToDouble(Operacion[1])
            };
            return operacionnueva;

        }
        public List<string> GenerarOperacionMatematica(string tipoOperacion = "mix")
        {
            Random rand = new Random();

            // 1. Generar números aleatorios
            int num1 = rand.Next(1, 10);
            int num2 = rand.Next(1, 10);
            int num3 = rand.Next(1, 10);

            // 2. Determinar operadores según el tipo solicitado
            string op1, op2;

            switch (tipoOperacion.ToLower())
            {
                case "sum":
                    op1 = "+";
                    op2 = rand.Next(2) == 0 ? "+" : "-"; // 50% de probabilidad de otro operador
                    break;

                case "res":
                    op1 = "-";
                    op2 = rand.Next(2) == 0 ? "-" : "+";
                    break;

                case "mul":
                    op1 = "*";
                    op2 = rand.Next(2) == 0 ? "*" : "/";
                    break;

                case "div":
                    op1 = "/";
                    op2 = rand.Next(2) == 0 ? "/" : "*";
                    break;

                default: // "mix" o cualquier otro valor
                    string[] todosOperadores = { "+", "-", "*", "/" };
                    op1 = todosOperadores[rand.Next(todosOperadores.Length)];
                    op2 = todosOperadores[rand.Next(todosOperadores.Length)];
                    break;
            }

            // 3. Elegir formato con paréntesis
            string[] formatos = {
        $"{num1} {op1} {num2} {op2} {num3}",
        $"({num1} {op1} {num2}) {op2} {num3}",
        $"{num1} {op1} ({num2} {op2} {num3})",
        $"{{ {num1} {op1} {num2} }} {op2} {num3}",
        $"[ {num1} {op1} {num2} ] {op2} {num3}",
        $"{num1} {op1} {{ {num2} {op2} {num3} }}",
        $"({num1} {op1} {num2} {op2} {num3})"
    };

            string operacion = formatos[rand.Next(formatos.Length)];

            // 4. Calcular resultado (asegurando división entera cuando sea necesario)
            if (op1 == "/" || op2 == "/")
            {
                // Asegurar que las divisiones sean exactas
                if (op1 == "/") num1 = num2 * rand.Next(1, 3);
                if (op2 == "/") num3 = num2 * rand.Next(1, 3);

                // Reconstruir la operación con los números ajustados
                operacion = formatos[rand.Next(formatos.Length)]
                    .Replace(num1.ToString(), num1.ToString())
                    .Replace(num2.ToString(), num2.ToString())
                    .Replace(num3.ToString(), num3.ToString());
            }

            string expresionCalculo = operacion.Replace("{", "(").Replace("}", ")")
                                             .Replace("[", "(").Replace("]", ")");
            double resultado = Convert.ToDouble(new DataTable().Compute(expresionCalculo, null));

            // 5. Retornar la lista
            return new List<string> {
        operacion,
        resultado.ToString("0.##")
    };
        }



        //Funcion para esperar 5 segundos
        public async Task<bool> EsperarSegundos(int segundos)
        {
            Console.WriteLine($"Iniciando conteo de {segundos} segundos...");

            // Configurar el formato inicial
            LtiempoRestante.Text = $"{segundos} segundos";

            for (int i = segundos; i > 0; i--)
            {
                // Actualizar la etiqueta
                LtiempoRestante.Text = $"{i} segundos";

                // Esperar 1 segundo (usando delay cancelable)
                try
                {
                    await Task.Delay(1000); // 1000 ms = 1 segundo
                }
                catch (TaskCanceledException)
                {
                    LtiempoRestante.Text = "Cancelado";
                    return false;
                }
            }

            LtiempoRestante.Text = "¡Tiempo completado!";
            return true;
        }
    }

}
