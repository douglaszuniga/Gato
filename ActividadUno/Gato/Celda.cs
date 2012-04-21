using System.Windows.Controls;
using System.Windows.Media;

namespace Gato
{
    public class Celda : Button
    {
        public Celda()
        {
            Background = new SolidColorBrush(Colors.White);
            Content = "prueba";
            Foreground = new SolidColorBrush(Colors.Red);
        }
    }
}
