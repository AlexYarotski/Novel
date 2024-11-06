using Naninovel;

[CommandAlias("checkScore")]
public class CheckScoreCommand : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var score = ScoreManager.Instance.GetScore();
        
        Engine.GetService<ICustomVariableManager>().TrySetVariableValue("PlayerScore", score);

        return UniTask.CompletedTask;
    }
}