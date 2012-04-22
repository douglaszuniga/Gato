using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gato
{
    public class Celda : Button
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public Estado Estado { get; set; }
        public Brain GameBrain { get; set; }

        public Celda()
        {
            ColocarEstadoVisual();
            Tap += CeldaTap;
        }

        private void ColocarEstadoVisual()
        {
            ColocarFondo(ObtenerFondoPorEstado());
        }

        private ImageBrush ObtenerFondoPorEstado()
        {
            var fondo = new ImageBrush { ImageSource = new BitmapImage(new Uri("blank.png", UriKind.Relative)), Stretch = Stretch.Uniform };
            switch (Estado)
            {
                case Estado.JugadorUno:
                    fondo = new ImageBrush { ImageSource = new BitmapImage(new Uri("xNegra.png",UriKind.Relative)), Stretch = Stretch.Uniform};
                    break;
                case Estado.JugadorDos:
                    fondo = new ImageBrush { ImageSource = new BitmapImage(new Uri("oNegra.png", UriKind.Relative)), Stretch = Stretch.Uniform };
                    break;
            }
            return fondo;
        }

        private void ColocarFondo(ImageBrush fondo  )
        {
            Background = fondo;
        }

        void CeldaTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (GameBrain.JuegoBloqueado) return;
            Estado = GameBrain.ObtenerJugadorActual();
            GameBrain.IndicarEstadoCelda(Fila, Columna, Estado);
            ColocarEstadoVisual();
        }

        public void ReestablecerEstadoInicial()
        {
            Estado = Estado.Ninguno;
            ColocarEstadoVisual();
        }
    }
}
