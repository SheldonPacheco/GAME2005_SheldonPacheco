using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bounce : MonoBehaviour
{
    float vel = 0.0f; 
    float acc = Physics.gravity.y;
    public float pos = 5.0f;    
    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        vel += acc * dt;
        pos += vel * dt;

        if (pos <= 0.0f)
        {
            vel = -vel;
            pos = 0.0f; 
        } 
        transform.position = new Vector3(0.0f, pos, 0.0f);
    }
}
