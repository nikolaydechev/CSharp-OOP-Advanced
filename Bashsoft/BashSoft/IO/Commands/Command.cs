namespace BashSoft.IO.Commands
{
    using System;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.SimpleJudge;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        //private IContentComparer judge;
        //private IDatabase repository;
        //private IDirectoryManager inputOutputManager;

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
            //this.judge = judge;
            //this.repository = repository;
            //this.inputOutputManager = inputOutputManager;
        }

        protected string Input
        {
            get
            {
                return this.input;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        //protected IContentComparer Judge { get { return this.judge; } }
        //protected IDatabase StudentRepository { get { return this.repository; } }
        //protected IDirectoryManager InputOutputManager { get { return this.inputOutputManager; } }

        public abstract void Execute();

    }
}
