using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour {

    public float FlyingSpeed;
    public float LifeTime;
    public GameObject explosion;
    public AudioSource bulletAudio;


    public void InitAndShoot(Vector3 Direction)
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = Direction * FlyingSpeed * 0.1f;
        Invoke("KillYourself", LifeTime);

    }
    public void KillYourself()
    {
        GameObject.Destroy(this.gameObject);
    }
    public float damageValue = 15;
    void OnTriggerEnter(Collider other)
    {
        
        other.transform.GetChild(0).GetChild(0).SendMessage("Hit", damageValue);
        explosion.gameObject.transform.parent = null;
        explosion.gameObject.SetActive(true);
        bulletAudio.pitch = Random.Range(0.8f, 1);



        KillYourself();
    }
}
