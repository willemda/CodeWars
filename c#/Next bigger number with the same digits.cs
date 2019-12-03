//https://www.codewars.com/kata/55983863da40caa2c900004e
using System.Linq;

public class Kata
{
    public static long NextBiggerNumber(long n)
    {
        return long.Parse(NextBigNumberString(n.ToString()));
    }
    public static string NextBigNumberString(string n){
        for(int i = n.Length -1; i > 0; i--){
            if(n[i] > n[i-1]){
                var sub =  n.Substring(i);
                var pre = n.Substring(0, i - 1);
                var val = sub.Where(x=>x>n[i-1]).Min();
                var post = sub.Remove(sub.IndexOf(val), 1).Append(n[i-1]).OrderBy(x=>x);
                return $"{pre}{val}{string.Concat(post)}";
            }
        }
        return "-1";
    }
}
