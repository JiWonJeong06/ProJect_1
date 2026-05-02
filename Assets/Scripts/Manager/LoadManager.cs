using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    [Header("Scene Index")]
    [SerializeField] private int loadingSceneIndex = 3;

    public static int TargetSceneIndex { get; private set; } = -1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneWithLoading(int targetSceneIndex)
    {
        TargetSceneIndex = targetSceneIndex;
        SceneManager.LoadScene(loadingSceneIndex);
    }

    public void LoadLobby()
    {
        LoadSceneWithLoading(1);
    }

    public void LoadInGame()
    {
        LoadSceneWithLoading(2);
    }

    public void LoadStart()
    {
        LoadSceneWithLoading(0);
    }
}