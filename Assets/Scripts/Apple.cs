using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float buttomY = -20; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < buttomY)
        {
            Destroy(gameObject);
            //Отримуємо силку на компонент ApplePicker головної камери Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Викликаємо метод для очистки усіх яблук
            apScript.AppleDestroyed();

        }
    }
}
