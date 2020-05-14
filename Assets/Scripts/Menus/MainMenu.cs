using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {

        public void BeginSurvival()
        {
            SceneManager.LoadScene("Survival");
        }

        public void BeginTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }

        public void BeginArcade()
        {
            SceneManager.LoadScene("Game");
        }

        public void Quit()
        {
            Application.Quit();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
