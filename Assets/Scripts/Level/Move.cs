using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject controller;
    private bool active, click,start;
    private float i, k, x, y,x1,y1;
    public GameObject coll;
    public Image im;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Awake()
    {
        active = true;
        controller.SetActive(false);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
       start = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        start = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(0)&& start)
        {
            
            Vector3 dir4 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
            controller.active = true;
            if (active)
            {
                i = Input.mousePosition.x;
                k = Input.mousePosition.y;
                controller.transform.position = new Vector3(i, k, -10);
                active = false;
                controller.SetActive(true);
                if (Player.animator)
                    Player.animator.SetBool("isRun", true);
            }
            else
                click = false;
            if (active == false)
            {
                
                if (((Mathf.Pow(Input.mousePosition.x - i, 2) + Mathf.Pow(Input.mousePosition.y - k, 2)) <= 15625))
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir4, 1111111 * Time.deltaTime);
                else
                {
                    x = Input.mousePosition.x - i;
                    y = Input.mousePosition.y - k;
                    x = 125 * x / Mathf.Sqrt(x * x + y * y);
                    if (Input.mousePosition.y > k)
                        y = Mathf.Sqrt(15625 - x * x);
                    else
                        y = -Mathf.Sqrt(15625 - x * x);
                    Vector3 dir5 = new Vector3(x + i, y + k, -10);
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir5, 1111111 * Time.deltaTime);
                }

                x = Input.mousePosition.x - i;
                y = Input.mousePosition.y - k;
                if (x != 0 && y != 0)
                {
                    if (Input.mousePosition.x >= i)
                        x1 = y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI;
                    else
                        x1 = -y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI + 180;
                    coll.transform.rotation = Quaternion.Euler(0, 0, x1);

                    if (Input.mousePosition.x >= i)
                    {
                        x1 = x / Mathf.Sqrt(x * x + y * y);
                        y1 = y / Mathf.Sqrt(x * x + y * y);

                    }
                    else
                    {
                        x1 = x / Mathf.Sqrt(x * x + y * y);
                        y1 = y / Mathf.Sqrt(x * x + y * y);

                    }
                }
                if (Input.mousePosition.x - i < 0)
                    Player.square.GetComponent<SpriteRenderer>().flipX = true;
                else if (Input.mousePosition.x - i > 0)
                    Player.square.GetComponent<SpriteRenderer>().flipX = false;
                Player.agent.destination = new Vector3(Player.instance.gameObject.transform.position.x + x1, Player.instance.gameObject.transform.position.y + y1);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            controller.SetActive(false);
            click = true;
            active = true;
            if (Player.animator)
                Player.animator.SetBool("isRun", false);
            Player.agent.destination = new Vector3(Player.instance.gameObject.transform.position.x, Player.instance.gameObject.transform.position.y);
        }
    }
}
