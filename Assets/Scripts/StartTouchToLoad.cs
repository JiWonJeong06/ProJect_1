using UnityEngine;
using UnityEngine.InputSystem;

public class StartTouchToLoad : MonoBehaviour
{
    [Header("Target Scene")]
    [SerializeField] private int lobbySceneIndex = 1;

    private bool isLoading = false;

    void Update()
    {
        if (isLoading) return;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            StartLoading();
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartLoading();
        }
    }

    void StartLoading()
    {
        isLoading = true;

        if (LoadManager.Instance != null)
        {
            LoadManager.Instance.LoadSceneWithLoading(lobbySceneIndex);
        }
        else
        {
            Debug.LogError("LoadManager가 씬에 없습니다.");
        }
    }
}