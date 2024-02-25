using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // private:valid only in this script
    // rb定义为一个rigidbody类型的variable
    private Rigidbody2D rb;
    // 将动画与code串联与之前把code连接到rigidbody类似
    private Animator anim;
    private SpriteRenderer go;
    private float dirx = 0f;
    private BoxCollider2D coll;
    // [SerializeField]可以将后面的变量直接添加到unity的component里（在script component下面），可以在unity里面直接进行数值修改，使用小驼峰命名时，unity会帮忙自动加空格
    // 内部variable值的变化在外部不会体现，需要在外面right click，reset来更新外面显示的值
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround; // 通过layer，来确定人物collider与terrian ground是否重叠，只有重叠（也就是落地）时才可以跳跃，这里的代码会显示在compomnent中，选择哪个layer，c#就检测会和哪个collider相碰
    // 定义新类型来使用数值明确此时的运动状态，枚举。
    private enum MovementState { idle, running, jumping, falling};
    // 调用时，其为int value，从0开始，那么这里，idle就是 int 0

    [SerializeField] private AudioSource jumpSoundEffect; //接受audioresouce的reference.
    // 这么弄完后，running的那种方法就不会再用了，在animator中删掉。
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hihi");
        // rb读取该gameobject的rigibody模块
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        go = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // getaxisraw可以消除释放按键时的滞纳感，raw提供即使响应，不含任何平滑与插值
        dirx = Input.GetAxisRaw("Horizontal"); // 从水平轴检索输入，其返回一个-1-1的浮点数，按A就是-1，按D就是+1，相当于集合了按键识别
 // 下一步，检查input。getaxis值就能知道到底是向左还是向右，并作出改变
 // 将得到的值放大并赋到rb里，需要注意的是y不变
        rb.velocity = new Vector2(dirx * moveSpeed,rb.velocity.y); //keep original y value
        // 代码不够直观，不能从入口知道这里的7f，必须得进入代码细看才行
        
        
        //     if (dirx > 0)
    //    {
    //        rb.velocity = new Vector2(dirx * 7f);
    //    }
       if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //we need to change rigidbody for jumping
            // use getcomponent<name>() to access component 
// 同理，跳跃只变化y，x是不变的，保留x值，另外这里都是float
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpSoundEffect.Play();
        }

        // 与animation的切换：我们已经知道dirx=0时是静止的
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        MovementState state;
        // 选择
        // 先跑running，再jump，优先级不同
        if (dirx > 0f)
        {
            // 设定given bool 
            // 这个与animator设定的相关，我们刚才设置了，当running=true时，代表player再跑,那这个代码就是说，满足if的不同条件时，给animator里的running传不同的bool
            //anim.SetBool("running", true);

            // 更新后，改变enum的值就可完成任务。
            state = MovementState.running;
            go.flipX = false;
        }
        else if (dirx < 0f)
        {

            // anim.SetBool("running", true);
            // 改变朝向，得改变sprite renderer的flip
            state = MovementState.running;
            go.flipX = true;

        }
        else
        {
            //  anim.SetBool("running", false);
            state = MovementState.idle;
        }
        // y方向速率大于0，代表此时正在向上，那么就是jump的动作
        // ？他说这里velocity即使是静止也不是0，得用一个比较小的数字
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        // 把上面if新定义的state更新到animator里面,把state值赋给animator里面叫state的东西
        
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        // 创造一个与boxcollidor完全一致的盒子
        // 前两个，centre和size都是new collider的中心与大小， 0f指的是旋转，后面两者指的是将新建立的盒子向下方移一点儿,然后检查这个盒子与地面盒子是否重叠
        // 最后会返回T/F（盒子是否接触地面）
        // 当我们执行跳跃时，就会进行该条件判断
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);    

    }
}
