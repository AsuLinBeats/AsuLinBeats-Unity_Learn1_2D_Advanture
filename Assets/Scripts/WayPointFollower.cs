using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // ��ֻ������waypoint������ͬʱΪ���waypoint��׼��,������һ�д������ˣ���unity�༭��ҳ��Ϳ����ֶ�����waypoints��
    [SerializeField] private GameObject[] waypoints; // create array
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        // check distance between position of platform and waypoint
        // �����һ��waypoint��platform�ľ��������ô��������һ��ȥ
        // distanceּ�������������֮��ľ��룬ǰ�����Ҫ��ȡ��һ��waypoints��λ�ã���һ����gameobjectҲ����platform��λ��
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            // ��������Ͽ����ϣ��л�����һ��waypoint���ж��ǲ������һ��
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // ��position����waypoint��λ���ƶ������趨�õ��ٶȣ�delta.timeΪ�˱����������
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
