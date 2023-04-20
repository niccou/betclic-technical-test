namespace Core.UnitTest;

public class FrameTests
{
    private readonly Frame _sut = new();

    [Fact]
    public void RollShouldAddOnFirst(){
        _sut.Roll(1);

        _sut.FrameRolls.Should().NotBeEmpty();
        _sut.FrameRolls[0].Should().Be(1);
    }

    [Fact]
    public void RollNotAddMoreThanTwoRolls(){
        _sut.Roll(1);
        _sut.Roll(4);

        _sut.Roll(15);

        _sut.FrameRolls.Should().NotBeEmpty();
        _sut.FrameRolls[0].Should().Be(1);
        _sut.FrameRolls[1].Should().Be(4);
    }

    [Property]
    public Property RollShouldTakeOnlyZeroToTen(int pins)
    {
        Frame sut = new();

        sut.Roll(pins);

        if (pins < 0 || pins > 10)
            return (sut.FrameRolls[0] == 0).ToProperty();

        return (sut.FrameRolls[0] == pins).ToProperty();

    }

    [Fact]
    public void ScoreShouldReturnCorrectScore(){
        _sut.Roll(1);
        _sut.Roll(4);

        int score = _sut.Score();

        score.Should().Be(5);
    }

    [Fact]
    public void ShouldSayIsSpareOnSpareRolls(){
        _sut.Roll(5);
        _sut.Roll(5);

        _sut.IsSpare.Should().BeTrue();
    }

    [Fact]
    public void ShouldSayIsStrikeOnStrikeRoll(){
        _sut.Roll(10);

        _sut.IsStrike.Should().BeTrue();
    }

    [Fact]
    public void ShouldNotSayIsStrikeOnSpareRolls(){
        _sut.Roll(5);
        _sut.Roll(5);

        _sut.IsStrike.Should().BeFalse();
    }

    [Fact]
    public void ShouldNotSayIsSpareOnStrikeRoll(){
        _sut.Roll(10);

        _sut.IsSpare.Should().BeFalse();
    }

    [Fact]
    public void ShouldSayIsClosedOnAllRollsDone(){
        _sut.Roll(1);
        _sut.Roll(4);

        _sut.IsClosed.Should().BeTrue();
    }

    [Fact]
    public void ShouldSayIsClosedOnStrikeFrame(){
        _sut.Roll(10);

        _sut.IsClosed.Should().BeTrue();
    }
}