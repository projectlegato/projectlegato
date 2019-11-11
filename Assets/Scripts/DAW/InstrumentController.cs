public interface InstrumentController
{
    void MakeSound(int beatNum);
    void CharacterAction();
    int GetRow();

    void OnSet(int beatNum);

    void OnUnSet(int beatNum);
}
