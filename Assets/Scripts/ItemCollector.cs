using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0; // count cherries collected
    // things happen when we collide with cherry
    [SerializeField] private AudioSource collect;
    // 当需要reference的时候，就要create serializefirld变量
    [SerializeField] private Text applesText;
    private void OnTriggerEnter2D(Collider2D collision) // 定义colider类型的变量
    {
        // 调用collider里面的gameobj 比较tag是否为cherry，gameobject在本script代码内指的就是cherry
       if (collision.gameObject.CompareTag("Apple"))
        {
            collect.Play();
            Destroy(collision.gameObject); // 碰到了，就删去cherry，代表吃到了
            apples = apples + 1;
            Debug.Log("Apples :" + apples);
            applesText.text = "Apples:" + apples;
        }
    }
}
