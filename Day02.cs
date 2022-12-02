namespace adventofcode2022.thatsnotmylane;

public class Day02 : AdventBase
{   
    public Day02() : base("input02.txt")
    {
        Console.WriteLine(_input[0]);
        var totalScore = 0;
        var partTwoScore = 0;
        foreach(var line in _input)
        {
            var oppChoice = line[0];
            var myChoice = line[2];
            var myScore = myChoice == 'X'
                ? 1
                : myChoice == 'Y'
                    ? 2
                    : 3;

            var oppScore = oppChoice == 'A'
                ? 1
                : oppChoice == 'B'
                    ? 2
                    : 3;

            totalScore += EvaluateRound(myScore, oppScore) + myScore;

            var twoMyScore = myChoice == 'X'
                ? Lose(oppScore)
                : myChoice == 'Y'
                    ? Draw(oppScore)
                    : Win(oppScore);

            partTwoScore += EvaluateRound(twoMyScore, oppScore) + twoMyScore;
            
        }

        _partOne = totalScore;
        _partTwo = partTwoScore;

        
    }

    int EvaluateRound(int myScore, int oppScore)
    {
        if (myScore == oppScore)
        {
            return 3;
        }
        else if (myScore + oppScore == 4)
        {
            if (myScore < oppScore)
            {
                return 6;
            }
        }
        else
        {
            if (myScore > oppScore)
            {
                return 6;
            }
        }
        return 0;
    }

    int Win(int oppScore)
    {
        if(oppScore == 1)
        {
            return 2;
        }
        else if(oppScore == 2)
        {
            return 3;
        }
        else
        {
            return 1;
        }
    }

    int Lose(int oppScore)
    {
        if(oppScore == 1)
        {
            return 3;
        }
        else if(oppScore == 2)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    int Draw(int oppScore)
    {
        return oppScore;
    }

}
