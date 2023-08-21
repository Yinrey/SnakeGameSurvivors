using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;//食物預制體

    //邊界
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn() 
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
