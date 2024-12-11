using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 70f;

    [SerializeField] private Transform partToRotate;
    
    [SerializeField] private float turnSpeed = 10f;

    [SerializeField] private InfosJoueur infosJoueur;
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

        DropPoints();

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        Destroy(target.gameObject);
        Destroy(gameObject, 1f);
    }

    public void DropPoints()
    {
        
        float randomValue = Random.Range(0f, 100f);
        int pointsToAdd = 0;

  
        if (randomValue < 50f) 
        {
            pointsToAdd = Random.Range(2, 6); 
        }
        else if (randomValue < 85f) 
        {
            pointsToAdd = Random.Range(8, 12); 
        }
        else if (randomValue < 95f)
        {
            pointsToAdd = Random.Range(15, 24); 
        }
        else if (randomValue < 99f) 
        {
            pointsToAdd = Random.Range(30, 31); 
        }
        else 
        {
            pointsToAdd = 45; 
        }

        infosJoueur.nbPoints += pointsToAdd;

        Debug.Log($"Dropped Points: {pointsToAdd}. Total Points: {infosJoueur.nbPoints}");
    }

}
