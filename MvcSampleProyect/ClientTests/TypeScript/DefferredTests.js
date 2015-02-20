asyncTest('encadenar fail', function () {
    endEdition();
});
function endEdition() {
    persist().fail(function (parameterToTest) {
        QUnit.start();
        equal(parameterToTest, 'myParametro');
    });
}
function persist() {
    var dfd = $.Deferred();
    persistAjax().fail(function () {
        dfd.reject('myParametro');
    });
    return dfd.promise();
}
function persistAjax() {
    return $.ajax({ url: "esto/vaAPetar" });
}
//# sourceMappingURL=DefferredTests.js.map