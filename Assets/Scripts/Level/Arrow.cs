using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float x, y,z;
    private float speed = 5;
    private void Start()
    {
        if (x != 0 && y != 0)
        {
            if (x >= 0)
                z = y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI;
            else
                z = -y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI + 180;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, z);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Untagged" )
        {
            if(collision.tag == "Enemy")
            {
                if (collision.TryGetComponent<Enemy_Info>(out var _enemyInfo))
                {
                    _enemyInfo.TakeDamage(PlayerInfo.archer.damage);
                    if (_enemyInfo.lives <= 0)
                    {
                        _enemyInfo.Drop();
                        Destroy(collision.gameObject);

                    }
                }
                
            }
            
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    public void add_cord(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    void Update()
    {
        Vector3 dir5 = new Vector3(this.gameObject.transform.position.x+x, this.gameObject.transform.position.y+y, this.gameObject.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, dir5, speed * Time.deltaTime);
    }
}
