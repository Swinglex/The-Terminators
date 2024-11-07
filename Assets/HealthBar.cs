using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer healthBarRenderer;  
    public float healthAmount = 150f;
    public Sprite[] healthImages; 

    void Update()
    {
        if (healthAmount <= 0){
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            TakeDamage(10);
        }

    }

    public void TakeDamage(float damage){
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 150);
        UpdateHealthImage();
    }


    void UpdateHealthImage(){
        //this "index" keeps track of what helth to display from the max value of 150
        int index = Mathf.FloorToInt((1 - (healthAmount / 150f)) * (healthImages.Length - 1));
        healthBarRenderer.sprite = healthImages[index];
    }
}
