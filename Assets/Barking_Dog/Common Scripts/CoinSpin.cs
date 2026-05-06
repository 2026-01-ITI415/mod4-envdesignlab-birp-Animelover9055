using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 180f;

    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}