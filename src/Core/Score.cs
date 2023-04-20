using System.Linq;

namespace Core;

public class Frame
{
    private readonly int?[] _rolls = new int?[2];

    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            return;
        }

        if (IsClosed)
        {
            return;
        }

        if (_rolls[0].HasValue){
            _rolls[1] = pins;
            return;
        }

        _rolls[0] = pins;
    }

    public IReadOnlyList<int> FrameRolls => new List<int>(_rolls.Select(roll=> roll.HasValue? roll.Value : 0));

    public bool IsSpare => !IsStrike && Score() == 10;

    public bool IsStrike => _rolls[0] == 10;

    public int Score() => FrameRolls.Sum();

    public bool IsClosed => IsStrike || (_rolls[0].HasValue && _rolls[1].HasValue);
}

public class Score
{
    private List<Frame> _frames = new();

    public void Roll(int pins)
    {
        var _lastFrame = _frames.LastOrDefault();

        if (_lastFrame == null || _lastFrame.IsClosed){
            _lastFrame = new Frame();
            _frames.Add(_lastFrame);
        }

        _lastFrame.Roll(pins);
    }

    public int ScoreGame()
    {
        if (_frames.Count == 0){
            return 0;
        }

        var score = _frames[0].Score();

        for (int i = 1; i < _frames.Count; i++)
        {
            score += _frames[i].Score();
            if (_frames[i-1].IsSpare){
                score += _frames[i].FrameRolls[0];
            }
        }

        return score;
    }
}