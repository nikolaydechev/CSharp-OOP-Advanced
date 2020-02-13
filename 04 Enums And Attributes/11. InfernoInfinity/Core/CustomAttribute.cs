namespace _11.InfernoInfinity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; set; }  //- prints the author of the class

        public int Revision { get; set; } //- prints the revision of the class

        public string Description { get; set; } //- prints the class description

        public IList<string> Reviewers { get; set; } //- prints the reviewers of the class

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Author: {this.Author}");
            sb.AppendLine($"Revision: {this.Revision}");
            sb.AppendLine($"Class description: {this.Description}");
            sb.AppendLine($"Reviewers: {string.Join(", ", this.Reviewers)}");

            return sb.ToString().Trim();
        }
    }
}
