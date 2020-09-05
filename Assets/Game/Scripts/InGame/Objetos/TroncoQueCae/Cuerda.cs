using System.Collections;
using UnityEngine;

public class Cuerda : MonoBehaviour {

    private PlayerController _player;

    public Rigidbody2D _objectAtatch;
    public GameObject _fireParticles;
    private ParticleSystem _fire;
    public PuzzleSolved _puerta;

	void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _objectAtatch.bodyType = RigidbodyType2D.Static;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && _player._playerNum != 1 && !_puerta._puzzleSolved)
        {
            _puerta._puzzleSolved = true;
            GameObject particles = Instantiate(_fireParticles, transform) as GameObject;
            _fire = particles.GetComponent<ParticleSystem>();
            StartCoroutine(DestroyRope(_fire));
        }
    }
    IEnumerator DestroyRope(ParticleSystem fire)
    {
        yield return new WaitUntil(() => fire.particleCount >= 15);
        _objectAtatch.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(fire.main.startLifetime.constant);
        Destroy(this.gameObject);
    }
}