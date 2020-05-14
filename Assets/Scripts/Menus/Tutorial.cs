using Controllers_Scripts;
using Game_Logic_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class Tutorial : MonoBehaviour
    {

        public GameObject slide1;
        public GameObject slide2;
        public GameObject slide3;
        public GameObject slide4;
        public GameObject player;

        public void Next1()
        {
            slide1.SetActive(false);
            slide2.SetActive(true);
            player.SetActive(true);
        }

        public void Next2()
        {
            slide2.SetActive(false);
            slide3.SetActive(true);
            player.SetActive(false);
        }

        public void Next3()
        {
            slide3.SetActive(false);
            slide4.SetActive(true);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
