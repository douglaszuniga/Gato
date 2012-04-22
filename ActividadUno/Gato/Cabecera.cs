using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gato
{
    public class Cabecera : StackPanel
    {
        public bool NuevoJuegoPedido { get; set; }

        private TextBlock resultado;

        public Cabecera()
        {

            Background = new SolidColorBrush(Colors.White);
            Orientation = Orientation.Vertical;

            var nombreJuego = new TextBlock { Text = "Tres en Línea", FontSize = 78, Foreground = new SolidColorBrush(Colors.Black), HorizontalAlignment = HorizontalAlignment.Center};
            Children.Add(nombreJuego);

            var nuevoJuego = new Button {Content = "Iniciar nuevo Juego", Background = new SolidColorBrush(Colors.Black)};
            nuevoJuego.Tap += nuevoJuego_Tap;
            Children.Add(nuevoJuego);

            Grid resultadoGrid = new Grid{Background = new SolidColorBrush(Colors.White), ShowGridLines = false};

            resultadoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            resultadoGrid.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)});
            resultadoGrid.RowDefinitions.Add(new RowDefinition());

            var labelResultado = new TextBlock { Text = "Resultado:", FontSize = 22, Foreground = new SolidColorBrush(Colors.Black), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            resultadoGrid.Children.Add(labelResultado);
            Grid.SetColumn(labelResultado, 0);

            resultado = new TextBlock { Text = "En proceso.", FontSize = 22, Foreground = new SolidColorBrush(Colors.Black), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            resultadoGrid.Children.Add(resultado);
            Grid.SetColumn(resultado, 1);

            Children.Add(resultadoGrid);
        }

        void nuevoJuego_Tap(object sender, GestureEventArgs e)
        {
            NuevoJuegoPedido = true;
        }

        public void CambiarTextoResultado(Estado estado)
        {
            if (estado == Estado.JugadorUno)
            {
                resultado.Text = "Equix gana.";
            }
            if (estado == Estado.JugadorDos)
            {
                resultado.Text = "Circulo gana.";
            }
            if (estado == Estado.Ninguno)
            {
                resultado.Text = "Empatados.";
            }
            if (estado == Estado.Continuar)
            {
                resultado.Text = "En Proceso.";
            }
        }
    }
}
