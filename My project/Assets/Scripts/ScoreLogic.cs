using Unity.VisualScripting;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    [SerializeField] private GameLogic gameLogic;
    void OnTriggerEnter(Collider other)
    {
        gameLogic.PlayerScored(this.GameObject().name);
    }
}
