using UnityEngine;

public class UpdateNotes : MonoBehaviour
{
    public CharacterList.NPC npc; 
    public void ApplyNotes(string newNotes)
    {
        npc.Notes = newNotes;
    }
}