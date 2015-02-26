using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yabl_Tach
{
    struct Point
    {
        int X;
        int Y;
        char A;
        ConsoleColor CurColor;
        ConsoleColor BackColor;

        public Point(int x, int y, char a, ConsoleColor cC, ConsoleColor bC)
        {
            this.X = x;
            this.Y = y;
            this.A = a;
            this.CurColor = cC;
            this.BackColor = bC;
        }

        public void SetPoint(int x, int y, char a, ConsoleColor cC, ConsoleColor bC)
        {
            this.X = x;
            this.Y = y;
            this.A = a;
            this.CurColor = cC;
            this.BackColor = bC;
        }

        public void SetXY(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void SetX(int x)
        {
            this.X = x;
        }

        public void SetY(int y)
        {
            this.Y = y;
        }

        public void SetCC( ConsoleColor cC)
        {
            this.CurColor = cC;
        }

        public void SetBC( ConsoleColor bC)
        {
            this.BackColor = bC;
        }

        public void SetA( char a)
        {
            this.A = a;
        }

        public char GetA()
        {
            return A;
        }

        public int GetY()
        {
            return Y;
        }

        public int GetX()
        {
            return X;
        }

        public ConsoleColor GetCC()
        {
            return CurColor;
        }

        public ConsoleColor GetBC()
        {
            return BackColor;
        }
    }

    class Сursor
    {
        public Point[] My = new Point[9];

        public Сursor()
        {
            My[0] = My[2] = My[4] = My[6] = My[8] = new Point(0, 0, '+', ConsoleColor.DarkBlue, ConsoleColor.Cyan);
            My[1] = My[7] = new Point(0, 0, '|', ConsoleColor.White, ConsoleColor.Black);
            My[3] = My[5] = new Point(0, 0, '-', ConsoleColor.White, ConsoleColor.Black);
        }

        public void SetCursor(int ind, int x, int y, char a, ConsoleColor cC, ConsoleColor bC)
        {
            My[ind].SetPoint( x, y, a, cC, bC);
        }

        public bool Perhaps(int x, int y)
        {
            if (x >= 0 && y >= 0 && x + 3 <= Console.WindowWidth && y + 3 <= Console.WindowHeight)
            {
                return true;
            }
            else return false;
        }

        public void BildCurs(int x, int y)
        {
            My[0].SetXY(x, y);
            My[1].SetXY(x, y + 1);
            My[2].SetXY(x, y + 2);
            My[3].SetXY(x + 1, y);
            My[4].SetXY(x + 1, y + 1);
            My[5].SetXY(x + 1, y + 2);
            My[6].SetXY(x + 2, y);
            My[7].SetXY(x + 2, y + 1);
            My[8].SetXY(x + 2, y + 2);
        }

        public void Print(Point a)
        {
            Console.BackgroundColor = a.GetBC();
            Console.ForegroundColor = a.GetCC();
            Console.SetCursorPosition(a.GetX(), a.GetY());
            Console.WriteLine(a.GetA()); 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintAll()
        {
            for(int i=0; i<My.Length; i++)
            {
                Print(My[i]);
            }
        }

    }

    struct Poin
    {
        public int X;
        public int Y;

        public int PoinX()
        {
            return X;
        }
        public int PoinY()
        {
            return Y;
        }
    }

    struct Rectangl
    {
        public Poin A;
        public Poin B;
        public Poin C;
        public Poin D;

        public Rectangl(int x, int y, int l)
        {
            A.X = x;
            A.Y = y;
            B.X = x + l;
            B.Y = y;
            C.X = x;
            C.Y = y + l;
            D.X = x + l;
            D.Y = y + l;
        }

        public int CoordX(Poin a)
        {
            return a.PoinX();
        }
        
        public void Border()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = A.X + 1; i < A.X + (B.X - A.X); i++)
            {
                Console.SetCursorPosition(i, A.Y);
                Console.WriteLine('-');
                Console.SetCursorPosition(i, A.Y + (B.X - A.X));
                Console.WriteLine('-');
            }
            for (int i = A.Y + 1; i < A.Y + (B.X - A.X); i++)
            {
                Console.SetCursorPosition(A.X, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(A.X + (B.X - A.X), i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(A.X,A.Y);
            Console.WriteLine('+');
            Console.SetCursorPosition(B.X, B.Y);
            Console.WriteLine('+');
            Console.SetCursorPosition(C.X, C.Y);
            Console.WriteLine('+');
            Console.SetCursorPosition(D.X, D.Y);
            Console.WriteLine('+');
        }

    }
}
