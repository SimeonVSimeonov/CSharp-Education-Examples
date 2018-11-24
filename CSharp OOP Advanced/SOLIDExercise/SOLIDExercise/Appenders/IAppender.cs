namespace SOLIDExercise.Appenders
{
    using Enums;
    using Layouts;

    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string data, ReportLevel level, string message);

        ReportLevel ReportLevel {get; set;}
    }
}
