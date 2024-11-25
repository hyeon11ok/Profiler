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
            Debug.Log(i + "번 : " + questions[i].IsRight);
            if (!questions[i].IsRight) {
                return false;
            }
        }

        return true;
    }

    // 문제의 정답이 모두 선택 됐는지 확인
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
                // 범인을 맞췄을 경우
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
