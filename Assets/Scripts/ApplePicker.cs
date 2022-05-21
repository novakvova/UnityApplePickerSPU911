using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    //���� ��� ������
    public GameObject basketPrefab;
    //ʳ������ ��� �����
    public int numBasket = 3;
    //������� �� Y ������� ��� ������� �������� ��� ���
    public float basketButtomY = -14f;
    //�������� �� ������ ������
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
        //��������� ���� �������
        //�������� ������ ��������, ���� ������� ��������
        int basketIndex = basketList.Count - 1;
        //�������� �����, ���� ������� ��������
        GameObject tBasketGO = basketList[basketIndex];
        //��������� ������� �� ������
        basketList.RemoveAt(basketIndex);
        //��������� ��� ���� �� ���
        Destroy(tBasketGO);
        if (basketList.Count==0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

}
