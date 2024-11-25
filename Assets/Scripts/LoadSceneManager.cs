using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void ResultSceneLoad() {
        string name = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GetSceneName();

        if (name == "")
            return;
        else {
            StartCoroutine(LoadingAsync(name));
        }
    }

    IEnumerator LoadingAsync(string name) {
        SceneManager.LoadScene("LoadingScene");
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(0.5f); // 짧은 지연으로 메모리 확보 시간을 줌

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        asyncOperation.allowSceneActivation = true; //로딩이 완료되는대로 씬을 활성화할것인지
        yield return null;
    }
}
