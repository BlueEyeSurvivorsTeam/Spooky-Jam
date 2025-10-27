using UnityEngine;
using System.Collections;

public class AmbientSoundPlayer : MonoBehaviour
{
    [Header("Sonidos ambientales")]
    public AudioClip[] ambientSounds;  // Arreglo de sonidos

    [Header("Configuración de tiempo")]
    public float minDelay = 5f;  // Tiempo mínimo entre sonidos
    public float maxDelay = 15f; // Tiempo máximo entre sonidos

    void Start()
    {
        StartCoroutine(PlayAmbientSounds());
    }

    IEnumerator PlayAmbientSounds()
    {
        while (true)
        {
            // Espera un tiempo aleatorio antes del siguiente sonido
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            // Reproduce un sonido aleatorio
            if (ambientSounds.Length > 0)
            {
                AudioClip clip = ambientSounds[Random.Range(0, ambientSounds.Length)];
                AudioManager.Instance.PlayMusicOneShot(clip);
            }
        }
    }
}
