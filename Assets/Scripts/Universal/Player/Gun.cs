using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioCycle))]
public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float fireRate;
    public Camera fpsCam;
    public Animator anim;
    public GameObject bulletHit;
    public GameObject enemyHit;
    public GameObject paperHit;
    public TrailRenderer bulletTrail;
    public GameObject bulletSpawn;
    private AudioCycle audioCycle;
    private float volume;
    public float maxVol = .5f;
    public float minVol = .1f;

    enum Difficulty { Easy, Normal, Hard }
    private Difficulty difficulty;

    private bool _paused;
    private bool burst = false;

    private List<Coroutine> fireCorutines = new();

    private void OnEnable()
    {
        GameEvents.OnDificultyChanged += OnDificultyChanged;
        GameEvents.OnPauseGame += OnPauseGame;
    }

    private void OnDisable()
    {
        GameEvents.OnDificultyChanged -= OnDificultyChanged;
        GameEvents.OnPauseGame += OnPauseGame;
    }

    private void OnPauseGame(bool paused)
    {
        _paused = paused;
    }

    private void OnDificultyChanged()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            if (PlayerPrefs.GetInt("Difficulty") == 0)
            {
                difficulty = Difficulty.Easy;
            }
            else if (PlayerPrefs.GetInt("Difficulty") == 1)
            {
                difficulty = Difficulty.Normal;
            }
            else if (PlayerPrefs.GetInt("Difficulty") == 2)
            {
                difficulty = Difficulty.Hard;
            }
        }
    }

    public void Start()
    {
        fireRate *= .1f;
        audioCycle = GetComponent<AudioCycle>();

        if (PlayerPrefs.HasKey("Difficulty"))
        {
            if (PlayerPrefs.GetInt("Difficulty") == 0)
            {
                difficulty = Difficulty.Easy;
            }
            else if (PlayerPrefs.GetInt("Difficulty") == 1)
            {
                difficulty = Difficulty.Normal;
            }
            else if (PlayerPrefs.GetInt("Difficulty") == 2)
            {
                difficulty = Difficulty.Hard;
            }
        }
    }
    public void Update()
    {
        if (!_paused)
        {
            if (difficulty == Difficulty.Easy)
            {
                //checks for mouse1 and nextTimeToFire
                if (Input.GetButtonDown("Fire1"))
                {
                    fireCorutines.Add(StartCoroutine(fireEasy()));
                }

                if (Input.GetButtonUp("Fire1"))
                {
                    foreach (Coroutine fire in fireCorutines)
                    {
                        StopCoroutine(fire);
                    }
                    fireCorutines.Clear();
                }
            }
            else if(difficulty == Difficulty.Normal)
            {
                //checks for mouse1 and nextTimeToFire
                if (Input.GetButtonDown("Fire1") && !burst)
                {
                    fireCorutines.Add(StartCoroutine(fireNormal()));
                    burst = true;
                }

                if (Input.GetButtonUp("Fire1"))
                {
                    fireCorutines.Clear();
                }
            }
            else if(difficulty == Difficulty.Hard)
            {
                //checks for mouse1 and nextTimeToFire
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("Shoot");
                    Shoot();
                }
            }
        }
        volume += .2f * Time.deltaTime;
        volume = Mathf.Clamp(volume, minVol, maxVol);
        audioCycle.SetVolume(volume);
    }

    private IEnumerator fireEasy()
    {
        while (true)
        {
            anim.SetTrigger("Shoot");
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
    private IEnumerator fireNormal()
    {
        for (int i = 0; i < 3; i++)
        {
            anim.SetTrigger("Shoot");
            Shoot();
            yield return new WaitForSeconds(.1f);
        }
        burst = false;
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            volume += -.05f;
            volume = Mathf.Clamp(volume, minVol, maxVol);
            audioCycle.SetVolume(volume);
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawn.transform.position, Quaternion.identity);
            GameEvents.OnUniversalplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.UniversalClipTags.Gunfire);
            StartCoroutine(SpawnTrail(trail, hit));
        }
    }
    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startposition = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startposition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        trail.transform.position = hit.point;
        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                //damage enemy Event
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject); //This passes though a damage AND the object that GET'S HIT
                Instantiate(enemyHit, hit.point, bulletSpawn.transform.rotation);

                WeakPoints target = hit.transform.GetComponent<WeakPoints>();
                if (target != null)
                {
                    GameEvents.DamageEnemy?.Invoke(damage, hit.transform.parent.gameObject);
                    target.Shot();
                }
            }
            else if (hit.transform.CompareTag("Paper"))
            {
                Instantiate(paperHit, hit.point, bulletSpawn.transform.rotation);
            }
            else if (hit.transform.CompareTag("Nose"))
            {
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject);
            }
            else if (hit.transform.CompareTag("Player"))
            {
            }
            else
            {
                Instantiate(bulletHit, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
        Destroy(trail.gameObject, trail.time);
    }
}