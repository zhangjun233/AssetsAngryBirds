using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isMouseDown = false; //��¼С����ʱ,����Ƿ���

    public enum BirdState //����С��״̬
    {
        Waiting,
        Shooting,
        AfterShooting
    }
    public BirdState state = BirdState.Waiting;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.Shooting:
                MoveControl();
                break;
            case BirdState.AfterShooting:
                break;
            default:
                break;
        }

    }

    //����
    private void OnMouseDown()
    {
        if (this.state == BirdState.Shooting)
        {
            print("��갴��");
            isMouseDown = true;
        } 
    }
 
    private void OnMouseUp()
    {
        if (this.state == BirdState.Shooting)
        {
            isMouseDown = false;
            print("����");
            //this.state = BirdState.AfterShooting;
        }
    }

    //��ȡ����ƶ�,����С��
    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
 
    }

    //��ȡ����ͶӰ������ͷ������λ��
    private Vector3 GetMousePosition()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        return mp;
    }
}
