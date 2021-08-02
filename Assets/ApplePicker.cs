using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]

    public GameObject basketPerfab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPerfab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        DeleteOneBasket();
        if( basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
        


    }
    /// <summary>
    /// Удалить одну корзину
    /// </summary>
    private void DeleteOneBasket()
    {
        // Получить индекс последней корзины в basketList
        int basketListIndex = basketList.Count - 1;
        // Получить ссылку на игровой объект basket
        GameObject tBasketGO = basketList[basketListIndex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketListIndex);
        Destroy(tBasketGO);
    }
}
