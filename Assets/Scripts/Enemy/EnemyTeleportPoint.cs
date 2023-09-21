using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTeleportPoint : MonoBehaviour
{
    public GameObject playerRef;
    Transform playerPos;
    public GameObject tpPoint;
    public GameObject pointHolder;

    Vector3 originPoint;

    public float tpPointRadius;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        playerPos = playerRef.transform;
        pointHolder = transform.Find("Point_Holder").gameObject;
        tpPoint = transform.Find("Teleport_Point").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(playerPos.position.x, this.transform.position.y, playerPos.position.z);

        dist = Vector3.Distance(playerRef.transform.position, gameObject.transform.position);
        tpPoint.transform.LookAt(targetPosition);
        pointHolder.transform.LookAt(targetPosition);

        FollowPlayer();
    }

    public void FollowPlayer()
    {

    }

    private void OnDrawGizmos()
    {
        
    }
}
