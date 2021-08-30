using UnityEngine;

// позволяет в Unity создать (Create-State) новый ScriptableObject с именем по умолчанию State с расширением asset.
[CreateAssetMenu(menuName = "State")]
// создаем класс ScriptableObject, который будет содержать/хранить в себе текст и не будет связан ни с каким GameObject в инспекторе.
public class State : ScriptableObject
{
    // [TextArea(14, 10)] создаем размер текстового поля 14 строк (текст который будет виден сразу), 10 через сколько строк можно будет скролить текст, 
    // который виден в инспекторе в файлах .asset.
    // создаем класс string который будет виден в инспекторе, в файлах .asset, позволяет писать текст прямо в инспекторе.
    [TextArea(14, 10)] [SerializeField] string storyText;
    // создаем массив типа State, который будет виден в инспекторе, в файлах .asset, для того чтобы поместить в него файлы .asset.
    [SerializeField] State[] nextStates;

    // Создаем публичный метод GetStateStory(), для того чтобы отобразить текст на экране, при его вызове в скрипте AdventureGame.
    public string GetStateStory()
    {
        // отображаем текст на экране.
        return storyText;
    }

    // Создаем метод GetNextStates(), для того чтобы вызвать его в скрипте AdventureGame и использовать выбор вариантов прохождения из массива.
    public State[] GetNextStates()
    {
        // переходим в различные комнаты.
        return nextStates;
    }
}
