/* 
                            * SPEC *
You must use either the do-while statement or the while statement as an outer game loop.
The hero and the monster will start with 10 health points.
All attacks will be a value between 1 and 10.
The hero will attack first.
Print the amount of health the monster lost and their remaining health.
If the monster's health is greater than 0, it can attack the hero.
Print the amount of health the hero lost and their remaining health.
Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
Print the winner.
 */

int heroHealth = 15;
int monsterHealth = 15;
int attack ;
Random dice = new();

do 
{
    attack = dice.Next(0,8);
    monsterHealth -= attack;
    if (monsterHealth < 0) monsterHealth = 0;
    Console.WriteLine($"The hero attacks for {attack} \t\t the monster has {monsterHealth} health remaining");

    if(monsterHealth <= 0) continue;

    attack = dice.Next(0,9);
    heroHealth -= attack;
    if (heroHealth < 0) heroHealth = 0;
    Console.WriteLine($"The Monster attacks for {attack} \t the hero has {heroHealth} health remaining");
    

} while (monsterHealth > 0 && heroHealth > 0);

Console.WriteLine($"Hero health: {heroHealth}, Monster health: {monsterHealth}");
if(heroHealth <= 0) Console.WriteLine("You Lose. Game Over");
else if (monsterHealth <= 0) Console.WriteLine("You win");