using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    public GameObject warning;

    bool ResultCheck() {
        for(int i = 0; i < questions.Length; i++) {
            Debug.Log(i + "�� : " + questions[i].IsRight);
            if (!questions[i].IsRight) {
                return false;
            }
        }

        return true;
    }

    // ������ ������ ��� ���� �ƴ��� Ȯ��
    bool IsSelectedDone() {
        for (int i = 0; i < questions.Length; i++) {
            if (questions[i].s_Answer == -1) {
                return false;
            }
        }

        return true;
    }

    void HideWarning() {
        warning.SetActive(false);
    }

    public string GetSceneName() {
        string name = "";
        if (IsSelectedDone()) {
            if (ResultCheck()) {
                name = "TrueEnding";
            } else {
                // ������ ������ ���
                if (questions[questions.Length - 1].IsRight) {
                    name = "NormalEnding";
                } else {
                    name = "BadEnding";
                }
            }
        } else {
            CancelInvoke();
            warning.SetActive(true);
            Invoke("HideWarning", 1.5f);
        }

        return name;
    }

    public void ExitGame() {
        Application.Quit();
    }
}
