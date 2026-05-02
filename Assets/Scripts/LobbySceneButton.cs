using UnityEngine;

public class LobbySceneButton : MonoBehaviour
{
    [SerializeField] private int inGameSceneIndex = 2;

    public void OnClickStartGame()
    {
        if (LoadManager.Instance != null)
        {
            LoadManager.Instance.LoadSceneWithLoading(inGameSceneIndex);
        }
        else
        {
            Debug.LogError("LoadManager가 씬에 없습니다.");
        }
    }
}