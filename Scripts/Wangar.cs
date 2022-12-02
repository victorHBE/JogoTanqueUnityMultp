using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static System.Math;

public class Wangar : NetworkBehaviour
{
    private const int CIRCLE_DISTANCE = 6;
    private const int CIRCLE_RADIUS = 8;
    private const int ANGLE_CHANGE = 1;

    public float maxSpeed;
    public float rotationSpeed;

    public Vector3 circleCenter;
    public Vector3 displacement;

    public Rigidbody2D prefabBala;

    public float wanderAngle;

    Vector3 velocity;
    void Start()
    {
        this.velocity = new Vector3 (-1,0,-2);
        this.displacement = new Vector3();
    }

    
    void Update()
    {
        circleCenter = velocity;
        circleCenter = circleCenter.normalized * CIRCLE_DISTANCE;

        displacement = new Vector3(0,0,-1);
        displacement = displacement.normalized * CIRCLE_RADIUS;
        displacement = setAngle(displacement, wanderAngle);

        wanderAngle += Random.Range(0,5) * ANGLE_CHANGE - ANGLE_CHANGE * 0.5f;

        int randomFire = Random.Range(0,100);

        if(randomFire%2 == 0){
            CmdFire();
        }

        Vector3 wanderForce = circleCenter + displacement;

        transform.Rotate(0,0, Random.Range(-1,1) * rotationSpeed * 2);

        velocity = wanderForce * maxSpeed * Time.deltaTime;
        this.transform.position += velocity;
    }

    Vector3 setAngle(Vector3 vector, float value){
        float magnitude = vector.magnitude;
        vector.x = Mathf.Cos (value) * magnitude;
        vector.z = Mathf.Sin (value) * magnitude;

        return vector;

    }

    [Command]
    void CmdFire() {
        Vector3 pos = transform.position + transform.up;
        
        Rigidbody2D bala = (Rigidbody2D)Instantiate(prefabBala,pos, transform.rotation);
        bala.velocity = transform.up*6;
        NetworkServer.Spawn(bala.gameObject);
        Destroy(bala.gameObject, 1f);
    }

}
