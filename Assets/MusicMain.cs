using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMain : MonoBehaviour
{

  #region Singleton Stuff
  static MusicMain instance;
  public static MusicMain Instance { get { return instance; } }

  protected virtual void Awake()
  {
    if (instance != null)
    {
      Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0} from {1}", GetType().Name, this.gameObject.name);
      Destroy(this.gameObject);
    }
    else
    {
      instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
  }

  protected virtual void OnDestroy()
  {
    if (instance == this)
    {
      instance = null;
    }
  }
  #endregion

}
