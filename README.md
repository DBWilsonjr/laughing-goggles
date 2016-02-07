# laughing-goggles <br />
CPT 185 Final Project <br />
<br />
Final Notes is the place for the comprehensive breakdown. This is just the todo list. <br />
<br />
Game plays to completion for all endings (Protection win, boss win, boss loss, temple destruction). Hooray. <br />
It probably qualifies as a 0.2~ish build; fully functional as far as I can tell, but not feature complete. <br />
<br />
<br /> 
Current Task: Add the rest of the intended classes and abilities - The classes are already partially implemented anyway, so it's mostly abilities that need to be added. This one is more about creativity than coding, but still. <br />
<br />
Completed Tasks:<br />
1) Integrate Character Creation forms - Simple merge of two forms. Layout is decent but definitely can be improved. Also fixed a crash on clearing inputs that I didn't catch any other time I tested this thing. Pretty sure I didn't break anything else. Left the Preview form in, just in case.<br />
2) MainGame/Power-up integration - Didn't go as planned. For how I want things to work, having two forms is actually best. Made the powering-up actually work for all stats now.<br />
3) <b>MainGame clean-up</b><br />
3a) Fixed the game not playing completely through<br />
3b) Fixed certain informational bits not updating properly<br />
3c) Added color-coding for enemies<br />
3d) Commented on some variable choices I made previously for easier parsing at a glance and possibly for moving later<br />
4) <b>Combat core re-written</b> <br />
4a) Translated a few things into arrays for future expansion <br />
4b) Modified the debuff function to (probably) work with enemy attacks as well <br />
4c) Added some interface bits to clarify abilities while in combat <br />
4d) Removed the preview form; it was, in fact, useless since the creation code was redone <br />
4e) Finished the exsisting data entry, except for monster abilities beyond just normal hits <br />
4f) Fixed a stupid mistake that let bosses show up way sooner than intended <br />
4g) Fixed a really stupid mistake that had yellow reading from the boss tables <br />
4h) So many other bug fixes that I've forgotten <br />
<br />
Task List: <br />
?) Rewrite enemy spawn to better use the enemy class <br />
?) Double-Check unlock conditions <br />
?) Revamp data management for classes, enemies, and abilities <br />
?) More data Entry <br />
?) Add the rest of the intended classes and abilities <br />
?) Add remaining unlocks and challenges <br />
?) Balance the difficulty <br />
