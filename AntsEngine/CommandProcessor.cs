using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AntsEngine
{
    class CommandProcessor
    {
        List<FieldInfo> bools = new List<FieldInfo>();
        public CommandProcessor()
        {
            List<FieldInfo> f = typeof(Variables).GetFields().ToList();
            bools = f.Where(p => p.FieldType == typeof(Boolean)).ToList();

        }
        public void ProcessCommand(string commandRaw, MyWorld w)
        {
            string[] commandStructure = commandRaw.Split(new char[] { ' ' });
            string command = commandStructure[0];
            string[] arguments = new string[commandStructure.Length - 1];
            for (int i = 1; i < commandStructure.Length; i++)
            {
                arguments[i - 1] = commandStructure[i];
            }

            switch (command)
            {
                case "ShowPaths":
                    ProcessShowPaths(arguments);
                    break;
                case "ShowSensingRadius":
                    ProcessShowSensingRadius(arguments);
                    break;
                case "ShowPathsToFood":
                    ProcessShowPathsToFood(arguments);
                    break;
                case "ShowSenseLines":
                    ProcessShowSenseLines(arguments);
                    break;
                case "Spawn":
                    ProcessSpawn(arguments, w);
                    break;
                case "var":
                    ProcessVar(arguments);
                    break;
                case "ClearActors":
                    w.ClearActors();
                    break;
                default:
                    outputString("Unknown command");
                    break;
            }
        }
        static void outputString(string s)
        {
            Console.WriteLine(s);
        }

        public void ProcessVar(string[] arguments)
        {
            if (arguments.Length > 0)
            {
                FieldInfo v = null;
                foreach (FieldInfo f in bools)
                {
                    if (f.Name == arguments[0])
                        v = f;
                }
                if (v != null && arguments.Length > 1 && (arguments[1] == "true" || arguments[1] == "false" || arguments[1] == "0" || arguments[1] == "1"))
                {
                    if (arguments[1] == "true" || arguments[1] == "1")
                    {
                        v.SetValue(null, true);
                    }
                    else
                    {
                        v.SetValue(null, false);
                    }
                }
                else if (v != null)
                {
                    outputString(v.GetValue(null).ToString());
                }
                else
                {
                    //outputString("Unknown structure of command var");
                    foreach (var b in bools)
                    {
                        outputString(b.Name);
                    }
                }
            }
        }
        #region Processors
        //Spawn
        private static void ProcessSpawn(string[] arguments, MyWorld w)
        {
            if (arguments.Length > 0)
            {
                if (arguments.Length >= 3)
                {
                    int x, y;
                    if (!int.TryParse(arguments[1], out x) || !int.TryParse(arguments[2], out y))
                    {
                        outputString("Unknown structure of command Spawn");
                    }
                    else
                        switch (arguments[0])
                        {
                            case "Food":
                                w.AddActor(new Actors.Food() { position = new Ants.Vector2(x, y) });
                                break;
                            case "Anthill":
                                w.AddActor(new Actors.Anthill() { position = new Ants.Vector2(x, y) });
                                break;
                            default:
                                outputString("Unknown actor");
                                break;
                        }
                }
            }
        }
        //Variables
        private static void ProcessShowPaths(string[] arguments)
        {
            if (arguments.Length > 0)
            {
                if (arguments[0] == "set" && arguments.Length > 1 && (arguments[1] == "true" || arguments[1] == "false"))
                {
                    if (arguments[1] == "true")
                    {
                        Variables.showPaths = true;
                    }
                    else
                    {
                        Variables.showPaths = false;
                    }
                }
                else
                {
                    outputString("Unknown structure of command ShowPaths");
                }
            }
            else
            {
                outputString(Variables.showPaths.ToString());
            }
        }
        private static void ProcessShowSensingRadius(string[] arguments)
        {
            if (arguments.Length > 0)
            {
                if (arguments[0] == "set" && arguments.Length > 1 && (arguments[1] == "true" || arguments[1] == "false"))
                {
                    if (arguments[1] == "true")
                    {
                        Variables.showSensingRadius = true;
                    }
                    else
                    {
                        Variables.showSensingRadius = false;
                    }
                }
                else
                {
                    outputString("Unknown structure of command ShowSensingRadius");
                }
            }
            else
            {
                outputString(Variables.showSensingRadius.ToString());
            }
        }
        private static void ProcessShowSenseLines(string[] arguments)
        {
            if (arguments.Length > 0)
            {
                if (arguments[0] == "set" && arguments.Length > 1 && (arguments[1] == "true" || arguments[1] == "false"))
                {
                    if (arguments[1] == "true")
                    {
                        Variables.showSenseLines = true;
                    }
                    else
                    {
                        Variables.showSenseLines = false;
                    }
                }
                else
                {
                    outputString("Unknown structure of command ShowSenseLines");
                }
            }
            else
            {
                outputString(Variables.showSenseLines.ToString());
            }
        }
        private static void ProcessShowPathsToFood(string[] arguments)
        {
            if (arguments.Length > 0)
            {
                if (arguments[0] == "set" && arguments.Length > 1 && (arguments[1] == "true" || arguments[1] == "false"))
                {
                    if (arguments[1] == "true")
                    {
                        Variables.showPathsToFood = true;
                    }
                    else
                    {
                        Variables.showPathsToFood = false;
                    }
                }
                else
                {
                    outputString("Unknown structure of command ShowPathsToFood");
                }
            }
            else
            {
                outputString(Variables.showPathsToFood.ToString());
            }

        }
        #endregion
    }
}
