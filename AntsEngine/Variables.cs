using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsEngine
{
    public class Variables
    {
        public const double antSpawnDelay = 100;
        public const int maximumDistanceFromAnthill = 1000;
        public const double maximumDistanceToNewTarget = 60;
        public const double pixelsPerSecond = 1.5;
        public const double sensingRadius = 50;

        public const byte uiTransparency = 80;

        public static bool showPaths = false;
        public static bool showSensingRadius = true;
        public static bool showSenseLines = true;
        public static bool showPathsToFood = true;
        public static bool paused = false;
    }
}
