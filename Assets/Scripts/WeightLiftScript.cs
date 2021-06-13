﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightLiftScript : MonoBehaviour
{
    public GameObject Hahmo;

    private bool idle = true;
    private bool nosto;
    private bool nosto2;
    private bool nosto3;
    private bool nosto_aloitus;
    private bool nosto_aloitus2;

    private int clickCounter = 0;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        UpdateAnimations();

        if (clickCounter == 16)
        {

        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("nosto", nosto);
        anim.SetBool("nosto2", nosto2);
        anim.SetBool("nosto3", nosto3);
        anim.SetBool("nosto_aloitus", nosto_aloitus);
        anim.SetBool("nosto_aloitus2", nosto_aloitus2);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            NostoFunction();
            clickCounter++;
            Debug.Log("aikoo nostaa painoja");
            //kato miten require certain amount of clicks to perform action unity
            //Miten animaatioon saa startin ja endin
        }
    }

    private void NostoFunction()
    {
        if (clickCounter <= 1)
        {
            idle = false;
            nosto_aloitus = true;
            Debug.Log("on function sisällä");
        }
        else if(clickCounter <= 2)
        {
            idle = false;
            nosto_aloitus = false;
            nosto_aloitus2 = true;
            Debug.Log("on function sisällä1");
        }
        else if(clickCounter <= 3)
        {
            idle = false;
            nosto_aloitus2 = false;
            nosto = true;
            Debug.Log("on function sisällä2");
        }
        else if(clickCounter <= 4)
        {
            idle = false;
            nosto = false;
            nosto2 = true;
            Debug.Log("on function sisällä3");
        }
        else if(clickCounter <= 5)
        {
            nosto = false;
            idle = false;
            nosto2 = false;
            nosto3 = true;
            Debug.Log("on function sisällä4");
        }
    }

    private void Nosto_aloitusFunction()
    {

    }

    private void Nosto_aloitus2Function()
    {

    }
}
