 asyncTest('encadenar fail',()=> {
     endEdition();
 });

 function endEdition() {
     persist().fail((parameterToTest) => {
        QUnit.start();
        equal(parameterToTest,'myParametro');        
        
     });
 }

 function persist() : JQueryPromise<any> {
    var dfd = $.Deferred();
     persistAjax().fail(() => {
         dfd.reject('myParametro');
     });
     return dfd.promise();
 }

 function persistAjax() : JQueryPromise<any> {
    return $.ajax({url:"esto/vaAPetar"});
 }