using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGameRH.Models;

namespace TBQuestGameRH.DataLayer
{
    public static class GameData
    {

        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Raoul Duke",
                Level = 0,
                CurrentStatus = Player.Status.Hallucinating,
                HP = 100,
                LocationId = 0,
                SkillLevel = 10,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001), 1, 1),                  
                }
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "We were somewhere around Barstow, near the edge of the desert, when the drugs began to take hold."
            };
        }

        private static NPC NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.ID == id);
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Location EmptyLocation()
        {
            return new Location()
            {
                Id = 0,
                Name = "",
                Description = "All energy flows according to the whims of the great magnet. What a fool I was to defy him.",
                Accessible = false,
                RequiredLevel = 4,
                
            };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 4;

            Map gameMap = new Map(rows, columns);



            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 4,
                Name = "The Desert",
                Description = "We were somewhere around Barstow on the edge of the desert when the drugs began to take hold." +
                " 'We can't stop here! This is bat country...'",
                Accessible = true,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1, 1)
                },
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                },
                Message = "He who makes a beast of himself gets rid of the pain of being a man.      -Dr. Johnson"
            };

            gameMap.MapLocations[0, 1] = EmptyLocation();

            gameMap.MapLocations[0, 2] = EmptyLocation();

            gameMap.MapLocations[0, 3] = EmptyLocation();

            //
            // row 2
            //
            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 1,
                Name = "Beverly Heights Hotel",
                Description = "I Couldn't Concentrate. Terrible things were happening all around us." +
                " Right next to me a huge reptile was gnawing on a woman's neck, the carpet was a blood-soaked sponge," +
                "-impossible to walk on it, no footing at all.",
                RequiredLevel = 1,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2001), 1, 0)
                },
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                    NpcById(2001),
                }
            };

            
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 2,
                Name = "The Circus Casino",
                Description = "The Circus-Circus is what the whole hep world would be doing if the Nazi's had won the war." +
                " This is the sixth Reich. The ground floor is full of gambling tables, like all the other casinos..." +
                " but the places is about four stories high, in the style of a circus tent, " +
                " and all manner of strange County-Fair/Polish Carnival madness is going on up in this space.",
                RequiredLevel = 2,
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                    NpcById(2002)
                }
            };

            gameMap.MapLocations[1, 2] = EmptyLocation();           

            gameMap.MapLocations[1, 3] = EmptyLocation();

            //
            // row 3
            //
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 4,
                Name = "Mint 400 Race Track",
                Description = "The racers were ready at dawn. Fine sunrise over the desert. Very Tense. But the race didn't start until nine," +
                " so we had to kill about three long hours in the casino next to the pits, and that's where the trouble started.",
                RequiredLevel = 1,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3003), 1, 1)
                },
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 11,
                Name = "Time Fog",
                Description = "All energy flows according to the whims of the great magnet. What a fool I was to defy him.",
                Accessible = true,
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                }
            };

            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 5,
                Name = "The Matrix",
                Description = "I recall one night in the Matrix, when a road-person came in with a big pack on his back, shouting: " +
                "“Anybody want some L…S…D…? I got all the makin’s right here. All I need is a place to cook.”",
                RequiredLevel = 2,
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(2003),
                }
            };

            gameMap.MapLocations[2, 3] = EmptyLocation();

            //
            // row 4
            //

            gameMap.MapLocations[3, 0] = EmptyLocation();

            gameMap.MapLocations[3, 1] = new Location()
            {
                Id = 7,
                Name = "The Flamingo Hotel",
                Description = "If the pigs were gathering in Vegas, I felt the drug culture should be represented as well. " +
                "And there was a certain bent appeal in the notion of running a savage burn in one Las Vegas Hotel, " +
                "and then just wheeling across town and checking into another. Me and a thousand ranking cops from all over America. " +
                "Why not? Move confidently into their midst.",
                RequiredLevel = 2,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3002),1,1)
                },
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                }

            };

            gameMap.MapLocations[3, 2] = new Location()
            {
                Id = 8,
                Name = "Police Drug Conference",
                Description = "We sat in the rear fringe of a crowd of about 1500 in the ballroom of the Dunes Hotel. Far up in front of the room" +
                ", barely visible from the rear, the executive director of the National District Attorneys' Association-a middle aged, well-groomed" +
                ", successful GOP businessman type named Patrick Healy-was opening their Third National Institute on Narcotics and Dangerous Drugs.",
                RequiredLevel = 2,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(1002), 1, 1)
                },
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                    NpcById(2004),
                }
            };

            gameMap.MapLocations[3, 3] = new Location()
            {
                Id = 9,
                Name = "Las Vegas Airport",
                Description = "I swung behind the van and hit the brakes just long enough for my attorney to jump out. 'Don't take any" +
                " guff from these swine,' I yelled. 'Remember, if you have any trouble you can always send a telegram to the Right People.",
                RequiredLevel = 4,
                
                Message = "Journalism is not a profession or trade. It is a cheap catchall for fuckoffs and misfits."
            };

            //
            // row 5
            //

            gameMap.MapLocations[4, 0] = EmptyLocation();

            gameMap.MapLocations[4, 1] = EmptyLocation();

            gameMap.MapLocations[4, 2] = new Location()
            {
                Id = 10,
                Name = "Baker",
                Description = "'They've nailed me!' I shouted. 'I'm trapped in some stinking desert crossroads called Baker. I don't have " +
                "much time. The fuckers are closing in.",
                RequiredLevel = 2,
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(2001),
                }
            };

            gameMap.MapLocations[4, 3] = EmptyLocation();

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, ".357 Magnum", 75, 3, 5, "", 0),
                new Weapon(1002, "Razor Sharp Hunting Knife", 30, 5, 7, "", 0),
                new Loot(2001, "600 Bars of neutrogena soap", 10, Loot.Loottype.Mundane, "From the Beverly Heights Hotel", 1),
                new Drug(3002, "Adrenochrome", 1000, 0, "Extract from a living human adrenaline gland.", 1, 1),
                new Drug(3003, "Devil Ether", 1000, 0, "Ether from the red devil.", 1, 1),
                new Drug(3001, "Sunshine Blotter Acid", 5, 1, "As your attorney, I advise you to drive at top speed, and it'll be a damn miracle if we get there before you turn into a wild animal.", 1, 5)
            };
        }

        public static List<NPC> Npcs()
        {
            return new List<NPC>()
            {
                new Worm()
                {
                    ID = 2001,
                    Name = "Reptile",
                    Description = "A giant lizard was gnawing on a woman's neck!",
                    Messages = new List<string>()
                    {
                        "You'd better order some golf shoes."
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Worm()
                {
                    ID = 2004,
                    Name = "Dr. Elron Bloomquist",
                    Description = "Author of the book 'Marijuana'.",
                    Messages = new List<string>()
                    {
                        "There are four states of being, cool, hip groovy, and square."
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Worm()
                {
                    ID = 2002,
                    Name = "Circus Wolverine",
                    Description = "The Circus Circus Flying Trapese Unleash thier secret weapon!",
                    Messages = new List<string>()
                    {
                        "Snarl snarl.",
                    },
                   SkillLevel = 3,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Worm()
                {
                    ID = 2003,
                    Name = "Me",
                    Description = "Holy fuck, there I am!",
                    Messages = new List<string>()
                    {
                        "The important thing is to cover this story on its own terms.",
                        "There was a fantastic universal sense that whatever we were doing was right, that we were winning.",
                        "In Las Vegas they kill the weak and deranged.",
                        "We're looking for the American dream, and we were told it was somewhere in this area."
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Friendly()
                {
                    ID = 1001,
                    Name = "Dr. Gonzo",
                    Description = "Your Samoan Attorney.",
                    Messages = new List<string>()
                    {
                        "One toke over the line, Sweet Jesus . . . One toke over the line . . .",
                        "Its Okay. I'm just Admiring the Shape of your skull."
                    }
                }
            };
        }
    }
}
