using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightLiftScript : MonoBehaviour
{
    [SerializeField]
    Progressbox progressBox;

    public GameObject Hahmo;
    public AdsManager ads;
    public GameObject text;

    private bool idle = true;
    private bool nosto0;
    private bool nosto1;
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
    private float inputTimer;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        inputTimer = 0;
        
        ads.ShowBanner();
    }

    private void Update()
    {
        inputTimer += Time.deltaTime;
        CheckInput();
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("idle", idle);
        anim.SetBool("nosto0", nosto0);
        anim.SetBool("nosto1", nosto1);
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
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            inputTimer = 0;
            NostoFunction();
            clickCounter++;
            if (clickCounter >= 18)
            {
                clickCounter = 0;
                progressBox.UpdateProgress(0.1f);
                StaminaIndicator.instance.UseStamina(10);
                nosto13 = false;
                idle = true;
            }
            
        }
        if (StaminaIndicator.instance.currentStamina < 10)
        {
            idle = true;
            text.SetActive(true);
        }
        if (StaminaIndicator.instance.currentStamina > 10)
        {
            text.SetActive(false);
        }

        if (inputTimer >= 0.2f)
        {
            inputTimer = 0;
            if (clickCounter <= 0)
            {
                idle = true;
                nosto0 = false;
            }
            else if (clickCounter <= 2)
            {
                idle = false;
                nosto0 = true;
                nosto1 = false;
                clickCounter--;
            }
            else if (clickCounter <= 3)
            {
                idle = false;
                nosto0 = false;
                nosto1 = true;
                nosto2 = false;
                clickCounter--;
            }
            else if (clickCounter <= 4)
            {
                idle = false;
                nosto1 = false;
                nosto2 = true;
                nosto3 = false;
                clickCounter--;
            }
            else if (clickCounter <= 5)
            {
                idle = false;
                nosto2 = false;
                nosto3 = true;
                nosto4 = false;
                clickCounter--;
            }
            else if (clickCounter <= 6)
            {
                idle = false;
                nosto3 = false;
                nosto4 = true;
                nosto5 = false;
                clickCounter--;
            }
            else if (clickCounter <= 7)
            {
                idle = false;
                nosto4 = false;
                nosto5 = true;
                nosto6 = false;
                clickCounter--;
            }
            else if (clickCounter <= 8)
            {
                idle = false;
                nosto5 = false;
                nosto6 = true;
                nosto7 = false;
                clickCounter--;
            }
            else if (clickCounter <= 9)
            {
                idle = false;
                nosto6 = false;
                nosto7 = true;
                nosto8 = false;
                clickCounter--;
            }
            else if (clickCounter <= 10)
            {
                idle = false;
                nosto7 = false;
                nosto8 = true;
                nosto9 = false;
                clickCounter--;
            }
            else if (clickCounter <= 11)
            {
                idle = false;
                nosto8 = false;
                nosto9 = true;
                nosto10 = false;
                clickCounter--;
            }
            else if (clickCounter <= 12)
            {
                idle = false;
                nosto9 = false;
                nosto10 = true;
                nosto11 = false;
                clickCounter--;
            }
            else if (clickCounter <= 13)
            {
                idle = false;
                nosto10 = false;
                nosto11 = true;
                nosto12 = false;
                clickCounter--;
            }
            else if (clickCounter <= 14)
            {
                idle = false;
                nosto11 = false;
                nosto12 = true;
                nosto13 = false;
                clickCounter--;
            }
        }
    }
    private void NostoFunction()
    {
        if (clickCounter <= 1)
        {
            idle = false;
            nosto0 = true;
        }
        else if(clickCounter <= 2)
        {
            idle = false;
            nosto0 = false;
            nosto1 = true;
        }
        else if(clickCounter <= 3)
        {
            idle = false;
            nosto0 = false;
            nosto1 = false;
            nosto2 = true;
        }
        else if(clickCounter <= 4)
        {
            idle = false;
            nosto1 = false;
            nosto2 = false;
            nosto3 = true;
        }
        else if(clickCounter <= 5)
        {
            idle = false;
            nosto2 = false;
            nosto3 = false;
            nosto4 = true;
        }
        else if (clickCounter <= 6)
        {
            idle = false;
            nosto3 = false;
            nosto4 = false;
            nosto5 = true;
        }
        else if (clickCounter <= 7)
        {
            idle = false;
            nosto4 = false;
            nosto5 = false;
            nosto6 = true;
        }
        else if (clickCounter <= 8)
        {
            idle = false;
            nosto5 = false;
            nosto6 = false;
            nosto7 = true;
        }
        else if (clickCounter <= 9)
        {
            idle = false;
            nosto6 = false;
            nosto7 = false;
            nosto8 = true;
        }
        else if (clickCounter <= 10)
        {
            idle = false;
            nosto7 = false;
            nosto8 = false;
            nosto9 = true;
        }
        else if (clickCounter <= 11)
        {
            idle = false;
            nosto8 = false;
            nosto9 = false;
            nosto10 = true;
        }
        else if (clickCounter <= 12)
        {
            idle = false;
            nosto9 = false;
            nosto10 = false;
            nosto11 = true;
        }
        else if (clickCounter <= 13)
        {
            idle = false;
            nosto10 = false;
            nosto11 = false;
            nosto12 = true;
        }
        else if (clickCounter <= 14)
        {
            idle = false;
            nosto11 = false;
            nosto12 = false;
            nosto13 = true;
        }
    }
}
