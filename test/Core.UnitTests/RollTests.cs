namespace Core.UnitTest;

public class RollTests{
    private readonly Score _sut;
    public RollTests()
    {
        _sut = new Score();
    }

    [Fact]
    public void ShouldAddRollOnFrame(){
        _sut.Roll(1);

        var score = _sut.ScoreGame();

        score.Should().Be(1);
    }

    [Fact]
    public void ShouldAddRollOnNewFrame(){
        _sut.Roll(1);
        _sut.Roll(4);
        _sut.Roll(4);
        _sut.Roll(5);

        var score = _sut.ScoreGame();

        score.Should().Be(14);
    }

    [Fact]
    public void Sur6TirsEtUnSpareLeScoreEst29(){
        _sut.Roll(1);
        _sut.Roll(4);
        _sut.Roll(4);
        _sut.Roll(5);
        _sut.Roll(6);
        _sut.Roll(4);
        _sut.Roll(5);

        var score = _sut.ScoreGame();

        score.Should().Be(34);
    }
}