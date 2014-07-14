/// <reference path="../Framework/qunit.d.ts" />
test('mi primer prueba Typescript', function () {
    var map = new Map();

    map.set("pepe", new Cosa("pepe"));
    map.set("paco", new Cosa("paco"));

    var cosa = map.get("pepe");
    equal(cosa.text, 'pepe');
    ok(cosa);
});

var Cosa = (function () {
    function Cosa(text) {
        this.text = text;
    }
    return Cosa;
})();
//# sourceMappingURL=TypesScriptTest.js.map
