/// <reference path="../Scripts/jquery.d.ts" />
var myAjaxModule;
(function (myAjaxModule) {
    var MyAjaxClass = (function () {
        function MyAjaxClass() {
            this.doer = new StuffDoer();
        }
        MyAjaxClass.prototype.DoAjax = function () {
            var _this = this;
            $.ajax({
                url: "/TypeScriptTest/AjaxCall/1"
            }).then(function () {
                return _this.AjaxRespomse;
            });
        };
        MyAjaxClass.prototype.Aha = function (serverObject) {
            this.doer.Aha(serverObject);
        };
        MyAjaxClass.prototype.AjaxRespomse = function (serverObject) {
            this.Aha(serverObject);
        };
        return MyAjaxClass;
    })();
    myAjaxModule.MyAjaxClass = MyAjaxClass;

    var StuffDoer = (function () {
        function StuffDoer() {
        }
        StuffDoer.prototype.Aha = function (serverObject) {
            $('#stuffHere').html('<div>' + serverObject.MyProperty + '</div>');
        };
        return StuffDoer;
    })();
})(myAjaxModule || (myAjaxModule = {}));

$(document).ready(function () {
    $('#clickToStuff').click(function () {
        var myClass = new myAjaxModule.MyAjaxClass();
        myClass.DoAjax();
    });
});
//# sourceMappingURL=MyAjaxTest.js.map
