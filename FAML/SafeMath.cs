/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * 
 * Fast Approximate Math Library (FAML)
 * 
 * By: Roy Hwang
 * 
 * =====================================
 * Credits: 
 * =====================================
 * 
 * Several of these algorithms are C to C# ports from the 
 * lovely website https://graphics.stanford.edu/~seander/bithacks.html and 
 * others are from web resources such as the always dependable Stack Overflow 
 * comments sections!
 * 
 * =====================================
 * About: 
 * =====================================
 * 
 * The provided methods offer an alternate way of getting both precise results and 
 * approximations of standard math functions which are used regularly throughout any 
 * sort of programming. The goal of this library was to provide faster math functions for 
 * performance intensive programs or hot sections of code. 
 * 
 * HOWEVER - NEITHER THE PRECISE METHODS, NOR THE APPROXIMATIONS ARE GUARANTEED TO 
 * BE A FASTER SOLUTION FOR YOUR TARGET HARDWARE!!! Always benchmark for your 
 * hardware platform, before completely integrating any solution from any library!
 * 
 * Please be aware that some methods may only exist as a "safe" version, and 
 * some methods in this library may only exist as an "unsafe" version. Sometimes, 
 * a method will exist with both a "safe" and "unsafe" version, which can have 
 * slightly different implementations. If a common math function does not 
 * exist in FAML, it is because the .NET implementation from System.Math is 
 * generally superior, or I forgot. This is a continuous work!
 * 
 * The method summaries will tell you if a method will return a precise 
 * result, or an approximation. Approximations will (generally) be 
 * faster, at the expense of some degree of error.
 * 
 * I've personally experienced a boost from select algorithms provided in this 
 * library for certain programs, and it is my hope that you can find something 
 * useful to you here as well.  Once again, BENCHMARK FOR YOUR TARGET HARDWARE 
 * FIRST! I take no responsibility for anything you do with the code provided 
 * here.
 * 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System;
using System.Runtime.CompilerServices;

namespace FAML
{
    public class SafeMath
    {
        // Log LUT
        private static readonly uint[] B = { 0x2, 0xC, 0xF0, 0xFF00, 0xFFFF0000 };
        private static readonly int[] S = { 1, 2, 4, 8, 16 };

        /// <summary>
        /// PRECISE: Returns true if an integer x and an integer y have opposite signs, 
        /// and false if the signs are the same.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool OppositeSigns(int x, int y)
        {
            return ((x ^ y) < 0);
        }

        /// <summary>
        /// PRECISE: Returns the square of the float x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SquareFloat(float x)
        {
            return x * x;
        }

        /// <summary>
        /// PRECISE: Returns the square of the double x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SquareDouble(double x)
        {
            return x * x;
        }

        /// <summary>
        /// PRECISE: Returns the square of the integer x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SquareInt(int x)
        {
            return x * x;
        }

        /// <summary>
        /// Returns the square of the unsigned integer x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SquareUint(uint x)
        {
            return x * x;
        }

        /// <summary>
        /// PRECISE: Returns the square of the 64 bit integer x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SquareLong(long x)
        {
            return x * x;
        }

        /// <summary>
        /// Returns the square of the unsigned 64 bit integer x.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SquareUlong(ulong x)
        {
            return x * x;
        }

        /// <summary>
        /// PRECISE: Returns the result of the float x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubeFloat(float x)
        {
            return x * x * x;
        }

        /// <summary>
        /// PRECISE: Returns the result of the double x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubeDouble(double x)
        {
            return x * x * x;
        }

        /// <summary>
        /// PRECISE: Returns the result of the integer x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CubeInt(int x)
        {
            return x * x * x;
        }

        /// <summary>
        /// PRECISE: Returns the result of the unsigned integer x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CubeUint(uint x)
        {
            return x * x * x;
        }

        /// <summary>
        /// PRECISE: Returns the result of the 64 bit integer x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CubeLong(long x)
        {
            return x * x * x;
        }

        /// <summary>
        /// Returns the result of the unsigned 64 bit integer x^3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CubeUlong(ulong x)
        {
            return x * x * x;
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of x^y where x is the base and y is the exponent.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PowDouble(double x, double y)
        {
            return BitConverter.Int64BitsToDouble(((long)((int)(y * (((int)(BitConverter.DoubleToInt64Bits(x) >> 32)) - 1072632447) + 1072632447))) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of x^y where x is the base and y is the exponent.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PowFloat(double x, double y)
        {
            return (float)BitConverter.Int64BitsToDouble(((long)((int)(y * (((int)(BitConverter.DoubleToInt64Bits(x) >> 32)) - 1072632447) + 1072632447))) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of e^x. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double expDouble(double x)
        {
            return BitConverter.Int64BitsToDouble(((long)(1512775 * x + 1072632447)) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of e^x. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float expFloat(double x)
        {
            return (float)BitConverter.Int64BitsToDouble(((long)(1512775 * x + 1072632447)) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of ln(x). 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double lnDouble(double x)
        {
            return ((BitConverter.DoubleToInt64Bits(x) >> 32) - 1072632447) / 1512775;
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of ln(x). 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float lnFloat(double x)
        {
            return (float)((BitConverter.DoubleToInt64Bits(x) >> 32) - 1072632447) / 1512775;
        }


        /// <summary>
        /// PRECISE: Get the log base 2 of an integer using a lookup table.
        /// </summary>
        public static int FastLog2Int(int x)
        {
            int r = 0;

            if ((x & B[4]) != 0)
            {
                x >>= S[4];
                r |= S[4];
            }
            if ((x & B[3]) != 0)
            {
                x >>= S[3];
                r |= S[3];
            }
            if ((x & B[2]) != 0)
            {
                x >>= S[2];
                r |= S[2];
            }
            if ((x & B[1]) != 0)
            {
                x >>= S[1];
                r |= S[1];
            }
            if ((x & B[0]) != 0)
            {
                x >>= S[0];
                r |= S[0];
            }
            return r;
        }

        /// <summary>
        /// PRECISE: Returns the absolute value of an integer x without using branching. If branching is faster 
        /// on your target hardware, it is recommended to use System.Math.Abs() or a manually inlined 
        /// conditional statement.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int AbsInt(int x)
        {
            int mask = x >> 31;
            return (x + mask) ^ mask;
        }

        /// <summary>
        /// PRECISE: Returns -1 if x is less than y, 
        /// returns 0 if x is equal to y, and
        /// returns 1 if x is greater than y.
        /// </summary>
        public int CompareInts(int x, int y)
        {
            return (((x - y) >> 0x1F) | (int)((uint)(-(x - y)) >> 0x1F));
        }

    }
}
