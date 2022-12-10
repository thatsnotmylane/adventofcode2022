namespace adventofcode2022.thatsnotmylane;

public class Day10 : AdventBase
{
    public Dictionary<int, int> _registerRecord { get; set; } = new Dictionary<int, int>();
    public Day10() : base("input10.txt")
    {
        var clockCyle = 1;
        _registerRecord[0] = 1;
        foreach(var line in _input)
        {
            var lineInputs = line.Split(" ");
            var instruction = lineInputs[0];
            if(instruction == "noop")
            {
                var previousValue = _registerRecord[clockCyle - 1];
                var existingValue = _registerRecord.ContainsKey(clockCyle) == true ? _registerRecord[clockCyle] : 0;
                _registerRecord[clockCyle] = previousValue + existingValue;
            }
            else
            {
                var previousValue = _registerRecord[clockCyle - 1];
                var existingValue = _registerRecord.ContainsKey(clockCyle) == true ? _registerRecord[clockCyle] : 0;
                _registerRecord[clockCyle] = previousValue + existingValue;

                

                int.TryParse(lineInputs[1], out var increment);
                _registerRecord.Add(clockCyle + 1, increment + _registerRecord[clockCyle]);
                
                clockCyle += 1;
            }
            clockCyle += 1;
        }

        foreach(var reg in _registerRecord)
        {
            Console.WriteLine($"{reg.Key}: {reg.Value}");
        }

        _partOne = CalculateSignalStrength(20) + CalculateSignalStrength(60) + CalculateSignalStrength(100) + CalculateSignalStrength(140) + CalculateSignalStrength(180) + CalculateSignalStrength(220);

        var h = 0;
        var v = 0;
        var spritePos = _registerRecord[1];
        foreach(var register in _registerRecord)
        {
            var cycle = register.Key;
            spritePos = register.Value;
            var pixels = new int[] { spritePos - 1, spritePos, spritePos + 1 };
            h = normalizeHorizontal(cycle);
            v = normalizeVertical(cycle);


        }
    }

    int CalculateSignalStrength(int cycle)
    {
        var registerValue = _registerRecord[cycle - 1];
        var signalStrength = cycle * registerValue;
        Console.WriteLine($"{cycle}: {registerValue} - {signalStrength}");
        return signalStrength;
    }

    int normalizeHorizontal(int cycle)
    {
        var noralized = cycle % 40;
        return noralized;
    }

    int normalizeVertical(int cycle)
    {
        if(cycle < 41)
        {
            return 0;
        }
        else if(cycle >= 41 && cycle < 80)
        {
            return 1;
        }
        else if (cycle >= 81 && cycle < 120)
        {
            return 2;
        }
        else if (cycle >= 121 && cycle < 160)
        {
            return 3;
        }
        else if (cycle >= 161 && cycle < 200)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }
}
