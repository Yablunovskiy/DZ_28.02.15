using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yabl_Tach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Сursor A = new Сursor();
            Move(A);
        }

        static public void Move(Сursor A)
        {
            int Mx, Ml, My;
            ConsoleKeyInfo key;
            int Width = 80;
            int Height = 40;
            int x = 1;
            int y = 1;
            Random rand = new Random();
            Ml = rand.Next(18, 25);
            do
            {
                Mx = rand.Next(0, Width-1);
                My = rand.Next(0, Height-1);
            } while ((Ml + Mx) > Width || (Ml + My) > Height);
            Rectangl q = new Rectangl(Mx, My, Ml);
            Ml -= 5;
            do
            {
                Mx = rand.Next(0, Width-1);
                My = rand.Next(0, Height-1);
            } while (!Intersectoin(q, Mx, My, Ml) || (Ml + Mx) > Width || (Ml + My) > Height);

            Rectangl q2 = new Rectangl(Mx, My, Ml);
            q.Border();
            q2.Border();

            while (true)
            {
                Console.Clear();
                A.BildCurs(x, y);
                A.PrintAll();
                q.Border();
                q2.Border();
                Beep(ref A, q);
                Beep(ref A, q2);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        if (!A.Perhaps(x, y)) y++;
                        break;
                    case ConsoleKey.DownArrow:
                        ++y;
                        if (!A.Perhaps(x, y)) y--;
                        break;
                    case ConsoleKey.LeftArrow:
                        --x;
                        if (!A.Perhaps(x, y)) x++;
                        break;
                    case ConsoleKey.RightArrow:
                        ++x;
                        if (!A.Perhaps(x, y)) x--;
                        break;
                }
            }
        }


        static public void Beep(ref Сursor A, Rectangl Z)
        {
            bool beep = false;
            for (int i=0; i<A.My.Length; i++)
            {
                if (A.My[i].GetX() == Z.A.X && (Z.A.Y <= A.My[i].GetY() && A.My[i].GetY() <= Z.C.Y)) beep = true;
                if (A.My[i].GetX() == Z.B.X && (Z.B.Y <= A.My[i].GetY() && A.My[i].GetY() <= Z.D.Y)) beep = true;
                if (A.My[i].GetY() == Z.A.Y && (Z.A.X <= A.My[i].GetX() && A.My[i].GetX() <= Z.B.X)) beep = true;
                if (A.My[i].GetY() == Z.C.Y && (Z.C.X <= A.My[i].GetX() && A.My[i].GetX() <= Z.D.X)) beep = true;
                //if ((Z.A.X <= A.My[i].GetX() && A.My[i].GetX() <= Z.B.X) && (Z.A.Y <= A.My[i].GetY() && A.My[i].GetY() <= Z.C.Y))
                //{
                //    //A.My[i].SetBC(ConsoleColor.Yellow);
                //    //A.My[i].SetCC(ConsoleColor.Black);
                //    beep = true;
                //    //Console.Beep();
                //}
                //else
                //{
                //    A.My[i].SetBC(ConsoleColor.Black);
                //    A.My[i].SetCC(ConsoleColor.White);
                //}
            }
            if (beep) Console.Beep();
        }

        static public bool Intersectoin(Rectangl Z, int x, int y, int l)
        {
            if ((Z.A.X <= x && x <= Z.B.X) && (Z.A.Y <= y && y <= Z.C.Y))
            {
                return false;
            }
            if ((Z.A.X <= x+l && x+l <= Z.B.X) && (Z.A.Y <= y && y <= Z.C.Y))
            {
                return false;
            }
            if ((Z.A.X <= x + l && x + l <= Z.B.X) && (Z.A.Y <= y+l && y+l <= Z.C.Y))
            {
                return false;
            }
            if ((Z.A.X <= x && x <= Z.B.X) && (Z.A.Y <= y+l && y+l <= Z.C.Y))
            {
                return false;
            }
            else return true;
        }
    }
}
