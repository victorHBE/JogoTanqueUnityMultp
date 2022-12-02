using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bala : NetworkBehaviour
{
   public GameObject prefabBala;
   public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector3 pos = this.transform.position;
            Instantiate(prefabBala, pos,
            Quaternion.Euler(0,0,-90+player.transform.localEulerAngles.z));
        }
    }

}
