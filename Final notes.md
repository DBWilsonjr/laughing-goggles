This is my CPT-185 final project, in the state in which it was submitted. Off the jump, it is not in 100% working order. I didn't finish some of the data entry and still some things just didn't get coded at all. It's also pretty ugly. I get pretty wordy below, but if you'd rather stick with the bullet points then you're in the right place.

Right off the top: All graphics in this mess are completely swipped from Google image searching. I'm not trying to claim any of it, but I likewise don't have any info for the content creator(s). Pretty sure that makes me a dick.


What it is: I've been calling it an RPG Tower Defense game, which is probably the best simple description. You basically make a character and defend an imaginary temple. The temple has ten health and loses a certain amount of health based on what you're facing when you lose a fight. When you win a fight, you have a chance to improve yourself or heal/protect the temple. If you get ten protects on the temple, you win the game. You also have a chance of running into a boss, which becomes a do-or-die moment; lose and it's game over, win and it's a won run.

What it also is: My ambition getting the better of me. I wanted to include so much more in the default game (there are six classes, I planned for at least 18, etc), but at a certain point I realized that there was no way to do it all and make the due date. I still missed out on finishing some basic components, which just goes to show that I worked too much on things that got cut and failed to prioritize the core portions of the game as much as I should have. Oh well.

How complete is it? Hypothetically, it works to a complete finish. In practice, on my ancient laptop, it crashes in really strange spots that don't crash anywhere else. YMMV.

What needs to be fixed: Too much to even list. By the end of it, I was really burned out and made a lot of mistakes. The code is really scatterbrained in spots. Databases are stupid (I did it for the points; I regret it). In the future, databases will be gone. I can't really see anything else because of how much I hate the databases. I don't know why I thought it would be a good idea for less than 90% of the grade. Seriously, database is terrible.


TODO list:<br />
1) Implement all the originally intended content (mostly classes and character options)<br />
2) REMOVE THE SODDING ACCESS DATABASES (SQLite or something built-in with Visual Studio, I dunno)<br />
3) Rewrite the main code. It's a mess and even I have trouble tracking it<br />
4) Finish the data entry for enemies and abilities<br />
5) Add more stuff (I had so many ideas~!)<br />


-------------------------------------------------

Intro

It's bland, but that's because I don't do graphics at all. I just don't have the talent. The code is actually pretty neat, though; this is where I read files to determine if things have been unlocked. It just uses text files so it's not super impressive or innovative, but I like it. I may, in the rewrite, try to get fancy with file padding and specific location reads, but that's a probably top of the non-vital list.


Unlocks

Still not really that impressive. Defaults to a locked icon and generic text, changes to other icons and text based on unlocks read from the Intro. I wanted to a whole lot more, but as it turns out this kinda thing is a lot more time than I expected (especially when graphics are involved).


Bestiary

Same as with the unlocks, it displays one thing when locked and the actual info when unlocked. This one reads the "Names" column of the database, but that will change when I dump the databases. The code is similar to the above, except that there are no graphics involved here.


Character Creation (Creator and Preview forms)

This is actually a massive pain in the ass. Not only do things have to be passed from one form to another, but also to a third and in a way that doesn't set things too early since the purpose of the Preview form is to allow people to change their minds. The code is simple enough at its base; put a name in the textbox, pick a class, enable the other listboxes, make sure every option is accounted for, and pass it off to the Preview form. On the preview form, the player gets to see their choices, a short description of the abilities from their choices, and (hopefully?) an generic icon for their character. Once the accept button is clicked, all sorts of shit gets set and passed to globals, classes, and the Main Form.

I think the difficulty thing is probably my favorite bit of all this. It's a pretty simple idea, but it felt relatively clever at the time; difficulty sets a global (10, 5, or 0) that is used in the dice roll that generates a monster. So long as you've had fewer fights than that number, you can't land a boss and your pool doesn't shrink. After that point, or immediately for Hard, the number of fights you've had start subtracting from that dice roll, which lowers the chance of getting Red, Blue, or Yellow enemies and raises the odds of hitting a boss and thus pushing you to the end of the game. Again, it's very simple but sometimes the coolest things are simple.

