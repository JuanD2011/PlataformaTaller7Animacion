using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    AsyncOperation operation = null;

    /// <summary>
    /// Load asynchronously the scene that has the same build index
    /// </summary>
    public void LoadLevel(int _LevelBuildIndex) 
    {
        StartCoroutine(LoadAsynchronously(_LevelBuildIndex));
    }

    private IEnumerator LoadAsynchronously(int _LevelBuildIndex)
    {
        operation = SceneManager.LoadSceneAsync(_LevelBuildIndex);

        yield return new WaitUntil(() => operation.isDone);
    }
}