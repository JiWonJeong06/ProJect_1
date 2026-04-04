using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        //인게임 버튼
        SceneManager.LoadScene(2);
        print("인게임 버튼 클릭");
    }
    public void DifficultyButton()
    {
        print("난이도 버튼 클릭");
    }
    public void SettingsButton()
    {
        print("세팅 버튼 클릭");
    }

    public void RankingButton()
    {
        print("랭킹 버튼 클릭");
    }

    public void ExitButton()
    {
        //게임 종료 버튼
        Application.Quit();
        print("게임 종료");
    }
}
