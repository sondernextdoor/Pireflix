using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pireflix
{
    public static class SeriesData
    {
        public static string[] gameOfThrones =
        {
            "Game of Thrones", // Title
            "4-17-2011", // Air date
            "8", // Season count

            "Winter Is Coming",
            "Eddard Stark is torn between his family and an old friend when asked to serve at the side of King Robert Baratheon; Viserys plans to wed his sister to a nomadic warlord in exchange for an army.",
            @"images\got\ep1.png",
            @"media\got\ep1.mp4",
            "1:01:37",

            "The Kingsroad",
            "While Bran recovers from his fall, Ned takes only his daughters to King's Landing. Jon Snow goes with his uncle Benjen to the Wall. Tyrion joins them.",
            @"images\got\ep2.png",
            @"media\got\ep2.mp4",
            "0:00:00",

            "Lord Snow",
            "Jon begins his training with the Night's Watch; Ned confronts his past and future at King's Landing; Daenerys finds herself at odds with Viserys.",
            @"images\got\ep3.png",
            @"media\got\ep3.mp4",
            "0:00:00",

            "Cripples, Bastards, and Broken Things",
            "Eddard investigates Jon Arryn's murder. Jon befriends Samwell Tarly, a coward who has come to join the Night's Watch.",
            @"images\got\ep4.png",
            @"media\got\ep4.mp4",
            "0:00:00",

            "The Wolf and the Lion",
            "Catelyn has captured Tyrion and plans to bring him to her sister, Lysa Arryn, at the Vale, to be tried for his, supposed, crimes against Bran. Robert plans to have Daenerys killed, but Eddard refuses to be a part of it and quits.",
            @"images\got\ep5.png",
            @"media\got\ep5.mp4",
            "0:00:00",

            "A Golden Crown",
            "While recovering from his battle with Jaime, Eddard is forced to run the kingdom while Robert goes hunting. Tyrion demands a trial by combat for his freedom. Viserys is losing his patience with Drogo.",
            @"images\got\ep6.png",
            @"media\got\ep6.mp4",
            "0:00:00",

            "You Win or You Die",
            "Robert has been injured while hunting and is dying. Jon and the others finally take their vows to the Night's Watch. A man, sent by Robert, is captured for trying to poison Daenerys. Furious, Drogo vows to attack the Seven Kingdoms.",
            @"images\got\ep7.png",
            @"media\got\ep7.mp4",
            "0:00:00",

            "The Pointy End",
            "The Lannisters press their advantage over the Starks; Robb rallies his father's northern allies and heads south to war; The White Walkers attack the Wall; Tyrion returns to his father with some new friends.",
            @"images\got\ep8.png",
            @"media\got\ep8.mp4",
            "0:00:00",

            "Baelor",
            "Robb goes to war against the Lannisters. Jon finds himself struggling on deciding if his place is with Robb or the Night's Watch. Drogo has fallen ill from a fresh battle wound. Daenerys is desperate to save him.",
            @"images\got\ep9.png",
            @"media\got\ep9.mp4",
            "0:00:00",

            "Fire and Blood",
            "Robb vows to get revenge on the Lannisters. Jon must officially decide if his place is with Robb or the Night's Watch. Daenerys says her final goodbye to Drogo.",
            @"images\got\ep10.png",
            @"media\got\ep10.mp4",
            "0:00:00",

            "Pireflix Season End Id"
        };

        public static string[] starTrekDS9 =
        {
            "Star Trek: Deep Space Nine",
            "1-3-1993",
            "7",

            "Emissary",
            "A new joint Federation/Bajoran crew is assigned to a former Cardassian space station: Deep Space Nine. Benjamin Sisko, the new station commander, discovers a stable wormhole connecting Bajor to the Gamma Quadrant.",
            @"images\ds9\ep1.png",
            @"media\ds9\ep1.mp4",
            "0:00:00",

            "Past Prologue",
            "A Bajoran terrorist with ties to Kira arrives on Deep Space Nine and is pursued by the Cardassians. Garak, a mysterious Cardassian tailor who lives on the station, assists in uncovering what he is up to.",
            @"images\ds9\ep2.png",
            @"media\ds9\ep2.mp4",
            "0:00:00",

            "A Man Alone",
            "Odo is accused of the murder of a Bajoran murderer.",
            @"images\ds9\ep3.png",
            @"media\ds9\ep3.mp4",
            "0:00:00",

            "Babel",
            "A mysterious virus plagues the station, causing first aphasia and eventually death.",
            @"images\ds9\ep4.png",
            @"media\ds9\ep4.mp4",
            "0:00:00",

            "Captive Pursuit",
            "O'Brien befriends an alien from the Gamma Quadrant who is being hunted.",
            @"images\ds9\ep5.png",
            @"media\ds9\ep5.mp4",
            "0:00:00",

            "Q-Less",
            "Q and Vash arrive on Deep Space Nine. However, Vash has grown annoyed by Q's attention and wants him to leave her alone.",
            @"images\ds9\ep6.png",
            @"media\ds9\ep6.mp4",
            "0:00:00",

            "Dax",
            "Jadzia Dax is arrested for a murder allegedly committed by Curzon Dax, a previous host of her symbiont. An extradition hearing is held to determine whether Jadzia can be held liable for Curzon's actions.",
            @"images\ds9\ep7.png",
            @"media\ds9\ep7.mp4",
            "0:00:00",

            "The Passenger",
            "A sinister criminal cheats death to hide his consciousness in the mind of someone on Deep Space Nine.",
            @"images\ds9\ep8.png",
            @"media\ds9\ep8.mp4",
            "0:00:00",

            "Move Along Home",
            "Quark plays a board game with the Wadi, a newly encountered species from the Gamma Quadrant, and the lives of the crew seemingly depend on the outcome.",
            @"images\ds9\ep9.png",
            @"media\ds9\ep9.mp4",
            "0:00:00",

            "The Nagus",
            "Quark is named as the head of the Ferengi Alliance by Grand Nagus Zek, but he is now surrounded by enemies.",
            @"images\ds9\ep10.png",
            @"media\ds9\ep10.mp4",
            "0:00:00",

            "Vortex",
            "Odo discovers he might not be the only one of his kind when a visitor from the Gamma Quadrant claims he can contact Odo's people.",
            @"images\ds9\ep11.png",
            @"media\ds9\ep11.mp4",
            "0:00:00",

            "Battle Lines",
            "The spiritual leader of Bajor, Kai Opaka, travels with Sisko, Bashir and Kira on a trip to the Gamma Quadrant, but is stranded on a world where the dead are resurrected.",
            @"images\ds9\ep12.png",
            @"media\ds9\ep12.mp4",
            "0:00:00",

            "The Storyteller",
            "O'Brien is recruited to save a Bajoran village from destruction by a mysterious cloud creature.",
            @"images\ds9\ep13.png",
            @"media\ds9\ep13.mp4",
            "0:00:00",

            "Progress",
            "Kira has to deal with a stubborn farmer (Brian Keith) who refuses to leave his home even though it is slated for demolition.",
            @"images\ds9\ep14.png",
            @"media\ds9\ep14.mp4",
            "0:00:00",

            "If Wishes Were Horses",
            "Deep Space Nine is put in jeopardy when the crew's thoughts manifest themselves, and such figures as Rumpelstiltskin appear.",
            @"images\ds9\ep15.png",
            @"media\ds9\ep15.mp4",
            "0:00:00",

            "The Foresaken",
            "The Federation ambassador from Betazed, Lwaxana Troi, visits the station, and develops an affection for Odo. Meanwhile, data from a mysterious Gamma Quadrant probe causes system failures on DS9.",
            @"images\ds9\ep16.png",
            @"media\ds9\ep16.mp4",
            "0:00:00",

            "Dramatis Personae",
            "Tensions rise between the DS9 crew members after they are telepathically imprinted with the memories of participants in an alien power struggle.",
            @"images\ds9\ep17.png",
            @"media\ds9\ep17.mp4",
            "0:00:00",

            "Duet",
            "A visiting Cardassian, Marritza, may in fact be the notorious war criminal Gul Darhe'el, butcher of Gallitep labor camp, and Kira is determined to bring him down.",
            @"images\ds9\ep18.png",
            @"media\ds9\ep18.mp4",
            "0:00:00",

            "In the Hands of the Prophets",
            "A conniving Bajoran cleric, Vedek Winn, protests Keiko O'Brien's school on Deep Space Nine when she discovers Keiko is teaching her students that the inhabitants of the wormhole are aliens, not gods.",
            @"images\ds9\ep19.png",
            @"media\ds9\ep19.mp4",
            "0:00:00",

            "Pireflix Season End Id"
        };
    }
}