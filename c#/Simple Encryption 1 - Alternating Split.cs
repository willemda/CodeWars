//https://www.codewars.com/kata/57814d79a56c88e3e0000786
using System.Linq;

public class Kata
{
  public static string Encrypt(string text, int n)
  {
    if(string.IsNullOrEmpty(text))
        return text;
    if(n <= 0)
        return text;

    var encrypted = text.Select((Val, Index)=> new {Val, Index = (Index+1)%2 == 0 ? Index/2 : text.Length/2+((Index+1)/2)})
                        .OrderBy(x => x.Index)
                        .Select(x => x.Val);

    return Encrypt(string.Concat(encrypted), n - 1);
  }
  
  public static string Decrypt(string encryptedText, int n)
  {
    if(string.IsNullOrEmpty(encryptedText))
        return encryptedText;
    if(n <= 0)
        return encryptedText;
    
    var part1 = encryptedText.Substring(0, encryptedText.Length / 2).Select((Val, Index) => new {Val, Index = (Index  * 2)+1});
    var part2 = encryptedText.Substring(encryptedText.Length / 2).Select((Val, Index) => new {Val, Index = Index * 2});

    var decrypted = part1.Concat(part2)
                         .OrderBy(x => x.Index)
                         .Select(x => x.Val);

    return Decrypt(string.Concat(decrypted), n - 1);
  }
}
