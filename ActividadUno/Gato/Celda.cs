using System.Windows.Controls;
using System.Windows.Media;

namespace Gato
{
    public class Celda : Button
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public Estado Estado { get; set; }

        public Celda()
        {
            ColocarEstadoVisual();
            //Content = "texto";
            //Foreground = new SolidColorBrush(Colors.Purple);
            Tap += CeldaTap;
        }

        private void ColocarEstadoVisual()
        {
            ColocarFondo(ObtenerColorPorEstado());
        }

        private Color ObtenerColorPorEstado()
        {
            var color = Colors.Transparent;
            switch (Estado)
            {
                case Estado.Inactivo:
                    color = Colors.Transparent;
                    break;
                case Estado.JugadorUno:
                    color = Colors.Red;
                    break;
                case Estado.JugadorDos:
                    color = Colors.Blue;
                    break;
            }
            return color;
        }

        private void ColocarFondo(Color color)
        {
            Background = new SolidColorBrush(color);
        }

        void CeldaTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //MessageBox.Show(string.Format("Fila es {0} columna {1}.", Fila.ToString(CultureInfo.InvariantCulture), Columna.ToString(CultureInfo.InvariantCulture)));
            ColocarEstadoVisual();
        }

        public void ReestablecerEstadoInicial()
        {
            Estado = Estado.Inactivo;
            ColocarEstadoVisual();
        }
    }
}
