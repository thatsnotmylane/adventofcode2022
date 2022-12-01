namespace adventofcode2022.thatsnotmylane;

public class AdventBase
{
    public readonly string[] _input;
    public int _partOne { get; set; } = 0;
    public int _partTwo { get; set; } = 0;
    public AdventBase(string fileName)
    {
        _input = File.ReadAllLines($"../../../{fileName}");
    }

    public void DisplayAnswers()
    {
        Console.WriteLine($"{this.GetType().Name}{Environment.NewLine}Part One Answer: {_partOne}{Environment.NewLine}Part Two Answer: {_partTwo}");
    }
}
