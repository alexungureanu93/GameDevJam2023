using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

  #region Singleton Stuff
  static Health instance;
  public static Health Instance { get { return instance; } }

  public bool isTutorial = false;

  protected virtual void Awake()
  {
    if (instance != null)
    {
      if (isTutorial)
        instance.PLAYER_HP = 100;
      else
        Debug.LogWarningFormat("[Singleton] Trying to instantiate a second instance of singleton class {0} from {1}", GetType().Name, this.gameObject.name);

      Destroy(this.gameObject);
      
    }
    else
    {
      instance = this;

    }
    DontDestroyOnLoad(transform.gameObject);

  }

  protected virtual void OnDestroy()
  {
    if (instance == this)
    {
      instance = null;
    }
  }
  #endregion


  public int PLAYER_HP= 100;

  // Start is called before the first frame update
  void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
