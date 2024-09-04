using UnityEngine;

public class FunkyMotion : MonoBehaviour
{
    public float x, y = 0;
    public float f = 1;
    public float a = 5;
    public float t = 0;
    private void FixedUpdate()
    {

        float dt = Time.fixedDeltaTime;
        x += (-Mathf.Sin(t * f) * f * a * dt);
        y += (-Mathf.Cos(t * f) * f * a * dt);
        transform.position = new Vector3(x, y, transform.position.z);  
        t += dt;
        //Debug.Log(dt);
    }
    private void Update()
    {
        //float dt = Time.deltaTime;
        //float dt = Time.fixedDeltaTime;
       // Debug.Log(dt);
    }
}
