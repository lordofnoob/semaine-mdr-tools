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
    public bool isEnemy;
    public float life;
    public Mb_LifeManager currentLife;
    

    private void Awake()
    {
        if (isEnemy == true)
        {
            gameObject.layer = 8;
        }
        else
            gameObject.layer = 9;

        currentLife.currentLife = life;
        startPos = transform.position;
        placeToGo = startPos +paternOfMoving.patern[currentIndex+1];
    }

    private void Update()
    {
        transform.position -= new Vector3(0,0,Sc_GameOptions.sc_GameOptions.gameSpeed* Time.deltaTime);
        transform.position += Vector3.Normalize( placeToGo - startPos) * speed*Time.deltaTime;
        distanceTraveled += Vector3.Magnitude(placeToGo - startPos) * speed * Time.deltaTime;
        if (Vector3.Distance(startPos, transform.position) >= Vector3.Distance(startPos, placeToGo))
        { 
            GoToNextPoint();
        }
        
    }

    public void GoToNextPoint()
    {

        currentIndex += 1;
        distanceTraveled = 0;
        if (paternOfMoving.patern.Length <= currentIndex)
            currentIndex = 0;
        startPos = transform.position;
        if (isEnemy==true)
            placeToGo = (startPos + paternOfMoving.patern[currentIndex])*-1;
        else
            placeToGo =startPos + paternOfMoving.patern[currentIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        Mb_LifeManager touched = collision.gameObject.GetComponent<Mb_LifeManager>();
        touched.currentLife -= damages;
        CheckDeath(touched);
        Mb_PoolManager.PoolManager.DecallItem(this.GetComponent<Mb_Poolable>());
    }
  
    public void CheckDeath(Mb_LifeManager otherLife)
    {
        if (otherLife.currentLife <= 0)
        {
            Mb_PoolManager.PoolManager.CallItem(Mb_Poolable.poolableTag.Fx, otherLife.transform.position, otherLife.transform.rotation.y);
            Mb_PoolManager.PoolManager.DecallItem(otherLife.gameObject.GetComponent<Mb_Poolable>());
        }
    }
}