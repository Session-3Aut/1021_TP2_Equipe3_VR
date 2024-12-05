using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 70f;

    [SerializeField] private Transform partToRotate;
    
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private GameObject impactEffect;

    public void Seek(Transform _target){
        target = _target;
    }
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (rotation.x, rotation.y, 0f);

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
