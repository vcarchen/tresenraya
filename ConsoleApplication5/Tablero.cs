using System;

namespace CursoOOP
{
  
  internal class Tablero
  {
    private static int DIMENSION = 3;
    private static char VACIA = '_';
    private char[,] casillas;
    
    public Tablero()
    {
      casillas = new char[DIMENSION,DIMENSION];
      for (int fila = 0; fila < DIMENSION; fila++)
      {
        for (int columna = 0; columna < DIMENSION; columna++)
        {
          casillas[fila,columna]=VACIA;
        }
      }
    }

    internal void mostar() 
    {
      GestorIO gestorio = new GestorIO();
      for(int fila=0;fila< DIMENSION; fila++)
      {
        for (int columna = 0; columna < DIMENSION; columna++)
        {
          gestorio.mostrar(" " + casillas[fila,columna]);
        }
        gestorio.mostrar("\n");
      }
    }

    internal void ponerFicha(Coordenada coordenada, char colorjugador)
    {
      casillas[coordenada.getFila() - 1,coordenada.getColumna() - 1] = colorjugador;
    }

    public void retirarFicha(Coordenada coordenada)
    {
      this.ponerFicha(coordenada, VACIA);
    }

    internal bool ocupada(Coordenada coordenada)
    {
      return casillas[coordenada.getFila() - 1,coordenada.getColumna() - 1] !=VACIA ;
    }
    public Boolean ocupada(Coordenada coordenada, char color)
    {
      return casillas[coordenada.getFila() - 1,coordenada.getColumna() - 1] == color;
    }
    public Boolean hayTresEnRaya()
    {
      return this.hayTresEnRaya('x') || this.hayTresEnRaya('o');
    }

    private Boolean hayTresEnRaya(char color)
    {
      int[] filas = new int[DIMENSION];
      int[] columnas = new int[DIMENSION];
      int diagonal = 0;
      int secundaria = 0;
      for (int i = 0; i < DIMENSION; i++)
      {
        for (int j = 0; j < DIMENSION; j++)
        {
          if (color == casillas[i,j])
          {
            filas[i]++;
            columnas[j]++;
            if (i == j)
            {
              diagonal++;
            }
            if (i + j == 2)
            {
              secundaria++;
            }
          }
        }
      }
      if (diagonal == DIMENSION || secundaria == DIMENSION)
      {
        return true;
      }
      else {
        for (int i = 0; i < DIMENSION; i++)
        {
          if (filas[i] == DIMENSION || columnas[i] == DIMENSION)
          {
            return true;
          }
        }
      }
      return false;
    }

    internal bool estaCompleto(Jugador jugador)
    {
      int fichas=0;
      for (int i = 0; i < DIMENSION; i++)
      {
        for (int j = 0; j < DIMENSION; j++)
        {
          if (jugador.color() == casillas[i, j])
          {
            fichas++;
          }
        }
      }
      return fichas==DIMENSION;
    }
  }
}