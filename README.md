
Fast Approximate Math Library (FAML)

By: Roy Hwang

=====================================
Credits: 
=====================================

Several of these algorithms are C to C# ports from the 
lovely website https://graphics.stanford.edu/~seander/bithacks.html and 
others are from web resources such as the always dependable Stack Overflow 
comments sections! Other algorithms are derived from my own research, and 
some basic math principles.

=====================================
About: 
=====================================

  The provided methods offer an alternate way of getting both precise results and 
approximations of standard math functions which are used regularly throughout any 
sort of programming. The goal of this library was to provide faster math functions for 
performance intensive programs or hot sections of code. 

HOWEVER - NEITHER THE PRECISE METHODS, NOR THE APPROXIMATIONS ARE GUARANTEED TO 
BE A FASTER SOLUTION FOR YOUR TARGET HARDWARE!!! Always benchmark for your 
hardware platform, before completely integrating any solution from any library!

  Please be aware that some methods may only exist as a "safe" version, and 
some methods in this library may only exist as an "unsafe" version. Sometimes, 
a method will exist with both a "safe" and "unsafe" version, which can have 
slightly different implementations. If a common math function does not 
exist in FAML, it is because the .NET implementation from System.Math is 
generally superior, or I forgot. This is a continuous work!

  The method summaries will tell you if a method will return a precise 
result, or an approximation. Approximations will (generally) be 
faster, at the expense of some degree of error.

  I've personally experienced a boost from select algorithms provided in this 
library for certain programs, and it is my hope that you can find something 
useful to you here as well.  Once again, BENCHMARK FOR YOUR TARGET HARDWARE 
FIRST! I take no responsibility for anything you do with the code provided 
here.

As a final note, I've omitted error checks for the sake of performance. If you know that your 
input will fall within a given valid range (as is often the case), then this is for the better. 
However, if you do not have that guarantee, it is quite trivial to add the error checking 
yourself to any single one of these methods. 

You'll also find that most of these options 
have hints to the JITer for an inlining preference. Most of these methods should show some performance 
benefit from inlining, but some of the larger methods may actually become slower when used often and 
inlined since it can reduce locality of reference and cause cache misses to occur (which is a topic too 
deep for a readme section!). If your benchmark reflects these possible pitfalls, try removing the inlining 
hint attribute. You may also need to remove these attributes if you are working with a .NET framework version which 
does not support "[MethodImpl(MethodImplOptions.AggressiveInlining)]".

With those caveats in mind, please enjoy! I hope you find this library useful. I always welcome criticism and improvement of my works.
