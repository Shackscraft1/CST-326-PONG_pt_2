using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class BallLogic : MonoBehaviour
{
    [SerializeField] private float StartingSpeed = 8f;
    private float speed;
    
    [SerializeField] private AudioClip slowHitSound;
    [SerializeField] private AudioClip regularHitSound;
    [SerializeField] private AudioClip fastHitSound;

    private Vector3 directiom;
    private Vector3 currentDir;
    private Rigidbody rb;
    
    AudioSource audioSource;  
    

    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 8.48f, -4.42f);    
        Launch();
    }
    
    void Update()
    {
        currentDir = rb.linearVelocity;
    }
    
    void Launch()
    {
        float yDir = Random.value < 0.5f ? -1f : 1f;
        float zDir = Random.Range(-0.5f, 0.5f);

        Vector3 dir = new Vector3(2f, yDir, zDir).normalized;
        rb.linearVelocity = dir * StartingSpeed;
        speed = StartingSpeed;
    }
    
    
    public void Launch(string playerWhoScored, bool checkIfWin)
    {
        speed = StartingSpeed;
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (checkIfWin)
        {
            Destroy(gameObject);
            return;
        }
        
        if (playerWhoScored.Equals("Player1Goal"))
        {
            float yDir = -1f;
            float zDir = Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(0f, 8.48f, -4.42f);
            Vector3 dir = new Vector3(2f, yDir, zDir);
            rb.linearVelocity = dir * StartingSpeed;
        }else if (playerWhoScored.Equals("Player2Goal"))
        {
            float yDir = 1f;
            float zDir = Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(0f, 8.48f, -4.42f);
            Vector3 dir = new Vector3(2f, yDir, zDir);
            rb.linearVelocity = dir * StartingSpeed;
        }
        
        
        
    }

    public void ChangeSpeed(float speed)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * Math.Abs(this.speed + speed);
    }

    public void ChangeSize(float size)
    {
        transform.localScale = new Vector3(1.5f, 1f * size, 1f * size);
    }
    void OnCollisionEnter(Collision collision)
    {
        speed = currentDir.magnitude;
        if (collision.collider.TryGetComponent<PaddleMarker>(out _))
        {
            if (speed > 15f)
            {
                audioSource.PlayOneShot(fastHitSound);
            }else if (speed < 15f && speed > 5)
            {
                audioSource.PlayOneShot(regularHitSound);
            }
            else
            {
                audioSource.PlayOneShot(slowHitSound);
            }
            speed += 3f;
            
        }
        var direction = Vector3.Reflect(currentDir.normalized, collision.contacts[0].normal);
        
        rb.linearVelocity = direction * speed;
       
        


       
        
    }
}   
