using System;

namespace CursoOOP
{
  internal class Jugador
  {
    private char colorjugador;

    public Jugador(char Color)
    {
      this.colorjugador = Color;
    }
    internal char color()
    {
      return colorjugador;
    }

    internal void ponerFicha(Tablero tablero)
    {
      this.ponerFicha(tablero, null);
    }

    private void ponerFicha(Tablero tablero,Coordenada coordenadarepetida)
    {
      new GestorIO().mostrar(string.Format("Pone el jugador con {0} {1}", colorjugador, "\n"));
      tablero.ponerFicha(this.recogerCoordenadaPuestaValida(tablero, coordenadarepetida), colorjugador);
    }

    private Coordenada recogerCoordenadaPuestaValida(Tablero tablero, Coordenada coordenadarepetida)
    {
      Coordenada resultado = new Coordenada();
      string error = "";
      do
      {
        resultado.recoger();
        error = this.errorPuesta(tablero, resultado, coordenadarepetida);
        if (!error.Equals("")) {
          new GestorIO().mostrar(string.Format("Error!!! {0} {1}", error, "\n"));
        }
      } while (!error.Equals(""));
      return resultado;
    }

    private string errorPuesta(Tablero tablero, Coordenada coordenada, Coordenada coordenadaRepetida)
    {
      if (tablero.ocupada(coordenada))
      {
        return "Coordenada ocupada en el tablero";
      }
      if (coordenadaRepetida!=null && coordenadaRepetida.igual(coordenada))
      {
        return "No se puede poner donde se quitó la ficha.";
      }
      return "";
    }

    internal void moverFicha(Tablero tablero)
    {
      new GestorIO().mostrar(string.Format("Mueve el jugador con {0} {1}", colorjugador, "\n"));
      Coordenada retirada = this.recogerCoordenadaRetiradaValida(tablero);
      tablero.retirarFicha(retirada);
      this.ponerFicha(tablero, retirada);
    }

    private Coordenada recogerCoordenadaRetiradaValida(Tablero tablero)
    {
      Coordenada resultado = new Coordenada();
      String error = "";
      do
      {
        resultado.recoger();
        error = this.errorRetirada(tablero, resultado);
        if (!error.Equals(""))
        {
          new GestorIO().mostrar(string.Format("Error!!! {0} {1}", error, "\n"));
        }

      } while (!error.Equals(""));
      return resultado;
    }

    private string errorRetirada(Tablero tablero, Coordenada coordenada)
    {
      if (!tablero.ocupada(coordenada, colorjugador))
      {
        return string.Format("Coordenada no ocupada  en el tablero por una ficha {0}", colorjugador);
      }
      return "";
    }

    internal void cantaVictoria()
    {
      new GestorIO().mostrar(string.Format("Victoria del color: {0}", colorjugador));
    }    
  }
}