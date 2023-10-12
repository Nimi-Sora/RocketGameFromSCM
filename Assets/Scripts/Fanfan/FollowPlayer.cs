using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    int mapGrade = 3;
    int nowGrade = 0;
    int mapHeight = 200;
    int defaultHeight = 200;

    Transform transform;
    Transform player;

    void Start()
    {
        transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)//Input.GetKeyDown(KeyCode.M)
        {
            nowGrade++;
            nowGrade %= mapGrade;
            mapHeight = defaultHeight * (nowGrade+1);
        }
        transform.position = new Vector3(player.position.x, mapHeight, player.position.z);

    }
}
