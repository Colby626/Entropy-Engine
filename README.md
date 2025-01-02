# Entropy Engine 
This is a project for generating stats for a character given its **Rarity** and **Class**
- A character's **Rarity** determines the set of levels that a character will generate within  
- The **Level** determines the amount of stat points that the character will have  
- The chosen **Class** determines what distribution of stats that character will have

The base classes are 
- Warrior
- Archer
- Rogue
- Mage

The base stats are 
- Endurance
- Strength
- Dexterity
- Agility
- Intelligence
- Spirit

## Adding a New Class
1. Add your new class name under Assets/Scripts/GenerateStats.cs in the enum Class  
2. Add your new class in the Dictionary classWeights in the same script with its weights  

This is the Google Sheet I used to calculate weights: https://docs.google.com/spreadsheets/d/1ot3yGjghJdC6G9v0UOX8EPgTcdkwQWsX4zbnGdPo6mA/edit?usp=sharing  
Green cells are inputs, blue cells are outputs  

"Parts" of a class mean how much weight you give that class in generating a new class   
1 part warrior, 0 parts every other class is the warrior class  
1 part warrior, 1 part archer is half warrior, half archer  
3 part mage, 3 part archer, 1 part warrior is mostly a magic archer, with some warrior class mixed in 

![image](https://github.com/user-attachments/assets/ed0b3e28-7162-4188-b70f-aaa499fc10a2)
