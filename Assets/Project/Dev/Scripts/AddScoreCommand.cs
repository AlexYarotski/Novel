using Naninovel;

[CommandAlias("addScore")]
public class AddScoreCommand : Command
{
    [RequiredParameter]
    public IntegerParameter Amount;

    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        ScoreManager.Instance.AddScore(Amount);
        return UniTask.CompletedTask;
    }
}