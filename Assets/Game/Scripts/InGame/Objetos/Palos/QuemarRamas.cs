using System.Collections;
using UnityEngine;

public class QuemarRamas : MonoBehaviour
{
    private PlayerController _player;
    public GameObject _fireParticles;

    private BoxCollider2D _collider;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _player._playerNum != 1 && !_collider.isTrigger)
        {
            _collider.isTrigger = true;
            GameObject particles = Instantiate(_fireParticles, transform);
            StartCoroutine(DestroySticks(particles.GetComponent<ParticleSystem>()));
        }
    }
    IEnumerator DestroySticks(ParticleSystem fire)
    {
        yield return new WaitUntil(() => fire.particleCount >= 14);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(fire.main.startLifetime.constant);
        Destroy(this.gameObject);
    }
}