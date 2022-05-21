using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    //Обєкт для кошика
    public GameObject basketPrefab;
    //Кількість рівні життя
    public int numBasket = 3;
    //Позиція по Y відносно якої потрібно будувати нові слої
    public float basketButtomY = -14f;
    //відстання між слоями кошика
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketButtomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tApple in tAppleArray) 
            Destroy(tApple);
        //видаляємо одну корзину
        //Отримуємо індекс елемента, який потрібно видалить
        int basketIndex = basketList.Count - 1;
        //Отримуємо обєект, який потрібно видалить
        GameObject tBasketGO = basketList[basketIndex];
        //Видаляємо елемент із списку
        basketList.RemoveAt(basketIndex);
        //Видаляємо сам обєкт із гри
        Destroy(tBasketGO);
        if (basketList.Count==0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

}
