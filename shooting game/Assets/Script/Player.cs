using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        //�p�G����V��J
        if (dir.magnitude > 0.1f)
        {
            //�ήy�Ш��o����
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //������������w����
            
            //transform.rotation = Quaternion.Euler(0, faceAngle, 0);

            //�Ϩ���u�����v�������w����
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.01f);
        }

       
            //����rigibody�Ӳ���
        cc.Move(dir * Time.deltaTime * 10);
    }
}
