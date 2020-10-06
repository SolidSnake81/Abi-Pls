using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public Transform[] pP;

    public float s; 

    int cPI;

    float wT; 

    public float sWT;

    Animator aa; 

    // Start is called before the first frame update
    void Start()
    {

        transform.position = pP[0].position;

         wT = sWT;


        aa = GetComponent<Animator>();


    }

    // Update is called once per frame
     private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, pP[cPI].position, s * Time.deltaTime ); 

        if (transform.position==pP[cPI].position)

        {




            aa.SetBool("isR", false); 

            if(wT<=0)

            {
                if (cPI + 1 < pP.Length)

                {
                    cPI++;
                }
                else
                {
                    cPI = 0;
                }

                wT = sWT; 

            }


             else


            {

                wT -= Time.deltaTime;


                aa.SetBool("isR", true); 
            }
            
        }
    }
}
