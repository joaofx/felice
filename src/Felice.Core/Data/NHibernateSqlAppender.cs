////
//// this class was get on http://www.codeproject.com/Articles/249154/Logging-NHibernate-queries-with-parameters
////
namespace Felice.Core.Data
{
    using System.Text.RegularExpressions;
    using log4net.Appender;
    using log4net.Core;
    using System.Text;

    public class NHibernateSqlAppender : ConsoleAppender
    {
        private const string ParameterStart = ":p";

        protected override void Append(LoggingEvent loggingEvent)
        {
            var loggingEventData = loggingEvent.GetLoggingEventData();
            
            if (loggingEventData.Message.Contains(ParameterStart))
            {
                var messageBuilder = new StringBuilder();

                var message = loggingEventData.Message;
                var queries = Regex.Split(message, @"command\s\d+:");

                foreach (var query in queries)
                {
                    messageBuilder.Append(ReplaceQueryParametersWithValues(query));
                }

                loggingEventData.Message = messageBuilder.ToString();
            }

            base.Append(new LoggingEvent(loggingEventData));
        }

        private static string ReplaceQueryParametersWithValues(string query)
        {
            return Regex.Replace(query, string.Format(@"{0}\d(?=[,);\s])(?!\s*=)", ParameterStart), match =>
            {
                var parameterValueRegex = new Regex(
                    string.Format(@".*{0}\s*=\s*(.*?)\s*[\[].*", match), RegexOptions.Compiled);

                var value = parameterValueRegex.Match(query).Groups[1].ToString();
                
                if (value.StartsWith("'") == false)
                {
                    return "'" + value + "'";
                }

                return value;
            });
        }
    }
}
