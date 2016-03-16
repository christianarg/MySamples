using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.ExplicitInterface.Improved
{
    public class LocalizationAppSvc
    {
        ILocalizationFactory factory;

        public void Create()
        {
            var content = new Content();
            content.CreateLocalization(factory);
        }
    }

    /* 
     * Esta implementación es más robusta porque no da lugar a errores
     * porque el método del objeto del dominio REQUIERE una ILocalizationFactory
     *
     */
    public interface ILocalizationFactory
    {
        Localization Create(Content content);
    }

    internal class LocalizationFactory : ILocalizationFactory
    {
        public Localization Create(Content content)
        {
            var localization = new Localization();

            // Logica de creación compleja :)
            return localization;
        }
    }

    public class Content
    {
        private List<Localization> Localizations = new List<Localization>();

        /// <summary>
        /// Como forzamos a 
        /// </summary>
        /// <param name="factory"></param>
        public void CreateLocalization(ILocalizationFactory factory)
        {
            Localizations.Add(factory.Create(this));
        }
    }

    public class Localization
    {
    }
}
