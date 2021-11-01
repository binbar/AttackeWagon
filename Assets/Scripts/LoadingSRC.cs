using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSRC : MonoBehaviour {
    public Slider bar;
    public GameObject LoadingScreen;
    public GameObject[] Hints;
    public GameObject Loading_text;
    public GameObject Loading_text_push_on_screen;

    string name_of_lvl;

    public void LoadSomeLvl (string input_lvl) {
        name_of_lvl = input_lvl;
        LoadingScreen.SetActive (true);
        Loading_text.SetActive (true);
        Hints[Random.Range (0, Hints.Length)].SetActive (true);
        Debug.Log ("LoadSomeLvl");
        // StartCoroutine(LoadAsyncSceneLVL());

        LoadLevel (name_of_lvl);
    }

    public void LoadLevel (string sceneIndex) {
        StartCoroutine (LoadAsynchronously (sceneIndex));
    }

    IEnumerator LoadAsynchronously (string sceneIndex) {
        LoadingScreen.SetActive (true);
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01 (operation.progress / 0.9f);

            if (progress > 0.9f) {
                Loading_text_push_on_screen.SetActive (true);
                Loading_text.SetActive (false);
            }

            bar.value = progress;

            yield return null;
        }
    }

    /*
    IEnumerator LoadAsyncSceneLVL()
    {
        Debug.Log("LoadAsyncSceneLVL name_of_lvl=" + name_of_lvl);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name_of_lvl);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                Loading_text_push_on_screen.SetActive(true);
                Loading_text.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }

    }
*/
}