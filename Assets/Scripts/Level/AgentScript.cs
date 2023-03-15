using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] public Transform target;
    public Vector3 start_position,target_position;
    public GameObject gm;
    public GameObject sprite;
    [SerializeField] private NavMeshAgent agent;
    public float distance;
    public bool active=false;
    public bool In_area = false;
    public Animator animator;

    void Start()
    {
        start_position = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        target_position = start_position;
    }
    public void Set_active(Transform new_target)
    {
        target = new_target;
        active = true;
    }

    void Update()
    {
        if(active)
        {
            target_position = target.position;
        }
        if (target_position.x<this.transform.position.x)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            sprite.GetComponent<SpriteRenderer>().flipX = false;
        }



        distance= Vector3.Distance(transform.position, start_position);
        if(distance>6)
        {
            active = false;
            target_position = start_position;
        }


        if(target_position != start_position)
        {
            agent.stoppingDistance = 2;
            Vector3 targetDir = target.position - transform.position;
            if (target.position.y < this.transform.position.y)
            {
                gm.transform.rotation = Quaternion.Euler(0, 0, -Vector3.SignedAngle(targetDir, Vector3.right, Vector3.right));
            }
            else
            {
                gm.transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(targetDir, Vector3.right, Vector3.right));
            }
            if (Vector3.Distance(transform.position, target_position) > agent.stoppingDistance &&animator)
            {
                animator.SetBool("isRun", true);
            }
            else
                animator.SetBool("isRun", false);
        }
        else
        {
            agent.stoppingDistance = 0;
            gameObject.GetComponent<Enemy_Info>().lives = gameObject.GetComponent<Enemy_Info>().max_lives;
            gameObject.GetComponent<Enemy_Info>().ShowHP();
        }
        
        agent.destination = target_position;
    }
}
