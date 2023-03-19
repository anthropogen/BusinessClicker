using Clicker.Infrastructure;
using UnityEngine;

public class PersistentMonoProvider : MonoBehaviour
{
    private IPersistentDataService _persistentDataService;

    public void Construct(IPersistentDataService persistentDataService)
        => _persistentDataService = persistentDataService;

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            _persistentDataService.Save();

    }

    private void OnApplicationQuit()
    {
        _persistentDataService.Save();
    }
}
