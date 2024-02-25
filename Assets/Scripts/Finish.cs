using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] AudioSource finish;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
        finish = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 使用来碰撞的物体的名字来判断自身是否与其相撞
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            finish.Play();
            // 完成之后再次碰撞就没有声音了
            levelCompleted = true;
            // invoke后面跟method name,再跟时间,将在时间后运行method.
            Invoke("CompleteLever", 2f);
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {   
        // change the scene
        // scene 的储存方式为index,不同数字代表不同的scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
