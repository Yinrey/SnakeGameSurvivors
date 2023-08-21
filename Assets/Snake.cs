using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System;
using UnityEditor.Timeline.Actions;
using UnityEngine.PlayerLoop;

public class Snake : MonoBehaviour
{
    private Vector2 dir;
    [SerializeField]
    private GameObject bodyPrefab;
    private enum movingDirection//移動方向
    {
        dirRight,
        dirDown,
        dirLeft,
        dirUp
    }
    private movingDirection moveDirectionState = movingDirection.dirRight;//初始化移動方向，先向右
    private GameObject foodPrefab;
    [SerializeField]
    private List<GameObject> snakeBody = new List<GameObject>();//蛇的身體存放
    [SerializeField]
    private List<Transform> snakeBodyTranform = new List<Transform>();//蛇的身體位置存放
    private bool ateFood = false;

    void Start()
    {
        //執行MOVE，每0.1秒一次
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    void Update()
    {
        //設定移動方向的狀態
        switch (moveDirectionState)
        {
            //右
            case movingDirection.dirRight:
            break;
            //下
            case movingDirection.dirDown:
            break;
            //左
            case movingDirection.dirLeft:
            break;
            //上
            case movingDirection.dirUp:
            break;
        }
        
        //切換移動方向的狀態
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (moveDirectionState != movingDirection.dirLeft)
            {
                dir = Vector2.right;
                moveDirectionState = movingDirection.dirRight;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (moveDirectionState != movingDirection.dirUp)
            {
                dir = Vector2.down;
                moveDirectionState = movingDirection.dirDown;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (moveDirectionState != movingDirection.dirRight)
            {
                dir = Vector2.left;
                moveDirectionState = movingDirection.dirLeft;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (moveDirectionState != movingDirection.dirDown)
            {
                dir = Vector2.up;
                moveDirectionState = movingDirection.dirUp;
            }
        }

        //吃到食物後增加體節
        if (ateFood == true)
        {
            ateFood = false;
            GameObject newBody = Instantiate(bodyPrefab);
            snakeBody.Add(newBody);
        }
        
    }

    void Move() 
    {
        //由最後面的體節開始往前面體節的位置移動
        for (int i = snakeBody.Count - 1; i > 0; i --)
        {
            snakeBody[i].transform.position = snakeBody[i - 1].transform.position;
        }
        //往dir方向移動
        transform.Translate(dir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //吃到食物並消除
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            ateFood = true;
        }
        else
        {
            //碰到其他東西遊戲結束
            //GameOver();
        }
    }
}
