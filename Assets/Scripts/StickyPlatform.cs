using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //// This script is to make player and platform move together.
    //// 一样还是以碰撞为判断条件,
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.name == "Player")
    //    {
    //        //通过判断碰撞的东西是不是player来判断
    //        // 之后设定platform为parent，这样player就是子，那么会跟着父动
    //        collision.gameObject.transform.SetParent(transform);
    //    }
    //}
    //// player需要离开platform，所以还需要有exit方法，exit方法将会在碰在一起的collider离开时触发
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(null);

    //    }
    //}

    // 用trigger和两个collider使得只有玩家接触板子上面才会跟着走，而碰到侧面是不会被粘着的

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //通过判断碰撞的东西是不是player来判断
            // 之后设定platform为parent，这样player就是子，那么会跟着父动
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
