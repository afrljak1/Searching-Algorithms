using System.Diagnostics;

namespace Sorter
{
    class MainProgram
    {
        const int BROJ_ELEMENATA = 1000000;
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 1000000;


        public static void Main(string[] args)
        {
            Random rdn = new Random();

            int[] niz = new int[BROJ_ELEMENATA];
            int[] trebapretraziti = new int[BROJ_ELEMENATA];

            for (int i = 0; i < niz.Length; i++)
                niz[i] = rdn.Next(MIN_VALUE, MAX_VALUE);



            List<int> lista = new List<int>(BROJ_ELEMENATA);
            List<int> pretragalista = new List<int>(BROJ_ELEMENATA);

            for (int i = 0; i < lista.Count; i++)
                lista[i] = rdn.Next(MIN_VALUE, MAX_VALUE);


            //kreiranje niza, te njegova inicijalizacija 
            int[] pretraga_niza = new int[] { 3, 1, 9, 8, 7, 12, 56, 23, 89 , 101, 678};
            int n, rezultat;

             Stopwatch sw = new();

             sw.Start();

             Console.WriteLine("Unesite broj koji zelite provjerti: ");
             n = Int32.Parse(Console.ReadLine());
             rezultat = Sorter.LinearSearch(pretraga_niza, n);
             if (n !=-0)
                 Console.WriteLine("Broj " + n + " je pronadjen na poziciji " +rezultat);
             else
                 Console.WriteLine("Broj nije pronadjen!");




             //LINEARSEARCH PRETRAGA
             Sorter.LinearSearch(pretraga_niza, n);

             sw.Stop();
             Console.WriteLine("\nVrijeme potrebno za pretrazivanje LinearSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
             sw.Restart();


            //BINARYSEARCH PRETRAGA
             Array.Sort(pretraga_niza);//sortiranje niza neophodno izvrsiti prilikom binarne pretrage
             Console.WriteLine("Sortiran niz: ");
             foreach (int x in pretraga_niza) Console.Write(x + " ");
             Console.WriteLine();
             Sorter.BinarySearch(pretraga_niza, n);

             sw.Stop();
             Console.WriteLine("Vrijeme potrebno za pretrazivanje BinarySearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
             sw.Restart();


            //JUMPSEARCH PRETRAGA
            Array.Sort(pretraga_niza);
            Sorter.JumpSearch(pretraga_niza, 678);

            sw.Stop();
            Console.WriteLine("Vrijeme potrebno za pretrazivanje JumpSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();

            //INTERPOLATIONSEARCH PRETRAGA
            Array.Sort(pretraga_niza);
            Sorter.InterpolationSearch(pretraga_niza, n);

            sw.Stop();
            Console.WriteLine("Vrijeme potrebno za pretrazivanje Interpolationsearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();

            //TERNARYSEARCH PRETRAGA
            Sorter.ternarySearch(2,11,12, pretraga_niza);

            sw.Stop();
            Console.WriteLine("Vrijeme potrebno za pretrazivanje Ternarysearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("\n");

            



            //testiranje proizvoljnih vrijednosti na razlicitim algoritmima
            Console.WriteLine("Testiranje proizvoljnih vrijednosti\n");
            sw.Start();
            Sorter.LinearSearch(trebapretraziti, MAX_VALUE);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje LinearSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();


            sw.Start();
            Sorter.LinearSearch(trebapretraziti, 1000);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje LinearSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();


            sw.Start();

            Array.Sort(trebapretraziti);//sortiranje niza neophodno izvrsiti prilikom binarne pretrage
           
            Sorter.BinarySearch(trebapretraziti, MIN_VALUE);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje BinarySearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();


            sw.Start();
            Array.Sort(trebapretraziti);//potrebno izvrsiti sortiranje niza
            Sorter.BinarySearch(trebapretraziti, MAX_VALUE);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje BinarySearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();



            sw.Start();
            Array.Sort(trebapretraziti);//potrebno izvrsiti sortiranje niza
            Sorter.JumpSearch(trebapretraziti, BROJ_ELEMENATA);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje JumpSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();
           

            sw.Start();
            Array.Sort(trebapretraziti);//potrebno izvrsiti sortiranje niza
            Sorter.JumpSearch(trebapretraziti, MIN_VALUE);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje JumpSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();


            sw.Start();
            Array.Sort(trebapretraziti);
            Sorter.InterpolationSearch(trebapretraziti, 100);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje InterpolationSearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();

          /*  sw.Start();
            Sorter.ternarySearch(320, 10000, 5600, trebapretraziti);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje TernarySearch algoritmom: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();
          */

            sw.Start();
            Sorter.BinarySearch(pretragalista, BROJ_ELEMENATA);
            sw.Stop();

            Console.WriteLine("Vrijeme potrebno za pretrazivanje BinarySearch algoritmom za listu: {0}ms", sw.ElapsedMilliseconds);
            sw.Restart();


        }
    }


    class Sorter
    {
        public static int LinearSearch(int[] niz, int broj)//linearna pretraga
        {
            for (int i = 0; i < niz.Length; i++)
            {
                if (broj == niz[i])
                    return (i + 1);//broj je pronadjen
            }
            return -1;//broj nije pronadjen i vraca se -1, te se ispisuje poruka
            Console.WriteLine("Broj nije pronadjen u nizu");
        }


        public static object BinarySearch(int[] niz, int n)//binarna pretraga
        {
            
            int low, high, mid;//prilikom ove pretrage potrebno je izvrsiti sortiranje niza
            low = 0;
            high = niz.Length - 1;
            mid = (low + high) / 2;
            while (low <= high)
            {
                if (niz[mid] == n)
                    return mid + 1;
                else
                    if (n < niz[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
                mid = (low + high) / 2;
            }
            return -1;//broj nije pronadjen i vraca se -1, te se ispisuje poruka
            Console.WriteLine("Broj nije pronadjen u nizu");

        }



        public static int JumpSearch(int[] niz, int broj)//jumpsearch pretraga
        {
            int n = niz.Length;


            int step = (int)Math.Sqrt(n);


            int prev = 0;
            while (niz[Math.Min(step, n) - 1] < broj)
            {
                prev = step;
                step += (int)Math.Sqrt(n);
                if (prev >= n)
                    return -1;
            }


            while (niz[prev] < broj)
            {
                prev++;


                if (prev == Math.Min(step, n))
                    return -1;
            }

            //ako je pronadjen element
            if (niz[prev] == broj)
                return prev;

            return -1;//broj nije pronadjen u nizu
            Console.WriteLine("Broj nije pronadjen u nizu");
        }


        public static int InterpolationSearch(int[] niz, int broj)//interpolationsearch pretraga
        {
            int n = niz.Length;
            int low = 0;
            int high = n - 1;

            while (low <= high && broj >= niz[low] && broj <= niz[high])
            {

                int index = low + ((broj - niz[low]) * (high - low)) / (niz[high] - niz[low]);

                if (niz[index] < broj)
                {
                    low = index + 1;
                }
                else if (niz[index] > broj)
                {
                    high = index - 1;
                }
                else
                {
                    // ako je pronadjen broj, vraca se indeks
                    return index;
                }
            }

            return -1;//broj nije pronadjin u nizu
            Console.WriteLine("Broj nije pronadjen u nizu");
        }

        public static int ternarySearch(int l, int r, int broj, int[] niz)//ternarysearch
        {
            if (r >= l)
            {

                // pronalazak m1 i m2
                int m1 = l + (r - l) / 3;
                int m2 = r - (r - l) / 3;

                // provjera da li se broj nalazi izmedu mid1 i m2
                if (niz[m1] == broj)
                {
                    return m1;
                }
                if (niz[m2] == broj)
                {
                    return m2;
                }



                if (broj < niz[m1])
                {

                    return ternarySearch(l, m1 - 1, broj, niz);
                }
                else if (broj > niz[m2])
                {


                    return ternarySearch(m2 + 1, r, broj, niz);
                }
                else
                {

                    return ternarySearch(m1 + 1, m2 - 1, broj, niz);
                }
            }

            //ako broj nije pronadjen potrebno je vratiti -1
            return -1;
            Console.WriteLine("Broj nije pronadjen u nizu");
        }

        public static List<int> FindAllIndex(List<int> lista, Predicate<int> broj)
        {
            var items = lista.FindAll(broj);
            List<int> indeks = new List<int>();
            foreach (var item in items)
            {
                indeks.Add(lista.IndexOf(item));
            }

            return indeks;
        }

        public static int BinarySearch(IEnumerable<int> lista, int broj)
        {
            int left = 0;
            int right = lista.Count() - 1;

            while (left <= right)
            {
                int median = (left + right) / 2;
                int item = lista.ElementAt(median);

                var comparison = broj.CompareTo(item);
                if (comparison == 0)
                {
                    return median;
                }

                if (comparison < 0)
                {
                    right = median - 1;
                }
                else
                {
                    left = median + 1;
                }
            }

            return -1;
        }
    }
    }

/*
class PretrazivanjeListe
{

    public static List<int> FindAllIndex( List<int> container, Predicate<int> match)
    {
        var items = container.FindAll(match);
        List<int> indexes = new List<int>();
        foreach (var item in items)
        {
            indexes.Add(container.IndexOf(item));
        }

        return indexes;
    }

    private static int BinarySearch(IEnumerable<int> lista, int broj) 
    {
        int left = 0;
        int right = lista.Count() - 1;

        while (left <= right)
        {
            int median = (left + right) / 2;
            int item = lista.ElementAt(median);

            var comparison = broj.CompareTo(item);
            if (comparison == 0)
            {
                return median;
            }

            if (comparison < 0)
            {
                right = median - 1;
            }
            else
            {
                left = median + 1;
            }
        }

        return -1;
    }

}
*/