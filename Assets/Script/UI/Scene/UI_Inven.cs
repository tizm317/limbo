using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    // 인벤토리

    enum GameObjects
    {
        GridPanel,
    }


    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        // 바인딩 과정
        Bind<GameObject>(typeof(GameObjects));

        // girdPanel 날리기 (child 순회해서) 과정
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 아이템 개수만큼 붙이기
        for(int i = 0; i < 8; i++) // 실제 인벤토리 정보 참고해서 몇개 만들지 고려
        {
            // 1. inven_item 생성해서 GridPanel 산하에 붙임
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform).gameObject;


            // 프리팹에 UI_Inven_Item 컴포넌트 연결 안 되어있어서 생기는 문제 해결법
            // 1번째 방법 - 코드로 추가 : Util.GetOrAddComponent<UI_Inven_Item>(item);
            // (2번째 방법 : 프리팹 저장할 때 add component 해서 UI_Inven_Item 컴포넌트 추가)
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>(); // Extension 사용
            
            invenItem.SetInfo($"집행검{i}번");
        }
    }

  

}
