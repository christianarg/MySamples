/// <reference path="../../Scripts/linq.d.ts" />
 
 class MyTestClass {
     public nombre : string;
     public apellido : string;

     constructor(nombre, apellido) {
         this.nombre = nombre;
         this.apellido = apellido;
     }
 }

 test('GroupBy',()=> {
    // ARRANGE
    var myArray : Array<MyTestClass> = [];
    myArray.push(new MyTestClass('paco','luis'));
    myArray.push(new MyTestClass('jorge','perez'));
    myArray.push(new MyTestClass('paco','van der jose'));
    //ACT
    var groupedByPaco = Enumerable.From(myArray)
                            .GroupBy((c : MyTestClass) => c.nombre)
                            .Where((g) => {
                                return g.Key() == 'paco';
                            }).Select('$.ToArray()').ToArray()[0];
    // ASSERT 
    equal(groupedByPaco.length,2);

    var pacoluis = Enumerable.From(groupedByPaco).Where((p :MyTestClass) => p.apellido == 'luis').SingleOrDefault(null);
    ok(pacoluis != null);

    var pacovanderjose = Enumerable.From(groupedByPaco).Where((p :MyTestClass) => p.apellido == 'van der jose').SingleOrDefault(null);
    ok(pacovanderjose != null);

 })