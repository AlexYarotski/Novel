using Naninovel;
using UnityEngine;

public class NaninovelStarter : MonoBehaviour
{
    private const string StartNovelScript = "Start";
    
    private async void Start()
    {
        await RuntimeInitializer.InitializeAsync();
        var player = Engine.GetService<IScriptPlayer>();
        await player.PreloadAndPlayAsync(StartNovelScript);
    }
}