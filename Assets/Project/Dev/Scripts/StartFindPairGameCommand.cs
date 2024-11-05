using Naninovel;
using UnityEngine;

[CommandAlias("startFindPairGame")]
public class StartFindPairGameCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        GameObject findPairGame = GameObject.Find("FindPairGame");
        
        if (findPairGame != null)
        {
            findPairGame.SetActive(true);
        }
        
        return UniTask.CompletedTask;
    }
}