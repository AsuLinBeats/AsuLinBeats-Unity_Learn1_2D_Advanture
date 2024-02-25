using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0; // count cherries collected
    // things happen when we collide with cherry
    [SerializeField] private AudioSource collect;
    // ����Ҫreference��ʱ�򣬾�Ҫcreate serializefirld����
    [SerializeField] private Text applesText;
    private void OnTriggerEnter2D(Collider2D collision) // ����colider���͵ı���
    {
        // ����collider�����gameobj �Ƚ�tag�Ƿ�Ϊcherry��gameobject�ڱ�script������ָ�ľ���cherry
       if (collision.gameObject.CompareTag("Apple"))
        {
            collect.Play();
            Destroy(collision.gameObject); // �����ˣ���ɾȥcherry������Ե���
            apples = apples + 1;
            Debug.Log("Apples :" + apples);
            applesText.text = "Apples:" + apples;
        }
    }
}
