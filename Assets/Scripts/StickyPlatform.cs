using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //// This script is to make player and platform move together.
    //// һ����������ײΪ�ж�����,
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.name == "Player")
    //    {
    //        //ͨ���ж���ײ�Ķ����ǲ���player���ж�
    //        // ֮���趨platformΪparent������player�����ӣ���ô����Ÿ���
    //        collision.gameObject.transform.SetParent(transform);
    //    }
    //}
    //// player��Ҫ�뿪platform�����Ի���Ҫ��exit������exit��������������һ���collider�뿪ʱ����
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(null);

    //    }
    //}

    // ��trigger������colliderʹ��ֻ����ҽӴ���������Ż�����ߣ������������ǲ��ᱻճ�ŵ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //ͨ���ж���ײ�Ķ����ǲ���player���ж�
            // ֮���趨platformΪparent������player�����ӣ���ô����Ÿ���
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);

        }
    }
}
