using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*En este ejemplo la factory es publica y el método de añadir localización 
 *(una vez creada la instancia) es interno
 *
 * PRO: Desde la capa de aplicación queda muy claro como funciona y no se ve el método AddLocalization
 * CONTRA: Desde el dominio, alguen se puede confundir y puede no saber si llamar a Content.AddLocalization
 */
namespace SamplesTestProyect.ExplicitInterface.Mejorable
{
    public class LocalizationAppSvc
    {
        ILocalizationFactory factory;

        public void Create()
        {
            var content = new Content();
            var localization = factory.Create(content);

            //content.AddLocalization(localization);
        }
    }

    public interface ILocalizationFactory
    {
        Localization Create(Content content);
    }

    public class LocalizationFactory : ILocalizationFactory
    {
        public Localization Create(Content content)
        {
            var localization = new Localization();

            // Logica de creación compleja :)
            content.AddLocalization(localization);
            return localization;
        }
    }

    public class Content
    {
        private List<Localization> Localizations = new List<Localization>();

        /// <summary>
        /// Posible desventaja:
        /// 
        /// El código cliente podría llamar a este método sin una localización creada correctamente
        /// </summary>
        /// <param name="localization"></param>
        internal void AddLocalization(Localization localization)
        {
            Localizations.Add(localization);
        }
    }

    public class Localization { }
}
