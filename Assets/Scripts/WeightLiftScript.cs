using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightLiftScript : MonoBehaviour
{
    private bool idle;
    private bool nosto;
    private bool nosto_aloitus;
    private bool nosto_aloitus2;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("nosto", nosto);
        anim.SetBool("nosto_aloitus", nosto_aloitus);
        anim.SetBool("nosto_aloitus2", nosto_aloitus2);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Nosto"))
        {
            NostoFunction();
            Debug.Log("aikoo nostaa painoja");
            //kato miten require certain amount of clicks to perform action unity
        }
    }

    private void NostoFunction()
    {
        if (idle == false && nosto == true && nosto_aloitus == false && nosto_aloitus2 == false)
        {

        }
        else
        {

        }
    }

    private void Nosto_aloitusFunction()
    {

    }

    private void Nosto_aloitus2Function()
    {

    }
}
