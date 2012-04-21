using System.Windows.Controls;
using System.Windows.Media;

namespace Gato
{
    public class Tablero : Grid
    {
        private const int NumeroFilas = 3;
        private const int NumeroColumnas = 3;


        public Tablero()
        {
            Background = new SolidColorBrush(Colors.White);
            ShowGridLines = true;
            DefinirFilas();
            DefinirColumnas();
            InicializarCeldas();
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
                    var controlEnCelda = CrearAgregarControlEnCelda();
                    
                    SetRow(controlEnCelda, i);
                    SetColumn(controlEnCelda, j);
                }
            }
        }


        private Celda CrearAgregarControlEnCelda()
        {
            var celda = new Celda();
            Children.Add(celda);
            return celda;
        }
    }
}
