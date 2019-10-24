using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_MovingItem : MonoBehaviour
{
    [HideInInspector] public bool used=false;
    public Sc_PatternWay paternOfMoving;
    public float speed;
    public float damages;
    private Vector3 placeToGo;
    private int currentIndex=0;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPos;
    private float distanceTraveled;

    private void Awake()
    {
        if (transform.rotation.y==0)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 360, 0));
        }
        startPos = transform.position;
        placeToGo = Quaternion.AngleAxis(transform.rotation.y, Vector3.up) *(startPos +paternOfMoving.patern[currentIndex]);
        Debug.Log(placeToGo);
    }

    private void Update()
    {
        transform.position += Vector3.Normalize(placeToGo- startPos) * speed*Time.deltaTime;
        distanceTraveled = Vector3.Distance(startPos, transform.position);
        if (distanceTraveled > Vector3.Distance(startPos, placeToGo))
        { 
            GoToNextPoint();
        }
    }

    public void GoToNextPoint()
    {
        currentIndex += 1;
        if (paternOfMoving.patern.Length <= currentIndex)
            currentIndex = 0;
 
        startPos = transform.position;
        Debug.Log(currentIndex);
        placeToGo = Quaternion.AngleAxis(transform.rotation.y, Vector3.up) * (startPos + paternOfMoving.patern[currentIndex]);

    }
}