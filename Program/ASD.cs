using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    delegate double fun(double x);

    internal class ASD
    {
        public static int Fibo(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;
            return Fibo(n - 1) + Fibo(n - 2);
        }
        public static int FiboR(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;
            int a, b, c = 0;
            a = 1; b = 1;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                b = a;
                a = c;
            }
            return c;

        }
        public static int FiboArray(int n)
        {
            if (n == 0) return 0;
            if (n < 1) return 1;
            int[] f = new int[n+2];
            f[0] = 0;  f[1] = 1; f[2] = 1;
            for(int i = 3; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }
        public static string IntConvert(int n, int d)
        {
            string result = " ";
            string Letters = "0123456789ABCDEF";
            while (n > 0 && d > 1 && d <= 16)
            {
                int oct = n % d;
                result = Letters[oct] + result;
                n = n / d;
            }
            return result;
        }
        public static int ConvertStringToInt(string str)
        {
            int n = Convert.ToInt32(str);
            return n;
        }
        public static int NOD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a + b;
        }
        public static bool BoolTestSimple(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static double PolDel(double a,double b,double eps, fun f)
        {
            double fa, fb, fc, c;
            fa = f(a); fb = f(b);
            if (fa * fb > 0) return double.NaN;
            while (b - a > eps)
            {
                c = (a + b) / 2.0;
                fc = f(c);
                if (fa * fc < 0) { b = c; fb = fc; }
                else { a = c; fa = fc; }
            }
            return (a + b) / 2.0;
        }
        public static double GoldMin(double a, double b, double eps, fun f)
        {
            double v, w;
            v = a + (b - a) * 0.382; w = a + (b - a) * 0.618;
            double fv = f(v), fw = f(w);
            while (b - a > eps)
            {
                if (fv < fw)
                {
                    b = w; w = v; fw = fv; v = a + (b - a) * 0.382; fv = f(v);
                }
                else
                {
                    a = v; v = w; fv = fw; w = a + (b - a) * 0.618; fw = f(w);
                }
            }
            return (a + b) / 2.0;
        }
    }
}