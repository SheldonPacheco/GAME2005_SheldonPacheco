using UnityEngine;

public class AccessStraw : MonoBehaviour 
{
    public bool local = false;
    private void Update()
    {
        Vector3 right = local ? transform.right : Vector3.right;
        Vector3 up = local ? transform.up : Vector3.up;
        Vector3 forward = local ? transform.forward : Vector3.forward;

        Debug.DrawLine(transform.position, transform.position + right * 6.0f, Color.red);
        Debug.DrawLine(transform.position, transform.position + up * 6.0f, Color.green);
        Debug.DrawLine(transform.position, transform.position + forward * 6.0f, Color.blue);

        //world and self
        //transform.Translate(Vector3.forward, Space.Self)
        //transform.Translate(Vector3.forward, Space.World)
    }
}
