using System.Text;
using Domain.Models;

namespace DataProcessingApplication.Helpers
{
	public static class HtmlHelper
	{
        public static string GetErrorHtml(string errorMessage)
        {
            var html = System.IO.File.ReadAllText(@"./Assets/Error.html");
            html = html.Replace("{{errorMessage}}", errorMessage);
            return html;
        }

		public static string GetQueryHtml(Query query)
		{
            var html = System.IO.File.ReadAllText(@"./Assets/Query.html");
            html = GetQueryHtml(html, query);
            return html;
        }

        private static string GetQueryHtml(string html, Query query)
        {
            var sb = new StringBuilder(); var i = 0;
            foreach(var symbol in query.Symbols)
            {
                sb.Append($@"<div class=""container {(i % 2 == 0 ? "left" : "right")}""><div class=""content"">
                    <h2>Time range: {symbol.TimeFrom} - {symbol.TimeTo}</h2>
                    <h3>Symbol price: {symbol.Price}</h3>
                    <p>
                        column5: {symbol.Column5}, column6: {symbol.Column6}, column7: {symbol.Column7}, column8: {symbol.Column8},
                        column9: {symbol.Column9}, column10: {symbol.Column10}, column11: {symbol.Column11}, column12: {symbol.Column12},
                        column13: {symbol.Column13}, column14: {symbol.Column14}, column15: {symbol.Column15} 
                    </p>
                    <table>
                        <tr>
                            <th>Indicator name</th>
                            <th>Execution</th>
                            <th>Parameters</th>
                        </tr>
                    
                ");
                foreach (var indicator in query.Indicators.Where(x => x.TimeFrom >= symbol.TimeFrom && x.TimeTo <= symbol.TimeTo))
                {
                    sb.Append($@"
                    <tr>
                    <td>{indicator.Name}</td><td>{indicator.Execution}</td>
                    <td>{string.Join(", ", indicator.Parameters.Select(x => $"{x.Name}: {x.Value}"))}</td>
                    </tr>");
                }
                sb.Append("</table></div></div>");
                i++;
            }

            html = html.Replace("{{indicatorContent}}", sb.ToString());
            return html;
        }
    }
}