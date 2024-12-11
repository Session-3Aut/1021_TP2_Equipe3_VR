using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attribute")]

    [SerializeField] private float range = 15f;
    [SerializeField] private float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Field")]
    [SerializeField] private string enemyTag = "Enemy";

    [SerializeField] private Transform partToRotate;

    [SerializeField] private float turnSpeed = 10f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private AudioClip[] soundClips; 

    [SerializeField] private float lowerVolume = 0.08f;
    private AudioSource audioSource;  

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = lowerVolume;
         audioSource.spatialBlend = 1f;
         audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 2f;
        audioSource.maxDistance = 7f;
    }


    void UpdateTarget(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }

    }

    void Update()
    {
        if(target == null){
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if(fireCountDown <= 0f){
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot(){
        GameObject bulletGO =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        PlayRandomSoundClip();
        if(bullet != null){
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    void PlayRandomSoundClip()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);

            audioSource.PlayOneShot(soundClips[randomIndex]);
        }
    }
}
