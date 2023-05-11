using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralleta : MonoBehaviour
{
    public bool disparando;

    public Rigidbody balaOriginal;

    Coroutine disparoCoro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!disparando)
            {
                disparando = true;
                Empieza_DisparaCoro();
            }
        }
        else
        {
            if (disparando)
            {
                disparando = false;
                Finaliza_DisparaCoro();
            }
        }
    }

    IEnumerator DisparaCoro()
    {
        while (true)
        {
            Rigidbody clon = Instantiate(balaOriginal, transform.position, transform.rotation);
            clon.AddForce(clon.transform.forward * 10f, ForceMode.Impulse);

            Destroy(clon.gameObject, 1f);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void Empieza_DisparaCoro()
    {
        if (disparoCoro == null)
        {
            disparoCoro = StartCoroutine(DisparaCoro());
        }
    }

    void Finaliza_DisparaCoro()
    {
        if (disparoCoro != null)
        {
            StopCoroutine(disparoCoro);
            disparoCoro = null;
        }
    }
}
