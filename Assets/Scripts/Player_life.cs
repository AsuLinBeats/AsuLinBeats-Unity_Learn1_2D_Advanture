using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Life : MonoBehaviour
{
    // 这个是为了在死亡时同步对animator作出调整添加的，是该script的私有属性，与其他文件的不冲突
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource death;
    [SerializeField] private AudioSource restart;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // oncollisionenter2d is active 当两个collider相碰时
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 使用tags把traps与其他objective分开
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
    }
    private void Die()
    {
        // 运行death trigger,也就是把animator的状态设置成death，触发animator内部定义的变量
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        death.Play();

    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restart.Play();
    }
}
