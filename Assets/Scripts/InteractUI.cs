using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    LaserPointer laser;
    Transform pointer; // ������ ���� ������ ����
    Vector3 offset; // ������Ʈ�� ��ġ�� ������ ������ �ʱ� ����

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
        transform.position = pointer.position - offset; // ���� Ŭ�� ���� ������ �����ϱ� ����
    }

    public void ResetPointer() {
        pointer = null;
        offset = Vector3.zero;
    }
}
