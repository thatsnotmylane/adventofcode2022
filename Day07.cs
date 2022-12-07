namespace adventofcode2022.thatsnotmylane;

public class Day07 : AdventBase
{
    public Dictionary<string[], int> _paths { get; set; } = new Dictionary<string[], int>();
    public Dictionary<string[], int> _directorySizes { get; set; } = new Dictionary<string[], int>();

    public Day07() : base("input07.txt")
    {
        var workingDirectory = Array.Empty<string>();

        _paths.Add(new[] { "/" }, 0);
        foreach(var line in _input)
        {
            var parts = line.Split(' ');
            if (parts[0] == "$")
            {
                var command = parts[1];
                if (command == "ls")
                {

                }
                else if (command == "cd")
                {
                    var newDirectory = parts[2];
                    if (newDirectory == "..")
                    {
                        Array.Resize(ref workingDirectory, workingDirectory.Length - 1);
                    }
                    else
                    {
                        workingDirectory = workingDirectory.Concat(new[] { newDirectory }).ToArray();
                    }
                }
            }
            else if (parts[0] == "dir")
            {
                var directoryName = parts[1];
                var directoryPath = new string[workingDirectory.Length];
                workingDirectory.CopyTo(directoryPath, 0);
                directoryPath = directoryPath.Concat(new[] { directoryName }).ToArray();
                if(_paths.ContainsKey(directoryPath) == false)
                {
                    _paths.Add(directoryPath, 0);
                }
            }
            else
            {
                int.TryParse(parts[0], out var fileSize);
                var fileName = parts[1];
                var filePath = new string[workingDirectory.Length];
                workingDirectory.CopyTo(filePath, 0);
                filePath = filePath.Concat(new[] { fileName }).ToArray();
                if(_paths.ContainsKey(filePath) == false)
                {
                    _paths.Add(filePath, fileSize);
                }
            }
        }

        foreach(var directoryPath in _paths.Where(p => p.Value == 0))
        {
            var directory = directoryPath.Key;
            var subDirectories = _paths.Where(p => Enumerable.SequenceEqual( p.Key.Take(directory.Length), directory)).ToArray();
            var directorySize = subDirectories.Sum(sd => sd.Value);
            _directorySizes.Add(directory, directorySize);
        }

        _partOne = _directorySizes.Where(ds => ds.Value <= 100000).Sum(ds => ds.Value);

        var fileSystemMax = 70000000;
        var unusedSpaceRequired = 30000000;
        var currentSpaceUsed = _directorySizes.Where(ds => Enumerable.SequenceEqual( ds.Key, new[] {"/"}) ).Select(ds => ds.Value).First();
        var currentUnsedSpace = fileSystemMax - currentSpaceUsed;
        var amountToRemove = unusedSpaceRequired - currentUnsedSpace;
        Console.WriteLine($"Current Space: {currentSpaceUsed}");
        Console.WriteLine($"Current unused Space: {currentUnsedSpace}");
        Console.WriteLine($"Amount To Remove: {amountToRemove}");

        var validRemoveDirectories = _directorySizes.Where(ds => ds.Value >= amountToRemove);
        var minRemoveDir = validRemoveDirectories.OrderBy(d => d.Value).First();
        _partTwo = minRemoveDir.Value;
    }

}
