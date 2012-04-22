using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gato
{
    public class Tablero : Grid
    {
        public Brain GameBrain { get; set; }

        public Tablero()
        {
            Background = new SolidColorBrush(Colors.White);
            ShowGridLines = true;
            DefinirFilas();
            DefinirColumnas();
        }

        public void Init()
        {
            InicializarCeldas();
        }

        public void LimpiarCeldas()
        {
            foreach (var child in Children)
            {
                ((Celda)child).ReestablecerEstadoInicial();
            }
        }

        private void DefinirFilas()
        {
            for (var i = 0; i < Constantes.NumeroFilas; i++)
            {
                RowDefinitions.Add(new RowDefinition());
            }
        }

        private void DefinirColumnas()
        {
            for (var i = 0; i < Constantes.NumeroColumnas; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void InicializarCeldas()
        {
            for (var i = 0; i < Constantes.NumeroFilas; i++)
            {
                for (var j = 0; j < Constantes.NumeroColumnas; j++)
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
            controlEnCelda.GameBrain = GameBrain;
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
