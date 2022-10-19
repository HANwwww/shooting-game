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

        //如果有方向輸入
        if (dir.magnitude > 0.1f)
        {
            //用座標取得角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //讓角色旋轉到指定角度
            
            //transform.rotation = Quaternion.Euler(0, faceAngle, 0);

            //使角色「漸漸」旋轉到指定角度
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.01f);
        }

       
            //推動rigibody來移動
        cc.Move(dir * Time.deltaTime * 10);
    }
}
