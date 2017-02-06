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


using System.Runtime.CompilerServices;

namespace FAML
{
    public class UnsafeMath
    {
        
        /// <summary>
        /// PRECISE: Returns the value of the float x clamped to zero.
        /// </summary>
        public static unsafe float Clamp0(float x)
        {
            int casted = *(int*)&x;
            int s = casted >> 31;
            s = ~s;
            casted &= s;
            return x = *(float*)&casted;
        }

        /// <summary>
        /// PRECISE: Returns the absolute value of the float x.
        /// </summary>
        public static unsafe float AbsFloat(float x)
        {
            int i = ((*(int*)&x) & 0x7fffffff);
            return (*(float*)&i);
        }

        /// <summary>
        /// APPROXIMATION: Returns the inverse value of the float x.
        /// </summary>
        public static unsafe float InverseFloat(float x)
        {
            uint* i = (uint*)&x;
            *i = 0x7F000000 - *i;
            return x;
        }

        /// <summary>
        /// APPROXIMATION: The famous Quake 3 fast inverse square root approximation! Estimated 5% average error, increasing as 'x' 
        /// gets closer to zero.
        /// </summary>
        public unsafe static float InvSqrtFloat(float x)
        {
            int i = 0x5f3759d5 - ((*(int*)&x) >> 1);
            x = *(float*)&i;
            return x * (1.5f - (0.5f * x) * x * x);
        }

        /// <summary>
        /// APPROXIMATION: The famous Quake 3 fast inverse square root approximation! Estimated 5% average error, increasing as 'x' 
        /// gets closer to zero.
        /// </summary>
        public unsafe static double InvSqrtDouble(double x)
        {
            long i = 0x5fe6ec85e7de30da - ((*(long*)&x) >> 1);
            x = *(double*)&i;
            return x * (1.5f - (0.5 * x) * x * x);
        }

        /// <summary>
        /// APPROXIMATION: Returns square root of a float x with average error of 5%, with error increasing as x gets closer to zero.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float SqrtFloat(float x)
        {
            uint i = ((*(uint*)&x) + 1065353216U) >> 1;
            return *(float*)&i;
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of x^y where x is the base and y is the exponent. The average error is about 
        /// 4%, with the error increasing as the exponent increases.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float PowFloat(float x, float y)
        {
            long temp = ((long)((int)(y * (((int)(*((long*)&x))) - 1072632447) + 1072632447))) << 32;
            return (float)(*((double *)&temp));
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of x^y where x is the base and y is the exponent. The average error is about 
        /// 4%, with the error increasing as the exponent increases.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double PowDouble(double x, double y)
        {
            long temp = ((long)((int)(y * (((int)(*((long*)&x))) - 1072632447) + 1072632447))) << 32;
            return *((double*)&temp);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of ln(x).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double LnDouble(double x)
        {
            return (((*((long*)&x)) >> 32) - 1072632447) / 1512775;
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of ln(x).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float LnFloat(double x)
        {
            return (float)(((*((long*)&x)) >> 32) - 1072632447) / 1512775;
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of e^x. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double ExpDouble(double x)
        {
            long temp = ((long)(1512775 * x + 1072632447)) << 32;
            return *((double*)&temp);
        }

        /// <summary>
        /// APPROXIMATION: Returns an approximation of e^x. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float ExpFloat(double x)
        {
            long temp = ((long)(1512775 * x + 1072632447)) << 32;
            return (float)(*((double*)&temp));
        }

    }

}
