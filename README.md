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

## Running the Project
Download the entire folder WindowsBuild

Run the executable found within

## Adding a New Class
1. Add your new class name under Assets/Scripts/GenerateStats.cs in the enum Class  
2. Add your new class in the Dictionary classWeights in the same script with its weights  

This is the Google Sheet I used to calculate weights: https://docs.google.com/spreadsheets/d/1ot3yGjghJdC6G9v0UOX8EPgTcdkwQWsX4zbnGdPo6mA/edit?usp=sharing  
Green cells are inputs, blue cells are outputs  

"Parts" of a class mean how much weight you give that class in generating a new class   
1 part warrior, 0 parts every other class is the warrior class  
1 part warrior, 1 part archer is half warrior, half archer  
3 part mage, 3 part archer, 1 part warrior is mostly a magic archer, with some warrior class mixed in 

![image](https://github.com/user-attachments/assets/b9615952-d66e-43fe-972c-4cf66ccfbe10)

## Generators
This project also has a tab for generating items and loot

![image](https://github.com/user-attachments/assets/0158c5a1-2a12-459d-b57b-4b9c461b5da9)

Each item contains {Enchanted} {Quality} {Rarity} {Item Type}
- Not all items can be enchanted
- Quality determines how well made that particular item is. 
- Rarity determines the material the item is made out of or how valuable it is.
- There are a variety of different item types including weapons and armor.

Additionally, there is a coin generator for different categories of loot
- 1 Electrum = 1000 Platinum
- 1 Platinum = 100 Gold
- 1 Gold = 100 Silver
- 1 Silver = 100 Copper
