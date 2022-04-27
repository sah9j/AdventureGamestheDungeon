using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace AdventureGamesTheDungeon
{
    internal static class EntryEvaluation
    {
        private static bool isdone = false;
        // This method evaluates Item and Location Combination entries.
        public static void ItemLocationEvaluation(int entryID, ref List<Card> inventory, ref int hp, string name)
        {
            if(MainForm.frm.beastAlive && MainForm.frm.locationCurrently == 'K')
            {
                if (hp > 1)
                    hp--;
            }
            if(MainForm.frm.endOfGame)
            {
                MainForm.frm.Countdown--;
            }
            switch (entryID)
            {
                case 10101:
                    MessageBox.Show("The brick smashes into the lock and splinters off a tiny piece. The lock still " +
                        "remains intact though.");
                    break;
                case 10201:
                    MessageBox.Show("You hammer on the damaged part of the door with the brick. The wood " +
                        "creaks a little, but does not break. Maybe you can attatch something to it to give " +
                        "you more force and speed to do more damage?");
                    break;
                case 10301:
                    MessageBox.Show("You don't want to give the dead man another headache.");
                    break;
                case 10401:
                    MessageBox.Show("The grating is too solid for the brick to do any damage.");
                    break;
                case 10501:
                    MessageBox.Show("It's just another brick in the wall ...");
                    break;
                case 10601:
                    MessageBox.Show("Why do you want to hide the brick under the bunk?");
                    break;
                case 10701:
                    MessageBox.Show("The brick is strong enough to damage the metal box. After a few blows, " +
                        "it's so dented that you can now remove the contents. You recieve a strange map.");
                    AdventureCardDatabase.CreateCard(ref inventory, 14);
                    break;
                case 10801:
                    MessageBox.Show("The iron bars are pretty solid. The brick is more likely to break.");
                    break;
                case 11101:
                    MessageBox.Show("The iron bar hits the lock with a clang. Apart from the scratch, it doesn't " +
                        "appear to have done anything though.");
                    break;
                case 11201:
                    MessageBox.Show("The iron bar doesn't have enough power behind it to damage the wood. " +
                        "Maybe you can attach it to something to give you more force and speed to do " +
                        "more damage?");
                    break;
                case 11301:
                    MessageBox.Show("The man already died in chains. There's no need to hit him with an iron " +
                        "bar, too.");
                    break;
                case 11401:
                    MessageBox.Show("The clang of the iron bar hitting the metal grating reverberates loudly " +
                        "around the sewers.");
                    break;
                case 11501:
                    MessageBox.Show("You manage to make a few scratches on the stones with the iron bar, but " +
                        "that's about it.");
                    break;
                case 11601:
                    MessageBox.Show("A startled spider scuttles out from under the bunk when you poke around " +
                        "underneath it with the iron bar.");
                    break;
                case 11701:
                    MessageBox.Show("The iron bar causes a few scratches and dents in the metal box, but it " +
                        "doesn't have enough power to do any real damage.");
                    break;
                case 11801:
                    MessageBox.Show("You'd be able to hear it from afar. And anyway, the remaining iron bars " +
                        "look pretty solid.");
                    break;
                case 12101:
                    MessageBox.Show("The hammer hits the lock with great force. But the metal is solid enough " +
                        "to withstand your fervid attack.");
                    break;
                case 12201:
                    MessageBox.Show($"You repeatedly swing your makeshift hammer with all your might and " +
                        "smash it down on the weak spot in the door. The wood splinters after a few " +
                        "strokes and soon the gap is wide enough for you to squeeze through. Your tool " +
                        "is no good for anything anymore though. You lose your makeshift hammer. " +
                        //entry 901
                        "With a queasy feeling in your stomach, you peak through the hole in the " +
                        "door. There can't be any guards around, or else they would have heard you trying " +
                        "to break out. With a sigh of relief, you realize that the coast is clear and you can't " +
                        "see anyone in the torchlight. ");
                    //read entry C
                    LocEntry(ref inventory, ref hp, name,entry:'C');
                    //remove card 12 from inventory
                    AdventureCardDatabase.RemoveCard(12);
                    //add room card C to board adjacent to A
                    MainForm.OpenLocation('C');
                    //Move player to room card c.
                    break;
                case 12301:
                    MessageBox.Show("He's dead. There's no need to give him another headache.");
                    break;
                case 12401:
                    MessageBox.Show("Even the makeshift hammer won't be enough to destroy the iron grating.");
                    break;
                case 12501:
                    MessageBox.Show("You decide that your makeshift hammer would break before the wall " +
                        "would.");
                    break;
                case 12601:
                    MessageBox.Show("The makeshift hammer scratches the ground without having any effect.");
                    break;
                case 12701:
                    MessageBox.Show("The force of the impact almost smashes the little metal box. Let's hope " +
                        "the contents haven't been damaged! You carefully reach into the opening you've " +
                        "created. You recieve a strange map.");
                    AdventureCardDatabase.CreateCard(ref inventory,14);
                    break;
                case 12801:
                    MessageBox.Show("The iron bars are too solid, Even your makeshift hammer can't help you here.");
                    break;
                case 13101:
                    MessageBox.Show("Your hands tremble with excitement and you try to put the key in the lock. " +
                        "Unfortunately, it doesn't fit.");
                    break;
                case 13105:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 13109:
                    //read entry 109
                    MessageBox.Show("You walk along the corridor to the great portal. As you approach, you hear " +
                        "a whistling sound. You look up to see an arrow shooting towards you from the " +
                        "mouth of the stone mask above the portal. Unfortunately, you're far too close to " +
                        "escape its path and pain sears through your leg as it is pierced by the arrow! Next " +
                        "time, you'd do well to steer clear of the stone mask.");
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 13201:
                    MessageBox.Show("There are scratches here. It's a key. There's no use for it here. It's normally " +
                        "used to open a lock.");
                    break;
                case 13205:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 13301:
                    if (MessageBox.Show("Will the key maybe unlock the skeleton's chains? You try the key in the " +
                   "left shackle and it springs open.Without its support, the skeleton's arm drops " +
                   " down.You spot something glittering in a crack behind it.Do you want to get it " +
                   "out?", "Skeleton chains", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 16);
                    }
                    break;
                case 13401:
                    MessageBox.Show("There's no keyhole in the grating. And you certainly don't want to drop " +
                        "the key in.");
                    break;
                case 13409:
                    MessageBox.Show("The key is too wide to put down the crack between the stones.");
                    break;
                case 13601:
                    MessageBox.Show("Of course, you could just hide the key under the bunk. But that won't " +
                        "help you get out of the cell.");
                    break;
                case 13701:
                    MessageBox.Show("The metal box doesn't have a keyhole.");
                    break;
                case 13707:
                    MessageBox.Show("This door doesn't have a keyhole.");
                    break;
                case 13709:
                    MessageBox.Show("A single key is not enough. All good things come in ...?");
                    break;
                case 13801:
                    MessageBox.Show("You want to throw the key out the window? Really?!");
                    break;
                case 13805:
                    MessageBox.Show("The door is already unlocked.");
                    break;
                case 14407:
                    MessageBox.Show("\"Edric: I don't know what that means either, I'm afraid.\"");
                    break;
                case 17401:
                    MessageBox.Show("The broom is too slick. You cannot use it to grasp whatever is down there.");
                    break;
                case 17409:
                    MessageBox.Show("The broom handle is too wide to fit down the crack between the stones.");
                    break;
                case 17509:
                    MessageBox.Show($"When you use the broom to sweep away the spider webs, something " +
                        "tinkles on the floor. What kind of a spider spun these webs anyway? When you " +
                        "glance down at the broom, you see it crawling with spiders. Grossed out, " +
                        "you toss it away. You recieve {card 25} and lose {card 17}");
                    //discard card 17 from inventory
                    AdventureCardDatabase.RemoveCard(17);
                    //add card 25 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 25);
                    break;
                case 17701:
                    if (MessageBox.Show("Summoning all your strength, you bring the broom crashing down on the " +
                    "metal box.You manage to create a wide opening, Do you want to reach inside ?", "Metal box", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 14);
                    }
                    break;
                case 19608:
                    MessageBox.Show("The ring's stone fits perfectly into the groove. With a soft click, it opens " +
                        "to reveal a gemstone! You recieve {card 57} and lose {card 19}");
                    //discard card 19 from inventory
                    AdventureCardDatabase.RemoveCard(19);
                    //add card 57 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 57);
                    break;
                case 20105:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 20109:
                    //read entry 109
                    MessageBox.Show("You walk along the corridor to the great portal. As you approach, you hear " +
                        "a whistling sound. You look up to see an arrow shooting towards you from the " +
                        "mouth of the stone mask above the portal. Unfortunately, you're far too close to " +
                        "escape its path and pain sears through your leg as it is pierced by the arrow! Next " +
                        "time, you'd do well to steer clear of the stone mask.");
                    //subtract 2 health points from character.
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 20205:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 20301:
                    if (MessageBox.Show("Will the key maybe unlock the skeleton's chains? You try the key in the " +
                    "left shackle and it springs open.Without its support, the skeleton's arm drops " +
                    " down.You spot something glittering in a crack behind it.Do you want to get it " +
                    "out?", "Skeleton chains", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 16);
                    }
                    break;
                case 20409:
                    MessageBox.Show("The key is too wide to put down the crack between the stones.");
                    break;
                case 20701:
                    MessageBox.Show("The metal box doesn't have a keyhole.");
                    break;
                case 20707:
                    MessageBox.Show("This door doesn't have a keyhole.");
                    break;
                case 20709:
                    MessageBox.Show("A single key is not enough. All good things come in ...?");
                    break;
                case 20805:
                    MessageBox.Show("The door is already unlocked.");
                    break;
                case 24105:
                    MessageBox.Show("Even a burglar would have trouble breaking a lock open with a simple " +
                        "knife");
                    break;
                case 24407:
                    MessageBox.Show("There is no reason to attack Edric.");
                    break;
                case 24409:
                    if (MessageBox.Show("With a precise stab, you wedge the knife into the gap beside the loose " +
                    "stone slab. After a few attempts, you'e also able to lift the stone slightly. You should " +
                    "be able to reach under the stone now. It will probably break the blade though.Is it worth taking the risk? ",
                    "Stone slab", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //read entry 244
                        MessageBox.Show("Slowly but surely, you loosen the stone with your knife. As feared, the " +
                            "blade breaks after a while. But you discover beneath the stone makes up for this. " +
                            "You recieve an emerald.");
                        //remove card 24
                        AdventureCardDatabase.RemoveCard(24);
                        //add card 44
                        AdventureCardDatabase.CreateCard(ref inventory, 44);
                    }
                    break;
                case 24509:
                    MessageBox.Show("The spider web is out of reach.");
                    break;
                case 24701:
                    MessageBox.Show("The knife doesn't do much damage.");
                    break;
                case 24707:
                    MessageBox.Show("The door is simply too heavy. The knife doesn't do anything.");
                    break;
                case 25105:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 25109:
                    //read entry 109
                    MessageBox.Show("You walk along the corridor to the great portal. As you approach, you hear " +
                        "a whistling sound. You look up to see an arrow shooting towards you from the " +
                        "mouth of the stone mask above the portal. Unfortunately, you're far too close to " +
                        "escape its path and pain sears through your leg as it is pierced by the arrow! Next " +
                        "time, you'd do well to steer clear of the stone mask.");
                    //subtract 2 health points from character.
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 25205:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 25301:
                    if (MessageBox.Show("Will the key maybe unlock the skeleton's chains? You try the key in the " +
                    "left shackle and it springs open.Without its support, the skeleton's arm drops " +
                    " down.You spot something glittering in a crack behind it.Do you want to get it " +
                    "out?", "Skeleton chains", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 16);
                    }
                    break;
                case 25409:
                    MessageBox.Show("The key is too wide to put down the crack between the stones.");
                    break;
                case 25701:
                    MessageBox.Show("The metal box doesn't have a keyhole.");
                    break;
                case 25707:
                    MessageBox.Show("This door doesn't have a keyhole.");
                    break;
                case 25709:
                    MessageBox.Show("A single key is not enough. All good things come in ...?");
                    break;
                case 25805:
                    MessageBox.Show("The door is already unlocked.");
                    break;
                case 28105:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 28205:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 28301:
                    MessageBox.Show("You can't use this key to unlock the shackles.");
                    break;
                case 28304:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 28404:
                    MessageBox.Show("The key doesn't fit.");
                    break;
                case 28502:
                    MessageBox.Show("Finally, the key fits! The heavy wooden door swings opens with a creak to " +
                        "reveal a passageway carved in rough stone.");
                    //reveal room card L right of room G
                    MainForm.OpenLocation('L');
                    //read entry L
                    LocEntry(ref inventory,ref hp, name,entry:'L');
                    break;
                case 28701:
                    MessageBox.Show("The metal box doesn't have a keyhole.");
                    break;
                case 28709:
                    MessageBox.Show("The door is already open.");
                    break;
                case 28711:
                    MessageBox.Show("There's no lock on the rusty grating.");
                    break;
                case 28802:
                    MessageBox.Show("The silver key unlocks the trapdoor in the floor and you lift it open. " +
                        "Creaking wooden steps lead down into the darkness. You descend the steep steps " +
                        "and enter a small chamber. " +
                        "What a horrific sight! Several chains hang from the ceiling and various torture " +
                        "implements stand ready for use. As if physical pain weren't enough, several skulls " +
                        "stare down at those unlucky enough to end up here and thus also torment the " +
                        "soul. Even you feel a little queasy and struggle to tear your gaze from the hollow " +
                        "eye sockets that grow larger and larger and threaten to swallow you up.");
                    //move player to room card M
                    MainForm.OpenLocation('M');
                    //read entry M
                    LocEntry(ref inventory,ref hp,name,entry:'M');
                    break;
                case 28805:
                    MessageBox.Show("The door is already open.");
                    break;
                case 29304:
                    MessageBox.Show("Your helpfulness is commendable, but this isn't the time to be " +
                        "oiling the hinges!");
                    break;
                case 29404:
                    MessageBox.Show("Your helpfulness is commendable, but this isn't the time to be " +
                        "oiling the hinges!");
                    break;
                case 29502:
                    MessageBox.Show("Your helpfulness is commendable, but this isn't the time to be " +
                        "oiling the hinges!");
                    break;
                case 29605:
                    MessageBox.Show("A few drops of oil really can work wonders sometimes! You can finally " +
                        "move the lever, and pull down on it. You hear a scraping noise to your left and " +
                        "when you follow the sound with your eyes, you see that a stone in the floor is " +
                        "moving away to reveal a secret passage! You curiously descend the steps.");
                    //remove card 29 from inventory
                    inventory.RemoveAt(inventory.FindIndex(p => p.ID == 29));
                    AdventureCardDatabase.RemoveCard(29);
                    //place room card I below room card C
                    MainForm.OpenLocation('I');
                    //move player to room I

                    //read entry I
                    LocEntry(ref inventory,ref hp,name,entry:'I');

                    break;
                case 29802:
                    MessageBox.Show("Your helpfulness is commendable, but this isn't the time to be " +
                        "oiling the hinges!");
                    break;
                case 30111:
                    MessageBox.Show("The rats retreat at your approach.");
                    break;
                case 30507:
                    MessageBox.Show("You hold the bottle under the tap and fill it up. You recieve {card 31}");
                    //remove card 30 from inventory
                    AdventureCardDatabase.RemoveCard(30);
                    //add card 31 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 31);
                    break;
                case 31111:
                    MessageBox.Show("You decide that pouring the wine out here is an unnecessary waste.");
                    break;
                case 31205:
                    MessageBox.Show("Jin literally tears the wine from your hands. He swallows it in a single " +
                        "gulp, as if he were dying of thirst. \"Not bad,\" he says as he wipes a few drops of " +
                        "the liquid from his sparse beard and emphasizes his conentment with a hearty " +
                        "belch. Then he pats down his ragged clothes and pulls out a crumpled piece " +
                        "of parchment. \"Here, my friend. Take this. It might be useful to you.\"");
                    //remove card 31 from inventory
                    AdventureCardDatabase.RemoveCard(31);
                    //place card 42 in inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 42);
                    break;
                case 33204:
                    MessageBox.Show("You sprinkle a little poweder on the notes, but no secret messages are " +
                        "revealed.");
                    break;
                case 33212:
                    MessageBox.Show("You sprinkle a little poweder on the notes, but no secret messages are " +
                        "revealed.");
                    break;
                case 33503:
                    MessageBox.Show("You sprinkle a little poweder on the notes, but no secret messages are " +
                        "revealed.");
                    break;
                case 33504:
                    MessageBox.Show("You sprinkle a little poweder on the notes, but no secret messages are " +
                        "revealed.");
                    break;
                case 34104:
                    MessageBox.Show("You carefully insert the shard of glass into the stained glass window " +
                        "frame. It fits! You open the window a little and look at it against the light. In " +
                        "doing so, you notice that the blue sections shine partticularly brightly.");
                    //remove card 34 from inventory
                    AdventureCardDatabase.RemoveCard(34);
                    //place card 79 into inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 79);
                    break;
                case 35105:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then this door is open and Monte steps out. \"Thank you so very " +
                        "much! free at last!\" He sighs with relief. \"Please allow me to accompany you. I've " +
                        "worked in the mines and passageways for so long, my knowledge of them is sure to be " +
                        "of help to you!\"");
                    //remove card 35 from inventory
                    AdventureCardDatabase.RemoveCard(35);
                    //add card 74 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 74);
                    break;
                case 35205:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then the door i s open. The prisoner steps out and shakes your " +
                        "hand. \"At last I'm out of that cramped cell. I'm eternally grateful to you!\" At this, he " +
                        "bows down in front of you. \"My name is Jin by the way and it would be my pleasure " +
                        "to accompany you. Who knows, maybe my knowledge of gemstones will prove useful!\"");
                    //remove card 35 from inventory
                    AdventureCardDatabase.RemoveCard(35);
                    //add card 75 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 75);
                    break;
                case 35304:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. The final drop of metal has only just fallen to the ground when the " +
                        "door bursts open and the prisoner comes barreling out with a huge grin on her " +
                        "face. \"How can I possibly thank you for freeing me?\" She gives you a wide smile, " +
                        "but then suddenly remembers something. \"Oh! please excuse my manners. " +
                        "My name is Nuha. Allow me to accompany you. There are sure to be more secrets " +
                        "of the League down here. Riddles are my specialty, so I could help you with that!\"");
                    //remove card 35 from inventory 
                    AdventureCardDatabase.RemoveCard(35);
                    //add card 76 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 76);
                    break;
                case 35404:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then the door is open. The prisoner cautiously sticks her " +
                        "head out and looks around. When she sees you, she says grumpily, \"You again, I " +
                        "suppose I owe you something for getting me out.\" She steps out, draws herself up to " +
                        "her full impressive height, and gives you a nod. \"Brigh's my name. I'll come with " +
                        "you. If you get into a fight, then you can count on me. But as soon as we get out of " +
                        "here, we will go our seperate ways.\"");
                    //remove card 35 from inventory
                    AdventureCardDatabase.RemoveCard(35);
                    //add card 77 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 77);
                    break;
                case 35502:
                    MessageBox.Show("Aqua regia only affects gold. It's useless when it comes to silver.");
                    break;
                case 35707:
                    MessageBox.Show("There is nothing here that aqua regia could melt.");
                    break;
                case 35802:
                    MessageBox.Show("Aqua regia only affects gold. It's useless when it comes to silver.");
                    break;
                case 36111:
                    MessageBox.Show("The rates retreat at your approach.");
                    break;
                case 36401:
                    MessageBox.Show("Not a bad idea. But with the hook alone you won't be able to reach down " +
                        "far enough.");
                    break;
                case 36415:
                    MessageBox.Show("You're unable to do any damage to the inscription or the stone with the " +
                        "hook.");
                    break;
                case 36701:
                    if (MessageBox.Show("Summoning all your strength, you bring the hook crashing down on the " +
                    "metal box.You manage to create a wide opening, Do you want to reach inside ?", "Metal box", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 14);
                    }
                    break;
                case 36711:
                    MessageBox.Show("You hit the rusty grating. Then try pulling on them. They don't budge.");
                    break;
                case 37111:
                    MessageBox.Show("The rats retreat as you approach.");
                    break;
                case 37711:
                    MessageBox.Show("You're unable to do any damage to the rusty bars with the stone tablet.");
                    break;
                case 43105:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then this door is open and Monte steps out. \"Thank you so very " +
                        "much! free at last!\" He sighs with relief. \"Please allow me to accompany you. I've " +
                        "worked in the mines and passageways for so long, my knowledge of them is sure to be " +
                        "of help to you!\"");
                    //remove card 43 from inventory
                    AdventureCardDatabase.RemoveCard(43);
                    //add card 74 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 74);
                    break;
                case 43205:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then the door i s open. The prisoner steps out and shakes your " +
                        "hand. \"At last I'm out of that cramped cell. I'm eternally grateful to you!\" At this, he " +
                        "bows down in front of you. \"My name is Jin by the way and it would be my pleasure " +
                        "to accompany you. Who knows, maybe my knowledge of gemstones will prove useful!\"");
                    //remove card 43 from inventory
                    AdventureCardDatabase.RemoveCard(43);
                    //add card 75 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 75);
                    break;
                case 43304:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. The final drop of metal has only just fallen to the ground when the " +
                        "door bursts open and the prisoner comes barreling out with a huge grin on her " +
                        "face. \"How can I possibly thank you for freeing me?\" She gives you a wide smile, " +
                        "but then suddenly remembers something. \"Oh! please excuse my manners. " +
                        "My name is Nuha. Allow me to accompany you. There are sure to be more secrets " +
                        "of the League down here. Riddles are my specialty, so I could help you with that!\"");
                    //remove card 43 from inventory 
                    AdventureCardDatabase.RemoveCard(43);
                    //add card 76 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 76);
                    break;
                case 43404:
                    MessageBox.Show("With slightly trembling hands, you pour the aqua regia over the lock. The " +
                        "liquid has barely touched the precious metal when it begins to bubble and then, " +
                        "as if by magic, to dissolve before your eyes. It takes a while for the lock to dissolve " +
                        "completely. But then the door is open. The prisoner cautiously sticks her " +
                        "head out and looks around. When she sees you, she says grumpily, \"You again, I " +
                        "suppose I owe you something for getting me out.\" She steps out, draws herself up to " +
                        "her full impressive height, and gives you a nod. \"Brigh's my name. I'll come with " +
                        "you. If you get into a fight, then you can count on me. But as soon as we get out of " +
                        "here, we will go our seperate ways.\"");
                    //remove card 43 from inventory
                    AdventureCardDatabase.RemoveCard(43);
                    //add card 77 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 77);
                    break;
                case 43502:
                    MessageBox.Show("Aqua regia only affects gold. It's useless when it comes to silver.");
                    break;
                case 43707:
                    MessageBox.Show("There is nothing here that aqua regia could melt.");
                    break;
                case 43802:
                    MessageBox.Show("Aqua regia only affects gold. It's useless when it comes to silver.");
                    break;
                case 45211:
                    MessageBox.Show("Take the left fork. The map will show you the way.");
                    break;
                case 45311:
                    MessageBox.Show("Take the right fork. The map will show you the way.");
                    break;
                case 46207:
                    MessageBox.Show("When you attemot to shove the rat into the oven, it bites you before " +
                        "scurrying off. It was only playing dead! You lose 1 health point and the rat.");
                    //subtract 1 hp from player
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    //remove card 46 from inventory
                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 47111:
                    MessageBox.Show("You toss the ham to the rats and they immediately pounce it. But " +
                        "what's that? A rat nabs a piece and scurries off into the darkness.");
                    //remove card 47 from inventory
                    AdventureCardDatabase.RemoveCard(47);
                    break;
                case 47711:
                    MessageBox.Show("The prisoner eyes the ham hungrily. \"Give it here!\" She grabs it greedily " +
                        "and bites a piece off. \"Beetles are crunchier, but this is simply heaven!\" She rolls " +
                        "her rolls eyes in rapture and continues to eat noisily. Once she has finished her meal, " +
                        "she turns to you: \"So then, a favor for a favor. Take this gemstone. I've no use for it " +
                        "here in this cell.\" You recieve {card 65}");
                    //remove card 47 from inventory
                    AdventureCardDatabase.RemoveCard(47);
                    //add card 65 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 65);
                    break;
                case 49203:
                    MessageBox.Show("The rope is too short to reach the bottom of the shaft.");
                    break;
                case 49303:
                    MessageBox.Show("The shaft is so shallow, you don't need a rope to climb down.");
                    break;
                case 49403:
                    MessageBox.Show("The rope is too short to reach the bottom of the shaft.");
                    break;
                case 49410:
                    MessageBox.Show("Unfortunately, the rope is too short to reach the bottom of the ravine.");
                    break;
                case 50711:
                    MessageBox.Show("You'd better not, else the jewelry box will break.");
                    break;
                case 51111:
                    MessageBox.Show("The rats retreat at your approach.");
                    break;
                case 51203:
                    MessageBox.Show("The rope is too short to reach the bottom of the shaft.");
                    break;
                case 51303:
                    MessageBox.Show("The shaft is so shallow, you don't need a rope to climb down.");
                    break;
                case 51401:
                    MessageBox.Show("You slowly lower the hook attatched to the rope through the grating down " +
                        "towards the sewer. Maybe you'll be able to catch something with it. Moments " +
                        "later, your improvised fishing rod does indeed catch onto something solid. You " +
                        "carefully draw the ropw back up again to examine your catch. You recieve {card 60}");
                    //add card 60 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 60);
                    break;
                case 51403:
                    MessageBox.Show("The rope is too short to reach the bottom of the shaft.");
                    break;
                case 51410:
                    MessageBox.Show("Unfortunately, the rope with a hook is too short to reach the bottom of " +
                        "the ravine.");
                    break;
                case 51415:
                    MessageBox.Show("You're unable to do any damage to the inscription or the stone with the " +
                        "hook.");
                    break;
                case 51701:
                    if (MessageBox.Show("Summoning all your strength, you bring the hook crashing down on the " +
                    "metal box.You manage to create a wide opening, Do you want to reach inside ?", "Metal box", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdventureCardDatabase.CreateCard(ref inventory, 14);
                    }
                    break;
                case 51711:
                    MessageBox.Show("You hit the rusty bars. Then try pulling on them. They don't budge.");
                    break;
                case 52111:
                    MessageBox.Show("You toss the cheese to the rats and they immediately pounce on it. " +
                        "But what's that? A rat nabs a piece and scurries off into the darkness.");
                    //remove card 52 from inventory
                    inventory.RemoveAt(inventory.FindIndex(p => p.ID == 52));
                    AdventureCardDatabase.RemoveCard(52);
                    //read entry 888
                    MessageBox.Show("Curious, you follow it. Several passage ways branch off and at one point, " +
                        "you think you hear the sound of water. The rat doesn't let itself be distracted, " +
                        "though, and continues to scamper along happily. You finally reach a gloomy " +
                        "chamber filled with spider webs. You struggle to keep sight of the rat in the dim " +
                        "light. Suddenly, it scurries behind a shapeless form and moments later you hear " +
                        "the sound of gnawing. You creep closer and find yourself standing next to an egg " +
                        "shaped object that you notice is giving off a fair amount of heat. That's what drew " +
                        "the rat here! Pretty smart. It has now finished its meal and turns its little eyes up " +
                        "to look at you expectantly.");
                    //add cards 61 and 91 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 61);
                    AdventureCardDatabase.CreateCard(ref inventory, 91);
                    //move player to room card N
                    MainForm.OpenLocation('N') ;

                    break;
                case 52711:
                    MessageBox.Show("The prisoner eyes the cheese hungrily. \"Give me that!\" She grabs it greedily " +
                        "and bites a piece off. \"Beetles are crunchier, but this is simply heaven!\" She rolls " +
                        "her rolls eyes in rapture and continues to eat noisily. Once she has finished her meal, " +
                        "she turns to you: \"So then, a favor for a favor. Take this gemstone. I've no use for it " +
                        "here in this cell.\" You recieve {card 65}");
                    //remove card 52 from inventory
                    AdventureCardDatabase.RemoveCard(52);
                    //add card 65 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 65);
                    break;
                case 54310:
                    MessageBox.Show("Balancing the mirror in the statue's hands so that it remains there proves " +
                        "quite tricky. You finally manage it, though, and carefully step back a few paces. " +
                        "Just at that moment, another beam of sunlight shines down from above onto " +
                        "the mirror. It is reflected across the water towards the gloomy archway so that " +
                        "the light shines on the eastern tomb, and the dark stone of the well and its " +
                        "inscription are lit up. At first, smoke rises from the inscription, then from the " +
                        "entire well begins to glow. Moments later, it bursts into flames and there " +
                        "is a powerful explosion that knocks you to the ground. " +
                        "As you come to, you peer through the cloud of dust over towards the archway, " +
                        "dazed. You can't make out anything beyond it anymore. The destructive force has " +
                        "buried the cavern with the tombs entirely under the mountain. The tremors have " +
                        "also caused the mirror to fall down and it appears to have sunk into the water. It's " +
                        "nowhere to be seen.");
                    //all players in room P are moved to room B by the explosion and lose 1 health point
                    MainForm.OpenLocation('B');
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    //remove cards 27, 28, 37, and 54 from inventory 
                    AdventureCardDatabase.RemoveCard(27);
                    AdventureCardDatabase.RemoveCard(28);
                    AdventureCardDatabase.RemoveCard(37);
                    AdventureCardDatabase.RemoveCard(54);
                    //remove room card P from map
                    MainForm.BlockLocation('P');
                    break;
                case 54711:
                    MessageBox.Show("It's not as if you couldn't do with a little help from Lady Luck down here, " +
                        "you think to yourself. With that in mind, you decide that breaking a mirror " +
                        "doesn't seem like such a good idea.");
                    break;
                case 60111:
                    MessageBox.Show("The rats retreat at your approach.");
                    break;
                case 61207:
                    MessageBox.Show("\"Wouldn't the warm oven be the perfect place to hatch a scaled egg?\" you " +
                        "think to yourself. And so you place the egg inside the oven to incubate. After " +
                        "a while, you begin to wonder what's happening inside. You curiously open the " +
                        "door and peer inside. Something moves and looks up at you with blinking little " +
                        "eyes. Can it really be a baby dragon? You recieve {card 62}");
                    //remove card 61 from inventory
                    AdventureCardDatabase.RemoveCard(61);
                    //add card 62 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 62);
                    break;
                case 61711:
                    MessageBox.Show("\"It really is a dragon's egg!\" She looks from you to the egg in amazement. " +
                        "\"Wherever you found it, you're going to have to hatch it now. It needs warmth!\" " +
                        "That's easier said than done. \"And where do you expect me to find a " +
                        "sufficiently hot fire?\" you ask. Sirona looks at you uncertainly, then shrugs her " +
                        "shoulders.");
                    break;
                case 62711:
                    MessageBox.Show("You carefully set the dragon down in front of the little barred opening. " +
                        "Sirona is litterally glued to the bars in fascination and excitement. \"Quick, " +
                        "hurry! Make it spit fire!\" But this is easier said than done. You tickle " +
                        "the little dragon's belly, then its throat. It seems to enjoy the attention, and " +
                        "nestles against your hand making soft purring noises. The baby dragon is quite " +
                        "boisterous though, and one of your fingers ends up in its nostrils when it jerks " +
                        "its head back as your stroking its throat. It looks up at you in astonishment, " +
                        "then begins to sneeze fire uncontrollably. You quickly hold it up to the bars and " +
                        "hope that it' enough. When you look back at the cell, you see that the rusty iron " +
                        "bars have indeed disintegrated. As some of Sirona's hair. She doesn't seem " +
                        "bothered though. \"Unbelievable. a real dragon! You're full of suprises. I gladly place " +
                        "my healing arts at your disposal.\" Even with the few means at her disposal, she " +
                        "manages to expertly treat your injuries, both major and minor.");
                    //all players gain 5 health points
                    //and can be divided amongst the rest however they choose. (Maybe leave out?)
                    hp += 5;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    //add card 89 
                    AdventureCardDatabase.CreateCard(ref inventory, 89);
                    break;
                case 65414:
                    MessageBox.Show("It takes alot of patience, but using the incredibly hard diamond, you " +
                        "finally manage to extract the gemstone from the crystal layer it is encased in." +
                        " You recieve Topaz.");
                    //add card 69 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 69);
                    break;
                case 70507:
                    MessageBox.Show("You want to mix the wine with the black potion. You've got a hunch that " +
                        "this is not a good idea.");
                    break;
                case 71207:
                    MessageBox.Show("The bread is already quite hard. It certainly doesn't need to be any crunchier.");
                    break;
                case 71111:
                    MessageBox.Show("You toss the bread to the rats and they immediately pounce on it. " +
                        "But what's that? A rat nabs a piece and scurries off into the darkness.");
                    //remove card 71 from inventory
                    AdventureCardDatabase.RemoveCard(71);
                    //add card 65 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 65);
                    break;
                case 71711:
                    MessageBox.Show("The prisoner looks at the bread suspiciously. \"No crunchy bugs? Okay, " +
                        "never mind.\" Then she takes the bread and begins gnawing on it rather " +
                        "unenthusiastically at first. After a time, her hunger gets the better of her, though. " +
                        "When she's finally finished her meal, she turns to you: \"At least my stomach is full " +
                        "now. Here, take this gemstone by the way of thanks. I can't eat it and it's of no use to me in " +
                        "this cell.\" You recieve { card 65 }");
                    //remove card 71 from inventory
                    AdventureCardDatabase.RemoveCard(71);
                    //add card 65 to inventory
                    AdventureCardDatabase.CreateCard(ref inventory, 65);
                    break;
                case 91207:
                    MessageBox.Show("As you attempt to trap the rat in the oven, it bites you before scurrying " +
                        "off. You lose 1 health point.");
                    //remove card 91 from inventory
                    AdventureCardDatabase.RemoveCard(91);
                    //lose 1 health point
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 132025:
                    MessageBox.Show("You turn the keys one by one, unlocking all three bronze locks and push " +
                        "the door open. At first, you're blinded by the bright sunlight. Then you realize " +
                        "that this is the way to freedom! You call your companions over and gather at the " +
                        "exit. " +
                        "The path leads across green meadows before vanishing into the distance. You eagerly " +
                        "suck in the fresh air as you approach the drawbridge. You could now breathe a sigh " +
                        "of relief, but your eyes nervously flick back and forth, fearful that you will still be " +
                        "discovered by any remaining guards. A piece of parchment lying on the ground " +
                        "catches your eye. You bend down to read it: \"Gruel for prisoners Monte, Nuha, and " +
                        "Lin. As punishment, no food for Brigh in 404. 2 guards to Berengar in the tower.\" " +
                        "So your old friend Berengar is also locked up here and well guarded! At least he " +
                        "was until most of the guards fled. You can't abandon him and decide to free him, " +
                        "too. With renewed courage, you return to the dungeon with a new mission firmly " +
                        "in sight.");
                    //remove cards 13, 20, 25, from inventory

                    AdventureCardDatabase.RemoveCard(13);
                    AdventureCardDatabase.RemoveCard(20);
                    AdventureCardDatabase.RemoveCard(25);

                    // Take Adventure Card 67.
                    MessageBox.Show("You got some rest before you continued your journey. You gain up to 6 health points.","Beginning of Chapter II");
                    hp += 6;
                    LocEntry(ref inventory,ref hp,name,id:200);
                    //reveal room card F above room Q
                    MainForm.OpenLocation('F');

                    //Possibly show conclusional message.


                    break;
                case 347504:
                    MessageBox.Show("You carefully tread on the step with three marks, then the one with four. " +
                        "With a spring in your step, you then leap onto the step with seven marks. Well " +
                        "fancy that, the steps remain intact. A short while later, you reach the top of the " +
                        "staris! You open the trapdoor in the ceiling leading up into the tower and climb through. " +
                        "Suddenly, you hear a low growl and something very large comes bounding out of " +
                        "the shadows towards you. As if turned to stone, you remain rooted to the spot, " +
                        "and a chill goes down your spine. " +
                        "It's the beast - and it's more terrible than you imagined in your worst " +
                        "nightmares! With a defeaning roar, the beast launches itself towards you, swiping " +
                        "at you with its paws.");
                    //remove card 79 from inventory
                    AdventureCardDatabase.RemoveCard(79);
                    //reveal room card K above room H.
                    MainForm.frm.beastAlive = true;
                    MainForm.OpenLocation('K');
                    //Place card 55 face up in the middle of room K

                    //is card 77 in a players inventory?
                    if (inventory.FindIndex(p => p.ID == 79) > -1)
                    {
                        //read entry 447
                        MessageBox.Show("When Brigh realizes you're in danger, she valiantly throws herself between " +
                            "you and the beast. With her incredible strength, she's able to keep the monster " +
                            "at bay while you wuickliy flee through the trapdoor. " +
                            "Hot on your heels, Brigh squeezes through the trapdoor right " +
                            "behind you and just manages to close it in time. Amazingly, she has only suffered " +
                            "a few scratches. \"The beast isn't that terrible,\" she whispers before limping past you " +
                            "down the steps.");
                    }
                    else
                    {
                        //read entry 547
                        MessageBox.Show("Before you can even react, the beast has pounced on you and inflicted " +
                            "deep wounds to your arm and cheek. Taken by suprise, you stumble backwards " +
                            "through the trapdoor. As luck would have it, you managed to slam the trapdoor " +
                            "closed behind you as you fall.");
                        //lose 2 hp
                        if (hp > 2)
                            hp -= 2;
                        else if (hp == 2)
                            hp--;
                        AdventureCardDatabase.ChangeHP(hp,name);

                    }
                    //place player in room card H
                    MainForm.OpenLocation('H');

                    break;
                case 485214:
                    MessageBox.Show("You adjust the combination on the little cogs. Shortly thereafter, you " +
                        "hear an audible click inside the device and it noisily starts up. The trickle that " +
                        "previously flowed out of the wall turns into a raging torrent, causing the water " +
                        "level in the chamber to rise noticebly. \"Let's get out of here!\" you shout, and make " +
                        "for the door. The water is already up to your knees by the time you reach the " +
                        "mighty stone door and close it behind you." +
                        "After a while, the chamber has been filled with water. It then seeps through the " +
                        "opening in the ceiling and gradually begins to fill the ravine.");
                    //place all players, that are in room O, to room N
                    MainForm.OpenLocation('B');
                    //remove cards 53, 56, and 63 from inventory

                    AdventureCardDatabase.RemoveCard(53);
                    AdventureCardDatabase.RemoveCard(56);
                    AdventureCardDatabase.RemoveCard(63);
                    //remove room O
                    MainForm.BlockLocation('O');
                    //place all players, that are in room L, to room B

                    //remove room L
                    MainForm.BlockLocation('L');
                    //read entry B
                    LocEntry(ref inventory, ref hp, name,entry:'B');
                    break;
                default:
                    MessageBox.Show("Nothing happens.");
                    break;
            }
            if(MainForm.frm.Countdown == 0)
                MainForm.frm.CountDownFinished();
        }
        // This method evaluates item and item combination entries.
        public static void ItemsEntryEval(ref List<Card> cards,ref int hp, string name, int entry)
        {
            if (MainForm.frm.beastAlive && MainForm.frm.locationCurrently == 'K')
            {
                if (hp > 1)
                    hp--;
            }
            if (MainForm.frm.endOfGame)
            {
                MainForm.frm.Countdown--;
            }
            switch (entry)
            {
                case 1011:
                    MessageBox.Show("The iron bar fits in the hole in the brick almost perfectly! This makeshift hammer will surely have some power behind it. Discard Adventure Cards 10 and 11.");
                    AdventureCardDatabase.CreateCard(ref cards, 12);
                    AdventureCardDatabase.RemoveCard(10);
                    AdventureCardDatabase.RemoveCard(11);
                    break;
                case 1424:
                    MessageBox.Show("Cutting up the map isn't such a good idea. You might still need it.");
                    break;
                case 1433:
                    MessageBox.Show("You sprinke a little powder on the map, but no secret messages are revealed.");
                    break;
                case 1724:
                    MessageBox.Show("You've better things to do than to whittle a broom!");
                    break;
                case 1824:
                    MessageBox.Show("Cutting up the comfrey without real purpose does seem like a good idea to you.");
                    break;
                case 1826:
                    MessageBox.Show("A pleasantly cool feeling spreads around the wound as you apply the paste of masticated comfrey. Adventure cards 18 and 26 are discarded.");
                    AdventureCardDatabase.RemoveCard(18);
                    AdventureCardDatabase.RemoveCard(26);
                    break;
                case 1878:
                    MessageBox.Show("You eat the medicinal herb. Just a few heart beats later, you feel the madness begin to subside. Finally! Discard Adventure card 18 and take adventure card 86.");
                    AdventureCardDatabase.RemoveCard(18);
                    AdventureCardDatabase.CreateCard(ref cards, 86);
                    break;
                case 2426:
                    MessageBox.Show("'This is gonna hurt, but it can't be helped. The poison has to come out!' Teeth gritted, you carefully cut into the bite wound. You almost pass out from the pain, but you manage to pull yourself together and quickly suck the poison out. The wound still throbs, but if you're lucky, you might have prevented something worse. You take one point of damage. Discard Adventure card 26.");
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    AdventureCardDatabase.RemoveCard(26);
                    break;
                case 2446:
                    MessageBox.Show("'Now to finish you off!', you mutter and raise the knife high above your head. The rat is only playing dead though and clearly still has plenty of life in it. In a flash, it bites your finger. You drop the rat in suprise, and it takes to its heels and flees into a crevice. You take one point of damage. Discard Adventure card 46.");
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 2447:
                    MessageBox.Show("There is no use in cuttinng the piece of ham into tiny bits.");
                    break;
                case 2452:
                    MessageBox.Show("There is no use in cutting the cheese.");
                    break;
                case 2471:
                    MessageBox.Show("There is no use in cutting the bread into tiny bits.");
                    break;
                case 2670:
                    MessageBox.Show("As you don't know what the potin might do, it is too risky to pour it on the spider bite.");
                    break;
                case 2733:
                    MessageBox.Show("You sprinkle a little powder on the scroll, but nothing happens.");
                    break;
                case 2741:
                    MessageBox.Show("Nice Try-- but you're going to have to decipher it yourselves!");
                    break;
                case 2742:
                    MessageBox.Show("Nice Try-- but you're going to have to decipher it yourselves!");
                    break;
                case 2850:
                    MessageBox.Show("The silver key doesn't fir in the lock of the little box.");
                    break;
                case 2858:
                    MessageBox.Show("You use the key to quickly brush the scorpian off and it scuttles away. Discard Adventure Card 58");
                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 2859:
                    MessageBox.Show("You use the key to quickly brush the giant leech off and it crawls away.");
                    AdventureCardDatabase.RemoveCard(59);
                    break;
                case 2888:
                    MessageBox.Show("You'd better not, else the beast will swallow the key.");
                    break;
                case 2955:
                    MessageBox.Show("It won't be enough to defeat the beast.");
                    break;
                case 3046:
                    MessageBox.Show("'Now to finish you off!' you mutter and raise the bottle high above your head. The rat is only playing dead though and clearly still has plenty of life in it. In a flash, it bites your finger. You drop the rat in surprise, and it takes to its heels and flees into a crevice. You take one point of damage. Discard Adventure Card 46.");
                    if(hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 3055:
                    MessageBox.Show("With a bottle? Seriously? Come on no, you're not Chuck Norris. You're going to need more than that to defeat the beast.");
                    break;
                case 3132:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3135:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3138:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3139:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3143:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3146:
                    MessageBox.Show("You consider for a moment whether to use it to kill the rat. It would be a shame to wate the wine though. You take a swig from the bottle instead, and it helps to calm your nerves again.");
                    break;
                case 3155:
                    MessageBox.Show("Drinking the beast under the table sounds rather imprudent...");
                    break;
                case 3170:
                    MessageBox.Show("It would be a shame to spoil the good wine.");
                    break;
                case 3175:
                    MessageBox.Show("Jin literally tears the bottle from your hands. He swallows it in a single gulp, as if he were dying of thirst.\n 'Not bad,' he says as he wipes a few drops of the liquid from his sparse beard and emphasizes his contentment with a hearty belch.\n Then he pats down his ragged clothes and pulls out a crumpled piece of parchment. 'Here, take this. It might be useful to you.' Adventure Card 31 is discarded. Take Adventure Card 42.");
                    AdventureCardDatabase.RemoveCard(31);
                    AdventureCardDatabase.CreateCard(ref cards, 42);
                    break;
                case 3235:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal. Mixing it with another poition isn't such a good idea");
                    break;
                case 3238:
                    MessageBox.Show("You carefully mix the two potions and the liquid begins to bubble. Suddenly, it begins to glow in a purple hue! Adventure Cards 32 and 38 are discarded. Take Adventure Card 39.");
                    AdventureCardDatabase.RemoveCard(32);
                    AdventureCardDatabase.RemoveCard(38);
                    AdventureCardDatabase.CreateCard(ref cards, 39);
                    break;
                case 3243:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal. Mixing it with another poition isn't such a good idea");
                    break;
                case 3255:
                    MessageBox.Show("What if the potion doesn't have any effect and your left at the beast's mercy? No, the risk is simply too great.");
                    break;
                case 3270:
                    MessageBox.Show("You carefully dribble a few drops of the blue potion into the black one. The mixture bubbles and foams, then turns grey. You tentatively try a sip and a warm feeling spread through your body. You recover back up to 2 health points. Adventure Card 38 is discarded.");
                    hp+=2;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    AdventureCardDatabase.RemoveCard(38);
                    isdone = true;
                    break;
                case 3278:
                    MessageBox.Show("What the devil?! Are you mad?");
                    break;
                case 3337:
                    MessageBox.Show("Nothing about the stone tablet changes.");
                    break;
                case 3340:
                    MessageBox.Show("You sprinkle a little powder on the parchment and a secret message is revealed! Adventure Card 40 is discarded. Take Adventure Card 41. If you have Adventure Card 76, read entry 902.");
                    AdventureCardDatabase.RemoveCard(40);
                    AdventureCardDatabase.CreateCard(ref cards, 41);
                    if (cards.FindIndex(p => p.ID == 76) != -1)
                        LocEntry(ref cards,ref hp, name,902);
                    break;
                case 3341:
                    MessageBox.Show("The parchment doesn't reveal any more secrets.");
                    break;
                case 3342:
                    MessageBox.Show("The Powder does not draw any more secrets from the parchment.");
                    break;
                case 3345:
                    MessageBox.Show("You sprinkle a little powder on the map and for a moment, you see a fie egg in the chamber with spider webs. Then it is gone again.");
                    break;
                case 3355:
                    MessageBox.Show("The powder will probably onyl have an effect if the beast happens to be allergic to it. No, the risk is simply too great.");
                    break;
                case 3372:
                    MessageBox.Show("The powder does not draw any more secrets from the page");
                    break;
                case 3538:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 3539:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 3543:
                    MessageBox.Show("Let's put it this way: that'll mean more yellow potion.");
                    break;
                case 3555:
                    MessageBox.Show("What if the potion doesn't have any effect and you're left at the beast's mercy? No, the risk is simply too great.");
                    break;
                case 3570:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 3578:
                    MessageBox.Show("The pungent smell of burned metal only reaches your nose as you're holding the little vial up to your lips. Drinking is doesnt seem like such a good idea after all.");
                    break;
                case 3646:
                    MessageBox.Show("'Now to finish you off!' you mutter and raise the hook high above your head. The rat is only playing dead though and clearly still has plenty of life in it. In a flash, it bites your finger. You drop the rat in surprise, and it takes to its heels and flees into a crevice. You take 1 point of damage and Adventure Card 46 is discarded.");
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);

                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 3649:
                    MessageBox.Show("You deftly thread the rope through the hook's eye and secure it tightly. Adventure Cards 36 and 49 are discarded and you take Adventure Card 51. If you have Adventure Card 74, then read entry 475.");
                    AdventureCardDatabase.CreateCard(ref cards, 51);

                    AdventureCardDatabase.RemoveCard(36);
                    AdventureCardDatabase.RemoveCard(49);
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                        LocEntry(ref cards, ref hp, name,475);
                    break;
                case 3650:
                    MessageBox.Show("You'd better not. WHo knows what's in it?");
                    break;
                case 3658:
                    MessageBox.Show("You use the hook to quickly brush the scorpian off and it scuttles away. Adventure Card 58 is discarded.");
                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 3661:
                    MessageBox.Show("Unbelievable! That didn't even leave a scratch!");
                    break;
                case 3688:
                    MessageBox.Show("You hit the electric eel a few times and it finally lets you go. Adventure Card 88 is discarded. If you have Adventure Card 74, read entry 575.");
                    AdventureCardDatabase.RemoveCard(88);
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                        LocEntry(ref cards, ref hp, name,575);
                    break;
                case 3746:
                    MessageBox.Show("'Now to finish you off!' you mutter and raise the stone tablet high above your head. The rat is only playing dead though and clearly still has plenty of life in it. In a flash, it bites your finger. You drop the rat in surprise, and it takes to its heels and flees into a crevice. You take 1 point of damage, and Adventure Card 46 is discarded.");
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);

                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 3843:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 3855:
                    MessageBox.Show("What if the potion doesn't have any effect and you're left at the beast's mercy? No, the risk is simply too great.");
                    break;
                case 3870:
                    MessageBox.Show("You carefully dribble a few drops of the red potion into the black one. The mixture glows briefly, then turns orange.You tentatively try a sip and a warm feeling spreads through your body. You regain up to 3 health points, and Adventure Card 70 is discarded.");
                    AdventureCardDatabase.RemoveCard(70);
                    hp += 3;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 3878:
                    MessageBox.Show("Holding your nose closed, you gulp down the red potion. Just a few heartbeats later, you feel the madness begin to subside.Finally! Take Adventure Card 86");
                    AdventureCardDatabase.CreateCard(ref cards, 86);
                    break;
                case 3943:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 3955:  //END OF CHAPTER II
                    MessageBox.Show("The beast is now just a few paces away. “You'd better make this a good throw, or you've had it!” you think to yourself.Summoning all your strength, you hurl the glowing purple potion towards the beast.As if by reflex, the beast's mighty jaws clamp down on the bottle and crush it. Most of the potion goes down the beast's throat; the rest splashes on its body. With burning eyes it  attempt a final few steps towards you.Then a look of surprise flashes across its face, followed by a mixture of pain and panic. The potion is working! Moments later, the monster collapses with its limbs spasming, leaving deep furrows in the ground with every swipe of its paws. With a final howl, the beast turns to dust before your eyes.The noise brings the rest of your group to the tower. As you pat each other on the back, a sound from the throne startles you. There’ssomeone there! A shrunken figure in robes emerges from the shadows.It's your old friend Berengar! ‘Were so glad we’re finally found yaw!It mint have been terrible to be lacked in here iuith the best.” Berengar eyes you with a look of annoyance on his face. “Lacked in?” He echoes — in a cold voice ? ”I msume you re still suffering fram amnesia!” You stop short. “that da you mean...?” “Allow me to refresh your memory a little. I'm not a prisoner here, Init rather the Grand Master of the League of Guardians.And until just recently, you were my loyal comrades-in-arms.At least you u'ereuntil your treacherous betrayal!” You can hardly believe your ears! Berengar continues, unmoved: “Dent go thinking , you cdn Stop me. have defeated that one stone golem, but beneath the. fervors countless more await rbeir revival. Tft6 the invincibk army I will take the Kingdom by storm!” Your thoughts are racing. the shock brings back some of your lost memories and .the bitter realization that Berengar is indeed telling the truth. You were members of the League of Guardians. And now it's entirely up to you to stop him. Well done! You've successfully defeated the beast. This concludes Chapter 2." +
                        "Adventure cards 14, 39, 41, 42, and 55 are discarded. You are all now in Room Card K.");
                    MainForm.OpenLocation('K');
                    MessageBox.Show("As you pat each other on the back, a sound from the throne startles you. There's someone there! A shrunken figure in robes emerges from the shadows. It's your old friend Berengar! \"We are so glad we've finally found you!It must have been terrible to be locked in here with the beast.\" Berengar eyes you with a look of annoyance on his face. \"Locked in?\" He echoes — in a cold voice? \"I assume you're still suffering from amnesia!\" You stop short. \"What do you mean...?\" `Allow me to refresh your memory a little. I'm not a prisoner here, but rather the Grand Master of the League of Guardians.And until just recently, you were my loyal comrades-in¬arms.At least you were until your treacherous betrayal!\" You can hardly believe your ears! Berengar continues, unmoved: \"Don't go thinking you can stop me. You may have defeated that one stone golem, but beneath this fortress countless more await their revival. With this invincible army, I will take the kingdom by storm!\" Your thoughts are racing. The shock brings back some of your lost memories and the bitter realization that Berengar is indeed telling the truth. You were members of the League of Guardians. And now it's entirely up to you to stop him. Well done! Chapter 2 is finished! The next chapter can now begin.");
                    MessageBox.Show("After some rest, your group gains up to 8 health points. Now read entry 300.");
                    hp += 8;
                    AdventureCardDatabase.ChangeHP(hp,name);

                    AdventureCardDatabase.RemoveCard(14);
                    AdventureCardDatabase.RemoveCard(39);
                    AdventureCardDatabase.RemoveCard(41);
                    AdventureCardDatabase.RemoveCard(42);
                    // Beast is beaten
                    MainForm.frm.beastAlive = false;
                    MainForm.OpenLocation('K');
                    // Put focus on Room Card K.
                    LocEntry(ref cards,ref hp,name,id:300);
                    break;
                case 3970:
                    MessageBox.Show("You carefully dribble a few drops of the purple-potion into the black one: The mixture begins to froth and.turns pink, releasing a tempting aroma.You tentatively try a sip and a feeling of warmth and well - being spreads through your body. There is enough for the whole party. You regain up to 4 health points, and Adventure Card 70 is discarded.");
                    AdventureCardDatabase.RemoveCard(55);
                    hp += 4;
                    break;
                case 4370:
                    MessageBox.Show("The yellow potion gives off a pungent stench of burned metal . Mixing it with another potion isn't such a good idea.");
                    break;
                case 4378:
                    MessageBox.Show("The pungent smell of burned metal only reaches your nose as you're holding the little vial up to your lips. Drinking is doesnt seem like such a good idea after all.");
                    break;
                case 4647:
                    MessageBox.Show("Maybe some ham will help to revive the rat ? After all, they're meant to be highly intelligent  little creatures.You gently take the rat in your hand and hold out the food to it.And indeed, its nose gives a twitch.It really was only playing dead then! The rat eyes your offering suspiciously. Then it takes a tentarive bite, jumps off your hand, and slowly patters off into the darkness. Read entry 888.");
                    LocEntry(ref cards,ref hp, name,id:888);
                    break;
                case 4649:
                    MessageBox.Show("The rat wouldn't need to be Houdini to escape being tied up in such a thick rope!");
                    break;
                case 4650:
                    MessageBox.Show("As you lift the jewelry box, you hear a muf8ed clank that distracts you. Who knows, maybe treating it roughy isn't such a good idea ...");
                    break;
                case 4651:
                    MessageBox.Show("'Now to finish you off!' you mutter and raise the hook high above your head. The rat is only playing dead though and clearly still has plenty of life in it. In a flash, it bites your finger. You drop the rat in surprise, and it takes to its heels and flees into a crevice. You take 1 point of damage, and Adventure Card 46 is discarded.");
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);

                    AdventureCardDatabase.RemoveCard(46);
                    break;
                case 4652:
                    MessageBox.Show("Maybe a little cheese will help to revive the rat ? After all, they're meant to be highly intelligent  lime creatures.You gently take the rat in your hand and hold out the food to it.And indeed, its nose gives a twitch.It really was only playing dead then! The rat eyes your offering suspiciously. Then it takes a tentarive bite, jumps off your hand, and slowly patters off into the darkness. Read entry 888.");
                    LocEntry(ref cards, ref hp, name,id:888);
                    break;
                case 4654:
                    MessageBox.Show("If only you still had your hairdressing kit, you could spruce the rat up a bit. It probably wouldn't like that though.");
                    break;
                case 4660:
                    MessageBox.Show("The mighty relic does not turn the rat to dust. So the little creature obviously does not pose a threat to the League of Guardians.");
                    break;
                case 4671:
                    MessageBox.Show("Maybe a little bread will revive the rat? After all, they're meant to be highly intellegent little creatures. You gently take the rat into your hand and hold out the food to it. And indeed, its nose gives a twitch. It was only playing dead then! The rat eyes your offering suspiciously. Then it dares a bite, jumps off your hand, and scurries off into the darkness. Read entry 888.");
                    LocEntry(ref cards, ref hp, name,888);
                    break;
                case 4789:
                    MessageBox.Show("Thanks, perhaps later. Now we've got more important things to tend to.");
                    break;
                case 4850:
                    MessageBox.Show("The necklace's pendant is the same shape as the groove in the box. When you insert the pendant, the lock opens with a soft click to reveal its contents. Adventure cards 48 and 50 are discarded. Take Adventure Card 54.");
                    AdventureCardDatabase.CreateCard(ref cards, 48);
                    AdventureCardDatabase.CreateCard(ref cards, 50);

                    AdventureCardDatabase.RemoveCard(54);
                    break;
                case 5051:
                    MessageBox.Show("You'd better not. Who knows what's in it.");
                    break;
                case 5058:
                    MessageBox.Show("You use the little box to brush off the scorpion and it scuttles away. Adventure Card 58 is discarded.");

                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 5059:
                    MessageBox.Show("You use the little box to brush off the leech and it crawls away. Adventure Card 59 is discarded.");

                    AdventureCardDatabase.RemoveCard(59);
                    break;
                case 5088:
                    MessageBox.Show("You'd better not. Who knows what's in it.");
                    break;
                case 5158:
                    MessageBox.Show("You use the hook to brush off the scorpion and it scuttles away. Adventure Card 58 is discarded.");

                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 5159:
                    MessageBox.Show("You use the hook to brush off the leech and it crawls away. Adventure Card 59 is discarded.");

                    AdventureCardDatabase.RemoveCard(59);
                    break;
                case 5161:
                    MessageBox.Show("Incredible, there's not even a scratch on the egg.");
                    break;
                case 5188:
                    MessageBox.Show("You hit the eel a few times and it lets you go. Adventure Card 88 is discarded. If you have Adventure Card 74, read entry 575.");
                    
                    AdventureCardDatabase.RemoveCard(88);
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:575);
                    }   
                    break;
                case 5356:
                    MessageBox.Show("In the right light, the two Mother of Pearl tiles shine brightly. You notice that they've been cut differently.");
                    break;
                case 5363:
                    MessageBox.Show("In the right light, the two Mother of Pearl tiles shine brightly. You notice that they've been cut differently.");
                    break;
                case 5458:
                    MessageBox.Show("You use the mirror to brush off the scorpion and it scuttles away. Adventure Card 58 is discarded.");
                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 5459:
                    MessageBox.Show("You use the hook to brush off the leech and it crawls away. Adventure Card 59 is discarded.");

                    AdventureCardDatabase.RemoveCard(59);
                    break;
                case 5488:
                    MessageBox.Show("Even if the eel is vain, the mirror might get damaged!");
                    break;
                case 5663:
                    MessageBox.Show("In the right light, the two Mother of Pearl tiles shine brightly. You notice that they've been cut differently.");
                    break;
                case 5860:
                    MessageBox.Show("You use the scepter to brush off the scorpion and it scuttles away. Adventure Card 58 is discarded.");

                    AdventureCardDatabase.RemoveCard(58);
                    break;
                case 5960:
                    MessageBox.Show("You use the scepter to brush off the leech and it crawls away. Adventure Card 59 is discarded.");

                    AdventureCardDatabase.RemoveCard(59);
                    break;
                case 6061:
                    MessageBox.Show("It sounds like something is scratching from the inside of the shell. The egg itself, however, remains unchanged.");
                    break;
                case 6066:
                    MessageBox.Show("Berengar flinches as he sees the scepter.");
                    break;
                case 6088:
                    MessageBox.Show("You hit the eel a few times and it lets you go. Adventure Card 88 is discarded. If you have Adventure Card 74, read entry 575.");
                    AdventureCardDatabase.RemoveCard(88);
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                    {
                        LocEntry(ref cards, ref hp, name, 575);
                    }
                    break;
                case 6291:
                    MessageBox.Show("The pair eye each other suspiciously. Then the rat tries to nestle up against the baby dragon's warm body. The dragon snaps at the rat, though, causing it to retreat back into your sleeve.");
                    break;
                case 7189:
                    MessageBox.Show("Thanks, perhaps later. Now we've got more important things to tend to.");
                    break;
                default:
                    MessageBox.Show("You cannot combine these items!");
                    break;
            }
            if (MainForm.frm.Countdown == 0)
                MainForm.frm.CountDownFinished();
        }
        // This method evaluates Location entries.
        public static void LocEntry(ref List<Card> cards,ref int hp, string name, int id = 0, char entry = 'x')
        {

            if (MainForm.frm.beastAlive && MainForm.frm.locationCurrently == 'K')
            {
                if (hp > 1)
                    hp--;
            }
            if (MainForm.frm.endOfGame)
            {
                MainForm.frm.Countdown--;
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string path = @"InputFiles\\LocationIDs.txt";
            string[] entries = File.ReadAllLines(path);
            int index = 0;
            DialogResult result;
            bool haveExplored = false;
            bool hasdone = false;
            switch (entry)
            {
                case 'A':
                    MessageBox.Show("As you look around the cell, a huge locked wooden door (101) with several scratches in it (201) immediately catches your eye. In front of it, there is a grating in the floor (401). On the bunk, you see a box (701) and beneath it, something may be hidden in the shadows (601). A brick juts out of the wall to your left (501), while a skeleton clad in heavy iron chains hangs to your right (301). Moonlight floods into the cell through a barred window.", "Entry A");
                    break;
                case 'B':
                    MessageBox.Show("The ravine is filled with water and you can now reach the stone archway (510).", "Entry B");
                    break;
                case 'C':
                    MessageBox.Show("You find yourself standing in a hallway with four more doors. Two have golden locks (105 & 205); One of the doors is open (305). A sign hangs above the doorway on your far right(803). A symbol has been etched into the wall above the stairway leading up (403) between the doors.There are three levers sunk into the floor(505, 603, 703).","Entry C");
                    break;
                case 'D':
                    MessageBox.Show("The massive wooden portal is secured with three bronze locks (109}. Whatever lies behind it must be pretty important! To the lefr of the portal is a pile of wood(209). Thick Splder webs cover the ceilIng(509) and there is something scowled on the walt to the let(609). just close to you, a stone slab sticks up a little from the ground (409) to the right of which srands a barrel(309). A large stone mask casts its gruesome gaze down on you from above the portal.", "Entry D");
                    break;
                case 'E':
                    MessageBox.Show("Upon entering the guards' quarters, you see a table (107), oven (207), shelf (607) and cupboard(307) to your left, and a barrel(507) as well as s door(707)", "Entry E");
                    break;
                case 'F':
                    MessageBox.Show("A note (212) hangs to your left and to your right is a box (312). A drawbridge spans a deep ravine down the center(112).", "Entry F");
                    break;
                case 'G':
                    MessageBox.Show("You've discovered some sort of labrotory. Stairs continue on upwards (202) to your left. To your right is a door (502), and there is a trapdoor in the floor in front of it(802). Both have a silver lock. Shelves crammedwith books(102), bottles, tinctures(302), and other curious items line the walls At the center of the chamber is a vast wooden table(602) laden with glass vials and pots containing liquids(402), along with a few cans and Jars(702). ", "Entry G");
                    break;
                case 'H':
                    MessageBox.Show("On your way up, you pass a colorful window (104), then a few notes pinned to tile wall (204), two doorS secured with golden locks(304, 404), and several steps wirh strange markings(504).", "Entry H");
                    break;
                case 'I':
                    MessageBox.Show("the secret passageway leads to a mine beneath the castle. the rubble littering the area suggests that digging took place here until just recently.  three large shafts lead Further into the depths (203, 303, 403). there’s also a notice hanging from a beam(503).", "Entry I");
                    break;
                case 'J':
                    MessageBox.Show("The ceiling over the ivy-covered wall (308) has collapsed, allowing in a little light from the mine. At the chamber's center is a large stone tomb (208). A sacrificial bowl (108) has been placed beside it. To the left, you can make out a crumbling statue(608), along with an intact statue (508) and a heap of sand(408).", "Entry J");
                    break;
                case 'K':
                    MessageBox.Show("You find yourself in a very dark ruom with 8 large stone throne at its cencer (113). A menacing skull hangs above the throne(213). Huge banners hang from the ceiling to the left and right of the chair (313).", "Entry K");
                    break;
                case 'L':
                    MessageBox.Show("After a few dozen paces, you follow a staircase down into a vast underground chamber. A deep  ravine runs down the middle(410).Digging has also been going on here — heaps of earth lie scattered around here and there(210).Suddenly, a few rays of light shine down from the high ceiling and illuminate the chamber, allowing you to also make out a well(110)and a statue (310) at the chamber's center.", "Entry L");
                    break;
                case 'M':
                    MessageBox.Show("This is obviously a torture chamber. Ar the room's center is a stretching rack (506) and you can make out numerous iron implements hanging on the wall behind it(606). three skulls hang to your left (106, 206, 306) beside a loose chain (406). there is a large grating in the floor (706}. Suddenly, you have a vision: As through a veil, you see a different room.You see skulls there, too — but considerably larger ones. Below them, a ceremony is mking place. From a distance you watch Berengar surrounded by high rankIng members of the league. All are clad in dark robes.Your attention is drawn towards an ancient, highly ornamented scepter in rhe middle of the circle.Then you can hear Berengar say: We hereby renounce the old ways of the League of Guardians! Enough of the moderation. From today, we shall awaken the monsters ourselves! Brothers and sisters, let us banish the scepter of our founder and with it his traditional teachings! Take adventure card 85 and read it out loud.", "Entry M");
                    CreatingForm.createCharEventForm(name, hp, 85);
                    AdventureCardDatabase.CompareDatabase(ref cards,ref hp);
                    break;
                case 'N':
                    MessageBox.Show("Below a ladder recessed in the wall you can make out a dark passageway with Entries a sewage channel running down the middle.The passageway splits into a left(211) and a right(311) fork.Three musty boxes are stacked to your right(411, 511,100: You wake up from an uneasy sleep and search around in the dark, your611). You can also hear soft murmuring(711) and the scurrying of rats(Ill).eyes wide open.You still have goose bumps all over your body.Weren't you justwalking through a torchlit stone passageway? And then ... there was a noise.");
                    break;
                case 'O':
                    MessageBox.Show("Part of this chamber is flooded with water, but it seems to only be knee-deep. Or was it... a scream? That's what woke you. Now all is quiet again. Almost. The perfect opportunity to wash off at least the worst of the dirt from the sewer! For you can hear a sound — too quiet to pinpoint its location yet loud enough As you wash, you catch sight of something shimmering in the water(414). There's  to be disconcerting. How did I even end up here? you ask yourself. Trying to an opening in the vaulted ceiling high above you(114). A trickle of water flows remember makes your head hurt though, so you decide to take a look around you from a hole in the wall(314). A mechanical device has been built into the wall first. and you can hear it creaking softly(214), In the moonlight streaming in through the barred window, you slowly begin to make out details.You're lying on the stone floor of a dirty cell. A dungeon?");
                    break;
                case 'P':
                    MessageBox.Show("Several ancient tombstones line the cavernous chamber (515). Each of them You quickly look back to the window.Indeed, it is barricaded with solid iron is adorned with mysterious engravings. At the chamber's center is a basin made bars.Feeling apprehensive, you take another look around. You can make out from dark rock bearing an inscription(415). Two gargoyles flank the entrance several shapeless shadows on the floor.Yellowish light flickers under the door — (115, 215) and you spot a third on the wall(315). probably From a torch on the other side. There! Didn't one of the shadows just move? It's another human.Then you hear a");
                    break;
                case 'Q':
                    MessageBox.Show("The mask has closed its deadly mouth. You can now reach the portal (709) and woodpile(809) unscathed.");
                    break;
                case 'R':
                    MessageBox.Show(@"The door to your right is now open (807). This is where the guard must have others begin to wake up.You can't remember anything, but one name remains come from.");
                    break;
            }
            switch (id)
            {
                case 100:
                    MessageBox.Show("You wake up from an uneasy sleep and search around in the dark, your eyes wide open. You still have goose bumps all over your body. Weren't you just walking through a torchlit stone passageway? And then... there was a noise. Or was it ... a scream? That's what woke you. Now all is quiet again. Almost. For you can hear a sound -- too quiet to pinpoint its location yet loud enough to be disconcerting. How did I even end up here? you ask yourself. Trying to remember makes your head hurt though. You resolve to find out what happened to you, who improsoned you here -- and above all, how to escape this dungeon! Take mission card A1. Read entry A.","Introduction");
                    LocEntry(ref cards, ref hp, name,entry:'A');
                    MainForm.frm.missionNumber = 1;
                    CardRecieved form = new CardRecieved();
                    // add mission card A1.
                    form.pictureBox1.Image = Properties.Resources.MissionA1;
                    form.ShowDialog();
                    
                    break;
                case 101:
                    MessageBox.Show("The iron lock can only be opened with the right key");
                    break;
                case 102:
                    MessageBox.Show("On the shelf across from you are countless books, including Forbidden Alchemy Through the Ages, On Reviving Dead Beings, and The Chronicles of the a - League of Guardians,' Your interest piqued, you flip through them for a while before coming across this passage: Following lengthy negotiations, the castle built over the forgotten tombs came into the League's possession. A blank page flutters out as you turn the page.Take adventure card 40.");
                    AdventureCardDatabase.CreateCard(ref cards, 40);
                    break;
                case 104:
                    MessageBox.Show("What a colorful sight in this gloomy place! The stained glass window brings back memories of better days.But something disturbs the harmony: a piece of ponder for a second what roasted rat might taste like.A squeak draws you from the window is missing. ");
                    break;
                case 105:
                    MessageBox.Show("The first door has a little barred opening and a golden lock. Does anyone have adventure card 74 ? If so, then read entry 522.Otherwise, read entry 544.");
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:522);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp,name,id:544);
                    }
                    break;
                case 106:
                    MessageBox.Show("As you reach for the topmost skull, a giant leech suddenly crawls out of one of the eye sockets onto your arm. You quickly try to shake it off, but it has  already firmly attached itself.Take adventure card 59.");
                    AdventureCardDatabase.CreateCard(ref cards, 59);
                    break;
                case 107:
                    MessageBox.Show("Stomach growling, you eye the almost empty plate on the table. There is only a tiny piece of cheese and a knife left on it. Edric clears his throat: I'm sorry to see you hungry. But the roast mutton was simply too tempting ...\" Take adventure cards 24 and 52.");
                    AdventureCardDatabase.CreateCard(ref cards, 24);
                    AdventureCardDatabase.CreateCard(ref cards, 52);
                    break;
                case 108:
                    MessageBox.Show("Beside the tomb is a stone pedestal with a sacrificial bowl. Alchemy was performed here not long ago, for the basin still contains residues of indeterminable liquids and powders, along with several broken glass vials.One of the vials is still intact though! It contains a thick, reddish liquid.Take adventure card 38.");
                    AdventureCardDatabase.CreateCard(ref cards, 38);
                    break;
                case 109:
                    MessageBox.Show(@"You walk along the corridor to the great portal.As you approach, you hear                                                                                              
a whistling sound.You look up to see an arrow shooting towards you from the mouth at you.You lose 2 health points.
mouth of the stone mask above the portal.Unfortunately, you're far too close to
escape its path and pain sears through your leg as it is pierced by the arrow!Next                                                                                          
time, you'd do well to steer clear of the stone mask. You lose 2 health points.    ");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 110:
                    MessageBox.Show(@"110: The stone well is very solid. It is not particularly deep though and almost                                                                                                                                                                                                                                                                     
empty.Catching a movement out of the corner of your eye, you draw back.Was            
that a snake at the bottom ? Backing away, you carefully take a closer look from a
safe distance.Phew, it's just a piece of old rope! Take adventure card 49.             
your senses fade.When you come to, you're lying on the floor and the room still
spins around you.Your nose throbs with pain and saliva dribbles from the corner
of your mouth.You're having some really crazy hallucinations. It must be the
effects of the potion.You'd better find an antidote! Take adventure card 78.");
                    AdventureCardDatabase.CreateCard(ref cards, 78);
                    AdventureCardDatabase.CreateCard(ref cards, 49);
                    break;
                case 111:
                    MessageBox.Show(@"You lose 1 health point. Take adventure Card 46.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp,name);
                    AdventureCardDatabase.CreateCard(ref cards, 46);
                    break;
                case 112:
                    MessageBox.Show(@"The drawbridge is down — freedom is within reach. But you’re not leaving 
without your friend Berengar! You return to the castle, determined to find him");
                    break;
                case 113:
                    result = MessageBox.Show(@"The emblem of the League of Guardians has been carved into the throne. 
Do you want to sit down? If so, then read entry 513.","",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:513);
                    break;
                case 114:
                    MessageBox.Show(@"There is an opening in the vaulted ceiling high above you. It resembles a 
diamond enclosed in a circle. What might be up there?");
                    break;
                case 115:
                    MessageBox.Show(@"There’s something about that gargoyle that isn’t quite right. As you warily 
edge closer, one of its eyes lights up and a jet of fire comes shooting out of its 
mouth at you. You lose 2 health points.");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp,name);
                    break;
                case 122:
                    MessageBox.Show(@"You feel around with your hand. There’s something moving! In a flash, a 
snake wraps itself around your arm and sinks its fangs in! You withdraw your arm 
in fright, which causes the snake to fall off and disappear back into the sewer. 
That certainly wasn’t what you saw glittering! You’ll need something longer to 
reach it. You lose 1 health point.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 125:
                    MessageBox.Show(@"You take a sip of the blue potion. It tastes awful! Then your vision blurs and 
your senses fade. When you come to, you’re lying on the floor and the room still 
spins around you. Your nose throbs with pain and saliva dribbles from the corner 
of your mouth. You’re having some really crazy hallucinations. It must be the 
effects of the potion. You’d better find an antidote! Take adventure card 78");
                    AdventureCardDatabase.CreateCard(ref cards, 78);
                    break;
                case 141:
                    MessageBox.Show(@"141: You carefully open the door.When it's open just a crack, you catch sight of a  
man in the next room! You immediately stop opening the door and are just about
to close it again when you hear a friendly voice: Don't be scared, I'm not a guard!
And going by the way you're sneaking around here, you're trying to escape, too — just
like me.My name is Edric. read entry E.");
                    // Put adventure card 90 in room Card E.
                    // Create Room Card E
                    MainForm.OpenLocation('E');
                    LocEntry(ref cards, ref hp, name,entry:'E');
                    break;
                case 144:
                    result = MessageBox.Show(@"144: Jin stares at the stone in your hand in fascination. I've seen members of the League find gemstones in the shafts.Some were embedded in harder rock or even in  less precious crystals.They can only be removed with good tools. Do you want to keep digging ? If so, then read entry 803. ","",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name, 803);
                    break;
                case 145:
                    result = MessageBox.Show(@"145: You reach another fork in the tunnel.Do you want to take the left fork ?
Then click 'Yes' and read entry 245.Or do you want to take the right fork instead? Then click 'No' and read 
entry 345.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name, 245);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp,name, 345);
                    break;
                case 152:
                    MessageBox.Show(@"152: Your gaze remains fixed on the scepter. Why does he want to get rid of it?
What is he afraid of ?  The vision fades and you're filled with resolve: you can use     
this scepter to stop Berengar!With renewed strength, you stride on. Regain 1
health point. ");
                    hp += 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 153:
                    MessageBox.Show(@"153: Catching your foot on something, you stumble and fall head over heels. 
momentum carries you further down the shaft before you crash to the cold stone 
lfoor.Your whole body is covered in cuts and bruises! You lose 2 health points.
Read entry 653.");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp,name, 653);
                    break;
                case 154:
                    MessageBox.Show(@"154: You deftly free yourself from the prisoner's grasp and evade the hands    
Jawing at your neck. You quickly take a step back and instinctively rub your   
neck.Read entry 444.");
                    LocEntry(ref cards, ref hp, name,444);
                    break;
                case 155:
                    MessageBox.Show(@"155: You look pretty hungry said Monte. Here, take this. He passes you a piece the passageway.
of stale bread.Take adventure card 71");
                    AdventureCardDatabase.CreateCard(ref cards, 71);
                    break;
                case 156:
                    MessageBox.Show(@"You throw the door open and rush into the room, ready for battle. Suddenly, 
you feel a sharp pain in your knee and you fall to the ground cursing with your 
arms stretched out in front of you. You lose 1 health point.
You look around quickly, expecting to be attacked by a guard. Instead, you find 
yourself looking up into a mischievous, smiling bearded face: “You don’t look like 
a guard to me, ” he exclaims. “More like another prisoner trying to escape! My name 
is Edric. ” He offers you his hand and helps you to your feet. “I'm sorry about your 
knee. But you just can’t be too careful in this place. ”
Read entry E.");
                    // Create Room Card E. Put focus on it.
                    MainForm.OpenLocation('E');
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp,name,entry:'E');
                    break;
                case 157:
                    MessageBox.Show(@"157: In the crystal ball, you can see... yourself ? You are carrying a sword and
shield, and seem to be protecting someone important dressed in robes.
a simple farmer gets too close to your charge for your liking, so you immediately smack him square in the face with your armored fist and he falls to the ground,
bleeding. Read entry 757.");
                    LocEntry(ref cards, ref hp, name,id:757);
                    break;
                case 159:
                    MessageBox.Show(@"159: Taken by surprise, you remain remain rooted to the spot but the arrow only grazes
your arm! You lose 1 health point.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 161:
                    MessageBox.Show(@"161: You! the prisoner shrieks. You work for the League!Your ragged clothes don't fool me! You're Berengars personal guard and accompany him everywhere he " +
" .The goes in the kingdom.Your cold - bloodedness is notorious.Leave me alone! Without warning, she lobs a stone at your head! Only when you can credibly assure her" +
" that you're imprisoned here, too, does she calm down a little. You lose 1 health point. Read entry 561.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:561);
                    break;
                case 162:
                    MessageBox.Show(@"162: You hide in the shadows at the drawbridge and will the guards to pass you
    by.Moments later, you hear more screams from inside, followed by panting, then
    ... silence. That didn't sound good! Could we maybe have helped Edric? You're
    roused from your thoughts moments later by the patter of feet running along the passageway.A guard is running towards the drawbridge!Return adventure card 90 to the box.Do you have adventure card 24 ? if so, then read entry 362.
Otherwise, read entry 462.");
                    MainForm.frm.edrickAlive = false;
                    // Return The Edrick card to the box. Remove his card from E.
                    if (cards.FindIndex(p => p.ID == 24) != -1)
                    {
                        LocEntry(ref cards, ref hp,name,id:362);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp, name,id:462);
                    }
                    break;
                case 165:
                    MessageBox.Show(@"165: With a jerk, you finally manage to move the lever down. It seems to have        
triggered a mechanism because when you press your ear to the wall, you can hear      
a soft hum and the clattering of gears. The stone mask above the portal in the 
room across the corridor finally closes its deadly mouth.
Fantastic, you've found a way to deactivate the trap! Return room card D to the      
box. Read entry Q.");
                    // Put away Room Card D and Create Room Card Q.
                    MainForm.BlockLocation('D');
                    MainForm.OpenLocation('Q');
                    LocEntry(ref cards, ref hp, name,'Q');
                    break;
                case 171:
                    MessageBox.Show(@"171: In your mind's eye, you see a gloomy chamber. At its center is a stone throne
bearing the symbol of the League of Guardians. The longer you stare at the          
throne, the more you're convinced that this place is evil and the throne is cursed! 
Read entry 971.");
                    LocEntry(ref cards, ref hp,name, id:971);
                    break;
                case 183:
                    MessageBox.Show(@"183: Brigh breaks away from the group and is the first to reach Berengar.Before     
he even realizes what's happening, she's wrestled him to the ground. Impressive!    
But Berengar twists around, draws a potion from beneath his cloak, and pours it
onto the ground. An immense cloud of smoke immediately forms, and you can your hand 
barely make out your hand in front of you. By the time the smoke has finally cleared, Berengar has vanished.You'd better       
hurry if you want to reach the eastern tomb in time.Only there can you prevent 
Berengar from unleashing yet more horrors!Read entry K.");
                    LocEntry(ref cards, ref hp, name,entry:'K');
                    break;
                case 200:
                    result = MessageBox.Show(@"200: You pause again and look wistfully outside.The sun is warm on your faces and the light breeze carries the scent of autumn.Suddenly, you hear a shout from " + 
"within the castle: Stop right there! This is followed by a stifled cry.Was that " +    
"Edric? He's in trouble! But what if the guard is also looking for you? " +
"Return mission card Al to the box, and take mission card" +
"A2.You must now decide: do you want to hide from the approaching threat?" +
"Then click 'Yes' and read entry 162.Or do you want to rush to Edric's aid? Then click 'No' and read entry 262.", "", MessageBoxButtons.YesNo);

                    // Remove mission A1. Take A2.
                    MainForm.frm.missionNumber = 2;
                    CardRecieved mTwo = new CardRecieved();
                    mTwo.pictureBox1.Image = Properties.Resources.MissionA2;
                    mTwo.ShowDialog();
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name,id: 162);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp, name,id:262);
                    break;
                case 201:
                    MessageBox.Show(@"201: The upper half of the door is more damaged than you first thought. If you     
were to hit it with something sufficiently hard, you might be able to break it. ");
                    break;
                case 202:
                    MessageBox.Show(@"The steps mark the start of a long spiral staircase.Take room card H");
                    // Create Room Card H and put focus on it.
                    MainForm.OpenLocation('H');
                    LocEntry(ref cards, ref hp,name,entry:'H');
                    break;
                case 203:
                    MessageBox.Show(@"203: The shaft nearest to you seems to be very deep and disappears into darkness.
You bend down to take a closer look. Does anyone have adventure card 74 ? If so
read entry 344.Otherwise, read entry 422.");
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:344);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp,name,id: 422);
                    }
                    break;
                case 204:
                    MessageBox.Show(@"204: Several notes hang on the walls up the stairs. Important: prisoner 304 is
annoying, but highly intelligent! She could still prove useful.Prisoner 404 has
attacked the guards again.She will be disciplined next week.The other note appears to be some kind of map. Take adventure card 45");
                    AdventureCardDatabase.CreateCard(ref cards, 45);
                    break;
                case 205:
                    MessageBox.Show(@"205: Just like the first cell door, the second also has a little barred opening
and a golden lock. Do you have adventure card 75? If so, then read entry 522. Otherwise, read entry 644.");
                    if (cards.FindIndex(p => p.ID == 75) != -1)
                    {
                        LocEntry(ref cards, ref hp,name, id:522);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp, name,id:644);
                    }
                    break;
                case 206:
                    MessageBox.Show(@"206: The empty eye sockets of the middle skull stare at you lifelessly. Repulsed,
you decide to check whether there's anything inside it. You discover something
small and smooth in its mouth. But then you feel a sting and quickly withdraw
again!You lose 1 health point. Take adventure card 58.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    AdventureCardDatabase.CreateCard(ref cards, 58);
                    break;
                case 207:
                    MessageBox.Show(@"207: The oven is still hot and warms the room. Someone must have prepared a fire here not so long ago. Unfortunately, there's nothing left of it now.");
                    break;
                case 208:
                    MessageBox.Show(@"208: You tiptoe over to the tomb at the center of the chamber. The lid has been
removed and you venture a peek inside.It's empty! The corpse — or whatever
here — has been moved or stolen.You spot a few fragments of rock in one
corner.");
                    break;
                case 209:
                    MessageBox.Show(@" 209: You steal along the corridor to take a closer look at the pile of wood on the floor. As you approach, you hear a whistling sound.You look up to see an arrow shooting from the mouth of the stone mask above the portal towards you. " + 
"Unfortunately, you're far too close to avoid it in time and pain sears through your " +
"shoulder as it is pierced by the arrow! Next time, you'd do well to steer clear of the " +
"stone mask.You lose 2 health points");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 210:
                    MessageBox.Show(@"A Mother-of - Pearl tile lies on top of the heap of rubble.Take adventure card 63.");
                    AdventureCardDatabase.CreateCard(ref cards, 63);
                    break;
                case 211:
                    MessageBox.Show(@"211: You decide to take the left fork and feel your way along the passageway in   
the dark for quite some time.Suddenly, you hear a rumble, and without any         
warning, the ceiling begins to collapse on top of you.A sharp rock falls on your  
back and you cry out in pain! Let's get out of here before the tunnel buries you
alive! Return to the starting point on room card N.You lose 2 health points.");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 212:
                    MessageBox.Show(@"212: Beware: from now on, always send two of the best guards to Berengar in the
tower! The message is clear. Berengar really is alive and must be imprisoned in
the tower!");
                    break;
                case 213:
                    MessageBox.Show(@"213: The giant skull on the wall stoically returns your gaze. Something glints inside its mouth. Take adventure card 28");
                    AdventureCardDatabase.CreateCard(ref cards, 28);
                    break;
                case 214:
                    MessageBox.Show(@"214: Your attention is drawn to the device's levers. A notice warns: Do not adjust
the water pump! Below it are three cogs, each of which bears the numbers 0 to 9.      
With the right combination, maybe you can activate the device.Do you want to
try entering a three - digit code? Then read the six - digit entry XYZ214, completing
the combination with three digits of your choice(X, Y, and Z).");
                    CreatingForm.EnterEntry(214);
                    break;
                case 215:
                    MessageBox.Show(@"215: The stone gargoyle's mouth cavity extends deep into the wall. You fearlessly   
reach inside. Take adventure card 48.");
                    AdventureCardDatabase.CreateCard(ref cards, 48);
                    break;
                case 222:
                    MessageBox.Show(@"222: Maybe you can see what's behind the door through the barred opening. You
edge closer. At the last moment, you spot two wild, sparkling green eyes in the  
half - light.Take adventure card 83 and read it out loud.");
                    CreatingForm.createCharEventForm(name,hp,83);
                    AdventureCardDatabase.CompareDatabase(ref cards,ref hp);
                    break;
                case 225:
                    MessageBox.Show(@"225: Do you have adventure card 78 ? If so, then read entry 625.Otherwise, read 
entry 725.");
                    if (cards.FindIndex(p => p.ID == 78) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:625);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp,name, id:725);
                    }
                    break;
                case 244:
                    MessageBox.Show(@"244: Slowly but surely, you loosen the stone with your knife.As feared, the blade                                                                              
breaks after a while.But what you discover beneath the stone makes up for this.
Return adventure card 24 to the box.Take adventure card 44.");
                    cards.RemoveAt(cards.FindIndex(p => p.ID == 24));
                    AdventureCardDatabase.RemoveCard(24);
                    AdventureCardDatabase.CreateCard(ref cards, 44);
                    break;
                case 245:
                    result = MessageBox.Show(@"245: You once again reach a fork in the tunnel.To go left, click 'Yes' and read entry 445.To go
right, click 'No' and read entry 545.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name, id:445);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp, name,id:545);
                    break;
                case 252:
                    MessageBox.Show("Everyone begins to cheer. But it doesn't escape your sharp eyes that a member of the League lifts the scepter and murmurs softly: 'Into the sewers of history with you, along with the old teachings.'");
                    break;
                case 253:
                    MessageBox.Show(@"253: Squinting, you just manage to make out a big rock on the floor of the
tunnel in time.You carefully step over it and continue on your way.Read entry 653.");
                    LocEntry(ref cards, ref hp,name, id:653);
                    break;
                case 254:
                    MessageBox.Show(@"254: You intuitively dodge to one side so that the blow slams into your shoulder,
rather than hitting you square in the face. You lose 1 health point. Read entry 444");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:444);
                    break;
                case 255:
                    MessageBox.Show(@"255: Monte moves closer and closer to your face until his clouded eyes widen with surprise: Yolanda! How wonderful to see you here. my darling daughter. Take adventure card 73.");
                    AdventureCardDatabase.CreateCard(ref cards, 73);
                    break;
                case 257:
                    MessageBox.Show(@" 257: In the crystal ball, you can see yourself? You're in an opulent chamber
that clearly isn't yours. You tiptoe up to the table and sprinkle a little powder into
    the carafe of wine standing there. Then you withdraw back into the shadows.  Read entry 757.");
                    LocEntry(ref cards, ref hp,name, id:757);
                    break;
                case 259:
                    MessageBox.Show(@"259: Thanks to your quick reflexes, you manage to throw yourself to the ground
in time.The arrow whistles over your head and smashes into the wall behind you. That was close!");
                    break;
                case 261:
                    MessageBox.Show(@"261: You! the prisoner shrieks. You work for the League! Your ragged clothes don't fool me! You're the League's best spy It was your henchmen who put me in this cell.
        Leave me alone! Without warning, she lobs a stone at your head! Only when you can credibly assure her that you're imprisoned here, too, does she calm down a little. You lose 1 health point. Read entry 561.");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:561);
                    break;
                case 262:
                    MessageBox.Show(@"262: You sprint down the corridor as fast as your feet can carry you with your 
friends hot on your heels. Breathing hard, you reach the guards’ quarters and peek inside. Take your character and place them on Room card E.
 That must be where the guard came from. The door across from you is open a crack. A mismatched battle is raging in the room. The guard is attacking Edric with a long spear,
 while Edric attempts in vain to fend him off. It's clear to you that Edric won't last much longer on his own. You look at each other and decide to attack the guard together!
Using the element of surprise and strength in numbers, you manage to overpower the guard, who falls to the ground injured. Do you have adventure card 24? If so, read entry 562. Otherwise,
read entry 662.");
                    if (cards.FindIndex(p => p.ID == 24) != -1)
                    {
                        LocEntry(ref cards, ref hp,name, id:562);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp, name,id:662);
                    }
                    break;
                case 271:
                    MessageBox.Show(@"271: Several tombs surround a basin.It is inscribed with letters that begin to   
dance before your eyes.The grim dance seems to freeze your soul and you long     
for the sun's warming caress. Read entry 971.");
                    LocEntry(ref cards, ref hp,name,id:971);
                    break;
                case 283:
                    MessageBox.Show(@"283: Berengar sees you coming.He steps behind the throne, draws a white        
potion out from beneath his cloak, and tosses it in your direction.The bottle  
shatters into a thousand pieces at your Feet, and a cloud of dense white smoke 
immediately forms and rapidly fills the entire chamber.You sink to the ground,  
dazed and coughing.As a group, you must give up 2 health points.                            
By the time the smoke has finally cleared, Berengar has vanished.You'd better    
hurry if you want to reach the eastern tomb in time.Only there can you stop the
experiment before Berengar unleashes yet more horrors! Read entry K.");
                    LocEntry(ref cards, ref hp, name,entry:'K');
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 300:
                    result = MessageBox.Show(@"300: You look around at each other, indecisive. You still find it hard to believe 
that you once were part of the League of Guardians. Berengar continues            
unmoved: What wretched cowards you are.When you learned of my plan to awaken
the stone golems, a spark of rebellion was ignited in you.You suddenly found your
conscience, He snorts disdainfully. As if that would have stopped you from all the     
other horrors that were necessary to achieve our ultimate goal. As expected, though,
your plan was flawed, and we caught you before you could do any real harm.We had
no choice but to erase your memory and imprison you.You may be simple-minded,          
but you still knew too much. His gaze turns to the place where the beast ... no,
the stone golem had perished. Your escape and defeat of the stone golem show that      
you still pose a threat to the League. But there's an entire army of stone golems in the 
eastern tombs just waiting to be awoken by me.The experiment is almost complete
and you won't stop it now!                                                             
Return mission card A2 to the box, and take mission card
A3.You must now decide: do you want to try to convince Berengar not to go
ahead with his plans? Then click 'Yes' and read entry 613. Or do you want to attack him? Then click 'No' and
read entry 713.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:613);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp,name, id:713);
                    // Return A2 to the box and take A3.
                    MainForm.frm.missionNumber = 3;
                    CardRecieved card = new CardRecieved();
                    card.pictureBox1.Image = Properties.Resources.MissionA3;
                    card.ShowDialog();
                    break;
                case 301:
                    result = MessageBox.Show(@"301: A creepy skeleton is all that remains of this prisoner.His arms are still " +    
"chained to the wall with bronze shackles.Since he won't be needing his" +             
"belongings anymore, you decide to search the half rotten tunic that still hangs" +    
"from his chest.Groping around, you manage to locate a pocket. Do you want to" +       
"reach inside If so, take adventure card 15.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        AdventureCardDatabase.CreateCard(ref cards, 15);
                    break;
                case 302:
                    MessageBox.Show(@" 302: The shelf is laden with all sorts of strange bottles and jars.Most of them are cracked and broken, but, as luck would have it, you find a little glass bottle still intact! Take adventure card 30.");
                    AdventureCardDatabase.CreateCard(ref cards, 15);
                    break;
                case 303:
                    result = MessageBox.Show(@"303: The bottom of the second shaft is just a few steps below you.Who knows,
maybe you'll find something interesting among all the rubble and debris covering
the floor ? Carefully, you climb down and start to dig with your bare hands.Take
adventure card 33.Do you want keep on digging ? If so, then read entry 703.","",MessageBoxButtons.YesNo);
                    AdventureCardDatabase.CreateCard(ref cards, 15);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name, id:703);
                    break;
                case 304:
                    MessageBox.Show(@"304: The door of the cell on the left has a golden lock.Do you have adventure
card 76? If so, then read entry 522. Otherwise, read entry 904.");
                    if (cards.FindIndex(p => p.ID == 76) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:522);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp,name,id:904);
                    }
                    break;
                case 305:
                    MessageBox.Show(@"305: The door to the second cell is unlocked.You notice some melted metal on the floor in front of it.Are these maybe the remains of the lock? That must mean that someone else has escaped, too! Unsurprisingly, you find that there's nothing left in the cell of any value.");
                    break;
                case 306:
                    MessageBox.Show(@"306: A small white shimmering Mother - of - Pearl tile glints in the nasal cavity of
the lower skull in the dim light. Take adventure card 53.");
                    AdventureCardDatabase.CreateCard(ref cards, 53);
                    break;
                case 307:
                    MessageBox.Show(@"307: There's nothing in the cupboard but cleaning utensils. The broom might
come in handy though. Take adventure card 17.");
                    AdventureCardDatabase.CreateCard(ref cards, 17);
                    break;
                case 308:
                    MessageBox.Show(@" 308: A Few wisps of ivy grow on the back wall of the crypt. You intuitively brush
the greenery aside. Underneath it, you find a hidden shelf carved into the rock
face.It's empty apart from a little crystal ball. Take adventure card 82 and read it
out loud.");
                    CreatingForm.createCharEventForm(name, hp, 82);
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 309:
                    result = MessageBox.Show(@" 309: There's a big barrel just near you. You curiously pull the lid off and peek
inside. It looks empty, but it's really too dark to say for sure. Do you want to
reach inside? If so, then read entry 909.","",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:909);
                    break;
                case 310:
                    MessageBox.Show(@"310: The statue seems to give you a determined look from beneath the hood that
is drawn low over its face. A memory stirs deep within you, and you suddenly
remember who the statue represents: Wulfred, the founder of the League of
Guardians! So the statue must be hundreds of years old.Do you have adventure
card 76 ? If so, then read entry 610.");
                    if (cards.FindIndex(p => p.ID == 76) != -1)
                    {
                        LocEntry(ref cards, ref hp, name,id:610);
                    }
                    break;
                case 311:
                    result = MessageBox.Show(@"311: You decide to take the right fork.After just a few steps, the light From     
the main passageway fades. In the faint light, you can just make out that the     
passageway splits again.The loud roar of water echoing off the tunnel walls       
makes you jittery.One wrong step here could have serious consequences! Are you    
sure you know where you're going? If so, continue to feel your way in the dark    
and read entry 145.If not, return to room card N.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:145);
                    break;
                case 312:
                    MessageBox.Show(@"312: A large wooden crate leans open against the wall.It contains a variety of old
bottles and jars in no discernible order.Most of them are empty, but then one                   
bottle containing a yellow liquid catches your eye. The label reads 'Aqua regia                 
— to melt the most precious metals. Now, this is interesting.Maybe you can use
it to melt one of the locks and free another prisoner.After all, you could really
use some help.You also find some ham! One of the guards must have left it here
when they fled.Take adventure cards 35 and 47");
                    AdventureCardDatabase.CreateCard(ref cards, 35);
                    AdventureCardDatabase.CreateCard(ref cards, 47);
                    break;
                case 313:
                    result = MessageBox.Show(@"313: Behind the left banner, you find that one of the stones is loose.Do you want                                                                                    
to pull it out? If so, then read entry 383.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:383);
                    break;
                case 314:
                    MessageBox.Show(@"314: You walk around the room along the far wall and take a closer look at          
the hole in the wall from which a little trickle of water flows. The water seems
clean, so you decide to splash some of it on your face. It is cool and refreshing.  
Suddenly, an electric eel comes darting out and shocks you, then proceeds to        
wrap itself around your neck! Take adventure card 88.");
                    AdventureCardDatabase.CreateCard(ref cards, 88);
                    break;
                case 315:
                    MessageBox.Show(@"315: There's something about that gargoyle that isn't quite right.You warily edge closer. Suddenly, one of its eyes lights up and a jet of ice comes shooting out of its mouth at you.. You lose 1 health point.");
                    if (hp > 1)
                    {
                        hp--;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 322:
                    MessageBox.Show(@"You try with all your might to lever the stone out. But the crack is just too 
small. Maybe you could manage it if you had the right tool");
                    break;
                case 325:
                    MessageBox.Show(@"Your lips are almost touching the bottle's opening, but the liquid's glow 
makes you hesitate.Maybe there’s a better use for this strange potion.");
                    break;
                case 344:
                    result = MessageBox.Show(@"344: When you look into the shaft, you hear Monte behind you: If there's one
thing I know about, its mines.So listen to me very carefully. We dug three tunnels
for the League of Guardians.Tunnel 203 is very dangerous, so stay away.
We found a few interesting artifacts in Tunnel 303.I don't know whether there's still
anything there though.The League was most interested in Tunnel 403. Nobody ever told us where it actually leads or what they found there though.Do you still want
to explore Tunnel 203 ? If so, then read entry 422.", "", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:422);
                    break;
                case 345:
                    result = MessageBox.Show(@"345: You've reached another fork in the tunnel. To go left, click 'Yes' and read entry 645.
 To go right, click 'No' and read entry 745.", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name,id:645);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp, name,id:745);
                    break;
                case 352:
                    MessageBox.Show(@"352: I recognize that scepter from my research! What was it about again... it harbors great power...
that's it! It will wipe anyone who attempts to lead the League on as path of evil off the face of the earth.");
                    break;
                case 353:
                    MessageBox.Show(@"  353: You trip on the uneven ground, stumble forward, and fall head over heals.
The momentum carries you further down the shaft before you crash to the cold
stone floor.Your whole body is covered in cuts and bruises! You lose I
point. Read entry 653");
                    if (hp > 1)
                    {
                        hp -= 1;
                    }
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:653);
                    break;
                case 354:
                    MessageBox.Show(@"354: Completely out of the blue, the prisoner reaches through the bar
her hands around your throat. You see madness in her eyes. You kick
but only when your senses begin to fade do you fall to the ground. Wheezing,
you gasp fur air.Another stab of pain sears through your body — now you have a sore neck to go with your strangulation marks.You lose 2 health points. Read Entry 444.");
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:444);
                    break;
                case 355:
                    MessageBox.Show(@"355: You look rather clever. Maybe you can figure this parchment out. A
dropped it a few days ago and I've kept it hidden away ever since. Take card 72");
                    AdventureCardDatabase.CreateCard(ref cards, 72);
                    break;
                case 357:
                    MessageBox.Show(@"In the crystal ball, you can see ... yourself? You’re standing at a large desk 
surrounded by books and scrolls. All the reading is giving you a headache and 
your gaze wanders to another parchment. As your eyelids begin to fall closed, 
you’re just reading about tombs. Suddenly, you sit bolt upright again. “That’s it! 
That’s how we’ll find the beasts!” you exclaim. Read entry 757.");
                    LocEntry(ref cards, ref hp, name,id:757);
                    break;
                case 359:
                    MessageBox.Show(entries[0]);
                    if (hp > 2)
                    {
                        hp -= 2;
                    }
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 361:
                    MessageBox.Show(entries[1]);
                    LocEntry(ref cards,ref hp,name,id:561);
                    break;
                case 362:
                    MessageBox.Show(entries[2]);
                    // Returns Room Card E to the box.
                    MainForm.BlockLocation('E');
                    index = cards.FindIndex(p => p.ID == 24);
                    cards.RemoveAt(index);
                    AdventureCardDatabase.RemoveCard(24);
                    // Open form R and put focus on it.
                    MainForm.OpenLocation('R');
                    LocEntry(ref cards, ref hp,name,entry:'R');
                    break;
                case 371:
                    MessageBox.Show(entries[3]);
                    LocEntry(ref cards, ref hp, name,id:971);
                    break;
                case 383:
                    MessageBox.Show(entries[4]);
                    AdventureCardDatabase.CreateCard(ref cards,37);
                    if(cards.FindIndex(p => p.ID == 76) != -1)
                        LocEntry(ref cards, ref hp,name, id:483);
                    break;
                case 400:
                    MessageBox.Show(entries[5]);
                    // calculate Final Score.
                    calcFinalScore(hp, cards);
                    break;
                case 401:
                    result = MessageBox.Show(entries[6],"",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:122);
                    break;
                case 402:
                    MessageBox.Show(entries[7]);
                    AdventureCardDatabase.CreateCard(ref cards, 32);
                    break;
                case 403:
                    result = MessageBox.Show(entries[8],"",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:903);
                    break;
                case 404:
                    MessageBox.Show(entries[9]);
                    if (cards.FindIndex(p => p.ID == 77) != -1)
                        LocEntry(ref cards, ref hp, name,id:522);
                    else
                        LocEntry(ref cards, ref hp, name,id:222);
                    break;
                case 405:
                    MessageBox.Show(entries[10]);
                    // open Form D. Change Focus to Form D.
                    if(!isdone)
                    {
                        CreatingForm.createCharEventForm(name, hp, 80);
                        AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                        isdone = true;
                    }
                    MainForm.OpenLocation('D');
                    LocEntry(ref cards, ref hp, name,entry:'D');

                    break;
                case 406:
                    MessageBox.Show(entries[11]);
                    AdventureCardDatabase.CreateCard(ref cards, 36);
                    break;
                case 407:
                    if(haveExplored)
                    {
                        MessageBox.Show(entries[12],"");
                        CreatingForm.Trade();
                        AdventureCardDatabase.CompareDatabase(ref cards,ref hp);
                    }
                    else
                        LocEntry(ref cards, ref hp, name,id:468);
                    break;
                case 408:
                    MessageBox.Show(entries[13]);
                    AdventureCardDatabase.CreateCard(ref cards, 34);
                    break;
                case 409:
                    result = MessageBox.Show(entries[14],"",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp, name,id:322);
                    break;
                case 410:
                    MessageBox.Show(entries[15]);
                    break;
                case 411:
                    MessageBox.Show(entries[16]);
                    AdventureCardDatabase.CreateCard(ref cards, 56);
                    break;
                case 412:
                    MessageBox.Show(entries[17]);
                    MainForm.frm.endOfGame = true;
                    // This is when the 4-turn countdown starts for Berengar.
                    break;
                case 414:
                    MessageBox.Show(entries[18]);
                    if (cards.FindIndex(p => p.ID == 75) != -1)
                        LocEntry(ref cards, ref hp, name,id:514);
                    break;
                case 415:
                    MessageBox.Show(entries[19]);
                    if (cards.FindIndex(p => p.ID == 74) != -1)
                        LocEntry(ref cards, ref hp, name,id:615);
                    break;
                case 422:
                    MessageBox.Show(entries[20]);
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 425:
                    MessageBox.Show(entries[21]);
                    break;
                case 444:
                    MessageBox.Show(entries[22]);
                    break;
                case 445:
                    MessageBox.Show(entries[23]);
                    // left fork and right fork.
                    break;
                case 447:
                    MessageBox.Show(entries[24]);
                    break;
                case 452:
                    MessageBox.Show(entries[25]);
                    break;
                case 453:
                    MessageBox.Show(entries[26]);
                    LocEntry(ref cards, ref hp, name,id:653);
                    break;
                case 454:
                    MessageBox.Show(entries[27]);
                    if (hp > 1) 
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:444);
                    break;
                case 455:
                    MessageBox.Show(entries[28]);
                    AdventureCardDatabase.CreateCard(ref cards, 70);
                    break;
                case 456:
                    result = MessageBox.Show(entries[29],"",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        // Take ending card 1 and read aloud.
                        CardRecieved endingOne = new CardRecieved();
                        endingOne.pictureBox1.Image = Properties.Resources.Ending1;
                        endingOne.ShowDialog();
                        LocEntry(ref cards,ref hp,name,id:512);
                    }
                    else
                    {
                        LocEntry(ref cards, ref hp, name,id:600);
                    }
                    break;
                case 457:
                    MessageBox.Show(entries[30]);
                    LocEntry(ref cards, ref hp, name,id:757);
                    break;
                case 459:
                    MessageBox.Show(entries[31]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 461:
                    MessageBox.Show(entries[32]);
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:561);
                    break;
                case 462:
                    MessageBox.Show(entries[33]);
                    // Return Room Card E to the box. Take Room Card R.
                    MainForm.BlockLocation('E');
                    MainForm.OpenLocation('R');
                    LocEntry(ref cards, ref hp, name,entry:'R');
                    break;
                case 468:
                    MessageBox.Show("468: You approach the man warily.He smiles at you broadly. “All of the guards suddenly fled the dungeon in a panic last night. Who cares why.One of them dropped this yellow potion. " +
                    "The label says it’s Aqua regia. ’ It melts gold! It sounded almost too good to be true.So, without further ado, I tried it on the lock of my cell. I sprinkled just a few drops on the golden metal and it immediately began to dissolve." +
                    " And here I am now — searching for something to make up for my imprisonment before I make my escape. ”You eye him with interest: “So, what have you found so far ?” Edric pulls an assortment of items out of his bag: “See for yourself." +
                    "Maybe there’s something you might find useful ? If there is, then I’d be happy to sell it to you.After all, I have to think of the time after my captivity, don’t I ?” Then he gives you a wink.To purchase a medicinal herb, return 1 coin to the box and take adventure card 18.To purchase a ring, return 2 coins to the box and take adventure card 19.To purchase a bronze key return 1 coin to the box and take adventure card 20." +
                    "You can purchase as many items as you can afford. You can talk to Edric at anytime, to make another deal.");
                    CreatingForm.Trade();
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 471:
                    MessageBox.Show(entries[34]);
                    LocEntry(ref cards, ref hp, name,id:971);
                    break;
                case 475:
                    MessageBox.Show(entries[35]);
                    break;
                case 483:
                    MessageBox.Show(entries[36]);
                    break;
                case 500:
                    MessageBox.Show(entries[37]);
                    AdventureCardDatabase.CreateCard(ref cards, 92);
                    if (cards.FindIndex(p => p.ID == 62) != -1)
                        LocEntry(ref cards, ref hp, name,id:456);
                    else
                        LocEntry(ref cards, ref hp, name,id:600);
                    break;
                case 501:
                    MessageBox.Show(entries[38]);
                    AdventureCardDatabase.CreateCard(ref cards, 10);
                    break;
                case 502:
                    MessageBox.Show(entries[39]);
                    break;
                case 503:
                    MessageBox.Show(entries[40]);
                    break;
                case 504:
                    MessageBox.Show(entries[41]);
                    if (cards.FindIndex(p => p.ID == 62) != -1)
                        LocEntry(ref cards, ref hp, name,id:622);
                    CreatingForm.EnterEntry(504);
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 505:
                    MessageBox.Show(entries[42]);
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 506:
                    MessageBox.Show(entries[43]);
                    break;
                case 507:
                    MessageBox.Show(entries[44]);
                    break;
                case 508:
                    MessageBox.Show(entries[45]);
                    break;
                case 509:
                    MessageBox.Show(entries[46]);
                    AdventureCardDatabase.CreateCard(ref cards, 26); // remember spider bite.
                    break;
                case 510:
                    MessageBox.Show(entries[47]);
                    // open form P
                    MainForm.OpenLocation('P');
                    LocEntry(ref cards, ref hp, name,entry:'P');
                    break;
                case 511:
                    MessageBox.Show(entries[48]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 512:
                MessageBox.Show("512: “What was that?” “Do you mean the shadow or the noise?” “I have a really bad " +
                    "feeling...” A powerful gust of wind blows in your face and a few leaves, already" +
                    "turned orange and red by the autumn, bluster past you.The air suddenly smells" +
                    "heavy and like... sulfur.Then you’re startled by a hissing noise and your eyes fall" +
                    "on a baby dragon. It is fearlessly waddling across the drawbridge and hopping" +
                    "around in excitement.Berengar looks from the little dragon back to you.The" +
                    "fury in his eyes has been replaced by growing panic. Moments later, you also" +
                    "realize why.The shadow flits across the drawbridge again.This time it is bigger, " +
                    "the noise is louder, and the wind is even stronger. A piercing roar makes the air" +
                    "and ground tremble.When you spot its source, an icy shiver runs down your" +
                    "spine.A mighty black dragon soars in the sky above the castle.It circles ever" +
                    "higher, then its body drops suddenly, and it plunges back down towards the" +
                    "drawbridge.You watch its raging approach as its chest begins to glow red.All" +
                    "of a sudden, you realize what it is going to do.Gathering all your energy, you" +
                    "sprint back into the castle without a backward glance.You just manage to get to" +
                    "safety around a corner when a colossal wall of fire makes the whole castle shake" +
                    "and rips your feet out from under you.Then fires break out everywhere and" +
                    "the solid castle walls begin to crack.You only have one thought: “Let's get out of " +
                    "here!” You sprint back out of the castle again as fast as you can.Just as you reach" +
                    "the drawbridge, part of the castle collapses behind you.A frightening scene also" +
                    "plays out in front of you.The drawbridge has plummeted into the ravine and on" +
                    "the other side, where the baby dragon is hopping around excitedly between the" +
                    "mighty dragon’s legs, smoking boots are all that remain of Berengar.You remain" +
                    "rooted to the spot. But the dragon has seen you and fixes its fiery glare on you." +
                    "Then you hear its voice in your heads: “That was a just punishment for the golem" +
                    "master, who stole one of my eggs.You, on the other hand, have brought my young" +
                    "one back to me.For that, I'll let you live. ” She flies you across the ravine and says: " +
                    "“Go — and don't ever come back. ” You don’t need to be told twice. After all, who " +
                    "wants to disagree with a dragon ? Read entry 400.");
                    LocEntry(ref cards, ref hp, name,id:400);
                    break;
                case 513:
                    MessageBox.Show(entries[49]);
                    if(hp > 1)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 514:
                    MessageBox.Show(entries[50]);
                    break;
                case 515:
                    MessageBox.Show(entries[51]);
                    break;
                case 522:
                    MessageBox.Show(entries[52]);
                    break;
                case 525:
                    MessageBox.Show(entries[53]);
                    break;
                case 544:
                    MessageBox.Show(entries[54]);
                    CreatingForm.createCharEventForm(name,hp,81);
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 545:
                    MessageBox.Show(entries[55]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 547:
                    MessageBox.Show(entries[56]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    // Make Room Card H the focus.
                    MainForm.OpenLocation('H');
                    break;
                case 561:
                    MessageBox.Show("561: \"“Who are you and what are you doing down here?\" Still a little suspicious, shereplies in a gruff voice: “I'm Sirona. Not so long ago, I was a member of the League " +
                    "of Guardians.I thought we were going to research the secrets of forgotten alchemy!" +
                    "And indeed we did discover a number of ancient remedies.But one day, I learned that" +
                    "our experiments were merely a part of Berengar's plan. All he actually cared about " +
                    "was how he could awaken the stone golems beneath this castle and seize control of the" +
                    "kingdom! I swore I would not let that happen and searched for a way to stop him." +
                    "I recently discovered that the dark crystal with the inscription that he needs for the" +
                    "crucial experiment can be destroyed by pure sunlight.But before I could do anything, " +
                    "I was found out and thrown in this dungeon.\" She becomes more animated. " +
                    "Even if Berengar has already awakened a stone golem, he can still be stopped. Please let me" +
                    "help you! You'll need to find something to help get me out of this cell first. The only " +
                    "weak point is this grating.Aqua regia is no use here, though, as it only dissolves the" +
                    "noblest of metals. Maybe we can use dragon fire to blast out the rusty bars. \" " +
                    "You eye Sirona in disbelief.Did you just hear right ? “Dragon fire?\" “Not from a full-grown " +
                    "dragon, of course. But maybe you can find a young dragon or even an egg. They like" +
                    "dark places and give offquite a lot of heat.\" “I'll see what I can do.\" " +
                    "As you turn to go, she thinks of something else. “Wait! There's something very important somewhere down here. A constant hum sometimes fills the air and walls.And one of the guards" +
                    "who patrols here muttered something strange: ‘Three dazzling discs from large to small." +
                    "The numbers on their side will unlock all.Do you have adventure card 76 ? If so,then read entry 822.");
                    if (cards.FindIndex(p => p.ID == 76) != -1)
                        LocEntry(ref cards, ref hp, name, id:822);
                    break;
                case 562:
                    MessageBox.Show(entries[57]);
                    index = cards.FindIndex(p => p.ID == 24);
                    cards.RemoveAt(index);
                    AdventureCardDatabase.RemoveCard(24);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:762);
                    break;
                case 575:
                    MessageBox.Show(entries[58]);
                    CreatingForm.ChooseYourCard();
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 600:
                    MessageBox.Show(entries[59]);
                    if (hp <= 6)
                    {
                        index = 0;
                        CardRecieved endingTwo = new CardRecieved();
                        endingTwo.pictureBox1.Image = Properties.Resources.Ending2;
                        endingTwo.ShowDialog();
                        LocEntry(ref cards, ref hp, name, id: 612);
                    }   
                    // take ending card 2
                    else if (hp > 6 & cards.FindIndex(p => p.ID == 77) != -1)
                    {
                        
                        index = 0;
                        CardRecieved endingThree = new CardRecieved();
                        endingThree.pictureBox1.Image = Properties.Resources.Ending3;
                        endingThree.ShowDialog();
                        DialogResult res = MessageBox.Show("Say Yes to face Berengar now or No to wait until nightfall","Choice", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                            LocEntry(ref cards, ref hp, name, id: 712);
                        else
                            LocEntry(ref cards, ref hp, name, id: 612);
                    }  
                    // take ending card 3
                    else
                    {
                        index = 0;
                        CardRecieved endingFour = new CardRecieved();
                        endingFour.pictureBox1.Image = Properties.Resources.Ending4;
                        endingFour.ShowDialog();
                        DialogResult res = MessageBox.Show("Say Yes to face Berengar now or No to wait until nightfall", "Choice", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                            LocEntry(ref cards, ref hp, name, id: 812);
                        else
                            LocEntry(ref cards, ref hp, name, id: 612);
                    }
                        
                    // take ending card 4
                        break;
                case 601:
                    MessageBox.Show(entries[60]);
                    AdventureCardDatabase.CreateCard(ref cards, 13);
                    break;
                case 602:
                    MessageBox.Show(entries[61]);
                    AdventureCardDatabase.CreateCard(ref cards, 27);
                    break;
                case 605:
                    MessageBox.Show(entries[62]);
                    break;
                case 606:
                    MessageBox.Show(entries[63]);
                    AdventureCardDatabase.CreateCard(ref cards, 43);
                    break;
                case 607:
                    MessageBox.Show(entries[64]);
                    AdventureCardDatabase.CreateCard(ref cards, 21);
                    break;
                case 608:
                    MessageBox.Show(entries[65]);
                    break;
                case 609:
                    MessageBox.Show(entries[66]);
                    break;
                case 610:
                    MessageBox.Show(entries[67]);
                    break;
                case 611:
                    MessageBox.Show(entries[68]);
                    AdventureCardDatabase.CreateCard(ref cards, 50);
                    break;
                case 612:
                    MessageBox.Show("612: “If we don't stop Berengar now, then it will all have been in vain!” You " +
                        "angrily kick a stone away with your foot and flinch in pain as one of your many" +
                        "wounds throbs. “How can we possibly stop Berengar when we can hardly take care of" +
                        "ourselves ?” “What's the hurry? The stone golem has been destroyed and the tombs are " +
                        "buried.And it's going to take a while for Berengar to rally his guards again. ” “You're" +
                        "right. ” “Let's wait until nigh fall, then headfor the nearest town to alert the watch. ” " +
                        "You hesitate a moment longer.You don’t like to leave the battle with Berengar" +
                        "to someone else, even if you have thwarted his plans. You patiently wait until" +
                        "nightfall.After a while, Berengar gets fed up with waiting. Muttering angrily," +
                        "he stomps back into the castle: “Wretched cowards. But what more can you expect" +
                        "of such traitors? It's a miracle that they even managed to defeat the stone golem ... " +
                        "Tomorrow I'll find those cowardly guards. I'll give them a good talking-to. Making" +
                        "off at the very first sign of danger...” When you can no longer hear his voice," +
                        "you set off for the town. Despite your ragged appearance, no one believes you" +
                        "when you first arrive.But when you drop a few mentions of gemstones into the" +
                        "conversation, this changes abruptly.After just a few days, you find yourself back" +
                        "at the entrance to the castle — this time with a sizeable troop of armed men." +
                        "There’s no sign of Berengar though and you hope that he will never return with" +
                        "another plan. Read entry 400.");
                    LocEntry(ref cards, ref hp, name,id:400);
                    break;
                case 613:
                    MessageBox.Show("613: You hoarsely call across to Berengar. “This madness must end. You're " +
                        "summoning powers that you cannot control! Countless innocent people will suffer" +
                        "because of you!” He begins to respond, but you continue quickly. “Berengar, your" +
                        "plan is doomed to fail! The king has enough soldiers to take you and your creatures" +
                        "on!” Berengar seems unimpressed. “What a foolish lie. If your memory had" +
                        "returned, then you'd know that you bribed the king with gold and gemstones yourself” " +
                        "He suddenly becomes grave. “And now enough of your talk, you traitor. ” At this, " +
                        "Berengar draws a bottle of white liquid from beneath his cloak and tosses it at" +
                        "your feet.The bottle shatters and thick white gas begins to rise and rapidly fills" +
                        "the entire room. Gasping for air, you fall to the ground and your senses fade." +
                        "When you come to again, the gas has dispersed and there’s no sign of Berengar." +
                        "You’d better hurry if you want to reach the eastern tomb in time.Only there" +
                        "can you stop the experiment before Berengar unleashes yet more horrors! As a" +
                        "group, you must give up 2 health points. Read entry K.");
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,entry:'K');
                    break;
                case 615:
                    MessageBox.Show(entries[69]);
                    break;
                case 622:
                    MessageBox.Show(entries[70]);
                    break;
                case 625:
                    MessageBox.Show(entries[71]);
                    CreatingForm.createCharEventForm(name,hp,86);
                    AdventureCardDatabase.CompareDatabase(ref cards,ref hp);
                    break;
                case 644:
                    MessageBox.Show("644: A prisoner’s face appears in the opening: “Hey you!” He hisses. “Please help" +
                        "me get out of here!” you reply apologetically: “I'm sorry, but I don't have a key for this" +
                        "lock. ” “Damn, I'm going to rot away here!” “Don't despair! Maybe there's another way " +
                        "to get you out. What do you know about this dungeon?” He thinks for a moment." +
                        "“Not much.Like most of the other prisoners, I work in the mines. \" He becomes " +
                        "more animated. “If the guards have gone, you may find one or two gemstones with a" +
                        "little luck.If you get me out of here, I can tell you a thing or two about them.I used to" +
                        "be a jeweler, you know. ”Your eyes flick to the sign above the stairs. “What's that strange symbol!” He’s " +
                        "quiet for a moment and then says with amusement: “Why, it's the emblem of the " +
                        "League of Guardians.Don't tell me you don't know that! Then you can't have been " +
                        "imprisoned here for very long.They kidnapped us, locked us up, and forced us into" +
                        "slave labor. ” “Oh, I see!” you say with a nod.Before you turn away, he gives you an" +
                        "urgent look. “If you can't free me, then could you at least get me a strong drink! I'll" +
                        "give you something that belonged to the League of Guardians for it. ”");
                    break;
                case 645:
                    MessageBox.Show(entries[72]);
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    AdventureCardDatabase.CreateCard(ref cards, 61);
                    break;
                case 653:
                    MessageBox.Show(entries[73]);
                    MainForm.OpenLocation('J');
                    LocEntry(ref cards, ref hp, name,entry:'J');
                    // Create Room Card J and put it into focus.
                    break;
                case 662:
                    MessageBox.Show(entries[74]);
                    if (hp > 4)
                        hp -= 4;
                    else if (hp == 4)
                        hp -= 3;
                    else if (hp == 3)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    LocEntry(ref cards, ref hp, name,id:762);
                    break;
                case 701:
                    MessageBox.Show(entries[75]);
                    break;
                case 702:
                    MessageBox.Show(entries[76]);
                    AdventureCardDatabase.CreateCard(ref cards, 29);
                    break;
                case 703:
                    result = MessageBox.Show(entries[77],"",MessageBoxButtons.YesNo);
                    AdventureCardDatabase.CreateCard(ref cards, 64);
                    if (cards.FindIndex(p => p.ID == 75) != -1)
                        LocEntry(ref cards, ref hp, name,id:144);
                    else if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name,id: 803);
                    break;
                case 705:
                    MessageBox.Show(entries[78]);
                    if (MainForm.frm.isOpen == true)
                        LocEntry(ref cards, ref hp, name, id: 165);
                    // You must test if Room Card D is in play. If it is, read entry 165.
                    break;
                case 706:
                    MessageBox.Show(entries[79]);
                    // Create Room Card N and give focus to it.
                    MainForm.OpenLocation('N');
                    LocEntry(ref cards, ref hp, name,entry:'N');
                    break;
                case 707:
                    MessageBox.Show(entries[80]);
                    break;
                case 709:
                    MessageBox.Show(entries[81]);
                    if (cards.FindIndex(p => p.ID == 13) != -1 && cards.FindIndex(p => p.ID == 20) != -1 && cards.FindIndex(p => p.ID == 25) != -1)
                        ItemLocationEvaluation(132025,ref cards,ref hp,name);
                    break;
                case 711:
                    MessageBox.Show(entries[82]);
                    if(cards.FindIndex(p => p.ID == 75) != -1)
                        LocEntry(ref cards, ref hp, name,id:861);
                    else
                        LocEntry(ref cards, ref hp,name,id:811);
                    break;
                case 712:
                    MessageBox.Show("712: You return Brigh’s gaze with a determined look. “We need to stop Berengar once and for all," +
                        " or else this nightmare will never end. \" “The cavern has been buried " +
                        "that wont stop him from rallying his henchmen and uncovering the tombs again" +
                        "to create new stone golems. \" “So we have no choice.\" Brigh looks at each of you in " +
                        "turn, then nods. “Then it's decided!\"As if on command, you step out of the shadows onto the drawbridge. " +
                        "Berengar has been expecting you.He raises his arm and tosses a vial in your direction. " +
                        "Not another of his diabolical potions!Shrieking in rage, Brigh rushes forward." +
                        "She dives towards the vial and manages to catch it just before it smashes on the" +
                        "ground, deflecting it over the parapet instead.Moments later, you see a bright" +
                        "flash and feel a powerful explosion far below you. The drawbridge shakes and" +
                        "you struggle to remain on your feet.Berengar is less fortunate. You watch as he" +
                        "topples into the abyss with flailing arms and a look of dismay on his face.The" +
                        "threat posed by Berengar has been resolved once and for all.And you’re finally" +
                        "free! Do you have adventure card 60 ? If so, then read entry 912.Otherwise, read" +
                        "entry 400.");
                    if ( cards.FindIndex(p => p.ID == 60) != -1)
                        LocEntry(ref cards, ref hp,name, id:912);
                    else
                        LocEntry(ref cards, ref hp,name, id:400);
                    break;
                case 713:
                    MessageBox.Show(entries[83]);
                    if (cards.FindIndex(p => p.ID == 77) != -1)
                        LocEntry(ref cards, ref hp, name,id:183);
                    else
                        LocEntry(ref cards, ref hp,name,id:283);
                    break;
                case 725:
                    MessageBox.Show(entries[84]);
                    break;
                case 745:
                    MessageBox.Show(entries[85]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp -= 1;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 757:
                    MessageBox.Show(entries[86]);
                    index = cards.FindIndex(p => p.ID == 82);
                    cards.RemoveAt(index);
                    AdventureCardDatabase.RemoveCard(82);
                    break;
                case 762:
                    MessageBox.Show(entries[87]);
                    // Take away Room Card E. Put in Room Card R. Focus on R.
                    MainForm.BlockLocation('E');
                    MainForm.OpenLocation('R');
                    CreatingForm.ChooseYourCard();
                    AdventureCardDatabase.CompareDatabase(ref cards,ref hp);
                    LocEntry(ref cards, ref hp, name,entry:'R');
                    break;
                case 801:
                    MessageBox.Show(entries[88]);
                    AdventureCardDatabase.CreateCard(ref cards, 11);
                    break;
                case 802:
                    MessageBox.Show(entries[89]);
                    break;
                case 803:
                    MessageBox.Show(entries[90]);
                    if (hp > 1)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 805:
                    result = MessageBox.Show(entries[91],"",MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                        LocEntry(ref cards, ref hp,name, id:141);
                    else if (result == DialogResult.No)
                        LocEntry(ref cards, ref hp, name,id:156);
                    break;
                case 807:
                    MessageBox.Show(entries[92]);
                    // Take Room Card G. Put Focus.
                    MainForm.OpenLocation('G');
                    LocEntry(ref cards, ref hp,name, entry:'G');
                    break;
                case 809:
                    MessageBox.Show(entries[93]);
                    AdventureCardDatabase.CreateCard(ref cards, 23);
                    break;
                case 811:
                    MessageBox.Show(entries[94]);
                    // Focus on Room Card N.
                    MainForm.OpenLocation('N');
                    // Create Form to deal with Character Event.
                    if (!hasdone)
                        CreatingForm.createCharEventForm(name, hp, 87);
                    else
                        LocEntry(ref cards, ref hp, name,id:561);
                    break;
                case 812:
                    MessageBox.Show("812: \"We cant leave the castle to Berengar, or else he'll find a way to uncover the " +
                        "tombs once more.And then it will start all over again!” \"You re right. We must " +
                        "confront him and stop him once and for all. ” \"Remember, though, he knows that we're" +
                        " coming and his potions are treacherous. ” \"I wont be sneaking off under the cover " +
                        "of darkness and leave the others to do the dirty work!” \"Then we all agree. ”" +
                        "Thus resolved, you step out onto the drawbridge.As feared, Berengar has been" +
                        "expecting you. \"Just look at you. Pitiful creatures lacking the courage to do something " +
                        "great.Do you really think you have a chance? Take a look at this...” He draws a" +
                        "shiny silver vial from beneath his cloak. \"My latest concoction!” Were he not so " +
                        "busy admiring his vial, that might have been it for you.You take advantage of" +
                        "this moment of distraction to take him by surprise.In the scuffle that ensues," +
                        "Berengar trips with the vial still in his hands.When he lands on the drawbridge," +
                        "the vial smashes.There’s a flash of light, followed by a huge explosion that rips" +
                        "your feet out from under you.As a group, you must give up 4 health points.You" +
                        "can divide these points up among yourselves however you wish." +
                        "When the smoke clears, you see that Berengar has come off worse than you.He" +
                        "lies motionless on the ground and a pool of blood slowly spreads out around" +
                        "him.The threat posed by Berengar has been resolved once and for all.And you’re" +
                        "finally free!Do you have adventure card 60 ? If so, then read entry 912.Otherwise, read entry 400.");
                    if (cards.FindIndex(p => p.ID == 60) != -1)
                        LocEntry(ref cards, ref hp, name,id:912);
                    else
                        LocEntry(ref cards, ref hp,name,id:400);
                    break;
                case 822:
                    MessageBox.Show(entries[95]);
                    break;
                case 846:
                    MessageBox.Show(entries[96]);
                    if (hp > 2)
                        hp -= 2;
                    else if (hp == 2)
                        hp--;
                    AdventureCardDatabase.ChangeHP(hp, name);
                    break;
                case 861:
                    MessageBox.Show(entries[97]);
                    LocEntry(ref cards, ref hp,name,id:811);
                    break;
                case 888:
                    MessageBox.Show(entries[98]);
                    AdventureCardDatabase.CreateCard(ref cards, 61);
                    AdventureCardDatabase.CreateCard(ref cards, 91);
                    break;
                case 901:
                    MessageBox.Show(entries[99]);
                    // Take Room Card C, put focus on it.
                    MainForm.OpenLocation('C');
                    LocEntry(ref cards, ref hp, name,entry:'C');
                    break;
                case 902:
                    MessageBox.Show(entries[100]);
                    break;
                case 903:
                    MessageBox.Show(entries[101]);
                    CreatingForm.createCharEventForm(name,hp,84);
                    AdventureCardDatabase.CompareDatabase(ref cards, ref hp);
                    break;
                case 904:
                    MessageBox.Show(entries[102]);
                    break;
                case 909:
                    MessageBox.Show(entries[103]);
                    AdventureCardDatabase.CreateCard(ref cards, 22);
                    break;
                case 912:
                    MessageBox.Show(entries[104]);
                    LocEntry(ref cards, ref hp, name,400);
                    break;
                case 946:
                    MessageBox.Show(entries[105]);
                    // Create Room Card O and put focus on it. 
                    MainForm.OpenLocation('O');
                    LocEntry(ref cards, ref hp,name,entry:'O');
                    break;
                case 971:
                    MessageBox.Show(entries[106]);
                    cards.RemoveAt(cards.FindIndex(p => p.ID == 78));
                    AdventureCardDatabase.RemoveCard(78);
                    break;
                default:
                    if(id != 0)
                        MessageBox.Show("Invalid entry ID.");
                    break;
            }
            if(MainForm.frm.Countdown == 0)
                MainForm.frm.CountDownFinished();
        }
        private static void calcFinalScore(int hp, List<Card> cards)
        {
            int score = hp;
            // 18, 47, 52, 60, 62, 70, 71, 73, 74, 75, 76, 77, 89, 91
            // if Edric is still alive.
            foreach(Card card in cards)
            {
                if (card.ID == 18 || card.ID == 47 || card.ID == 52 || card.ID == 60)
                    score += 2;
                else if (card.ID == 62 || card.ID == 70 || card.ID == 71 || card.ID == 73 || card.ID == 74)
                    score += 2;
                else if (card.ID == 75 || card.ID == 76 || card.ID == 77 || card.ID == 89 || card.ID == 91)
                    score += 2;
            }
            if (MainForm.frm.edrickAlive)
                score += 2;
            MessageBox.Show($"You have a total of {score}");
            Application.Exit();
        }
    }
}
