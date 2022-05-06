﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x,y;

    public Rigidbody rb;
    public float fuerzaDeSalto= 8f;
    public bool puedoSaltar;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 10f;

    // Start is called before the first frame update
    void Start()
    {
      puedoSaltar = false;
      anim = GetComponent<Animator>();  
    }

    void FixedUpdate(){
      if(!estoyAtacando)
      {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);

      }
      if(avanzoSolo)
      {
        rb.velocity=transform.forward * impulsoDeGolpe;
      }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");     

        if(Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
          anim.SetTrigger("golpeo");
          estoyAtacando = true;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(puedoSaltar)
        {
          if(!estoyAtacando)
          {
            if(Input.GetKeyDown(KeyCode.Space))
            {
              anim.SetBool("salte", true);
              rb.AddForce(new Vector3(0,fuerzaDeSalto,0), ForceMode.Impulse);
            }
          }
          anim.SetBool("tocoSuelo", true); 
        }
        else
        {
          EstoyCayendo();
        } 
    }

    public void EstoyCayendo()
    {
      anim.SetBool("tocoSuelo", false);
      anim.SetBool("salte", false); 
    }
    
    public void DejeDeGolpear()
    {
      estoyAtacando = false;
      avanzoSolo = false;
    } 

    public void AnanzoSolo()
    {
      avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
      avanzoSolo = false;
    }
}

