using Naninovel;
using Naninovel.UI;
using Project.Dev.Scripts;
using UnityEngine;

[CommandAlias("startFindPairGame")]
public class StartFindPairGameCommand : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var uiManager = Engine.GetService<IUIManager>();
        var findPairGameUI = uiManager.GetUI<FindPairGameUI>(); 

        if (findPairGameUI != null)
        {
            findPairGameUI.Enable();
        }
        else
        {
            Debug.LogError("UI объект 'FindPairGame' не найден в UI Configurations.");
        }

        return UniTask.CompletedTask;
    }
}