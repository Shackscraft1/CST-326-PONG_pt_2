using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class PaddleLogic : MonoBehaviour
{
    [SerializeField] private Transform walls;
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    
    [SerializeField] private float paddleSpeed;
    
    
   
    public void Awake()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        float left = GetLeftWallPosition();
        float right = GetRightWallPosition();


        float minZ = Mathf.Min(left, right);
        float maxZ = Mathf.Max(left, right);

        // Player 1
        float p1Move = 0f;
        if (Keyboard.current.aKey.isPressed) p1Move += 1f;
        if (Keyboard.current.dKey.isPressed) p1Move -= 1f;

        if (p1Move != 0f)
        {
            Vector3 pos = player1.position;
            pos.z += p1Move * paddleSpeed * Time.deltaTime;
            pos.z = Mathf.Clamp(pos.z, minZ + paddleSpeed/4, maxZ - paddleSpeed/4);
            player1.position = pos;
        }

        // Player 2
        float p2Move = 0f;
        if (Keyboard.current.jKey.isPressed) p2Move += 1f;
        if (Keyboard.current.lKey.isPressed) p2Move -= 1f;

        if (p2Move != 0f)
        {
            Vector3 pos = player2.position;
            pos.z += p2Move * paddleSpeed * Time.deltaTime;
            pos.z = Mathf.Clamp(pos.z, minZ + paddleSpeed/4, maxZ - paddleSpeed/4);
            player2.position = pos;
        }
    }
    

    private float GetLeftWallPosition()  => walls.GetChild(0).position.z;
    private float GetRightWallPosition() => walls.GetChild(1).position.z;
}
