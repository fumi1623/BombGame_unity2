using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;      //���΋����擾�p

    // Start is called before the first frame update
    void Start()
    {
        // MainCamera(�������g)��player�Ƃ̑��΋��������߂�
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //// �⊮�X�s�[�h�����߂�
        //float speed = 0.1f;
        //// �^�[�Q�b�g�����̃x�N�g�����擾
        //Vector3 relativePos = player.transform.position - this.transform.position;
        //// �������A��]���ɕϊ�
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //// ���݂̉�]���ƁA�^�[�Q�b�g�����̉�]����⊮����
        //transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

        //�V�����g�����X�t�H�[���̒l��������
        transform.position = player.transform.position + offset;
    }
}
