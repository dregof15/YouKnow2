using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
}

public class FireCtrl : MonoBehaviour
{

    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }

    public WeaponType currWeapon = WeaponType.RIFLE;
    public GameObject bullet;
    public Transform firePos;
    public ParticleSystem cartridge; // 탄피효과
    public ParticleSystem muzzleFlash; // 총구화염
    public PlayerSfx playerSfx;//총소리

    private bool FireState;
    private bool FireOn;
    public float FireDelay;
    public AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        FireState = true;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DoFire();
    }
    void Fire()
    {
        //FireOn = true;
    }
    void EndFire()
    {
        //FireOn = false;
    }
    void DoFire()
    {
        if (FireState)
        {
            if (MoblieMove.isfire == false)
                return;


            StartCoroutine(FireCycle());
            Instantiate(bullet, firePos.position, firePos.rotation);
            //총알오브젝트 ,총알생성위치 , 총알각도

            //탄피효과
            cartridge.Play();
            //총구화염
            muzzleFlash.Play();
            FireSfx();
        }
    }
    private void FireSfx()
    {
        var _sfx = playerSfx.fire[(int)currWeapon];
        _audio.PlayOneShot(_sfx, 1.0f);
    }
    IEnumerator FireCycle()
    {
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }
}
