using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.Partials
{
    class PbBuiltInConsants
    {
        public const string MyBuiltInConstant = "Paco";
        
        public class Definitions
        {
            public class FaceBook
            {
                public const string MyBuiltInInConstant = "FacebookPaco";

            }

        }

    }


    class PbWebSiteConstants : PbBuiltInConsants
    {
        public const string MySiteInConstant = "Jose";
        
        public new class Definitions : PbBuiltInConsants.Definitions
        {
            public new class FaceBook : PbBuiltInConsants.Definitions.FaceBook
            {
                public const string MySiteInConstant = "FacebookJose";

            }

            public class MyWidget
            {
                public const string MySiteInConstant = "MyWidget";

            }

        }
    }




    public class MyView
    {
        public void Render()
        {
            //PbWebSiteConstants.Arr != PbBuiltInConsants.Arr;

            var myBuiltIn = PbWebSiteConstants.MyBuiltInConstant;
            var mySite = PbWebSiteConstants.MySiteInConstant;
            //PbWebSiteConstants.Definitions.FaceBook.MySiteInConstant
            //PbWebSiteConstants.Definitions.FaceBook.            //PbWebSiteConstants.Definitions.FaceBook.MySiteInConstant
        }
    }
}
