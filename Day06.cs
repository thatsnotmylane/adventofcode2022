namespace adventofcode2022.thatsnotmylane;

public class Day06 : AdventBase
{
    public Day06() : base("input06.txt")
    {
        
        foreach(var line in _input)
        {
            var inMessage = false;
            for(var i = 4; i <= line.Length; i++)
            {
                var lastFour = line.Substring(i - 4, 4);
                if (inMessage == false && lastFour.Distinct().Count() == 4)
                {
                    Console.WriteLine($"match?: {lastFour}");
                    _partOne = i;
                    inMessage = true;
                }
                else
                {
                    if (i >= 14)
                    {
                        var lastFourteen = line.Substring(i - 14, 14);
                        if(lastFourteen.Distinct().Count() == 14)
                        {
                            Console.WriteLine($"Start of Message: {lastFourteen}");
                            _partTwo = i;
                            break;
                        }
                    }
                }
            }
        }
    }
}
