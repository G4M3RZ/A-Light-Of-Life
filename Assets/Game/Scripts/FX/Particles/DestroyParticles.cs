using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
        Destroy(this.gameObject, _particles.main.startLifetime.constant);
    }
}