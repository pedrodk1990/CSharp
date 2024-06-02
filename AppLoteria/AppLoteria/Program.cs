using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoteria
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[6];
            var rdm = new Random();
            int aleatorio;

            for(var i = 0; i < numeros.Length; i++)
            {
               aleatorio = rdm.Next(1,61);
                while (numeros.Contains(aleatorio))
                {
                    aleatorio = rdm.Next(1, 61);
                }
                    numeros[i] = aleatorio;
                Console.Write(numeros[i].ToString() + " ");
            }
        }
    }
}
