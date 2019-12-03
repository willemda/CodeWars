//https://www.codewars.com/kata/55aa075506463dac6600010d
using System;
using System.Collections.Generic;
using System.Linq;

public class SumSquaredDivisors 
{
	public static string listSquared(long m, long n)
	{
        Dictionary<long, long> results = new Dictionary<long, long>();
        for(long i = m; i <= n; i++){
            var dividers = FindDividers(i);
            var sum = (long)dividers.Select(x=> Math.Pow(x, 2)).Sum();
            if(Math.Sqrt(sum)%1 == 0){
                results.Add(i, sum);
            }
        }
        return $"[{string.Join(", ",results.Select(x=> $"[{x.Key}, {x.Value}]"))}]";
	}

    public static IEnumerable<long> FindDividers(long m){
        for(long d = 1; d <= m; d++){
            if(m%d == 0) yield return d;
        }
    }
}
