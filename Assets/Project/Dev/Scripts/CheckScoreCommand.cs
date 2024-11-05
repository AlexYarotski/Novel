using Naninovel;
using UnityEngine;

[CommandAlias("checkScore")]
public class CheckScoreCommand : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var score = ScoreManager.Instance.GetScore();
        Debug.Log($"Current Score: {score}");
        return UniTask.CompletedTask;
    }
}