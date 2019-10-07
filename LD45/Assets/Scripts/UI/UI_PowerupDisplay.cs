using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerupDisplay : MonoBehaviour
{
    [SerializeField] bool spritesAvailable = false;

    [SerializeField] Image powerupDisplayImg;

    public Sprite[] PowerupSprites = new Sprite[5];

    void PowerupChanged(Powerups current)
    {
        if (spritesAvailable == false)
        {
            Debug.Log("NO POWERUP SPRITES ASSIGNED!");
            return;
        }

        powerupDisplayImg.sprite = PowerupSprites[(int)current];
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PowerupController>().UpdatePowerupInfo += PowerupChanged;
    }
}
