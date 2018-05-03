using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取Manager的中转类
/// </summary>
public class ManagerStation
{
    private static Dictionary<ManagerEnum, BaseManager> managerDict = new Dictionary<ManagerEnum, BaseManager>();

    /// <summary>
    /// 若字典未存储Manager，调用此方法将所有Manager添加到字典中
    /// </summary>
    private static void InitDict()
    {
        string[] managersName = System.Enum.GetNames(typeof(ManagerEnum));//存储所有Manager的名字

        foreach (string name in managersName)
        {
            switch (name)
            {
                case "AudioManager":
                    managerDict.Add(ManagerEnum.AudioManager, new AudioManager());
                    // 或者也可以这样添加 managerDict.Add(ManagerEnum.AudioManager, GameObject.Find(自定义路径));
                    //第二种方法是如果manager挂载在场景的物体上的话，就调用第二种方法获取场景中的manager
                    break;
                case "LevelManager":
                    managerDict.Add(ManagerEnum.LevelManager, new LevelManager());//这里用第一种方法举例子，反正就是要将一个manager添加到字典里的意思
                    break;
                case "SceneManager":
                    managerDict.Add(ManagerEnum.SceneManager, new SceneManager());
                    break;
                case "UIManager":
                    managerDict.Add(ManagerEnum.UIManager, new UIManager());
                    break;
                case "EventManager":
                    managerDict.Add(ManagerEnum.Eventmanager, new EventManager());
                    break;
                case "GameManager":
                    managerDict.Add(ManagerEnum.GameManager, new GameManager());
                    break;
                case "CharacterManager":
                    managerDict.Add(ManagerEnum.CharacterManager, new CharacterManager());
                    break;
            }
        }
    }

    /// <summary>
    /// 外部通过该方法获取字典中的Manager，以BaseManager的类型返回，获取后要进行强制类型转换
    /// </summary>
    /// <param name="managerName"></param>
    /// <returns></returns>
    public static BaseManager GetManager(ManagerEnum managerName)
    {
        if (managerDict.Count <= 0)
            InitDict();

        BaseManager manager;
        managerDict.TryGetValue(managerName, out manager);
        return manager;
    }
}
