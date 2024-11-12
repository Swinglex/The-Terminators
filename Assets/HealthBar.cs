using UnityEngine;

public class Health : MonoBehaviour
{
    public SpriteRenderer healthBarRenderer;  
    public float healthAmount = 150f;
    public Sprite[] healthImages; 

    void Update()
    {
        if (healthAmount <= 0){
            //reloads the scene when the player "dies"
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void TakeDamage(float damage){
        //updates the image when the player takes damage
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 150);
        UpdateHealthImage();
    }


    void UpdateHealthImage(){
        //this "index" keeps track of what helth to display from the max value of 150
        int index = Mathf.FloorToInt((1 - (healthAmount / 150f)) * (healthImages.Length - 1));
        healthBarRenderer.sprite = healthImages[index];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == null)
        {
            TakeDamage(10);
        }
    }


}