These two forms started out as one form. I don't remember why I changed it, but now that I'm thinking of rewriting things I think it should be one form again. It's probably something to do with the size of the window and what it does for the layout, but I think I can make it work so I'll probably give it another pass in the revision.


The actual game (Main Form, PowerUp)

Interesting fact about the history of this game: The original code and vision in my head completely failed to account for the buttons (seriously?), so the actual tracking of combat gets a bit wonky. Long story short, it really needs a rewrite. Things got better once I realized how stupid I was, but it suffers for it. The general method (non-coding sort of method) I used to write all of this was very, very flawed; I started with the core idea but with very few of the core parts coded or otherwise accessible. That is to say, I wrote the enemy dice roll before I had the database created, which meant I pseudo'd in my program to fill the space and wound up spending a lot more time than expected getting the database to work once I had it (fun fact, without all that crap at the top that declares the database tables as variables, the tables won't fill and the game will crash 100%. Feels inconsistent with the way the database works on other forms, but whatever).

Combat is(/should be?) fairly simple. The button push sets your damage bonus (which should be picked up from the ABILITYx variable of the class) and anything else necessary and passes it to the main method (ActualGame (fun fact: was originally named ActualDamnGame, and almost submitted that way)), where we do a number of necessary things:
1) Check if frozen or stunned; if so, no turns for you.
2) CHeck if paralyzed and roll dice to see if you get a turn
3) Check for buffs and debuffs that impact health. This should actually be first, but I hobbled this shit together so some things are not the way they should be. Debuffs also don't kill, because that one messed with my head. When I rewrite, I'll move this first (as it should be) and reconsider debuffs/DoTs killing; I know how to do it, so it's just a matter of deciding if I want to be that kinda game or not.
4) Determine what sort of attack you're using and pass it to the appropriate method: Buff, Debuff, or Damage. If damage, do all the appropriate damage stuff. I haven't tested it lately, but I think I changed it in such a way that you can attack, then buff, and do the same damage a second time. Oops.
5) Check if the monster dies. If so, pop-up the powerup window, then check for win conditions; if win, yay this.close(), if not then run the Restart method for the next fight.
6) Enemy turn, check freeze/stun, para, then attack. Enemies don't have abilities yet, so the method that rolls attacks for enemies is incomplete and kinda stupid atm.
7) Check if the player dies, if so then damage the temple/protection. Check for lose conditions, etc.

I don't know how well it follows that format anymore. This is just a matter of poor planning, but seeing as my original vision failed to account for the goddamn buttons, no one should be surprised by this.

Some of that (as written above) is also out of order. After checking regen/DoTs and stun/para, it should go: (player attack -> check monster death, if so set variable -> Monster attack if deadmonster variable = false, else skip to end -> monster attack -> check player death, if so set variable -> check if player is dead, if so do dead player stuff -> check if monster is dead, if so do dead monster stuff (power-up, win condition, etc. (probably not in that order)), else next round of combat). This is more of me writing things out of order and jumping around tasks. It's hard to write a straight combat system when you do it before you even create enemies, the RNG for enemies, and various other things necessary for, you know, combat.

I also wrote the abilities late. Too late, probably. My last tests on my desktop were without abilities and the game played to conclusion without a problem. I haven't tried to find out if that's still the case (I just can't look at it anymore). The abilities are another point I'm proud of, though, partially for cleverness and partially because it's future de-databasing proof. I don't know if I'll still feel this way when I start adding more abilities, but I believe it's just a matter of adding the abilities to the proper if statement as an OR option, so it shouldn't be a problem.

I'm not sure what I want to do about enemies. Because they don't get buttons, I have to roll for their attacks. This is somewhat complicated by the fact that I don't want all enemies to have four abilities, which means a simple D4 doesn't work in all cases. I'm sure I can figure a way to read that nonsense (probably related to temple damage since the weaker enemies do 1 damage, medium do 2, and strongest do 3), but I'm still annoyed that I had to write a second damage Method for enemies. I should be able to do this in one method, but then again it's a bit cleaner with two. pros and cons, I guess.

I'll probably break the big complicated method into smaller methods in the rewrite since the goal is supposed to be to keep these things as simple and compact as possible.


I'm sure there's a lot more that needs to be said about what is wrong with this thing and what needs to be repaired/re-written, but it's been too long for me to remember and I'm more eager to start working on making it make sense.
