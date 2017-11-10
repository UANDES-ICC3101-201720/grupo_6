using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaPOO
{
    [Serializable]
    class Comprador
    {
        int categoriaInteres;
        int presupuesto;
        int auto;
        int tiempo;

        public Comprador()
        {
            Random ran = new Random();
            this.categoriaInteres = ran.Next(1, 4);
            this.auto = ran.Next(0, 2);
        }
        public int Auto()
        {
            return auto;
        }
    }
}
