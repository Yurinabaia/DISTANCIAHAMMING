using System;
using System.Collections.Generic;
using App.Entidades;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            M classeM = new M();
            //1º Definimos a quantidade de bit
            //Formula 2*D + 1
            Console.WriteLine("Digite a quantidade de bits");
            int bits = int.Parse(Console.ReadLine());
            int formula = (2 * bits) + 1;//3
            //vai 1 bits
            Console.WriteLine("Digite o codigo de transmissao");
            string transimor = Console.ReadLine();
            // 8 algarismo
            double qtdAlgarismo =  transimor.ToString().ToCharArray().Length + 1;
            double qtdbits = qtdAlgarismo + formula;
            List<double> X = new List<double>();
            for (var i = 0; Math.Pow(2, i) < qtdbits + 1; i++)
            {
                X.Add(Math.Pow(2,i));
            }
            List<double> Mss = new List<double>();
            for (int i = 1; i <= qtdbits; i++)
            {
                if (!X.Exists(r => r == i))
                    Mss.Add(i);
            }


            List<string> ListaXar = new List<string>();
            int soma = 0, cont = 0;
            string certo = "";
            foreach (var item in Mss)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            for (int i = 2; i < qtdbits; i++)
            {
               string a =  classeM.printCombination(X, X.Count, i);

                char[] arr = a.ToCharArray();
                for (int j = 0; j< arr.Length; j++)
                {

                    if (arr[j] != ',')
                    {
                        soma = soma + int.Parse(arr[j].ToString());
                        int valor = (int)Math.Log2(double.Parse(arr[j].ToString()));
                        certo += valor.ToString();
                    }
                    else if (Mss.Exists(r => r == soma)) 
                    {
                        //Console.WriteLine(soma);
                        ListaXar.Add(certo.ToString());
                        certo = "";
                        cont++;
                        soma = 0;
                    }
                    else if (arr[j] == ',')
                    {
                        soma = 0;
                        certo = "";
                    }
                }
            }
            foreach (var item in Mss)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("###################--------------------#######################################################");

            ValoresDeM(ListaXar, X.Count, transimor);
        }
        public static void ValoresDeM(List<string> listasX, int qtdX, string trasmi) 
        {
            List<int> ValorFinalX = new List<int>();
            int cont = 1, XOR = 0, j = 0;
            bool entrou = false;
            char[] arr = trasmi.ToString().ToCharArray();

            for (int i = 0; i < qtdX; i++)
            {
                foreach (var item in listasX)
                {
                    if (item.Contains(i.ToString())) 
                    {
                        if (j > arr.Length -1)
                            j = j- 1;

                       entrou = true;                  
                       XOR = XOR ^ int.Parse(arr[j].ToString());
                       Console.WriteLine("M"+cont + " = " +  arr[j].ToString());         
                    }
                    cont++;
                    j++;
                }
                if (entrou) 
                {
                    Console.WriteLine("X" + i + "=" +XOR);
                    ValorFinalX.Add(XOR);
                    Console.WriteLine("--------");
                }
                entrou = false;
                cont = 1;
                XOR = 0;
                j = 0;
            }
            // return;
        }

        public static void ConferirValor(List<int> VALORX, double receptor) 
        {
        
        }
    }
}