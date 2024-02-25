using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // private:valid only in this script
    // rb����Ϊһ��rigidbody���͵�variable
    private Rigidbody2D rb;
    // ��������code������֮ǰ��code���ӵ�rigidbody����
    private Animator anim;
    private SpriteRenderer go;
    private float dirx = 0f;
    private BoxCollider2D coll;
    // [SerializeField]���Խ�����ı���ֱ����ӵ�unity��component���script component���棩��������unity����ֱ�ӽ�����ֵ�޸ģ�ʹ��С�շ�����ʱ��unity���æ�Զ��ӿո�
    // �ڲ�variableֵ�ı仯���ⲿ�������֣���Ҫ������right click��reset������������ʾ��ֵ
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround; // ͨ��layer����ȷ������collider��terrian ground�Ƿ��ص���ֻ���ص���Ҳ������أ�ʱ�ſ�����Ծ������Ĵ������ʾ��compomnent�У�ѡ���ĸ�layer��c#�ͼ�����ĸ�collider����
    // ������������ʹ����ֵ��ȷ��ʱ���˶�״̬��ö�١�
    private enum MovementState { idle, running, jumping, falling};
    // ����ʱ����Ϊint value����0��ʼ����ô���idle���� int 0

    [SerializeField] private AudioSource jumpSoundEffect; //����audioresouce��reference.
    // ��ôŪ���running�����ַ����Ͳ��������ˣ���animator��ɾ����
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hihi");
        // rb��ȡ��gameobject��rigibodyģ��
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        go = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // getaxisraw���������ͷŰ���ʱ�����ɸУ�raw�ṩ��ʹ��Ӧ�������κ�ƽ�����ֵ
        dirx = Input.GetAxisRaw("Horizontal"); // ��ˮƽ��������룬�䷵��һ��-1-1�ĸ���������A����-1����D����+1���൱�ڼ����˰���ʶ��
 // ��һ�������input��getaxisֵ����֪�����������������ң��������ı�
 // ���õ���ֵ�Ŵ󲢸���rb���Ҫע�����y����
        rb.velocity = new Vector2(dirx * moveSpeed,rb.velocity.y); //keep original y value
        // ���벻��ֱ�ۣ����ܴ����֪�������7f������ý������ϸ������
        
        
        //     if (dirx > 0)
    //    {
    //        rb.velocity = new Vector2(dirx * 7f);
    //    }
       if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //we need to change rigidbody for jumping
            // use getcomponent<name>() to access component 
// ͬ����Ծֻ�仯y��x�ǲ���ģ�����xֵ���������ﶼ��float
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpSoundEffect.Play();
        }

        // ��animation���л��������Ѿ�֪��dirx=0ʱ�Ǿ�ֹ��
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        MovementState state;
        // ѡ��
        // ����running����jump�����ȼ���ͬ
        if (dirx > 0f)
        {
            // �趨given bool 
            // �����animator�趨����أ����Ǹղ������ˣ���running=trueʱ������player����,������������˵������if�Ĳ�ͬ����ʱ����animator���running����ͬ��bool
            //anim.SetBool("running", true);

            // ���º󣬸ı�enum��ֵ�Ϳ��������
            state = MovementState.running;
            go.flipX = false;
        }
        else if (dirx < 0f)
        {

            // anim.SetBool("running", true);
            // �ı䳯�򣬵øı�sprite renderer��flip
            state = MovementState.running;
            go.flipX = true;

        }
        else
        {
            //  anim.SetBool("running", false);
            state = MovementState.idle;
        }
        // y�������ʴ���0�������ʱ�������ϣ���ô����jump�Ķ���
        // ����˵����velocity��ʹ�Ǿ�ֹҲ����0������һ���Ƚ�С������
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        // ������if�¶����state���µ�animator����,��stateֵ����animator�����state�Ķ���
        
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        // ����һ����boxcollidor��ȫһ�µĺ���
        // ǰ������centre��size����new collider���������С�� 0fָ������ת����������ָ���ǽ��½����ĺ������·���һ���,Ȼ��������������������Ƿ��ص�
        // ���᷵��T/F�������Ƿ�Ӵ����棩
        // ������ִ����Ծʱ���ͻ���и������ж�
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);    

    }
}
