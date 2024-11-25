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
        yield return new WaitForSeconds(0.5f); // ª�� �������� �޸� Ȯ�� �ð��� ��

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        asyncOperation.allowSceneActivation = true; //�ε��� �Ϸ�Ǵ´�� ���� Ȱ��ȭ�Ұ�����
        yield return null;
    }
}
