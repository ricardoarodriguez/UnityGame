using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivos : MonoBehaviour
{
    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMision;

    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obten las esferas Rojas Restantes : "+numDeObjetivos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Obten las esferas Rojas Restantes: "+numDeObjetivos; 
            if(numDeObjetivos <= 0 )
            {
                textoMision.text = "Completaste la Mision";
                botonDeMision.SetActive(true);
            }
        }
    }
}
