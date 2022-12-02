using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class velocidade : NetworkBehaviour
{

        public Vector2 velocity;
        public bool local;

        void FixedUpdate()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.Euler(0,0,rb.rotation+180) * velocity;
        }
}
