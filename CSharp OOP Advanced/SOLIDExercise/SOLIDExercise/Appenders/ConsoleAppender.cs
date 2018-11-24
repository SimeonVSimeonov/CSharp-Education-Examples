namespace SOLIDExercise.Appenders
{
    using System;
    using Enums;
    using Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                Console.WriteLine(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }
    }
}
