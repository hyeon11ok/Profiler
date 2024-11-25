using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private OVRGrabbable grabbable;
    public Transform nextTr;
    private Vector3 s_pos; // 최초 위치
    private Quaternion s_rot; // 최초 각도
    public AudioClip nextBGM;
    private bool isTrigged = false; // 최초 발동 시점 체크를 위함, 배경음악을 바꿔주기 위함

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
