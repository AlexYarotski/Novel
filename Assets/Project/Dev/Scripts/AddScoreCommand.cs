using Naninovel;

[CommandAlias("addScore")]
public class AddScoreCommand : Command
{
    [RequiredParameter]
    public IntegerParameter Amount;

    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var scoreManager = new ScoreManager(); // Или получайте его через DI, если это необходимо.
        scoreManager.AddScore(Amount);
        return UniTask.CompletedTask;
    }
}