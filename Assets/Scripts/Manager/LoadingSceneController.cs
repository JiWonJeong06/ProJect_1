using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingSceneController : MonoBehaviour
{
    [Header("Loading UI")]
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TMP_Text loadingText;

    [Header("Settings")]
    [SerializeField] private float minimumLoadingTime = 1.0f;

    void Start()
    {
        int targetSceneIndex = LoadManager.TargetSceneIndex;

        if (targetSceneIndex < 0)
        {
            Debug.LogError("목표 씬 인덱스가 설정되지 않았습니다.");
            return;
        }

        StartCoroutine(LoadSceneRoutine(targetSceneIndex));
    }

    IEnumerator LoadSceneRoutine(int targetSceneIndex)
    {
        float timer = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            float loadProgress = Mathf.Clamp01(operation.progress / 0.9f);
            float timeProgress = Mathf.Clamp01(timer / minimumLoadingTime);

            float finalProgress = Mathf.Min(loadProgress, timeProgress);

            if (loadingSlider != null)
                loadingSlider.value = finalProgress;

            if (loadingText != null)
                loadingText.text = $"{Mathf.RoundToInt(finalProgress * 100f)}%";

            if (operation.progress >= 0.9f && timer >= minimumLoadingTime)
            {
                if (loadingSlider != null)
                    loadingSlider.value = 1f;

                if (loadingText != null)
                    loadingText.text = "100%";

                yield return new WaitForSeconds(0.2f);

                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}