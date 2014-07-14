/// <reference path="../Scripts/jquery.d.ts" />


module myAjaxModule {
    export class MyAjaxClass{
        private doer: StuffDoer;
        constructor() {
            this.doer = new StuffDoer();
        }
     
        public DoAjax() {
            $.ajax({
                url:"/TypeScriptTest/AjaxCall/1"
            }).then(() => this.AjaxRespomse);
        }
        private Aha(serverObject) {
            this.doer.Aha(serverObject);
        }
        private AjaxRespomse(serverObject) {
            this.Aha(serverObject);
        }
    }

    class StuffDoer {
        public Aha(serverObject) {
            $('#stuffHere').html('<div>' + serverObject.MyProperty + '</div>');
        }
    }
}

$(document).ready(() => {

    $('#clickToStuff').click(() => {
        var myClass = new myAjaxModule.MyAjaxClass();
        myClass.DoAjax();
    });
});