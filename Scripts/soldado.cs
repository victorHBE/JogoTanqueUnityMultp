using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class soldado : NetworkBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Vertical",Input.GetAxis("Vertical"));

        if(!isLocalPlayer)
        return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, -h * 180 * Time.deltaTime);
        transform.Translate(0, v * 4 * Time.deltaTime,0);
    }
}
