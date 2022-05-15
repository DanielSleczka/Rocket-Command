using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSystem : MonoBehaviour
{
    [SerializeField] private LoadingView loadingView;

    private int sceneToLoad;
    private int sceneToUnload;


    public void StartLoadingScene(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        sceneToUnload = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        var loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        // TODO: pasek do postêpu loadingOperation.progress  
        yield return new WaitUntil(()=>loadingOperation.isDone);
        StartUnloadingScene();
        sceneToLoad = -1;
    }

    public void StartUnloadingScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
        StartCoroutine(UnloadScene());
    }


    private IEnumerator UnloadScene()
    {
        var unloadingOperation = SceneManager.UnloadSceneAsync(sceneToUnload);
        yield return new WaitUntil(() => unloadingOperation.isDone);
        sceneToUnload = -1;
    }

    public void StartGame()
    {
        loadingView.ShowView();
        StartLoadingScene(1);
    }
}
 