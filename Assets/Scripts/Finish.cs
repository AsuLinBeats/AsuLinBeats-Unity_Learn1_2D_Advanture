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
        // ʹ������ײ��������������ж������Ƿ�������ײ
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            finish.Play();
            // ���֮���ٴ���ײ��û��������
            levelCompleted = true;
            // invoke�����method name,�ٸ�ʱ��,����ʱ�������method.
            Invoke("CompleteLever", 2f);
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {   
        // change the scene
        // scene �Ĵ��淽ʽΪindex,��ͬ���ִ���ͬ��scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
