using System;
using System.Collections.Generic;
namespace GOL
{
   //conway game of life
    enum Estado{viva,vacia}
    class Celula 
    {
        public Estado estado_actual;
        public Estado estado_siguiente;
        //Posicion
        public short renglon;
        public short columnas;
        public Tablero tablero;

        public Celula(Estado inicial,Tablero tablero ,short renglon, short columnas)
        {
            estado_actual = inicial;
            this.renglon = renglon;
            this.columnas=columnas;
            this.tablero=tablero;
        }
        public void print(){
             if(this.estado_actual == Estado.vacia){
                //vacio
                Console.WriteLine("░") ;
                }
             else
                 //Viva
                 {
                  Console.WriteLine("█");
                 }
                  

                        }
        public void actualiza_estado(){
            estado_actual = estado_siguiente;
          }

        public void actualiza_estado_siguiente(){
			short vecinas = num_vecinas();
			if(estado_actual == Estado.viva && (vecinas < 2 || vecinas > 3)) {
				estado_siguiente = Estado.vacia;
			}
			if(estado_actual == Estado.vacia && vecinas == 3) {
				estado_siguiente = Estado.viva;
			}
		}

        public short num_vecinas()
        {   short cuenta = 0;
            // 1 
            if (renglon > 0  && columnas > 0)
                {
                  if(  tablero.grid[renglon-1][columnas-1].estado_actual == Estado.viva)
                      cuenta++;
                }
               
            if (renglon > 0  && columnas > 0)
                {
                  if(  tablero.grid[renglon-1][columnas-1].estado_actual == Estado.viva)
                      cuenta++;
                }

            return cuenta;
            
        }
            
        
    } 
    class Tablero
    {
        public List<List<Celula >> grid;
        private short n_renglones;
		private short n_columnas;
		public short num_renglones {
			get {
				return n_renglones;
			}
		}
		public short num_columnas {
			get {
				return n_columnas;
			}
        }
        public Tablero(short num_renglones, short num_columnas){
            n_renglones = num_renglones;
			n_columnas = num_columnas;
              grid = new List<List<Celula>>(); 
              for (short i=0; i<= num_renglones-1; i++)
              {
                 grid.Add(new List<Celula>()); 
                 for (short j = 0; j <= num_columnas-1; j++)
                 {
                    grid[i].Add(new Celula(Estado.vacia, this, i,j));
                 }
              }

        }
        
        public void actualizar_tablero(){
			foreach(List<Celula> renglon in grid)
			{
				foreach(Celula c in renglon)
				{
					c.actualiza_estado_siguiente();
				}
			}       
		}
        public void actualiza_estado_todas(){
            foreach(List<Celula> renglon in grid)
            {
               foreach(Celula c in renglon)
               {
                    c.actualiza_estado();
                }         
            }                  
        } 
        

        //Cambia el estado de todas las celdas


        public void inserta(Celula c){
            if((c.renglon >= 0 && c.renglon <= num_renglones) && (c.columnas >= 0 && c.columnas <= num_columnas))
                grid[c.renglon][c.columnas] = c;
        }

        public void print(){
             foreach ( List<Celula> renglon in grid){
                foreach (Celula c in renglon)
                {
                c.print();
                }
                  Console.WriteLine("");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
              Tablero GoL = new Tablero(5,5);
             GoL.inserta( new Celula(Estado.viva,GoL, 3,3  ) );
             GoL.inserta( new Celula(Estado.viva,GoL, 2,3  ) );
             GoL.inserta( new Celula(Estado.viva,GoL, 1,3  ) );
             GoL.inserta( new Celula(Estado.viva,GoL, 1,1  ) );
             
             GoL.print(); 

             GoL.actualizar_tablero();
             GoL.actualiza_estado_todas();
                Console.WriteLine("");
                GoL.print();
                //
             GoL.actualizar_tablero();
             GoL.actualiza_estado_todas();
            
            //GoL.actualizar();
             Console.WriteLine("");
             GoL.print();
             //break;
             
              
        }
    }
}
