using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    // we use this method to initialate the health and the data
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //we set the gradient at the start
        fill.color = gradient.Evaluate(1f);
    }

    // this method to indicate how much health the bar should show
    public void SetHealth(int health)
    {
        slider.value = health;

        //we use this line to get the update of the gradiant 
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
