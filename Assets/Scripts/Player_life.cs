using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Life : MonoBehaviour
{
    // �����Ϊ��������ʱͬ����animator����������ӵģ��Ǹ�script��˽�����ԣ��������ļ��Ĳ���ͻ
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
    // oncollisionenter2d is active ������collider����ʱ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ʹ��tags��traps������objective�ֿ�
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
    }
    private void Die()
    {
        // ����death trigger,Ҳ���ǰ�animator��״̬���ó�death������animator�ڲ�����ı���
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
