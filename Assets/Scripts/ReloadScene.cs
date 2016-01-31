namespace Assets.Scripts
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ReloadScene : MonoBehaviour
    {
        [SerializeField]
        private string m_SceneName;

        [SerializeField]
        private GameObject m_EndGameObject;

        [SerializeField]
        private List<Player.Input> m_InputScripts;

        public void ReloadGivenScene()
        {
            SceneManager.LoadScene(this.m_SceneName);
        }

        public void OnEndGame()
        {
            foreach (var input in this.m_InputScripts)
            {
                input.gameObject.SetActive(false);
            }

            this.m_EndGameObject.SetActive(true);
        }
    }
}