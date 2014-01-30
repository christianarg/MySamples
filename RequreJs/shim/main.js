require.config({
    paths: {
        "jquery": 'vendor/jquery'
    },
    shim: {
        "helpers/OldFashionJsWithNamespace": {
            deps: ["jquery"]
        }
    }
    
});

//requirejs(["jquery","helpers/utils2"], function (jq,utils) {
//    jq('body').text(utils.mostro());
//});



requirejs(["helpers/OldFashionJsWithNamespace"], function (utils) {
    Pb.Eip.HelloWorld.hola();
});


//requirejs(["pepe/pepe"], function (utils) {
//    console.log(utils.elpepe);
//});