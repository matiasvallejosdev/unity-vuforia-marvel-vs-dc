using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ViewModel;

namespace Components
{
    public class PlayGameButtonInput : MonoBehaviour
    {
        public GameFactoryCmd gameCommandFactory;
    
        public Slider loadingSlider;
        public TextMeshProUGUI playText;
        public GameObject characters;
        public int secondToWait = 5;
    
        string _sceneToOpen = "";
        CompositeDisposable _disposables = new CompositeDisposable(); // field
    
        public void OnClick(string scenename)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(Interval)
                .AddTo(_disposables);
    
            _sceneToOpen = scenename;
    
            this.gameObject.GetComponent<Button>().enabled = false;
            characters.SetActive(false);
            playText.gameObject.SetActive(false);
            loadingSlider.gameObject.SetActive(true);
            loadingSlider.maxValue = secondToWait;
        }
    
        private void Interval(long sec)
        {
            loadingSlider.value = sec;
            if(sec >= secondToWait)
            {
                OpenScene(_sceneToOpen);
            }
        }
        void OpenScene(string scenename)
        {
            try
            {
                SceneManager.LoadScene(scenename);
                //gameCommandFactory.PlayTurn(gameData.playerCharacters[0], gameData.playerCharacters[1], gameData).Execute();
                Debug.Log($"Loading {scenename} and closing current {SceneManager.GetActiveScene().name}");
            }
            catch(Exception e)
            {
                Debug.LogError($"Error when try to loading {scenename}. Try to resolve this Exception {e.Message}");
            }
            finally
            {
                _disposables.Dispose();
                _disposables.Clear();
            }
        }
    }
}
