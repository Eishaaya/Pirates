using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System.IO.Ports;

namespace platforming_pirates
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum levelstate
        {
            none,
            Proluage,
            Level1,
            Level2,
            Level3,
            Level4,
            level5,
            cannonfort
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //List<Rectangle> practiceFrames;
        TimeSpan untilenemypirate = new TimeSpan(0, 0, 0, 0, 350);
        TimeSpan untilenemycaptain = new TimeSpan(0, 0, 0, 0, 750);
        TimeSpan Untilnewcloud = new TimeSpan(0, 0, 0, 4, 500);
        TimeSpan untilredcoat = new TimeSpan(0, 0, 0, 2, 500);
        TimeSpan untilbluecoat = new TimeSpan(0, 0, 0, 1, 500);
        TimeSpan untilcrewcall = new TimeSpan(0, 2, 30);
        TimeSpan waitcrewcall = new TimeSpan(0, 1, 20);
        TimeSpan waitnewsong;
        TimeSpan untilnewsong = new TimeSpan(0, 3, 16);
        TimeSpan waitredcoat;
        TimeSpan waitbluecoat;
        TimeSpan waitenemycaptain;
        TimeSpan waitenemypirate;
        TimeSpan waitnewcloud;
        Sprite backround;
        AnimatingSprite jack;
        AnimatingSprite uglyguy;
        List<AnimatingSprite> enemypirates;
        AnimatingSprite boat;
        KeyboardState ks;
        Song music;
        int jackx;
        int jacky;
        float gravity = 0f;
        platform ship;
        platform cabin;
        platform cabin2;
        platform mast;
        platform crow;
        platform mast2;
        platform mast3;
        platform island;
        platform island2;
        platform palmtree;
        List<Rectangle> portroyalh = new List<Rectangle>();
        Sprite palm;
        bool menu = true;
        bool began = false;
        Sprite menuback;
        Sprite losescreen;
        AnimatingSprite pirahna;
        List<platform> platforms = new List<platform>();
        List<AnimatingSprite> enemycaptians = new List<AnimatingSprite>();
        List<Rectangle> sparrowframes = new List<Rectangle>();
        List<Rectangle> sparrowcrouch = new List<Rectangle>();
        List<Rectangle> sparrowrun = new List<Rectangle>();
        List<Rectangle> sparrowattack = new List<Rectangle>();
        List<Rectangle> sparrowca = new List<Rectangle>();
        List<Rectangle> sparrowja = new List<Rectangle>();
        List<Rectangle> piratewalk = new List<Rectangle>();
        List<Rectangle> pirateattack = new List<Rectangle>();
        List<Rectangle> piratestand = new List<Rectangle>();
        List<Rectangle> captainstand = new List<Rectangle>();
        List<Rectangle> captainwalk = new List<Rectangle>();
        List<Rectangle> captainattack = new List<Rectangle>();
        List<Rectangle> piranhas = new List<Rectangle>();
        List<Rectangle> boatmove = new List<Rectangle>();
        List<Rectangle> turtleup = new List<Rectangle>();
        List<Rectangle> turtledown = new List<Rectangle>();
        List<Rectangle> logmove = new List<Rectangle>();
        List<Rectangle> barrelmove = new List<Rectangle>();
        List<Rectangle> brokenbarrelmove = new List<Rectangle>();
        List<Rectangle> bucketmove = new List<Rectangle>();
        List<Rectangle> boxmove = new List<Rectangle>();
        List<Rectangle> turtlestand = new List<Rectangle>();
        List<Rectangle> turtleswim = new List<Rectangle>();
        List<Rectangle> turtlehappy = new List<Rectangle>();
        List<Rectangle> clammove = new List<Rectangle>();
        List<Rectangle> piratedead = new List<Rectangle>();
        List<Rectangle> captaindead = new List<Rectangle>();
        AnimatingSprite clam;
        AnimatingSprite clam2;
        platform pebble;
        platform stone;
        platform rock;
        platform boulder;
        MouseState ms;
        Button prologue;
        Button level1;
        Button level2;
        Button level3;
        int unlocker = 3;
        levelstate currentLevel;
        Sprite backround2;
        AnimatingSprite brokenbarrel;
        AnimatingSprite barrel;
        AnimatingSprite log;
        AnimatingSprite box;
        AnimatingSprite turtle;
        AnimatingSprite turtle2;
        AnimatingSprite turtle3;
        AnimatingSprite turtle4;
        AnimatingSprite turtle5;
        AnimatingSprite turtle6;
        AnimatingSprite turtle7;
        AnimatingSprite turtle8;
        Sprite raceflag;
        Sprite exitsign;
        bool turtledecend = false;
        camera samthecam;
        Sprite sea;
        Sprite shackland;
        platform hackland;
        Color color;
        Sprite dock;
        platform dockplat;
        platform road;
        Sprite dock2;
        platform dockplat2;
        platform rope;
        platform watchtowerp;
        Sprite watchtower;
        Sprite brownstone;
        platform brownstonep;
        Sprite germanhouse;
        platform germanhousep;
        Sprite brownstone2;
        platform brownstonep2;
        Sprite germanhouse2;
        platform germanhousep2;
        Sprite brownstone3;
        platform brownstonep3;
        Sprite brownstone4;
        platform brownstonep4;
        Sprite germanhouse3;
        platform germanhousep3;
        platform gech;
        platform gech2;
        platform gech3;
        platform road2;
        platform roperampart;
        platform rampart;
        platform castleclimb;
        platform castletop;
        platform shackp;
        Sprite castle;
        Sprite shack;
        Sprite fishbox;
        platform boxp;
        List<Sprite> clouds;
        Sprite cloud;
        Random random = new Random();
        Sprite plane;
        List<Rectangle> redcoatwalk = new List<Rectangle>();
        List<Rectangle> redcoatattack = new List<Rectangle>();
        List<Rectangle> redcoatdie = new List<Rectangle>();
        List<Rectangle> redcoatdead = new List<Rectangle>();
        List<Rectangle> redcoatstand = new List<Rectangle>();
        List<Rectangle> bluecoatwalk = new List<Rectangle>();
        List<Rectangle> bluecoatattack = new List<Rectangle>();
        List<Rectangle> bluecoatdie = new List<Rectangle>();
        List<Rectangle> bluecoatdead = new List<Rectangle>();
        List<AnimatingSprite> coats = new List<AnimatingSprite>();
        List<Rectangle> escaper = new List<Rectangle>();
        List<Rectangle> shipdown = new List<Rectangle>();
        List<Rectangle> shipup = new List<Rectangle>();
        List<Rectangle> shipleft = new List<Rectangle>();
        List<Rectangle> shipright = new List<Rectangle>();
        int redcount = 49;
        int bluecount = 199;
        int lives = 0;
        List<shooter> blues;
        Sprite crewcall;
        bool callthecrew = true;
        int captaincount = -3;
        int piratecount = -15;
        SerialPort port;
        string data;
        bool waitforopen = true;
        int xAxis;
        int yAxis;
        bool B1;
        bool B2;
        bool B3;
        bool B4;
        bool hijacked = false;
        AnimatingSprite escapeship;
        Sprite fishstand;
        platform fsp;
        Sprite ph;
        platform php;
        Sprite ph2;
        platform php2;
        Sprite ph3;
        platform php3;
        Sprite ph4;
        platform php4;
        Sprite ph5;
        platform php5;
        Sprite ph6;
        platform php6;
        Sprite tavern;
        platform tavernp;
        Sprite starboard;
        ship vessel;
        camera InTheNavy;
        AnimatingSprite fort;
        List<Rectangle> shootup = new List<Rectangle>();
        List<Rectangle> shootdown = new List<Rectangle>();
        List<Rectangle> shootleft = new List<Rectangle>();
        List<Rectangle> shootright = new List<Rectangle>();
        List<Rectangle> shootupleft = new List<Rectangle>();
        List<Rectangle> shootupright = new List<Rectangle>();
        List<Rectangle> shootdownleft = new List<Rectangle>();
        List<Rectangle> shootdownright = new List<Rectangle>();
        List<AnimatingSprite> forts = new List<AnimatingSprite>();
        Turret cannon;
        List<Rectangle> cannonimage = new List<Rectangle>();
        List<Rectangle> FrigateFrames = new List<Rectangle>();
        AnimatingSprite IslandOfHotDogs;
        List<Rectangle> HotDiggityDog = new List<Rectangle>();
        int money = 10000;
        label moneymoneys;
        List<Rectangle> supercoatattack = new List<Rectangle>();
        List<Rectangle> supercoatdeath = new List<Rectangle>();
        List<Rectangle> supercoatstand = new List<Rectangle>();
        List<Rectangle> supercoatdead = new List<Rectangle>();
        List<AnimatingSprite> bosses = new List<AnimatingSprite>();
        AnimatingSprite portroyal;
        bool isarduinoworking = false;
        Sprite cursor;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ks = new KeyboardState();
            enemypirates = new List<AnimatingSprite>();
            music = Content.Load<Song>("backround_music");
            MediaPlayer.Play(music);
            cursor = new Sprite(Content.Load<Texture2D>("cursor"), new Vector2(ms.X, ms.Y), Color.White);
            moneymoneys = new label(Content.Load<SpriteFont>("Spritefont1"), "", new Vector2(0, 0), Color.DarkGreen);
            menuback = new Sprite(Content.Load<Texture2D>("skull"), new Vector2(0, 0), Color.White);
            backround = new Sprite(Content.Load<Texture2D>("backround"), new Vector2(0, 0), Color.White);
            ship = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(520, 500, 650, 1));
            cabin = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(400, 450, 150, 1));
            cabin2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(250, 420, 150, 1));
            mast = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(425, 290, 30, 1));
            mast2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(600, 250, 75, 1));
            mast3 = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(910, 260, 70, 1));
            pebble = new platform(Content.Load<Texture2D>("ip"), new Vector2(1600, 720), Color.White, new Rectangle(1600, 720, 50, 1));
            stone = new platform(Content.Load<Texture2D>("ip"), new Vector2(1640, 710), Color.White, new Rectangle(1640, 700, 20, 1));
            rock = new platform(Content.Load<Texture2D>("ip"), new Vector2(1690, 600), Color.White, new Rectangle(1670, 660, 20, 1));
            boulder = new platform(Content.Load<Texture2D>("ip"), new Vector2(1700, 700), Color.White, new Rectangle(1700, 600, 150, 1));
            crow = new platform(Content.Load<Texture2D>("ip"), new Vector2(500, 300), Color.White, new Rectangle(435, 115, 15, 1));
            palm = new Sprite(Content.Load<Texture2D>("palm"), new Vector2(650, 525), Color.White);
            palmtree = new platform(Content.Load<Texture2D>("ip"), new Vector2(800, 550), Color.White, new Rectangle(700, 585, 100, 1));
            losescreen = new Sprite(Content.Load<Texture2D>("lose"), new Vector2(600, 150), Color.White);
            boat = new AnimatingSprite(Content.Load<Texture2D>("boat"), new Vector2(500, 600), Color.White, 100, new Rectangle(0, 0, 0, 0), 100, 0, Content.Load<SpriteFont>("SpriteFont1"));
            prologue = new Button(Content.Load<SpriteFont>("SpriteFont1"), "Prologue:\nMutiny", Content.Load<Texture2D>("button"), new Vector2(100, 100), Color.White, new Rectangle(100, 100, 180, 100));
            level1 = new Button(Content.Load<SpriteFont>("SpriteFont1"), "Level1:\nMarooned!", Content.Load<Texture2D>("button"), new Vector2(380, 100), Color.White, new Rectangle(380, 100, 180, 100));
            level2 = new Button(Content.Load<SpriteFont>("SpriteFont1"), "Level2:\nPort Royal", Content.Load<Texture2D>("button"), new Vector2(660, 100), Color.White, new Rectangle(660, 100, 180, 100));
            level3 = new Button(Content.Load<SpriteFont>("SpriteFont1"), "Level3:\nNaval Chase", Content.Load<Texture2D>("button"), new Vector2(940, 100), Color.White, new Rectangle(940, 100, 180, 100));
            backround2 = new Sprite(Content.Load<Texture2D>("island"), new Vector2(0, 0), Color.White);
            brokenbarrel = new AnimatingSprite(Content.Load<Texture2D>("float"), new Vector2(1500, 600), Color.White, 105, new Rectangle(550, 1600, 0, 0), 100, 0, Content.Load<SpriteFont>("SpriteFont1"));
            barrel = new AnimatingSprite(Content.Load<Texture2D>("float"), new Vector2(1300, 560), Color.White, 105, new Rectangle(510, 1500, 0, 0), 100, 0, Content.Load<SpriteFont>("SpriteFont1"));
            log = new AnimatingSprite(Content.Load<Texture2D>("float"), new Vector2(1160, 540), Color.White, 105, new Rectangle(510, 1500, 0, 0), 100, 0, Content.Load<SpriteFont>("SpriteFont1"));
            box = new AnimatingSprite(Content.Load<Texture2D>("float"), new Vector2(1000, 540), Color.White, 105, new Rectangle(400, 600, 0, 0), 100, 0, Content.Load<SpriteFont>("SpriteFont1"));
            island = new platform(Content.Load<Texture2D>("ip"), new Vector2(0, 650), Color.White, new Rectangle(0, 660, 760, 1));
            island2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(0, 650), Color.White, new Rectangle(740, 640, 140, 1));
            turtle = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(0, 650), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle2 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(1700, 590), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle3 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(1000, 530), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle4 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(40, 600), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle5 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(-250, 800), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle6 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(0, 800), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle7 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(725, 575), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            turtle8 = new AnimatingSprite(Content.Load<Texture2D>("turtles"), new Vector2(1230, 605), Color.White, 105, new Rectangle(500, 500, 0, 0), 100, 1, Content.Load<SpriteFont>("SpriteFont1"));
            clam = new AnimatingSprite(Content.Load<Texture2D>("clam"), new Vector2(1600, 825), Color.White, 105, new Rectangle(0, 0, 0, 0), 100, 2, Content.Load<SpriteFont>("SpriteFont1"));
            clam2 = new AnimatingSprite(Content.Load<Texture2D>("clam"), new Vector2(1645, 825), Color.White, 105, new Rectangle(0, 0, 0, 0), 100, 2, Content.Load<SpriteFont>("SpriteFont1"));
            raceflag = new Sprite(Content.Load<Texture2D>("raceflag"), new Vector2(745, 550), Color.White);
            exitsign = new Sprite(Content.Load<Texture2D>("es"), new Vector2(1550, 800), Color.White);
            sea = new Sprite(Content.Load<Texture2D>("ocean"), new Vector2(0, 650), Color.White);
            shackland = new Sprite(Content.Load<Texture2D>("shackland"), new Vector2(850, 445), Color.White);
            hackland = new platform(Content.Load<Texture2D>("ip"), new Vector2(880, 640), Color.White, new Rectangle(880, 640, 330, 1));
            dock = new Sprite(Content.Load<Texture2D>("dock"), new Vector2(3500, 560), Color.Gray);
            dockplat = new platform(Content.Load<Texture2D>("ip"), new Vector2(3500, 575), Color.White, new Rectangle(3500, 540, 266, 1));
            dock2 = new Sprite(Content.Load<Texture2D>("dock"), new Vector2(18766, 560), Color.Gray);
            dockplat2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(18766, 575), Color.White, new Rectangle(18766, 540, 266, 1));
            road = new platform(Content.Load<Texture2D>("street"), new Vector2(3500, 640), Color.Gray, new Rectangle(3766, 560, 7500, 125));
            road2 = new platform(Content.Load<Texture2D>("street"), new Vector2(11266, 640), Color.Gray, new Rectangle(11266, 560, 7500, 125));
            watchtowerp = new platform(Content.Load<Texture2D>("ip"), new Vector2(3800, 75), Color.White, new Rectangle(3800, 125, 260, 5));
            rope = new platform(Content.Load<Texture2D>("ip"), new Vector2(4016, 125), Color.White, new Rectangle(4016, 125, 1, 425));
            watchtower = new Sprite(Content.Load<Texture2D>("watchtower"), new Vector2(3800, 25), Color.White);
            brownstone = new Sprite(Content.Load<Texture2D>("brownstone house"), new Vector2(5000, 360), Color.White);
            brownstone4 = new Sprite(Content.Load<Texture2D>("brownstone house"), new Vector2(13000, 360), Color.White);
            brownstone2 = new Sprite(Content.Load<Texture2D>("brownstone house"), new Vector2(8000, 360), Color.White);
            brownstone3 = new Sprite(Content.Load<Texture2D>("brownstone house"), new Vector2(6500, 360), Color.White);
            germanhouse = new Sprite(Content.Load<Texture2D>("german house"), new Vector2(4500, 377), Color.White);
            germanhouse2 = new Sprite(Content.Load<Texture2D>("german house"), new Vector2(8500, 377), Color.White);
            germanhouse3 = new Sprite(Content.Load<Texture2D>("german house"), new Vector2(6000, 377), Color.White);
            brownstonep = new platform(Content.Load<Texture2D>("ip"), new Vector2(5015, 370), Color.White, new Rectangle(5015, 370, 190, 10));
            brownstonep4 = new platform(Content.Load<Texture2D>("ip"), new Vector2(5015, 370), Color.White, new Rectangle(13015, 370, 190, 10));
            brownstonep2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(8015, 370), Color.White, new Rectangle(8015, 370, 190, 10));
            brownstonep3 = new platform(Content.Load<Texture2D>("ip"), new Vector2(6515, 370), Color.White, new Rectangle(6515, 370, 190, 10));
            germanhousep = new platform(Content.Load<Texture2D>("ip"), new Vector2(4500, 385), Color.White, new Rectangle(4500, 410, 175, 5));
            germanhousep2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(8500, 385), Color.White, new Rectangle(8500, 410, 175, 5));
            germanhousep3 = new platform(Content.Load<Texture2D>("ip"), new Vector2(6000, 385), Color.White, new Rectangle(6000, 410, 175, 5));
            gech = new platform(Content.Load<Texture2D>("ip"), new Vector2(4510, 385), Color.White, new Rectangle(4510, 385, 25, 5));
            gech2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(8510, 385), Color.White, new Rectangle(8510, 385, 25, 5));
            gech3 = new platform(Content.Load<Texture2D>("ip"), new Vector2(6010, 385), Color.White, new Rectangle(6010, 385, 25, 5));
            castle = new Sprite(Content.Load<Texture2D>("castle"), new Vector2(9000, -165), Color.White);
            roperampart = new platform(Content.Load<Texture2D>("ip"), new Vector2(6010, 385), Color.White, new Rectangle(9000, 45, 150, 5));
            rampart = new platform(Content.Load<Texture2D>("ip"), new Vector2(6010, 385), Color.White, new Rectangle(9600, 45, 150, 5));
            castleclimb = new platform(Content.Load<Texture2D>("ip"), new Vector2(6010, 385), Color.White, new Rectangle(9000, 45, 3, 715));
            castletop = new platform(Content.Load<Texture2D>("ip"), new Vector2(6010, 385), Color.White, new Rectangle(9000, 80, 725, 1));
            shack = new Sprite(Content.Load<Texture2D>("shack"), new Vector2(9800, 485), Color.White);
            shackp = new platform(Content.Load<Texture2D>("ip"), new Vector2(9800, 505), Color.White, new Rectangle(9800, 505, 55, 5));
            fishbox = new Sprite(Content.Load<Texture2D>("fishbox"), new Vector2(9900, 535), Color.White);
            boxp = new platform(Content.Load<Texture2D>("ip"), new Vector2(9900, 535), Color.White, new Rectangle(9900, 535, 25, 1));
            fishstand = new Sprite(Content.Load<Texture2D>("fishstand"), new Vector2(10000, 480), Color.White);
            fsp = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(10000, 475, 75, 1));
            ph = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(11500, 435), Color.White);
            php = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 470), Color.White, new Rectangle(11500, 465, 200, 1));
            ph2 = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(12000, 435), Color.White);
            php2 = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(12000, 465, 200, 1));
            ph3 = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(12500, 435), Color.White);
            php3 = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(12500, 465, 200, 1));
            ph4 = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(13700, 435), Color.White);
            php4 = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(13700, 465, 200, 1));
            ph5 = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(14200, 435), Color.White);
            php5 = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(14200, 465, 200, 1));
            tavern = new Sprite(Content.Load<Texture2D>("tavern"), new Vector2(14700, 405), Color.White);
            tavernp = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(14700, 435, 400, 1));
            ph6 = new Sprite(Content.Load<Texture2D>("fishermanhouse"), new Vector2(15300, 435), Color.White);
            php6 = new platform(Content.Load<Texture2D>("ip"), new Vector2(1000, 500), Color.White, new Rectangle(15300, 465, 200, 1));
            cloud = new Sprite(Content.Load<Texture2D>("fog"), new Vector2(500, 0), Color.White);
            clouds = new List<Sprite>();
            clouds.Add(cloud);
            plane = new Sprite(Content.Load<Texture2D>("plane"), new Vector2(-25000, 0), Color.White);
            blues = new List<shooter>();
            starboard = new Sprite(Content.Load<Texture2D>("starboard"), new Vector2(0, 0), Color.White);
            fort = new AnimatingSprite(Content.Load<Texture2D>("fort"), new Vector2(0, 0), Color.White, 100, new Rectangle(150, 100, 743, 539), 5000, 45, Content.Load<SpriteFont>("SpriteFont1"));
            fort.personalspace = new Rectangle(35, 10, 940, 749);
            portroyal = new AnimatingSprite(Content.Load<Texture2D>("pr"), new Vector2(0, 1250), Color.White, 100, new Rectangle(150, 1350, 2000, 1800), 5000, 45, Content.Load<SpriteFont>("SpriteFont1"));

            cannon = new Turret(Content.Load<Texture2D>("cannon"), new Vector2(fort.Location.X + fort.Image.Width / 2 - 175, fort.Location.Y + fort.Image.Height / 2 - 100), Color.White, 1500, new Rectangle(0, 0, 0, 0), 20, 499, Content.Load<SpriteFont>("Spritefont1"), new List<ammo>(), new TimeSpan(0, 0, 0, 0, 500), Content.Load<Texture2D>("shot"), new Vector2(10, 1 / 2), new Rectangle(0, 0, -100, 1), 0, 0);
            cannon.origin = new Vector2(135, 110);
            cannon.Location += cannon.origin;

            IslandOfHotDogs = new AnimatingSprite(Content.Load<Texture2D>("hotdog village"), new Vector2(-2500, -2500), Color.White, 100, new Rectangle(-2470, -2470, 458, 287), 5000, 30, Content.Load<SpriteFont>("SpriteFont1"));
            vessel = new ship(Content.Load<Texture2D>("frigate"), new Vector2(-2000, -2000), Color.White, 100, new Rectangle(0, 0, 0, 0), 2500, 250, Content.Load<SpriteFont>("SpriteFont1"), new List<ammo>(), new TimeSpan(0, 0, 0, 0, 750), Content.Load<Texture2D>("shot"), new Vector2(7, 7), new Rectangle(0, 0, 0, 0), 15, new Vector2(0, 0), new Sprite(Content.Load<Texture2D>("ancor"), new Vector2(0, 0), Color.White), 3);
            vessel.hpdisplacement = 175;

            turtle.LoadFrameList(turtleswim, AnimatingSprite.State.Running);
            turtle.LoadFrameList(turtlehappy, AnimatingSprite.State.Attacking);
            turtle.LoadFrameList(turtlestand, AnimatingSprite.State.Standing);
            turtle.CurrentState = AnimatingSprite.State.Running;

            turtle2.LoadFrameList(turtlehappy, AnimatingSprite.State.Attacking);
            turtle2.CurrentState = AnimatingSprite.State.Attacking;

            turtle3.LoadFrameList(turtlestand, AnimatingSprite.State.Standing);
            turtle3.CurrentState = AnimatingSprite.State.Standing;

            turtle5.LoadFrameList(turtleswim, AnimatingSprite.State.Running);
            turtle5.CurrentState = AnimatingSprite.State.Running;

            turtle6.LoadFrameList(turtleswim, AnimatingSprite.State.Running);
            turtle6.CurrentState = AnimatingSprite.State.Running;

            turtle7.LoadFrameList(turtlehappy, AnimatingSprite.State.Attacking);
            turtle7.CurrentState = AnimatingSprite.State.Attacking;

            turtle4.LoadFrameList(turtlestand, AnimatingSprite.State.Standing);
            turtle4.CurrentState = AnimatingSprite.State.Standing;

            turtle8.LoadFrameList(turtlestand, AnimatingSprite.State.Standing);
            turtle8.CurrentState = AnimatingSprite.State.Standing;

            clam.LoadFrameList(clammove, AnimatingSprite.State.Standing);
            clam.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
            clam.CurrentState = AnimatingSprite.State.Standing;

            clam2.LoadFrameList(clammove, AnimatingSprite.State.Standing);
            clam2.CurrentState = AnimatingSprite.State.Standing;

            brokenbarrel.LoadFrameList(brokenbarrelmove, AnimatingSprite.State.Standing);
            brokenbarrel.CurrentState = AnimatingSprite.State.Standing;

            barrel.LoadFrameList(barrelmove, AnimatingSprite.State.Standing);
            barrel.CurrentState = AnimatingSprite.State.Standing;

            log.LoadFrameList(logmove, AnimatingSprite.State.Standing);
            log.CurrentState = AnimatingSprite.State.Standing;

            box.LoadFrameList(boxmove, AnimatingSprite.State.Standing);
            box.CurrentState = AnimatingSprite.State.Standing;

            HotDiggityDog.Add(new Rectangle(0, 0, 688, 407));
            IslandOfHotDogs.LoadFrameList(HotDiggityDog, AnimatingSprite.State.Standing);
            IslandOfHotDogs.currentState = AnimatingSprite.State.Standing;

            portroyalh.Add(new Rectangle(0, 0, 2011, 1820));
            portroyal.LoadFrameList(portroyalh, AnimatingSprite.State.Standing);
            portroyal.currentState = AnimatingSprite.State.Standing;

            platforms.Add(ship);
            platforms.Add(cabin);
            platforms.Add(cabin2);
            platforms.Add(mast);
            platforms.Add(mast2);
            platforms.Add(mast3);
            platforms.Add(crow);

            supercoatstand.Add(new Rectangle(136, 10, 83, 76));
            supercoatstand.Add(new Rectangle(221, 10, 85, 76));
            supercoatstand.Add(new Rectangle(308, 10, 83, 76));
            supercoatstand.Add(new Rectangle(393, 10, 83, 76));

            supercoatattack.Add(new Rectangle(11,141, 96, 70));
            supercoatattack.Add(new Rectangle(109, 141, 84, 69));
            supercoatattack.Add(new Rectangle(196, 149, 64, 62));
            supercoatattack.Add(new Rectangle(261, 149, 68, 63));
            supercoatattack.Add(new Rectangle(331, 108, 92, 104));
            supercoatattack.Add(new Rectangle(425, 109, 81, 103));
            supercoatattack.Add(new Rectangle(508, 109, 91, 104));

            supercoatdeath.Add(new Rectangle(183, 228, 78, 72));
            supercoatdeath.Add(new Rectangle(262, 228, 79, 72));
            supercoatdeath.Add(new Rectangle(342, 228, 81, 72));
            supercoatdeath.Add(new Rectangle(427, 222, 86, 72));

            supercoatdead.Add(new Rectangle(519, 236, 76, 60));

            escaper.Add(new Rectangle(0, 281, 461, 281));

            sparrowframes.Add(new Rectangle(6, 9, 37, 53));

            sparrowcrouch.Add(new Rectangle(7, 76, 36, 45));
            sparrowcrouch.Add(new Rectangle(46, 87, 38, 36));

            sparrowrun.Add(new Rectangle(3, 131, 36, 43));
            sparrowrun.Add(new Rectangle(51, 128, 35, 48));
            sparrowrun.Add(new Rectangle(101, 131, 39, 47));
            sparrowrun.Add(new Rectangle(154, 131, 44, 42));
            sparrowrun.Add(new Rectangle(214, 133, 40, 42));
            sparrowrun.Add(new Rectangle(269, 133, 37, 45));

            sparrowattack.Add(new Rectangle(2, 194, 37, 48));
            sparrowattack.Add(new Rectangle(53, 195, 39, 46));
            sparrowattack.Add(new Rectangle(114, 198, 57, 42));
            sparrowattack.Add(new Rectangle(194, 199, 50, 43));
            sparrowattack.Add(new Rectangle(260, 201, 32, 43));
            sparrowattack.Add(new Rectangle(315, 202, 32, 44));
            sparrowattack.Add(new Rectangle(9, 260, 32, 45));
            sparrowattack.Add(new Rectangle(61, 257, 39, 46));
            sparrowattack.Add(new Rectangle(131, 254, 59, 47));
            sparrowattack.Add(new Rectangle(289, 263, 44, 43));

            sparrowca.Add(new Rectangle(12, 328, 26, 36));
            sparrowca.Add(new Rectangle(54, 331, 52, 36));
            sparrowca.Add(new Rectangle(123, 332, 39, 36));
            sparrowca.Add(new Rectangle(189, 333, 35, 36));
            sparrowca.Add(new Rectangle(247, 335, 28, 34));
            sparrowca.Add(new Rectangle(304, 336, 44, 33));
            sparrowja.Add(new Rectangle(10, 400, 34, 49));
            sparrowja.Add(new Rectangle(59, 392, 30, 47));
            sparrowja.Add(new Rectangle(159, 389, 49, 43));
            sparrowja.Add(new Rectangle(313, 387, 56, 58));
            sparrowja.Add(new Rectangle(391, 397, 29, 48));

            piratestand.Add(new Rectangle(3, 307, 28, 38));
            piratewalk.Add(new Rectangle(32, 305, 34, 39));
            piratewalk.Add(new Rectangle(78, 306, 28, 38));
            piratewalk.Add(new Rectangle(124, 305, 35, 39));
            piratewalk.Add(new Rectangle(170, 306, 28, 38));
            piratewalk.Add(new Rectangle(230, 306, 30, 38));
            piratewalk.Add(new Rectangle(277, 301, 19, 43));
            piratewalk.Add(new Rectangle(324, 301, 13, 43));

            captainwalk.Add(new Rectangle(53, 407, 34, 37));
            captainwalk.Add(new Rectangle(105, 408, 29, 36));
            captainwalk.Add(new Rectangle(146, 407, 33, 37));
            captainwalk.Add(new Rectangle(197, 408, 29, 36));
            captainwalk.Add(new Rectangle(228, 405, 31, 39));
            captainwalk.Add(new Rectangle(283, 403, 20, 41));
            captainwalk.Add(new Rectangle(334, 404, 16, 40));

            captainstand.Add(new Rectangle(6, 407, 28, 37));

            captaindead.Add(new Rectangle(411, 269, 39, 13));

            piratedead.Add(new Rectangle(414, 245, 42, 13));

            captainattack.Add(new Rectangle(8, 449, 19, 42));
            captainattack.Add(new Rectangle(58, 450, 15, 40));
            captainattack.Add(new Rectangle(95, 444, 27, 46));
            captainattack.Add(new Rectangle(137, 444, 31, 46));
            captainattack.Add(new Rectangle(180, 444, 36, 47));
            captainattack.Add(new Rectangle(226, 459, 46, 42));
            captainattack.Add(new Rectangle(275, 456, 43, 34));
            captainattack.Add(new Rectangle(283, 403, 20, 41));
            captainattack.Add(new Rectangle(334, 404, 16, 40));

            pirateattack.Add(new Rectangle(2, 348, 20, 42));
            pirateattack.Add(new Rectangle(47, 349, 13, 41));
            pirateattack.Add(new Rectangle(91, 344, 29, 46));
            pirateattack.Add(new Rectangle(137, 344, 32, 46));
            pirateattack.Add(new Rectangle(181, 345, 35, 45));
            pirateattack.Add(new Rectangle(216, 362, 46, 28));
            pirateattack.Add(new Rectangle(262, 356, 42, 34));
            pirateattack.Add(new Rectangle(308, 353, 46, 37));

            piranhas.Add(new Rectangle(341, 195, 142, 132));
            piranhas.Add(new Rectangle(498, 195, 149, 132));
            piranhas.Add(new Rectangle(664, 190, 137, 138));
            piranhas.Add(new Rectangle(827, 179, 129, 148));
            piranhas.Add(new Rectangle(984, 171, 137, 157));
            piranhas.Add(new Rectangle(1147, 177, 131, 151));

            boatmove = new List<Rectangle>();
            boatmove.Add(new Rectangle(0, 209, 95, 50));
            boatmove.Add(new Rectangle(96, 208, 95, 49));
            boatmove.Add(new Rectangle(193, 209, 94, 48));
            boatmove.Add(new Rectangle(288, 209, 95, 47));

            brokenbarrelmove.Add(new Rectangle(1, 2, 30, 26));
            brokenbarrelmove.Add(new Rectangle(34, 3, 30, 29));
            brokenbarrelmove.Add(new Rectangle(65, 4, 29, 27));
            brokenbarrelmove.Add(new Rectangle(1, 34, 30, 26));
            brokenbarrelmove.Add(new Rectangle(33, 35, 31, 29));
            brokenbarrelmove.Add(new Rectangle(65, 36, 29, 27));
            brokenbarrelmove.Add(new Rectangle(2, 66, 29, 26));
            brokenbarrelmove.Add(new Rectangle(34, 67, 30, 29));
            brokenbarrelmove.Add(new Rectangle(65, 68, 29, 27));
            brokenbarrelmove.Add(new Rectangle(1, 98, 30, 26));
            brokenbarrelmove.Add(new Rectangle(34, 99, 30, 29));
            brokenbarrelmove.Add(new Rectangle(65, 100, 29, 27));

            barrelmove.Add(new Rectangle(97, 2, 30, 26));
            barrelmove.Add(new Rectangle(129, 3, 31, 29));
            barrelmove.Add(new Rectangle(161, 4, 30, 27));
            barrelmove.Add(new Rectangle(97, 34, 30, 26));
            barrelmove.Add(new Rectangle(129, 35, 30, 29));
            barrelmove.Add(new Rectangle(161, 36, 30, 27));
            barrelmove.Add(new Rectangle(97, 66, 30, 26));
            barrelmove.Add(new Rectangle(129, 67, 31, 29));
            barrelmove.Add(new Rectangle(161, 68, 30, 27));
            barrelmove.Add(new Rectangle(97, 98, 30, 26));
            barrelmove.Add(new Rectangle(129, 99, 31, 29));
            barrelmove.Add(new Rectangle(161, 100, 30, 27));

            logmove.Add(new Rectangle(193, 6, 30, 24));
            logmove.Add(new Rectangle(226, 7, 30, 27));
            logmove.Add(new Rectangle(257, 8, 29, 25));

            boxmove.Add(new Rectangle(1, 128, 30, 28));
            boxmove.Add(new Rectangle(34, 129, 30, 31));
            boxmove.Add(new Rectangle(65, 130, 29, 29));

            turtleswim.Add(new Rectangle(5, 18, 33, 20));
            turtleswim.Add(new Rectangle(49, 20, 38, 18));
            turtleswim.Add(new Rectangle(98, 18, 38, 20));
            turtleswim.Add(new Rectangle(147, 21, 42, 17));
            turtleswim.Add(new Rectangle(199, 19, 37, 19));
            turtleswim.Add(new Rectangle(246, 19, 34, 19));

            turtlestand.Add(new Rectangle(5, 49, 35, 19));
            turtlestand.Add(new Rectangle(51, 49, 35, 19));
            turtlestand.Add(new Rectangle(97, 49, 35, 19));
            turtlestand.Add(new Rectangle(143, 48, 35, 20));
            turtlestand.Add(new Rectangle(148, 49, 35, 19));
            turtlestand.Add(new Rectangle(235, 49, 35, 19));

            turtlehappy.Add(new Rectangle(5, 79, 35, 23));
            turtlehappy.Add(new Rectangle(51, 82, 35, 20));

            clammove.Add(new Rectangle(13, 21, 42, 28));
            clammove.Add(new Rectangle(57, 20, 40, 29));
            clammove.Add(new Rectangle(13, 21, 42, 28));
            clammove.Add(new Rectangle(57, 20, 40, 29));
            clammove.Add(new Rectangle(99, 1, 44, 48));
            clammove.Add(new Rectangle(145, 7, 44, 42));
            clammove.Add(new Rectangle(191, 7, 44, 42));
            clammove.Add(new Rectangle(237, 7, 44, 42));
            clammove.Add(new Rectangle(283, 7, 44, 42));
            clammove.Add(new Rectangle(329, 7, 44, 42));
            clammove.Add(new Rectangle(283, 7, 44, 42));

            redcoatwalk.Add(new Rectangle(175, 45, 31, 45));
            redcoatwalk.Add(new Rectangle(206, 46, 33, 48));
            redcoatwalk.Add(new Rectangle(240, 48, 40, 45));
            redcoatwalk.Add(new Rectangle(175, 45, 31, 45));

            redcoatattack.Add(new Rectangle(175, 1, 48, 44));
            redcoatattack.Add(new Rectangle(223, 1, 70, 45));

            redcoatdie.Add(new Rectangle(281, 54, 20, 39));

            redcoatdead.Add(new Rectangle(323, 71, 54, 12));

            redcoatstand.Add(new Rectangle(339, 1, 26, 48));

            bluecoatwalk.Add(new Rectangle(365, 3, 21, 66));

            bluecoatdie.Add(new Rectangle(301, 54, 20, 39));

            bluecoatdead.Add(new Rectangle(323, 83, 54, 12));

            bluecoatattack.Add(new Rectangle(293, 3, 44, 48));
            bluecoatattack.Add(new Rectangle(386, 1, 43, 41));

            shipdown.Add(new Rectangle(66, 3, 96, 186));
            shipdown.Add(new Rectangle(274, 4, 96, 186));
            shipdown.Add(new Rectangle(483, 3, 96, 186));
            shipdown.Add(new Rectangle(691, 4, 96, 186));

            shipleft.Add(new Rectangle(30, 231, 175, 143));
            shipleft.Add(new Rectangle(238, 231, 175, 143));
            shipleft.Add(new Rectangle(446, 231, 175, 143));
            shipleft.Add(new Rectangle(654, 231, 175, 143));

            shipright.Add(new Rectangle(3, 423, 175, 143));
            shipright.Add(new Rectangle(211, 423, 175, 143));
            shipright.Add(new Rectangle(419, 423, 175, 143));
            shipright.Add(new Rectangle(627, 423, 175, 143));

            shipup.Add(new Rectangle(61, 585, 90, 182));
            shipup.Add(new Rectangle(271, 585, 90, 182));
            shipup.Add(new Rectangle(478, 585, 90, 182));
            shipup.Add(new Rectangle(688, 585, 90, 182));

            FrigateFrames.Add(new Rectangle(0, 0, 60, 151));

            vessel.LoadFrameList(FrigateFrames, AnimatingSprite.State.Standing);
            vessel.CurrentState = AnimatingSprite.State.Standing;

            shootup.Add(new Rectangle(0, 0, 1000, 726));

            fort.LoadFrameList(shootup, AnimatingSprite.State.left);
            fort.CurrentState = AnimatingSprite.State.left;

            escapeship = new AnimatingSprite(Content.Load<Texture2D>("big ship"), new Vector2(-1725, 425), Color.White, 105, new Rectangle(500, 500, 0, 0), 2500, 1, Content.Load<SpriteFont>("SpriteFont1"));
            escapeship.LoadFrameList(escaper, AnimatingSprite.State.Standing);
            escapeship.CurrentState = AnimatingSprite.State.Standing;
            //do the fish super power
            fort.origin = new Vector2(vessel.activeFrame.Width / 2, vessel.activeFrame.Height / 2);
            forts.Add(fort);

            //practiceFrames = new List<Rectangle>();
            //practiceFrames.Add(new Rectangle(68, 50, 206, 281));
            //practiceFrames.Add(new Rectangle(298, 78, 227, 279));
            //practiceFrames.Add(new Rectangle(571, 98, 232, 267));
            //practiceFrames.Add(new Rectangle(896, 80, 193, 293));
            //practiceFrames.Add(new Rectangle(1150, 95, 202, 287));
            //practiceFrames.Add(new Rectangle(48, 421, 203, 275));
            //practiceFrames.Add(new Rectangle(297, 423, 233, 280));
            //practiceFrames.Add(new Rectangle(566, 437, 240, 261));
            //practiceFrames.Add(new Rectangle(1147, 423, 206, 283));
            //uglyguy = new AnimatingSprite(Content.Load<Texture2D>("uglykid"), new Vector2(0, 200), Color.White, practiceFrames, 100);
            jackx = 750;
            jacky = 460;
            jack = new AnimatingSprite(Content.Load<Texture2D>("jack"), new Vector2(750, -1000), Color.White, 50, new Rectangle(jackx, jacky, Content.Load<Texture2D>("jack").Width, Content.Load<Texture2D>("jack").Height), 150, 20, Content.Load<SpriteFont>("SpriteFont1"));

            jack.LoadFrameList(sparrowframes, AnimatingSprite.State.Standing);
            jack.LoadFrameList(sparrowcrouch, AnimatingSprite.State.Crouching);
            jack.LoadFrameList(sparrowrun, AnimatingSprite.State.Running);
            jack.LoadFrameList(sparrowattack, AnimatingSprite.State.Attacking);
            jack.LoadFrameList(sparrowca, AnimatingSprite.State.Crouchattacking);
            jack.LoadFrameList(sparrowja, AnimatingSprite.State.Jumping);

            enemypirates.Add(new AnimatingSprite(Content.Load<Texture2D>("pirates"), new Vector2(800, 0), Color.White, 50, new Rectangle(0, 0, 0, 0), 25, 5, Content.Load<SpriteFont>("SpriteFont1")));
            for (int i = 0; i < enemypirates.Count; i++)
            {
                enemypirates[i].LoadFrameList(piratewalk, AnimatingSprite.State.Running);
                enemypirates[i].LoadFrameList(pirateattack, AnimatingSprite.State.Attacking);
                enemypirates[i].LoadFrameList(piratestand, AnimatingSprite.State.Standing);
                enemypirates[i].LoadFrameList(sparrowcrouch, AnimatingSprite.State.Crouching);
                enemypirates[i].LoadFrameList(sparrowca, AnimatingSprite.State.Crouchattacking);
                enemypirates[i].LoadFrameList(sparrowja, AnimatingSprite.State.Jumping);
                enemypirates[i].CurrentState = AnimatingSprite.State.Running;
            }
            cannonimage.Add(new Rectangle(0, 0, 503, 223));
            cannon.LoadFrameList(cannonimage, AnimatingSprite.State.Standing);
            cannon.CurrentState = AnimatingSprite.State.Standing;
            pirahna = new AnimatingSprite(Content.Load<Texture2D>("p"), new Vector2(1250, 650), Color.White, 75, new Rectangle(1250, 600, 195, 192), 100, 100, Content.Load<SpriteFont>("SpriteFont1"));
            pirahna.LoadFrameList(piranhas, AnimatingSprite.State.Attacking);
            pirahna.LoadFrameList(piratestand, AnimatingSprite.State.Standing);
            pirahna.LoadFrameList(sparrowcrouch, AnimatingSprite.State.Crouching);
            pirahna.LoadFrameList(sparrowca, AnimatingSprite.State.Crouchattacking);
            pirahna.LoadFrameList(sparrowja, AnimatingSprite.State.Jumping);
            pirahna.CurrentState = AnimatingSprite.State.Running;
            pirahna.LoadFrameList(piratewalk, AnimatingSprite.State.Running);
            pirahna.CurrentState = AnimatingSprite.State.Attacking;
            crewcall = new Sprite(Content.Load<Texture2D>("callthecrew"), new Vector2(jack.Location.X - GraphicsDevice.Viewport.Width / 2, jack.Location.Y - GraphicsDevice.Viewport.Height / 2), Color.White);
            boat.LoadFrameList(boatmove, AnimatingSprite.State.Running);
            boat.LoadFrameList(piranhas, AnimatingSprite.State.Attacking);
            boat.LoadFrameList(piratestand, AnimatingSprite.State.Standing);
            boat.LoadFrameList(sparrowcrouch, AnimatingSprite.State.Crouching);
            boat.LoadFrameList(sparrowca, AnimatingSprite.State.Crouchattacking);
            boat.LoadFrameList(sparrowja, AnimatingSprite.State.Jumping);
            boat.CurrentState = AnimatingSprite.State.Running;
            turtle2.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
            boat.LayerDepth = .979f;
            turtle5.LayerDepth = .98f;
            turtle6.LayerDepth = .98f;
            jack.LayerDepth = .99999f;
            sea.depth = .01f;
            shackland.depth = .999f;
            losescreen.depth = .9999999999f;
            dock.depth = 0f;
            dock2.effect = SpriteEffects.FlipHorizontally;
            dock2.depth = 0f;
            watchtower.depth = .1f;
            germanhouse.depth = .1f;
            germanhouse2.depth = .1f;
            germanhouse3.depth = .1f;
            brownstone.depth = .1f;
            brownstone4.depth = .1f;
            brownstone2.depth = .1f;
            brownstone3.depth = .1f;
            shack.depth = .1f;
            brownstone3.depth = .1f;
            fishbox.depth = .1f;
            road.depth = .0f;
            road2.depth = .0f;
            ph.depth = .1f;
            ph2.depth = .1f;
            ph3.depth = .1f;
            ph4.depth = .1f;
            ph5.depth = .1f;
            ph6.depth = .1f;
            tavern.depth = .1f;
            fishstand.depth = .999999f;
            IslandOfHotDogs.LayerDepth = 0f;
            portroyal.LayerDepth = 0f;
            fort.LayerDepth = 0f;
            cannon.LayerDepth = .9f;
            vessel.LayerDepth = 0.8f;
            port = new SerialPort("COM6", 115200);
            port.Open();
            port.DataReceived += Port_DataReceived;
            samthecam = new camera(jack);
            InTheNavy = new camera(vessel);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isarduinoworking)
            {
                try
                {
                    // 1,1,1}{255,255,1,1,1,1}
                    while (port.BytesToRead > 0)
                    {
                        char c = (char)port.ReadChar();
                        if (waitforopen)
                        {
                            data = "";
                            if (c == '{')
                            {
                                waitforopen = false;
                            }
                        }
                        else
                        {
                            if (c == '}')
                            {
                                string[] split = data.Split(',');
                                if (split.Length == 6)
                                {
                                    xAxis = 0;
                                    bool isxvalid = int.TryParse(split[0], out xAxis);
                                    yAxis = 0;
                                    bool isyvalid = int.TryParse(split[1], out yAxis);
                                    int B1int = 0;
                                    bool isb1valid = int.TryParse(split[2], out B1int);
                                    int B2int = 0;
                                    bool isb2valid = int.TryParse(split[3], out B2int);
                                    int B3int = 0;
                                    bool isb3valid = int.TryParse(split[4], out B3int);
                                    int B4int = 0;
                                    bool isb4valid = int.TryParse(split[5], out B4int);

                                    B1 = B1int != 0;
                                    B2 = B2int != 0;
                                    B3 = B3int != 0;
                                    B4 = B4int != 0;
                                }
                                waitforopen = true;
                            }
                            data += c;
                        }
                    }
                }
                catch
                {
                    //TODO: Teach Edden locks once he's a bit more advanced... :)
                }
            }
        }
        protected override void UnloadContent()
        {
            if (isarduinoworking)
            {
                port.Close();
            }
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            waitnewsong += gameTime.ElapsedGameTime;
            if (waitnewsong >= untilnewsong)
            {
                MediaPlayer.Play(music);
                waitnewsong = TimeSpan.Zero;
            }
            ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            Vector2 mousePoint = new Vector2(ms.X, ms.Y);
            cursor.Location = mousePoint;
            #region menu
            if (menu)
            {
                if (prologue.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y))
                {
                    prologue.shade(Color.Green);
                }
                else
                {
                    prologue.shade(Color.White);
                }
                if (prologue.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y) && ms.LeftButton == ButtonState.Pressed)
                {
                    menu = false;
                    currentLevel = levelstate.Proluage;
                    jack.Location = new Vector2(750, -1000);
                    boat.Location = new Vector2(1200, 600);
                    enemypirates.Clear();
                    enemycaptians.Clear();
                    jack.defence = 150;
                }
                if (level1.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y))
                {
                    level1.shade(Color.GreenYellow);
                }
                else
                {
                    level1.shade(Color.White);
                }
                if (level1.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y) && ms.LeftButton == ButtonState.Pressed)
                {
                    menu = false;
                    currentLevel = levelstate.Level1;
                    jack.Location = new Vector2(750, -1000);
                    boat.Location = new Vector2(1200, 600);
                    enemypirates.Clear();
                    enemycaptians.Clear();
                    jack.defence = 150;
                }
                if (level2.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y))
                {
                    level2.shade(Color.Orange);
                }
                else
                {
                    level2.shade(Color.White);
                }
                if (level2.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y) && ms.LeftButton == ButtonState.Pressed)
                {
                    menu = false;
                    currentLevel = levelstate.Level2;
                    jack.Location = new Vector2(875, -300);
                    coats.Clear();
                    blues.Clear();
                    redcount = 49;
                    bluecount = 199;
                    enemypirates.Clear();
                    callthecrew = true;
                    escapeship.Location = new Vector2(-1750, escapeship.Location.Y);
                    jack.defence = 150;
                    boat.Location = new Vector2(430, boat.Location.Y);
                    boat.ImageEffect = AnimatingSprite.ImageState.Normal;
                    turtle5.Location = new Vector2(1200, 600);
                    turtle6.Location = new Vector2(1300, 600);
                }
                if (level3.hitbox.Contains((int)mousePoint.X, (int)mousePoint.Y))
                {
                    level3.shade(Color.OrangeRed);
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        menu = false;
                        currentLevel = levelstate.Level3;
                    }
                }
                else
                {
                    level3.shade(Color.White);
                }
            }
            #endregion
            #region prolague
            if (!menu && currentLevel == levelstate.Proluage)
            {
                if (jack.Location.X >= GraphicsDevice.Viewport.Width + 100 && jack.isdead == false)
                {
                    menu = true;
                    currentLevel = levelstate.none;
                    unlocker = 1;
                }
                else if (jack.Location.Y >= 10000)
                {
                    jack.Location = new Vector2(750, -1000);
                    boat.Location = new Vector2(1200, 600);
                    enemypirates.Clear();
                    enemycaptians.Clear();
                    jack.isdead = false;
                    jack.defence = 150;
                }
                boat.Animate(gameTime);
                boat.Hitbox = new Rectangle((int)boat.Location.X, (int)boat.Location.Y, boat.activeFrame.Width, boat.activeFrame.Height);
                pirahna.Location = new Vector2(jack.Location.X - 50, pirahna.Location.Y);
                pirahna.Hitbox = new Rectangle((int)pirahna.Location.X - 15, (int)pirahna.Location.Y + 100, 195, 192);
                jackx = (int)jack.Location.X;
                jacky = (int)jack.Location.Y;
                if (jacky >= GraphicsDevice.Viewport.Height + 45)
                {
                    jack.isdead = true;
                }
                jack.Hitbox = new Rectangle(jackx, jacky, jack.activeFrame.Width, jack.activeFrame.Height);
                if (jack.Hitbox.Intersects(boat.Hitbox))
                {
                    gravity = -0.175f;
                    boat.Location = new Vector2(jack.Location.X - 25, boat.Location.Y);
                    if (jack.ImageEffect == AnimatingSprite.ImageState.FlippedHorizontally)
                    {
                        boat.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (jack.ImageEffect == AnimatingSprite.ImageState.Normal)
                    {
                        boat.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                }
                if (jack.Hitbox.Intersects(ship.Solid) || jack.Hitbox.Intersects(cabin.Solid) || jack.Hitbox.Intersects(cabin2.Solid) || jack.Hitbox.Intersects(mast.Solid) || jack.Hitbox.Intersects(mast2.Solid) || jack.Hitbox.Intersects(mast3.Solid) || jack.Hitbox.Intersects(crow.Solid))
                {
                    gravity = 0f;
                }
                else
                {
                    gravity += .175f;
                }
                jack.Location = new Vector2(jack.Location.X, jack.Location.Y + gravity);
                if (isarduinoworking)
                {
                    if (B1)
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (xAxis >= 121 && xAxis <= 135 && yAxis >= 121 && yAxis <= 135)
                    {
                        jack.CurrentState = AnimatingSprite.State.Standing;
                    }
                    if (xAxis <= 120 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        mousePoint = new Vector2(mousePoint.X - 5, mousePoint.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (xAxis >= 136 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        mousePoint = new Vector2(mousePoint.X + 5, mousePoint.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (xAxis <= 120)
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            mousePoint = new Vector2(mousePoint.X - 5, mousePoint.Y - 8.3f);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (xAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            mousePoint = new Vector2(mousePoint.X + 5, mousePoint.Y - 8.3f);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (yAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            mousePoint = new Vector2(mousePoint.X, mousePoint.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        if (yAxis <= 100)
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                    if (jack.Hitbox.Intersects(pirahna.Hitbox))
                    {
                        jack.isdead = true;
                    }
                    if (jack.defence <= 0)
                    {
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                        jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 3);
                        mousePoint = new Vector2(mousePoint.X, mousePoint.Y + 3f);
                    }
                }
                else
                {
                    if (ks.IsKeyDown(Keys.Space))
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        mousePoint = new Vector2(mousePoint.X - 5, mousePoint.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        mousePoint = new Vector2(mousePoint.X + 5, mousePoint.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (ks.IsKeyDown(Keys.Left))
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            mousePoint = new Vector2(mousePoint.X - 5, mousePoint.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (ks.IsKeyDown(Keys.Right))
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            mousePoint = new Vector2(mousePoint.X + 5, mousePoint.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (ks.IsKeyDown(Keys.Up))
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            mousePoint = new Vector2(mousePoint.X, mousePoint.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        if (ks.IsKeyDown(Keys.Down))
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                        else
                        {
                            jack.CurrentState = AnimatingSprite.State.Standing;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                    if (jack.Hitbox.Intersects(pirahna.Hitbox))
                    {
                        jack.isdead = true;
                    }
                    if (jack.defence <= 0)
                    {
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                        jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 3);
                    }
                }
                jack.Animate(gameTime);
                waitenemypirate += gameTime.ElapsedGameTime;
                waitenemycaptain += gameTime.ElapsedGameTime;
                pirahna.Animate(gameTime);
                if (!jack.isdead && jack.Location.X <= GraphicsDevice.Viewport.Width + 10)
                {
                    if (waitenemycaptain > untilenemycaptain)
                    {
                        AnimatingSprite newcaptain = new AnimatingSprite(Content.Load<Texture2D>("pirates"), new Vector2(515, 460), Color.White, 150, new Rectangle(0, 0, 0, 0), 50, 7, Content.Load<SpriteFont>("SpriteFont1"));
                        newcaptain.LoadFrameList(captainwalk, AnimatingSprite.State.Running);
                        newcaptain.LoadFrameList(captainattack, AnimatingSprite.State.Attacking);
                        newcaptain.LoadFrameList(captainstand, AnimatingSprite.State.Standing);
                        newcaptain.ImageEffect = AnimatingSprite.ImageState.Normal;
                        enemycaptians.Add(newcaptain);
                        jack.defence += 2;
                        waitenemycaptain = TimeSpan.Zero;
                    }
                    if (waitenemypirate > untilenemypirate)
                    {
                        AnimatingSprite newPirate = new AnimatingSprite(Content.Load<Texture2D>("pirates"), new Vector2(515, 460), Color.White, 100, new Rectangle(0, 0, 0, 0), 25, 5, Content.Load<SpriteFont>("SpriteFont1"));
                        newPirate.LoadFrameList(piratewalk, AnimatingSprite.State.Running);
                        newPirate.LoadFrameList(pirateattack, AnimatingSprite.State.Attacking);
                        newPirate.LoadFrameList(piratestand, AnimatingSprite.State.Standing);
                        newPirate.ImageEffect = AnimatingSprite.ImageState.Normal;
                        enemypirates.Add(newPirate);
                        jack.defence += 1;
                        waitenemypirate = TimeSpan.Zero;
                    }
                }

                bool attacked = false;
                for (int i = 0; i < enemypirates.Count; i++)
                {
                    enemypirates[i].Hitbox = new Rectangle((int)enemypirates[i].Location.X, (int)enemypirates[i].Location.Y, enemypirates[i].activeFrame.Width, enemypirates[i].activeFrame.Height);
                    enemypirates[i].Animate(gameTime);
                    //Falling
                    if (!enemypirates[i].Hitbox.Intersects(ship.Solid) || enemypirates[i].Hitbox.Intersects(cabin.Solid) || enemypirates[i].Hitbox.Intersects(cabin2.Solid) || enemypirates[i].Hitbox.Intersects(mast.Solid) || enemypirates[i].Hitbox.Intersects(mast2.Solid) || enemypirates[i].Hitbox.Intersects(mast3.Solid) || enemypirates[i].Hitbox.Intersects(crow.Solid))
                    {
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X, enemypirates[i].Location.Y + 5);
                        enemypirates[i].CurrentState = AnimatingSprite.State.Standing;
                        enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                    }
                    if (!jack.isdead && jack.Location.X <= GraphicsDevice.Viewport.Width + 10)
                    {
                        if (enemypirates[i].Location.X >= 1100)
                        {
                            enemypirates[i].goback = true;
                        }
                        else if (enemypirates[i].Location.X <= 515)
                        {
                            enemypirates[i].goback = false;
                        }
                    }
                    if (enemypirates[i].goback)
                    {
                        enemypirates[i].ImageEffect = AnimatingSprite.ImageState.Normal;
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X - 3, enemypirates[i].Location.Y);
                    }
                    else if (!enemypirates[i].goback)
                    {
                        enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X + 3, enemypirates[i].Location.Y);
                    }
                    if (jack.isdead)
                    {
                        enemypirates[i].defence = -1;
                    }
                    if (enemypirates[i].Hitbox.Intersects(pirahna.Hitbox))
                    {
                        enemypirates[i].isdead = true;
                    }
                    if (enemypirates[i].defence <= 0)
                    {
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X - 1, enemypirates[i].Location.Y + 3);
                        enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                        enemypirates[i].CurrentState = AnimatingSprite.State.Standing;
                    }
                    if (jack.CurrentState == AnimatingSprite.State.Attacking && jack.Hitbox.Intersects(enemypirates[i].Hitbox) || jack.CurrentState == AnimatingSprite.State.Crouchattacking && jack.Hitbox.Intersects(enemypirates[i].Hitbox))
                    {
                        if (jack.readytoattack)
                        {
                            jack.defence += 3;
                            enemypirates[i].defence -= jack.attack;
                            attacked = true;
                        }
                    }
                    if (jack.Hitbox.Intersects(enemypirates[i].Hitbox))
                    {
                        enemypirates[i].CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (!jack.Hitbox.Intersects(enemypirates[i].Hitbox) && enemypirates[i].defence >= 1)
                    {
                        enemypirates[i].CurrentState = AnimatingSprite.State.Running;
                    }
                    if (enemypirates[i].CurrentState == AnimatingSprite.State.Attacking && jack.Hitbox.Intersects(enemypirates[i].Hitbox))
                    {
                        enemypirates[i].Location = new Vector2(jack.Location.X, enemypirates[i].Location.Y);
                        if (enemypirates[i].readytoattack)
                        {
                            jack.defence -= enemypirates[i].attack;
                        }
                    }
                    enemypirates[i].Animate(gameTime);
                }
                for (int i = 0; i < enemycaptians.Count; i++)
                {
                    enemycaptians[i].Hitbox = new Rectangle((int)enemycaptians[i].Location.X, (int)enemycaptians[i].Location.Y, enemycaptians[i].activeFrame.Width, enemycaptians[i].activeFrame.Height);
                    enemycaptians[i].Animate(gameTime);
                    if (!enemycaptians[i].Hitbox.Intersects(ship.Solid) || enemycaptians[i].Hitbox.Intersects(cabin.Solid) || enemycaptians[i].Hitbox.Intersects(cabin2.Solid) || enemycaptians[i].Hitbox.Intersects(mast.Solid) || enemycaptians[i].Hitbox.Intersects(mast2.Solid) || enemycaptians[i].Hitbox.Intersects(mast3.Solid) || enemycaptians[i].Hitbox.Intersects(crow.Solid))
                    {
                        enemycaptians[i].Location = new Vector2(enemycaptians[i].Location.X, enemycaptians[i].Location.Y + 5);
                        enemycaptians[i].CurrentState = AnimatingSprite.State.Standing;
                        enemycaptians[i].ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                    }
                    if (!jack.isdead && jack.Location.X <= GraphicsDevice.Viewport.Width + 10)
                    {
                        if (enemycaptians[i].Location.X >= 1100)
                        {
                            enemycaptians[i].goback = true;
                        }
                        else if (enemycaptians[i].Location.X <= 515)
                        {
                            enemycaptians[i].goback = false;
                        }
                    }
                    if (enemycaptians[i].goback)
                    {
                        enemycaptians[i].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                        enemycaptians[i].Location = new Vector2(enemycaptians[i].Location.X - 3, enemycaptians[i].Location.Y);
                    }
                    else if (!enemycaptians[i].goback)
                    {
                        enemycaptians[i].ImageEffect = AnimatingSprite.ImageState.Normal;
                        enemycaptians[i].Location = new Vector2(enemycaptians[i].Location.X + 3, enemycaptians[i].Location.Y);
                    }
                    if (jack.isdead)
                    {
                        enemycaptians[i].defence = -1;
                    }
                    if (jack.CurrentState == AnimatingSprite.State.Attacking && jack.Hitbox.Intersects(enemycaptians[i].Hitbox) || jack.CurrentState == AnimatingSprite.State.Crouchattacking && jack.Hitbox.Intersects(enemycaptians[i].Hitbox))
                    {
                        if (jack.readytoattack)
                        {
                            jack.defence += 3;
                            enemycaptians[i].defence -= jack.attack;
                            attacked = true;
                        }
                    }
                    if (jack.Hitbox.Intersects(enemycaptians[i].Hitbox))
                    {
                        enemycaptians[i].CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (!jack.Hitbox.Intersects(enemycaptians[i].Hitbox))
                    {
                        enemycaptians[i].CurrentState = AnimatingSprite.State.Running;
                    }
                    if (enemycaptians[i].CurrentState == AnimatingSprite.State.Attacking && jack.Hitbox.Intersects(enemycaptians[i].Hitbox))
                    {
                        enemycaptians[i].Location = new Vector2(jack.Location.X, enemycaptians[i].Location.Y);
                        if (enemycaptians[i].readytoattack)
                        {
                            jack.defence -= enemypirates[i].attack;
                        }
                    }
                    if (enemycaptians[i].Hitbox.Intersects(pirahna.Hitbox))
                    {
                        enemycaptians[i].isdead = true;
                    }
                    if (jack.CurrentState == AnimatingSprite.State.Attacking && jack.Hitbox.Intersects(enemycaptians[i].Hitbox) || jack.CurrentState == AnimatingSprite.State.Crouchattacking && jack.Hitbox.Intersects(enemycaptians[i].Hitbox))
                    {
                        if (jack.readytoattack)
                        {
                            enemycaptians[i].defence -= jack.attack;
                            attacked = true;
                            //jack.readytoattack = false;
                        }
                    }
                    if (enemycaptians[i].defence <= 0)
                    {
                        enemycaptians[i].Location = new Vector2((int)enemycaptians[i].Location.X + 1, (int)enemycaptians[i].Location.Y + 5);
                        enemycaptians[i].ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                        enemycaptians[i].CurrentState = AnimatingSprite.State.Standing;
                    }
                    enemycaptians[i].Animate(gameTime);
                }
                if (attacked)
                {
                    jack.readytoattack = false;
                }
            }
            #endregion prolaugue
            #region level1
            else if (currentLevel == levelstate.Level1)
            {
                gravity += .175f;
                jack.Location = new Vector2(jack.Location.X, jack.Location.Y + gravity);
                if (isarduinoworking)
                {
                    if (B1)
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (xAxis >= 121 && xAxis <= 135 && yAxis >= 121 && yAxis <= 135)
                    {
                        jack.CurrentState = AnimatingSprite.State.Standing;
                    }
                    if (xAxis <= 120 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (xAxis >= 136 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (xAxis <= 120)
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (xAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (yAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        if (yAxis <= 100)
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                }
                else
                {
                    if (ks.IsKeyDown(Keys.Space))
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (ks.IsKeyDown(Keys.Left))
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        else if (ks.IsKeyDown(Keys.Right))
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        else if (ks.IsKeyDown(Keys.Up))
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        else if (ks.IsKeyDown(Keys.Down))
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                        else
                        {
                            jack.CurrentState = AnimatingSprite.State.Standing;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                }
                if (jack.defence <= 0)
                {
                    jack.ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                    jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 3);
                }
                if (jack.Location.Y >= 775 || jack.Hitbox.Intersects(pebble.Solid) || jack.Hitbox.Intersects(stone.Solid) || jack.Hitbox.Intersects(rock.Solid) || jack.Hitbox.Intersects(boulder.Solid) || jack.Hitbox.Intersects(palmtree.Solid) || jack.Hitbox.Intersects(brokenbarrel.Hitbox) || jack.Hitbox.Intersects(barrel.Hitbox) || jack.Hitbox.Intersects(log.Hitbox) || jack.Hitbox.Intersects(box.Hitbox) || jack.Hitbox.Intersects(island.Solid) || jack.Hitbox.Intersects(island2.Solid) || jack.Hitbox.Intersects(turtle.Hitbox) || jack.Hitbox.Intersects(boat.Hitbox))
                {
                    gravity = -0.175f;
                }
                jack.Animate(gameTime);
                jackx = (int)jack.Location.X;
                jacky = (int)jack.Location.Y;
                if (jacky >= GraphicsDevice.Viewport.Height + 45)
                {
                    jack.isdead = true;
                }
                jack.Hitbox = new Rectangle(jackx, jacky, jack.activeFrame.Width, jack.activeFrame.Height);
                brokenbarrel.Hitbox = new Rectangle((int)brokenbarrel.Location.X, (int)brokenbarrel.Location.Y, brokenbarrel.activeFrame.Width, brokenbarrel.activeFrame.Height);
                barrel.Hitbox = new Rectangle((int)barrel.Location.X, (int)barrel.Location.Y, barrel.activeFrame.Width, barrel.activeFrame.Height);
                log.Hitbox = new Rectangle((int)log.Location.X, (int)log.Location.Y, log.activeFrame.Width, log.activeFrame.Height);
                box.Hitbox = new Rectangle((int)box.Location.X, (int)box.Location.Y, box.activeFrame.Width, box.activeFrame.Height);
                turtle.Hitbox = new Rectangle((int)turtle.Location.X, (int)turtle.Location.Y, turtle.activeFrame.Width, turtle.activeFrame.Height);
                boat.Hitbox = new Rectangle((int)boat.Location.X, (int)boat.Location.Y, boat.activeFrame.Width, boat.activeFrame.Height);
                clam.Hitbox = new Rectangle((int)clam.Location.X, (int)clam.Location.Y, clam.activeFrame.Width, clam.activeFrame.Height);
                brokenbarrel.Animate(gameTime);
                barrel.Animate(gameTime);
                log.Animate(gameTime);
                box.Animate(gameTime);
                turtle.Animate(gameTime);
                turtle2.Animate(gameTime);
                turtle3.Animate(gameTime);
                turtle4.Animate(gameTime);
                turtle5.Animate(gameTime);
                turtle6.Animate(gameTime);
                turtle7.Animate(gameTime);
                turtle8.Animate(gameTime);
                boat.Animate(gameTime);
                clam.Animate(gameTime);
                clam2.Animate(gameTime);

                clam2.Location = new Vector2(jack.Location.X - 25, clam2.Location.Y);
                clam.Location = new Vector2(jack.Location.X + 25, clam.Location.Y);
                if (jack.ImageEffect == AnimatingSprite.ImageState.FlippedHorizontally)
                {
                    clam.ImageEffect = AnimatingSprite.ImageState.Normal;
                    clam2.ImageEffect = AnimatingSprite.ImageState.Normal;
                }
                else if (jack.ImageEffect == AnimatingSprite.ImageState.Normal)
                {
                    clam.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    clam2.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                }
                if (turtle.Location.X >= GraphicsDevice.Viewport.Width)
                {
                    turtle.goback = true;
                }
                else if (turtle.Location.X <= 0)
                {
                    turtle.goback = false;
                }
                if (turtle.goback)
                {
                    turtle.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    turtle.Location = new Vector2(turtle.Location.X - 3, turtle.Location.Y - .1f);
                }
                else if (!turtle.goback)
                {
                    turtle.ImageEffect = AnimatingSprite.ImageState.Normal;
                    turtle.Location = new Vector2(turtle.Location.X + 3, turtle.Location.Y - .1f);
                }
                if (turtle.Location.Y <= 550)
                {
                    turtledecend = true;
                }
                else if (turtle.Location.Y >= 800)
                {
                    turtledecend = false;
                }
                if (turtledecend)
                {
                    turtle.Location = new Vector2(turtle.Location.X, turtle.Location.Y + .2f);
                }
                else
                {
                    turtle.Location = new Vector2(turtle.Location.X, turtle.Location.Y);
                }
                if (jack.Hitbox.Intersects(turtle.Hitbox) && jack.CurrentState != AnimatingSprite.State.Attacking)
                {
                    if (jack.CurrentState != AnimatingSprite.State.Crouchattacking)
                    {
                        jack.Location = new Vector2(turtle.Location.X, turtle.Location.Y - 45);
                        if (turtle.goback)
                        {
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                        }
                        else if (!turtle.goback)
                        {
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                        }
                    }
                }
                if (turtle5.Location.X >= GraphicsDevice.Viewport.Width)
                {
                    turtle5.goback = true;
                }
                else if (turtle5.Location.X <= 0)
                {
                    turtle5.goback = false;
                }
                if (turtle5.goback)
                {
                    turtle5.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    turtle5.Location = new Vector2(turtle5.Location.X - 2.5f, turtle5.Location.Y - .1f);
                }
                else if (!turtle5.goback)
                {
                    turtle5.ImageEffect = AnimatingSprite.ImageState.Normal;
                    turtle5.Location = new Vector2(turtle5.Location.X + 2.5f, turtle5.Location.Y + .1f);
                }
                if (turtle6.Location.X >= GraphicsDevice.Viewport.Width)
                {
                    turtle6.goback = true;
                }
                else if (turtle6.Location.X <= 0)
                {
                    turtle6.goback = false;
                }
                if (turtle6.goback)
                {
                    turtle6.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    turtle6.Location = new Vector2(turtle6.Location.X - 2.5f, turtle6.Location.Y - .1f);
                }
                else if (!turtle6.goback)
                {
                    turtle6.ImageEffect = AnimatingSprite.ImageState.Normal;
                    turtle6.Location = new Vector2(turtle6.Location.X + 2.5f, turtle6.Location.Y + .1f);
                }
                if (turtle6.Location.X >= turtle7.Location.X)
                {
                    turtle7.ImageEffect = AnimatingSprite.ImageState.Normal;
                }
                else if (turtle6.Location.X <= turtle7.Location.X)
                {
                    turtle7.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                }
                if (turtle8.Location.X >= GraphicsDevice.Viewport.Width - 200)
                {
                    turtle8.goback = true;
                }
                else if (turtle8.Location.X <= 500)
                {
                    turtle8.goback = false;
                }
                if (turtle8.goback)
                {
                    turtle8.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    boat.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    turtle8.Location = new Vector2(turtle8.Location.X - 2.5f, turtle8.Location.Y - .1f);
                    if (jack.Hitbox.Intersects(boat.Hitbox))
                    {
                        jack.Location = new Vector2(jack.Location.X - 2.5f, jack.Location.Y - .1f);
                    }
                }
                else if (!turtle8.goback)
                {
                    turtle8.ImageEffect = AnimatingSprite.ImageState.Normal;
                    boat.ImageEffect = AnimatingSprite.ImageState.Normal;
                    turtle8.Location = new Vector2(turtle8.Location.X + 2.5f, turtle8.Location.Y + .1f);
                    if (jack.Hitbox.Intersects(boat.Hitbox))
                    {
                        jack.Location = new Vector2(jack.Location.X + 2.5f, jack.Location.Y + .1f);
                    }
                }
                boat.Location = new Vector2(turtle8.Location.X - 25, turtle8.Location.Y + 10);
                if (jack.Location.X >= GraphicsDevice.Viewport.Width + 100 && jack.isdead == false)
                {
                    menu = true;
                    currentLevel = levelstate.none;
                    unlocker = 2;
                }
            }
            #endregion
            #region Level2
            else if (currentLevel == levelstate.Level2)
            {
                escapeship.Animate(gameTime);
                escapeship.Hitbox = new Rectangle((int)escapeship.Location.X, (int)escapeship.Location.Y, escapeship.activeFrame.Width, escapeship.activeFrame.Height);
                //    plane.Location = new Vector2(plane.Location.X + 15, plane.Location.Y);
                waitenemycaptain += gameTime.ElapsedGameTime;
                waitenemypirate += gameTime.ElapsedGameTime;
                waitcrewcall += gameTime.ElapsedGameTime;
                waitbluecoat += gameTime.ElapsedGameTime;
                waitredcoat += gameTime.ElapsedGameTime;
                waitnewcloud += gameTime.ElapsedGameTime;
                moneymoneys.location = new Vector2(jack.Location.X - 25, jack.Location.Y - 65);
                moneymoneys.text = ($"MoneyMoneys: {money}");
                if (waitnewcloud >= Untilnewcloud)
                {
                    Sprite newcloud = new Sprite(Content.Load<Texture2D>("fog"), new Vector2(random.Next(-3500, 500), random.Next(-550, 350)), Color.WhiteSmoke);
                    newcloud.scale = .00000001f;
                    newcloud.depth = 1f;
                    clouds.Add(newcloud);
                    waitnewcloud = TimeSpan.Zero;
                    jack.defence += 10;
                    piratecount -= 5;
                }
                if (waitredcoat >= untilredcoat && redcount <= 50)
                {
                    AnimatingSprite newcoat = new AnimatingSprite(Content.Load<Texture2D>("bad guys"), new Vector2(castle.Location.X + 360, box.Location.Y), Color.White, 100, new Rectangle(0, 0, 0, 0), 100, 5, Content.Load<SpriteFont>("Spritefont1"), 4);
                    newcoat.LoadFrameList(redcoatattack, AnimatingSprite.State.Attacking);
                    newcoat.LoadFrameList(redcoatwalk, AnimatingSprite.State.Running);
                    newcoat.LoadFrameList(redcoatstand, AnimatingSprite.State.Standing);
                    newcoat.LoadFrameList(redcoatdie, AnimatingSprite.State.Crouching);
                    newcoat.LoadFrameList(redcoatdead, AnimatingSprite.State.Jumping);
                    newcoat.CurrentState = AnimatingSprite.State.Running;
                    newcoat.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    newcoat.LayerDepth = .999999f;
                    newcoat.cost = 25;
                    coats.Add(newcoat);
                    redcount++;
                    waitredcoat = TimeSpan.Zero;
                }
                if (waitbluecoat >= untilbluecoat && bluecount <= 200)
                {
                    shooter newcoat = new shooter(Content.Load<Texture2D>("bad guys"), new Vector2(castle.Location.X + 360, box.Location.Y - 30), Color.White, 1500, new Rectangle(0, 0, 0, 0), 20, 3, Content.Load<SpriteFont>("Spritefont1"), new List<ammo>(), new TimeSpan(0, 0, 0, 0, 500), Content.Load<Texture2D>("shot"), new Vector2(10, 1 / 2), new Rectangle(0, 0, -100, 1), random.Next(1, 5));
                    newcoat.LoadFrameList(bluecoatattack, AnimatingSprite.State.Attacking);
                    newcoat.LoadFrameList(bluecoatdie, AnimatingSprite.State.Crouching);
                    newcoat.LoadFrameList(bluecoatdead, AnimatingSprite.State.Jumping);
                    newcoat.LoadFrameList(bluecoatwalk, AnimatingSprite.State.Running);
                    newcoat.CurrentState = AnimatingSprite.State.Running;
                    newcoat.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    newcoat.LayerDepth = .999999f;
                    newcoat.goback = false;
                    newcoat.cost = 15;
                    blues.Add(newcoat);
                    bluecount++;
                    piratecount += 1;
                    began = true;
                    waitbluecoat = TimeSpan.Zero;
                }
                if (callthecrew)
                {
                    if (waitenemycaptain >= untilenemycaptain)
                    {
                        if (captaincount <= 0)
                        {
                            AnimatingSprite newcaptain = new AnimatingSprite(Content.Load<Texture2D>("pirates"), new Vector2(tavern.Location.X + 200, box.Location.Y - 20), Color.White, 150, new Rectangle(0, 0, 0, 0), 50, 7, Content.Load<SpriteFont>("SpriteFont1"), 3);
                            newcaptain.LoadFrameList(captainwalk, AnimatingSprite.State.Running);
                            newcaptain.LoadFrameList(captainattack, AnimatingSprite.State.Attacking);
                            newcaptain.LoadFrameList(captainstand, AnimatingSprite.State.Standing);
                            newcaptain.LoadFrameList(captaindead, AnimatingSprite.State.Jumping);
                            newcaptain.ImageEffect = AnimatingSprite.ImageState.Normal;
                            newcaptain.LayerDepth = .99999f;
                            newcaptain.flipped = true;
                            newcaptain.isattacking = false;
                            newcaptain.goback = false;
                            enemypirates.Add(newcaptain);
                            captaincount++;
                            waitenemycaptain = new TimeSpan(0, 0, 0, 0, 325);
                        }
                    }
                    if (waitenemypirate >= untilenemypirate)
                    {
                        if (piratecount <= 0)
                        {
                            AnimatingSprite newPirate = new AnimatingSprite(Content.Load<Texture2D>("pirates"), new Vector2(tavern.Location.X + 200, box.Location.Y - 20), Color.White, 150, new Rectangle(0, 0, 0, 0), 25, 5, Content.Load<SpriteFont>("SpriteFont1"), 3);
                            newPirate.LoadFrameList(piratewalk, AnimatingSprite.State.Running);
                            newPirate.LoadFrameList(pirateattack, AnimatingSprite.State.Attacking);
                            newPirate.LoadFrameList(piratestand, AnimatingSprite.State.Standing);
                            newPirate.LoadFrameList(piratedead, AnimatingSprite.State.Jumping);
                            newPirate.ImageEffect = AnimatingSprite.ImageState.Normal;
                            newPirate.LayerDepth = .99999f;
                            newPirate.isattacking = false;
                            newPirate.goback = false;
                            enemypirates.Add(newPirate);
                            piratecount++;
                            waitenemypirate = new TimeSpan(0, 0, 0, 0, 175);
                        }
                    }
                    if (piratecount >= 0)
                    {
                        crewcall.Color = Color.Gray;
                        callthecrew = false;
                    }
                }
                if (waitcrewcall >= untilcrewcall)
                {
                    crewcall.Color = Color.White;
                    piratecount -= 30;
                    captaincount -= 5;
                    waitcrewcall = TimeSpan.Zero;
                }
                if (B4)
                {
                    callthecrew = true;
                }
                for (int i = 0; i < enemypirates.Count; i++)
                {
                    enemypirates[i].Animate(gameTime);
                    enemypirates[i].Hitbox = new Rectangle((int)enemypirates[i].Location.X, (int)enemypirates[i].Location.Y, enemypirates[i].activeFrame.Width, enemypirates[i].activeFrame.Height);
                    if (enemypirates[i].Hitbox.Intersects(dockplat.Solid) || B3)
                    {
                        enemypirates[i].goback = false;
                    }
                    else if (enemypirates[i].Hitbox.Intersects(dockplat2.Solid) || B2)
                    {
                        enemypirates[i].goback = true;
                    }
                    enemypirates[i].Hitbox = new Rectangle((int)enemypirates[i].Location.X, (int)enemypirates[i].Location.Y, enemypirates[i].activeFrame.Width, enemypirates[i].activeFrame.Height);
                    enemypirates[i].Animate(gameTime);
                    if (enemypirates[i].Hitbox.Intersects(road.Solid) || enemypirates[i].Hitbox.Intersects(road2.Solid) || enemypirates[i].Hitbox.Intersects(dockplat.Solid) || enemypirates[i].Hitbox.Intersects(dockplat2.Solid))
                    {
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X, enemypirates[i].Location.Y);
                    }
                    else
                    {
                        enemypirates[i].Location = new Vector2(enemypirates[i].Location.X, enemypirates[i].Location.Y + 5);
                        enemypirates[i].CurrentState = AnimatingSprite.State.Standing;
                        //enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                    }
                    if (!enemypirates[i].isattacking && !enemypirates[i].isdead)
                    {
                        if (enemypirates[i].goback)
                        {
                            if (!enemypirates[i].flipped)
                            {
                                enemypirates[i].ImageEffect = AnimatingSprite.ImageState.Normal;
                            }
                            else
                            {
                                enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            }
                            enemypirates[i].Location = new Vector2(enemypirates[i].Location.X - 3, enemypirates[i].Location.Y);
                            enemypirates[i].CurrentState = AnimatingSprite.State.Running;
                        }
                        else if (!enemypirates[i].goback)
                        {
                            if (!enemypirates[i].flipped)
                            {
                                enemypirates[i].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            }
                            else
                            {
                                enemypirates[i].ImageEffect = AnimatingSprite.ImageState.Normal;
                            }
                            enemypirates[i].Location = new Vector2(enemypirates[i].Location.X + 3, enemypirates[i].Location.Y);
                            enemypirates[i].CurrentState = AnimatingSprite.State.Running;
                        }
                    }
                    if (enemypirates[i].defence <= 0)
                    {
                        enemypirates[i].CurrentState = AnimatingSprite.State.Jumping;
                        enemypirates[i].isdead = true;
                    }
                    if (enemypirates[i].isdead)
                    {
                        if (enemypirates[i].untilattack >= enemypirates[i].attackdellay)
                        {
                            enemypirates[i].totaldeath++;
                            enemypirates[i].untilattack = TimeSpan.Zero;
                        }
                        if (enemypirates[i].totaldeath >= 25)
                        {
                            enemypirates[i].Location = new Vector2(enemypirates[i].Location.X, enemypirates[i].Location.Y + 15);
                        }
                        if (enemypirates[i].Location.Y >= 2500 && i != 0)
                        {
                            enemypirates.RemoveAt(i);
                        }
                    }
                }
                for (int d = 0; d < coats.Count; d++)
                {
                    coats[d].Animate(gameTime);
                    if (coats[d].isdead == false)
                    {
                        coats[d].Hitbox = new Rectangle((int)coats[d].Location.X, (int)coats[d].Location.Y, coats[d].activeFrame.Width, coats[d].activeFrame.Height);
                        if (coats[d].Hitbox.Intersects(dockplat.Solid))
                        {
                            coats[d].goback = true;
                        }
                        else if (coats[d].Hitbox.Intersects(dockplat2.Solid))
                        {
                            coats[d].goback = false;
                        }
                        if (coats[d].Hitbox.Intersects(jack.Hitbox))
                        {
                            coats[d].CurrentState = AnimatingSprite.State.Attacking;
                            if (coats[d].readytoattack)
                            {
                                jack.defence -= coats[d].attack;
                                coats[d].untilattack = TimeSpan.Zero;
                            }
                            if (jack.CurrentState == AnimatingSprite.State.Attacking)
                            {
                                if (jack.readytoattack)
                                {
                                    coats[d].defence -= jack.attack;
                                    money++;
                                    jack.untilattack = TimeSpan.Zero;
                                }
                            }
                        }
                        for (int i = 0; i < enemypirates.Count; i++)
                        {
                            if (enemypirates[i].isdead == false)
                            {
                                if (coats[d].Hitbox.Intersects(enemypirates[i].Hitbox))
                                {
                                    coats[d].CurrentState = AnimatingSprite.State.Attacking;
                                    enemypirates[i].CurrentState = AnimatingSprite.State.Attacking;
                                    if (coats[d].readytoattack)
                                    {
                                        enemypirates[i].defence -= coats[d].attack;
                                        coats[d].untilattack = TimeSpan.Zero;
                                    }
                                    if (enemypirates[i].readytoattack)
                                    {
                                        coats[d].defence -= enemypirates[i].attack * 2;
                                        enemypirates[i].untilattack = TimeSpan.Zero;
                                    }
                                }
                            }
                        }
                        if (coats[d].defence <= 0)
                        {
                            if (!coats[d].isdead)
                            {
                                money += coats[d].cost;
                            }
                            coats[d].isdead = true;
                        }
                        if (!coats[d].isattacking && !coats[d].isdead)
                        {
                            if (!coats[d].goback)
                            {
                                coats[d].Location = new Vector2(coats[d].Location.X - coats[d].speed, coats[d].Location.Y);
                                coats[d].CurrentState = AnimatingSprite.State.Running;
                                coats[d].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            }
                            else if (coats[d].goback)
                            {
                                coats[d].Location = new Vector2(coats[d].Location.X + coats[d].speed, coats[d].Location.Y);
                                coats[d].CurrentState = AnimatingSprite.State.Running;
                                coats[d].ImageEffect = AnimatingSprite.ImageState.Normal;
                            }
                        }
                    }
                    else
                    {
                        if (coats[d].totaldeath >= 25)
                        {
                            coats[d].Location = new Vector2(coats[d].Location.X, coats[d].Location.Y + 15);
                        }
                        else if (coats[d].totaldeath >= 5)
                        {
                            coats[d].CurrentState = AnimatingSprite.State.Jumping;
                            coats[d].Location = new Vector2(coats[d].Location.X, box.Location.Y + 25);
                        }
                        else if (coats[d].totaldeath <= 4)
                        {
                            coats[d].CurrentState = AnimatingSprite.State.Crouching;
                        }
                        if (coats[d].Location.Y >= 2000 && d != 0)
                        {
                            coats.RemoveAt(d);
                        }
                    }
                }

                for (int i = 0; i < blues.Count; i++)
                {
                    blues[i].isattacking = false;
                }


                for (int i = 0; i < coats.Count; i++)
                {
                    coats[i].isattacking = false;
                }

                for (int i = 0; i < enemypirates.Count; i++)
                {
                    enemypirates[i].isattacking = false;
                }

                for (int d = 0; d < blues.Count; d++)
                {
                    for (int p = 0; p < coats.Count; p++)
                    {
                        for (int i = 0; i < enemypirates.Count; i++)
                        {
                            if (blues[d].range.Intersects(enemypirates[i].Hitbox) && blues[d].range.Intersects(jack.Hitbox) && jack.isdead == false && enemypirates[i].isdead == false)
                            {
                                blues[d].isattacking = true;
                            }
                            else if (blues[d].range.Intersects(enemypirates[i].Hitbox) && enemypirates[i].isdead == false && blues[d].isdead == false || blues[d].range.Intersects(jack.Hitbox) && jack.isdead == false && blues[d].isdead == false)
                            {
                                blues[d].isattacking = true;
                            }

                            if (coats[p].Hitbox.Intersects(enemypirates[i].Hitbox) && coats[p].Hitbox.Intersects(jack.Hitbox) && jack.isdead == false && coats[p].isdead == false && enemypirates[i].isdead == false)
                            {
                                blues[d].isattacking = true;
                            }
                            else if (coats[p].Hitbox.Intersects(enemypirates[i].Hitbox) && enemypirates[i].isdead == false && coats[p].isdead == false || coats[p].Hitbox.Intersects(jack.Hitbox) && jack.isdead == false && coats[p].isdead == false)
                            {
                                coats[p].isattacking = true;
                            }
                            if (enemypirates[i].Hitbox.Intersects(blues[d].Hitbox) && enemypirates[i].Hitbox.Intersects(coats[p].Hitbox) && coats[p].isdead == false && blues[d].isdead == false && enemypirates[i].isdead == false)
                            {
                                enemypirates[i].isattacking = true;
                            }
                            else if (enemypirates[i].Hitbox.Intersects(blues[d].Hitbox) && blues[d].isdead == false && enemypirates[i].isdead == false || enemypirates[i].Hitbox.Intersects(coats[p].Hitbox) && coats[p].isdead == false && enemypirates[i].isdead == false)
                            {
                                enemypirates[i].isattacking = true;
                            }
                        }
                    }
                    blues[d].update(gameTime);
                    if (blues[d].isdead == false)
                    {
                        blues[d].Hitbox = new Rectangle((int)blues[d].Location.X, (int)blues[d].Location.Y, blues[d].activeFrame.Width, blues[d].activeFrame.Height);
                        if (blues[d].Hitbox.Intersects(dockplat.Solid))
                        {
                            blues[d].goback = true;
                        }
                        else if (blues[d].Hitbox.Intersects(dockplat2.Solid))
                        {
                            blues[d].goback = false;
                        }
                        for (int i = 0; i < blues[d].shot.Count; i++)
                        {
                            if (jack.Hitbox.Intersects(blues[d].shot[i].hitbox) || blues[d].shot[i].Location.X <= -150 || blues[d].shot[i].Location.Y >= road.Location.Y - 15)
                            {
                                if (jack.Hitbox.Intersects(blues[d].shot[i].hitbox))
                                {
                                    jack.defence -= blues[d].attack;
                                }

                                blues[d].shot.RemoveAt(i);
                            }
                        }
                        if (blues[d].range.Intersects(jack.Hitbox) || jack.Hitbox.Intersects(blues[d].Hitbox) && jack.CurrentState == AnimatingSprite.State.Attacking || jack.Hitbox.Intersects(blues[d].Hitbox) && jack.CurrentState == AnimatingSprite.State.Crouchattacking)
                        {
                            if (!blues[d].isdead && !jack.isdead)
                            {
                                if (blues[d].range.Intersects(jack.Hitbox))
                                {
                                    blues[d].CurrentState = AnimatingSprite.State.Attacking;
                                    blues[d].Location = new Vector2(blues[d].Location.X, box.Location.Y - 15);
                                    if (!blues[d].goback)
                                    {
                                        blues[d].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                                    }
                                    else if (blues[d].goback)
                                    {
                                        blues[d].ImageEffect = AnimatingSprite.ImageState.Normal;
                                    }
                                    if (blues[d].readytoattack)
                                    {
                                        blues[d].untilattack = TimeSpan.Zero;
                                    }
                                    if (blues[d].totalreloads >= 3)
                                    {
                                        blues[d].shoot(new Vector2(blues[d].Location.X, blues[d].Location.Y + 20));
                                        blues[d].totalreloads = 0;
                                    }
                                }
                                if (blues[d].Hitbox.Intersects(jack.Hitbox))
                                {
                                    if (jack.CurrentState == AnimatingSprite.State.Attacking)
                                    {
                                        if (jack.readytoattack)
                                        {
                                            blues[d].defence -= jack.attack;
                                            money++;
                                            jack.untilattack = TimeSpan.Zero;
                                        }
                                    }
                                }
                            }
                        }
                        if (blues[d].defence <= 0)
                        {
                            if(!blues[d].isdead)
                            {
                                money += blues[d].cost;
                            }
                            blues[d].isdead = true;
                        }
                        for (int i = 0; i < enemypirates.Count; i++)
                        {
                            if (blues[d].range.Intersects(enemypirates[i].Hitbox) || enemypirates[i].Hitbox.Intersects(blues[d].Hitbox))
                            {
                                if (enemypirates[i].isdead == false && blues[d].isdead == false)
                                {
                                    blues[d].CurrentState = AnimatingSprite.State.Attacking;

                                    if (blues[d].range.Intersects(enemypirates[i].Hitbox))
                                    {
                                        blues[d].CurrentState = AnimatingSprite.State.Attacking;
                                        blues[d].Location = new Vector2(blues[d].Location.X, box.Location.Y - 15);
                                        if (!blues[d].goback)
                                        {
                                            blues[d].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                                        }
                                        else if (blues[d].goback)
                                        {
                                            blues[d].ImageEffect = AnimatingSprite.ImageState.Normal;
                                        }
                                        if (blues[d].readytoattack)
                                        {
                                            blues[d].untilattack = TimeSpan.Zero;
                                        }
                                        if (blues[d].totalreloads >= 3)
                                        {
                                            blues[d].shoot(new Vector2(blues[d].Location.X, blues[d].Location.Y + 20));
                                            blues[d].totalreloads = 0;
                                        }
                                    }
                                    if (blues[d].Hitbox.Intersects(enemypirates[i].Hitbox))
                                    {
                                        if (enemypirates[i].readytoattack)
                                        {
                                            blues[d].defence -= enemypirates[i].attack * 2;
                                            enemypirates[i].untilattack = TimeSpan.Zero;
                                            enemypirates[i].CurrentState = AnimatingSprite.State.Attacking;
                                        }
                                    }
                                }
                            }
                            for (int s = 0; s < blues[d].shot.Count; s++)
                            {
                                if (enemypirates[i].Hitbox.Intersects(blues[d].shot[s].hitbox) || blues[d].shot[s].hitbox.Intersects(road.Solid) || blues[d].shot[s].hitbox.Intersects(road2.Solid))
                                {
                                    enemypirates[i].defence -= blues[d].attack * 4;
                                    blues[d].shot.RemoveAt(s);
                                }
                            }
                        }
                        if (blues[d].isattacking == false)
                        {
                            if (blues[d].updown <= 9)
                            {
                                blues[d].Location = new Vector2(blues[d].Location.X, blues[d].Location.Y + 1);
                            }
                            else if (blues[d].updown >= 10)
                            {
                                blues[d].Location = new Vector2(blues[d].Location.X, blues[d].Location.Y - 1);
                            }
                            if (!blues[d].goback)
                            {
                                blues[d].Location = new Vector2(blues[d].Location.X - blues[d].speedx, blues[d].Location.Y);
                                blues[d].CurrentState = AnimatingSprite.State.Running;
                                blues[d].ImageEffect = AnimatingSprite.ImageState.Normal;
                            }
                            else if (blues[d].goback)
                            {
                                blues[d].Location = new Vector2(blues[d].Location.X + blues[d].speedx, blues[d].Location.Y);
                                blues[d].CurrentState = AnimatingSprite.State.Running;
                                blues[d].ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            }
                        }
                    }
                    else if (blues[d].isdead)
                    {
                        if (blues[d].totaldeath >= 25)
                        {
                            blues[d].Location = new Vector2(blues[d].Location.X, blues[d].Location.Y + 15);
                        }
                        else if (blues[d].totaldeath >= 5)
                        {
                            blues[d].CurrentState = AnimatingSprite.State.Jumping;
                            blues[d].Location = new Vector2(blues[d].Location.X, box.Location.Y + 25);
                        }
                        else if (blues[d].totaldeath <= 4)
                        {
                            blues[d].CurrentState = AnimatingSprite.State.Crouching;
                        }
                        if (blues[d].Location.Y >= 2500 && d != 0)
                        {
                            blues.RemoveAt(d);
                        }
                    }
                }
                for (int d = 0; d < clouds.Count; d++)
                {
                    clouds[d].scale = clouds[d].scale + .0001f * d;
                    clouds[d].Location = new Vector2(clouds[d].Location.X + random.Next(0, 5), clouds[d].Location.Y);
                }
                gravity += .175f;
                jack.Location = new Vector2(jack.Location.X, jack.Location.Y + gravity);
                if (isarduinoworking)
                {
                    if (B1)
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (xAxis >= 121 && xAxis <= 135 && yAxis >= 121 && yAxis <= 135)
                    {
                        jack.CurrentState = AnimatingSprite.State.Standing;
                    }
                    else if (xAxis <= 120 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (xAxis >= 136 && yAxis >= 136)
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (xAxis <= 120)
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (xAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        if (yAxis >= 136)
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        if (yAxis <= 80)
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                }
                else
                {
                    if (ks.IsKeyDown(Keys.Space))
                    {
                        jack.CurrentState = AnimatingSprite.State.Attacking;
                    }
                    else if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X - 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                    }
                    else if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Up))
                    {
                        jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y - 8.3f);
                        jack.CurrentState = AnimatingSprite.State.Jumping;
                        jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                    }
                    else
                    {
                        if (ks.IsKeyDown(Keys.Left))
                        {
                            jack.Location = new Vector2(jack.Location.X - 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.FlippedHorizontally;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        else if (ks.IsKeyDown(Keys.Right))
                        {
                            jack.Location = new Vector2(jack.Location.X + 5f, jack.Location.Y);
                            jack.ImageEffect = AnimatingSprite.ImageState.Normal;
                            if (!jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Running;
                            }
                            else if (jack.Hitbox.Intersects(boat.Hitbox))
                            {
                                jack.CurrentState = AnimatingSprite.State.Standing;
                            }
                        }
                        else if (ks.IsKeyDown(Keys.Up))
                        {
                            jack.Location = new Vector2(jack.Location.X, jack.Location.Y - 8.3f);
                            jack.CurrentState = AnimatingSprite.State.Jumping;
                        }
                        else if (ks.IsKeyDown(Keys.Down))
                        {
                            //jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 5);
                            jack.CurrentState = AnimatingSprite.State.Crouching;
                        }
                        else
                        {
                            jack.CurrentState = AnimatingSprite.State.Standing;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        jack.CurrentState = AnimatingSprite.State.Crouchattacking;
                    }
                }
                if (jack.defence <= 0)
                {
                    jack.ImageEffect = AnimatingSprite.ImageState.FlippedVertically;
                    jack.Location = new Vector2(jack.Location.X, jack.Location.Y + 3);
                }

                if (jack.Hitbox.Intersects(boat.Hitbox))
                {
                    gravity = -.175f;
                    boat.Location = new Vector2(boat.Location.X + 5, boat.Location.Y);
                    jack.Location = new Vector2(jack.Location.X + 5, jack.Location.Y);
                }
                else if (boat.Location.X <= 3500)
                {
                    boat.Location = new Vector2(boat.Location.X + 2, boat.Location.Y);
                }
                jack.Animate(gameTime);
                jackx = (int)jack.Location.X;
                jacky = (int)jack.Location.Y;
                if (jacky >= GraphicsDevice.Viewport.Height + 45)
                {
                    jack.isdead = true;
                    losescreen.Location = new Vector2(jackx - 150, jacky + 150);
                }
                jack.Hitbox = new Rectangle(jackx, jacky, jack.activeFrame.Width, jack.activeFrame.Height);
                boat.Hitbox = new Rectangle((int)boat.Location.X, (int)boat.Location.Y, boat.activeFrame.Width, boat.activeFrame.Height);
                boat.Animate(gameTime);
                if (jack.Location.Y >= 3000)
                {
                    jack.isdead = false;
                    jack.defence = 150;
                    jack.Location = new Vector2(850, -1000);
                    boat.Location = new Vector2(230, boat.Location.Y);
                    sea.Location = new Vector2(0, 650);
                    gravity = 0;
                    lives++;
                }
                turtle5.Location = new Vector2(turtle5.Location.X + 2, boat.Location.Y + 25);
                turtle5.ImageEffect = AnimatingSprite.ImageState.Normal;
                turtle5.Animate(gameTime);
                turtle6.Location = new Vector2(turtle6.Location.X + 2, boat.Location.Y + 25);
                turtle6.ImageEffect = AnimatingSprite.ImageState.Normal;
                turtle6.Animate(gameTime);
                if (jack.Hitbox.Intersects(hackland.Solid) || jack.Hitbox.Intersects(dockplat.Solid) || jack.Hitbox.Intersects(dockplat2.Solid) || jack.Hitbox.Intersects(road.Solid) || jack.Hitbox.Intersects(road2.Solid) || jack.Hitbox.Intersects(dockplat2.Solid) || jack.Hitbox.Intersects(rope.Solid) || jack.Hitbox.Intersects(watchtowerp.Solid) || jack.Hitbox.Intersects(brownstonep.Solid) || jack.Hitbox.Intersects(brownstonep2.Solid) || jack.Hitbox.Intersects(brownstonep3.Solid) || jack.Hitbox.Intersects(germanhousep.Solid) || jack.Hitbox.Intersects(germanhousep2.Solid) || jack.Hitbox.Intersects(germanhousep3.Solid) || jack.Hitbox.Intersects(brownstonep4.Solid) || jack.Hitbox.Intersects(gech.Solid) || jack.Hitbox.Intersects(gech2.Solid) || jack.Hitbox.Intersects(gech3.Solid) || jack.Hitbox.Intersects(shackp.Solid) || jack.Hitbox.Intersects(roperampart.Solid) || jack.Hitbox.Intersects(rampart.Solid) || jack.Hitbox.Intersects(castletop.Solid) || jack.Hitbox.Intersects(castleclimb.Solid) || jack.Hitbox.Intersects(boxp.Solid) || jack.Hitbox.Intersects(fsp.Solid) || jack.Hitbox.Intersects(php.Solid) || jack.Hitbox.Intersects(php2.Solid) || jack.Hitbox.Intersects(php3.Solid) || jack.Hitbox.Intersects(php4.Solid) || jack.Hitbox.Intersects(php5.Solid) || jack.Hitbox.Intersects(php6.Solid) || jack.Hitbox.Intersects(tavernp.Solid))
                {
                    gravity = -.175f;
                }
                sea.Location = new Vector2(jack.Location.X - 1000, sea.Location.Y);
                if (jack.Hitbox.Intersects(rampart.Solid) || jack.Hitbox.Intersects(roperampart.Solid))
                {
                    castle.depth = 1;
                }
                else
                {
                    castle.depth = .1f;
                }
                if (coats.Count <= 1 && blues.Count <= 1 && began)
                {
                    if (!hijacked)
                    {
                        escapeship.Location = new Vector2(escapeship.Location.X + 5, escapeship.Location.Y);
                    }
                    else if (jack.Hitbox.Intersects(escapeship.Hitbox))
                    {
                        escapeship.Location = new Vector2(escapeship.Location.X + 15, escapeship.Location.Y);
                        jack.Location = new Vector2(escapeship.Location.X + 10, escapeship.Location.Y + 200);
                        if (jack.Location.X >= 20000)
                        {
                            unlocker++;
                            menu = true;
                            currentLevel = levelstate.none;
                        }
                    }
                }
                if (escapeship.Hitbox.Intersects(shackp.Solid) && !hijacked)
                {
                    AnimatingSprite newboss = new AnimatingSprite(Content.Load<Texture2D>("supercoat"), new Vector2(castle.Location.X + 1060, box.Location.Y - 50), Color.White, 125, new Rectangle(0, 0, 0, 0), 1500, 30, Content.Load<SpriteFont>("Spritefont1"), 0);
                    newboss.LoadFrameList(supercoatstand, AnimatingSprite.State.Running);
                    newboss.LoadFrameList(supercoatdeath, AnimatingSprite.State.Crouching);
                    newboss.LoadFrameList(supercoatattack, AnimatingSprite.State.Attacking);
                    newboss.LoadFrameList(supercoatdead, AnimatingSprite.State.Jumping);
                    newboss.currentState = AnimatingSprite.State.Running;
                    newboss.goback = true;
                    newboss.cost = 5000;
                    newboss.origin = new Vector2(newboss.activeFrame.Width / 2, newboss.activeFrame.Height);
                    newboss.LayerDepth = 0.3f;
                    coats.Add(newboss);
                    bluecount -= 75;
                    redcount -= 15;
                    hijacked = true;
                }
                samthecam.update();
                crewcall.Location = new Vector2(jack.Location.X - GraphicsDevice.Viewport.Width / 2, jack.Location.Y - GraphicsDevice.Viewport.Height / 2);
            }
            #endregion
            else if (currentLevel == levelstate.Level3)
            {
                InTheNavy.update();
                Vector2 distance = vessel.Location - cannon.Location;
                float turretRotation = (float)Math.Atan2(distance.Y, distance.X);
                cannon.rotation = turretRotation;
                cannon.xAxis = (int)distance.X;
                cannon.yAxis = (int)distance.Y;
                Math.Atan2(cannon.xAxis, cannon.yAxis);
                moneymoneys.location = new Vector2(vessel.hp.location.X, vessel.hp.location.Y - 20);
                moneymoneys.text = ($"MoneyMoneys:{money}");
                vessel.update(gameTime);
                if (!vessel.isdead)
                {
                    vessel.origin = new Vector2(vessel.activeFrame.Width / 2, vessel.activeFrame.Height / 2);
                    if (B1)
                    {
                        vessel.shoot(vessel.origin);
                    }


                    vessel.xAxis = xAxis;
                    vessel.yAxis = yAxis;

                    vessel.icon.Location = new Vector2(GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Width);


                    if (vessel.rotation >= 10 && vessel.rotation <= 170)
                    {
                        vessel.Location = new Vector2(vessel.Location.X - 3, vessel.Location.Y);
                    }
                    if (vessel.rotation >= 190 && vessel.rotation <= 350)
                    {
                        vessel.Location = new Vector2(vessel.Location.X + 3, vessel.Location.Y);
                    }
                    if (vessel.rotation >= 280 || vessel.rotation <= 80)
                    {
                        vessel.Location = new Vector2(vessel.Location.X, vessel.Location.Y + 3);
                    }
                    if (vessel.rotation <= 260 && vessel.rotation >= 100)
                    {
                        vessel.Location = new Vector2(vessel.Location.X, vessel.Location.Y - 3);
                    }
                    if (vessel.Hitbox.Intersects(IslandOfHotDogs.Hitbox))
                    {
                        vessel.defence -= IslandOfHotDogs.attack;
                    }
                    if (vessel.Hitbox.Intersects(fort.Hitbox))
                    {
                        vessel.defence -= fort.attack;
                    }
                    if(vessel.Hitbox.Intersects(fort.personalspace))
                    {
                        if(B3)
                        {
                            currentLevel = levelstate.cannonfort;
                        }
                    }
                }
                if (vessel.defence <= 0)
                {
                    vessel.isdead = true;
                }
                if (vessel.isdead)
                {
                    vessel.Color = new Color(vessel.alpha, vessel.alpha, vessel.alpha, vessel.alpha);
                    vessel.alpha--;
                }
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(color);
            if (!menu)
            {
                //uglyguy.Draw(spriteBatch);
                if (currentLevel == levelstate.Proluage)
                {
                    color = Color.FromNonPremultiplied(172, 158, 117, 255);
                    spriteBatch.Begin();
                    backround.Draw(spriteBatch);
                    //ship.Draw(spriteBatch);
                    //cabin.Draw(spriteBatch);
                    //cabin2.Draw(spriteBatch);
                    //mast.Draw(spriteBatch);
                    //mast2.Draw(spriteBatch);
                    //mast3.Draw(spriteBatch);
                    //crow.Draw(spriteBatch);
                    boat.Draw(spriteBatch);
                    //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), boat.Hitbox, Color.Red);
                    if (jack.isdead)
                    {
                        losescreen.Draw(spriteBatch);
                    }
                    else
                    {
                        //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), jack.Hitbox, Color.Red);
                        jack.Draw(spriteBatch);
                    }
                    for (int i = 0; i < enemypirates.Count; i++)
                    {
                        if (enemypirates[i].isdead == false)
                        {
                            enemypirates[i].Draw(spriteBatch);
                        }
                    }
                    for (int i = 0; i < enemypirates.Count; i++)
                    {
                        if (enemypirates[i].isdead == false)
                        {
                            enemypirates[i].Draw(spriteBatch);
                            // spriteBatch.Draw(Content.Load<Texture2D>("pixel"), enemypirates[i].Hitbox, Color.Red);
                        }
                    }
                    for (int i = 0; i < enemycaptians.Count; i++)
                    {
                        if (enemycaptians[i].isdead == false)
                        {
                            enemycaptians[i].Draw(spriteBatch);
                            //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), enemycaptians[i].Hitbox, Color.Red);
                        }
                    }

                    pirahna.Draw(spriteBatch);
                    // spriteBatch.Draw(Content.Load<Texture2D>("pixel"), pirahna.Hitbox, Color.Red);
                    cursor.Draw(spriteBatch);
                    spriteBatch.End();
                }
                else if (currentLevel == levelstate.Level1)
                {
                    color = Color.FromNonPremultiplied(172, 158, 117, 255);
                    spriteBatch.Begin();
                    backround2.Draw(spriteBatch);
                    brokenbarrel.Draw(spriteBatch);
                    barrel.Draw(spriteBatch);
                    log.Draw(spriteBatch);
                    box.Draw(spriteBatch);
                    exitsign.Draw(spriteBatch);
                    turtle.Draw(spriteBatch);
                    turtle2.Draw(spriteBatch);
                    turtle3.Draw(spriteBatch);
                    turtle4.Draw(spriteBatch);
                    turtle5.Draw(spriteBatch);
                    turtle6.Draw(spriteBatch);
                    boat.Draw(spriteBatch);
                    turtle8.Draw(spriteBatch);
                    palm.Draw(spriteBatch);
                    raceflag.Draw(spriteBatch);
                    clam.Draw(spriteBatch);
                    clam2.Draw(spriteBatch);
                    if (jack.isdead)
                    {
                        losescreen.Draw(spriteBatch);
                    }
                    else
                    {
                        //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), jack.Hitbox, Color.Red);
                        jack.Draw(spriteBatch);
                    }
                    turtle7.Draw(spriteBatch);
                    //pebble.Draw(spriteBatch);
                    //rock.Draw(spriteBatch);
                    //stone.Draw(spriteBatch);
                    //boulder.Draw(spriteBatch);
                    //palmtree.Draw(spriteBatch);
                    //island.Draw(spriteBatch);
                    //island2.Draw(spriteBatch);
                    cursor.Draw(spriteBatch);
                    spriteBatch.End();
                }
                else if (currentLevel == levelstate.Level2)
                {
                    color = Color.CornflowerBlue;
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, samthecam.effect);
                    sea.Draw(spriteBatch);
                    shackland.Draw(spriteBatch);
                    boat.Draw(spriteBatch);
                    turtle6.Draw(spriteBatch);
                    turtle5.Draw(spriteBatch);
                    dock.Draw(spriteBatch);
                    road.Draw(spriteBatch);
                    road2.Draw(spriteBatch);
                    dock2.Draw(spriteBatch);
                    watchtower.Draw(spriteBatch);
                    germanhouse.Draw(spriteBatch);
                    germanhouse2.Draw(spriteBatch);
                    germanhouse3.Draw(spriteBatch);
                    brownstone.Draw(spriteBatch);
                    brownstone2.Draw(spriteBatch);
                    brownstone3.Draw(spriteBatch);
                    brownstone4.Draw(spriteBatch);
                    fishstand.Draw(spriteBatch);
                    ph.Draw(spriteBatch);
                    ph2.Draw(spriteBatch);
                    ph3.Draw(spriteBatch);
                    ph4.Draw(spriteBatch);
                    ph5.Draw(spriteBatch);
                    ph6.Draw(spriteBatch);
                    tavern.Draw(spriteBatch);
                    castle.Draw(spriteBatch);
                    shack.Draw(spriteBatch);
                    fishbox.Draw(spriteBatch);
                    escapeship.Draw(spriteBatch);
                    crewcall.Draw(spriteBatch);
                    for (int d = 0; d < coats.Count; d++)
                    {
                        coats[d].Draw(spriteBatch);
                    }
                    for (int d = 0; d < blues.Count; d++)
                    {
                        blues[d].Draw(spriteBatch);
                        //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), blues[d].range, Color.Red);
                    }
                    for(int i = 0; i < bosses.Count; i++)
                    {
                        bosses[i].Draw(spriteBatch);
                    }
                    for (int i = 0; i < enemypirates.Count; i++)
                    {
                        enemypirates[i].Draw(spriteBatch);
                    }
                    for (int i = 0; i < clouds.Count; i++)
                    {
                        clouds[i].Draw(spriteBatch);
                    }
                    plane.Draw(spriteBatch);
                    if (jack.isdead || lives >= 5)
                    {
                        losescreen.Draw(spriteBatch);
                    }
                    else if (lives <= 5)
                    {
                        //spriteBatch.Draw(Content.Load<Texture2D>("pixel"), jack.Hitbox, Color.Red);
                        jack.Draw(spriteBatch);
                    }
                    hackland.Draw(spriteBatch);
                    dockplat.Draw(spriteBatch);
                    watchtowerp.Draw(spriteBatch);
                    rope.Draw(spriteBatch);
                    brownstonep.Draw(spriteBatch);
                    brownstonep2.Draw(spriteBatch);
                    brownstonep3.Draw(spriteBatch);
                    germanhousep.Draw(spriteBatch);
                    germanhousep2.Draw(spriteBatch);
                    germanhousep3.Draw(spriteBatch);
                    castleclimb.Draw(spriteBatch);
                    castletop.Draw(spriteBatch);
                    moneymoneys.draw(spriteBatch);
                    cursor.Draw(spriteBatch);
                    spriteBatch.End();
                }
                else if (currentLevel == levelstate.Level3)
                {
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, InTheNavy.effect);
                    // spriteBatch.Begin();
                    color = Color.Navy;
                    for (int i = 0; i < forts.Count; i++)
                    {
                        forts[i].Draw(spriteBatch);
                    }
                    cannon.build(spriteBatch);
                    IslandOfHotDogs.Draw(spriteBatch);
                    // kingkongland.Draw(spriteBatch);
                    moneymoneys.draw(spriteBatch);
                    vessel.Draw(spriteBatch);
                    portroyal.Draw(spriteBatch);
                    //  starboard.Draw(spriteBatch);
                    cursor.Draw(spriteBatch);
                    spriteBatch.End();
                }
            }
            else if (menu)
            {
                color = Color.FromNonPremultiplied(172, 158, 117, 255);
                spriteBatch.Begin();
                menuback.Draw(spriteBatch);
                prologue.Draw(spriteBatch);
                if (unlocker >= 1)
                {
                    level1.Draw(spriteBatch);
                }
                if (unlocker >= 2)
                {
                    level2.Draw(spriteBatch);
                }
                if (unlocker >= 3)
                {
                    level3.Draw(spriteBatch);
                }
                cursor.Draw(spriteBatch);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}