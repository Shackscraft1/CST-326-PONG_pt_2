using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUpLogic : MonoBehaviour
{
    [SerializeField] private BallLogic ballLogic;
    [SerializeField] private TextMeshProUGUI PowerUpCurrentText;
    private enum PowerUpType
    {
        Grow,
        Shrink,
        Fast,
        Slow,
        None
    }

    private void Start()
    {
        PowerUpCurrentText.text = "Power up: None";
        SpawnPowerUp();
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);
    }

    private Array values = Enum.GetValues(typeof(PowerUpType));
    private static PowerUpType powerUpTypeCurrentState = PowerUpType.None;

    private void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        PowerUpType powerUpType = (PowerUpType)random.Next(values.Length);

        switch (powerUpType)
        {
            case PowerUpType.Grow:
                SpawnPowerUp();
                PowerUpCurrentText.text = "Power up: Grow";
                if (powerUpTypeCurrentState.Equals(PowerUpType.Grow)) break;
                ballLogic.ChangeSize(3.5f);
                powerUpTypeCurrentState = PowerUpType.Grow;
                
                break;
            case PowerUpType.Shrink:
                SpawnPowerUp();
                PowerUpCurrentText.text = "Power up: Shrink";
                if (powerUpTypeCurrentState.Equals(PowerUpType.Shrink)) break;
                powerUpTypeCurrentState = PowerUpType.Shrink;
                ballLogic.ChangeSize(.3f);
                break;
            case PowerUpType.Fast:
                SpawnPowerUp();
                PowerUpCurrentText.text = "Power up: Fast";
                if (powerUpTypeCurrentState.Equals(PowerUpType.Fast)) break;
                powerUpTypeCurrentState = PowerUpType.Fast;
                ballLogic.ChangeSpeed(4f);
                break;
            case PowerUpType.Slow:
                SpawnPowerUp();
                PowerUpCurrentText.text = "Power up: Slow";
                if (powerUpTypeCurrentState.Equals(PowerUpType.Slow)) break;
                powerUpTypeCurrentState = PowerUpType.Slow;
                Debug.Log("Slow");
                ballLogic.ChangeSpeed(-10f);
                break;
            case PowerUpType.None:
                SpawnPowerUp();
                PowerUpCurrentText.text = "Power up: None";
                break;
        }
        {
            
        }
    }

    void SpawnPowerUp()
    {
        
        var dirY = Random.Range(-1f, 19.5f);
        var dirZ = Random.Range(-15.6f, 8.9f);
        transform.position = new Vector3(0f,dirY,dirZ);
        
    }

    public void ResetPowerUpStatus()
    {
        powerUpTypeCurrentState = PowerUpType.None;
        PowerUpCurrentText.text = "Power up: None";
    }
}
