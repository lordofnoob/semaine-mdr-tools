using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_MovingItem : MonoBehaviour
{
    [HideInInspector] public bool used=false;
    public Sc_PatternWay movingProps;
    public float speed;
    public float damages;

    private Vector3 placeToGo;
    private int currentIndex=0;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPos;
    private float distanceTraveled;

    private void Awake()
    {
        startPos = transform.position;
        placeToGo = startPos+movingProps.patern[currentIndex];
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
        if (movingProps.patern.Length <= currentIndex)
            currentIndex = 0;
        startPos = transform.position;
        placeToGo = transform.position+ movingProps.patern[currentIndex];
       
    }
}