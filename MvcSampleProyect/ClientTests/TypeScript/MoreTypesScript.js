var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var MoreTypescript;
(function (MoreTypescript) {
    var MyBaseClass = (function () {
        function MyBaseClass() {
        }
        MyBaseClass.prototype.myBaseMethod = function () {
        };
        return MyBaseClass;
    })();

    var MyOtherBaseClass = (function () {
        function MyOtherBaseClass() {
        }
        MyOtherBaseClass.prototype.myOtherBaseMethod = function () {
        };
        return MyOtherBaseClass;
    })();

    var MyUltraClass = (function (_super) {
        __extends(MyUltraClass, _super);
        function MyUltraClass() {
            _super.apply(this, arguments);
        }
        return MyUltraClass;
    })(MyBaseClass);
})(MoreTypescript || (MoreTypescript = {}));

var kito;

var Mondongo = (function () {
    function Mondongo() {
    }
    Mondongo.prototype.pepito = function () {
    };
    Mondongo.prototype.pablito = function () {
    };
    return Mondongo;
})();
//# sourceMappingURL=MoreTypesScript.js.map
