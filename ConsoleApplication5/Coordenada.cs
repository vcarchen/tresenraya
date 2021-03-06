﻿using System;

namespace CursoOOP
{
  internal class Coordenada
  {
    private int fila;
    private int columna;
    private static Intervalo LIMITES = new Intervalo(1, 3);

    public Coordenada()
    {
    }

    public Coordenada(int fila, int columna)
    {
      this.fila = fila;
      this.columna = columna;
    }

    public int getFila()
    {
      return fila;
    }

    public int getColumna()
    {
      return columna;
    }
    internal Boolean valida()
    {
      return LIMITES.incluye(fila) && LIMITES.incluye(columna);
    }
    public void recoger()
    {
      GestorIO gestorIO = new GestorIO();
      Boolean error = false;
      do
      {
        gestorIO.mostrar("Introduce fila [1,3]: ");
        fila = gestorIO.inInt();
        gestorIO.mostrar("Introduce columna [1,3]: ");
        columna = gestorIO.inInt();
        error = !this.valida();
        if (error)
        {
          gestorIO.mostrar("Error!!! Valores fuera de rango\n");
        }
      } while (error);
    }

    internal bool igual(Coordenada coordenada)
    {
      return fila == coordenada.fila && columna == coordenada.columna;
    }
<<<<<<< HEAD

    internal int direccion(Coordenada coordenada)
    {
      if (fila == coordenada.fila)
      {
        return 0;
      }
      if (columna == coordenada.columna)
      {
        return 1;
      }
      if (fila - columna == 0 && coordenada.fila - coordenada.columna == 0)
      {
        return 2;
      }
      if (fila + columna == 4 && coordenada.fila + coordenada.columna == 4)
      {
        return 3;
      }
      return -1;
    }
=======
>>>>>>> 3e2c08cdd1376868006d790a8bc5b29ae63fa7ca
  }
}