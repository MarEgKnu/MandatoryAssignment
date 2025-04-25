
using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Repositories;
using MandatoryAssignment.Structs;
using MandatoryAssignment.Utility;
using SampleFrameworkUse;
using SampleFrameworkUse.Difficulties;
using SampleFrameworkUse.Repositories;
using SampleFrameworkUse.Utility;

IWorldObjectRepository objRepo = new WorldObjectRepository();

IWorldEntityRepository entityRepo = new WorldEntityRepository();

IDifficultyRepository difficultyRepository = new DifficultyRepository(new Dictionary<string, IDifficulty>());

difficultyRepository.Add(NormalDifficulty.Instance.Name, NormalDifficulty.Instance);
difficultyRepository.Add(NoviceDifficulty.Instance.Name, NoviceDifficulty.Instance);
difficultyRepository.Add(TrainedDifficulty.Instance.Name, TrainedDifficulty.Instance);

IDifficulty selectedDiff = NormalDifficulty.Instance;

PositiveInt maxY = new PositiveInt(100);
PositiveInt maxX = new PositiveInt(100);

IMovementManager movementMgr = new SampleMovementManager();

ICombatManager combatMgr = new SampleCombatManager();

IWorld world = new SampleWorld(objRepo, entityRepo, difficultyRepository, maxY, maxX, selectedDiff, movementMgr, combatMgr);

ConfigLoader configLoader = new SampleConfigLoader(@".\config\config.xml");

IGameLoop gameLoop = new SampleGameLoop();

Logger logger = new Logger(new System.Diagnostics.TraceSource("[GAME]", System.Diagnostics.SourceLevels.All));


IReceiveHitStrategy receiveHitStrategy = new ReceiveHitAccumulateReduction();

IGameState gameState = new SampleGameState(world, configLoader, logger, gameLoop);

gameState.LoadConfig();
// create basic armor for the player
DefenceItem armor = new BasicDefenceArmor("Basic Armor");

//Create basic sword for the player to wield
AttackItem basicSword = new BasicSword("Basic Sword");
// use decorator to enchant it
IWorldItem enchantedSword = new EnchantedWeapon("Enchanted Basic Sword", basicSword, 5, 1);
// create a bad for the player, and add the enchanted sword and basic armor to it
IWorldItem playerBag = new SampleContainer("Bagpack", new List<IWorldItem>() { enchantedSword }, new HashSet<PositiveInt>());

// create sword for enemy
IWorldItem enemyItem = new BasicSword("Basic Sword");

IWorldEntity player = new SampleMonster("Player", 40, new DamageReduction(5, 20), receiveHitStrategy, new Coordinate(10, 10), playerBag, true);

MandatoryAssignment.Interfaces.IObserver<IWorldEntity> playerHitObserver = new PlayerHitObserver();

//add observer
player.OnHit += playerHitObserver.Update;

// create player character
gameState.World.WorldEntities.Add(player);

//enemy monster
IWorldEntity monster = new SampleMonster("Gremlin", 40, new DamageReduction(2, 0), receiveHitStrategy, new Coordinate(5, 5), enemyItem, false);

// create enemy monster
gameState.World.WorldEntities.Add(monster);

IWorldObjectFactory lootFactory;
//use factory to create loot objects based on difficulty
if(gameState.World.SelectedDifficulty is NoviceDifficulty)
{
    lootFactory = new NoviceLootableFactory();
}
else if(gameState.World.SelectedDifficulty is NormalDifficulty)
{
    lootFactory = new NormalLootableFactory();
}
else
{
    lootFactory = new TrainedLootableFactory();
}

Coordinate position = new Coordinate(6, 6);
// add loot object to the game world
gameState.World.WorldObjects.Add(lootFactory.CreateObject(position));

//make the monster attack the player to test observers
player.ReceiveHit(monster.Hit());

gameState.StartGameLoop();
