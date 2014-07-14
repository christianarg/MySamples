/// <reference path="MoreTypesScript.ts" />
var MyNewModule;
(function (MyNewModule) {
    var MyPepe = (function () {
        function MyPepe() {
        }
        MyPepe.prototype.queonda = function () {
            return 'queonda';
        };
        return MyPepe;
    })();
    MyNewModule.MyPepe = MyPepe;
})(MyNewModule || (MyNewModule = {}));

var MyNewModule;
(function (MyNewModule) {
    (function (Pepe) {
        var MyPepe2 = (function () {
            function MyPepe2() {
            }
            MyPepe2.prototype.queOndaMostro = function (pepino) {
                this.queondaResult = pepino.queonda();
            };
            MyPepe2.dapePapa = function () {
                var myPepe = new MyNewModule.MyPepe();
                var myPepe2 = new MyPepe2();
                myPepe2.queOndaMostro(myPepe);
                return myPepe2.queondaResult;
            };
            return MyPepe2;
        })();
        Pepe.MyPepe2 = MyPepe2;
    })(MyNewModule.Pepe || (MyNewModule.Pepe = {}));
    var Pepe = MyNewModule.Pepe;
})(MyNewModule || (MyNewModule = {}));
//# sourceMappingURL=MyTypeScript.js.map
