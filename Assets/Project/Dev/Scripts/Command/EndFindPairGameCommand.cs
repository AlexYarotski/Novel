using Naninovel;
using Project.Dev.Scripts;

[CommandAlias("endFindPairGame")]
public class EndFindPairGame : Command
{
    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        var tcs = new UniTaskCompletionSource();

        FindPairGame.Completed += FindPairGame_Completed;
        
        await tcs.Task;
        return;

        void FindPairGame_Completed()
        {
            var uiManager = Engine.GetService<IUIManager>();
            var findPairGameUI = uiManager.GetUI<FindPairGameUI>(); 
            
            FindPairGame.Completed -= FindPairGame_Completed;
            findPairGameUI.FadeOutAllElements();
            
            tcs.TrySetResult();
        }
    }
}