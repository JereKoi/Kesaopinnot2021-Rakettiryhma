using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightLiftScript : MonoBehaviour
{
    [SerializeField]
    Progressbox progressBox;

    public GameObject Hahmo;

    private bool idle = true;
    private bool nosto;
    private bool nosto2;
    private bool nosto3;
    private bool nosto4;
    private bool nosto5;
    private bool nosto6;
    private bool nosto7;
    private bool nosto8;
    private bool nosto9;
    private bool nosto10;
    private bool nosto11;
    private bool nosto12;
    private bool nosto13;
    private bool nosto_aloitus;
    private bool nosto_aloitus2;

    private int clickCounter = 0;

    private Animator anim;

    //XPScript.instance.AddXP(250);
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("nosto", nosto);
        anim.SetBool("nosto2", nosto2);
        anim.SetBool("nosto3", nosto3);
        anim.SetBool("nosto4", nosto4);
        anim.SetBool("nosto5", nosto5);
        anim.SetBool("nosto6", nosto6);
        anim.SetBool("nosto7", nosto7);
        anim.SetBool("nosto8", nosto8);
        anim.SetBool("nosto9", nosto9);
        anim.SetBool("nosto10", nosto10);
        anim.SetBool("nosto11", nosto11);
        anim.SetBool("nosto12", nosto12);
        anim.SetBool("nosto13", nosto13);
        anim.SetBool("idle", idle);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            NostoFunction();
            clickCounter++;
            if (clickCounter >= 11)
            {
                clickCounter = 0;
                idle = true;
            }
            else if (clickCounter <= 0)
            {
                idle = false;
            }
        }
    }

    private void NostoFunction()
    {
        if (clickCounter <= 1)
        {
            idle = false;
            nosto_aloitus = true;
        }
        else if(clickCounter <= 2)
        {
            idle = false;
            nosto_aloitus = false;
            nosto_aloitus2 = true;
        }
        else if(clickCounter <= 6)
        {
            idle = false;
            nosto_aloitus2 = false;
            nosto = true;
        }
        else if(clickCounter <= 8)
        {
            idle = false;
            nosto = false;
            nosto2 = true;
        }
        else if(clickCounter <= 10)
        {
            idle = false;
            nosto2 = false;
            nosto3 = true;
            progressBox.UpdateProgress(0.1f);
        }
    }
}
