using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject player;
    public Slider healthSlider;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = player.GetComponent<PlayerController>().MaxHealth;
        healthSlider.value = player.GetComponent<PlayerController>().CurrentHealth;
    }
}
