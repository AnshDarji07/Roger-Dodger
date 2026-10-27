using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WelcomeInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void WelcomeInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Use the arrow keys OR WASD to move the player");
    }

    void MovePlayer()
    {
        float valueX = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        float valueY = 0;
        float valueZ = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;

        transform.Translate(valueX,valueY,valueZ);
    }
}
