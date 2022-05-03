using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] Transform target;
    public GameObject gm;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //agent.updatePosition = false;
        //agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(target.position);
        agent.destination = target.position;
        //gm.transform.position = agent.transform.position;
        //gameObject.transform.position = agent.transform.position;
        //this.transform.position = agent.transform.position;
        //this.transform.rotation=new Quaternion(0,0,0,0);
    }
}
