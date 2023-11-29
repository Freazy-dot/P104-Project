using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 2;

    private float rand;
    private float timeSince;
    private float timeSinceDelta;
    private PlayerMovement pm;
    [SerializeField] private float fleeRange = 4;

    private void Start()
    {
        rand = Random.Range(0.5f,1);
        timeSince = Random.Range(1, 5);


        player = GameObject.FindWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();

    }
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < fleeRange) //make enemy flee further
        {
            transform.position -= (player.transform.position - transform.position).normalized * Time.deltaTime * speed;
            
            PlayArea();
            return;
            
        }
        
        
        timeSinceDelta = timeSinceDelta - Time.deltaTime;

        if(timeSinceDelta < 0) 
        {
            transform.position += new Vector3 (1, Mathf.PingPong(Time.time, rand) * Random.Range(-1, 1), 0) * speed * Time.deltaTime;

            if (timeSinceDelta < timeSince*-1) 
            {
                timeSinceDelta = timeSince;
            }
        }
        else
        {
            transform.position += new Vector3(-1, Mathf.PingPong(Time.time, rand) * Random.Range(-1,1), 0) * speed * Time.deltaTime;
        }

        PlayArea();
        

    }

    void PlayArea()
    {
        if (transform.position.x >= pm.xRightBoundary)
        {
            transform.position = new Vector3(pm.xRightBoundary, transform.position.y, 0);
        }
        else if (transform.position.x <= pm.xLeftBoundary)
        {
            transform.position = new Vector3(pm.xLeftBoundary, transform.position.y, 0);
        }
        if (transform.position.y >= pm.yUpBoundary)
        {
            transform.position = new Vector3(transform.position.x, pm.yUpBoundary, 0);
        }
        else if (transform.position.y <= pm.yDownBoundary)
        {
            transform.position = new Vector3(transform.position.x, pm.yDownBoundary, 0);
        }
    }
}
