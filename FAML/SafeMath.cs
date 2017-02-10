/* FAML by Roy Hwang * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
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
 * As a final note: USE THESE FUNCTIONS ONLY IF YOU KNOW that the input values will 
 * fall within the "Recommended Domain" values, otherwise the result will be completely 
 * unusable due to the nature of trying to approximate functions that contain vertical 
 * asymptotes with polynomial functions.
 * 
 * Thanks for using my library! I always welcome criticism, improvements, and suggestions!
 * 
 * - Roy Hwang
 * 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System;
using System.Runtime.CompilerServices;


namespace FAML
{
    public static class SafeMath
    {

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
        /// APPROXIMATION: Returns a float approximation of x^y where x is the base and y is the exponent.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PowDouble(double x, double y)
        {
            return BitConverter.Int64BitsToDouble(((long)((int)(y * (((int)(BitConverter.DoubleToInt64Bits(x) >> 32)) - 1072632447) + 1072632447))) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns a double precision approximation of x^y where x is the base and y is the exponent.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PowFloat(double x, double y)
        {
            return (float)BitConverter.Int64BitsToDouble(((long)((int)(y * (((int)(BitConverter.DoubleToInt64Bits(x) >> 32)) - 1072632447) + 1072632447))) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns a double type approximation of e^x. 
        /// <para>RECOMMENDED DOMAIN: [0 to double.MaxValue]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ExpDouble(double x)
        {
            return BitConverter.Int64BitsToDouble(((long)(1512775 * x + 1072632447)) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns a float approximation of e^x. 
        /// <para>RECOMMENDED DOMAIN: [0 to float.MaxValue]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpFloat(double x)
        {
            return (float)BitConverter.Int64BitsToDouble(((long)(1512775 * x + 1072632447)) << 32);
        }

        /// <summary>
        /// APPROXIMATION: Returns a double type approximation of ln(x). 
        /// <para>RECOMMENDED DOMAIN: [0 to double.MaxValue]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LnDouble(double x)
        {
            return ((BitConverter.DoubleToInt64Bits(x) >> 32) - 1072632447) / 1512775;
        }

        /// <summary>
        /// APPROXIMATION: Returns a float approximation of ln(x). 
        /// <para>RECOMMENDED DOMAIN: [0 to float.MaxValue]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LnFloat(double x)
        {
            return (float)((BitConverter.DoubleToInt64Bits(x) >> 32) - 1072632447) / 1512775;
        }

        /// <summary>
        /// PRECISE: Get the log base 2 of an integer.
        /// <para>RECOMMENDED DOMAIN: [0 to int.MaxValue]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2Int(int x)
        {
            int r = 0;

            if ((x & 0xFFFF0000) != 0)
            {
                x >>= 16;
                r |= 16;
            }
            if ((x & 0xFF00) != 0)
            {
                x >>= 8;
                r |= 8;
            }
            if ((x & 0xF0) != 0)
            {
                x >>= 4;
                r |= 4;
            }
            if ((x & 0xC) != 0)
            {
                x >>= 2;
                r |= 2;
            }
            if ((x & 0x2) != 0)
            {
                x >>= 1;
                r |= 1;
            }
            return r;
        }

        /// <summary>
        /// <para>PRECISE: Returns the absolute value of an integer x without using branching.</para>
        /// <para>If branching is faster on your target hardware, it is recommended to use 
        /// System.Math.Abs() or a manually inlined conditional statement.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
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
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CompareInts(int x, int y)
        {
            return (((x - y) >> 0x1F) | (int)((uint)(-(x - y)) >> 0x1F));
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns whether a number is a power of two.</para>
        /// <para>RECOMMENDED DOMAIN: [0 to uint.MaxValue]</para>
        /// <para>ERROR: This method will erroneously return 0 when x = 0. You can 
        /// write your own checks for these into the method, but for the sake of performance zero 
        /// error checks have been implemented. This method is PRECISE otherwise.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOf2(uint x)
        {
            return (x & (x - 1)) == 0;
        }

        /// <summary>
        /// <para>APPROXIMATE: Returns the next power of 2, or returns the argument x if x is a power of 2. 
        /// For example - if x = 22, the return result will be 32.</para>
        /// <para>RECOMMENDED DOMAIN: [0 to 1,073,741,824]</para>
        /// <para>ERROR: This method will erroneously return 0 when x = 0, and 1 when x = 1. You can 
        /// write your own checks for these into the method, but for the sake of performance zero 
        /// error checks have been implemented. This method is PRECISE otherwise.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NextPowerOf2Int(int x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;
            return x;
        }

        /// <summary>
        /// <para>APPROXIMATE: Returns the next power of 2, or returns the argument x if x is a power of 2. 
        /// For example - if x = 22, the return result will be 32.</para>
        /// <para>RECOMMENDED DOMAIN: [0 to 4,611,686,018,427,387,904]</para>
        /// <para>ERROR: This method will erroneously return 0 when x = 0, and 1 when x = 1. You can 
        /// write your own checks for these into the method, but for the sake of performance zero 
        /// error checks have been implemented. This method is PRECISE otherwise.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long NextPowerOf2Long(long x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;
            return x;
        }

        /// <summary>
        /// <para>APPROXIMATE: Returns the next power of 2, or returns the argument x if x is a power of 2. 
        /// For example - if x = 22, the return result will be 32.</para>
        /// <para>RECOMMENDED DOMAIN: [0 to 2,147,483,648]</para>
        /// <para>ERROR: This method will erroneously return 0 when x = 0, and 1 when x = 1. You can 
        /// write your own checks for these into the method, but for the sake of performance zero 
        /// error checks have been implemented. This method is PRECISE otherwise.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint NextPowerOf2Uint(uint x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;
            return x;
        }

        /// <summary>
        /// <para>APPROXIMATE: Returns the next power of 2, or returns the argument x if x is a power of 2. 
        /// For example - if x = 22, the return result will be 32.</para>
        /// <para>RECOMMENDED DOMAIN: [0 to 9,223,372,036,854,775,808]</para>
        /// <para>ERROR: This method will erroneously return 0 when x = 0, and 1 when x = 1. You can 
        /// write your own checks, but for the sake of performance no 
        /// error checks are implemented by default. This method is PRECISE otherwise.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextPowerOf2Ulong(ulong x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;
            return x;
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the sine of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-PI to PI]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SinFloat(float x)
        {
            if (x < 0)
            {
                return x * (1.27323954f + 0.405284735f * x);
            }
            else
            {
                return x * (1.27323954f - 0.405284735f * x);
            }
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the sine of the double x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-PI to PI]</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinDouble(double x)
        {
            if (x < 0)
            {
                return x * (1.27323954 + 0.405284735 * x);
            }
            else
            {
                return x * (1.27323954 - 0.405284735 * x);
            }
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the cosine of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-4.71238898 to 1.57079632], or (-3PI/2 to PI/2)</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CosFloat(float x)
        {
            // Cos(x) = Sin(x + PI / 2)
            x += 1.57079632f;

            if (x < 0)
            {
                return x * (1.27323954f + 0.405284735f * x);
            }
            else
            {
                return x * (1.27323954f - 0.405284735f * x);
            }
        }


        /// <summary>
        /// <para>APPROXIMATION: Returns the cosine of the double x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-4.71238898 to 1.57079632], or (-3PI/2 to PI/2)</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosDouble(double x)
        {
            // Cos(x) = Sin(x + PI / 2)
            x += 1.57079632679489661923;

            if (x < 0)
            {
                return x * (1.27323954 + 0.405284735 * x);
            }
            else
            {
                return x * (1.27323954 - 0.405284735 * x);
            }
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the sine of the float x which is to be provided in radians. 
        /// This method doesn't have a heavily restricted input range, but is slower than the limited range versions.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: Average error of 2-5%, increases as x approaches -PI or PI</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SinFloatNormalized(float x)
        {
            // Normalize
            while (x < -3.14159265f) x += 6.28318531f;
            while (x > 3.14159265f) x -= 6.28318531f;

            if (x < 0)
            {
                return x * (1.27323954f + 0.405284735f * x);
            }
            else
            {
                return x * (1.27323954f - 0.405284735f * x);
            }
        }
        
        /// <summary>
        /// <para>APPROXIMATION: Returns the sine of the double x which is to be provided in radians. 
        /// This method doesn't have a heavily restricted input range, but is slower than the limited range versions.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: Average error of 2-5%, increases as x approaches -PI or PI</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinDoubleNormalized(double x)
        {
            // Normalize
            
            while (x < -3.1415926535897932) x += 6.2831853071795865;
            while (x > 3.1415926535897932) x -= 6.2831853071795865;

            if (x < 0)
            {
                return x * (1.27323954 + 0.405284735 * x);
            }
            else
            {
                return x * (1.27323954 - 0.405284735 * x);
            }
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the cosine of the float x which is to be provided in radians. 
        /// This method doesn't have a heavily restricted input range, but is slower than the limited range versions.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: Average error of 2-5%, increases as x approaches -PI or PI</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CosFloatNormalized(float x)
        {
            // Cos(x) = Sin(x + PI / 2)
            x += 1.57079632f;

            // Normalize
            while (x < -4.71238898f) x += 6.28318531f;
            while (x > 1.57079632f) x -= 6.28318531f;

            if (x < 0)
            {
                return x * (1.27323954f + 0.405284735f * x);
            }
            else
            {
                return x * (1.27323954f - 0.405284735f * x);
            }
        }


        /// <summary>
        /// <para>APPROXIMATION: Returns the cosine of the double x which is to be provided in radians. 
        /// This method doesn't have a heavily restricted input range, but is slower than the limited range versions.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: Average error of 2-5%, increases as x approaches -PI or PI</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosDoubleNormalized(double x)
        {
            // Cos(x) = Sin(x + PI / 2)
            x += 1.57079632679489661923;

            // Normalize
            while (x < -4.7123889803846898) x += 6.2831853071795865;
            while (x > 1.57079632679489661923) x -= 6.2831853071795865;

            if (x < 0)
            {
                return x * (1.27323954 + 0.405284735 * x);
            }
            else
            {
                return x * (1.27323954 - 0.405284735 * x);
            }
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the tangent of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-1 to 1]</para>
        /// <para>ERROR: The average error is 3% - 5% within the recommended domain.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TanFloat(float x)
        {
            float y = x * x;
            return (1f + (0.33333333f * y) + (0.13333333f * y * y) + (0.05396825f * y * y * y)) * x;
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the tangent of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-1 to 1]</para>
        /// <para>ERROR: The average error is 3% - 5% within the recommended domain.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TanDouble(double x)
        {
            double y = x * x;
            return (1f + (0.3333333333333333 * y) + (0.1333333333333333 * y * y) + (0.053968253968254 * y * y * y)) * x;
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns a high precision approximation of the tangent of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-PI / 2 to PI / 2]</para>
        /// <para>ERROR: The average error is less than 1%.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TanFloatHP(float x)
        {
            return (x - (0.09580102f * x * x * x)) / (1 - 0.42913502f * x * x + 0.00971659f * x * x * x * x);
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns a high precision approximation of the tangent of the float x which is to be provided in radians. 
        /// This method has a very limited valid input range.</para>
        /// <para>RECOMMENDED DOMAIN: [-PI / 2 to PI / 2]</para>
        /// <para>ERROR: The average error is less than 1%.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TanDoubleHP(double x)
        {
            return (x - (0.09580102f * x * x * x)) / (1 - 0.42913502f * x * x + 0.00971659f * x * x * x * x);
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns a high precision approximation of the tangent of the float x which is to be provided in radians. 
        /// This method normalizes the input for you, so it is slower than the non-normalized method.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: The average error is less than 1%.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TanFloatNormalizedHP(float x)
        {
            // Normalize
            while (x < -1.57079633f) x += 3.14159265f;
            while (x > 1.57079633f) x -= 3.14159265f;

            return (x - (0.09580102f * x * x * x)) / (1 - 0.42913502f * x * x + 0.00971659f * x * x * x * x);
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns a high precision approximation of the tangent of the float x which is to be provided in radians. 
        /// This method normalizes the input for you, so it is slower than the non-normalized method.</para>
        /// <para>RECOMMENDED DOMAIN: All</para>
        /// <para>ERROR: The average error is less than 1%.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TanDoubleNormalizedHP(double x)
        {
            // Normalize
            while (x < -1.57079633f) x += 3.14159265f;
            while (x > 1.57079633f) x -= 3.14159265f;

            return (x - (0.09580102f * x * x * x)) / (1 - 0.42913502f * x * x + 0.00971659f * x * x * x * x);
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the tangent of the float x which is to be provided in radians. 
        /// Use this if after normalization, your input value falls between -1 and 1.</para>
        /// <para>RECOMMENDED DOMAIN: [-1 to 1] after normalization.</para>
        /// <para>ERROR: The average error is 3% - 5% within the recommended domain.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TanFloatNormalized(float x)
        {
            // Normalize
            while (x < -1.57079633f) x += 3.14159265f;
            while (x > 1.57079633f) x -= 3.14159265f;

            float y = x * x;
            return (1f + (0.33333333f * y) + (0.13333333f * y * y) + (0.05396825f * y * y * y)) * x;
        }

        /// <summary>
        /// <para>APPROXIMATION: Returns the tangent of the float x which is to be provided in radians. 
        /// Use this if after normalization, your input value falls between -1 and 1.</para>
        /// <para>RECOMMENDED DOMAIN: [-1 to 1] after normalization.</para>
        /// <para>ERROR: The average error is 3% - 5% within the recommended domain.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TanDoubleNormalized(double x)
        {
            // Normalize
            while (x < -1.5707963267948966) x += 3.1415926535897932;
            while (x > 1.5707963267948966) x -= 3.1415926535897932;

            double y = x * x;
            return (1f + (0.3333333333333333 * y) + (0.1333333333333333 * y * y) + (0.053968253968254 * y * y * y)) * x;
        }

    }
}
