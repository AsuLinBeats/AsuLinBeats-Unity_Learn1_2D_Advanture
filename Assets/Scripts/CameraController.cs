using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    
    


    // Update is called once per frame
    void Update()
    {
        // �����reference��ͨ����קplayer��vector��script��player����ʵ�ֵģ���˲���Ҫgetcomponent
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z-10f);
    }
}