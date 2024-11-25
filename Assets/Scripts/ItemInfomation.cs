using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfomation : MonoBehaviour
{
    public Transform whiteBoard;
    public GameObject itemInfoUI;
    private List<GameObject> activeInfo = new List<GameObject>();
    private List<GameObject> unactiveInfo = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Item")) {
            if (unactiveInfo.Count == 0) {
                GameObject infoTmp = Instantiate(itemInfoUI, whiteBoard);
                infoTmp.transform.localPosition = Vector3.zero;
                infoTmp.transform.name = other.transform.name;
                infoTmp.GetComponent<Image>().sprite = other.gameObject.GetComponent<Item>().ItemInfo;
                activeInfo.Add(infoTmp);
            } else {
                GameObject infoTmp = unactiveInfo[0];
                infoTmp.gameObject.SetActive(true);
                infoTmp.transform.localPosition = Vector3.zero;
                infoTmp.transform.name = other.transform.name;
                infoTmp.GetComponent<Image>().sprite = other.gameObject.GetComponent<Item>().ItemInfo;
                unactiveInfo.Remove(infoTmp);
                activeInfo.Add(infoTmp);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Item")) {
            for (int i = 0; i < activeInfo.Count; i++) {
                if (activeInfo[i].name == other.gameObject.GetComponent<Item>().ItemName) {
                    activeInfo[i].gameObject.SetActive(false);
                    activeInfo.Remove(activeInfo[i]);
                    break;
                }
            }
        }
    }
}
