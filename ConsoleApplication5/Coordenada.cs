using System;

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
  }
}