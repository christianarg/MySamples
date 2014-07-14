/// <reference path="../../Scripts/linq.d.ts" />
var MyTestClass = (function () {
    function MyTestClass(nombre, apellido) {
        this.nombre = nombre;
        this.apellido = apellido;
    }
    return MyTestClass;
})();

test('GroupBy', function () {
    // ARRANGE
    var myArray = [];
    myArray.push(new MyTestClass('paco', 'luis'));
    myArray.push(new MyTestClass('jorge', 'perez'));
    myArray.push(new MyTestClass('paco', 'van der jose'));

    //ACT
    var groupedByPaco = Enumerable.From(myArray).GroupBy(function (c) {
        return c.nombre;
    }).Where(function (g) {
        return g.Key() == 'paco';
    }).Select('$.ToArray()').ToArray()[0];

    // ASSERT
    equal(groupedByPaco.length, 2);

    var pacoluis = Enumerable.From(groupedByPaco).Where(function (p) {
        return p.apellido == 'luis';
    }).SingleOrDefault(null);
    ok(pacoluis != null);

    var pacovanderjose = Enumerable.From(groupedByPaco).Where(function (p) {
        return p.apellido == 'van der jose';
    }).SingleOrDefault(null);
    ok(pacovanderjose != null);
});
//# sourceMappingURL=LinqJsTests.js.map
