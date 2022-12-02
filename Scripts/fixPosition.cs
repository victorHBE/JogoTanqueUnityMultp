using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPosition : MonoBehaviour
{
        
    void LateUpdate()
    {
        transform.position = 
        transform.parent.position + new Vector3 (0,1,0);
        transform.rotation = Quaternion.identity;
    }
}
