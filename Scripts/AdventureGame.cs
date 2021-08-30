using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // создаем класс (переменную) Text, чтобы в него можно было поместить текст в инспекторе.
    [SerializeField] Text textComponent;
    // создаем класс (переменную) State, чтобы в него можно было поместить файл StartingState с расширением asset в инспекторе.
    [SerializeField] State startingState;
    // создаем класс State для того чтобы получить доступ к скрипту State.
    State state;

    void Start()
    {
        // передаем текст из StartingState в переменную (поле) state.
        state = startingState;
        // получаем доступ в textComponent к тексту Story Text из Canvas, вызываем метод GetStateStory() из скрипта State.
        // и запускаем отображение текста из файла StartingState при старте игры.
        textComponent.text = state.GetStateStory();
    }

    void Update()
    {
        // вызываем каждый фрейм метод ManageState()
        ManageState();
    }

    // Создаем метод ManageState(), для того чтобы можно было выбрать комнату из массива для перехода между ними.
    private void ManageState()
    {
        // используем var, так как nextStates является массивом (можно использовать State[]), вызываем GetNextStates() из скрипта State.
        // передаем значение в переменную массива nextStates.
        var nextStates = state.GetNextStates();

        // начинаем отсчет комнат State с элемента индекса ноль, пока индекс < количества вариантов выбора комнат, индекс сможет увеличиваться на 1.
        // для первой комнаты индекс будет только один так как только один вариант развития, 
        // для второй уже два и.т.д в зависимости от количества выбора вариантов в комнате.
        for(int index = 0; index<nextStates.Length; index++)
        {
            // Сможем переходить между комнатами при нажатии кнопок 1 и 2
            // Если мы нажимаем кнопку 1 + индекс номера комнаты (0,1)
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                // переходим с комнаты StartingState в комнату RoomOne или RoomTwo.
                state = nextStates[index];
            }
        }  

        // Запускаем смену текста в комнатах на в игре через кнопки 1,2, и.т.д. клавиатуры.
        textComponent.text = state.GetStateStory();
    }
}