using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // 不只是俩个waypoint，我们同时为多个waypoint做准备,下面这一行创建好了，在unity编辑器页面就可以手动增加waypoints了
    [SerializeField] private GameObject[] waypoints; // create array
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        // check distance between position of platform and waypoint
        // 如果这一个waypoint与platform的距离近，那么换到另外一边去
        // distance旨在输出两个东西之间的距离，前半个是要获取第一个waypoints的位置，后一个是gameobject也就是platform的位置
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            // 距离基本上快贴上，切换到另一个waypoint并判断是不是最后一个
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // 将position向着waypoint的位置移动，以设定好的速度，delta.time为了避免出现问题
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
