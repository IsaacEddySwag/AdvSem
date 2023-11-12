INCLUDE globals.ink

{ areFood == "": -> main | ->ChoiceMade}

=== Main ===
I'm <color=\#FF0000>hungry</color> #speaker:Hungry Man #color:HungrySpeak #layout:Left
I want to eat
Are you <color=\#FF0000>hungry</color>?
I'm not <color=\#FF0000>hungry</color> #speaker:Not Hungry Man #color:NotHungrySpeak #layout:Right
Ok. #speaker:Hungry Man #color:HungrySpeak #layout:Left
How about you?

*[Yep]
->Choice1
*[Nope]
->Choice2
*[I am food]
->Choice3

=== Choice1 ===
Nice.
I think I'll <color=\#FF0000>eat</color> you now
 ~ areFood = are food

-> END
=== Choice2 ===
Nerd
Do you want to <color=\#FF0000>eat</color>?
Yep #speaker:Not Hungry Man #color:NotHungrySpeak #layout:Right
 ~ areFood = are not food

-> END
=== Choice3 ===
I'm going to <b>fucking<b> <color=\#FF0000>eat</color> you
 ~ areFood = are food
Your


=== ChoiceMade ===
You {areFood}. Bazinga.
-> END


