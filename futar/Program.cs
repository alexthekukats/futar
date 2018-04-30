using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace futar
{
    class Program
    {
        static int[,] tomb = new int[62, 3];
        static void Main(string[] args)
        {

            read();
            elsofutas();
            Console.WriteLine();
            uccsofutas();
            Console.WriteLine();
            nemdolgoz();
            Console.WriteLine();
            maxfuvar();
            Console.WriteLine();
            futasok();
            Console.WriteLine();

            Console.WriteLine("Kérem adjon meg egy távolságot, hogy kiszámítsam a kifizetést! :");
            int ertek = Convert.ToInt32(Console.ReadLine());

            if (ertek >= 1 && ertek <= 2)
            {
                Console.WriteLine("500 Ft.");
            }
            if (ertek >= 3 && ertek <= 5)
            {
                Console.WriteLine("700 Ft.");
            }
            if (ertek >= 6 && ertek <= 10)
            {
                Console.WriteLine("900 Ft.");
            }
            if (ertek >= 11 && ertek <= 20)
            {
                Console.WriteLine("1400 Ft.");
            }
            if (ertek >= 21 && ertek <= 30)
            {
                Console.WriteLine("2000 Ft.");
            }


            Console.WriteLine();
            dijazas();
            Console.ReadKey();
        }

        static void read()
        {
            Console.WriteLine("Első feladat:");
            int sz = 0;
            int sz3 = 0;
            Console.WriteLine("Adatok beolvasása...");

            StreamReader re = new StreamReader("tavok.txt");

            string line = re.ReadLine();
            for (int j = 0; ; j++)
            {
                if (line == null || (line == ""))
                    break;

                for (int i = 0; i < 3; i++)
                {



                    string szam = "";

                    for (int q = 1; q < line.Length; q++)
                    {
                        try
                        {
                            if (line.Substring(sz3, 1) == " ")
                            {

                                break;
                            }
                            else
                            {
                                sz++;
                                szam += line.Substring(sz3, 1);
                            }
                            sz3++;
                        }

                        catch { break; }
                    }

                    tomb[j, i] = Convert.ToInt32(szam);
                    sz3++;
                }
                line = re.ReadLine();
                sz3 = 0;
                sz = 0;
            }
            Console.WriteLine("Adatok beolvasva.");
        }

        static void elsofutas()
        {
            Console.WriteLine("Második feladat:");

            int[,] elsotomb = new int[7, 1];

            for (int nap = 1; nap < 8; nap++)
            {
                for (int i = 0; i < 62; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (tomb[i, 0] == nap)
                        {
                            if (tomb[i, 1] == 1)
                            {
                                Console.WriteLine("{0} számú napon {1} km-t tett meg első futásra", nap, tomb[i, 2]);
                                break;
                            }
                        }
                    }
                }
            }
        }


        static void uccsofutas()
        {
            int max = 0;
            for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (tomb[i, 0] == 7)
                    {
                        if (max < tomb[i, 1])
                        {
                            max = tomb[i, 1];
                        }
                    }
                }
            }
            Console.WriteLine("A hét utolsó futása {0} km hosszú volt.", max);
        }

        static void nemdolgoz()
        {
            bool sz = false;
            for (int nap = 1; nap < 8; nap++)
            {
                sz = false;
                for (int i = 0; i < 62; i++)
                {
                    if (tomb[i, 0] == nap)
                    {
                        sz = true;
                        break;
                    }
                }
                if (sz == false)
                {
                    Console.WriteLine("{0} számú napon nem dolgozott.", nap);
                }
            }
        }

        static void maxfuvar()
        {
            int nap2 = 0;
            int nap3 = 0;
            int max = 0;
            int max2 = 0;
            for (int nap = 1; nap < 8; nap++)
            {
                for (int i = 0; i < 62; i++)
                {
                    if (tomb[i, 0] == nap)
                    {
                        nap2 = nap;
                        max += tomb[i, 1];
                    }
                }

                if (max > max2)
                {
                    max2 = max;
                    nap3 = nap2;
                }
                max = 0;
            }

            Console.WriteLine("{0}. napon volt a legtöbb fuvar.", nap3);
        }

        static void futasok()
        {
            int nap2 = 0;
            int max = 0;
            for (int nap = 1; nap < 8; nap++)
            {
                for (int i = 0; i < 62; i++)
                {
                    if (tomb[i, 0] == nap)
                    {
                        nap2 = nap;
                        max += tomb[i, 1];
                    }
                }
                if (nap == 2)
                {
                    Console.WriteLine("2. nap: 0 km");
                }
                else if (nap == 6)
                { 
                    Console.WriteLine("6. nap: 0 km");
                }

                else
                {
                    Console.WriteLine("{0}. nap: {1} km", nap, max);
                }
                max = 0;
            }
        }

        static void dijazas()
        {
            int dij = 0;
            StreamWriter wr = new StreamWriter("dijazas.txt");
            int ertek = 0;
            for (int nap = 1; nap < 8; nap++)
            {
                for (int i = 0; i < 62; i++)
                {
                    if (tomb[i, 0] == nap)
                    {
                        ertek = tomb[i, 1];

                        if (ertek >= 1 && ertek <= 2)
                        {
                            Console.WriteLine("{0}. nap {1}. út: 500 Ft.",nap,i);
                            dij += 500;
                        }
                        if (ertek >= 3 && ertek <= 5)
                        {
                            Console.WriteLine("{0}. nap {1}. út: 700 Ft.", nap, i);
                            dij += 700;
                        }
                        if (ertek >= 6 && ertek <= 10)
                        {
                            Console.WriteLine("{0}. nap {1}. út: 900 Ft.", nap, i);
                            dij += 900;
                        }
                        if (ertek >= 11 && ertek <= 20)
                        {
                            Console.WriteLine("{0}. nap {1}. út: 1400 Ft.", nap, i);
                            dij += 1400;
                        }
                        if (ertek >= 21 && ertek <= 30)
                        {
                            Console.WriteLine("{0}. nap {1}. út: 2000 Ft.", nap, i);
                            dij += 2000;
                        }
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("{0} a díja a futárnak!", dij);
            }
        }
    }
}
