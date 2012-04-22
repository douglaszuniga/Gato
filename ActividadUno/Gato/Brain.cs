using System;

namespace Gato
{
    public class Brain
    {
        private Estado[,] _matrizJuego;
        private Estado _jugador;
        private int _numeroMovimientos;
        public int UltimaFilaSeleccionada { get; set; }
        public int UltimaColumnaSeleccionada { get; set; }
        public bool JuegoBloqueado { get; set; }

        public Brain()
        {
            _numeroMovimientos = 0;
            _jugador = Estado.JugadorUno;
            _matrizJuego = new Estado[Constantes.NumeroFilas, Constantes.NumeroColumnas];
        }

        public void IndicarEstadoCelda(int fila, int columna, Estado estado)
        {
            if (_matrizJuego == null) return;
            _matrizJuego[fila, columna] = estado;
            UltimaFilaSeleccionada = fila;
            UltimaColumnaSeleccionada = columna;
            _numeroMovimientos++;
        }

        public void EstablecerValoresDefault()
        {
            LimpiarCeldas();
            _numeroMovimientos = 0;
            UltimaColumnaSeleccionada = 0;
            UltimaFilaSeleccionada = 0;
            _jugador = Estado.JugadorUno;
            JuegoBloqueado = false;
        }

        private void LimpiarCeldas()
        {
            for (var i = 0; i < Constantes.NumeroFilas; i++)
            {
                for (var j = 0; j < Constantes.NumeroColumnas; j++)
                {
                    _matrizJuego [i,j] = Estado.Ninguno;
                }
            }
        }

        public Estado ObtenerJugadorActual()
        {
            return _jugador;
        }
        public void CambiarJugador()
        {
            _jugador = _jugador == Estado.JugadorUno ? Estado.JugadorDos : Estado.JugadorUno;
        }

        public Estado ResolverEstadoJuego()
        {
            if (CumpleMinimoMovimientos())
            {
                if (VerificarEmpate())
                {
                    return Estado.Ninguno;
                }
                if (ExisteGanador())
                {
                    return _jugador;
                }
            }
            return ContinuarJuego();
        }

        private bool CumpleMinimoMovimientos()
        {
            return _numeroMovimientos >= 5;
        }

        private Estado ContinuarJuego()
        {
            CambiarJugador();
            return Estado.Continuar;
        }

        private bool ExisteGanador()
        {
            return VerificarDiagonal() || VerificarColumnas() || VerificarFilas() || VerificarAntiDiagonal();
        }
        private bool VerificarColumnas()
        {
            var ganaPorColumnas = true;
            for (var i = 0; i < Constantes.NumeroColumnas; i++)
            {
                if (_matrizJuego[UltimaFilaSeleccionada, i] == _jugador) continue;
                ganaPorColumnas = false;
                break;
            }
            return ganaPorColumnas;
        }
        private bool VerificarFilas()
        {
            var ganaPorColumnas = true;
            for (var i = 0; i < Constantes.NumeroColumnas; i++)
            {
                if (_matrizJuego[i, UltimaColumnaSeleccionada] == _jugador) continue;
                ganaPorColumnas = false;
                break;
            }
            return ganaPorColumnas;
        }
        private bool VerificarDiagonal()
        {
            if (UltimaFilaSeleccionada != UltimaColumnaSeleccionada) return false;

            var ganaPorColumnas = true;
            for (var i = 0; i < Constantes.NumeroColumnas; i++)
            {
                if (_matrizJuego[i, i] == _jugador) continue;
                ganaPorColumnas = false;
                break;
            }
            return ganaPorColumnas;
        }
        private bool VerificarAntiDiagonal()
        {
            var ganaPorColumnas = true;
            const int valorColumna = Constantes.NumeroColumnas - 1;
            for (var i = 0; i < Constantes.NumeroColumnas; i++)
            {
                if (_matrizJuego[i, valorColumna - i] == _jugador) continue;
                ganaPorColumnas = false;
                break;
            }
            return ganaPorColumnas;
        }
        private bool VerificarEmpate()
        {
            return _numeroMovimientos == (int)((Math.Pow(Constantes.NumeroFilas, 2)));
        }
    }
}
