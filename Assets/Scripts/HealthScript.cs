using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int hp = 1;
    public bool isEnemy = true;
    public int killScore = 10;
    void Awake()
    {   
        //Dead = Resources.Load("plane") as GameObject;
    }
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            ShowScore.score += killScore;
            Destroy(gameObject);
            
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.tag == "Player")
        {
            ShakeCamera.isshakeCamera = true;
            Destroy(otherCollider.gameObject);

            ShowScore.gameOver = true;

            if (gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }


        }
        DamageHP shot = otherCollider.gameObject.GetComponent<DamageHP>();
        if (shot != null)
        {

            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                Destroy(shot.gameObject); // Remember to always target the gameObject, otherwise you will just remove the script
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShakeCamera.isshakeCamera = true; 
            Destroy(other.gameObject);
            ShowScore.gameOver = true;



            //Time.timeScale = 0; //Pause
        }
        if (other.gameObject.tag == "Cancle")
        {
            other.gameObject.GetComponent<RadiationController>().speed = 1.2f;
            other.gameObject.GetComponent<RadiationController>().direction = new Vector2(-1, 0);
        }
    }

}