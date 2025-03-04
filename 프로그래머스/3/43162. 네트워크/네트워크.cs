using System;
using System.Linq;
using System.Collections.Generic;

public class Computer
{
    public List<Computer> Connected { get; set; }
    public bool Visit { get; set; }
    
    public Computer()
    {
        Connected = new List<Computer>();
    }
}

public class Solution 
{
    public int solution(int n, int[,] computers) 
    {
        var computerList = Enumerable.Range(0, n).Select(_ => new Computer()).ToArray();    
        
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var linkInfo= computers[i, j];
                
                if (linkInfo == 1)
                    computerList[i].Connected.Add(computerList[j]);   
            }
        }

        var pending = new HashSet<Computer>(computerList);
        var networkCount = 0;

        while (pending.Count > 0)
        {
            var peek = pending.First();
            SearchNetwork(peek, ref pending);
            networkCount++;
        }
        
        return networkCount;
    }
    
    private void SearchNetwork(Computer root, ref HashSet<Computer> pending)
    {
        var peek = root;
        peek.Visit = true;
        pending.Remove(peek);
        
        foreach (var connected in peek.Connected.Where(connected => !connected.Visit))
            SearchNetwork(connected, ref pending);
    }
}