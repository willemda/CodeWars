//https://www.codewars.com/kata/557f6437bf8dcdd135000010
using System;
using System.Linq;

public class Kata
{
  public static string Factorial(int n)
  {
    int[] results = new int[10000];
    results[0] = 1;
    int res_size = 1;
    for(int i = 2; i <= n; i++){
        res_size = Multiply(results, i, res_size);
    }

    return string.Concat(results.Take(res_size).Reverse());
  }

  public static int Multiply(int[] array, int x, int size){
      int carry = 0;
      for(int i = 0; i < size; i++){
          int product = array[i] * x + carry;
          array[i] = product % 10;
          carry = product / 10;
      }

      while(carry != 0){
          size++;
          array[size - 1] = carry % 10;
          carry = carry / 10;
      }

      return size;
  }
}
