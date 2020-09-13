using System;
using System.Collections.Generic;
using System.Text;

namespace App.Entidades
{
    class M
    {
        public List<double> ValorM { get; set; }
        public double ResultSD { get; set; }

        public M()
        {
           
        }

        /* arr[] ---> Input Array 
    data[] ---> Temporary array to 
                store current combination 
    start & end ---> Staring and Ending  
                     indexes in arr[] 
    index ---> Current index in data[] 
    r ---> Size of a combination 
            to be printed */
        public void combinationUtil(List<double> arr, int[] data, int start, int end,int index, int r, ref string palavra)
        {
            // Current combination is  
            // ready to be printed,  
            // print it 
            if (index == r)
            {
                for (int j = 0; j < r; j++) 
                {
                    palavra += data[j];
                }
                palavra += ",";
                return;
            }

            // replace index with all 
            // possible elements. The  
            // condition "end-i+1 >=  
            // r-index" makes sure that  
            // including one element 
            // at index will make a  
            // combination with remaining  
            // elements at remaining positions 
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = (int)arr[i];
                combinationUtil(arr, data, i + 1,
                                end, index + 1, r, ref palavra);
            }
        }

        // The main function that prints 
        // all combinations of size r 
        // in arr[] of size n. This  
        // function mainly uses combinationUtil() 
        public string printCombination(List<double> arr,int n, int r)
        {
            // A temporary array to store  
            // all combination one by one 
            string palavra = "";
            int[] data = new int[r];

            // Print all combination  
            // using temprary array 'data[]' 
            combinationUtil(arr, data, 0,n - 1, 0, r, ref palavra);
            return palavra;
        }


    }
}
