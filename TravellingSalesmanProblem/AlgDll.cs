using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TravellingSalesmanProblem {
    class AlgDll {
        const string dll = "Alg.dll";
        [DllImport(dll)] public static extern int Add(int a, int b);
        [DllImport(dll)] public static extern void Improve2Opt([In, Out] int[] visitOrder, int num, [In] long[] distTable);
    }
}
