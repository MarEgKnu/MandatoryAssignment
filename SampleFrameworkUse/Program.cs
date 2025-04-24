
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

IWorld world = new SampleWorld(objRepo, entityRepo, difficultyRepository, maxY, maxX, selectedDiff);

ConfigLoader configLoader = new SampleConfigLoader(@".\config\config.xml");

IGameLoop gameLoop = new SampleGameLoop();

Logger logger = new Logger(new System.Diagnostics.TraceSource("[GAME]", System.Diagnostics.SourceLevels.All));


IGameState gameState = new SampleGameState(world, configLoader, logger, gameLoop);

gameState.LoadConfig();