namespace adventofcode2022.thatsnotmylane;

public class Day01
{
    public Day01()
    {
        var input = File.ReadAllLines("../../../input01.txt");
        var calorieCounts = Array.Empty<int>();
        var thisElf = 0;
        foreach (var line in input)
        {
            if(true == int.TryParse(line, out var individualCalorie))
            {
                thisElf += individualCalorie;
            }
            else
            {
                calorieCounts = calorieCounts.Concat(new[] { thisElf }).ToArray();
                thisElf = 0;
            }
        }

        Console.WriteLine($"Part One: {calorieCounts.Max()}");

        var topThreeTotal = calorieCounts
            .OrderByDescending(c => c)
            .Take(3)
            .Sum();

        Console.WriteLine($"Part Two: {topThreeTotal}");
    }
}
