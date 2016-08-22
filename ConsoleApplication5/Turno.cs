using System;

namespace CursoOOP
{
  internal class Turno
  {
    private int valor;
    public Turno()
    {
      valor =new Random().Next(0, 1);
    }

    internal int toca()
    {
      return valor;
    }

    internal void cambiar()
    {
      valor= this.noToca();
    }

    internal int noToca()
    {
      return (valor+1)%2;
    }
  }
}