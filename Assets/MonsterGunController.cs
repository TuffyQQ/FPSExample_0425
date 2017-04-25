using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MonsterGunController : MonoBehaviour {

    public float MMinimumShootPeriod;
    public float MmuzzleShowPeriod;
    private float MshootCounter = 0;
    private float MmuzzleCounter = 0;
    public GameObject muzzleFlash;
    public GameObject bulletCandidate;
    public GameObject troll;

    public void Start()
    {

    }
    public void MonsterTryToTriggerGun()
    {
        if (MshootCounter <= 0)
        {


            this.transform.DOShakeRotation(MMinimumShootPeriod * 0.8f, 3f);
            MmuzzleCounter = MmuzzleShowPeriod;
            muzzleFlash.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
            MshootCounter = MMinimumShootPeriod;

            GameObject newBullet = GameObject.Instantiate(bulletCandidate);
            MonsterBulletController bullet = newBullet.GetComponent<MonsterBulletController>();

            //要改定位子彈的方式

            bullet.transform.position = troll.transform.position;
            bullet.transform.rotation = troll.transform.rotation;
            bullet.InitAndShoot(troll.transform.forward);
        }
    }
    public void Update()
    {
        if (MshootCounter > 0)
        {
            MshootCounter -= Time.deltaTime;
        }
        if (MmuzzleCounter > 0)
        {
            muzzleFlash.gameObject.SetActive(true);
            MmuzzleCounter -= Time.deltaTime;
        }
        else
        {
            muzzleFlash.gameObject.SetActive(false);
        }
    }
}
