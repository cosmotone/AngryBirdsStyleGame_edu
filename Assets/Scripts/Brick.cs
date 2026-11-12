using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private AudioResource woodHitSound;

    [SerializeField]
    private AudioSource brickAudioSource;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        float damage = col.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude * 10;
        //don't play audio for small damages
        if (damage >= 10)
            brickAudioSource.resource = woodHitSound;
            brickAudioSource.Play();
        //decrease health according to magnitude of the object that hit us
        Health -= damage;
        //if health is 0, destroy the block
        if (Health <= 0) Destroy(this.gameObject);
    }

    public float Health = 70f;


    //wood sound found in 
    //https://www.freesound.org/people/Srehpog/sounds/31623/
}
