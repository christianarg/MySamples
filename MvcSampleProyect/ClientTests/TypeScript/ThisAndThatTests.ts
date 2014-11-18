/// <reference path="../../Scripts/jquery.d.ts" />
/// <reference path="../Framework/qunit.d.ts" />

class TestContext {

    testOutput: string; // para recoger la salida de los tests 
    jTestDom: JQuery; // Dom a utilizar en cada Test
}

// Variable global 
var textContext: TestContext;


QUnit.module("ThisAndThatTest", {
    setup: () => {
        textContext = new TestContext();
        var jSomeDom = $('<div id="someDomId"></div>');
        $('#qunit-fixture').append(jSomeDom);
        textContext.jTestDom = jSomeDom;
    },
    teardown: () => {

    }
});


test('1 - When Bind a Click using function() keyword "this" is the DomElement', () => {
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


test('1.1 - When Bind a Click using function name keyword "this" is the DomElement and event Arguments recieved', () => {
    // ARRANGE
    var jSomeDom = textContext.jTestDom;
    jSomeDom.click(clickHandler);
    // ACT
    jSomeDom.click();
    // ASSERT 
    equal(textContext.testOutput, 'someDomId_click');
});

function clickHandler(evt: JQueryEventObject) {
    textContext.testOutput = $(this).attr('id') + '_' + evt.type;
}


class ThisAndThatTestClass {
    private someText = 'someText';
    private jTestDom: JQuery;
    constructor(jDom: JQuery) {
        this.jTestDom = jDom;
    }
    public getSomeText() {
        return this.someText;
    }

    public bindHandlerWithLambda() {
        this.jTestDom.click(() => {
            textContext.testOutput = this.someText;
        });
    }

    public bindHandler() {
        // Va
        //this.jTestDom.click((evt) => this.myHandler(evt));
        this.jTestDom.click($.proxy(this.myHandler,this));
        
    }
    private myHandler(evt: JQueryEventObject) {
        textContext.testOutput = this.someText + '_' + evt.type;
    }
}

test('2 - When Bind a Click using ()=> keyword "this" is the DomElement', () => {
    // ARRANGE
    var jTestDom = textContext.jTestDom;
    var testClass = new ThisAndThatTestClass(jTestDom);
    testClass.bindHandlerWithLambda();
    // ACT
    jTestDom.click();
    // ASSERT 
    equal(textContext.testOutput, 'someText');
});

test('2.1 - When Bind a Click using ()=> keyword "this" is the DomElement', () => {
    // ARRANGE
    var jTestDom = textContext.jTestDom;
    var testClass = new ThisAndThatTestClass(jTestDom);
    testClass.bindHandler();
    // ACT
    jTestDom.click();
    // ASSERT 
    equal(textContext.testOutput, 'someText_click');
});