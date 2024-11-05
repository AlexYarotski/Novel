using Naninovel;
using Naninovel.UI;
using Project.Dev.Scripts;
using UnityEngine;

[CommandAlias("startFindPairGame")]
public class StartFindPairGameCommand : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        // Попытка найти UI объект по его имени в UI Configuration.
        var uiManager = Engine.GetService<IUIManager>();
        var findPairGameUI = uiManager.GetUI<FindPairGameUI>(); // Укажите точное имя из UI Configurations

        if (findPairGameUI != null)
        {
            findPairGameUI.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("UI объект 'FindPairGame' не найден в UI Configurations.");
        }

        return UniTask.CompletedTask;
    }
}