namespace adventofcode2022.thatsnotmylane;

public class Day03 : AdventBase
{
    public Day03() : base("input03.txt")
    {
        var partOnePriorities = Array.Empty<int>();
        foreach(var line in _input)
        {
            var itemsInSack = line.Length;
            var compartmentSize = itemsInSack / 2;
            var firstCompartment = line.Substring(0, compartmentSize);
            var secondCompartment = line.Substring(compartmentSize, compartmentSize);

            var commonItem = firstCompartment.Intersect(secondCompartment).FirstOrDefault();

            var isUpper = char.IsUpper(commonItem);

            var priorityAsLower = char.ToLower(commonItem) - 96;

            var priority = PriorityFromChar(commonItem);

            partOnePriorities = partOnePriorities.Concat(new[] { priority }).ToArray();
        }

        _partOne = partOnePriorities.Sum();

        var partTwoPriorities = Array.Empty<int>();
        for(int i = 0; i < _input.Length; i += 3)
        {
            var sackOne = _input[i];
            var sackTwo = _input[i + 1];
            var sackThree = _input[i + 2];

            var badgeLetter = sackOne
                .Intersect(sackTwo)
                .Intersect(sackThree)
                .FirstOrDefault();

            var badgePriority = PriorityFromChar(badgeLetter);

            partTwoPriorities = partTwoPriorities.Concat(new[] { badgePriority }).ToArray();
        }

        _partTwo = partTwoPriorities.Sum();
    }

    int PriorityFromChar(char input)
    {
        var isUpper = char.IsUpper(input);

        var priorityAsLower = char.ToLower(input) - 96;

        var priority = priorityAsLower + (true == isUpper ? 26 : 0);

        return priority;
    }
}
