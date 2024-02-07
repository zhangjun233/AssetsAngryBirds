using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isMouseDown = false; //记录小鸟发射时,鼠标是否按下

    public enum BirdState //设置小鸟状态
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

    //按下
    private void OnMouseDown()
    {
        if (this.state == BirdState.Shooting)
        {
            print("鼠标按下");
            isMouseDown = true;
        } 
    }
 
    private void OnMouseUp()
    {
        if (this.state == BirdState.Shooting)
        {
            isMouseDown = false;
            print("弹起");
            //this.state = BirdState.AfterShooting;
        }
    }

    //获取鼠标移动,控制小鸟
    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
 
    }

    //获取鼠标的投影到摄像头的世界位置
    private Vector3 GetMousePosition()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        return mp;
    }
}
