using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    LaserPointer laser;
    Transform pointer; // 추적을 위한 포인터 정보
    Vector3 offset; // 오브젝트의 위치와 포인터 사이의 초기 간격

    // Start is called before the first frame update
    void Start()
    {
        laser = GameObject.Find("UIHelpers").transform.GetChild(0).GetComponent<LaserPointer>();
    }

    public void SetPointer() {
        pointer = laser.cursorVisual.transform;
        offset = pointer.position - transform.position;
    }

    public void FollowPointer() {
        transform.position = pointer.position - offset; // 최초 클릭 시의 간격을 유지하기 위함
    }

    public void ResetPointer() {
        pointer = null;
        offset = Vector3.zero;
    }
}
