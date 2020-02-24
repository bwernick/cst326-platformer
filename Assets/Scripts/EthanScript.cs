using UnityEngine;
using System.Collections;

public class EthanScript : MonoBehaviour
{
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run");
    public float panSpeed = 20f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float speed = 5f;
        anim.SetFloat("horizontal", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash)
        {
            anim.SetTrigger(jumpHash);
        } 

        Vector3 pos = transform.position;

        if(anim.GetFloat("jump") == 1f)
        {
            anim.SetFloat("jump", 0.5f);
            pos.y -= speed * Time.deltaTime;
        }
        
        /*
        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        */
        if (Input.GetKey(KeyCode.Space))
        {
            pos.y += speed * Time.deltaTime;
            anim.SetFloat("jump", 1);
        }
        if (Input.GetKey("d"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;
    }
}
