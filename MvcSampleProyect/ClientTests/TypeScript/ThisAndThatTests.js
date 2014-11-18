/// <reference path="../../Scripts/jquery.d.ts" />
/// <reference path="../Framework/qunit.d.ts" />
var TestContext = (function () {
    function TestContext() {
    }
    return TestContext;
})();

// Variable global
var textContext;

QUnit.module("ThisAndThatTest", {
    setup: function () {
        textContext = new TestContext();
        var jSomeDom = $('<div id="someDomId"></div>');
        $('#qunit-fixture').append(jSomeDom);
        textContext.jTestDom = jSomeDom;
    },
    teardown: function () {
    }
});

test('1 - When Bind a Click using function() keyword "this" is the DomElement', function () {
    // ARRANGE
    var jSomeDom = textContext.jTestDom;
    jSomeDom.click(function () {
        textContext.testOutput = $(this).attr('id');
    });

    // ACT
    jSomeDom.click();

    // ASSERT
    equal(textContext.testOutput, 'someDomId');
});

test('1.1 - When Bind a Click using function name keyword "this" is the DomElement and event Arguments recieved', function () {
    // ARRANGE
    var jSomeDom = textContext.jTestDom;
    jSomeDom.click(clickHandler);

    // ACT
    jSomeDom.click();

    // ASSERT
    equal(textContext.testOutput, 'someDomId_click');
});

function clickHandler(evt) {
    textContext.testOutput = $(this).attr('id') + '_' + evt.type;
}

var ThisAndThatTestClass = (function () {
    function ThisAndThatTestClass(jDom) {
        this.someText = 'someText';
        this.jTestDom = jDom;
    }
    ThisAndThatTestClass.prototype.getSomeText = function () {
        return this.someText;
    };

    ThisAndThatTestClass.prototype.bindHandlerWithLambda = function () {
        var _this = this;
        this.jTestDom.click(function () {
            textContext.testOutput = _this.someText;
        });
    };

    ThisAndThatTestClass.prototype.bindHandler = function () {
        // Va
        //this.jTestDom.click((evt) => this.myHandler(evt));
        this.jTestDom.click($.proxy(this.myHandler, this));
    };
    ThisAndThatTestClass.prototype.myHandler = function (evt) {
        textContext.testOutput = this.someText + '_' + evt.type;
    };
    return ThisAndThatTestClass;
})();

test('2 - When Bind a Click using ()=> keyword "this" is the DomElement', function () {
    // ARRANGE
    var jTestDom = textContext.jTestDom;
    var testClass = new ThisAndThatTestClass(jTestDom);
    testClass.bindHandlerWithLambda();

    // ACT
    jTestDom.click();

    // ASSERT
    equal(textContext.testOutput, 'someText');
});

test('2.1 - When Bind a Click using ()=> keyword "this" is the DomElement', function () {
    // ARRANGE
    var jTestDom = textContext.jTestDom;
    var testClass = new ThisAndThatTestClass(jTestDom);
    testClass.bindHandler();

    // ACT
    jTestDom.click();

    // ASSERT
    equal(textContext.testOutput, 'someText_click');
});
//# sourceMappingURL=ThisAndThatTests.js.map
