using System;

namespace CursoOOP
{
  
  internal class Tablero
  {
    private static int DIMENSION = 3;
    private static char VACIA = '_';

    private Coordenada[,] fichas;
    
    public Tablero()
    {
      fichas = new Coordenada[2, 3];
    }

    internal void mostar() 
    {
      GestorIO gestorio = new GestorIO();
      for(int fila=1;fila <= DIMENSION; fila++)
      {
        for (int columna = 1; columna <= DIMENSION; columna++)
        {
          gestorio.mostrar(this.getColor(new Coordenada(fila,columna)));
        }
        gestorio.mostrar("\n");
      }
      gestorio.mostrar("\n");
    }

    private char getColor(Coordenada coordenada)
    {
      if (this.tiene(coordenada, 0))
      {
        return 'o';
      }
      if (this.tiene(coordenada, 1))
      {
        return 'x';
      }
      return VACIA;
    }

    private bool tiene(Coordenada coordenada, int jugador)
    {
      for (int i = 0; i < DIMENSION; i++)
      {
        if(fichas[jugador, i]!=null && fichas[jugador, i].igual(coordenada))
        {
          return true;
        }
      }
      return false;
    }

    
    internal bool ocupada(Coordenada coordenada)
    {
      return this.ocupada(coordenada, 'o') || this.ocupada(coordenada, 'x');

    }
    public Boolean ocupada(Coordenada coordenada, char color)
    {
      int fila = this.getFila(color);
      for (int i = 0; i < DIMENSION; i++)
      {
        if(fichas[fila,i]!=null && fichas[fila, i].igual(coordenada)){
          return true;
        }
      }
      return false;
    }
    internal void ponerFicha(Coordenada coordenada, char color)
    {
      int fila=this.getFila(color);
      int contador = 0;
      while (fichas[fila,contador]!=null)
      {
        contador++;
      }
      fichas[fila, contador] = coordenada;
    }

    public void retirarFicha(Coordenada coordenada)
    {
      for (int i=0; i < DIMENSION; i++)
      {
        for(int j = 0; j < DIMENSION; j++)
        {
          if (fichas[i,j]!=null && fichas[i,j].igual(coordenada))
          {
            fichas[i, j] = null;
            return;
          }
        }
      }
    }

    private int getFila(char color)
    {
      if (color == 'o')
      {
        return 0;
      }
      return 1;
    }

    public Boolean hayTresEnRaya()
    {
      return this.hayTresEnRaya('o') || this.hayTresEnRaya('x');
    }

    private Boolean hayTresEnRaya(char jugador)
    {
      if (!this.estaCompleto(jugador))
      {
        return false;
      }
      int fila = this.getFila(jugador);
      int direccion = fichas[fila, 0].direccion(fichas[fila, 1]);
      if (direccion == -1)
      {
        return false;
      }
      return direccion == fichas[fila, 1].direccion(fichas[fila, 2]);
      
    }

    public Boolean estaCompleto(Jugador jugador)
    {
      return this.estaCompleto(jugador.color());
    }

    public Boolean estaCompleto(char jugador)
    {
      int fila = this.getFila(jugador);
      int contador = 0;
      for (int i = 0; i < DIMENSION ; i++)
      {
        if (fichas[fila,i] != null)
        {
          contador++;
        }
      }
      return contador == DIMENSION;
    }

  }
}