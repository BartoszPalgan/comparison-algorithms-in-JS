using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_San
{
    class Sorting_algorithms
    {
        public static int selectionSort(int[] tab)
        {
            int temp, min; //m -index elementu minimalnego
            int counter = 0; // zminna opisująca liczbę operacji dominujących 
            for (int i = 0; i < tab.Length; i++)
            {
                min = i;

                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[min]) min = j;
                    counter++;
                }

                temp = tab[i];
                tab[i] = tab[min];
                tab[min] = temp;
            }

            return counter;
        }

        public static int insertionSort(int[] tab)
        {
            int j, v; //v -value
            int counter = 0; //zmienna opisująca liczbę operacji dominującyh 
            for (int i = 1; i < tab.Length; i++)
            {
                j = i; v = tab[i];
                while (tab[j - 1] > v)
                {
                    tab[j] = tab[j - 1];
                    j = j - 1;
                    counter++;
                    if (j == 0) break;
                }
                tab[j] = v;
            }
            return counter;
        }

        public static int quickSort(int[] tab, int d, int h)
        {
            int pivot = tab[(d + h) / 2];
            int counter = 0; //zmienna opisująca liczbę operacji dominujacych
            int i = d; //d - dół 
            int j = h; // h - góra
            int temp;

            do
            {
                while (tab[i] < pivot) { i++; counter++; }
                while (tab[j] > pivot) { j--; counter++; }
                if (i <= j)
                {
                    temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                    j--; i++;
                }
            } while (i <= j);
            if (d < j) counter += quickSort(tab, d, j);
            if (h > i) counter += quickSort(tab, i, h);

            return counter;

        }

        public static int bubblesort(int[] tab)
        {
            int temp;
            int counter = 0;

            for (int j = 0; j <= tab.Length - 2; j++)
            {
                for (int i = 0; i <= tab.Length - 2; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        counter++;
                        temp = tab[i + 1];
                        tab[i + 1] = tab[i];
                        tab[i] = temp;
                    }
                }
            }

            return counter;
        }
    }
}
