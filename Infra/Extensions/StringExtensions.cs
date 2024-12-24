using System.Globalization;

namespace Infra.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converte um valor decimal ou double para uma string formatada com a moeda corrente.
        /// </summary>
        /// <param name="valor">O valor decimal a ser formatado.</param>
        /// <param name="cultura">A cultura para formatação. (Opcional, usa padrão do sistema)</param>
        /// <returns>String representando o valor formatado como moeda.</returns>
        public static string ParaMoeda(this decimal valor, CultureInfo? cultura = null)
        {
            cultura ??= CultureInfo.CurrentCulture; // Usa a cultura padrão do sistema, se nenhuma for fornecida.
            return string.Format(cultura, "{0:C}", valor);
        }
    }
}
