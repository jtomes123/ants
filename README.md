This was a school project during my 3rd year at Česko-anglické gymnázium. The original idea was to simulate behaviour of hunderts of ants, but the Greenfoot that was chosen in order to match the skill of everyone in class was lacking the performance neccessary. In order to overcome this I decided to develop this engine from scratch in C#. AntsEngine is the implementation that is executable. 
#### There are multiple basic commands:
* Reffer to the CommandProcessor.cs for more info
* Spawn is the most important command
* In order to see something happen enter:
    * Spawn <What> <Position X> <Position Y>
        * Spawn Anthill 250 250
        * Spawn Food 500 250
    * ShowPaths
        * ShowPaths set true

You will see an anthill spawn, anthill then spawns an ant, who in turn starts looking for food. Anthill then keeps tract of valid paths to food.