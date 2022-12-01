namespace adventofcode2022.thatsnotmylane;

public class Day01 : AdventBase
{
    public Day01() : base("input01.txt")
    {
        var calorieCounts = Array.Empty<int>();
        var thisElf = 0;
        foreach (var line in _input)
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

        _partOne = calorieCounts.Max();

        var topThreeTotal = calorieCounts
            .OrderByDescending(c => c)
            .Take(3)
            .Sum();

        _partTwo = topThreeTotal;
    }


}
