using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 rotateangles;
    void Update()
    {
        transform.Rotate(rotateangles);
    }
}
