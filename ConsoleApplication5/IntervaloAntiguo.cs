using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CursoOOP
{
  public class IntervaloAntiguo
  {
    private double inferior;

    private double superior;

    public IntervaloAntiguo(double inferior, double superior)
    {
      this.inferior = inferior;
      this.superior = superior;
    }

    public IntervaloAntiguo(double superior) : this(0, superior)
    {

    }

    public IntervaloAntiguo(IntervaloAntiguo IntervaloAntiguo) : this(IntervaloAntiguo.inferior, IntervaloAntiguo.superior)
    {

    }

    public IntervaloAntiguo() : this(0, 0)
    {

    }

    public IntervaloAntiguo clone()
    {
      return new IntervaloAntiguo(this);
    }

    public double longitud()
    {
      return superior - inferior;
    }

    public void desplazar(double desplazamiento)
    {
      inferior += desplazamiento;
      superior += desplazamiento;
    }

    public IntervaloAntiguo desplazado(double desplazamiento)
    {
      IntervaloAntiguo IntervaloAntiguo = this.clone();
      IntervaloAntiguo.desplazar(desplazamiento);
      return IntervaloAntiguo;
    }

    public Boolean incluye(double valor)
    {
      return inferior <= valor && valor <= superior;
    }

    public Boolean incluye(IntervaloAntiguo IntervaloAntiguo)
    {
      Debug.Assert(IntervaloAntiguo != null);
      return this.incluye(IntervaloAntiguo.inferior) &&
          this.incluye(IntervaloAntiguo.superior);
    }

    public Boolean equals(IntervaloAntiguo IntervaloAntiguo)
    {
      Debug.Assert(IntervaloAntiguo != null);
      return inferior == IntervaloAntiguo.inferior &&
          superior == IntervaloAntiguo.superior;
    }

    public IntervaloAntiguo interseccion(IntervaloAntiguo IntervaloAntiguo)
    {
      Debug.Assert(this.intersecta(IntervaloAntiguo));
      if (this.incluye(IntervaloAntiguo))
      {
        return IntervaloAntiguo.clone();
      }
      else if (IntervaloAntiguo.incluye(this))
      {
        return this.clone();
      }
      else if (this.incluye(IntervaloAntiguo.inferior))
      {
        return new IntervaloAntiguo(IntervaloAntiguo.inferior, superior);
      }
      else {
        return new IntervaloAntiguo(inferior, IntervaloAntiguo.superior);
      }
    }

    public Boolean intersecta(IntervaloAntiguo IntervaloAntiguo)
    {
      Debug.Assert(IntervaloAntiguo != null);
      return this.incluye(IntervaloAntiguo.inferior) ||
          this.incluye(IntervaloAntiguo.superior) ||
          IntervaloAntiguo.incluye(this);
    }

    public void oponer()
    {
      double inferiorInicial = inferior;
      double superiorInicial = superior;
      inferior = -superiorInicial;
      superior = -inferiorInicial;
    }

    public void doblar()
    {
      double longitudInicial = this.longitud();
      inferior -= longitudInicial / 2;
      superior += longitudInicial / 2;
    }

    public void recoger()
    {
      GestorIO gestorIO = new GestorIO();
      gestorIO.mostrar("Inferior?");
      inferior = gestorIO.inDouble();
      gestorIO.mostrar("Superior?");
      superior = gestorIO.inDouble();
    }

    public void mostrar()
    {
      new GestorIO().mostrar("[" + inferior + "," + superior + "]");
    }

    public IntervaloAntiguo[] trocear(int trozos)
    {
      return null;
    }
  
  }
}
