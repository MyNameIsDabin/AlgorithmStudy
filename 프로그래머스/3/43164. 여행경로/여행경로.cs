using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private const string StartAirport = "ICN";
    private Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();
    private Dictionary<string, int> ticketCounts = new Dictionary<string, int>();
    private List<string> answer = new List<string>();
    private int totalTickets = 0;

    public string[] solution(string[,] tickets)
    {
        for (var i = 0; i < tickets.GetLength(0); i++)
        {
            var from = tickets[i, 0];
            var to = tickets[i, 1];

            if (!paths.ContainsKey(from))
                paths[from] = new List<string>();

            paths[from].Add(to);

            var hash = from + to;
            if (!ticketCounts.ContainsKey(hash))
                ticketCounts[hash] = 0;
            ticketCounts[hash]++;
            totalTickets++;
        }

        var consumed = new Dictionary<string, int>();
        answer.Add(StartAirport);
        Visit(StartAirport, answer, consumed);

        return answer.ToArray();
    }

    private bool Visit(string from, List<string> visited, Dictionary<string, int> consumed)
    {
        if (visited.Count == totalTickets + 1)
            return true;

        if (!paths.ContainsKey(from))
            return false;

        foreach (var to in paths[from].OrderBy(x => x))
        {
            var hash = from + to;

            if (!consumed.ContainsKey(hash)) 
                consumed[hash] = 0;

            if (consumed[hash] >= ticketCounts[hash])
                continue;

            visited.Add(to);
            consumed[hash]++;

            if (!Visit(to, visited, consumed))
            {
                visited.RemoveAt(visited.Count - 1);
                consumed[hash]--;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}