require.config({
    paths: {
        "jquery": 'vendor/jquery'
    },
    shim: {
        "helpers/stubJsModule": {
            deps: ["jquery"]
        }
    }
    
});

//requirejs(["jquery","helpers/utils2"], function (jq,utils) {
//    jq('body').text(utils.mostro());
//});

requirejs(["helpers/stubJsModule"], function () {
    $('body').text('daigual');
});


//requirejs(["pepe/pepe"], function (utils) {
//    console.log(utils.elpepe);
//});




function pepe() {
    
    var addOne = function(oneIntParameter) {
        return oneIntParameter + 1;
    };
    
    var result = addOne(4);
}