namespace Core.UnitTest;

public class ScoreTests
{
    [Fact]
    public void AucunTirLeScoreEstZero()
    {
        Score sut = new Score();

        int score = sut.ScoreGame();

        score.Should().Be(0);
    }

}