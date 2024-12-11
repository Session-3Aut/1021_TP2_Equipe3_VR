using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
   [SerializeField] private GameObject[] _prefabs;
    
    [SerializeField] private Vector3 _zoneSize;

    [SerializeField] private float _timer;

    private int _randomPrefabs;

    float _randomTimer;

    float _randomTimeX;

     [SerializeField]private float currentTime;
     [SerializeField]private float delay = 1.5f;

    void Start()
    {
        _randomTimer = Random.Range(1,3);

        _randomTimeX = Random.Range(2,4);

    }

    // Update is called once per frame
    void Update()
    {
        _randomPrefabs = Random.Range(0, 3);
        currentTime += Time.deltaTime;
        _timer += Time.deltaTime;

        if(currentTime > 59f){
            delay =.9f;
        }
        else if(currentTime > 89f){
            delay = 0.2f;
        }
        if(_timer > delay){
            SpawnCube();
            _timer = 0;
        }
    }
    void SpawnCube(){
        //GameObject instantiated = Instantiate(_prefabs);
         GameObject instantiated = Instantiate(_prefabs[_randomPrefabs]);

            instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - _zoneSize.x / 2, transform.position.x + _zoneSize.x / 2 ),
                Random.Range(transform.position.y - _zoneSize.y / 2, transform.position.y + _zoneSize.y / 2 ),
                Random.Range(transform.position.z - _zoneSize.z / 2, transform.position.z + _zoneSize.z / 2 )
            );

            //instantiated.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _zoneSize);
}
}
