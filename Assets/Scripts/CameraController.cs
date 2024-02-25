using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    
    


    // Update is called once per frame
    void Update()
    {
        // 这里的reference是通过拖拽player的vector到script的player部分实现的，因此不需要getcomponent
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z-10f);
    }
}
