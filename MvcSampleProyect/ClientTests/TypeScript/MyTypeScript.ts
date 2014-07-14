/// <reference path="MoreTypesScript.ts" />


module MyNewModule {
    export class MyPepe{
        public queonda() : string{
            return 'queonda';
        }
    }
}


module MyNewModule.Pepe {
    declare var $;
    export class MyPepe2 {
        queondaResult:string
        public queOndaMostro(pepino: MyNewModule.MyPepe) {
            this.queondaResult = pepino.queonda();
        }
        public static dapePapa(): string {
            var myPepe = new MyNewModule.MyPepe();
            var myPepe2 = new MyPepe2();
            myPepe2.queOndaMostro(myPepe);
            return myPepe2.queondaResult;
        }
    }
}


