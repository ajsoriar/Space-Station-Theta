using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_Trampa : MonoBehaviour {

    public Rigidbody RocaRb;
    public Animator RocaAnim;
    public RocaEstados EstadosDeLaRoca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum RocaEstados
{
    WaitingPlayer, // "esperando a Player"
    Falling, // "cayendo"
    CoolDown, // "espera o recarga"
    Raising // "subiendo
}