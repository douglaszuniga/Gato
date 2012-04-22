using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gato
{
    public class GatoUI : Grid
    {
        private Brain _brain;
        private Tablero _tablero;
        private Cabecera _cabecera;
        
        public GatoUI()
        {
            _brain = new Brain();
            Background = new SolidColorBrush(Colors.White);

            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition{Height = new GridLength(562)});

            _tablero = new Tablero {GameBrain = _brain};
            _tablero.Init();
            Children.Add(_tablero);
            SetRow(_tablero, 1);

            _cabecera = new Cabecera();
            Children.Add(_cabecera);
            SetRow(_cabecera, 0);

            Tap += GatoUI_Tap;
        }

        void GatoUI_Tap(object sender, GestureEventArgs e)
        {
            if (_cabecera.NuevoJuegoPedido)
            {
                JuegoNuevo();
                _cabecera.NuevoJuegoPedido = false;
                return;
            }

            if (_brain.JuegoBloqueado) return;

            ResolverEstadoDelJuego();    
        }

        private void ResolverEstadoDelJuego()
        {
            var estadoJuego = _brain.ResolverEstadoJuego();
            if (estadoJuego != Estado.Continuar) FinalizarJuego(estadoJuego);
        }

        private void FinalizarJuego(Estado estadoJuego)
        {
            MostrarResultado(estadoJuego);
            _brain.JuegoBloqueado = true;
        }

        private void MostrarResultado(Estado estadoJuego)
        {
            _cabecera.CambiarTextoResultado(estadoJuego);
        }

        private void JuegoNuevo()
        {
            _brain.EstablecerValoresDefault();
            _tablero.LimpiarCeldas();
            _cabecera.NuevoJuegoPedido = false;
            _cabecera.CambiarTextoResultado(Estado.Continuar);
        }
    }
}
