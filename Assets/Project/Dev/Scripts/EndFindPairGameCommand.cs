using Naninovel;
using UnityEngine;

[CommandAlias("endFindPairGame")]
public class EndFindPairGameCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        GameObject findPairGame = GameObject.Find("FindPairGame");
        
        if (findPairGame != null)
        {
            findPairGame.SetActive(false);
        }
        
        return UniTask.CompletedTask;
    }
}