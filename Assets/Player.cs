using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;

    Rigidbody2D rigid;

    bool fR = true; // fR = Facing Right 
         
    bool iG; // Is Grounded 

    public Transform gC; // Ground Check 

    public LayerMask wIG; // What Is Ground 

    public float cR;

    public float jumpF;
             
    bool iTF;

    public Transform FR;

    bool wS;

    public float wSS;

    bool WJ;

    public float xWF;

    public float yWF;

    public float wJT;


    Animator a;


    // Start is called before the first frame update
    void Start()
    {

        a = GetComponent<Animator>(); 
        rigid = GetComponent<Rigidbody2D>(); 
       
    }

    // Update is called once per frame
    void Update()
    {

        float input = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(input * Speed, rigid.velocity.y);



        if (input > 0 && fR == false)

        {
            Flip();
        }

        else if (input < 0 && fR == true)

        {
            Flip();
        }


        if (input!=0)

        {

            a.SetBool("iR", true);  

        }

       else
        {
            a.SetBool("iR", false );

        }
        iG = Physics2D.OverlapCircle(gC.position, cR, wIG);


        if (Input.GetKeyDown(KeyCode.UpArrow) && iG == true)

        {



            rigid.velocity = Vector2.up * jumpF;

        }





        iTF = Physics2D.OverlapCircle(FR.position, cR, wIG);
         
        if(iG==true)



        {

            a.SetBool("iJ", false);  

        }

        else
        {




            a.SetBool("iJ", true);  

        }


        if (iTF == true && iG == false && input != 0)

        {
            wS = true;

        }

        else
        {
            wS = false;
        }

        if (wS)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, Mathf.Clamp(rigid.velocity.y, -wSS, float.MaxValue));


        }




        if (Input.GetKeyDown(KeyCode.UpArrow) && wS == true)

        {

            WJ = true;

            Invoke("sWJTF", wJT);

        }

        if (WJ)

        {

            rigid.velocity = new Vector2(xWF * -input, yWF);

        }





    }


        void Flip()

        {

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            fR = !fR;
        }

        void sWJTF()

        {
            WJ = false;
        }
    

   }
