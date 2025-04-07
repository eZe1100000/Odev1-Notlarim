using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour

{

    public float speed = 0.0f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector3 charPos;
    [SerializeField] private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();//caching 
        animator = GetComponent<Animator>();
        charPos = transform.position;
    }

   /* private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, 0);
    }*/


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            Debug.Log("1.f speed");
        }
        else
        {
            speed = 0.0f;
        }

        animator.SetFloat("speedUnity" , speed);
        charPos = new Vector3(charPos.x + speed*Time.deltaTime , charPos.y);
        transform.position = charPos;
        
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(charPos.x , charPos.y , charPos.z -1.0f);
        
    }
}
