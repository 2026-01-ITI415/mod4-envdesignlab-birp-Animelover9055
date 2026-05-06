using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position
            );

            CoinManager.instance.AddCoin();

            Destroy(gameObject);
        }
    }
}