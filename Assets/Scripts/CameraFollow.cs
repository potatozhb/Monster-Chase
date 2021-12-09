using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, MaxX;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Selected index is " + GameManagement.instance.Index);

        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        
        minX = -123;
        MaxX = 164;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        if (player == null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > MaxX)
            tempPos.x = MaxX;

        transform.position = tempPos;
    }
}
