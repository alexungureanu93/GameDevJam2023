using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton Stuff
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

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
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    #endregion
  
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  public void LoadTutorial()
  {
    SceneManager.LoadScene(1);
  }

  public void LoadTitle()
  {
    SceneManager.LoadScene(0);
  }
  public void LoadGameOver()
  {
    if (MusicMain.Instance != null)
      Destroy(MusicMain.Instance.gameObject);
    SceneManager.LoadScene("ThreeTorchsGameOver");
  }

  public void LoadCongrats()
  {
    if(MusicMain.Instance != null)
      Destroy(MusicMain.Instance.gameObject);
    SceneManager.LoadScene("ThreeTorchsEnd");
  }
}
