using Naninovel;
using UnityEngine;

[Command.CommandAlias("checkScore")]
public class CheckScoreCommand : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var scoreManager = new ScoreManager(); // Или получайте его через DI, если это необходимо.
        var score = scoreManager.GetScore();
        Debug.Log($"Current Score: {score}");
        return UniTask.CompletedTask;
    }
}