using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private OVRGrabbable grabbable;
    public Transform nextTr;
    private Vector3 s_pos; // ���� ��ġ
    private Quaternion s_rot; // ���� ����
    public AudioClip nextBGM;
    private bool isTrigged = false; // ���� �ߵ� ���� üũ�� ����, ��������� �ٲ��ֱ� ����

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        s_pos = transform.position;
        s_rot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed) {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.GetComponent<CharacterController>().enabled = false;
            player.position = nextTr.position + Vector3.up;
            player.rotation = nextTr.rotation;
            player.GetComponent<CharacterController>().enabled = true;

            if(!isTrigged) {
                SoundManager.instance.BgSoundPlay(nextBGM);
                isTrigged = true;
            }
        } else {
            ResetTransform();
            isTrigged = false;
        }
    }

    void ResetTransform() {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = s_pos;
        transform.rotation = s_rot;
    }
}
