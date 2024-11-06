using Naninovel;

[CommandAlias("resetScore")]
public class ResetScoreCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.TrySetVariableValue("PlayerScore", 0);

        var scoreManager = ScoreManager.Instance;
            scoreManager.Reset();

        return UniTask.CompletedTask;
    }
}