using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartTouchHandler : MonoBehaviour
{
    private const int LOBBY_SCENE_INDEX = 1;

    private bool isTouched = false;

    private void Update()
    {
        if (isTouched)
            return;

        // 모바일 터치
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            GoLobby();
            return;
        }

        // 에디터/PC 테스트용
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            GoLobby();
        }
    }

    private void GoLobby()
    {
        isTouched = true;
        SceneManager.LoadScene(LOBBY_SCENE_INDEX);
    }
}