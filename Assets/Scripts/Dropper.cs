using UnityEngine;

public class Dropper : MonoBehaviour
{
    public int timer = 3;
    public Rigidbody rb;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            rb.useGravity = true;
        }
    }
}
