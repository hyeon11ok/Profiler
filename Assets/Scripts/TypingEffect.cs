using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text txt;
    public Text exitTxt;
    [Multiline] public string[] comment;
    public AudioClip[] typingSounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Typing(0));
    }

    IEnumerator Typing(int idx) {
        for (int i = 0; i <= comment[idx].Length; i++) {
            int num = Random.Range(0, typingSounds.Length);
            SoundManager.instance.SFXPlay("typing", typingSounds[num]);

            txt.text = comment[idx].Substring(0, i);

            yield return new WaitForSeconds(0.08f);
        }

        idx++;
        if(idx < comment.Length) {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(Typing(idx));
        } else {
            string ending = "게임 종료";
            for (int i = 0; i <= ending.Length; i++) {
                int num = Random.Range(0, typingSounds.Length);
                SoundManager.instance.SFXPlay("typing", typingSounds[num]);

                exitTxt.text = ending.Substring(0, i);

                yield return new WaitForSeconds(0.08f);
            }
            exitTxt.GetComponent<Button>().enabled = true;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
