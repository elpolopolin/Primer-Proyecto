using System.Collections.Generic;
using System;

namespace sala_de_escape.Models
{


public static class escape{
    private static List<string> _incognitasSalas = new List<string>();
    private static int estadoJuego = 1;
    
            private static void InicializarLista()
        {
            _incognitasSalas.Add("7");
            _incognitasSalas.Add("YETA");
            _incognitasSalas.Add("NO BINARIO");
            _incognitasSalas.Add("RIBER");


        }

        public static int EstadoJuego
        {
            get {return estadoJuego;}
        }

    


    public static void Reiniciar()
    {
        estadoJuego = 1;
    }

    public static bool ResolverSala(int sala, string Respuesta)
       {
           if (_incognitasSalas.Count() != 5){
               InicializarLista();
           }           
           if  (Respuesta.ToUpper() == _incognitasSalas[sala-1]){
               estadoJuego = sala  + 1;
               return true;
               
           }
           else {
               estadoJuego = sala;
               return false;
           }       


       }

       

       


}
}


            

