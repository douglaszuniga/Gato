using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gato
{
    public class Tablero : Grid
    {
        private const int NumeroFilas = 3;
        private const int NumeroColumnas = 3;

        private Estado _jugador = Estado.JugadorUno;

        public Tablero()
        {
            Background = new SolidColorBrush(Colors.White);
            ShowGridLines = true;
            DefinirFilas();
            DefinirColumnas();
            InicializarCeldas();

            Tap += new System.EventHandler<System.Windows.Input.GestureEventArgs>(OnTableroTap);
        }

        void OnTableroTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var controlEnCelda = (Border)e.OriginalSource;
           
            int fila = GetRow(controlEnCelda);
            int columna = GetColumn(controlEnCelda);
            var punto = e.GetPosition(controlEnCelda);
            MessageBox.Show(e.OriginalSource.GetType().Name);

            //recorrer el grid para determinar si ya hay ganador
            //algoritmo para determinar quien gano en http://stackoverflow.com/questions/1056316/algorithm-for-determining-tic-tac-toe-game-over-java

            //si no hay nada se continua jugando y se cambia el jugador
            //return

            //en caso de ganador determinar quien es y mostrar mensaje
            //en caso de empate, mostrar mensaje
            //limpiar tablero
            //return
        }


        private void CambiarJugador()
        {
            _jugador = _jugador == Estado.JugadorUno ? Estado.JugadorDos : Estado.JugadorUno;
        }

        private void LimpiarCeldas()
        {
            foreach (var child in Children)
            {
                ((Celda)child).ReestablecerEstadoInicial();
            }
        }

        private void DefinirFilas()
        {
            for (var i = 0; i < NumeroFilas; i++)
            {
                RowDefinitions.Add(new RowDefinition());
            }
        }

        private void DefinirColumnas()
        {
            for (var i = 0; i < NumeroColumnas; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void InicializarCeldas()
        {
            for (var i = 0; i < NumeroFilas; i++)
            {
                for (var j = 0; j < NumeroColumnas; j++)
                {
                    IniciarCelda(j, i);
                }
            }
        }

        private void IniciarCelda(int j, int i)
        {
            var controlEnCelda = CrearAgregarControlEnCelda();
            controlEnCelda.Fila = i;
            controlEnCelda.Columna = j;
            PosicionarCelda(controlEnCelda);
        }

        private void PosicionarCelda(Celda controlEnCelda)
        {
            SetRow(controlEnCelda, controlEnCelda.Fila);
            SetColumn(controlEnCelda, controlEnCelda.Columna);
        }

        private Celda CrearAgregarControlEnCelda()
        {
            var celda = new Celda();
            Children.Add(celda);
            return celda;
        }
    }
}
