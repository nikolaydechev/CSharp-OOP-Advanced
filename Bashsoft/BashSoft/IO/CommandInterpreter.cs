namespace BashSoft
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            commandName = commandName.ToLower();
            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                       .Where(atr => atr.Equals(command))
                                       .ToArray().Length > 0);

            if (typeOfCommand == null)
            {
                throw new InvalidCommandException(input);
            }

            Type typeOfInterpreter = typeof(CommandInterpreter);

            IExecutable exe = (IExecutable)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            
            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe,
                            fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;

            //switch (command)
            //{
            //    case "open":
            //        return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    //TryOpenFile(input, data);
            //    case "mkdir":
            //        return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    //TryCreateDirectory(input, data);
            //    //break;
            //    case "is":
            //        return new TraverseFoldersCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryTraverseFolders(input, data);
            //    //break;
            //    case "cmp":
            //        return new CompareFilesCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    case "cdrel":
            //        return new ChangeRelativePathCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryChangePathRelatively(input, data);
            //    //break;
            //    case "cdabs":
            //        return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryChangePathAbsolute(input, data);
            //    //break;
            //    case "readdb":
            //        return new ReadDatabaseCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryReadDatabaseFromFile(input, data);
            //    //break;
            //    case "help":
            //        return new GetHelpCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryGetHelp(input, data);
            //    //break;
            //    case "filter":
            //        return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryFilterAndTake(input, data);
            //    //break;
            //    case "order":
            //        return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository,
            //            this.inputOutputManager);
            //    //TryOrderAndTake(input, data);
            //    //break;
            //    case "decorder":
            //        return null;
            //    //break;
            //    case "download":
            //        return null;
            //    //break;
            //    case "downloadasynch":
            //        return null;
            //    //break;
            //    case "show":
            //        return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    //TryShowWantedData(input, data);
            //    //break;
            //    case "dropdb":
            //        return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    //TryDropDb(input, data);
            //    //break;
            //    case "display":
            //        return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputManager);

            //    default:
            //        throw new InvalidCommandException(input);
            //        //DisplayInvalidCommandMessage(input);
            //        //break;
            //}
        }
    }
    //private void TryDropDb(string input, string[] data)
    //{
    //    if (data.Length != 1)
    //    {
    //        this.DisplayInvalidCommandMessage(input);
    //        return;
    //    }

    //    this.repository.UnloadData();
    //    OutputWriter.WriteMessageOnNewLine("Database dropped!");
    //}

    //private void TryOrderAndTake(string input, string[] data)
    //{
    //    if (data.Length == 5)
    //    {
    //        string courseName = data[1];
    //        string comparison = data[2].ToLower();
    //        string takeCommand = data[3].ToLower();
    //        string takeQuantity = data[4].ToLower();

    //        TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
    //{
    //    if (takeCommand == "take")
    //    {
    //        if (takeQuantity == "all")
    //        {
    //            this.repository.OrderAndTake(courseName, comparison);
    //        }
    //        else
    //        {
    //            int studentsToTake;
    //            bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
    //            if (hasParsed)
    //            {
    //                this.repository.OrderAndTake(courseName, comparison, studentsToTake);
    //            }
    //            else
    //            {
    //                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommandParameter);
    //    }
    //}

    //private void TryFilterAndTake(string input, string[] data)
    //{
    //    if (data.Length == 5)
    //    {
    //        string courseName = data[1];
    //        string filter = data[2].ToLower();
    //        string takeCommand = data[3].ToLower();
    //        string takeQuantity = data[4].ToLower();

    //        TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
    //{
    //    if (takeCommand == "take")
    //    {
    //        if (takeQuantity == "all")
    //        {
    //            this.repository.FilterAndTake(courseName, filter);
    //        }
    //        else
    //        {
    //            int studentsToTake;
    //            bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
    //            if (hasParsed)
    //            {
    //                this.repository.FilterAndTake(courseName, filter, studentsToTake);
    //            }
    //            else
    //            {
    //                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommandParameter);
    //    }
    //}

    //private void TryShowWantedData(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string courseName = data[1];
    //        this.repository.GetAllStudentsFromCourse(courseName);
    //    }
    //    else if (data.Length == 3)
    //    {
    //        string courseName = data[1];
    //        string userName = data[2];
    //        this.repository.GetStudentScoresFromCourse(courseName, userName);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryGetHelp(string input, string[] data)
    //{
    //    if (data.Length == 1)
    //    {
    //        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
    //        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //        OutputWriter.WriteEmptyLine();
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryReadDatabaseFromFile(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string fileName = data[1];
    //        this.repository.LoadData(fileName);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryChangePathAbsolute(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string absolutePath = data[1];
    //        this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryChangePathRelatively(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string relPath = data[1];
    //        this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryCompareFiles(string input, string[] data)
    //{
    //    if (data.Length == 3)
    //    {
    //        string firstPath = data[1];
    //        string secondPath = data[2];

    //        this.judge.CompareContent(firstPath, secondPath);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryTraverseFolders(string input, string[] data)
    //{
    //    if (data.Length == 1)
    //    {
    //        this.inputOutputManager.TraverseDirectory(0);
    //    }
    //    else if (data.Length == 2)
    //    {
    //        int depth;
    //        bool hasParsed = int.TryParse(data[1], out depth);
    //        if (hasParsed)
    //        {
    //            this.inputOutputManager.TraverseDirectory(depth);
    //        }
    //        else
    //        {
    //            OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
    //        }
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryCreateDirectory(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string folderName = data[1];
    //        this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void TryOpenFile(string input, string[] data)
    //{
    //    if (data.Length == 2)
    //    {
    //        string fileName = data[1];
    //        Process.Start(SessionData.currentPath + "\\" + fileName);
    //    }
    //    else
    //    {
    //        DisplayInvalidCommandMessage(input);
    //    }
    //}

    //private void DisplayInvalidCommandMessage(string input)
    //{
    //    var message = $"The command '{input}' is invalid";
    //    OutputWriter.DisplayException(message);
    //}
}

