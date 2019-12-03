//https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution {
  public class BattleshipField {
    public static bool ValidateBattlefield(int[,] field) {
        return new BattleshipField(field).Validate();
    }
    private List<Ship> _ships;
    public readonly List<int> MandatoryShipsBySize = new List<int>{4, 3, 3, 2, 2, 2, 1, 1, 1, 1}; 
    public BattleshipField(int [,] field){
        _ships = new List<Ship>();

        for(int x = 0; x < field.GetLength(0); x++){
            for(int y = 0; y < field.GetLength(1); y++){
                if(field[x, y] == 1){
                    var ship = new Ship{Area = SearchShip(field, x, y, new List<(int, int)>())};
                    _ships.Add(ship);
                    foreach(var area in ship.Area){
                        field[area.Item1, area.Item2] = 0;
                    }
                }
            }
        }
    }
    public bool Validate(){
        var shipsBySize = _ships.Select(x => x.Area.Count()).OrderByDescending(x=>x);
        return _ships.All(x => x.Validate()) //all ships have a valid shape
                && shipsBySize.SequenceEqual(MandatoryShipsBySize); // no missing or additional ships
    }

    //For simplification a ship is composed of all touching 1's including on the edge.
    private List<(int, int)> SearchShip(int [,] field, int x, int y, List<(int, int)> except){
        var area = new List<(int, int)>{};
        if(field[x, y] == 1)
        {
            area.Add((x,y));
            except.Add((x, y));

            int xStart = x == 0 ? x : x - 1;
            int xEnd = x == field.GetLength(0) - 1 ? x : x + 1;
            int yStart = y == 0 ? y : y - 1;
            int yEnd = y == field.GetLength(1) - 1 ? y : y + 1;

            var areaToSearch = Range(xStart, xEnd).SelectMany(list => Range(yStart, yEnd), (xNew, yNew)=> (xNew, yNew)).Except(except);
            foreach(var a in areaToSearch){
                area.AddRange(SearchShip(field, a.Item1, a.Item2, except));
            }
        }
        return area.Distinct().ToList();
    }

    private IEnumerable<int> Range(int from, int to){
        return Enumerable.Range(from, to-from+1);
    }
  }

  public class Ship{
      public List<(int, int)> Area {get;set;}

      //Each ship must be a straight line, except for submarines, which are just single cell.
      public bool Validate(){
          (int, int) area = Area.First();
          return Area.All(x => x.Item1 == area.Item1) || Area.All(x => x.Item2 == area.Item2);
      }
  }
}
6 days agoRefactorDiscuss
5 kyu
Integers: Recreation One
C#:
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
