using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 70f;

    [SerializeField] private Transform partToRotate;
    
    [SerializeField] private float turnSpeed = 10f;

    [SerializeField] private InfosJoueur infosJoueur;

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
        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    public void DropPoints()
    {
        
        float randomValue = Random.Range(0f, 100f);
        int pointsToAdd = 0;

  
        if (randomValue < 50f) 
        {
            pointsToAdd = Random.Range(1, 3); 
        }
        else if (randomValue < 85f) 
        {
            pointsToAdd = Random.Range(5, 7); 
        }
        else if (randomValue < 95f)
        {
            pointsToAdd = Random.Range(12, 14); 
        }
        else if (randomValue < 99f) 
        {
            pointsToAdd = Random.Range(20, 21); 
        }
        else 
        {
            pointsToAdd = 35; 
        }

        infosJoueur.nbPoints += pointsToAdd;

        Debug.Log($"Dropped Points: {pointsToAdd}. Total Points: {infosJoueur.nbPoints}");
    }
}
