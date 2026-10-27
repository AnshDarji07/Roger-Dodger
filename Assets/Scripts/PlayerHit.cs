using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerHit : MonoBehaviour
{
    private int hitCount = 0;
    private Rigidbody rb;
    private Move moveScript;
    private float starttime;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveScript = GetComponent<Move>();
        starttime = Time.time;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Land"))
        {
            return;
        }

        Debug.Log("Player Collided with " + collision.gameObject.name + "!!");
        hitCount += 1;
        Debug.Log("Player hit " + hitCount + " times !!");
        
        float score = 100 - (Time.time - starttime) - (hitCount * 10);
        if(collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Player hit the finish line!!");
            Debug.Log("Player hit " + hitCount + " times !!");
            
            if(score <= 0)
            {
                Debug.Log("Player score is 0!!");
            }
            else
            {
                Debug.Log("Player score is " + score + "!!");
            }
        }
        /*
        Transform transform = collision.gameObject.GetComponent<Transform>();
        transform.localScale = new Vector3(1,1,1);
        */
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            changeColor(collision.gameObject, Color.red);
            //Gameover();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            changeColor(collision.gameObject, Color.black);
        }

        if(collision.gameObject.CompareTag("Walls"))
        {
            changeColor(collision.gameObject, Color.yellow);
        }
    }

    private void changeColor(GameObject obj, Color color)
    {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        material.color = color;
    }

    private bool Gameover()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        moveScript.enabled = false;
        return true;
    }
}
